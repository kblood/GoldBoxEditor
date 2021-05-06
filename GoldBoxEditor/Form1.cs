using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoldBoxEditor
{
    public partial class Form1 : Form
    {
        GoldBoxCharacter loadedCharacter;

        public Form1()
        {
            InitializeComponent();

            List<string> items = new List<string>() {"Int16","Int32","Number","Text","Byte"};

            comboBox.Items.AddRange(items.ToArray());
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"G:\",
                Title = "Browse DQK Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "qch",
                Filter = "qch files (*.qch)|*.qch",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileLabel.Text = openFileDialog1.FileName;
                byte[] bytes = File.ReadAllBytes(openFileDialog1.FileName);
                
                HexTextBox.Text = ByteArrayToString2(bytes);
                AsciiTextBox.Text = Encoding.ASCII.GetString(bytes);

                var attributes = GoldBoxUtility.FindAttributes(bytes);

                var character= 
                      attributes.First() == 112 ? GoldBoxUtility.LoadCharacter(bytes, GameMaps.getDQK_Amiga_Map())
                    : attributes.First() == 120 ? GoldBoxUtility.LoadCharacter(bytes, GameMaps.getDQK_DOS_Map()) 
                    : GoldBoxUtility.LoadCharacter(bytes, GameMaps.getDQK_DOS_Map());

                
                ValuesTextBox.Text = GenericsHelper.GetNamesAndValuesAsString(typeof(GoldBoxCharacter), character).Select(vals => $"{vals.Key}: {vals.Value}").Aggregate((a, b) => $"{a}{Environment.NewLine}{b}");
                ValuesTextBox.Text += Environment.NewLine + "File: " + ByteArrayToString(character.itemsAndEffects);

                loadedCharacter = character;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public static string ByteArrayToString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }

        public static string ByteArrayToString2(byte[] ba)
        {
            return BitConverter.ToString(ba).Replace("-", "");
        }

        public static byte[] StringToByteArray(String hex)
        {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(HexTextBox.Text))
                return;

            List<string> items = new List<string>() {"Int16","Int32","Number","Text","Byte"};
            
            //comboBox.SelectedItem.ToString();
            var bytes = StringToByteArray(HexTextBox.Text);

            try
            {
                var result = GoldBoxUtility.FindValue(bytes, SearchText.Text);
                if (result.Any())
                    AsciiTextBox.Text = result.Select(vals => $"{vals.Key}: {vals.Value}").Aggregate((a, b) => $"{a}{Environment.NewLine}{b}");
                else
                    AsciiTextBox.Text = "No matches found";
            }
            catch { }
        }

        private void compareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"G:\",
                Title = "Browse DQK Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "qch",
                Filter = "qch files (*.qch)|*.qch",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Filelabel2.Text = FileLabel.Text;
                Filelabel3.Text = openFileDialog1.FileName;

                byte[] bytes = File.ReadAllBytes(FileLabel.Text);
                byte[] bytes2 = File.ReadAllBytes(openFileDialog1.FileName);

                //HexTextBox.Text = ByteArrayToString2(bytes);
                //AsciiTextBox.Text = Encoding.ASCII.GetString(bytes);

                //var attributes = GoldBoxUtility.FindAttributes(bytes2);

                //var character=
                //      attributes.First() == 112 ? GoldBoxUtility.LoadCharacter(bytes2, GameMaps.getDQK_Amiga_Map())
                //    : attributes.First() == 120 ? GoldBoxUtility.LoadCharacter(bytes2, GameMaps.getDQK_DOS_Map())
                //    : GoldBoxUtility.LoadCharacter(bytes2, GameMaps.getDQK_DOS_Map());

                //ValuesTextBox.Text = GenericsHelper.GetNamesAndValuesAsString(typeof(GoldBoxCharacter), character).Select(vals => $"{vals.Key}: {vals.Value}").Aggregate((a, b) => $"{a}{Environment.NewLine}{b}");
                //ValuesTextBox.Text += Environment.NewLine + "File: " + ByteArrayToString(bytes2.Skip(414).ToArray());

                var attributes = GoldBoxUtility.FindAttributes(bytes2);

                var character=
                      attributes.First() == 112 ? GoldBoxUtility.LoadCharacter(bytes2, GameMaps.getDQK_Amiga_Map())
                    : attributes.First() == 120 ? GoldBoxUtility.LoadCharacter(bytes2, GameMaps.getDQK_DOS_Map())
                    : GoldBoxUtility.LoadCharacter(bytes2, GameMaps.getDQK_DOS_Map());


                Values2TextBox.Text = GenericsHelper.GetNamesAndValuesAsString(typeof(GoldBoxCharacter), character).Select(vals => $"{vals.Key}: {vals.Value}").Aggregate((a, b) => $"{a}{Environment.NewLine}{b}");
                Values2TextBox.Text += Environment.NewLine + "File: " + ByteArrayToString(character.itemsAndEffects);

                var comparison = GoldBoxUtility.CompareFiles(bytes, bytes2);
                if(comparison != null && comparison.Any())
                {
                    AsciiTextBox.Text = comparison.Aggregate((a, b) => $"{a}{Environment.NewLine}{b}");
                    //ValuesTextBox2.Text = comparison.Aggregate((a, b) => $"{a}{Environment.NewLine}{b}");
                }
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (loadedCharacter == null)
                return;


            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                InitialDirectory = @"g:\Games\The Dark Queen of Krynn\cloud_saves\SAVE\",
                Title = "Save Character As",

                CheckFileExists = false,
                CheckPathExists = true,

                DefaultExt = "qch",
                Filter = "qch files (*.qch)|*.qch",
                FilterIndex = 2,
                RestoreDirectory = true,
            };

            

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                GoldBoxCharacter character = loadedCharacter;

                character.name = Path.GetFileNameWithoutExtension(saveFileDialog.FileName);
                character.strength = character.original_strength;
                character.constitution = character.original_constitution;
                character.movementCurrent = character.movementBase;
                character.acCurrent = character.acBase;
                character.thac0Current = character.thac0base;
                character.encumberance = 0;
                character.handsEquipped = 0;
                character.hostile = 0;
                //character.npc = 0;
                character.numberOfItems = 0;
                
                //character.hitpointsCurrent = character.hitpointsRolled;

                var bytes = GoldBoxUtility.ConvertCharacterToByteArray(character, GameMaps.getDQK_DOS_Map());

                File.WriteAllBytes(saveFileDialog.FileName, bytes);
            }

            //HexTextBox.Text = ByteArrayToString2(bytes);
            //AsciiTextBox.Text = Encoding.ASCII.GetString(bytes);

            //var attributes = GoldBoxUtility.FindAttributes(bytes);

            //var character=
            //          attributes.First() == 112 ? GoldBoxUtility.LoadCharacter(bytes, GameMaps.getDQK_Amiga_Map())
            //        : attributes.First() == 120 ? GoldBoxUtility.LoadCharacter(bytes, GameMaps.getDQK_DOS_Map())
            //        : GoldBoxUtility.LoadCharacter(bytes, GameMaps.getDQK_DOS_Map());

            //ValuesTextBox.Text = GenericsHelper.GetNamesAndValuesAsString(typeof(GoldBoxCharacter), character).Select(vals => $"{vals.Key}: {vals.Value}").Aggregate((a, b) => $"{a}{Environment.NewLine}{b}");
            //ValuesTextBox.Text += Environment.NewLine + "File: " + ByteArrayToString(character.itemsAndEffects);

            //loadedCharacter = character;

        }
    }
}
/*
// Next character address
                bytes.Skip(0).Take(4).ToArray();
// Effects address
var effects =bytes.Skip(4).Take(4).ToArray();
// Items address
var items=bytes.Skip(8).Take(4).ToArray();
// Equipped weapon address 
var weapon = bytes.Skip(12).Take(4).ToArray();
// Equipped shield address 
var shield = bytes.Skip(16).Take(4).ToArray();
// Equipped armor address 
var armor = bytes.Skip(20).Take(4).ToArray();
// Equipped gauntlets address 
bytes.Skip(24).Take(4).ToArray();
// Equipped helm address 
bytes.Skip(28).Take(4).ToArray();
// Equipped belt address 
bytes.Skip(32).Take(4).ToArray();
// Equipped robe address 
bytes.Skip(36).Take(4).ToArray();
// Equipped cloak address 
bytes.Skip(40).Take(4).ToArray();
// Equipped boots address 
bytes.Skip(44).Take(4).ToArray();
// Equipped ring 1 address 
bytes.Skip(48).Take(4).ToArray();
// Equipped ring 2 address 
bytes.Skip(52).Take(4).ToArray();
// Equipped arrow address 
bytes.Skip(56).Take(4).ToArray();
// Equipped bolt address 
bytes.Skip(60).Take(4).ToArray();
// Combat address 
bytes.Skip(64).Take(4).ToArray();
// Experience 
var experience = bytes.Skip(68).Take(4).ToArray();
// Highest experience 
var highestexperience = bytes.Skip(72).Take(4).ToArray();
// Coins of steel
var steel = bytes.Skip(76).Take(2).ToArray();
// Gems
var gems = bytes.Skip(78).Take(2).ToArray();
// Jewelery
var jewelery = bytes.Skip(80).Take(2).ToArray();
// Age
var age = bytes.Skip(82).Take(2).ToArray();
// XP Award
var XPaward = bytes.Skip(84).Take(2).ToArray();
// Encumberance
var encumberance = bytes.Skip(86).Take(2).ToArray();
// Race
var race=bytes.Skip(88).Take(1).ToArray();
// Class
var charclass = bytes.Skip(90).Take(1).ToArray();
// Level undead
bytes.Skip(92).Take(1).ToArray();
// Gender
var gender=bytes.Skip(96).Take(1).ToArray();
// Alignemnt
var alignment = bytes.Skip(98).Take(1).ToArray();
// Status
var status = bytes.Skip(100).Take(1).ToArray();
// Hostile
bytes.Skip(102).Take(1).ToArray();
// Name
var name = bytes.Skip(104).Take(15).ToArray();
// String terminator
bytes.Skip(119).Take(1).ToArray();
var strengthOriginal = bytes.Skip(120).Take(1).ToArray();
var strengthCurrent = bytes.Skip(121).Take(1).ToArray();
var intelligenceOriginal = bytes.Skip(122).Take(1).ToArray();
var intelligenceCurrent = bytes.Skip(123).Take(1).ToArray();
var wisdomOriginal = bytes.Skip(124).Take(1).ToArray();
var wisdomCurrent = bytes.Skip(125).Take(1).ToArray();
var dexterityOriginal = bytes.Skip(126).Take(1).ToArray();
var dexterityCurrent = bytes.Skip(127).Take(1).ToArray();
var constitutionOriginal = bytes.Skip(128).Take(1).ToArray();
var constitutionCurrent = bytes.Skip(129).Take(1).ToArray();
var charismaOriginal = bytes.Skip(130).Take(1).ToArray();
var charismaCurrent = bytes.Skip(131).Take(1).ToArray();
var strengthExcOriginal = bytes.Skip(132).Take(1).ToArray();
var strengthExcCurrent = bytes.Skip(13).Take(1).ToArray();

 * Name: CAIN BLOODBANE
 * Age: 34
 * XP: 1000001
 * Male
 * Human
 * Knight
 * 
 * Name: CAIN BLOODBANE
 * Age: 58
 * XP: 333333
 * Male
 * Half-Elf
 * Cleric/Fighter/Mage
 * 
saveInfo += "Character name: " + character.name; //System.Text.Encoding.ASCII.GetString(bytes.Skip(104).Take(nameLength).ToArray());
                //saveInfo += Environment.NewLine + "-" + BitConverter.ToChar(bytes, 104);
                //saveInfo += Environment.NewLine + "-" + BitConverter.ToChar(bytes, 106);
                //saveInfo += Environment.NewLine + "-" + BitConverter.ToChar(bytes, 108);
                //saveInfo += Environment.NewLine + "r-" + BitConverter.ToChar(bytes, 110);
                //saveInfo += Environment.NewLine + "-" + BitConverter.ToChar(bytes, 112);
                //saveInfo += Environment.NewLine + "-" + BitConverter.ToChar(bytes, 114);
                //saveInfo += Environment.NewLine + "b-" +BitConverter.ToChar(bytes, 116);
                //saveInfo += Environment.NewLine + "b1 - /" + BitConverter.ToChar(bytes, 118);
                //saveInfo += Environment.NewLine + "-" + BitConverter.ToChar(bytes, 105);
                //saveInfo += Environment.NewLine + "break: " + BitConverter.ToChar(bytes, 118);
                saveInfo += Environment.NewLine + "Character experience: " +            character.experience;//BitConverter.ToInt32(bytes, 68);  //BitConverter.ToInt32(experience, 0);
                saveInfo += Environment.NewLine + "Character highest experience: " +    character.experienceMax;//BitConverter.ToInt32(bytes, 72);
                saveInfo += Environment.NewLine + "Character original strength: "     + character.original_strength;//bytes[120];// BitConverter.ToInt16(bytes, 120);
                saveInfo += Environment.NewLine + "Character current strength: "     +  character.strength;//bytes[121];
                saveInfo += Environment.NewLine + "Character original intelligence: " + character.original_intelligence;//bytes[122];
                saveInfo += Environment.NewLine + "Character current intelligence: " +  character.intelligence;// bytes[123];
                saveInfo += Environment.NewLine + "Character original wisdom: "       + character.original_wisdom;// bytes[124];
                saveInfo += Environment.NewLine + "Character current wisdom: " +        character.wisdom;//bytes[125];
                saveInfo += Environment.NewLine + "Character original dexterity: "    + character.original_dexterity;//bytes[126];
                saveInfo += Environment.NewLine + "Character current dexterity: " +     character.dexterity;//    bytes[127];
                saveInfo += Environment.NewLine + "Character original constitution: " + character.original_constitution;//    bytes[128];
                saveInfo += Environment.NewLine + "Character current constitution: " +  character.constitution;//bytes[129];
                saveInfo += Environment.NewLine + "Character original charisma: "     + character.original_charisma;// bytes[130];
                saveInfo += Environment.NewLine + "Character current charisma: " +      character.charisma;//    bytes[131];
                saveInfo += Environment.NewLine + "Character original strength exc: " + character.original_strengthExpanded;//    bytes[132];
                saveInfo += Environment.NewLine + "Character current strength exc: " +  character.strengthExpanded;//bytes[133];
                saveInfo += Environment.NewLine + "Number of items: " +                 character.itemLimits;//    bytes[201];
                saveInfo += Environment.NewLine + "Item limit: " +                      character.itemLimits;//    bytes[191];

                saveInfo += Environment.NewLine + "Robe: " +       character.robe;
                saveInfo += Environment.NewLine + "Thac0: " +      character.thac0base;
                saveInfo += Environment.NewLine + "AC: " +         character.acBase;
                saveInfo += Environment.NewLine + "Race: " +       character.race;
                saveInfo += Environment.NewLine + "Class: " +      character.char_class;
                saveInfo += Environment.NewLine + "Gender: " +      character.gender;

                //saveInfo += Environment.NewLine + "Effects address: " +ByteArrayToString(effects);  //+ BitConverter.ToInt32(bytes,4);
                //saveInfo += Environment.NewLine + "Items address: "   +ByteArrayToString(items);  //+ BitConverter.ToInt32(bytes, 8);
                //saveInfo += Environment.NewLine + "Weapon address: "  +ByteArrayToString(weapon);  //+ BitConverter.ToInt32(bytes, 12);
                //saveInfo += Environment.NewLine + "Shield address: "  +ByteArrayToString(shield);  //+ BitConverter.ToInt32(bytes, 16);
                //saveInfo += Environment.NewLine + "Armor address: " + ByteArrayToString(armor);  //+ BitConverter.ToInt32(bytes, 20);

                //saveInfo += Environment.NewLine + "File: " + ByteArrayToString(bytes.Skip(414).ToArray());
                //saveInfo += Environment.NewLine + "Next Character address: " + BitConverter.ToSingle(bytes.Take(4).ToArray(), 0);
                //saveInfo += Environment.NewLine + "Effect address: " + ByteArrayToString(bytes.Skip(4).Take(4).ToArray());
                //saveInfo += Environment.NewLine + "Effect address: " + BitConverter.ToInt32(bytes.Skip(4).Take(4).ToArray(), 0);

                //saveInfo += Environment.NewLine + "Character name: " + ByteArrayToString2(bytes).Substring(104, 15);
                //AsciiTextBox.Text = System.Text.Encoding.ASCII.GetString(bytes);
                //AsciiTextBox.Text = saveInfo;


*
*
 */
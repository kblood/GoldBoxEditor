using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GoldBoxEditor
{
    public class GoldBoxUtility
    {
        static public List<int> FindAttributes(byte[] characterFile)
        {
            List<int> attributes = new List<int>();

            //int j = 0;

            for(int i = 0; i< characterFile.Count(); i++)
            {
                if (characterFile[i] > 8 && characterFile[i] <= 23)
                    attributes.Add(i);

                if(characterFile[i] <= 8 || characterFile[i] > 23)
                {
                    if (attributes.Count() > 4)
                        return attributes;
                    else
                        attributes.Clear();
                }
            }

            return attributes;
        }

        static public List<string> CompareFiles(byte[] file1, byte[] file2)
        {
            List<string> comparison = new List<string>();

            for(int i = 0; i < file1.Length || i < file2.Length; i++)
            {
                if(file1.Length <= i)
                    comparison.Add($"Byte {i}: eof vs {file2[i]}");
                else if (file2.Length <= i)
                    comparison.Add($"Byte {i}: {file1[i]} vs eof");
                else if (file1[i] != file2[i])
                    comparison.Add($"Byte {i}: {file1[i]} vs {file2[i]}");
            }
            return comparison;
        }

        static public List<int> FindSequence(byte[] characterFile, List<int> variables)
        {
            List<int> attributes = new List<int>();

            for (int i = 0; i < characterFile.Count()- variables.Count(); i++)
            {
                List<int> sequence = new List<int>();

                for (int j = 0; j<variables.Count();j++)
                {
                    if (characterFile[i + j] == variables[j])
                        sequence.Add(i + j);
                }
                if (sequence.Count() == variables.Count())
                    attributes.AddRange(sequence);
            }

            return attributes;
        }

        static public Dictionary<int, string> FindValue(byte[] bytes, string value)
        {
            Dictionary<int, string> values = new Dictionary<int, string>();

            float number = -1;
            //int j = 0;
            if(value.Contains(","))
            {
                var variables = value.Split(',').Select(n => int.Parse(n)).ToList();
                var sequence = FindSequence(bytes, variables);
                if (sequence.Any())
                    return sequence.ToDictionary(d => d, d => "Byte: " + bytes[d]);
            }
            else
            for (int i = 0; i < bytes.Count(); i++)
            {
                if(float.TryParse(value, out number))
                {
                    float currentValue = -1;
                    if (bytes.Length >= i + 8)
                        currentValue = BitConverter.ToSingle(bytes, i);
                    if (currentValue == number)
                    {
                        values.Add(i, "Float: " + value);
                        continue;
                    }
                    if (bytes.Length >= i + 4)
                        currentValue = BitConverter.ToInt32(bytes, i);
                    if (currentValue == number)
                    {
                        values.Add(i, "Int32: " + value);
                        continue;
                    }
                    if (bytes.Length >= i + 2)
                        currentValue = BitConverter.ToInt16(bytes, i);
                    if (currentValue == number)
                    {
                        values.Add(i, "Int16: " + value);
                        continue;
                    }
                    currentValue = bytes[i];
                    if (currentValue == number)
                    {
                        values.Add(i, "Byte: " + value);
                        continue;
                    }
                    continue;
                }
                else
                {
                    if(bytes.Length >= i+value.Length)
                    {
                        string currentValue=Encoding.ASCII.GetString(bytes.Skip(i).Take(value.Length).ToArray());
                        if (currentValue.ToLower() == value.ToLower())
                            values.Add(i, currentValue);
                    }
                }
            }

            return values;
        }

        static public GoldBoxCharacter LoadCharacter(byte[] characterFile, GoldBoxSaveMap fileMap)
        {
            var character = new GoldBoxCharacter()
            {
                nextCharacterAddress        =       ByteArrayToString(characterFile.Skip(fileMap.nextCharacterAddress).Take(4).ToArray()),
                effectsAddress              =       ByteArrayToString(characterFile.Skip(fileMap.effectsAddress).Take(4).ToArray()),
                itemsAddress                =       ByteArrayToString(characterFile.Skip(fileMap.itemsAddress).Take(4).ToArray()),
                equippedWeaponAddress       =       ByteArrayToString(characterFile.Skip(fileMap.equippedWeaponAddress).Take(4).ToArray()),
                equippedShieldAddress       =       ByteArrayToString(characterFile.Skip(fileMap.equippedShieldAddress).Take(4).ToArray()),
                equippedArmorAddress        =       ByteArrayToString(characterFile.Skip(fileMap.equippedArmorAddress).Take(4).ToArray()),
                equippedGauntletsAddress    =       ByteArrayToString(characterFile.Skip(fileMap.equippedGauntletsAddress).Take(4).ToArray()),
                equippedHelmAddress         =       ByteArrayToString(characterFile.Skip(fileMap.equippedHelmAddress).Take(4).ToArray()),
                equippedBeltAddress         =       ByteArrayToString(characterFile.Skip(fileMap.equippedBeltAddress).Take(4).ToArray()),
                equippedRobeAddress         =       ByteArrayToString(characterFile.Skip(fileMap.equippedRobeAddress).Take(4).ToArray()),
                equippedCloakAddress        =       ByteArrayToString(characterFile.Skip(fileMap.equippedCloakAddress).Take(4).ToArray()),
                equippedBootsAddress        =       ByteArrayToString(characterFile.Skip(fileMap.equippedBootsAddress).Take(4).ToArray()),
                equippedRing1Address        =       ByteArrayToString(characterFile.Skip(fileMap.equippedRing1Address).Take(4).ToArray()),
                equippedRing2Address        =       ByteArrayToString(characterFile.Skip(fileMap.equippedRing2Address).Take(4).ToArray()),
                equippedArrowAddress        =       ByteArrayToString(characterFile.Skip(fileMap.equippedArrowAddress).Take(4).ToArray()),
                equippedBoltAddress         =       ByteArrayToString(characterFile.Skip(fileMap.equippedBoltAddress).Take(4).ToArray()),
                combatAddress               =       ByteArrayToString(characterFile.Skip(fileMap.combatAddress).Take(4).ToArray()),
                strength                    =       characterFile[fileMap.strength],
                original_strength           =       characterFile[fileMap.original_strength],
                intelligence                =       characterFile[fileMap.intelligence],
                original_intelligence       =       characterFile[fileMap.original_intelligence],
                wisdom                      =       characterFile[fileMap.wisdom],
                original_wisdom             =       characterFile[fileMap.original_wisdom],
                dexterity                   =       characterFile[fileMap.dexterity],
                original_dexterity          =       characterFile[fileMap.original_dexterity],
                constitution                =       characterFile[fileMap.constitution],
                original_constitution       =       characterFile[fileMap.original_constitution],
                charisma                    =       characterFile[fileMap.charisma],
                original_charisma           =       characterFile[fileMap.original_charisma],
                strengthExpanded            =       characterFile[fileMap.strengthExpanded],
                original_strengthExpanded   =       characterFile[fileMap.original_strengthExpanded],
                experience                  =       BitConverter.ToInt32(characterFile,fileMap.experience),
                experienceMax               =       BitConverter.ToInt32(characterFile,fileMap.experienceMax),
                experienceAward             =       BitConverter.ToInt16(characterFile,fileMap.experienceMax),
                steel                       =       BitConverter.ToInt16(characterFile,fileMap.steel),
                gems                        =       BitConverter.ToInt16(characterFile,fileMap.gems),
                jewelery                    =       BitConverter.ToInt16(characterFile,fileMap.jewelery),
                age                         =       BitConverter.ToInt16(characterFile,fileMap.age),
                encumberance                =       BitConverter.ToInt16(characterFile,fileMap.encumberance),
                race                        =       characterFile[fileMap.race],
                char_class                  =       characterFile[fileMap.char_class],
                gender                      =       characterFile[fileMap.gender],
                alignment                   =       characterFile[fileMap.alignment],
                god                         =       characterFile[fileMap.god],
                knight                      =       characterFile[fileMap.knight],
                robe                        =       characterFile[fileMap.robe],
                status                      =       characterFile[fileMap.status],
                highestHitpoints            =       characterFile[fileMap.highestHitpoints],
                hitpointsRolled             =       characterFile[fileMap.hitpointsRolled],
                hitpointsCurrent            =       characterFile[fileMap.hitpointsCurrent],
                movementBase                =       characterFile[fileMap.movementBase],
                movementCurrent             =       characterFile[fileMap.movementCurrent],
                acBase                      =       characterFile[fileMap.acBase],
                acCurrent                   =       characterFile[fileMap.acCurrent],
                thac0base                   =       characterFile[fileMap.thac0base],
                thac0Current                =       characterFile[fileMap.thac0Current],
                cureDiseaseCount            =       characterFile[fileMap.cureDiseaseCount],
                savethrow1                  =       characterFile[fileMap.savethrow1],
                savethrow2                  =       characterFile[fileMap.savethrow2],
                savethrow3                  =       characterFile[fileMap.savethrow3],
                savethrow4                  =       characterFile[fileMap.savethrow4],
                savethrow5                  =       characterFile[fileMap.savethrow5],
                levelHighest1               =       characterFile[fileMap.levelHighest1],
                levelHighest2               =       characterFile[fileMap.levelHighest2],
                thief1                      =       characterFile[fileMap.thief1],
                thief2                      =       characterFile[fileMap.thief2],
                thief3                      =       characterFile[fileMap.thief3],
                thief4                      =       characterFile[fileMap.thief4],
                thief5                      =       characterFile[fileMap.thief5],
                thief6                      =       characterFile[fileMap.thief6],
                thief7                      =       characterFile[fileMap.thief7],
                thief8                      =       characterFile[fileMap.thief8],
                highestLevelCleric          =       characterFile[fileMap.highestLevelCleric],
                highestLevelKnight          =       characterFile[fileMap.highestLevelKnight],
                highestLevelFighter         =       characterFile[fileMap.highestLevelFighter],
                highestLevelPaladin         =       characterFile[fileMap.highestLevelPaladin],
                highestLevelRanger          =       characterFile[fileMap.highestLevelRanger],
                highestLevelMage            =       characterFile[fileMap.highestLevelMage],
                highestLevelThief           =       characterFile[fileMap.highestLevelThief],
                levelCleric                 =       characterFile[fileMap.levelCleric],
                levelKnight                 =       characterFile[fileMap.levelKnight],
                levelFighter                =       characterFile[fileMap.levelFighter],
                levelPaladin                =       characterFile[fileMap.levelPaladin],
                levelRanger                 =       characterFile[fileMap.levelRanger],
                levelMage                   =       characterFile[fileMap.levelMage],
                levelThief                  =       characterFile[fileMap.levelThief],
                formerLevelCleric           =       characterFile[fileMap.formerLevelCleric],
                formerLevelKnight           =       characterFile[fileMap.formerLevelKnight],
                formerLevelFighter          =       characterFile[fileMap.formerLevelFighter],
                formerLevelPaladin          =       characterFile[fileMap.formerLevelPaladin],
                formerLevelRanger           =       characterFile[fileMap.formerLevelRanger],
                formerLevelMage             =       characterFile[fileMap.formerLevelMage],
                formerLevelThief            =       characterFile[fileMap.formerLevelThief],
                attacks1                    =       characterFile[fileMap.attacks1],
                attacks2                    =       characterFile[fileMap.attacks2],
                currentAttacks1             =       characterFile[fileMap.currentAttacks1],
                currentAttacks2             =       characterFile[fileMap.currentAttacks2],
                currentRolls                =       characterFile[fileMap.currentRolls],
                currentRolls2               =       characterFile[fileMap.currentRolls2],
                currentDice                 =       characterFile[fileMap.currentDice],
                currentDice2                =       characterFile[fileMap.currentDice2],
                currentModifier             =       characterFile[fileMap.currentModifier],
                currentModifier2            =       characterFile[fileMap.currentModifier2],
                unarmedRolls                =       characterFile[fileMap.unarmedRolls],
                unarmedRolls2               =       characterFile[fileMap.unarmedRolls2],
                unarmedDice                 =       characterFile[fileMap.unarmedDice],
                unarmedDice2                =       characterFile[fileMap.unarmedDice2],
                unarmedModifier             =       characterFile[fileMap.unarmedModifier],
                unarmedModifier2            =       characterFile[fileMap.unarmedModifier2],
                itemLimits                  =       characterFile[fileMap.itemLimits],
                numberOfItems               =       characterFile[fileMap.numberOfItems],
                flags1                      =       characterFile[fileMap.flags1],
                flags2                      =       characterFile[fileMap.flags2],
                saveBonus                   =       characterFile[fileMap.saveBonus],
                MagicResistance             =       characterFile[fileMap.MagicResistance],
                clericSpells1               =       characterFile[fileMap.clericSpells1],
                clericSpells2               =       characterFile[fileMap.clericSpells2],
                clericSpells3               =       characterFile[fileMap.clericSpells3],
                clericSpells4               =       characterFile[fileMap.clericSpells4],
                clericSpells5               =       characterFile[fileMap.clericSpells5],
                clericSpells6               =       characterFile[fileMap.clericSpells6],
                clericSpells7               =       characterFile[fileMap.clericSpells7],
                druidSpells1                =       characterFile[fileMap.druidSpells1],
                druidSpells2                =       characterFile[fileMap.druidSpells2],
                druidSpells3                =       characterFile[fileMap.druidSpells3],
                mageSpells1                 =       characterFile[fileMap.mageSpells1],
                mageSpells2                 =       characterFile[fileMap.mageSpells2],
                mageSpells3                 =       characterFile[fileMap.mageSpells3],
                mageSpells4                 =       characterFile[fileMap.mageSpells4],
                mageSpells5                 =       characterFile[fileMap.mageSpells5],
                mageSpells6                 =       characterFile[fileMap.mageSpells6],
                mageSpells7                 =       characterFile[fileMap.mageSpells7],
                mageSpells8                 =       characterFile[fileMap.mageSpells8],
                mageSpells9                 =       characterFile[fileMap.mageSpells9],
                levelUndead                 =       characterFile[fileMap.levelUndead],
                ableToTrain                 =       characterFile[fileMap.ableToTrain],
                npc                         =       characterFile[fileMap.npc],
                icon                        =       characterFile[fileMap.icon],
                iconDimensions              =       characterFile[fileMap.iconDimensions],
                iconColor1Body              =       characterFile[fileMap.iconColor1Body],
                iconColor2Body              =       characterFile[fileMap.iconColor2Body],
                iconColor1Arm               =       characterFile[fileMap.iconColor1Arm],
                iconColor2Arm               =       characterFile[fileMap.iconColor2Arm],
                iconColor1Leg               =       characterFile[fileMap.iconColor1Leg],
                iconColor2Leg               =       characterFile[fileMap.iconColor2Leg],
                iconColor1Hair              =       characterFile[fileMap.iconColor1Hair],
                iconColor2Face              =       characterFile[fileMap.iconColor2Face],
                iconColor1Shield            =       characterFile[fileMap.iconColor1Shield],
                iconColor2Shield            =       characterFile[fileMap.iconColor2Shield],
                iconColor1Weapon            =       characterFile[fileMap.iconColor1Weapon],
                iconColor2Weapon            =       characterFile[fileMap.iconColor2Weapon],
                handsEquipped               =       characterFile[fileMap.handsEquipped],
                enabled                     =       characterFile[fileMap.enabled],
                hostile                     =       characterFile[fileMap.hostile],
                quickfight                  =       characterFile[fileMap.quickfight]
            };

            int nameLength = 0;
            byte[] name = characterFile.Skip(fileMap.name).Take(16).ToArray();
            for (int i = 0; i < name.Length; i++)
            {
                nameLength = i;
                if (name[i] == 0)
                {
                    break;
                }
            }

            character.name = System.Text.Encoding.ASCII.GetString(characterFile.Skip(fileMap.name).Take(nameLength).ToArray());
            character.memorizedSpells = characterFile.Skip(fileMap.memorizedSpells).Take(fileMap.memorizedSpellsByteLength).ToArray();
            character.knownSpells = characterFile.Skip(fileMap.knownSpells).Take(fileMap.knownSpellsByteLength).ToArray();
            character.itemsAndEffects = characterFile.Skip(fileMap.itemsAndEffects).ToArray();
            character.items = new List<byte[]>();
            for (int i = 0; i < character.numberOfItems; i++)
                character.items.Add(character.itemsAndEffects.Skip(i*fileMap.itemByteLength).Take(fileMap.itemByteLength).ToArray());
            byte[] effects = character.itemsAndEffects.Skip(character.numberOfItems*fileMap.itemByteLength).ToArray();
            int numberOfEffects = effects.Length / fileMap.effectByteLength;
            character.effects = new List<byte[]>();
            for (int i = 0; i < numberOfEffects; i++)
                character.effects.Add(effects.Skip(i*fileMap.effectByteLength).Take(fileMap.effectByteLength).ToArray());

            //DOS Bytes 414-431 = first item. Item = 18 bytes? Amiga bytes 416-433 = first item. Items size 18 bytes
            //423-431  Effect = 10 bytes? Amiga DQK effect = 10 bytes. DOS DQK effect = 9 bytes

            return character;
        }

        static public byte[] ConvertCharacterToByteArray(GoldBoxCharacter character, GoldBoxSaveMap fileMap)
        {
            List<byte> characterBytes = new List<byte>();

            for (int i = 0; i < fileMap.itemsAndEffects; i++)
                characterBytes.Add(0);
            characterBytes.RemoveRange(fileMap.experience, BitConverter.GetBytes(character.experience).Length);
            characterBytes.InsertRange(fileMap.experience, BitConverter.GetBytes(character.experience));
            characterBytes.RemoveRange(fileMap.experienceMax, BitConverter.GetBytes(character.experienceMax).Length);
            characterBytes.InsertRange(fileMap.experienceMax, BitConverter.GetBytes(character.experienceMax));
            characterBytes.RemoveRange(fileMap.steel, BitConverter.GetBytes(character.steel).Length);
            characterBytes.InsertRange(fileMap.steel,BitConverter.GetBytes(character.steel));
            characterBytes.RemoveRange(fileMap.gems, BitConverter.GetBytes(character.gems).Length);
            characterBytes.InsertRange(fileMap.gems,BitConverter.GetBytes(character.gems));
            characterBytes.RemoveRange(fileMap.jewelery, BitConverter.GetBytes(character.jewelery).Length);
            characterBytes.InsertRange(fileMap.jewelery,BitConverter.GetBytes(character.jewelery));
            characterBytes.RemoveRange(fileMap.age, BitConverter.GetBytes(character.age).Length);
            characterBytes.InsertRange(fileMap.age,BitConverter.GetBytes(character.age));
            characterBytes.RemoveRange(fileMap.experienceAward, BitConverter.GetBytes(character.experienceAward).Length);
            characterBytes.InsertRange(fileMap.experienceAward,BitConverter.GetBytes(character.experienceAward));
            characterBytes.RemoveRange(fileMap.encumberance, BitConverter.GetBytes(character.encumberance).Length);
            characterBytes.InsertRange(fileMap.encumberance, BitConverter.GetBytes(character.encumberance));
            characterBytes.RemoveAt(fileMap.race);
            characterBytes.Insert(fileMap.race, character.race);
            characterBytes.RemoveAt(fileMap.char_class);
            characterBytes.Insert(fileMap.char_class, character.char_class);
            characterBytes.RemoveAt(fileMap.levelUndead);
            characterBytes.Insert(fileMap.levelUndead, character.levelUndead);
            characterBytes.RemoveAt(fileMap.gender);
            characterBytes.Insert(fileMap.gender, character.gender);
            characterBytes.RemoveAt(fileMap.alignment);
            characterBytes.Insert(fileMap.alignment, character.alignment);
            characterBytes.RemoveAt(fileMap.status);
            characterBytes.Insert(fileMap.status, character.status);
            characterBytes.RemoveAt(fileMap.hostile);
            characterBytes.Insert(fileMap.hostile, character.hostile);
            characterBytes.RemoveRange(fileMap.name, StringToByteArray(character.name).Length);
            characterBytes.InsertRange(fileMap.name, StringToByteArray(character.name));
            characterBytes.RemoveAt(fileMap.original_strength); characterBytes.Insert(fileMap.original_strength        , character.original_strength        );
            characterBytes.RemoveAt(fileMap.strength           );characterBytes.Insert(fileMap.strength                 , character.strength                 );
            characterBytes.RemoveAt(fileMap.original_intelligence);characterBytes.Insert(fileMap.original_intelligence    , character.original_intelligence    );
            characterBytes.RemoveAt(fileMap.intelligence         );characterBytes.Insert(fileMap.intelligence             , character.intelligence             );
            characterBytes.RemoveAt(fileMap.original_wisdom      );characterBytes.Insert(fileMap.original_wisdom          , character.original_wisdom          );
            characterBytes.RemoveAt(fileMap.wisdom               );characterBytes.Insert(fileMap.wisdom                   , character.wisdom                   );
            characterBytes.RemoveAt(fileMap.original_dexterity   );characterBytes.Insert(fileMap.original_dexterity       , character.original_dexterity       );
            characterBytes.RemoveAt(fileMap.dexterity            );characterBytes.Insert(fileMap.dexterity                , character.dexterity                );
            characterBytes.RemoveAt(fileMap.original_constitution);characterBytes.Insert(fileMap.original_constitution    , character.original_constitution    );
            characterBytes.RemoveAt(fileMap.constitution         );characterBytes.Insert(fileMap.constitution             , character.constitution             ); 
            characterBytes.RemoveAt(fileMap.original_charisma    );characterBytes.Insert(fileMap.original_charisma        , character.original_charisma        );
            characterBytes.RemoveAt(fileMap.charisma             );characterBytes.Insert(fileMap.charisma                 , character.charisma                 );
            characterBytes.RemoveRange(fileMap.original_strengthExpanded, BitConverter.GetBytes(character.original_strengthExpanded).Length);
            characterBytes.InsertRange(fileMap.original_strengthExpanded, BitConverter.GetBytes(character.original_strengthExpanded));
            characterBytes.RemoveRange(fileMap.strengthExpanded, BitConverter.GetBytes(character.original_strengthExpanded).Length);
            characterBytes.InsertRange(fileMap.strengthExpanded         , BitConverter.GetBytes(character.strengthExpanded));
            characterBytes.RemoveAt(fileMap.thac0base);
            characterBytes.Insert(fileMap.thac0base, character.thac0base);
            characterBytes.RemoveAt(fileMap.thac0Current);
            characterBytes.Insert(fileMap.thac0Current, character.thac0Current);
            characterBytes.RemoveAt(fileMap.cureDiseaseCount);
            characterBytes.Insert(fileMap.cureDiseaseCount, character.cureDiseaseCount);
            characterBytes.RemoveAt(fileMap.highestHitpoints);
            characterBytes.Insert(fileMap.highestHitpoints, character.highestHitpoints);
            characterBytes.RemoveAt(fileMap.hitpointsCurrent);
            characterBytes.Insert(fileMap.hitpointsCurrent, character.hitpointsCurrent);
            characterBytes.RemoveAt(fileMap.hitpointsRolled);
            characterBytes.Insert(fileMap.hitpointsRolled, character.hitpointsRolled);

            characterBytes.RemoveAt(fileMap.iconDimensions);
            characterBytes.Insert(fileMap.iconDimensions, character.iconDimensions);
            characterBytes.RemoveAt(fileMap.savethrow1);
            characterBytes.Insert(fileMap.savethrow1, character.savethrow1);
            characterBytes.RemoveAt(fileMap.savethrow2);
            characterBytes.Insert(fileMap.savethrow2, character.savethrow2);
            characterBytes.RemoveAt(fileMap.savethrow3);
            characterBytes.Insert(fileMap.savethrow3, character.savethrow3);
            characterBytes.RemoveAt(fileMap.savethrow4);
            characterBytes.Insert(fileMap.savethrow4, character.savethrow4);
            characterBytes.RemoveAt(fileMap.savethrow5);
            characterBytes.Insert(fileMap.savethrow5, character.savethrow5);
            characterBytes.RemoveAt(fileMap.movementBase);
            characterBytes.Insert(fileMap.movementBase, character.movementBase);
            characterBytes.RemoveAt(fileMap.movementCurrent);
            characterBytes.Insert(fileMap.movementCurrent, character.movementCurrent);
            characterBytes.RemoveAt(fileMap.levelHighest1);
            characterBytes.Insert(fileMap.levelHighest1, character.levelHighest1);
            characterBytes.RemoveAt(fileMap.levelHighest2);
            characterBytes.Insert(fileMap.levelHighest2, character.levelHighest2);
            characterBytes.RemoveAt(fileMap.thief1);
            characterBytes.Insert(fileMap.thief1, character.thief1);
            characterBytes.RemoveAt(fileMap.thief1);
            characterBytes.Insert(fileMap.thief1, character.thief1);
            characterBytes.RemoveAt(fileMap.thief2);
            characterBytes.Insert(fileMap.thief2, character.thief2);
            characterBytes.RemoveAt(fileMap.thief3);
            characterBytes.Insert(fileMap.thief3, character.thief3);
            characterBytes.RemoveAt(fileMap.thief4);
            characterBytes.Insert(fileMap.thief4, character.thief4);
            characterBytes.RemoveAt(fileMap.thief5);
            characterBytes.Insert(fileMap.thief5, character.thief5);
            characterBytes.RemoveAt(fileMap.thief6);
            characterBytes.Insert(fileMap.thief6, character.thief6);
            characterBytes.RemoveAt(fileMap.thief7);
            characterBytes.Insert(fileMap.thief7, character.thief7);
            characterBytes.RemoveAt(fileMap.thief8);
            characterBytes.Insert(fileMap.thief8, character.thief8);
            characterBytes.RemoveAt(fileMap.npc);
            characterBytes.Insert(fileMap.npc, character.npc);
            characterBytes.RemoveAt(fileMap.highestLevelCleric);
            characterBytes.Insert(fileMap.highestLevelCleric, character.highestLevelCleric);

            characterBytes.RemoveAt(fileMap.highestLevelCleric ); characterBytes.Insert(fileMap.highestLevelCleric, character.highestLevelCleric);
            characterBytes.RemoveAt(fileMap.highestLevelKnight ); characterBytes.Insert(fileMap.highestLevelKnight , character.highestLevelKnight );
            characterBytes.RemoveAt(fileMap.highestLevelFighter); characterBytes.Insert(fileMap.highestLevelFighter, character.highestLevelFighter);
            characterBytes.RemoveAt(fileMap.highestLevelPaladin); characterBytes.Insert(fileMap.highestLevelPaladin, character.highestLevelPaladin);
            characterBytes.RemoveAt(fileMap.highestLevelRanger ); characterBytes.Insert(fileMap.highestLevelRanger , character.highestLevelRanger );
            characterBytes.RemoveAt(fileMap.highestLevelMage   ); characterBytes.Insert(fileMap.highestLevelMage   , character.highestLevelMage   );
            characterBytes.RemoveAt(fileMap.highestLevelThief  ); characterBytes.Insert(fileMap.highestLevelThief  , character.highestLevelThief  );
            characterBytes.RemoveAt(fileMap.levelCleric        ); characterBytes.Insert(fileMap.levelCleric        , character.levelCleric        );
            characterBytes.RemoveAt(fileMap.levelKnight        ); characterBytes.Insert(fileMap.levelKnight        , character.levelKnight        );
            characterBytes.RemoveAt(fileMap.levelFighter       ); characterBytes.Insert(fileMap.levelFighter       , character.levelFighter       );
            characterBytes.RemoveAt(fileMap.levelPaladin       ); characterBytes.Insert(fileMap.levelPaladin       , character.levelPaladin       );
            characterBytes.RemoveAt(fileMap.levelRanger        ); characterBytes.Insert(fileMap.levelRanger        , character.levelRanger        );
            characterBytes.RemoveAt(fileMap.levelMage          ); characterBytes.Insert(fileMap.levelMage          , character.levelMage          );
            characterBytes.RemoveAt(fileMap.levelThief         ); characterBytes.Insert(fileMap.levelThief         , character.levelThief         );
            characterBytes.RemoveAt(fileMap.formerLevelCleric  ); characterBytes.Insert(fileMap.formerLevelCleric  , character.formerLevelCleric  );
            characterBytes.RemoveAt(fileMap.formerLevelKnight  ); characterBytes.Insert(fileMap.formerLevelKnight  , character.formerLevelKnight  );
            characterBytes.RemoveAt(fileMap.formerLevelFighter ); characterBytes.Insert(fileMap.formerLevelFighter , character.formerLevelFighter );
            characterBytes.RemoveAt(fileMap.formerLevelPaladin ); characterBytes.Insert(fileMap.formerLevelPaladin , character.formerLevelPaladin );
            characterBytes.RemoveAt(fileMap.formerLevelRanger  ); characterBytes.Insert(fileMap.formerLevelRanger  , character.formerLevelRanger  );
            characterBytes.RemoveAt(fileMap.formerLevelMage    ); characterBytes.Insert(fileMap.formerLevelMage    , character.formerLevelMage    );
            characterBytes.RemoveAt(fileMap.formerLevelThief   ); characterBytes.Insert(fileMap.formerLevelThief   , character.formerLevelThief   );
            characterBytes.RemoveAt(fileMap.attacks1           ); characterBytes.Insert(fileMap.attacks1           , character.attacks1           );
            characterBytes.RemoveAt(fileMap.attacks2           ); characterBytes.Insert(fileMap.attacks2           , character.attacks2           );
            characterBytes.RemoveAt(fileMap.currentAttacks1    ); characterBytes.Insert(fileMap.currentAttacks1    , character.currentAttacks1    );
            characterBytes.RemoveAt(fileMap.currentAttacks2    ); characterBytes.Insert(fileMap.currentAttacks2    , character.currentAttacks2    );
            characterBytes.RemoveAt(fileMap.currentRolls       ); characterBytes.Insert(fileMap.currentRolls       , character.currentRolls       );
            characterBytes.RemoveAt(fileMap.currentRolls2      ); characterBytes.Insert(fileMap.currentRolls2      , character.currentRolls2      );
            characterBytes.RemoveAt(fileMap.currentDice        ); characterBytes.Insert(fileMap.currentDice        , character.currentDice        );
            characterBytes.RemoveAt(fileMap.currentDice2       ); characterBytes.Insert(fileMap.currentDice2       , character.currentDice2       );
            characterBytes.RemoveAt(fileMap.currentModifier    ); characterBytes.Insert(fileMap.currentModifier    , character.currentModifier    );
            characterBytes.RemoveAt(fileMap.currentModifier2   ); characterBytes.Insert(fileMap.currentModifier2   , character.currentModifier2   );
            characterBytes.RemoveAt(fileMap.unarmedRolls       ); characterBytes.Insert(fileMap.unarmedRolls       , character.unarmedRolls       );
            characterBytes.RemoveAt(fileMap.unarmedRolls2      ); characterBytes.Insert(fileMap.unarmedRolls2      , character.unarmedRolls2      );
            characterBytes.RemoveAt(fileMap.unarmedDice        ); characterBytes.Insert(fileMap.unarmedDice        , character.unarmedDice        );
            characterBytes.RemoveAt(fileMap.unarmedDice2       ); characterBytes.Insert(fileMap.unarmedDice2       , character.unarmedDice2       );
            characterBytes.RemoveAt(fileMap.unarmedModifier    ); characterBytes.Insert(fileMap.unarmedModifier    , character.unarmedModifier    );
            characterBytes.RemoveAt(fileMap.unarmedModifier2   ); characterBytes.Insert(fileMap.unarmedModifier2   , character.unarmedModifier2   );
            characterBytes.RemoveAt(fileMap.itemLimits         ); characterBytes.Insert(fileMap.itemLimits         , character.itemLimits         );
            //characterBytes.RemoveAt(fileMap.numberOfItems      ); characterBytes.Insert(fileMap.numberOfItems      , character.numberOfItems      );
            characterBytes.RemoveAt(fileMap.flags1             ); characterBytes.Insert(fileMap.flags1             , character.flags1             );
            characterBytes.RemoveAt(fileMap.flags2             ); characterBytes.Insert(fileMap.flags2             , character.flags2             );
            characterBytes.RemoveAt(fileMap.saveBonus          ); characterBytes.Insert(fileMap.saveBonus          , character.saveBonus          );
            characterBytes.RemoveAt(fileMap.MagicResistance    ); characterBytes.Insert(fileMap.MagicResistance    , character.MagicResistance    );
            characterBytes.RemoveAt(fileMap.clericSpells1      ); characterBytes.Insert(fileMap.clericSpells1      , character.clericSpells1      );
            characterBytes.RemoveAt(fileMap.clericSpells2      ); characterBytes.Insert(fileMap.clericSpells2      , character.clericSpells2      );
            characterBytes.RemoveAt(fileMap.clericSpells3      ); characterBytes.Insert(fileMap.clericSpells3      , character.clericSpells3      );
            characterBytes.RemoveAt(fileMap.clericSpells4      ); characterBytes.Insert(fileMap.clericSpells4      , character.clericSpells4      );
            characterBytes.RemoveAt(fileMap.clericSpells5      ); characterBytes.Insert(fileMap.clericSpells5      , character.clericSpells5      );
            characterBytes.RemoveAt(fileMap.clericSpells6      ); characterBytes.Insert(fileMap.clericSpells6      , character.clericSpells6      );
            characterBytes.RemoveAt(fileMap.clericSpells7      ); characterBytes.Insert(fileMap.clericSpells7      , character.clericSpells7      );
            characterBytes.RemoveAt(fileMap.druidSpells1       ); characterBytes.Insert(fileMap.druidSpells1       , character.druidSpells1       );
            characterBytes.RemoveAt(fileMap.druidSpells2       ); characterBytes.Insert(fileMap.druidSpells2       , character.druidSpells2       );
            characterBytes.RemoveAt(fileMap.druidSpells3       ); characterBytes.Insert(fileMap.druidSpells3       , character.druidSpells3       );
            characterBytes.RemoveAt(fileMap.mageSpells1        ); characterBytes.Insert(fileMap.mageSpells1        , character.mageSpells1        );
            characterBytes.RemoveAt(fileMap.mageSpells2        ); characterBytes.Insert(fileMap.mageSpells2        , character.mageSpells2        );
            characterBytes.RemoveAt(fileMap.mageSpells3        ); characterBytes.Insert(fileMap.mageSpells3        , character.mageSpells3        );
            characterBytes.RemoveAt(fileMap.mageSpells4        ); characterBytes.Insert(fileMap.mageSpells4        , character.mageSpells4        );
            characterBytes.RemoveAt(fileMap.mageSpells5        ); characterBytes.Insert(fileMap.mageSpells5        , character.mageSpells5        );
            characterBytes.RemoveAt(fileMap.mageSpells6        ); characterBytes.Insert(fileMap.mageSpells6        , character.mageSpells6        );
            characterBytes.RemoveAt(fileMap.mageSpells7        ); characterBytes.Insert(fileMap.mageSpells7        , character.mageSpells7        );
            characterBytes.RemoveAt(fileMap.mageSpells8        ); characterBytes.Insert(fileMap.mageSpells8        , character.mageSpells8        );
            characterBytes.RemoveAt(fileMap.mageSpells9        ); characterBytes.Insert(fileMap.mageSpells9        , character.mageSpells9        );
            characterBytes.RemoveAt(fileMap.levelUndead        ); characterBytes.Insert(fileMap.levelUndead        , character.levelUndead        );
            characterBytes.RemoveAt(fileMap.ableToTrain        ); characterBytes.Insert(fileMap.ableToTrain        , character.ableToTrain        );
            characterBytes.RemoveAt(fileMap.icon               ); characterBytes.Insert(fileMap.icon               , character.icon               );
            characterBytes.RemoveAt(fileMap.acBase); characterBytes.Insert(fileMap.acBase, character.acBase);
            characterBytes.RemoveAt(fileMap.acCurrent); characterBytes.Insert(fileMap.acCurrent, character.acCurrent);

            characterBytes.RemoveAt(fileMap.iconColor1Body  ); characterBytes.Insert(fileMap.iconColor1Body, character.iconColor1Body);
            characterBytes.RemoveAt(fileMap.iconColor2Body  ); characterBytes.Insert(fileMap.iconColor2Body  , character.iconColor2Body  );
            characterBytes.RemoveAt(fileMap.iconColor1Arm   ); characterBytes.Insert(fileMap.iconColor1Arm   , character.iconColor1Arm   );
            characterBytes.RemoveAt(fileMap.iconColor2Arm   ); characterBytes.Insert(fileMap.iconColor2Arm   , character.iconColor2Arm   );
            characterBytes.RemoveAt(fileMap.iconColor1Leg   ); characterBytes.Insert(fileMap.iconColor1Leg   , character.iconColor1Leg   );
            characterBytes.RemoveAt(fileMap.iconColor2Leg   ); characterBytes.Insert(fileMap.iconColor2Leg   , character.iconColor2Leg   );
            characterBytes.RemoveAt(fileMap.iconColor1Hair  ); characterBytes.Insert(fileMap.iconColor1Hair  , character.iconColor1Hair  );
            characterBytes.RemoveAt(fileMap.iconColor2Face  ); characterBytes.Insert(fileMap.iconColor2Face  , character.iconColor2Face  );
            characterBytes.RemoveAt(fileMap.iconColor1Shield); characterBytes.Insert(fileMap.iconColor1Shield, character.iconColor1Shield);
            characterBytes.RemoveAt(fileMap.iconColor2Shield); characterBytes.Insert(fileMap.iconColor2Shield, character.iconColor2Shield);
            characterBytes.RemoveAt(fileMap.iconColor1Weapon); characterBytes.Insert(fileMap.iconColor1Weapon, character.iconColor1Weapon);
            characterBytes.RemoveAt(fileMap.iconColor2Weapon); characterBytes.Insert(fileMap.iconColor2Weapon, character.iconColor2Weapon);
            characterBytes.RemoveAt(fileMap.handsEquipped   ); characterBytes.Insert(fileMap.handsEquipped   , character.handsEquipped   );
            characterBytes.RemoveAt(fileMap.enabled         ); characterBytes.Insert(fileMap.enabled         , character.enabled         );
            characterBytes.RemoveAt(fileMap.hostile         ); characterBytes.Insert(fileMap.hostile         , character.hostile         );
            characterBytes.RemoveAt(fileMap.quickfight      ); characterBytes.Insert(fileMap.quickfight      , character.quickfight      );

            //DOS Bytes 414-431 = first item. Item = 18 bytes? Amiga bytes 416-433 = first item. Items size 18 bytes
            //423-431  Effect = 10 bytes? Amiga DQK effect = 10 bytes. DOS DQK effect = 9 bytes

            characterBytes.RemoveRange(fileMap.nextCharacterAddress, HexStringToByteArray(character.nextCharacterAddress).Length);
            characterBytes.InsertRange(fileMap.nextCharacterAddress, HexStringToByteArray(character.nextCharacterAddress));

            return characterBytes.Take(414).ToArray();
        }

        //public static List<Byte> Replace(List<Byte> bytes, GoldBoxCharacter character, GoldBoxSaveMap map, string name)
        //{
        //    PropertyInfo propertyInfo = typeof(GoldBoxCharacter).GetProperties().Where(p => p.Name == name).First();
        //    var value = propertyInfo.GetValue(character);

        //    bytes.RemoveAt()
        //    return bytes;
        //}

        public static string ByteArrayToString(byte[] ba)
        {
            return BitConverter.ToString(ba).Replace("-", "");
        }

        public static byte[] HexStringToByteArray(String hex)
        {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }

        public static byte[] StringToByteArray(String text)
        {
            // Create two different encodings.  
            Encoding ascii = Encoding.ASCII;
            Encoding unicode = Encoding.Unicode;
            // Convert unicode string into a byte array.  
            byte[] bytesInUni = unicode.GetBytes(text);
            // Convert unicode to ascii  
            byte[] bytesInAscii = Encoding.Convert(unicode, ascii, bytesInUni);
            // Convert byte[] into a char[]  
            char[] charsAscii = new char[ascii.GetCharCount(bytesInAscii, 0, bytesInAscii.Length)];
            ascii.GetChars(bytesInAscii, 0, bytesInAscii.Length, charsAscii, 0);

            return bytesInAscii;
        }
    }
}


namespace GoldBoxEditor
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.HexTextBox = new System.Windows.Forms.RichTextBox();
            this.ValuesTextBox = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FileLabel = new System.Windows.Forms.Label();
            this.AsciiTextBox = new System.Windows.Forms.RichTextBox();
            this.SearchButton = new System.Windows.Forms.Button();
            this.SearchText = new System.Windows.Forms.TextBox();
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.Filelabel3 = new System.Windows.Forms.Label();
            this.Values2TextBox = new System.Windows.Forms.RichTextBox();
            this.comboBoxGame = new System.Windows.Forms.ComboBox();
            this.AddTextBox = new System.Windows.Forms.TextBox();
            this.AddButton = new System.Windows.Forms.Button();
            this.DataTypeComboBox = new System.Windows.Forms.ComboBox();
            this.ComboBoxSystem = new System.Windows.Forms.ComboBox();
            this.ItemComboBox = new System.Windows.Forms.ComboBox();
            this.ItemCodeComboBox = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.EffectComboBox = new System.Windows.Forms.ComboBox();
            this.EffectCodeComboBox = new System.Windows.Forms.ComboBox();
            this.AddEffectCodeButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.deleteItembutton = new System.Windows.Forms.Button();
            this.deleteEffectbutton = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // HexTextBox
            // 
            this.HexTextBox.Location = new System.Drawing.Point(15, 77);
            this.HexTextBox.Name = "HexTextBox";
            this.HexTextBox.Size = new System.Drawing.Size(313, 201);
            this.HexTextBox.TabIndex = 0;
            this.HexTextBox.Text = "";
            // 
            // ValuesTextBox
            // 
            this.ValuesTextBox.Location = new System.Drawing.Point(334, 77);
            this.ValuesTextBox.Name = "ValuesTextBox";
            this.ValuesTextBox.Size = new System.Drawing.Size(257, 408);
            this.ValuesTextBox.TabIndex = 1;
            this.ValuesTextBox.Text = "";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1197, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.compareToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // compareToolStripMenuItem
            // 
            this.compareToolStripMenuItem.Name = "compareToolStripMenuItem";
            this.compareToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.compareToolStripMenuItem.Text = "Compare";
            this.compareToolStripMenuItem.Click += new System.EventHandler(this.compareToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // FileLabel
            // 
            this.FileLabel.AutoSize = true;
            this.FileLabel.Location = new System.Drawing.Point(12, 61);
            this.FileLabel.Name = "FileLabel";
            this.FileLabel.Size = new System.Drawing.Size(23, 13);
            this.FileLabel.TabIndex = 3;
            this.FileLabel.Text = "File";
            this.FileLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // AsciiTextBox
            // 
            this.AsciiTextBox.Location = new System.Drawing.Point(15, 284);
            this.AsciiTextBox.Name = "AsciiTextBox";
            this.AsciiTextBox.Size = new System.Drawing.Size(313, 201);
            this.AsciiTextBox.TabIndex = 4;
            this.AsciiTextBox.Text = "";
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(532, 24);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(75, 23);
            this.SearchButton.TabIndex = 5;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // SearchText
            // 
            this.SearchText.Location = new System.Drawing.Point(357, 26);
            this.SearchText.Name = "SearchText";
            this.SearchText.Size = new System.Drawing.Size(169, 20);
            this.SearchText.TabIndex = 6;
            // 
            // comboBox
            // 
            this.comboBox.FormattingEnabled = true;
            this.comboBox.Location = new System.Drawing.Point(230, 24);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(121, 21);
            this.comboBox.TabIndex = 7;
            this.comboBox.Text = "valuetype";
            // 
            // Filelabel3
            // 
            this.Filelabel3.AutoSize = true;
            this.Filelabel3.Location = new System.Drawing.Point(433, 61);
            this.Filelabel3.Name = "Filelabel3";
            this.Filelabel3.Size = new System.Drawing.Size(23, 13);
            this.Filelabel3.TabIndex = 9;
            this.Filelabel3.Text = "File";
            // 
            // Values2TextBox
            // 
            this.Values2TextBox.Location = new System.Drawing.Point(597, 77);
            this.Values2TextBox.Name = "Values2TextBox";
            this.Values2TextBox.Size = new System.Drawing.Size(257, 408);
            this.Values2TextBox.TabIndex = 10;
            this.Values2TextBox.Text = "";
            // 
            // comboBoxGame
            // 
            this.comboBoxGame.FormattingEnabled = true;
            this.comboBoxGame.Location = new System.Drawing.Point(688, 27);
            this.comboBoxGame.Name = "comboBoxGame";
            this.comboBoxGame.Size = new System.Drawing.Size(166, 21);
            this.comboBoxGame.TabIndex = 11;
            this.comboBoxGame.Text = "game";
            // 
            // AddTextBox
            // 
            this.AddTextBox.Location = new System.Drawing.Point(860, 58);
            this.AddTextBox.Name = "AddTextBox";
            this.AddTextBox.Size = new System.Drawing.Size(233, 20);
            this.AddTextBox.TabIndex = 12;
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(1099, 55);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(86, 23);
            this.AddButton.TabIndex = 13;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // DataTypeComboBox
            // 
            this.DataTypeComboBox.FormattingEnabled = true;
            this.DataTypeComboBox.Location = new System.Drawing.Point(860, 26);
            this.DataTypeComboBox.Name = "DataTypeComboBox";
            this.DataTypeComboBox.Size = new System.Drawing.Size(121, 21);
            this.DataTypeComboBox.TabIndex = 14;
            this.DataTypeComboBox.Text = "datatype";
            // 
            // ComboBoxSystem
            // 
            this.ComboBoxSystem.FormattingEnabled = true;
            this.ComboBoxSystem.Location = new System.Drawing.Point(613, 27);
            this.ComboBoxSystem.Name = "ComboBoxSystem";
            this.ComboBoxSystem.Size = new System.Drawing.Size(66, 21);
            this.ComboBoxSystem.TabIndex = 15;
            this.ComboBoxSystem.Text = "System";
            // 
            // ItemComboBox
            // 
            this.ItemComboBox.FormattingEnabled = true;
            this.ItemComboBox.Location = new System.Drawing.Point(860, 139);
            this.ItemComboBox.Name = "ItemComboBox";
            this.ItemComboBox.Size = new System.Drawing.Size(233, 21);
            this.ItemComboBox.TabIndex = 16;
            this.ItemComboBox.Text = "Item";
            this.ItemComboBox.SelectedIndexChanged += new System.EventHandler(this.ItemComboBox_SelectedIndexChanged);
            // 
            // ItemCodeComboBox
            // 
            this.ItemCodeComboBox.FormattingEnabled = true;
            this.ItemCodeComboBox.Location = new System.Drawing.Point(860, 166);
            this.ItemCodeComboBox.Name = "ItemCodeComboBox";
            this.ItemCodeComboBox.Size = new System.Drawing.Size(233, 21);
            this.ItemCodeComboBox.TabIndex = 17;
            this.ItemCodeComboBox.Text = "ItemCode";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1099, 139);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 37);
            this.button1.TabIndex = 18;
            this.button1.Text = "Add code to item";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // EffectComboBox
            // 
            this.EffectComboBox.FormattingEnabled = true;
            this.EffectComboBox.Location = new System.Drawing.Point(860, 230);
            this.EffectComboBox.Name = "EffectComboBox";
            this.EffectComboBox.Size = new System.Drawing.Size(233, 21);
            this.EffectComboBox.TabIndex = 19;
            this.EffectComboBox.Text = "Effect";
            // 
            // EffectCodeComboBox
            // 
            this.EffectCodeComboBox.FormattingEnabled = true;
            this.EffectCodeComboBox.Location = new System.Drawing.Point(860, 257);
            this.EffectCodeComboBox.Name = "EffectCodeComboBox";
            this.EffectCodeComboBox.Size = new System.Drawing.Size(233, 21);
            this.EffectCodeComboBox.TabIndex = 20;
            this.EffectCodeComboBox.Text = "EffectCode";
            // 
            // AddEffectCodeButton
            // 
            this.AddEffectCodeButton.Location = new System.Drawing.Point(1099, 230);
            this.AddEffectCodeButton.Name = "AddEffectCodeButton";
            this.AddEffectCodeButton.Size = new System.Drawing.Size(86, 37);
            this.AddEffectCodeButton.TabIndex = 21;
            this.AddEffectCodeButton.Text = "Add code to effect";
            this.AddEffectCodeButton.UseVisualStyleBackColor = true;
            this.AddEffectCodeButton.Click += new System.EventHandler(this.AddEffectCodeButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(1110, 456);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 22;
            this.SaveButton.Text = "Save data";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1029, 456);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 23;
            this.button3.Text = "Reload data";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // deleteItembutton
            // 
            this.deleteItembutton.Location = new System.Drawing.Point(1099, 182);
            this.deleteItembutton.Name = "deleteItembutton";
            this.deleteItembutton.Size = new System.Drawing.Size(86, 23);
            this.deleteItembutton.TabIndex = 24;
            this.deleteItembutton.Text = "Delete Item";
            this.deleteItembutton.UseVisualStyleBackColor = true;
            this.deleteItembutton.Click += new System.EventHandler(this.deleteItembutton_Click);
            // 
            // deleteEffectbutton
            // 
            this.deleteEffectbutton.Location = new System.Drawing.Point(1099, 273);
            this.deleteEffectbutton.Name = "deleteEffectbutton";
            this.deleteEffectbutton.Size = new System.Drawing.Size(86, 23);
            this.deleteEffectbutton.TabIndex = 25;
            this.deleteEffectbutton.Text = "Delete Effect";
            this.deleteEffectbutton.UseVisualStyleBackColor = true;
            this.deleteEffectbutton.Click += new System.EventHandler(this.deleteEffectbutton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1197, 491);
            this.Controls.Add(this.deleteEffectbutton);
            this.Controls.Add(this.deleteItembutton);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.AddEffectCodeButton);
            this.Controls.Add(this.EffectCodeComboBox);
            this.Controls.Add(this.EffectComboBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ItemCodeComboBox);
            this.Controls.Add(this.ItemComboBox);
            this.Controls.Add(this.ComboBoxSystem);
            this.Controls.Add(this.DataTypeComboBox);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.AddTextBox);
            this.Controls.Add(this.comboBoxGame);
            this.Controls.Add(this.Values2TextBox);
            this.Controls.Add(this.Filelabel3);
            this.Controls.Add(this.comboBox);
            this.Controls.Add(this.SearchText);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.AsciiTextBox);
            this.Controls.Add(this.FileLabel);
            this.Controls.Add(this.ValuesTextBox);
            this.Controls.Add(this.HexTextBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Gold Box Editor";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox HexTextBox;
        private System.Windows.Forms.RichTextBox ValuesTextBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Label FileLabel;
        private System.Windows.Forms.RichTextBox AsciiTextBox;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.TextBox SearchText;
        private System.Windows.Forms.ComboBox comboBox;
        private System.Windows.Forms.ToolStripMenuItem compareToolStripMenuItem;
        private System.Windows.Forms.Label Filelabel3;
        private System.Windows.Forms.RichTextBox Values2TextBox;
        private System.Windows.Forms.ComboBox comboBoxGame;
        private System.Windows.Forms.TextBox AddTextBox;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.ComboBox DataTypeComboBox;
        private System.Windows.Forms.ComboBox ComboBoxSystem;
        private System.Windows.Forms.ComboBox ItemComboBox;
        private System.Windows.Forms.ComboBox ItemCodeComboBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox EffectComboBox;
        private System.Windows.Forms.ComboBox EffectCodeComboBox;
        private System.Windows.Forms.Button AddEffectCodeButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button deleteItembutton;
        private System.Windows.Forms.Button deleteEffectbutton;
    }
}


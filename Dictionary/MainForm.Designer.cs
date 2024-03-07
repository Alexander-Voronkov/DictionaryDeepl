using System.Linq;
namespace Dictionary
{
    partial class DictionaryApp
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.TranslationLanguageComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.OriginalWordTextBox = new System.Windows.Forms.TextBox();
            this.TranslateBtn = new System.Windows.Forms.Button();
            this.InputWordClearBtn = new System.Windows.Forms.Button();
            this.TranslationTextBox = new System.Windows.Forms.TextBox();
            this.ClearBtn = new System.Windows.Forms.Button();
            this.OriginalWords = new System.Windows.Forms.ListBox();
            this.DeleteOriginalWordBtn = new System.Windows.Forms.Button();
            this.WordTranslations = new System.Windows.Forms.ListBox();
            this.DeleteTranslationBtn = new System.Windows.Forms.Button();
            this.LoadFromFileBtn = new System.Windows.Forms.Button();
            this.SaveToFileBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TranslationLanguageComboBox
            // 
            this.TranslationLanguageComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TranslationLanguageComboBox.FormattingEnabled = true;
            this.TranslationLanguageComboBox.Location = new System.Drawing.Point(973, 18);
            this.TranslationLanguageComboBox.Name = "TranslationLanguageComboBox";
            this.TranslationLanguageComboBox.Size = new System.Drawing.Size(202, 24);
            this.TranslationLanguageComboBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(935, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "To :";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(64, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Your word :";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(64, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "Translation : ";
            // 
            // OriginalWordTextBox
            // 
            this.OriginalWordTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.OriginalWordTextBox.Location = new System.Drawing.Point(150, 14);
            this.OriginalWordTextBox.Name = "OriginalWordTextBox";
            this.OriginalWordTextBox.Size = new System.Drawing.Size(133, 22);
            this.OriginalWordTextBox.TabIndex = 8;
            // 
            // TranslateBtn
            // 
            this.TranslateBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.TranslateBtn.Location = new System.Drawing.Point(67, 91);
            this.TranslateBtn.Name = "TranslateBtn";
            this.TranslateBtn.Size = new System.Drawing.Size(75, 24);
            this.TranslateBtn.TabIndex = 10;
            this.TranslateBtn.Text = "Translate";
            this.TranslateBtn.UseVisualStyleBackColor = true;
            this.TranslateBtn.Click += new System.EventHandler(this.TranslateBtn_Click);
            // 
            // InputWordClearBtn
            // 
            this.InputWordClearBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.InputWordClearBtn.Location = new System.Drawing.Point(208, 91);
            this.InputWordClearBtn.Name = "InputWordClearBtn";
            this.InputWordClearBtn.Size = new System.Drawing.Size(75, 24);
            this.InputWordClearBtn.TabIndex = 11;
            this.InputWordClearBtn.Text = "Clear";
            this.InputWordClearBtn.UseVisualStyleBackColor = true;
            this.InputWordClearBtn.Click += new System.EventHandler(this.InputWordClearBtn_Click);
            // 
            // TranslationTextBox
            // 
            this.TranslationTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.TranslationTextBox.Location = new System.Drawing.Point(150, 45);
            this.TranslationTextBox.Name = "TranslationTextBox";
            this.TranslationTextBox.ReadOnly = true;
            this.TranslationTextBox.Size = new System.Drawing.Size(133, 22);
            this.TranslationTextBox.TabIndex = 12;
            // 
            // ClearBtn
            // 
            this.ClearBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ClearBtn.Location = new System.Drawing.Point(1033, 48);
            this.ClearBtn.Name = "ClearBtn";
            this.ClearBtn.Size = new System.Drawing.Size(75, 24);
            this.ClearBtn.TabIndex = 14;
            this.ClearBtn.Text = "Clear";
            this.ClearBtn.UseVisualStyleBackColor = true;
            this.ClearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
            // 
            // OriginalWords
            // 
            this.OriginalWords.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.OriginalWords.FormattingEnabled = true;
            this.OriginalWords.ItemHeight = 16;
            this.OriginalWords.Location = new System.Drawing.Point(449, 156);
            this.OriginalWords.Name = "OriginalWords";
            this.OriginalWords.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.OriginalWords.Size = new System.Drawing.Size(146, 212);
            this.OriginalWords.TabIndex = 15;
            this.OriginalWords.SelectedIndexChanged += new System.EventHandler(this.OriginalWords_SelectedIndexChanged);
            // 
            // DeleteOriginalWordBtn
            // 
            this.DeleteOriginalWordBtn.Location = new System.Drawing.Point(449, 378);
            this.DeleteOriginalWordBtn.Name = "DeleteOriginalWordBtn";
            this.DeleteOriginalWordBtn.Size = new System.Drawing.Size(146, 23);
            this.DeleteOriginalWordBtn.TabIndex = 18;
            this.DeleteOriginalWordBtn.Text = "Delete chosen";
            this.DeleteOriginalWordBtn.UseVisualStyleBackColor = true;
            this.DeleteOriginalWordBtn.Click += new System.EventHandler(this.DeleteOriginalWordBtn_Click);
            // 
            // WordTranslations
            // 
            this.WordTranslations.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.WordTranslations.FormattingEnabled = true;
            this.WordTranslations.ItemHeight = 16;
            this.WordTranslations.Location = new System.Drawing.Point(652, 156);
            this.WordTranslations.Name = "WordTranslations";
            this.WordTranslations.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.WordTranslations.Size = new System.Drawing.Size(143, 212);
            this.WordTranslations.TabIndex = 19;
            // 
            // DeleteTranslationBtn
            // 
            this.DeleteTranslationBtn.Location = new System.Drawing.Point(652, 378);
            this.DeleteTranslationBtn.Name = "DeleteTranslationBtn";
            this.DeleteTranslationBtn.Size = new System.Drawing.Size(143, 23);
            this.DeleteTranslationBtn.TabIndex = 20;
            this.DeleteTranslationBtn.Text = "Delete chosen";
            this.DeleteTranslationBtn.UseVisualStyleBackColor = true;
            this.DeleteTranslationBtn.Click += new System.EventHandler(this.DeleteTranslationBtn_Click);
            // 
            // LoadFromFileBtn
            // 
            this.LoadFromFileBtn.Location = new System.Drawing.Point(1063, 395);
            this.LoadFromFileBtn.Name = "LoadFromFileBtn";
            this.LoadFromFileBtn.Size = new System.Drawing.Size(112, 23);
            this.LoadFromFileBtn.TabIndex = 22;
            this.LoadFromFileBtn.Text = "Load from file";
            this.LoadFromFileBtn.UseVisualStyleBackColor = true;
            this.LoadFromFileBtn.Click += new System.EventHandler(this.LoadFromFileBtn_Click);
            // 
            // SaveToFileBtn
            // 
            this.SaveToFileBtn.Location = new System.Drawing.Point(1063, 424);
            this.SaveToFileBtn.Name = "SaveToFileBtn";
            this.SaveToFileBtn.Size = new System.Drawing.Size(112, 23);
            this.SaveToFileBtn.TabIndex = 23;
            this.SaveToFileBtn.Text = "Save to file";
            this.SaveToFileBtn.UseVisualStyleBackColor = true;
            this.SaveToFileBtn.Click += new System.EventHandler(this.SaveToFileBtn_Click);
            // 
            // DictionaryApp
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1187, 459);
            this.Controls.Add(this.SaveToFileBtn);
            this.Controls.Add(this.LoadFromFileBtn);
            this.Controls.Add(this.DeleteTranslationBtn);
            this.Controls.Add(this.WordTranslations);
            this.Controls.Add(this.DeleteOriginalWordBtn);
            this.Controls.Add(this.OriginalWords);
            this.Controls.Add(this.ClearBtn);
            this.Controls.Add(this.TranslationTextBox);
            this.Controls.Add(this.InputWordClearBtn);
            this.Controls.Add(this.TranslateBtn);
            this.Controls.Add(this.OriginalWordTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TranslationLanguageComboBox);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Name = "DictionaryApp";
            this.Text = "Dictionary";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox TranslationLanguageComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox OriginalWordTextBox;
        private System.Windows.Forms.Button TranslateBtn;
        private System.Windows.Forms.Button InputWordClearBtn;
        private System.Windows.Forms.TextBox TranslationTextBox;
        private System.Windows.Forms.Button ClearBtn;
        private System.Windows.Forms.ListBox OriginalWords;
        private System.Windows.Forms.Button DeleteOriginalWordBtn;
        private System.Windows.Forms.ListBox WordTranslations;
        private System.Windows.Forms.Button DeleteTranslationBtn;
        private System.Windows.Forms.Button LoadFromFileBtn;
        private System.Windows.Forms.Button SaveToFileBtn;
    }
}


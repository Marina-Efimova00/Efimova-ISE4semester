﻿namespace AbstractMebelView
{
    partial class FormFillStorage
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
            this.comboBoxStorage = new System.Windows.Forms.ComboBox();
            this.comboBoxZagotovka = new System.Windows.Forms.ComboBox();
            this.textBoxCount = new System.Windows.Forms.TextBox();
            this.labelStorage = new System.Windows.Forms.Label();
            this.labelZagotovka = new System.Windows.Forms.Label();
            this.labelCount = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxStorage
            // 
            this.comboBoxStorage.FormattingEnabled = true;
            this.comboBoxStorage.Location = new System.Drawing.Point(137, 33);
            this.comboBoxStorage.Name = "comboBoxStorage";
            this.comboBoxStorage.Size = new System.Drawing.Size(352, 21);
            this.comboBoxStorage.TabIndex = 0;
            // 
            // comboBoxZagotovka
            // 
            this.comboBoxZagotovka.FormattingEnabled = true;
            this.comboBoxZagotovka.Location = new System.Drawing.Point(136, 80);
            this.comboBoxZagotovka.Name = "comboBoxZagotovka";
            this.comboBoxZagotovka.Size = new System.Drawing.Size(352, 21);
            this.comboBoxZagotovka.TabIndex = 1;
            // 
            // textBoxCount
            // 
            this.textBoxCount.Location = new System.Drawing.Point(136, 125);
            this.textBoxCount.Name = "textBoxCount";
            this.textBoxCount.Size = new System.Drawing.Size(353, 20);
            this.textBoxCount.TabIndex = 2;
            // 
            // labelStorage
            // 
            this.labelStorage.AutoSize = true;
            this.labelStorage.Location = new System.Drawing.Point(33, 36);
            this.labelStorage.Name = "labelStorage";
            this.labelStorage.Size = new System.Drawing.Size(38, 13);
            this.labelStorage.TabIndex = 3;
            this.labelStorage.Text = "Склад";
            // 
            // labelZagotovka
            // 
            this.labelZagotovka.AutoSize = true;
            this.labelZagotovka.Location = new System.Drawing.Point(33, 80);
            this.labelZagotovka.Name = "labelZagotovka";
            this.labelZagotovka.Size = new System.Drawing.Size(60, 13);
            this.labelZagotovka.TabIndex = 4;
            this.labelZagotovka.Text = "Заготовка";
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Location = new System.Drawing.Point(33, 125);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(66, 13);
            this.labelCount.TabIndex = 5;
            this.labelCount.Text = "Количество";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(249, 169);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(104, 21);
            this.buttonSave.TabIndex = 6;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(390, 167);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(97, 22);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // FormFillStorage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 212);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.labelZagotovka);
            this.Controls.Add(this.labelStorage);
            this.Controls.Add(this.textBoxCount);
            this.Controls.Add(this.comboBoxZagotovka);
            this.Controls.Add(this.comboBoxStorage);
            this.Name = "FormFillStorage";
            this.Text = "Пополнение склада";
            this.Load += new System.EventHandler(this.FormFillStorage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxStorage;
        private System.Windows.Forms.ComboBox comboBoxZagotovka;
        private System.Windows.Forms.TextBox textBoxCount;
        private System.Windows.Forms.Label labelStorage;
        private System.Windows.Forms.Label labelZagotovka;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
    }
}
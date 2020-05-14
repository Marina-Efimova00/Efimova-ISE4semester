namespace AbstractMebelStorageView
{
    partial class FormMain
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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.менюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.создатьСкладToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изменитьСкладToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.пополнитьСкладToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьСкладToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.обновитьСписокToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 26);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(776, 412);
            this.dataGridView.TabIndex = 1;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.менюToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(800, 24);
            this.menuStrip.TabIndex = 2;
            this.menuStrip.Text = "menuStrip";
            // 
            // менюToolStripMenuItem
            // 
            this.менюToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.создатьСкладToolStripMenuItem,
            this.изменитьСкладToolStripMenuItem,
            this.пополнитьСкладToolStripMenuItem,
            this.удалитьСкладToolStripMenuItem,
            this.обновитьСписокToolStripMenuItem});
            this.менюToolStripMenuItem.Name = "менюToolStripMenuItem";
            this.менюToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.менюToolStripMenuItem.Text = "Меню";
            // 
            // создатьСкладToolStripMenuItem
            // 
            this.создатьСкладToolStripMenuItem.Name = "создатьСкладToolStripMenuItem";
            this.создатьСкладToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.создатьСкладToolStripMenuItem.Text = "Создать склад";
            this.создатьСкладToolStripMenuItem.Click += new System.EventHandler(this.создатьСкладToolStripMenuItem_Click);
            // 
            // изменитьСкладToolStripMenuItem
            // 
            this.изменитьСкладToolStripMenuItem.Name = "изменитьСкладToolStripMenuItem";
            this.изменитьСкладToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.изменитьСкладToolStripMenuItem.Text = "Изменить склад";
            this.изменитьСкладToolStripMenuItem.Click += new System.EventHandler(this.изменитьСкладToolStripMenuItem_Click);
            // 
            // пополнитьСкладToolStripMenuItem
            // 
            this.пополнитьСкладToolStripMenuItem.Name = "пополнитьСкладToolStripMenuItem";
            this.пополнитьСкладToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.пополнитьСкладToolStripMenuItem.Text = "Пополнить склад";
            this.пополнитьСкладToolStripMenuItem.Click += new System.EventHandler(this.пополнитьСкладToolStripMenuItem_Click);
            // 
            // удалитьСкладToolStripMenuItem
            // 
            this.удалитьСкладToolStripMenuItem.Name = "удалитьСкладToolStripMenuItem";
            this.удалитьСкладToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.удалитьСкладToolStripMenuItem.Text = "Удалить склад";
            this.удалитьСкладToolStripMenuItem.Click += new System.EventHandler(this.удалитьСкладToolStripMenuItem_Click);
            // 
            // обновитьСписокToolStripMenuItem
            // 
            this.обновитьСписокToolStripMenuItem.Name = "обновитьСписокToolStripMenuItem";
            this.обновитьСписокToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.обновитьСписокToolStripMenuItem.Text = "Обновить список";
            this.обновитьСписокToolStripMenuItem.Click += new System.EventHandler(this.обновитьСписокToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FormMain";
            this.Text = "Склады";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem менюToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem создатьСкладToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem изменитьСкладToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem пополнитьСкладToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьСкладToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem обновитьСписокToolStripMenuItem;
    }
}
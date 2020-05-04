namespace AbstractMebelView
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
            this.справочникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.заготовкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.мебельToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.складToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.пополнитьСкладыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокМебелиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.заготовкиМебелиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокЗаказовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonCreateOrder = new System.Windows.Forms.Button();
            this.buttonTakeOrderInWork = new System.Windows.Forms.Button();
            this.buttonOrderReady = new System.Windows.Forms.Button();
            this.buttonPayOrder = new System.Windows.Forms.Button();
            this.buttonRef = new System.Windows.Forms.Button();
            this.списокЗаготовокToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.заготовкиПоСкладамToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокСкладовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.клиентыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(11, 39);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(1047, 338);
            this.dataGridView.TabIndex = 0;
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справочникиToolStripMenuItem,
            this.пополнитьСкладыToolStripMenuItem,
            this.отчетыToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1279, 28);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // справочникиToolStripMenuItem
            // 
            this.справочникиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.заготовкаToolStripMenuItem,
            this.мебельToolStripMenuItem,
            this.клиентыToolStripMenuItem});
            this.мебельToolStripMenuItem,
            this.складToolStripMenuItem});
            this.справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
            this.справочникиToolStripMenuItem.Size = new System.Drawing.Size(117, 24);
            this.справочникиToolStripMenuItem.Text = "Справочники";
            // 
            // заготовкаToolStripMenuItem
            // 
            this.заготовкаToolStripMenuItem.Name = "заготовкаToolStripMenuItem";
            this.заготовкаToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.заготовкаToolStripMenuItem.Text = "Заготовка";
            this.заготовкаToolStripMenuItem.Click += new System.EventHandler(this.заготовкиToolStripMenuItem_Click);
            // 
            // мебельToolStripMenuItem
            // 
            this.мебельToolStripMenuItem.Name = "мебельToolStripMenuItem";
            this.мебельToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.мебельToolStripMenuItem.Text = "Мебель";
            this.мебельToolStripMenuItem.Click += new System.EventHandler(this.мебельToolStripMenuItem_Click);
            // 
            // складToolStripMenuItem
            // 
            this.складToolStripMenuItem.Name = "складToolStripMenuItem";
            this.складToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.складToolStripMenuItem.Text = "Склад";
            this.складToolStripMenuItem.Click += new System.EventHandler(this.складToolStripMenuItem_Click);
            // 
            // пополнитьСкладыToolStripMenuItem
            // 
            this.пополнитьСкладыToolStripMenuItem.Name = "пополнитьСкладыToolStripMenuItem";
            this.пополнитьСкладыToolStripMenuItem.Size = new System.Drawing.Size(143, 24);
            this.пополнитьСкладыToolStripMenuItem.Text = "Пополнить склад";
            this.пополнитьСкладыToolStripMenuItem.Click += new System.EventHandler(this.пополнитьСкладToolStripMenuItem_Click);
            // 
            // отчетыToolStripMenuItem
            // 
            this.отчетыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.списокМебелиToolStripMenuItem,
            this.заготовкиМебелиToolStripMenuItem,
            this.списокЗаказовToolStripMenuItem,
            this.списокЗаготовокToolStripMenuItem,
            this.заготовкиПоСкладамToolStripMenuItem,
            this.списокСкладовToolStripMenuItem});
            this.отчетыToolStripMenuItem.Name = "отчетыToolStripMenuItem";
            this.отчетыToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.отчетыToolStripMenuItem.Text = "Отчеты";
            // 
            // списокМебелиToolStripMenuItem
            // 
            this.списокМебелиToolStripMenuItem.Name = "списокМебелиToolStripMenuItem";
            this.списокМебелиToolStripMenuItem.Size = new System.Drawing.Size(219, 26);
            this.списокМебелиToolStripMenuItem.Text = "Список мебели";
            this.списокМебелиToolStripMenuItem.Click += new System.EventHandler(this.списокМебелиToolStripMenuItem_Click);
            // 
            // заготовкиМебелиToolStripMenuItem
            // 
            this.заготовкиМебелиToolStripMenuItem.Name = "заготовкиМебелиToolStripMenuItem";
            this.заготовкиМебелиToolStripMenuItem.Size = new System.Drawing.Size(219, 26);
            this.заготовкиМебелиToolStripMenuItem.Text = "Заготовки мебели";
            this.заготовкиМебелиToolStripMenuItem.Click += new System.EventHandler(this.заготовкиМебелиToolStripMenuItem_Click);
            // 
            // списокЗаказовToolStripMenuItem
            // 
            this.списокЗаказовToolStripMenuItem.Name = "списокЗаказовToolStripMenuItem";
            this.списокЗаказовToolStripMenuItem.Size = new System.Drawing.Size(219, 26);
            this.списокЗаказовToolStripMenuItem.Text = "Список заказов";
            this.списокЗаказовToolStripMenuItem.Click += new System.EventHandler(this.списокЗаказовToolStripMenuItem_Click);
            // 
            // buttonCreateOrder
            // 
            this.buttonCreateOrder.Location = new System.Drawing.Point(1066, 49);
            this.buttonCreateOrder.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCreateOrder.Name = "buttonCreateOrder";
            this.buttonCreateOrder.Size = new System.Drawing.Size(200, 31);
            this.buttonCreateOrder.TabIndex = 2;
            this.buttonCreateOrder.Text = "Создать заказ";
            this.buttonCreateOrder.UseVisualStyleBackColor = true;
            this.buttonCreateOrder.Click += new System.EventHandler(this.buttonCreateOrder_Click);
            // 
            // buttonTakeOrderInWork
            // 
            this.buttonTakeOrderInWork.Location = new System.Drawing.Point(1066, 115);
            this.buttonTakeOrderInWork.Margin = new System.Windows.Forms.Padding(4);
            this.buttonTakeOrderInWork.Name = "buttonTakeOrderInWork";
            this.buttonTakeOrderInWork.Size = new System.Drawing.Size(200, 28);
            this.buttonTakeOrderInWork.TabIndex = 3;
            this.buttonTakeOrderInWork.Text = "Отдать на выполнение";
            this.buttonTakeOrderInWork.UseVisualStyleBackColor = true;
            this.buttonTakeOrderInWork.Click += new System.EventHandler(this.buttonTakeOrderInWork_Click);
            // 
            // buttonOrderReady
            // 
            this.buttonOrderReady.Location = new System.Drawing.Point(1066, 163);
            this.buttonOrderReady.Margin = new System.Windows.Forms.Padding(4);
            this.buttonOrderReady.Name = "buttonOrderReady";
            this.buttonOrderReady.Size = new System.Drawing.Size(200, 28);
            this.buttonOrderReady.TabIndex = 4;
            this.buttonOrderReady.Text = "Заказ готов";
            this.buttonOrderReady.UseVisualStyleBackColor = true;
            this.buttonOrderReady.Click += new System.EventHandler(this.buttonOrderReady_Click);
            // 
            // buttonPayOrder
            // 
            this.buttonPayOrder.Location = new System.Drawing.Point(1066, 227);
            this.buttonPayOrder.Margin = new System.Windows.Forms.Padding(4);
            this.buttonPayOrder.Name = "buttonPayOrder";
            this.buttonPayOrder.Size = new System.Drawing.Size(200, 28);
            this.buttonPayOrder.TabIndex = 5;
            this.buttonPayOrder.Text = "Заказ оплачен";
            this.buttonPayOrder.UseVisualStyleBackColor = true;
            this.buttonPayOrder.Click += new System.EventHandler(this.buttonPayOrder_Click);
            // 
            // buttonRef
            // 
            this.buttonRef.Location = new System.Drawing.Point(1066, 287);
            this.buttonRef.Margin = new System.Windows.Forms.Padding(4);
            this.buttonRef.Name = "buttonRef";
            this.buttonRef.Size = new System.Drawing.Size(200, 28);
            this.buttonRef.TabIndex = 6;
            this.buttonRef.Text = "Обновить список";
            this.buttonRef.UseVisualStyleBackColor = true;
            this.buttonRef.Click += new System.EventHandler(this.buttonRef_Click);
            // 
            // списокЗаготовокToolStripMenuItem
            // 
            this.списокЗаготовокToolStripMenuItem.Name = "списокЗаготовокToolStripMenuItem";
            this.списокЗаготовокToolStripMenuItem.Size = new System.Drawing.Size(245, 26);
            this.списокЗаготовокToolStripMenuItem.Text = "Список заготовок";
            this.списокЗаготовокToolStripMenuItem.Click += new System.EventHandler(this.списокЗаготовокToolStripMenuItem_Click);
            // 
            // заготовкиПоСкладамToolStripMenuItem
            // 
            this.заготовкиПоСкладамToolStripMenuItem.Name = "заготовкиПоСкладамToolStripMenuItem";
            this.заготовкиПоСкладамToolStripMenuItem.Size = new System.Drawing.Size(245, 26);
            this.заготовкиПоСкладамToolStripMenuItem.Text = "Заготовки по складам";
            this.заготовкиПоСкладамToolStripMenuItem.Click += new System.EventHandler(this.заготовкиПоСкладамToolStripMenuItem_Click);
            // 
            // списокСкладовToolStripMenuItem
            // 
            this.списокСкладовToolStripMenuItem.Name = "списокСкладовToolStripMenuItem";
            this.списокСкладовToolStripMenuItem.Size = new System.Drawing.Size(245, 26);
            this.списокСкладовToolStripMenuItem.Text = "Список складов";
            this.списокСкладовToolStripMenuItem.Click += new System.EventHandler(this.списокСкладовToolStripMenuItem_Click);
            // 
            // клиентыToolStripMenuItem
            // 
            this.клиентыToolStripMenuItem.Name = "клиентыToolStripMenuItem";
            this.клиентыToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.клиентыToolStripMenuItem.Text = "Клиенты";
            this.клиентыToolStripMenuItem.Click += new System.EventHandler(this.клиентыToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1279, 396);
            this.Controls.Add(this.buttonRef);
            this.Controls.Add(this.buttonPayOrder);
            this.Controls.Add(this.buttonOrderReady);
            this.Controls.Add(this.buttonTakeOrderInWork);
            this.Controls.Add(this.buttonCreateOrder);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormMain";
            this.Text = "Магазин";
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem справочникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem заготовкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem мебельToolStripMenuItem;
        private System.Windows.Forms.Button buttonCreateOrder;
        private System.Windows.Forms.Button buttonTakeOrderInWork;
        private System.Windows.Forms.Button buttonOrderReady;
        private System.Windows.Forms.Button buttonPayOrder;
        private System.Windows.Forms.Button buttonRef;
        private System.Windows.Forms.ToolStripMenuItem складToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem пополнитьСкладыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отчетыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списокМебелиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem заготовкиМебелиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списокЗаказовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списокЗаготовокToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem заготовкиПоСкладамToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списокСкладовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem клиентыToolStripMenuItem;
    }
}
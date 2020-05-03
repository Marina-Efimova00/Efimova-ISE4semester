namespace AbstractMebelView
{
    partial class FormReportZagotovka
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
            this.components = new System.ComponentModel.Container();
            this.ReportStorageZagotovkaViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.buttonToPdf = new System.Windows.Forms.Button();
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.ReportStorageZagotovkaViewModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ReportStorageZagotovkaViewModelBindingSource
            // 
            this.ReportStorageZagotovkaViewModelBindingSource.DataSource = typeof(AbstractMebelBusinessLogic.ViewModels.ReportStorageZagotovkaViewModel);
            // 
            // buttonToPdf
            // 
            this.buttonToPdf.Location = new System.Drawing.Point(726, 12);
            this.buttonToPdf.Name = "buttonToPdf";
            this.buttonToPdf.Size = new System.Drawing.Size(174, 38);
            this.buttonToPdf.TabIndex = 1;
            this.buttonToPdf.Text = "В Pdf";
            this.buttonToPdf.UseVisualStyleBackColor = true;
            this.buttonToPdf.Click += new System.EventHandler(this.buttonToPdf_Click);
            // 
            // reportViewer
            // 
            this.reportViewer.LocalReport.ReportEmbeddedResource = "AbstractMebelView.ReportZagotovka.rdlc";
            this.reportViewer.Location = new System.Drawing.Point(10, 61);
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.ServerReport.BearerToken = null;
            this.reportViewer.Size = new System.Drawing.Size(890, 465);
            this.reportViewer.TabIndex = 2;
            this.reportViewer.Load += new System.EventHandler(this.reportViewer_Load);
            // 
            // FormReportZagotovka
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 532);
            this.Controls.Add(this.reportViewer);
            this.Controls.Add(this.buttonToPdf);
            this.Name = "FormReportZagotovka";
            this.Text = "Список заготовок";
            ((System.ComponentModel.ISupportInitialize)(this.ReportStorageZagotovkaViewModelBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource ReportStorageZagotovkaViewModelBindingSource;
        private System.Windows.Forms.Button buttonToPdf;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
    }
}
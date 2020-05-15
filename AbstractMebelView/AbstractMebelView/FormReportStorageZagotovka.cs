using AbstractMebelBusinessLogic.BindingModels;
using AbstractMebelBusinessLogic.BusinessLogics;
using AbstractMebelBusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace AbstractMebelView
{
    public partial class FormReportStorageZagotovka : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly ReportLogic logic;
        private readonly IStorageLogic storageLogic;
        public FormReportStorageZagotovka(ReportLogic logic, IStorageLogic storageLogic)
        {
            InitializeComponent();
            this.logic = logic;
            this.storageLogic = storageLogic;
        }

        private void buttonSaveToExcel_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog { Filter = "xlsx|*.xlsx" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        logic.SaveStorageZagotovkasToExcelFile(new ReportBindingModel { FileName = dialog.FileName });

                        MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void FormReportStorageZagotovka_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                var dict = storageLogic.GetList();

                if (dict != null)
                {
                    dataGridView.Rows.Clear();

                    foreach (var storage in dict)
                    {
                        int zagotovkasSum = 0;

                        dataGridView.Rows.Add(new object[] { storage.StorageName, "", "" });

                        foreach (var zagotovka in storage.StorageZagotovkas)
                        {
                            dataGridView.Rows.Add(new object[] { "", zagotovka.ZagotovkaName, zagotovka.Count });
                            zagotovkasSum += zagotovka.Count;
                        }

                        dataGridView.Rows.Add(new object[] { "Итого", "", zagotovkasSum });
                        dataGridView.Rows.Add(new object[] { });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

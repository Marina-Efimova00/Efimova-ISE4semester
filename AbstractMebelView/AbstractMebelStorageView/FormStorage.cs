using AbstractMebelBusinessLogic.BindingModels;
using AbstractMebelBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AbstractMebelStorageView
{
    public partial class FormStorage : Form
    {
        public int Id { set { id = value; } }
        private int? id;
        private List<StorageZagotovkaViewModel> storageZagotovkas;
        public FormStorage()
        {
            InitializeComponent();
        }
        private void FormStorage_Load(object sender, EventArgs e)
        {
            dataGridView.Columns.Add("Id", "Id");
            dataGridView.Columns.Add("Заготовка", "Заготовка");
            dataGridView.Columns.Add("Количество", "Количество");
            dataGridView.Columns[0].Visible = false;
            dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            if (id.HasValue)
            {
                try
                {
                    StorageViewModel view = APIStorage.GetRequest<StorageViewModel>($"api/storage/getstorage?storageId={id.Value}");
                    if (view != null)
                    {
                        storageNameTextBox.Text = view.StorageName;
                        storageZagotovkas = view.StorageZagotovkas;
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                storageZagotovkas = new List<StorageZagotovkaViewModel>();
            }
        }
        private void LoadData()
        {
            try
            {
                if (storageZagotovkas != null)
                {
                    dataGridView.Rows.Clear();
                    foreach (var storageZagotovka in storageZagotovkas)
                    {
                        dataGridView.Rows.Add(new object[] { storageZagotovka.Id, storageZagotovka.ZagotovkaName, storageZagotovka.Count });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(storageNameTextBox.Text))
            {
                MessageBox.Show("Заполните поле Название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                APIStorage.PostRequest("api/Storage/createorupdatestorage", new StorageBindingModel
                {
                    Id = id,
                    StorageName = storageNameTextBox.Text
                });
                MessageBox.Show("Успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}

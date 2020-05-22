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
    public partial class FormFillStorage : Form
    {
        private int id;
        public FormFillStorage(int id)
        {
            InitializeComponent();
            this.id = id;
        }
        private void FormFillStorage_Load(object sender, System.EventArgs e)
        {
            try
            {
                List<ZagotovkaViewModel> list = APIStorage.GetRequest<List<ZagotovkaViewModel>>($"api/storage/getzagotovkaslist");
                if (list != null)
                {
                    comboBoxZagotovka.DisplayMember = "ZagotovkaName";
                    comboBoxZagotovka.ValueMember = "Id";
                    comboBoxZagotovka.DataSource = list;
                    comboBoxZagotovka.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSave_Click(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (comboBoxZagotovka.SelectedValue == null)
            {
                MessageBox.Show("Выберите зоготовку", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                APIStorage.PostRequest("api/storage/fillstorage", new StorageZagotovkaBindingModel
                {
                    Id = 0,
                    StorageId = id,
                    ZagotovkaId = Convert.ToInt32(comboBoxZagotovka.SelectedValue),
                    Count = Convert.ToInt32(textBoxCount.Text)
                });

                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}

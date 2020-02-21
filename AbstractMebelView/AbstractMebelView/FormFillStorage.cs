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
    public partial class FormFillStorage : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly IZagotovkaLogic logicZ;
        private readonly MainLogic logicM;
        private readonly IStorageLogic logicS;
        public FormFillStorage(IZagotovkaLogic logicZ, MainLogic logicM, IStorageLogic logicS)
        {
            InitializeComponent();
            this.logicZ = logicZ;
            this.logicM = logicM;
            this.logicS = logicS;
        }
        private void FormFillStorage_Load(object sender, EventArgs e)
        {
            try
            {
                var storageList = logicS.GetList();
                comboBoxStorage.DataSource = storageList;
                comboBoxStorage.DisplayMember = "StorageName";
                comboBoxStorage.ValueMember = "Id";

                var zagotovkaList = logicZ.Read(null);
                comboBoxZagotovka.DataSource = zagotovkaList;
                comboBoxZagotovka.DisplayMember = "ZagotovkaName";
                comboBoxZagotovka.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните количество", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            if (comboBoxStorage.SelectedValue == null)
            {
                MessageBox.Show("Выберите склад", "Ошибка", MessageBoxButtons.OK,
MessageBoxIcon.Error);
                return;
            }
            if (comboBoxZagotovka.SelectedValue == null)
            {
                MessageBox.Show("Выберите заготовку", "Ошибка", MessageBoxButtons.OK,
MessageBoxIcon.Error);
                return;
            }

            try
            {
                int storageId = Convert.ToInt32(comboBoxStorage.SelectedValue);
                int zagotovkaId = Convert.ToInt32(comboBoxZagotovka.SelectedValue);
                int count = Convert.ToInt32(textBoxCount.Text);

                this.logicM.FillStorage(new StorageZagotovkaBindingModel
                {
                    StorageId = storageId,
                    ZagotovkaId = zagotovkaId,
                    Count = count
                });
                MessageBox.Show("Склад успешно пополнен", "Сообщение",
                  MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
MessageBoxIcon.Error);
            }
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}

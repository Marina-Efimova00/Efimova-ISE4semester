using AbstractMebelBusinessLogic.Interfaces;
using AbstractMebelBusinessLogic.ViewModels;
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
    public partial class FormMebelZagotovka : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id
        {
            get { return Convert.ToInt32(comboBoxZagotovka.SelectedValue); }
            set { comboBoxZagotovka.SelectedValue = value; }
        }
        public string ZagotovkaName { get { return comboBoxZagotovka.Text; } }
        public int Count
        {
            get { return Convert.ToInt32(textBoxCount.Text); }
            set
            {
                textBoxCount.Text = value.ToString();
            }
        }
        public FormMebelZagotovka(IZagotovkaLogic logic)
        {
            InitializeComponent();
            List<ZagotovkaViewModel> list = logic.Read(null);
            if (list != null)
            {
                comboBoxZagotovka.DisplayMember = "ZagotovkaName";
                comboBoxZagotovka.ValueMember = "Id";
                comboBoxZagotovka.DataSource = list;
                comboBoxZagotovka.SelectedItem = null;
            }
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxZagotovka.SelectedValue == null)
            {
                MessageBox.Show("Выберите заготовку", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            DialogResult = DialogResult.OK;
            Close();
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}

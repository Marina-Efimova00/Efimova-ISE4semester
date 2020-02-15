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
        public MebelZagotovkaViewModel ModelView { get; set; }
        private readonly IZagotovkaLogic logic;
        public FormMebelZagotovka(IZagotovkaLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }
        private void FormMebelZagotovka_Load(object sender, EventArgs e)
        {
            try
            {
                List<ZagotovkaViewModel> list = logic.GetList();
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
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
            if (ModelView != null)
            {
                comboBoxZagotovka.Enabled = false;
                comboBoxZagotovka.SelectedValue = ModelView.ZagotovkaId;
                textBoxCount.Text = ModelView.Count.ToString();
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
            try
            {
                if (ModelView == null)
                {
                    ModelView = new MebelZagotovkaViewModel
                    {
                        ZagotovkaId = Convert.ToInt32(comboBoxZagotovka.SelectedValue),
                        ZagotovkaName = comboBoxZagotovka.Text,
                        Count = Convert.ToInt32(textBoxCount.Text)
                    };
                }
                else
                {
                    ModelView.Count = Convert.ToInt32(textBoxCount.Text);
                }
                MessageBox.Show("Сохранение прошло успешно", "Сообщение",
               MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
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

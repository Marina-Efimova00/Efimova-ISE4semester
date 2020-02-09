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
    public partial class FormProductMebel : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public ProductMebelViewModel ModelView { get; set; }
        private readonly IMebelLogic logic;
        public FormProductMebel(IMebelLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }
        private void FormProductMebel_Load(object sender, EventArgs e)
        {
            try
            {
                List<MebelViewModel> list = logic.GetList();
                if (list != null)
                {
                    comboBoxMebel.DisplayMember = "MebelName";
                    comboBoxMebel.ValueMember = "Id";
                    comboBoxMebel.DataSource = list;
                    comboBoxMebel.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
            if (ModelView != null)
            {
                comboBoxMebel.Enabled = false;
                comboBoxMebel.SelectedValue = ModelView.MebelId;
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
            if (comboBoxMebel.SelectedValue == null)
            {
                MessageBox.Show("Выберите компонент", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (ModelView == null)
                {
                    ModelView = new ProductMebelViewModel
                    {
                        MebelId = Convert.ToInt32(comboBoxMebel.SelectedValue),
                        MebelName = comboBoxMebel.Text,
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

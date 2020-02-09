using AbstractMebelBusinessLogic.BindingModels;
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
    public partial class FormProduct : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id { set { id = value; } }
        private readonly IProductLogic logic;
        private int? id;
        private List<ProductMebelViewModel> productMebels;
        public FormProduct(IProductLogic service)
        {
            InitializeComponent();
            this.logic = service;
        }
        private void FormProduct_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    ProductViewModel view = logic.GetElement(id.Value);
                    if (view != null)
                    {
                        textBoxName.Text = view.ProductName;
                        textBoxPrice.Text = view.Price.ToString();
                        productMebels = view.ProductMebels;
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
            else
            {
                productMebels = new List<ProductMebelViewModel>();
            }
        }
        private void LoadData()
        {
            try
            {
                if (productMebels != null)
                {
                    dataGridView.DataSource = null;
                    dataGridView.DataSource = productMebels;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[1].Visible = false;
                    dataGridView.Columns[2].Visible = false;
                    dataGridView.Columns[3].AutoSizeMode =
                   DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormProductMebel>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (form.ModelView != null)
                {
                    if (id.HasValue)
                    {
                        form.ModelView.ProductId = id.Value;
                    }
                    productMebels.Add(form.ModelView);
                }
                LoadData();
            }
        }
        private void buttonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormProductMebel>();
                form.ModelView =
               productMebels[dataGridView.SelectedRows[0].Cells[0].RowIndex];
                if (form.ShowDialog() == DialogResult.OK)
                {
                    productMebels[dataGridView.SelectedRows[0].Cells[0].RowIndex] =
                   form.ModelView;
                    LoadData();
                }
            }
        }
        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo,
               MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {

                        productMebels.RemoveAt(dataGridView.SelectedRows[0].Cells[0].RowIndex);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }
        private void buttonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxPrice.Text))
            {
                MessageBox.Show("Заполните цену", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            if (productMebels == null || productMebels.Count == 0)
            {
                MessageBox.Show("Заполните компоненты", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            try
            {
                List<ProductMebelBindingModel> productMebelBM = new
               List<ProductMebelBindingModel>();
                for (int i = 0; i < productMebels.Count; ++i)
                {
                    productMebelBM.Add(new ProductMebelBindingModel
                    {
                        Id = productMebels[i].Id,
                        ProductId = productMebels[i].ProductId,
                        MebelId = productMebels[i].MebelId,
                        Count = productMebels[i].Count
                    });
                }
                if (id.HasValue)
                {
                    logic.UpdElement(new ProductBindingModel
                    {
                        Id = id.Value,
                        ProductName = textBoxName.Text,
                        Price = Convert.ToDecimal(textBoxPrice.Text),
                        ProductMebels = productMebelBM
                    });
                }
                else
                {
                    logic.AddElement(new ProductBindingModel
                    {
                        ProductName = textBoxName.Text,
                        Price = Convert.ToDecimal(textBoxPrice.Text),
                        ProductMebels = productMebelBM
                    });
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

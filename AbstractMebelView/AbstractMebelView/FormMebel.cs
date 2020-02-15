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
    public partial class FormMebel : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id { set { id = value; } }
        private readonly IMebelLogic logic;
        private int? id;
        private List<MebelZagotovkaViewModel> mebelZagotovkas;
        public FormMebel(IMebelLogic service)
        {
            InitializeComponent();
            this.logic = service;
        }
        private void FormMebel_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    MebelViewModel view = logic.GetElement(id.Value);
                    if (view != null)
                    {
                        textBoxName.Text = view.MebelName;
                        textBoxPrice.Text = view.Price.ToString();
                        mebelZagotovkas = view.MebelZagotovkas;
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
                mebelZagotovkas = new List<MebelZagotovkaViewModel>();
            }
        }
        private void LoadData()
        {
            try
            {
                if (mebelZagotovkas != null)
                {
                    dataGridView.DataSource = null;
                    dataGridView.DataSource = mebelZagotovkas;
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
            var form = Container.Resolve<FormMebelZagotovka>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (form.ModelView != null)
                {
                    if (id.HasValue)
                    {
                        form.ModelView.MebelId = id.Value;
                    }
                    mebelZagotovkas.Add(form.ModelView);
                }
                LoadData();
            }
        }
        private void buttonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormMebelZagotovka>();
                form.ModelView =
               mebelZagotovkas[dataGridView.SelectedRows[0].Cells[0].RowIndex];
                if (form.ShowDialog() == DialogResult.OK)
                {
                    mebelZagotovkas[dataGridView.SelectedRows[0].Cells[0].RowIndex] =
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
                        mebelZagotovkas.RemoveAt(dataGridView.SelectedRows[0].Cells[0].RowIndex);
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
            if (mebelZagotovkas == null || mebelZagotovkas.Count == 0)
            {
                MessageBox.Show("Заполните заготовки", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            try
            {
                List<MebelZagotovkaBindingModel> mebelZagotovkaBM = new
               List<MebelZagotovkaBindingModel>();
                for (int i = 0; i < mebelZagotovkas.Count; ++i)
                {
                    mebelZagotovkaBM.Add(new MebelZagotovkaBindingModel
                    {
                        Id = mebelZagotovkas[i].Id,
                        MebelId = mebelZagotovkas[i].MebelId,
                        ZagotovkaId = mebelZagotovkas[i].ZagotovkaId,
                        Count = mebelZagotovkas[i].Count
                    });
                }
                if (id.HasValue)
                {
                    logic.UpdElement(new MebelBindingModel
                    {
                        Id = id.Value,
                        MebelName = textBoxName.Text,
                        Price = Convert.ToDecimal(textBoxPrice.Text),
                        MebelZagotovkas = mebelZagotovkaBM
                    });
                }
                else
                {
                    logic.AddElement(new MebelBindingModel
                    {
                        MebelName = textBoxName.Text,
                        Price = Convert.ToDecimal(textBoxPrice.Text),
                        MebelZagotovkas = mebelZagotovkaBM
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

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
        private Dictionary<int, (string, int)> MebelZagotovkas;
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
                    MebelViewModel view = logic.Read(new MebelBindingModel
                    {
                        Id = id.Value
                    })?[0];
                    if (view != null)
                    {
                        textBoxName.Text = view.MebelName;
                        textBoxPrice.Text = view.Price.ToString();
                        MebelZagotovkas = view.MebelZagotovkas;
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
                MebelZagotovkas = new Dictionary<int, (string, int)>();
            }
        }
        private void LoadData()
        {
            try
            {
                if (MebelZagotovkas != null)
                {
                    dataGridView.Rows.Clear();
                    foreach (var bf in MebelZagotovkas)
                    {
                        dataGridView.Rows.Add(new object[] { bf.Key, bf.Value.Item1, bf.Value.Item2 });
                    }
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
                if (MebelZagotovkas.ContainsKey(form.Id))
                {
                    MebelZagotovkas[form.Id] = (form.ZagotovkaName, form.Count);
                }
                else
                {
                    MebelZagotovkas.Add(form.Id, (form.ZagotovkaName, form.Count));
                }
                LoadData();
            }
        }
        private void buttonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormMebelZagotovka>();
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                form.Id = id;
                form.Count = MebelZagotovkas[id].Item2;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    MebelZagotovkas[form.Id] = (form.ZagotovkaName, form.Count);
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
                        MebelZagotovkas.Remove(Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value));
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
            if (MebelZagotovkas == null || MebelZagotovkas.Count == 0)
            {
                MessageBox.Show("Заполните заготовки", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            try
            {
                logic.CreateOrUpdate(new MebelBindingModel
                {
                    Id = id,
                    MebelName = textBoxName.Text,
                    Price = Convert.ToDecimal(textBoxPrice.Text),
                    MebelZagotovkas = MebelZagotovkas
                });
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

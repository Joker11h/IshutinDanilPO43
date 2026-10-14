using System;

namespace turbofalushiki
{
    public partial class FormMain : Form
    {
        private List<Software> softwareList = new List<Software>();
        public FormMain()
        {
            InitializeComponent();
        }
        private void RefreshListBox()
        {
            lstSoftware.DataSource = null;
            lstSoftware.DataSource = softwareList;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string title = txtTitle.Text;
                string version = txtVersion.Text;
                decimal price = numPrice.Value;
                string key = txtLicenseKey.Text;
                int days = (int)numLicenseDays.Value;
                if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(key))
                {
                    MessageBox.Show("Заполните все текстовые поля");
                    return;
                }
                License newLecense = new License(key, days);
                Software newSoftware = new Software(title, version, price, newLecense);
                softwareList.Add(newSoftware);
                RefreshListBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка добавления: {ex.Message}");
            }
        }
        private void btnSort_Click(object sender, EventArgs e)
        {
            softwareList.Sort();
            RefreshListBox();
        }
        private void btnClone_Click(object sender, EventArgs e)
        {
            if (lstSoftware.SelectedItem is Software selectedSoftware)
            {
                Software clonedSoftware = (Software)selectedSoftware.Clone();
                clonedSoftware.SetTitle(clonedSoftware.Title + " (Копия)");
                softwareList.Add(clonedSoftware);
                RefreshListBox();
            }
            else
            {
                MessageBox.Show("Выберите программу для клонирования");
            }
        }
        private void btnModifyClone_Click(object sender, EventArgs e)
        {
            if (lstSoftware.SelectedItem is Software selectedSoftware)
            {
                selectedSoftware.SoftwareLicense.UpdateLicense("TEST-TEST", 123);
                RefreshListBox();
                MessageBox.Show("Лицензия изменина. Убедитесь что у оригинального обьекта лицензия осталось прежней - это доказывает работу Deep Copy");
            }
        }
    }
}
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ArchiveFashionStore
{
    public partial class ReportForm : Form
    {

        private Database database = new Database();


        public ReportForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            FillChart();
        }

        private void ResetChart() { reportChart.Titles.Clear(); }

        System.DateTime datetime = System.DateTime.Now;

        /// <summary>
        /// Заполнение диаграммы
        /// </summary>
        private void FillChart()
        {
            database.open_connection();
            DataTable data_table = new DataTable();
            string query = periodCheckBox.Checked ? $"SELECT OrderDate, TotalAmount FROM Orders WHERE OrderDate > '{startMaskedTextBox.Text}' AND OrderDate < '{endMaskedTextBox.Text}'"
                : "SELECT OrderDate, TotalAmount FROM Orders";
            SqlDataAdapter sql_data_adapter = new SqlDataAdapter(query, database.get_connection());
            try
            {
                sql_data_adapter.Fill(data_table);
                reportChart.DataSource = data_table;
                reportChart.Series["Полная стоимость"].YValueMembers = "TotalAmount";
                reportChart.Series["Полная стоимость"].XValueMember = "OrderDate";
                reportChart.Titles.Add("orders total amount");
            }
            catch (System.Exception)
            {
                MessageBox.Show("Что-то пошло не так, пожалуйста введите данные корректно!", "Отчёт", MessageBoxButtons.OK, MessageBoxIcon.Error);
                startMaskedTextBox.Text = "2022-01-01";
                endMaskedTextBox.Text = "2024-01-01";
            }
        }

        /// <summary>
        /// Полное обновление диаграммы
        /// </summary>
        private void SetChart()
        {
            ResetChart();
            FillChart();
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            SetChart();
        }

        private void periodCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            periodPanel.Enabled = periodCheckBox.Checked;
            SetChart();
        }
    }
}

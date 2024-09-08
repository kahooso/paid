using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace ArchiveFashionStore
{
    public partial class AddForm : Form
    {
        Database database = new Database();
        public AddForm()
        {
            InitializeComponent();
            InitializeFont();
            InitializeColors();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void InitializeColors()
        {
            ForeColor = Color.Black;
            productsTabPage.BackColor = Color.LightBlue;
            ordersTabPage.BackColor = Color.LightPink;
            order_details_TabPage.BackColor = Color.LightSlateGray;
            productVariantsTabPage.BackColor = Color.LightYellow;
            employeesTabPage.BackColor = Color.LightSalmon;
            designersTabPage.BackColor = Color.LightGoldenrodYellow;
            collectionsTabPage.BackColor = Color.LightCyan;
            saveButton.BackColor = Color.LightSteelBlue;
        }

        private void InitializeFont() { Font = new Font("Roboto", 12, System.Drawing.FontStyle.Regular); }

        private void saveButton_Click(object sender, EventArgs e)
        {
            database.open_connection();
            try
            {
                var add_query = "";
                if (fieldsTabControl.SelectedTab == collectionsTabPage) //smt
                {
                    add_query = $"INSERT INTO Collections ([DesignerID], [CollectionName], [LaunchDate]) " +
                        $"VALUES ({collections_designer_ID_TextBox.Text}, '{collections_name_TextBox.Text}', '{collections_launch_date_TextBox.Text}')";
                }
                else if (fieldsTabControl.SelectedTab == designersTabPage)
                {
                    add_query = $"INSERT INTO Designers ([FullName], [Country], [Biography]) " +
                        $"VALUES ('{designer_full_name_TextBox.Text}', '{designer_country_TextBox.Text}', '{designer_biography_TextBox.Text}')";
                }
                else if (fieldsTabControl.SelectedTab == employeesTabPage)
                {
                    add_query = $"INSERT INTO Employees ([login], [password], FirstName, SecondName, isAdmin) " +
                        $"VALUES ('{employee_login_TextBox.Text}', '{md5.GetHashedPassword(employee_password_TextBox.Text)}'," +
                        $" '{employee_first_name_TextBox.Text}', '{employee_last_name_TextBox.Text}', 0)";
                }
                else if (fieldsTabControl.SelectedTab == ordersTabPage)
                {
                    add_query = $"INSERT INTO Orders (CustomerName, OrderDate, TotalAmount) " +
                        $"VALUES ('{order_customer_id_TextBox.Text}', '{order_order_date_TextBox.Text}', {order_total_amount_TextBox.Text})";
                }
                else if (fieldsTabControl.SelectedTab == order_details_TabPage)
                {
                    add_query = $"INSERT INTO OrderDetails (OrderID, VariantID, Quantity, UnitPrice) " +
                        $"VALUES ({order_detail_order_id_TextBox.Text}, {order_detail_variant_id_TextBox.Text}, " +
                        $"{order_detail_quantity_TextBox.Text}, {order_detail_unit_price_TextBox.Text})";

                }
                else if (fieldsTabControl.SelectedTab == productsTabPage)
                {
                    add_query = $"INSERT INTO Products (CollectionID, ProductName, Description, Price) " +
                        $"VALUES ('{product_name_TextBox.Text}', " +
                        $"'{product_description_TextBox.Text}', {product_price_TextBox.Text})";
                }
                else if (fieldsTabControl.SelectedTab == productVariantsTabPage)
                {
                    add_query = $"INSERT INTO Variants (ProductID, VariantName, [Size], [Color], [StockQuantity]) " +
                        $"VALUES ({product_variants_product_ID_TextBox.Text}, '{product_variants_name_TextBox.Text}', " +
                        $"'{product_variants_size_TextBox.Text}', '{product_variants_color_TextBox.Text}', {product_variants_stock_quantity_TextBox.Text})";
                }
                var command = new SqlCommand(add_query, database.get_connection());
                command.ExecuteNonQuery();

                MessageBox.Show("Новая запись успешно добавлена!", "Новая запись", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Что-то пошло не так!", "Новая запись", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}

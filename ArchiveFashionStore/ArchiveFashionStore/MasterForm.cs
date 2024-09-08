using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace ArchiveFashionStore
{
    public partial class MasterForm : Form
    {
        private readonly User _user;
        Database database = new Database();

        int selected_row;

        public MasterForm(User user)
        {
            _user = user;
            InitializeComponent();
            InitializeFont();
            InitializeColors();
            InitializeComboBox();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void InitializeComboBox() { tableComboBox.SelectedIndex = 0; }
        private void InitializeFont() { Font = new Font("Roboto", 12, FontStyle.Regular); }
        private void InitializeColors()
        {
            clearToolStripButton.Image = Properties.Resources.cleaning_icons_in_png_sharp_details;
            resetToolStripButton.Image = Properties.Resources.Refresh_icon;
            ForeColor = Color.Black;
            buttonsPanel.BackColor = Color.LightSkyBlue;
            productsTabPage.BackColor = Color.LightBlue;
            ordersTabPage.BackColor = Color.LightPink;
            order_details_TabPage.BackColor = Color.LightSlateGray;
            designersTabPage.BackColor = Color.LightYellow;
            employeesTabPage.BackColor = Color.LightSalmon;
            productVariantsTabPage.BackColor = Color.LightGoldenrodYellow;
            collectionsTabPage.BackColor = Color.LightCyan;
            searchToolStripTextBox.BackColor = Color.ForestGreen;
            searchToolStripTextBox.ForeColor = Color.AliceBlue;
        }

        private void MasterForm_Load(object sender, EventArgs e)
        {
            statusToolStripTextBox.Text = $"Логин: {_user.login}";
            IsAdmin();
            CreateCollumns();
            RefreshDataGridView(dataGridView);
        }

        public void CreateCollumns()
        {
            dataGridView.Rows.Clear();
            dataGridView.Columns.Clear();
            switch (tableComboBox.Text)
            {
                case "Employees":
                    dataGridView.Columns.Add("EmployeeID", "ID");
                    dataGridView.Columns.Add("login", "Логин");
                    dataGridView.Columns.Add("password", "Пароль");
                    dataGridView.Columns.Add("FirstName", "Имя");
                    dataGridView.Columns.Add("SecondName", "Фамилия");
                    dataGridView.Columns.Add("IsNew", string.Empty);
                    break;
                case "Collections":
                    dataGridView.Columns.Add("CollectionID", "ID");
                    dataGridView.Columns.Add("DesignerID", "ID дизайнера");
                    dataGridView.Columns.Add("CollectionName", "Имя коллекции");
                    dataGridView.Columns.Add("LaunchDate", "Дата релиза");
                    dataGridView.Columns.Add("IsNew", string.Empty);
                    break;
                case "Designers":
                    dataGridView.Columns.Add("DesignerID", "ID");
                    dataGridView.Columns.Add("FullName", "Название");
                    dataGridView.Columns.Add("Country", "Страна происхождения");
                    dataGridView.Columns.Add("Biography", "Биография");
                    dataGridView.Columns.Add("IsNew", string.Empty);
                    break;
                case "OrderDetails":
                    dataGridView.Columns.Add("OrderDetailID", "ID");
                    dataGridView.Columns.Add("OrderID", "ID заказа");
                    dataGridView.Columns.Add("VariantID", "ID вещи");
                    dataGridView.Columns.Add("Quantity", "Количество");
                    dataGridView.Columns.Add("UnitPrice", "Цена за единицу");
                    dataGridView.Columns.Add("IsNew", string.Empty);
                    break;
                case "Orders":
                    dataGridView.Columns.Add("OrderID", "ID");
                    dataGridView.Columns.Add("CustomerName", "Имя клиента");
                    dataGridView.Columns.Add("OrderDate", "Дата заказа");
                    dataGridView.Columns.Add("TotalAmount", "Общая сумма заказа");
                    dataGridView.Columns.Add("IsNew", string.Empty);
                    break;
                case "Products":
                    dataGridView.Columns.Add("ProductID", "ID");
                    dataGridView.Columns.Add("CollectionID", "ID коллекции");
                    dataGridView.Columns.Add("ProductName", "Название продукта");
                    dataGridView.Columns.Add("Description", "Описание");
                    dataGridView.Columns.Add("Price", "Цена");
                    dataGridView.Columns.Add("IsNew", string.Empty);
                    break;
                case "Variants":
                    dataGridView.Columns.Add("VariantID", "ID");
                    dataGridView.Columns.Add("ProductID", "ID продукта");
                    dataGridView.Columns.Add("VarianName", "Название вещи");
                    dataGridView.Columns.Add("Size", "Размер");
                    dataGridView.Columns.Add("Color", "Цвет");
                    dataGridView.Columns.Add("StockQuantity", "Количество");
                    dataGridView.Columns.Add("IsNew", string.Empty);
                    break;

            }
            dataGridView.Columns["IsNew"].Visible = false;
        }

        private void ReadSingleRow(DataGridView dataGridView, IDataRecord record)
        {
            switch (tableComboBox.Text)
            {
                case "Employees":
                    dataGridView.Rows.Add(
                        record.GetInt32(0),
                        record.GetString(1),
                        record.GetString(2),
                        record.GetString(3),
                        record.GetString(4),
                        RowState.ModifiedNew
                        );
                    break;
                case "Designers":
                    dataGridView.Rows.Add(
                        record.GetInt32(0),
                        record.GetString(1),
                        record.GetString(2),
                        record.GetString(3),
                        RowState.ModifiedNew);
                    break;
                case "Collections":
                    dataGridView.Rows.Add(
                        record.GetInt32(0),
                        record.GetInt32(1),
                        record.GetString(2),
                        record.GetDateTime(3),
                        RowState.ModifiedNew
                        );
                    break;
                case "OrderDetails":
                    dataGridView.Rows.Add(
                        record.GetInt32(0),
                        record.GetInt32(1),
                        record.GetInt32(2),
                        record.GetInt32(3),
                        record.GetDecimal(4),
                        RowState.ModifiedNew
                        );
                    break;
                case "Orders":
                    dataGridView.Rows.Add(
                        record.GetInt32(0),
                        record.GetString(1),
                        record.GetDateTime(2),
                        record.GetDecimal(3),
                        RowState.ModifiedNew
                        );
                    break;
                case "Products":
                    dataGridView.Rows.Add(
                        record.GetInt32(0),
                        record.GetInt32(1),
                        record.GetString(2),
                        record.GetString(3),
                        record.GetDecimal(4),
                        RowState.ModifiedNew
                        );
                    break;
                case "Variants":
                    dataGridView.Rows.Add(
                        record.GetInt32(0),
                        record.GetInt32(1),
                        record.GetString(2),
                        record.GetString(3),
                        record.GetString(4),
                        record.GetInt32(5),
                        RowState.ModifiedNew
                        );
                    break;
            }
        }

        /// <summary>
        /// Обновление таблицы
        /// </summary>
        /// <param name="dataGridView"></param>
        private void RefreshDataGridView(DataGridView dataGridView)
        {
            dataGridView.Rows.Clear();
            string query_string = $"SELECT * FROM {tableComboBox.Text}";
            SqlCommand sql_command = new SqlCommand(query_string, database.get_connection());
            database.open_connection();
            SqlDataReader sql_data_reader = sql_command.ExecuteReader();
            while (sql_data_reader.Read())
                ReadSingleRow(this.dataGridView, sql_data_reader);
            sql_data_reader.Close();
        }

        private void IsAdmin() { controlToolStripMenuItem.Enabled = deleteButton.Enabled = editButton.Enabled = saveButton.Enabled = newEntryButton.Enabled = _user.isAdmin; }

        /// <summary>
        /// Новая запись
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newEntryButton_Click(object sender, EventArgs e)
        {
            AddForm addForm = new AddForm();
            addForm.ShowDialog();
            RefreshDataGridView(dataGridView);
        }

        /// <summary>
        /// Удаление записи
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteButton_Click(object sender, EventArgs e)
        {
            delete();
            clear();
        }

        private void delete()
        {
            int index = dataGridView.CurrentCell.RowIndex;
            dataGridView.Rows[index].Visible = false;
            if (dataGridView.Rows[index].Cells[0].Value.ToString() == string.Empty)
            {
                dataGridView.Rows[index].Cells[dataGridView.ColumnCount - 1].Value = RowState.Deleted;
                return;
            }
            dataGridView.Rows[index].Cells[dataGridView.ColumnCount - 1].Value = RowState.Deleted;
        }

        /// <summary>
        /// Изменение
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void editButton_Click(object sender, EventArgs e)
        {
            edit();
            clear(); 
        }

        private void edit()
        {
            var selectedRowIndex = dataGridView.CurrentCell.RowIndex;
            int stock_quantity, product_id, collection_id, designer_id, product_variants_id, employee_id, order_detail_id, order_id, variant_id, quantity;
            string color, size, variant_name, collection_name, product_name, description, designer_name, country, biography, login, password, customer_name, first_name, second_name;
            DateTime launch_date, order_date;
            decimal price, unit_price, total_amount;
            try
            {
                switch (tableComboBox.Text)
                {
                    case "Collections":
                        collection_id = Convert.ToInt32(collections_ID_TextBox.Text);
                        designer_id = Convert.ToInt32(collections_designer_ID_TextBox.Text);
                        collection_name = collections_name_TextBox.Text;
                        launch_date = Convert.ToDateTime(collections_launch_date_TextBox.Text);
                        if (dataGridView.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty) 
                            dataGridView.Rows[selectedRowIndex].SetValues(collection_id, designer_id, collection_name, launch_date);
                        else MessageBox.Show("С вашими полями что-то не так!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case "Orders":
                        order_id = Convert.ToInt32(order_ID_TextBox.Text);
                        customer_name = order_customer_id_TextBox.Text;
                        order_date = Convert.ToDateTime(order_order_date_TextBox.Text).Date;
                        total_amount = Convert.ToDecimal(order_total_amount_TextBox.Text);
                        if (dataGridView.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty)
                            if (decimal.TryParse(order_total_amount_TextBox.Text, out total_amount))
                                dataGridView.Rows[selectedRowIndex].SetValues(order_id, customer_name, order_date, total_amount);
                            else MessageBox.Show("С вашими полями что-то не так!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case "Products":
                        product_id = Convert.ToInt32(product_ID_TextBox.Text);
                        collection_id = Convert.ToInt32(product_collection_ID_TextBox.Text);
                        product_name = product_name_TextBox.Text;
                        description = product_description_TextBox.Text;
                        price = Convert.ToDecimal(product_price_TextBox.Text);
                        if (dataGridView.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty) 
                            if (decimal.TryParse(product_price_TextBox.Text, out price))
                                dataGridView.Rows[selectedRowIndex].SetValues(product_id, collection_id, product_name, description, price);
                        else MessageBox.Show("С вашими полями что-то не так!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case "OrderDetails":
                        order_detail_id = Convert.ToInt32(order_detail_ID_TextBox.Text);
                        order_id = Convert.ToInt32(order_detail_order_id_TextBox.Text);
                        variant_id = Convert.ToInt32(order_detail_variant_id_TextBox.Text);
                        quantity = Convert.ToInt32(order_detail_quantity_TextBox.Text);
                        unit_price = Convert.ToDecimal(order_detail_unit_price_TextBox.Text);
                        if (dataGridView.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty)
                            if (decimal.TryParse(order_detail_unit_price_TextBox.Text, out unit_price)) 
                                dataGridView.Rows[selectedRowIndex].SetValues(order_detail_id, order_id, variant_id, quantity, unit_price);
                            else MessageBox.Show("С вашими полями что-то не так!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case "Variants":
                        product_variants_id = Convert.ToInt32(product_variants_product_ID_TextBox.Text);
                        variant_id = Convert.ToInt32(product_variants_ID_TextBox.Text);
                        product_id = Convert.ToInt32(product_variants_product_ID_TextBox.Text);
                        variant_name = product_variants_name_TextBox.Text;
                        size = product_variants_size_TextBox.Text;
                        color = product_variants_color_TextBox.Text;
                        stock_quantity = Convert.ToInt32(product_variants_stock_quantity_TextBox.Text);
                        if (dataGridView.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty) 
                            dataGridView.Rows[selectedRowIndex].SetValues(variant_id, product_id, variant_name, size, color, stock_quantity);
                        else MessageBox.Show("С вашими полями что-то не так!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case "Employees":
                        employee_id = Convert.ToInt32(employee_ID_TextBox.Text);
                        first_name = employee_first_name_TextBox.Text;
                        second_name = employee_last_name_TextBox.Text;
                        login = employee_login_TextBox.Text;
                        password = employee_password_TextBox.Text;
                        if (dataGridView.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty) 
                            dataGridView.Rows[selectedRowIndex].SetValues(employee_id, login, md5.GetHashedPassword(password), first_name, second_name);
                        else MessageBox.Show("С вашими полями что-то не так!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case "Designers":
                        designer_id = Convert.ToInt32(designer_ID_TextBox.Text);
                        designer_name = designer_full_name_TextBox.Text;
                        country = designer_country_TextBox.Text;
                        biography = designer_biography_TextBox.Text;
                        if (dataGridView.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty)
                            dataGridView.Rows[selectedRowIndex].SetValues(designer_id, designer_name, country, biography);
                        else MessageBox.Show("С вашими полями что-то не так!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
            catch (Exception) { MessageBox.Show("С вашими полями что-то не так!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            dataGridView.Rows[selectedRowIndex].Cells[dataGridView.ColumnCount - 1].Value = RowState.Modified;
        }

        private void clear()
        {
            searchToolStripTextBox.Clear();

            collections_ID_TextBox.Clear();
            collections_designer_ID_TextBox.Clear();
            collections_name_TextBox.Clear();
            collections_launch_date_TextBox.Clear();

            employee_ID_TextBox.Clear();
            employee_first_name_TextBox.Clear();
            employee_last_name_TextBox.Clear();
            employee_login_TextBox.Clear();
            employee_password_TextBox.Clear();

            designer_ID_TextBox.Clear();
            designer_full_name_TextBox.Clear();
            designer_country_TextBox.Clear();
            designer_biography_TextBox.Clear();

            order_detail_ID_TextBox.Clear();
            order_detail_quantity_TextBox.Clear();
            order_detail_variant_id_TextBox.Clear();
            order_detail_order_id_TextBox.Clear();
            order_detail_unit_price_TextBox.Clear();

            order_ID_TextBox.Clear();
            order_total_amount_TextBox.Clear();
            order_order_date_TextBox.Clear();
            order_customer_id_TextBox.Clear();

            product_ID_TextBox.Clear();
            product_collection_ID_TextBox.Clear();
            product_description_TextBox.Clear();
            product_price_TextBox.Clear();
            product_name_TextBox.Clear();

            product_variants_ID_TextBox.Clear();
            product_variants_name_TextBox.Clear();
            product_variants_color_TextBox.Clear();
            product_variants_size_TextBox.Clear();
            product_variants_product_ID_TextBox.Clear();
            product_variants_stock_quantity_TextBox.Clear();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            save();
        }

        private void save()
        {
            database.open_connection();
            try
            {
                for (int i = 0; i < dataGridView.Rows.Count; ++i)
                {
                    var row_state = (RowState)dataGridView.Rows[i].Cells[dataGridView.ColumnCount - 1].Value;
                    if (row_state == RowState.Existed) continue;
                    if (row_state == RowState.Deleted)
                    {
                        var selected_id = Convert.ToInt32(dataGridView.Rows[i].Cells[0].Value);
                        var table_id = tableComboBox.Text;
                        table_id = table_id.Remove(table_id.Length - 1) + "ID";
                        string delete_query = $"DELETE FROM {tableComboBox.Text} WHERE {table_id} = {selected_id}";
                        using (var sql_command = new SqlCommand(delete_query, database.get_connection()))
                        {
                            sql_command.Parameters.AddWithValue("@selected_id", selected_id);
                            sql_command.ExecuteNonQuery();
                        }
                    }
                    if (row_state == RowState.Modified)
                    {
                        string change_query = "";
                        switch (tableComboBox.Text)
                        {
                            case "Collections":
                                var collection_id = dataGridView.Rows[i].Cells[0].Value.ToString();
                                var designer_id = dataGridView.Rows[i].Cells[1].Value.ToString();
                                var collection_name = dataGridView.Rows[i].Cells[2].Value.ToString();
                                var launch_date = dataGridView.Rows[i].Cells[3].Value.ToString();
                                change_query =
                                    $"UPDATE {tableComboBox.Text} SET DesignerID = {designer_id}, CollectionName = '{collection_name}', LaunchDate = '{launch_date}' WHERE CollectionID = {collection_id}";
                                break;
                            case "Orders":
                                var order_id = dataGridView.Rows[i].Cells[0].Value.ToString();
                                var customer_id = dataGridView.Rows[i].Cells[1].Value.ToString();
                                var order_date = dataGridView.Rows[i].Cells[2].Value.ToString();
                                var total_amount = dataGridView.Rows[i].Cells[3].Value.ToString();
                                change_query =
                                    $"UPDATE {tableComboBox.Text} SET CustomerName = '{customer_id}'," +
                                    $" OrderDate = '{order_date}', TotalAmount = {total_amount}" +
                                    $" WHERE OrderID = {order_id}";
                                break;
                            case "OrderDetails":
                                var order_detail_id = dataGridView.Rows[i].Cells[0].Value.ToString();
                                order_id = dataGridView.Rows[i].Cells[1].Value.ToString();
                                var variant_id = dataGridView.Rows[i].Cells[2].Value.ToString();
                                var quantity = dataGridView.Rows[i].Cells[3].Value.ToString();
                                var unit_price = dataGridView.Rows[i].Cells[4].Value.ToString();
                                change_query =
                                    $"UPDATE {tableComboBox.Text} SET OrderID = {order_id}," +
                                    $" VariantID = {variant_id}, Quantity = {quantity}, UnitPrice = {unit_price}" +
                                    $" WHERE OrderDetailID = {order_detail_id}";
                                break;
                            case "Employees":
                                var employee_id = dataGridView.Rows[i].Cells[0].Value.ToString();
                                var login = dataGridView.Rows[i].Cells[1].Value.ToString();
                                var password = dataGridView.Rows[i].Cells[2].Value.ToString();
                                var first_name = dataGridView.Rows[i].Cells[3].Value.ToString();
                                var last_name = dataGridView.Rows[i].Cells[4].Value.ToString();
                                change_query =
                                    $"UPDATE {tableComboBox.Text} SET [login] = '{login}', [password] = '{password}', FirstName = '{first_name}', SecondName = '{last_name}'" +
                                    $" WHERE EmployeeID = {employee_id}";
                                break;
                            case "Designers":
                                designer_id = dataGridView.Rows[i].Cells[0].Value.ToString();
                                var designer_name = dataGridView.Rows[i].Cells[1].Value.ToString();
                                var country = dataGridView.Rows[i].Cells[2].Value.ToString();
                                var biography = dataGridView.Rows[i].Cells[3].Value.ToString();
                                change_query =
                                    $"UPDATE {tableComboBox.Text} SET FullName = '{designer_name}', Country = '{country}', Biography = '{biography}' WHERE DesignerID = {designer_id}";
                                break;
                            case "Products":
                                var product_id = dataGridView.Rows[i].Cells[0].Value.ToString();
                                collection_id = dataGridView.Rows[i].Cells[1].Value.ToString();
                                var name = dataGridView.Rows[i].Cells[2].Value.ToString();
                                var description = dataGridView.Rows[i].Cells[3].Value.ToString();
                                var price = dataGridView.Rows[i].Cells[4].Value.ToString();
                                change_query =
                                    $"UPDATE {tableComboBox.Text} SET CollectionID = {collection_id}, ProductName = '{name}'," +
                                    $"Description = '{description}', Price = '{price}' WHERE ProductID = {product_id}";
                                break;
                            case "Variants":
                                variant_id = dataGridView.Rows[i].Cells[0].Value.ToString();
                                product_id = dataGridView.Rows[i].Cells[1].Value.ToString();
                                name = dataGridView.Rows[i].Cells[2].Value.ToString();
                                var size = dataGridView.Rows[i].Cells[3].Value.ToString();
                                var color = dataGridView.Rows[i].Cells[4].Value.ToString();
                                var stock_quantity = dataGridView.Rows[i].Cells[5].Value.ToString();
                                change_query =
                                    $"UPDATE {tableComboBox.Text} SET ProductID = {product_id}, VariantName = '{name}'," +
                                    $"Size = '{size}', Color = '{color}', StockQuantity = {stock_quantity} WHERE VariantID = {variant_id}";
                                break;
                        }
                        SqlCommand sql_command = new SqlCommand(change_query, database.get_connection());
                        sql_command.ExecuteNonQuery();
                    }
                }
            }
            catch (System.Data.SqlClient.SqlException sql_exception)
            {
                MessageBox.Show($"{sql_exception.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                database.close_connection();
            }
        }

        /// <summary>
        /// Информация
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void informationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Добро пожаловать, {_user.login}!\n\n" +
                            "Режим доступа:\n" +
                            "- Администратор: имеет полномочия добавлять, удалять и изменять данные во всех таблицах.\n" +
                            "- Пользователь: может просматривать таблицы и создавать отчёты.\n\n" +
                            "Студент: Семён Косовский\n" +
                            "Группа: 329197\n" +
                            "Магазин архивной одежды",
                            "Информация",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }


        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clear();
        }

        /// <summary>
        /// Отчёт
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void reportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportForm report_form = new ReportForm();
            this.Hide();
            report_form.ShowDialog();
            this.Show();
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selected_row = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView.Rows[selected_row];
                switch (tableComboBox.Text)
                {
                    case "Employees":
                        employee_ID_TextBox.Text = row.Cells[0].Value.ToString();
                        employee_login_TextBox.Text = row.Cells[1].Value.ToString();
                        employee_password_TextBox.Text = row.Cells[2].Value.ToString();
                        employee_first_name_TextBox.Text = row.Cells[3].Value.ToString();
                        employee_last_name_TextBox.Text = row.Cells[4].Value.ToString();
                        break;
                    case "Collections":
                        collections_ID_TextBox.Text = row.Cells[0].Value.ToString();
                        collections_designer_ID_TextBox.Text = row.Cells[1].Value.ToString();
                        collections_name_TextBox.Text = row.Cells[2].Value.ToString();
                        collections_launch_date_TextBox.Text = Convert.ToDateTime(row.Cells[3].Value.ToString()).ToString("yyyy/MM/dd");
                        break;
                    case "Orders":
                        order_ID_TextBox.Text = row.Cells[0].Value.ToString();
                        order_customer_id_TextBox.Text = row.Cells[1].Value.ToString();
                        order_order_date_TextBox.Text = Convert.ToDateTime(row.Cells[2].Value.ToString()).ToString("yyyy/MM/dd");
                        order_total_amount_TextBox.Text = row.Cells[3].Value.ToString();
                        break;
                    case "OrderDetails":
                        order_detail_ID_TextBox.Text = row.Cells[0].Value.ToString();
                        order_detail_order_id_TextBox.Text = row.Cells[1].Value.ToString();
                        order_detail_variant_id_TextBox.Text = row.Cells[2].Value.ToString();
                        order_detail_quantity_TextBox.Text = row.Cells[3].Value.ToString();
                        order_detail_unit_price_TextBox.Text = row.Cells[4].Value.ToString();
                        break;
                    case "Products":
                        product_ID_TextBox.Text = row.Cells[0].Value.ToString();
                        product_collection_ID_TextBox.Text = row.Cells[1].Value.ToString();
                        product_name_TextBox.Text = row.Cells[2].Value.ToString();
                        product_description_TextBox.Text = row.Cells[3].Value.ToString();
                        product_price_TextBox.Text = row.Cells[4].Value.ToString();
                        break;
                    case "Designers":
                        designer_ID_TextBox.Text = row.Cells[0].Value.ToString();
                        designer_full_name_TextBox.Text = row.Cells[1].Value.ToString();
                        designer_country_TextBox.Text = row.Cells[2].Value.ToString();
                        designer_biography_TextBox.Text = row.Cells[3].Value.ToString();
                        break;
                    case "Variants":
                        product_variants_ID_TextBox.Text = row.Cells[0].Value.ToString();
                        product_variants_product_ID_TextBox.Text = row.Cells[1].Value.ToString();
                        product_variants_name_TextBox.Text = row.Cells[2].Value.ToString();
                        product_variants_size_TextBox.Text = row.Cells[3].Value.ToString();
                        product_variants_color_TextBox.Text = row.Cells[4].Value.ToString();
                        product_variants_stock_quantity_TextBox.Text = row.Cells[5].Value.ToString();
                        break;
                }
            }
        }

        private void allTabPages_Selecting(object sender, TabControlCancelEventArgs e)
        {
            tableComboBox.SelectedIndex = ((TabControl)sender as TabControl).SelectedIndex;
        }

        private void clearToolStripButton_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void resetToolStripButton_Click(object sender, EventArgs e) {
            refresh();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void refresh()
        {
            RefreshDataGridView(dataGridView);
            clear();
        }

        /// <summary>
        /// Поиск
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void searchToolStripTextBox_TextChanged(object sender, EventArgs e)
        {
            search();
        }

        private void search()
        {
            try
            {
                dataGridView.Rows.Clear();
                string search_query = "";
                string current_table = tableComboBox.Text;
                string current_search = searchToolStripTextBox.Text.Trim();
                SqlCommand sql_command = new SqlCommand();

                switch (current_table)
                {
                    case "Designers":
                        search_query = $"SELECT * FROM {current_table} WHERE CONCAT ([DesignerID], [FullName], [Country], [Biography]) LIKE @search";
                        break;
                    case "Collections":
                        search_query = $"SELECT * FROM {current_table} WHERE CONCAT ([CollectionID], [DesignerID], [CollectionName], [LaunchDate]) LIKE @search";
                        break;
                    case "Employees":
                        search_query = $"SELECT * FROM {current_table} WHERE CONCAT (EmployeeID, [login], [password], FirstName, SecondName) LIKE @search";
                        break;
                    case "OrderDetails":
                        search_query = $"SELECT * FROM {current_table} WHERE CONCAT (OrderDetailID, OrderID, VariantID, Quantity, UnitPrice) LIKE @search";
                        break;
                    case "Orders":
                        search_query = $"SELECT * FROM {current_table} WHERE CONCAT (OrderID, CustomerName, OrderDate, TotalAmount) LIKE @search";
                        break;
                    case "Products":
                        search_query = $"SELECT * FROM {current_table} WHERE CONCAT (ProductID, CollectionID, ProductName, Description, Price) LIKE @search";
                        break;
                    case "Variants":
                        search_query = $"SELECT * FROM {current_table} WHERE CONCAT (VariantID, ProductID, [VariantName], [Size], [Color], [StockQuantity]) LIKE @search";
                        break;
                }

                sql_command.CommandText = search_query;
                sql_command.Parameters.AddWithValue("@search", "%" + current_search + "%");
                sql_command.Connection = database.get_connection();

                database.open_connection();
                SqlDataReader sql_data_reader = sql_command.ExecuteReader();
                while (sql_data_reader.Read()) ReadSingleRow(dataGridView, sql_data_reader);
                sql_data_reader.Close();
            }
            catch { }
        }

        /// <summary>
        /// Поиск
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void searchToolStripTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '"' || e.KeyChar == '\'')
                searchToolStripTextBox.Text.Replace(e.KeyChar, '8');
        }

        /// <summary>
        /// Переключение таблиц
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tableComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CreateCollumns();
            RefreshDataGridView(dataGridView);
            fieldsTabControl.SelectedTab = fieldsTabControl.TabPages[tableComboBox.SelectedIndex];
        }
    }
}
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace ArchiveFashionStore
{
    public partial class SignInForm : Form
    {
        Database database = new Database();
        private string access_admin_password = "администратор";

        public SignInForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            Font = new Font("Roboto", 12, FontStyle.Regular);
        }

        private void signInButton_Click(object sender, EventArgs e)
        {
            if (passwordTextBox.Text.Length == 0 || loginTextBox.Text.Length == 0 ||
                firstNameTextBox.Text.Length == 0 || lastNameTextBox.Text.Length == 0)
            {
                MessageBox.Show("Пожалуйста заполните все поля!", "Регистрация", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            try
            {
                if (passwordTextBox.Text == repasswordTextBox.Text)
                {
                    if (CheckUser()) return;
                    string query_string = $"INSERT INTO Employees([login], [password], FirstName, SecondName, isAdmin) VALUES('{loginTextBox.Text}', '{md5.GetHashedPassword(passwordTextBox.Text)}', '{firstNameTextBox.Text}', '{lastNameTextBox.Text}', {CheckAdmin()})";
                    SqlCommand sql_command = new SqlCommand(query_string, database.get_connection());
                    database.open_connection();
                    try
                    {
                        if (Convert.ToBoolean(sql_command.ExecuteNonQuery() == 1))
                        {
                            MessageBox.Show("Регистрация прошла успешно!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoginForm login_form = new LoginForm();
                            this.Hide();
                            login_form.ShowDialog();
                        }
                        else MessageBox.Show("Вы не прошли регистрацию!", "Регистрация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message, "Регистрация", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    database.close_connection();
                }
                else MessageBox.Show("Оба пароля должны совпадать!", "Регистрация", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception)
            {
                MessageBox.Show("Что-то пошло не так!", "Регистрация", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int CheckAdmin() { return passwordTextBox.Text == access_admin_password ? 1 : 0; }

        private bool CheckUser()
        {
            string login = loginTextBox.Text;
            string user = passwordTextBox.Text;
            SqlDataAdapter sql_adapter = new SqlDataAdapter();
            DataTable data_table = new DataTable();
            string query_string = $"SELECT EmployeeID, [login], [password], FirstName, SecondName, isAdmin FROM Employees WHERE [login] = '{login}' and [password] = '{user}'";
            SqlCommand sql_command = new SqlCommand(query_string, database.get_connection());
            sql_adapter.SelectCommand = sql_command;
            sql_adapter.Fill(data_table);
            if (data_table.Rows.Count > 0)
            {
                MessageBox.Show("Пользователь уже существует!", "Регистрация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            else return false;
        }

        private void SigninForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoginForm login_form = new LoginForm();
            this.Hide();
            login_form.ShowDialog();
        }

        private void SignInForm_Load(object sender, EventArgs e)
        {
            passwordTextBox.UseSystemPasswordChar = repasswordTextBox.UseSystemPasswordChar = true;
        }
    }
}
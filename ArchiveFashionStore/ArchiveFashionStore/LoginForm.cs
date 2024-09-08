using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace ArchiveFashionStore
{
    public partial class LoginForm : Form
    {
        Database database = new Database();

        public bool ISADMIN;

        public LoginForm()
        {
            InitializeComponent();
            InitializeComponents();
            Font = new Font("Roboto", 12, FontStyle.Regular);
        }

        private void InitializeComponents()
        {
            passwordTextBox.PasswordChar = '*';
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void logInButton_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter data_adapter = new SqlDataAdapter();
                DataTable data_table = new DataTable();
                string query_string = $"SELECT EmployeeID, [login], [password], isAdmin FROM Employees WHERE [login] = '{loginTextBox.Text}' AND [password] = '{md5.GetHashedPassword(passwordTextBox.Text)}'";
                SqlCommand sql_command = new SqlCommand(query_string, database.get_connection());
                data_adapter.SelectCommand = sql_command;
                data_adapter.Fill(data_table);
                if (data_table.Rows.Count == 1)
                {
                    var user = new User(data_table.Rows[0].ItemArray[1].ToString(), Convert.ToBoolean(data_table.Rows[0].ItemArray[3]));
                    MessageBox.Show("Вход выполнен!", "Вход", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MasterForm main_form = new MasterForm(user);
                    this.Hide();
                    main_form.ShowDialog();
                    this.Show();
                }
                else MessageBox.Show("Вход не выполнен!", "Вход", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception)
            {
                MessageBox.Show("Что-то пошло не так!", "Вход", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void signInLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignInForm signin_form = new SignInForm();
            this.Hide();
            signin_form.ShowDialog();
            this.Close();
        }
    }
}

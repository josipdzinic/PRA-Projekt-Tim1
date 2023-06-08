using DAO;
using MainForm.admin;
using MainForm.Login;
using MainForm.user;

namespace MainForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitForm();
        }

        private void InitForm()
        {
            LoginForm loginForm = new LoginForm();
            this.Hide();
            var res = loginForm.ShowDialog();
            User user = new User();

            if (res == DialogResult.OK)
            {
                user = loginForm.user;
                if (user.role.ToString() == "admin")
                {
                    this.Hide();
                    AdminForm admin = new AdminForm();
                    var adminRes = admin.ShowDialog();

                    if (adminRes == DialogResult.OK)
                    {
                        InitForm();
                    }
                }
                else if (user.role.ToString() == "user")
                {
                    UserForm userForm = new UserForm();
                    var userRes = userForm.ShowDialog();

                    if (userRes == DialogResult.OK)
                    {
                        InitForm();
                    }
                }
                this.Dispose();
            }
        }
    }
}
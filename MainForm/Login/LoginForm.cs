using DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainForm.Login
{
    public partial class LoginForm : Form
    {
        private static IRepository repo = new UserRepository();
        public User user;

        public LoginForm()
        {
            InitializeComponent();
            lblError.Text = "";
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            User loginUser = new User
            {
                username = tbUsername.Text,
                password = tbPassword.Text
            };

            user = repo.GetUser(loginUser);

            if (user == null || loginUser==null)
            {
                lblError.Text = "There is no such user!!";
            }
            else
            {
                DialogResult = DialogResult.OK;
            }
        }
    }
}

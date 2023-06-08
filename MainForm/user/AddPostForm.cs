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

namespace MainForm.user
{
    public partial class AddPostForm : Form
    {
        public AddPostForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        public Post getData()
        {
            return new Post
            {
                title = tbTitle.Text,
                descriprion = tbDescription.Text
            };
        }
    }
}

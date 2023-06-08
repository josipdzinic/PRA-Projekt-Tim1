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

namespace MainForm.admin
{
    public partial class LecturerDialogForm : Form
    {
        public LecturerDialogForm()
        {
            InitializeComponent();
        }

        public LecturerDialogForm(Lecturer lecturer)
        {
            InitializeComponent();
            init(lecturer);
            StartPosition = FormStartPosition.CenterScreen;
        }

        public Lecturer getLecturer()
        {
            return new Lecturer
            {
                name = tbName.Text,
                email = tbEmail.Text,
                details = tbDetails.Text
            };
        }

        private void init(Lecturer lecturer)
        {
            tbName.Text = lecturer.name;
            tbEmail.Text = lecturer.email;
            tbDetails.Text = lecturer.details;
        }
    }
}

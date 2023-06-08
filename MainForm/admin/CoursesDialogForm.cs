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
    public partial class CoursesDialogForm : Form
    {
        public CoursesDialogForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }
        
        public CoursesDialogForm(Course course)
        {
            InitializeComponent();
            init(course);
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void init(Course course)
        {
            tbCourse.Text = course.course;
            tbLecturer.Text = course.lecturer;
            tbECTS.Text = course.ects.ToString();
        }

        public Course getCourse()
        {
            return new Course
            {
                course = tbCourse.Text,
                lecturer = tbLecturer.Text,
                ects = int.Parse(tbECTS.Text)
            };
        }
    }
}

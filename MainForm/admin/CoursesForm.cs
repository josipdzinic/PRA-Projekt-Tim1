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
    public partial class CoursesForm : Form
    {
        private Course course;
        private List<Course> courses = new List<Course>();
        private IRepository repo = new UserRepository();

        public CoursesForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            LoadCourses();
        }

        private void LoadCourses()
        {
            courses = repo.GetCourses();

            courses.ForEach(c => AddCourseToTable(c));
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            CoursesDialogForm coursesDialogForm = new CoursesDialogForm();

            var res = coursesDialogForm.ShowDialog();

            if (res == DialogResult.OK)
            {
                course = coursesDialogForm.getCourse();
                AddCourseToTable(course);
                courses.Add(course);
            } 
        }

        private void AddCourseToTable(Course course)
        {
            dgvTable.Rows.Add(course.course, course.lecturer, course.ects);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            SaveCourses();
        }

        private void SaveCourses()
        {
            repo.SaveCourses(courses);
        }

        private DataGridViewRow selectedRow = new DataGridViewRow();
        private Course selectedCourse = new Course();

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            if (dgvTable.SelectedRows.Count > 0)
            {
                selectedRow = dgvTable.SelectedRows[0];

                selectedCourse.course = selectedRow.Cells["Course"].Value.ToString();
                selectedCourse.lecturer = selectedRow.Cells["Lecturer"].Value.ToString();
                selectedCourse.ects = int.Parse(selectedRow.Cells["ECTS"].Value.ToString());
            }
            else
            {
                MessageBox.Show("You have to select row to update!!");
                return;
            }

            CoursesDialogForm coursesDialogForm = new CoursesDialogForm(selectedCourse);

            var res = coursesDialogForm.ShowDialog();

            if (res == DialogResult.OK)
            {
                course = new Course();
                course = coursesDialogForm.getCourse();

                foreach (Course lcourse in courses)
                {
                    if (lcourse.Equals(selectedCourse))
                    {
                        lcourse.course = course.course;
                        lcourse.lecturer = course.lecturer;
                        lcourse.ects = course.ects;
                    }
                }
                UpdateCourseTable();

            }
        }

        private void UpdateCourseTable()
        {
            if (dgvTable.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvTable.SelectedRows[0];

                selectedRow.Cells["Course"].Value = course.course;
                selectedRow.Cells["Lecturer"].Value = course.lecturer;
                selectedRow.Cells["ECTS"].Value = course.ects;

                dgvTable.Refresh();
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            if (dgvTable.SelectedRows.Count > 0)
            {
                selectedRow = dgvTable.SelectedRows[0];

                selectedCourse = new Course();

                selectedCourse.course = selectedRow.Cells["Course"].Value.ToString();
                selectedCourse.lecturer = selectedRow.Cells["Lecturer"].Value.ToString();
                selectedCourse.ects = int.Parse(selectedRow.Cells["ECTS"].Value.ToString());

                dgvTable.Rows.Remove(selectedRow);
                courses.Remove(selectedCourse);

                dgvTable.Refresh();
            }
            else
            {
                MessageBox.Show("You have to select row to update!!");
                return;
            }

        }
    }
}

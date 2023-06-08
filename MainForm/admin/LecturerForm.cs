using DAO;
using Microsoft.VisualBasic.Devices;
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
    public partial class LecturerForm : Form
    {
        private Lecturer lecturer;
        private List<Lecturer> lecturers = new List<Lecturer>();
        private IRepository repo = new UserRepository();

        public LecturerForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            LoadLectures();
        }

        private void LoadLectures()
        {
            lecturers = repo.GetLecturers();
            lecturers.ForEach(l => AddLecturerToTable(l));
        }

        private void AddLecturerToTable(Lecturer l)
        {
            dgvTable.Rows.Add(l.name, l.email, l.details);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            SaveLecturers();
        }

        private void SaveLecturers()
        {
            repo.SaveLectures(lecturers);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            LecturerDialogForm lecturerDialogForm = new LecturerDialogForm();

            var res = lecturerDialogForm.ShowDialog();

            if (res == DialogResult.OK)
            {
                lecturer = lecturerDialogForm.getLecturer();
                AddLecturerToTable(lecturer);
                lecturers.Add(lecturer);
            }
        }

        private DataGridViewRow selectedRow = new DataGridViewRow();
        private Lecturer selectedLecturer = new Lecturer();

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvTable.SelectedRows.Count > 0)
            {
                selectedRow = dgvTable.SelectedRows[0];

                selectedLecturer.name = selectedRow.Cells["Name"].Value.ToString();
                selectedLecturer.email = selectedRow.Cells["Email"].Value.ToString();
                selectedLecturer.details = selectedRow.Cells["Details"].Value.ToString();
            }
            else
            {
                MessageBox.Show("You have to select row to update!!");
                return;
            }

            LecturerDialogForm lecturerDialogForm = new LecturerDialogForm(selectedLecturer);

            var res = lecturerDialogForm.ShowDialog();

            if (res == DialogResult.OK)
            {
                lecturer = new Lecturer();
                lecturer = lecturerDialogForm.getLecturer();

                foreach (Lecturer llecturer in lecturers)
                {
                    if (llecturer.Equals(selectedLecturer))
                    {
                        llecturer.name = lecturer.name;
                        llecturer.email = lecturer.email;
                        llecturer.details = lecturer.details;
                    }
                }
                UpdateLecturerTable();
            }

        }

        private void UpdateLecturerTable()
        {
            if (dgvTable.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvTable.SelectedRows[0];

                selectedRow.Cells["Name"].Value = lecturer.name;
                selectedRow.Cells["Email"].Value = lecturer.email;
                selectedRow.Cells["Details"].Value = lecturer.details;

                dgvTable.Refresh();
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvTable.SelectedRows.Count > 0)
            {
                selectedRow = dgvTable.SelectedRows[0];

                selectedLecturer = new Lecturer();

                selectedLecturer.name = selectedRow.Cells["Name"].Value.ToString();
                selectedLecturer.email = selectedRow.Cells["Email"].Value.ToString();
                selectedLecturer.details = selectedRow.Cells["Details"].Value.ToString();

                dgvTable.Rows.Remove(selectedRow);
                lecturers.Remove(selectedLecturer);

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

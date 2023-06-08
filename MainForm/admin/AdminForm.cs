using DAO;
using MainForm.user;
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
    public partial class AdminForm : Form
    {
        private Post post;
        private List<Post> posts = new List<Post>();
        private static IRepository repo = new UserRepository();

        public AdminForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            LoadPosts();
        }

        private void LoadPosts()
        {
            posts = repo.GetPosts();
            posts.ForEach(p => AddPostToContainer(p));
        }

        private void AddPostToContainer(Post post)
        {
            FlowLayoutPanel flp = new FlowLayoutPanel();
            flp.BorderStyle = BorderStyle.FixedSingle;
            flp.FlowDirection = FlowDirection.LeftToRight;
            flp.Height = 300;
            flp.Width = 250;

            flp.Controls.Add(MakeTitle(post.title));
            flp.Controls.Add(MakeDesc(post.descriprion));

            flpContainer.Controls.Add(flp);
        }

        private Control MakeDesc(string descriprion)
        {
            RichTextBox richTextBox = new RichTextBox();
            richTextBox.Width = 180;
            richTextBox.Height = 220;
            richTextBox.Text = descriprion;
            return richTextBox;
        }

        private Control MakeTitle(string title)
        {
            Label lbl = new Label();
            lbl.Text = title;
            return lbl;
        }

        private void btnAddPost_Click(object sender, EventArgs e)
        {
            AddPost();
        }

        private void AddPost()
        {
            AddPostForm addPostForm = new AddPostForm();
            var res = addPostForm.ShowDialog();

            if (res == DialogResult.OK)
            {
                post = addPostForm.getData();
                posts.Add(post);
                AddPostToContainer(post);
            }
        }

        private void AdminForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SavePosts();
        }

        private void SavePosts()
        {
            repo.SavePost(posts);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            SavePosts();
        }

        private void btnCourses_Click(object sender, EventArgs e)
        {
            DoingCourses();
        }

        private void DoingCourses()
        {
            CoursesForm coursesForm = new CoursesForm();
            var res = coursesForm.ShowDialog();

            if (res == DialogResult.OK)
            {
                return;
            }
        }

        private void btnLecturers_Click(object sender, EventArgs e)
        {
            DoingLecturers();
        }

        private void DoingLecturers()
        {
            LecturerForm lecturerForm = new LecturerForm();
            var res = lecturerForm.ShowDialog();

            if (res == DialogResult.OK)
            {
                return;
            }
        }
    }
}

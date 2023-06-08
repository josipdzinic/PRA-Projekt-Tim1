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
    public partial class UserForm : Form
    {
        private Post post;
        private List<Post> posts = new List<Post>();
        private static IRepository repo = new UserRepository();

        public UserForm()
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

        private RichTextBox MakeDesc(string descriprion)
        {
            RichTextBox richTextBox = new RichTextBox();
            richTextBox.Width = 180;
            richTextBox.Height = 220;
            richTextBox.Text = descriprion;
            return richTextBox;
        }

        private Label MakeTitle(string title)
        {
            Label lbl = new Label();
            lbl.Text = title;
            return lbl;
        }

        private void UserForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SavePosts();
        }

        private void SavePosts()
        {
            repo.SavePost(posts);
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            SavePosts();
        }
    }
}

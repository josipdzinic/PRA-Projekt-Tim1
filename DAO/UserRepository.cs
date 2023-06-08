using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class UserRepository : IRepository
    {
        private const string FILE_USERS = "users.txt";
        private const string FILE_POSTS = "posts.txt";
        private const string FILE_COURSES = "courses.txt";
        private const string FILE_LECTURERS = "lecturers.txt";

        public UserRepository()
        {
            if (!File.Exists(FILE_USERS) || !File.Exists(FILE_POSTS))
            {
                File.Create(FILE_USERS).Close(); 

            }

            if (!File.Exists(FILE_POSTS))
            {
                File.Create(FILE_POSTS).Close();
            }
            
            if (!File.Exists(FILE_COURSES))
            {
                File.Create(FILE_COURSES).Close();
            }

            if (!File.Exists(FILE_LECTURERS))
            {
                File.Create(FILE_LECTURERS).Close();
            }
        }

        public List<Course> GetCourses()
        {
            List<Course> courses = new List<Course>();

            string[] details = File.ReadAllLines(FILE_COURSES);

            foreach (var line in details)
            {
                courses.Add(Course.ParseFromFileLine(line));
            }

            return courses;
        }

        public List<Lecturer> GetLecturers()
        {
            List<Lecturer> lecturers = new List<Lecturer>();
            string[] details = File.ReadAllLines(FILE_LECTURERS);

            foreach (var line in details)
            {
                lecturers.Add(Lecturer.ParseFromFileLine(line));
            }

            return lecturers;
        }

        public List<Post> GetPosts()
        {
            List<Post> posts = new List<Post>();
            string[] details = File.ReadAllLines(FILE_POSTS);
            foreach (var line in details)
            {
                posts.Add(Post.ParseFromFileLine(line));
            }
            return posts;
        }

        public User? GetUser(User user)
        {
            string[] fileUsers = File.ReadAllLines(FILE_USERS);

            List<User> users = new List<User>();

            foreach (var fileUser in fileUsers)
            {
                users.Add(User.ParseFromFileLine(fileUser));
            }

            foreach (User u in users)
            {
                if (u.Equals(user))
                {
                    return u;
                }
            }

            return null;
        }

        public void SaveCourses(List<Course> courses)
        {
            File.WriteAllLines(FILE_COURSES, courses.Select(c => c.FormatForFileLine()));
        }

        public void SaveLectures(List<Lecturer> lecturers)
        {
            File.WriteAllLines(FILE_LECTURERS, lecturers.Select(l => l.FormatForFileLine()));
        }

        public void SavePost(List<Post> posts)
        {
            File.WriteAllLines(FILE_POSTS, posts.Select(p => p.FormatForFileLine()));
        }

        public void SaveUser(User user)
        {
            File.WriteAllText(FILE_USERS, user.FormatForFileLine());
        }
    }
}

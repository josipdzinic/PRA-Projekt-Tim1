using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public interface IRepository
    {
        void SaveUser(User user);
        User? GetUser(User user);
        void SavePost(List<Post> posts);
        List<Post> GetPosts();
        void SaveCourses(List<Course> courses);
        List<Course>GetCourses();
        void SaveLectures(List<Lecturer> lecturers);
        List<Lecturer> GetLecturers();
    }
}

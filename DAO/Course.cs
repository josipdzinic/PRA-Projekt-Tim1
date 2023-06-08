using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class Course
    {
        private const char DEL = '#';

        public string course { get; set; }
        public string lecturer { get; set; }
        public int ects { get; set; }



        public override string ToString() => $"{course}, {lecturer}, {ects}";
        public string FormatForFileLine() => $"{course}{DEL}{lecturer}{DEL}{ects}";

        public static Course ParseFromFileLine(string line)
        {
            string[] details = line.Split(DEL);
            return new Course
            {
                course = details[0],
                lecturer = details[1],
                ects = int.Parse(details[2])
            };
        }

        public override bool Equals(object? obj)
        {
            return obj is Course course &&
                   this.course == course.course &&
                   lecturer == course.lecturer &&
                   ects == course.ects;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(course, lecturer, ects);
        }
    }
}

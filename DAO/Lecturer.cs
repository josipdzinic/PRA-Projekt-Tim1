using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class Lecturer
    {
        private const char DEL = '#';

        public string name { get; set; }
        public string email { get; set; }
        public string details { get; set; }

        public override string ToString() => $"{name}, {email}, {details}";
        public string FormatForFileLine() => $"{name}{DEL}{email}{DEL}{details}";

        public static Lecturer ParseFromFileLine(string line)
        {
            string[] details = line.Split(DEL);

            return new Lecturer
            {
                name = details[0],
                email = details[1],
                details = details[2]
            };
        }

        public override bool Equals(object? obj)
        {
            return obj is Lecturer lecturer &&
                   name == lecturer.name &&
                   email == lecturer.email &&
                   details == lecturer.details;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(name, email, details);
        }
    }
}

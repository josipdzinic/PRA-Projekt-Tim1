using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public enum UserType
    {
        admin,user
    };

    public class User
    {
        private const char DEL = '#';

        public string username { get; set; }
        public string password { get; set; }
        public UserType? role { get; set; }



        public string FormatForFileLine() => $"{username}{DEL}{password}{DEL}{role}";

        public override string ToString() => $"{username} {password} {role}";

        public static User ParseFromFileLine(string line)
        {
            string[] details = line.Split(DEL);
            return new User
            {
                username = details[0],
                password = details[1],
                role = (UserType)Enum.Parse(typeof(UserType), details[2])
            };
        }

        public override bool Equals(object? obj)
        {
            return obj is User user &&
                   username == user.username &&
                   password == user.password;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(username, password);
        }
    }
}

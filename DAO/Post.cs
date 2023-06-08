using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class Post
    {
        private const char DEL = '#';
        public string title { get; set; }
        public string descriprion { get; set; }

        public string FormatForFileLine() => $"{title}{DEL}{descriprion}";

        public override string ToString() => $"{title} {descriprion}";

        public static Post ParseFromFileLine(string line)
        {
            string[] details = line.Split(DEL);
            return new Post
            {
                title = details[0],
                descriprion = details[1],
            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace PedroPinturas.Models
{
    public class Color
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public Color() {

        }

        public Color(string name, string code)
        {
            Id = 0;
            Name = name;
            Code = code;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace PedroPinturas.Models
{
    public class Color
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public Color() {

        }

        public Color(string name, string code)
        {
            Id = name;
            Name = name;
            Code = code;
        }
    }
}

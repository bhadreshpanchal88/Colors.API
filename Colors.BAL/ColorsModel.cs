using System;
using System.Collections.Generic;

namespace Colors.BAL
{
    public class ColorsModel
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string Type { get; set; }
        public Code Code { get; set; }

    }
    public class Code
    {
        public List<int> RGBA { get; set; }
        public string Hex { get; set; }

    }

}



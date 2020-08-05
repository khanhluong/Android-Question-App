using System;
using System.Collections.Generic;

namespace Common.Model
{
    public class Datas
    {
        public string modhash { get; set; }
        public int dist { get; set; }
        public List<Child> children { get; set; }
        public string after { get; set; }
        public object before { get; set; }
    }
}

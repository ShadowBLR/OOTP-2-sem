using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOTPLab11
{
    class Score
    {
        public string ScoreName { get; set; }
        public string ProductName { get; set; }
        public int Count { get; set; }
        public Score() { }
        public Score(string _sname,string _pname,int _count) 
        {
            ScoreName = _sname;
            ProductName = _pname;
            Count = _count;
        }
    }
}

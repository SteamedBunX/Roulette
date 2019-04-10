using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette
{
    public class Model
    {
        public string Number { get; set; }
        public NumberSet Color { get; set; }
        public bool IsZeroSet { get; set; }
        public NumberSet OddEven { get; set; }
        public NumberSet LowHigh { get; set; }
        public NumberSet Dozen { get; set; }
        public NumberSet Column { get; set; }
        public int Street { get; set; }
        public List<List<int>> Six_Numbers { get; set; }
        public List<List<int>> Split { get; set; }
        public List<List<int>> Corner { get; set; }
    }
}

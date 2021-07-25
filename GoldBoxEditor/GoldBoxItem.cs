using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBoxEditor
{
    public class GoldBoxItem
    {
        public string BaseType { get; set; }
        public byte BaseTypeByte { get; set; }
        public string Name { get; set; }
        public byte NameByte1 { get; set; }
        public byte NameByte2 { get; set; }
        public byte NameByte3 { get; set; }
        public byte Bonus { get; set; }
        public byte SaveBonus { get; set; }
        public byte Readied { get; set; } // 0 = no, 1 = yes
        public byte UnidentifiedNameBits { get; set; }
        public short Weight { get; set; }
        public short Value { get; set; }
        public byte SpecialByte1 { get; set; } // Potion and wand charges or scroll spell
        public byte SpecialByte2 { get; set; } // Potion and wand effect or scroll spell
        public byte SpecialByte3 { get; set; } // Scroll spell
    }
}

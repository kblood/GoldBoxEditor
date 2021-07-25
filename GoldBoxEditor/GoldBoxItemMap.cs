using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBoxEditor
{
    public class GoldBoxItemMap
    {
        public GoldBoxItemMap()
        {
        }

        public GoldBoxItemMap(string itemName)
        {
            ItemName = itemName;
            ItemEffects = new List<string>();
            GameItemcodePairs = new Dictionary<string, string>();
            GameItembytesPairs = new Dictionary<string, byte[]>();
        }

        public string ItemName { get; set; }

        public int ItemStat { get; set; }

        public List<string> ItemEffects { get; set; }

        public Dictionary<string, byte[]> GameItembytesPairs { get; set; }
        public Dictionary<string, string> GameItemcodePairs { get; set; }
    }
}

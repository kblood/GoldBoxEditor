using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBoxEditor
{
    public class GoldBoxData
    {
        public List<string> Systems { get; set; }
        public List<string> Games { get; set; }
        public List<GoldBoxEffectMap> EffectMaps { get; set; }
        public List<GoldBoxItemMap> ItemMaps { get; set; }
        public Dictionary<string, GoldBoxSaveMap> GameSaveMaps { get; set; }
    }
}

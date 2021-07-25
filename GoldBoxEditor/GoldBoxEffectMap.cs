using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBoxEditor
{
    public class GoldBoxEffectMap
    {
        public GoldBoxEffectMap()
        {
            GameEffectcodePairs = new Dictionary<string, string>();
            GameEffectbytesPairs = new Dictionary<string, byte[]>();
        }

        public GoldBoxEffectMap(string effectName)
        {
            EffectName = effectName;
            GameEffectcodePairs = new Dictionary<string, string>();
        }

        public string EffectName { get; set; }
        public Dictionary<string, byte[]> GameEffectbytesPairs { get; set; }
        public Dictionary<string, string> GameEffectcodePairs { get; set; }

    }
}

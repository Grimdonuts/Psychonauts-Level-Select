using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelSelect.Model
{
    public class LevelSelectModel
    {
        public static Dictionary<string, string> Levels = new Dictionary<string, string> {
            { "BBA1", "Basic Braining 1" } , { "BBA2", "Basic Braining 2" } , { "BBLT", "Basic Braining Finale" }, { "sacu", "Sasha's Shooting Gallery" },
            { "nimp", "Brain Tumbler Experiment Woods" } , { "niba", "Brain Tank" } , { "aslb", "Brain Tank Final" }, { "mifl", "Milla's Lounge" },
            { "mimm", "Milla's Race" } , { "mill", "Milla's Fan Room" } , { "loma", "Lungfishopolis" },{ "locb", "Lungfish Kochamara" }, { "bvwc", "Cobra" },
            { "bvwd", "Dragon" } , { "bvwe", "Eagle" } , { "bvwt", "Tiger" }, { "bves", "Edgar's Sanctuary" },
            { "bvma", "Edgar Matadors Arena" } , { "bvrb", "Edgar Running Against the Bull" } ,
            { "mmi1", "Milkman Neighborhood 1" } , { "mmi2", "Milkman Neighborhood 2" } , { "mmdm", "Den Mother" },
            { "wwma", "Waterloo World" } , { "thms", "Glorias Theater The Stage" } , { "thcw", "Gloria Catwalks" },
            { "thfb", "Gloria Theater Confrontation" } , { "mctc", "Meat Circus Caravan" } , { "mcbb", "Meat Circus Bosses" },
            { "CAKC", "Kids Cabins (day)" } ,  { "CAKC_night", "Kids Cabins (night)" } , { "cali", "Inside Lodge (day)" },
            { "cali_night", "Inside Lodge (night)" } , { "cabh", "Lake (day)" }, { "cabh_night", "Lake (night)" },
            { "cagp", "GPC & Wilderness (day)" } , { "cagp_night", "GPC & Wilderness (night)" } , { "casa", "Sasha's Lab" }, { "caja", "Ford's Sanctuary" },
            { "cama", "Main Lodge (day)" } , { "cama_night", "Main Lodge (night)" } , { "care", "Reception Area (day)" }, { "care_night", "Reception Area (night)" },
            { "asgr", "Asylum Grounds" } , { "asco", "Asylum Lower Floors" } , { "asru", "Asylum Lab of Dr. Loboto" }, { "asup", "Asylum Upper Floors" }
        };

        public List<string> LevelHotkeys { get; set; }
        public List<string> HotkeyedLevels { get; set; }

        public string fileName { get; set; }
        public string filePath { get; set; }

        public enum KeyDefinitions
        {
            F1 = 112,
            F2 = 113,
            F3 = 114,
            F4 = 115,
            F5 = 116,
            F6 = 117,
            F7 = 118,
            F8 = 119,
            F9 = 120,
            F10 = 121,
            F11 = 122,
            F12 = 123,
            a = 65,
            b = 66,
            c = 67,
            d = 68,
            e = 69,
            f = 70,
            g = 71,
            h = 72,
            i = 73,
            j = 74,
            k = 75,
            l = 76,
            m = 77,
            n = 78,
            o = 79,
            p = 80,
            q = 81,
            r = 82,
            s = 83,
            t = 84,
            u = 85,
            v = 86,
            w = 87,
            x = 88,
            y = 89,
            z = 90,
            D1 = 49,
            D2 = 50,
            D3 = 51,
            D4 = 52,
            D5 = 53,
            D6 = 54,
            D7 = 55,
            D8 = 56,
            D9 = 57,
            D0 = 48
        }

    }
}

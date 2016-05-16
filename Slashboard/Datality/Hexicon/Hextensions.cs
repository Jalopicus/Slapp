using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;

namespace Datality.Hexicon {
    /// <summary>
    /// Extensions for HexaGraham classes
    /// </summary>
    public static class Hextensions {
        public static string Banish(this string thus, string find) {
            var ret = Regex.Replace(thus, find, "");
            return ret;
        }
        public static void DumpToDebug<T>(this T thus) where T : class, IDumpable {
            var props = thus.GetType().GetProperties();
            var builder = props.Aggregate("", (current, p) => current + (p.GetValue(thus) + "    "));
            Debug.WriteLine(builder);
        }
    }
}

using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using Datality.Smashley;
namespace Datality.Hexicon {
    /// <summary>
    /// Extensions for HexaGraham classes
    /// </summary>
    public static class Hextensions {
        public static string Banish(this string thus, string find) {
            var ret = Regex.Replace(thus, find, "");
            return ret;
        }
        public static void DumpToDebug<T>(this T thus) where T : class, IVoyeur {
            var props = thus.GetType().GetProperties();
            var builder = "";
            foreach (var prop in props)
                try {
                    builder = builder + (prop?.GetValue(thus) + "    ");
                }
                catch {
                    builder = builder + prop?.Name + " crapped out.   ";
                }
            Debug.WriteLine(builder);
        }
    }
}

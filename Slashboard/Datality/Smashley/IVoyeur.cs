namespace Datality.Smashley {
    /// <summary>
    /// Object has a number and string designated to represent it in a list control
    /// <seealso cref="Smashley.Thing"/>
    /// </summary>
    public interface IVoyeur {
        Thing Thing { get; }
    }
    /// <summary>
    /// The minimum information to reliably recognize an object.
    /// Populates mobs for list-based controls
    /// </summary>
    public class Thing {
        /// <summary>
        /// Lone constructor
        /// </summary>
        /// <param name="num">Usually an Id or Primary Key</param>
        /// <param name="txt">Usually a name or text content</param>
        public Thing(int num, string txt) {
            Number = num;
            Text = txt;
        }
        public int Number { get; set; }
        public string Text { get; set; }
        public static implicit operator int(Thing thing) {
            return thing.Number;
        }
        public static implicit operator string(Thing thing) {
            return thing.Text;
        }
    }
}

using System;
using System.Collections.ObjectModel;
using Datality.Smashley;
namespace Datality.Overlords {
    /// <summary>
    /// Requirements for serving an overlord. IOps mandates that Ops have a minion who carries an entity object, a representation of that object, and an inventory of retrievable loot.
    /// </summary>
    /// <typeparam name="T">Exhibitionist entity type</typeparam>
    public interface IOps<T> where T : class, IVoyeur, new() {
        Minion<T> Minion { get; set; }
        int FocusIndex { get; set; }
       // ObservableCollection<Thing> Inventory { get; }
        void Deploy(int assignment);
    }
    /// <summary>
    /// A page that employs an Overlord must implement IOverlord
    /// </summary>
    public interface IOverlord : IDisposable {

    }
}

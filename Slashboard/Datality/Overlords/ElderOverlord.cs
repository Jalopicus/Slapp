using System.ComponentModel;
using Datality.Properties;
using Datality.Smashley;
using PropertyChanged;

namespace Datality.Overlords {
    [ImplementPropertyChanged]
    public class MainOverlord : IOverlord {
        public MainOverlord() {
            ProOps.FocusIndex = Settings.Default.LastPro;
  }
        public event PropertyChangedEventHandler LootSwap;
        public Ops<Pro> ProOps { get; set; } = new Ops<Pro> ();
        public void Dispose() {
            Settings.Default["LastPro"] = ProOps.FocusIndex;
            Settings.Default.Save();
        }
    }
    public class ElderOverlord<T> : IOverlord where T : class, IVoyeur, new()  {
        public ElderOverlord() {
            try {
                Ops.FocusIndex = (int) Settings.Default["Last" + typeof (T).Name];
            }
            catch {
                var existingProperty = Settings.Default.Properties["LastPro"];
                var prop = new System.Configuration.SettingsProperty("Last" + typeof (T).Name);
                Settings.Default.Properties.Add(prop);
            }

        }
        public event PropertyChangedEventHandler LootSwap;
        public Ops<T> Ops { get; set; } = new Ops<T>();
        public void Dispose() {
            Settings.Default["Last" + typeof(T).Name] = Ops.FocusIndex;
            Settings.Default.Save();
        }
    }
}

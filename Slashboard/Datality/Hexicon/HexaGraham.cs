using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Datality.Hexicon.enums;
using Datality.Smashley;
namespace Datality.Hexicon {
    public class HexaGraham : DbContext {
        public DbSet<Hazard> Hazards { get; set; }
        public DbSet<CounterHazard> CounterHazards { get; set; }
        public HexaGraham() : base("name=Hexicon") {
            Hazards = Set<Hazard>();
            CounterHazards = Set<CounterHazard>();
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<HexaGraham>());
            this.Configuration.LazyLoadingEnabled = true;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Entity<Hazard>().HasMany<CounterHazard>(a => a.Counters).WithMany(b => b.Hazzes).Map(mp => {
                mp.MapLeftKey("HazKey");
                mp.MapRightKey("CounterKey");
                mp.ToTable("HazCounterHaz");
            });
            base.OnModelCreating(modelBuilder);
        }
    }
    public class Hazard : IStalker, IVoyeur {
        [Key]
        public int Key { get; set; }
        /// <summary>
        /// 6-digit ID for the 3 levels of hierarchy
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// United Nations H-codes
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// Hierarchy level 2, class of hazard
        /// </summary>
        public string Class { get; set; }
        /// <summary>
        /// Language-defining categorization
        /// </summary>
        public string Category { get; set; }

        public Pictogram Pictogram { get; set; }
        public SignalWord SignalWord { get; set; }
        public string Statement { get; set; }
        [InverseProperty("Hazzes")]
        public virtual ICollection<CounterHazard> Counters { get; set; }

        public virtual Thing Thing => new Thing(this.Id, this.Class + this.Category);
    }
    public class CounterHazard : IStalker, IVoyeur {
        [Key]
        public int Key { get; set; }
        /// <summary>
        /// Database identity
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// P-code provided by the United Nations
        /// </summary>
        public string Code { get; set; }
        public Subtype Subtype { get; set; }
        public string Statement { get; set; }
        public int Sort { get; set; } = 0;
        public virtual ICollection<CounterHazard> Overrides { get; set; }
        [InverseProperty("Counters")]
        public virtual ICollection<Hazard> Hazzes { get; set; }

        public virtual Thing Thing => new Thing(this.Id, this.Statement);
    }
    namespace enums {
        public enum SignalWord {
            None,
            Warning,
            Danger
        }
        public enum Pictogram {
            None,
            Bomb,
            BombandFlame,
            Corrosion,
            Environment,
            Exclamation,
            Flame,
            Flameovercircle,
            Gascylinder,
            HealthHazard,
            Skull
        }
        public enum Subtype {
            General = 1,
            Prevention = 2,
            Response = 3,
            Storage = 4,
            Disposal = 5,
            Additional = 6
        }
    }
}
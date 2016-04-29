using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using Datality.ComplexTypes;

using PropertyChanged;

namespace Datality {
    using ComplexTypes;
    /// <summary>
    /// Data model
    /// </summary>
    public sealed partial class AshleyGraham : DbContext {
        // Your context has been configured to use a 'AshleyGraham' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Datality.AshleyGraham' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'AshleyGraham' 
        // connection string in the application configuration file.
        public AshleyGraham() : base("name=AshleyGraham") {
            //Wipes database if model changes, suppresses errors nobody asks for
            Pros = Set<Pro>();
            Raws = Set<Raw>();
            Blends = Set<Blend>();
            Brands = Set<Brand>();
            Toxicities = Set<Toxicity>();
            SpecSets = Set<SpecSet>();
            Safeties = Set<Safety>();
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<AshleyGraham>());
            //Lazy loading is messing me all up
            this.Configuration.LazyLoadingEnabled = true;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Entity<Blend>().HasMany<Toxicity>(t => t.Toxicities).WithMany(b => b.Blends).Map(mp => {
                mp.MapLeftKey("BlendId");
                mp.MapRightKey("ToxId");
                mp.ToTable("BlendTox");
            });
            modelBuilder.Entity<Raw>().HasMany<Toxicity>(t => t.Toxicities).WithMany(r => r.Raws).Map(mp => {
                mp.MapLeftKey("RawId");
                mp.MapRightKey("ToxId");
                mp.ToTable("RawTox");
            });
            base.OnModelCreating(modelBuilder);
        }
        protected override void Dispose(bool disposing) {
            //var fm = Formulinoes.Where(x => x.BlendId == null);
            //foreach (var f in fm) {
            //    Entry(f).State = EntityState.Deleted;
            //}
            //SaveChanges();
            base.Dispose(disposing);
        }
        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.
        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public DbSet<Pro> Pros { get; set; }
        public DbSet<Raw> Raws { get; set; }
        public DbSet<Formulino> Formulinoes { get; set; }
        public DbSet<Blend> Blends { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Toxicity> Toxicities { get; set; }
        public DbSet<SpecSet> SpecSets { get; set; }
        public DbSet<Safety> Safeties { get; set; }
    }
    /// <summary>
    /// Tables/sets will inherit this base class
    /// 
    /// </summary>
    [ImplementPropertyChanged]
    public abstract class Bass {
        //protected Bass() {
        //     Created = DateTime.Now;
        // }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        //public DateTime? Created { get; set; }
        //public DateTime? Modified { get; set; }
        public string Note { get; set; }
    }
    [ImplementPropertyChanged]
    public abstract class Chemical : Bass {
        [Index(IsUnique = true)]
        [StringLength(450)]
        public string Name { get; set; }
        public virtual Reggo Reg { get; set; }
        public virtual ICollection<Toxicity> Toxicities { get; set; }
    }
    /// <summary>
    /// Raw material
    /// </summary>
    [ImplementPropertyChanged]
    public class Raw : Chemical { 
        public string StockConcentration { get; set; }
        //[Index(IsUnique = true)]
        //[StringLength(450)]
        public string Cas { get; set; }
        [InverseProperty("Raw")]
        public virtual ICollection<Formulino> Formulinoes { get; set; }
      //  public virtual ICollection<Toxicity> Toxicities { get; set; }
    }
    /// <summary>
    /// Combination of raw materials
    /// </summary>
    [ImplementPropertyChanged]
    public class Blend : Chemical {
        public SpecSet SpecSet { get; set; }
        public virtual Safety Safety { get; set; }
        //public Transport Transport { get; set; }
        [InverseProperty("Blend")]
        public virtual ICollection<Pro> Pros { get; set; }
        [InverseProperty("Blend")]
        public virtual ICollection<Formulino> Formulinoes { get; set; }
        //[InverseProperty("Blends")]
        //public virtual ICollection<Toxicity> Toxicities { get; set; }
    }
    [ImplementPropertyChanged]
    public class Formulino : Bass {
        public float Low { get; set; }
        public float High { get; set; }
        public float Actual { get; set; }
        public string Range { get; set; }
        [ForeignKey("BlendId")]
        public virtual Blend Blend { get; set; }
        [Index("BlendRaw", 1, IsUnique = true)]
        public virtual int? BlendId { get; set; }
        [ForeignKey("RawId")]
        public virtual Raw Raw { get; set; }
        [Index("BlendRaw", 2, IsUnique = true)]
        public int? RawId { get; set; }
    }
    /// <summary>
    /// Aliasing and branding of a blend
    /// </summary>
    [ImplementPropertyChanged]
    public class Pro : Bass {
        [Index(IsUnique = true)]
        [StringLength(450)]
        public string Name { get; set; }
        public string Class { get; set; }
        public string Description { get; set; }
        //public DateTime? IssueDate { get; set; }
        //public DateTime? RevisionDate { get; set; }
        public int? Version { get; set; }
        [ForeignKey("BlendId")]
        public virtual Blend Blend { get; set; }
        public int? BlendId { get; set; }
        [ForeignKey("BrandId")]
        public virtual Brand Brand { get; set; }
        public int? BrandId { get; set; }
    }
    [ImplementPropertyChanged]
    public class SpecSet : Bass {
        //
    }
    [ImplementPropertyChanged]
    public class Safety : Bass {
        //Stree
    }
    [ImplementPropertyChanged]
    public class BulletinText {
        //?
    }
    /// <summary>
    /// Toxicity entities
    /// </summary>
    [ImplementPropertyChanged]
    public class Toxicity : Bass {
        public int? SubSort { get; set; } = 0;
        public int? SpecimenType { get; set; } = 0;
        public string TestConcentration { get; set; }
        public string Test { get; set; }
        public string Result { get; set; }
        public string Source { get; set; }
        public int? RawId { get; set; }
        public int? BlendId { get; set; }
        //[InverseProperty("Toxicities")]
        public virtual ICollection<Raw> Raws { get; set; }
        //[InverseProperty("Toxicities")]
        public virtual ICollection<Blend> Blends { get; set; }
    }
    [ImplementPropertyChanged]
    public class Brand : Bass {
        [Index(IsUnique = true)]
        [StringLength(450)]
        public string Name { get; set; }
        public string FullName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Website { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public string EmergencyContact { get; set; }
        public int? Heading1Bg { get; set; }
        public int? Heading1Fg { get; set; }
        public int? Heading1Ol { get; set; }
        [InverseProperty("Brand")]
        public virtual ICollection<Pro> Pros { get; set; }
    }
    /// <summary>
    /// Regulation lists 
    /// </summary>
    [ImplementPropertyChanged]
    public class Reggo : Bass {
        public long Cercla { get; set; }
        public string Epa { get; set; }
        public bool Nsf { get; set; } = false;
        public bool Kosher { get; set; } = false;
        public bool Fda { get; set; } = false;
        public Sara Sara { get; set; }
        public LegacyRatings LegacyRatings { get; set; }
    }
}

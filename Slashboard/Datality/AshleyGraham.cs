using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Datality.ComplexTypes;
using PropertyChanged;



namespace Datality {
    using ComplexTypes;
    using System.Linq.Expressions;

    /// <summary>
    /// Data model
    /// </summary>
    public sealed class AshleyGraham : DbContext {
        // Your context has been configured to use a 'AshleyGraham' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Datality.AshleyGraham' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'AshleyGraham' 
        // connection string in the application configuration file.
        public AshleyGraham() : base("name=AshleyGraham") {
            Pros = Set<Pro>();
            Raws = Set<Raw>();
            Blends = Set<Blend>();
            Brands = Set<Brand>();
            Toxicities = Set<Toxicity>();
            SpecSets = Set<SpecSet>();
            Safeties = Set<Safety>();
            //Wipes database if model changes, suppresses errors nobody asks for
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<AshleyGraham>());
            //Lazy loading is messing me all up
            this.Configuration.LazyLoadingEnabled = false;
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.
        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public DbSet<Pro> Pros { get; set; }
        public DbSet<Raw> Raws { get; set; }
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
        public bool Dust { get; set; } = false;
        public string Note { get; set; }
    

    }

    [ImplementPropertyChanged]
    public abstract class Chemical : Bass {
        public string Name { get; set; }
        public virtual Reggo Reg { get; set; }
        public virtual ICollection<Toxicity> Toxicities { get; set; } = new HashSet<Toxicity>();
    }

    /// <summary>
    /// Raw material
    /// </summary>
    [ImplementPropertyChanged]
    public class Raw : Chemical {
        public string StockConcentration { get; set; }
        public string Cas { get; set; }
    }

    /// <summary>
    /// Combination of raw materials
    /// </summary>
    [ImplementPropertyChanged]
    public class Blend : Chemical {
        public SpecSet SpecSet { get; set; }
        public virtual Safety Safety { get; set; }
        //public Transport Transport { get; set; }
        public virtual ICollection<Pro> Pros { get; set; } = new HashSet<Pro>();
        public virtual ICollection<Formulino> Formulinos { get; set; } = new HashSet<Formulino>();
    }

    [ImplementPropertyChanged]
    public class Formulino : Bass {
        public float Low { get; set; } = 0;
        public float High { get; set; } = 100;
        public float Actual { get; set; } = 0;
        public string Range { get; set; } = "0-100";
        public virtual Raw Raw { get; set; }
    }

    /// <summary>
    /// Aliasing and branding of a blend
    /// </summary>
    [ImplementPropertyChanged]
    public class Pro : Bass {
        public string Name { get; set; }
        public string Class { get; set; }
        public string Description { get; set; }
        //public DateTime? IssueDate { get; set; }
        //public DateTime? RevisionDate { get; set; }
        public int Version { get; set; }
        public virtual Blend Blend { get; set; }
        public virtual Brand Brand { get; set; }
    }

    [ImplementPropertyChanged]
    public class SpecSet : Bass {
        //
    }

    [ImplementPropertyChanged]
    public class Safety : Bass {
        //
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
        public int Type { get; set; }
        public string Test { get; set; }
        public string Result { get; set; }
        public string Source { get; set; }
    }

    [ImplementPropertyChanged]
    public class Brand : Bass {
        public string Name { get; set; }
        public string FullName { get; set; }
        public StreetAddress StreetAddress { get; set; }
        public string WebSite { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
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

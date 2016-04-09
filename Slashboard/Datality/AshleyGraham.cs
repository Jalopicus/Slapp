using System;
using System.Data.Entity;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Datality {
    public sealed class AshleyGraham : DbContext {
        // Your context has been configured to use a 'AshleyGraham' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Datality.AshleyGraham' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'AshleyGraham' 
        // connection string in the application configuration file.
        public AshleyGraham(): base("name=AshleyGraham") {
            Pros = Set<Pro>();
            Raws = Set<Raw>();
            Blends = Set<Blend>();
            Brands = Set<Brand>();
            Toxicities = Set<Toxicity>();
            SpecSets = Set<SpecSet>();
            Safeties = Set<Safety>();
            //    var dbug = this.Configuration;
                Database.SetInitializer(new DropCreateDatabaseIfModelChanges<AshleyGraham>());
        }
      //  protected override void OnModelCreating(DbModelBuilder modelBuilder) {
//            base.OnModelCreating(modelBuilder);
//            modelBuilder.Entity<Blend>().Map(m => {
 //               m.MapInheritedProperties();
  //              m.ToTable("Blends");
   //         });
     //   }
        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.
        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        internal DbSet<Pro> Pros { get; set; }
        internal DbSet<Raw> Raws { get; set; }
        internal DbSet<Blend> Blends { get; set; }
        internal DbSet<Brand> Brands { get; set; }
        internal DbSet<Toxicity> Toxicities { get; set; }
        internal DbSet<SpecSet> SpecSets { get; set; }
        internal DbSet<Safety> Safeties { get; set; }
    }
    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
    /// <summary>
    /// Tables/sets will inherit this base class
    /// </summary>
  
    public abstract class Bass : INotifyPropertyChanged {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        protected string Note { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPc(string propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    #region Chemical Entities
    /// <summary>
    /// Chemical base
    /// </summary>
  
    public abstract class Chemical : Bass {
   //     protected Chemical() {
   //         this.Toxicities = new HashSet<Toxicity>();
   //     }
       // public string Name { get { return _name; } set { _name = value; OnPc("Name"); } }
     //   private string _name;
     public string Name { get; set; }
        public virtual Reggo Reg { get; set; }
        public virtual ICollection<Toxicity> Toxicities { get; set; }
    }
    /// <summary>
    /// Raw material
    /// </summary>
    public class Raw : Bass {

        // public string StockConcentration { get { return _stockConcentration; } set { _stockConcentration = value; OnPc("StockConcentration"); } }
        // private string _stockConcentration = null;
        // public string Cas { get { return _cas; } set { _cas = value; OnPc("Cas"); } }
        // private string _cas = null;
        //   public string Name { get { return _name; } set { _name = value; OnPc("Name"); } }
        //  private string _name;
        public string Name { get; set; }
        public virtual Reggo Reg { get; set; }
        public virtual ICollection<Toxicity> Toxicities { get; set; } = new HashSet<Toxicity>();
        public string StockConcentration { get; set; }
        public string Cas { get; set; }
    }
    /// <summary>
    /// Combination of raw materials
    /// </summary>
    public class Blend : Chemical {
        public SpecSet SpecSet { get; set; }
     //   public virtual Safety Safety { get; set; }
   //     public virtual Transport Transport { get; set; }
        public virtual ICollection<Pro> Products { get; set; } = new HashSet<Pro>();
        public virtual ICollection<Formulino> Formulinos { get; set; } = new HashSet<Formulino>();
    }
    /// <summary>
    /// Aliasing and branding of a blend
    /// </summary>
    public class Pro : Bass {
        public string Name { get; set; }
        public string Class { get { return _class; } set { _class = value; OnPc("Class"); } }
        private string _class;
        public string Description { get { return _description; } set { _description = value; OnPc("Description"); } }
        private string _description;
        public DateTime IssueDate { get; set; }
        public DateTime RevisionDate { get; set; }
        public int Version { get; set; }
        //public virtual Blend Blend { get; set; }
        public virtual Brand Brand { get; set; }
    }
    #endregion
    #region Documentation
    public class SpecSet : Bass {
        //
    }
    public class Safety : Bass {
        //
    }
    public class BulletinText {
        //?
    }
    /// <summary>
    /// Toxicity entities
    /// </summary>
    public class Toxicity : Bass {
        public int Type { get; set; }
        public string Test { get { return _test; } set { _test = value; OnPc("Test"); } }
        private string _test;
        public string Result { get { return _result; } set { _result = value; OnPc("Result"); } }
        private string _result;
        public string Source { get { return _source; } set { _source = value; OnPc("Source"); } }
        private string _source;
    }
    #endregion
    #region Branding
    public class Brand : Bass {
        public string Name { get; set; }
        public string FullName { get; set; }
        public StreetAddress StreetAddress { get; set; }
        public string WebSite { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
    }
    #endregion
    #region Regulatory
    /// <summary>
    /// Regulation lists 
    /// </summary>
    public class Reggo : Bass {
        public long Cercla { get { return _cercla; } set { _cercla = value; OnPc("Cercla"); } }
        private long _cercla;
        public string Epa { get { return _epa; } set { _epa = value; OnPc("Epa"); } }
        private string _epa;
        public bool Nsf { get { return _nsf; } set { _nsf = value; OnPc("Nsf"); } }
        private bool _nsf = false;
        public bool Kosher { get { return _kosher; } set { _kosher = value; OnPc("Kosher"); } }
        private bool _kosher = false;
        public bool Fda { get { return _fda; } set { _fda = value; OnPc("Fda"); } }
        private bool _fda = false;
        public Sara Sara { get; set; }
        public LegacyRatings LegacyRatings { get; set; }
    }
    #endregion
    #region Bums

    public class Transport : Bass {
        public bool Hazardous { get; set; } = true;
        public string Un { get; set; }
        public string Psn { get; set; }
        public string ContainsField { get; set; }
        public string Primary { get; set; }
        public string Secondary { get; set; }
        public string PackingGroup { get; set; }
        public string Type { get; set; } //(air, dot, etc)
    }
    [ComplexType]
    public class Sara {
        public bool Acute { get; set; } = false;
        public bool Chronic { get; set; } = false;
        public bool Fire { get; set; } = false;
        public bool Pressure { get; set; } = false;
        public bool Reactivity { get; set; } = false;
        public Sara313 Sara313 { get; set; }
    }
 
    public class LegacyRatings {
        public LegacyRating Hmis { get; set; } = new LegacyRating();
        public LegacyRating Nfpa { get; set; } = new LegacyRating();
        public LegacyRating Whims { get; set; } = new LegacyRating();
    }
    [ComplexType]
    public class LegacyRating {
        public int H { get; set; } = 0;
        public int F { get; set; } = 0;
        public int R { get; set; } = 0;
        public string Sp { get; set; } = null;
    }

    public class Formulino : Bass {
        public float Low { get; set; } = 0;
        public float High { get; set; } = 100;
        public float Actual { get; set; } = 0;
        public string Range { get; set; } = "0-100";
        public virtual Raw Raw  { get; set; }
    }
    [ComplexType]
    public class StreetAddress {
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
    }
    [ComplexType]
    public class Sara313 {
        private bool Listed { get; set; } = false;
        public long Tpq { get; set; }
        public long Rq { get; set; }
    }
}
#endregion
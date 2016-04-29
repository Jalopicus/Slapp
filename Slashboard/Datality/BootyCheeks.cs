using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datality {
    public static class BootyCheeks {
        public static bool IsAlreadyFormulated(this Blend b, Raw r) {
            return b.Formulinoes.Any(x => x.RawId == r.Id);
        }
        public static Formulino Formulate(this Blend b, Raw r, float low = -1, float high = -1, float actual =-1) {
            if (b.IsAlreadyFormulated(r)) return null;
            return new Formulino {
                Blend = b, BlendId = b.Id, Raw = r, RawId = r.Id,
                Low = low, High = high, Actual = actual };
         }
        public static void DeFormulate(this Formulino f) {
            if (f == null) return;
            f.BlendId = null;
            
        }
        public static void IsCloneOf(this Pro p, Blend b) {
            if (p == null | b == null) return;
            p.BlendId = b.Id;
            p.Blend = b;
        }
        public static void IsChangelingTo(this Blend b, Pro p) {
            if (p == null | b == null) return;
            p.BlendId = b.Id;
            p.Blend = b;
        }
        public static void Rawling(this Formulino f, Raw r) {
            if (r == null) return;
            f.RawId = r.Id;
            f.Raw = r;
        }
        public static void Modded(this DbEntityEntry e) {
            e.State = System.Data.Entity.EntityState.Modified;
        }
        public static void IsBrandedBy(this Pro p, Brand b) {
            if (b == null) return;
            p.Brand = b;
            p.BrandId = b.Id;
        }
        public static void IsBrandOf(this Brand b, Pro p) {
            if (p == null) return;
            p.Brand = b;
            p.BrandId = b.Id;
        }
    }
    public partial class AshleyGraham {
        //Pros = Set<Pro>();
        //    Raws = Set<Raw>();
        //    Blends = Set<Blend>();
        //    Brands = Set<Brand>();
        //    Toxicities = Set<Toxicity>();
        //    SpecSets = Set<SpecSet>();
        //    Safeties = Set<Safety>();
    }
    

}

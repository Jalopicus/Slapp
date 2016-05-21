using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datality.Smashley {
    namespace Extensions {
        public static class BootyCheeks {
            public static bool IsAlreadyFormulated(this Blend b, Raw r) {
                return b.Formulinoes.Any(x => x.RawId == r.Id);
            }
            /// <summary>
            /// Add a formulino to a blend
            /// </summary>
            /// <param name="blend">Blend to be formulated</param>
            /// <param name="raw">Raw material to be spliced in</param>
            /// <param name="low">Low end of the %weight range</param>
            /// <param name="high">High end of the %weight range</param>
            /// <param name="actual">Formula %weight</param>
            /// <returns></returns>
            public static Formulino Formulate(this Blend blend, Raw raw, float low = -1, float high = -1, float actual = -1) {
                if (blend.IsAlreadyFormulated(raw)) return null;
                return new Formulino {
                    Blend = blend,
                    BlendId = blend.Id,
                    Raw = raw,
                    RawId = raw.Id,
                    Low = low,
                    High = high,
                    Actual = actual
                };
            }
            /// <summary>
            /// Remove a formulino from a blend
            /// </summary>
            /// <param name="formulino"></param>
            public static void DeFormulate(this Formulino formulino) {
                if (formulino == null) return;
                formulino.BlendId = null;
            }
            /// <summary>
            /// Determines if a pro is a clone o
            /// </summary>
            /// <param name="p"></param>
            /// <param name="b"></param>
            public static void IsCloneOf(this Pro p, Blend b) {
                if (p == null | b == null) return;
                p.BlendId = b.Id;
                p.Blend = b;
            }
            /// <summary>
            /// TODO: No actual clones exist by default data tap
            /// </summary>
            /// <param name="p"></param>
            /// <returns></returns>
            public static List<Thing> HasTheseClones(this Pro p) {
                var list = new List<Thing>();
                using (var ag = new AshleyGraham()) {
                    list = ag.Pros.Where(x => x.BlendId == p.BlendId )
                        .AsEnumerable()
                        .Select(y => y.Thing).OrderBy(x=>x.Text)
                        .ToList();
                }
                return list;
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
            public static void Modded(this DbEntityEntry e) { e.State = System.Data.Entity.EntityState.Modified; }
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
            public static string CityStateZip(this Brand b) {
                string[] cs = {b.City, b.State};
                var ret = String.Join(", ", cs) + " " + b.Zip;
                return ret;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Datality.Smashley;
using PropertyChanged;

namespace Datality {
    /// <summary>
    /// Minions splay out properties and handle internal logistics for a given entity class
    /// </summary>
    public interface IMinion<T> {
        /// <summary>
        /// Object held by the minion
        /// </summary>
        T LootItem { get; }
        /// <summary>
        /// Retrieves an object by its id/primary key
        /// </summary>
        /// <param name="id">Integer id to search for (usually primary key)</param>
        /// <returns></returns>
        void Fetch(int id);
        /// <summary>
        /// Save changes to an object's appropriate Set of Ts
        /// </summary>
        /// <param name="obj">Object to save to Set of Ts</param>
        void Save(T obj);
        /// <summary>
        /// Add a new object to the corresponding Set of Ts
        /// </summary>
        /// <remarks>May be absorbed by Save()</remarks>
        /// <param name="obj">New object to be added</param>
        void Add(T obj);
    }
    /// <summary>
    /// Minions splay out properties and handle internal logistics for a given entity class
    /// </summary>
    /// <typeparam name="T">T is a class from the EF model and implements IVoyeur for list-based xaml controls</typeparam>
    /// <seealso cref="IVoyeur"/>
    /// <remarks>A minion can only carry one object at a time. Multiple minions form a "mob".</remarks>
    [ImplementPropertyChanged]
    public class Minion<T> : IMinion<T> where T : class, IVoyeur, new() {
        public Minion() {
            _lootItem = new T();
            LootSwap?.Invoke(this, new PropertyChangedEventArgs("LootItem"));
        }
        static Minion() {
            using (var ag = new AshleyGraham()) {
                _inventory = ag.Set<T>().AsEnumerable().Select(x => x.Thing).ToList<Thing>();
            }
        }
        public event PropertyChangedEventHandler LootSwap;

        private static readonly ICollection<Thing> _inventory;
        public ICollection<Thing> Inventory => _inventory;
        private T _lootItem;
        public T LootItem {
            get { return _lootItem; }
            set { _lootItem = value; LootSwap?.Invoke(this, new PropertyChangedEventArgs("LootItem")); }
        }
        /// <summary>
        /// Repository retrieval by primary key
        /// </summary>
        /// <param name="id">Primary key</param>
        /// <returns>An object T matching the primary key. Use of the .Find() method allegedly checks the .Local before retrieving from the repository.</returns>
        public void Fetch(int id) {
            using (var ag = new AshleyGraham()) {
                _lootItem = ag.Set<T>().Find(id);
                LootSwap?.Invoke(this, new PropertyChangedEventArgs("LootItem"));
            }
        }
        /// <summary>
        /// Save and commit changes to object
        /// </summary>
        /// <param name="obj">Altered object</param>
        public void Save(T obj) {
            if (obj.Thing.Number == default(int))
                throw new ArgumentException("Saving an entity with default Id. Should this be calling Add()?");
            using (var ag = new AshleyGraham()) {
                ag.Entry<T>(obj)?.CurrentValues.SetValues(obj);
                ag.SaveChanges();
            }
        }
        /// <summary>
        /// Add new object to the repository
        /// </summary>
        /// <param name="obj">New object</param>
        public void Add(T obj) {
            using (var ag = new AshleyGraham()) {
                ag.Set<T>().Add(obj);
                ag.SaveChanges();
            }
        }
    }
    public interface IStaticDischarge<T> {

    }
    [ImplementPropertyChanged]
    public static class StaticMinion<T> {

    }
    ///// <summary>
    ///// Specialized minion that would retrieve "static" data from HexaGraham
    ///// </summary>
    ///// <remarks>EF may be overkill for this</remarks>
    ///// <typeparam name="T">Entity class</typeparam>
    ///// TODO: Combine HexaGram with AshleyGraham
    //public class StaticMinion<T> : Minion<T> {

    //    public T Fetch(int id) {
    //        using (var ag = new HexaGraham()) {
    //            return ag.Set<T>().Find(id);
    //        }
    //    }
    //    public void Save(T obj) {
    //        if (obj.Thing.Number == default(int))
    //            throw new ArgumentException("Saving an entity with default Id. Should Add().");
    //        using (var ag = new HexaGraham()) {
    //            ag.Entry<T>(obj)?.CurrentValues.SetValues(obj);
    //            ag.SaveChanges();
    //        }
    //    }
    //    public void Add(T obj) {
    //        using (var ag = new HexaGraham()) {
    //            ag.Set<T>().Add(obj);
    //            ag.SaveChanges();
    //        }
    //    }
    //}
    /// <summary>
    /// Extensions to the classes that implement IMinion
    /// </summary>
    /// <see cref="Minion{T}"/>
    public static class MinionExtensions {

    }
}

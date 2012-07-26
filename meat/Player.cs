using System;
using System.Collections.Generic;
using meat.worker_distribution;

namespace meat
{
    public class Player
    {
        IList<Development> developments;
        GoodStore good_store;
        MonumentStore monument_store;
        public string name { get; private set; }
        public bool has_an_ending_condition { get; private set; }
        public int food { get; set; }
        public int cities { get; set; }
        public int disasters { get; set; }

        public Player() : this("") { }
        public Player(string name) : this(name, new GoodStore(), new MonumentStore()) { }
        public Player(string name, GoodStore good_store) : this(name, good_store, new MonumentStore()) { }
        public Player(string name, MonumentStore monument_store) : this(name, new GoodStore(), monument_store) { }
        public Player(string name, GoodStore good_store, MonumentStore monument_store)
        {
            this.name = name;
            this.good_store = good_store;
            this.monument_store = monument_store;
            developments = new List<Development>();
        }

        public void add(Development development)
        {
            developments.Add(development);
        }

        public virtual void add_goods(int quantity_of_goods)
        {
            good_store.add(quantity_of_goods);
        }

        public virtual void add_workers_to_cities(int quantity_of_workers)
        {
            throw new NotImplementedException();
        }

        public virtual void add_workers_to_monuments(IEnumerable<AddWorkersToMonument> workers_added_to_monuments)
        {
            monument_store.add(workers_added_to_monuments);
        }

        public virtual void remove_all_goods()
        {
            good_store.remove_all();
        }

        public bool has(Development development)
        {
            return developments.Contains(development);
        }

        public virtual bool has(Monument monument)
        {
            return monument_store.has(monument);
        }
    }

    public class MonumentStore
    {
        public virtual void add(IEnumerable<AddWorkersToMonument> workers_added_to_monuments)
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<Monument> get_completed()
        {
            throw new NotImplementedException();
        }

        public virtual bool has(Monument monument)
        {
            throw new NotImplementedException();
        }
    }
}
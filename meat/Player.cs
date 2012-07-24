using System;
using System.Collections.Generic;

namespace meat
{
    public class Player
    {
        IList<Development> developments;
        IList<Monument> monuments;

        public string name { get; private set; }
        public bool has_an_ending_condition { get; private set; }
        public int food { get; set; }
        public GoodStore good_store { get; private set; }
        public int cities { get; set; }
        public int disasters { get; set; }

        public Player() : this("") { }
        public Player(string name) : this(name, new GoodStore()) { }
        public Player(string name, GoodStore good_store)
        {
            this.name = name;
            this.good_store = good_store;
            developments = new List<Development>();
            monuments = new List<Monument>();
        }

        public void add(Development development)
        {
            developments.Add(development);
        }

        public void add(Monument monument)
        {
            monuments.Add(monument);
        }

        public void add_goods(int quantity_of_goods)
        {
            good_store.Add(quantity_of_goods);
        }

        public virtual void remove_all_goods()
        {
            good_store.remove_all();
        }

        public bool has(Development development)
        {
            return developments.Contains(development);
        }

        public bool has(Monument monument)
        {
            return monuments.Contains(monument);
        }
    }
}
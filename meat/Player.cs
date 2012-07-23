using System.Collections.Generic;

namespace meat
{
    public class Player
    {
        IList<Development> developments;

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
        }

        public void add_development(Development development)
        {
            developments.Add(development);
        }

        public bool has(Development development)
        {
            return developments.Contains(development);
        }

        public void add_goods(int quantity_of_goods)
        {
            good_store.Add(quantity_of_goods);
        }
    }
}
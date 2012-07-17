namespace meat
{
    public class Player
    {
        public virtual string name { get; private set; }
        public virtual bool has_an_ending_condition { get; private set; }

        public Player() : this("") {}
        public Player(string name)
        {
            this.name = name;
        }
    }
}
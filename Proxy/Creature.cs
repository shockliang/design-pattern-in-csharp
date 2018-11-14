namespace Proxy
{
    public class Creature
    {
        private Property<int> agility = new Property<int>();

        public int Agility
        {
            get => agility.Value;
            set => agility.Value = value;
        }
    }
}
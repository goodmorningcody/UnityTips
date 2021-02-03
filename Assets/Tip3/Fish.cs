namespace OOPWithInterface
{
    public class Fish
    {
        public string Name { get; private set; }
        public float Length { get; private set; }
        public Fish(string name, float length)
        {
            Name = name;
            Length = length;
        }
    }
}
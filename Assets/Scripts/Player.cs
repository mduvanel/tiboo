
namespace Tiboo
{
    public class Player
    {
        public enum Color
        {
            RED,
            GREEN,
            BLUE,
            YELLOW
        }

        public enum Animal
        {
            MOUSE,
            RABBIT
        }

        public Animal AnimalType { get; set; }
        public Color ColorType { get; set; }

        public Player(Animal animal, Color color)
        {
            ColorType = color;
            AnimalType = animal;
        }
    }
}

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
        public Position Pos { get; set; }

        public Player(Animal animal, Color color, Position position)
        {
            ColorType = color;
            AnimalType = animal;
            Pos = position;
        }
    }
}

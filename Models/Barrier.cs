using System.Drawing;

namespace CarGame.Models
{
    public class Barrier
    {
        public int Id { get; init; }

        public string Name { get; set; }

        public Bitmap Image { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public Barrier(Point position, int id)
        {
            Id = id;
            Name = $"Barrier{Id}";
            Image = (Bitmap)System.Drawing.Image.FromFile("C:\\Users\\turgh\\Desktop\\kod\\CarGame\\Assets\\barrier.png");
            X = position.X;
            Y = position.Y;
        }

        public void SetYPosition(int x)
        {
            X = x;
        }
    }
}

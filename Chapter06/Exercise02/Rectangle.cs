namespace WorkspaceSix
{
    public class Rectangle : Shape
    {
        public Rectangle(int height, double width)
        {
            Height = height;
            Width = width;
            Area = Width * Height;
        }
    }
}

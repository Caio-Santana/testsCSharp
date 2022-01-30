namespace WorkspaceSix
{
    public class Square : Shape
    {
        public Square(int sideLength)
        {
            Height = sideLength;
            Width = sideLength;
            Area = Width * Height;
        }
    }
}
namespace WorkspaceSix
{
    public class Circle : Shape
    {
        public Circle(double ray)
        {
            Width = ray * 2;
            Height = Width;
            Area = ray * ray * System.Math.PI;
        }
    }
}
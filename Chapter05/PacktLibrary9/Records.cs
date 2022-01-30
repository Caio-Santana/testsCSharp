namespace Packt.Shared
{
    public class ImmutablePerson
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
    }

    public record ImmutableVehicle
    {
        public int Wheels { get; init; }
        public string Color { get; init; }
        public string Brand { get; init; }
    }

    public record ImmutableAnimal
    {
        string Name;
        string Species;

        public ImmutableAnimal(string name, string species)
        {
            Name = name;
            Species = species;
        }

        public void Deconstruct(out string name, out string species)
        {
            name = Name;
            species = Species;
        }
    }

    public record ImmutableBook(string Name, int Pages);
}
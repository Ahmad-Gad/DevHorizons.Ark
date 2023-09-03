namespace DevHorizons.Ark.Test.Internal
{
    internal class Car : SomeInterface
    {
        public Color Color { get; set; }

        public int Model { get; set; }

        public string Name { get; set; }

        public CarManufacturer Manufacturer { get; set; }

        public ParentManufacturer ParentManufacturer { get; set; }
    }
}

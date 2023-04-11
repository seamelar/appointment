using MyLibrary;

namespace AutoMapperLibrary
{
    public class MapperAnimal
    {
        public int Id { get; set; }
        public string Species { get; set; } = null!;
        public string Name { get; set; } = null!;

        public int AnimalOwnerId { get; set; }

        public AnimalOwner? AnimalOwner { get; set; }
    }
}

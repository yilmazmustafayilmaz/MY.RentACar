using Core.Entities;

namespace Entities.Concreate
{
    public class Brand : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

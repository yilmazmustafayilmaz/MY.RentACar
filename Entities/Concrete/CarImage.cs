using Core.Entities;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Concrete
{
    public class CarImage : IEntity
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public string ImagePath { get; set; } = string.Empty;
        public DateTime Date { get; set; } = DateTime.Now;

        [NotMapped]
        public IFormFile File { get; set; }
    }
}

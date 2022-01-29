using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VladMedrisWebApp.Models
{
    public class Game
    {
        public int ID { get; set; }

        [Display(Name = "Game Title")]
        public string Title { get; set; }
        public string Studio { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
    }
}

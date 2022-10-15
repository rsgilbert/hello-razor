using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hello_razor.Models 
{
    public class Movie 
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50, MinimumLength =3)]
        public string Title { get; set; } = string.Empty;


        [DisplayFormat(DataFormatString="{0:yyyy-MM-dd}", ApplyFormatInEditMode =true)]
        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        

        [Required(ErrorMessage ="Genre can not be blank")]
        public string Genre { get; set; } = string.Empty;

        [Range(0, 1_000_000)]
        [DataType(DataType.Currency)]
        [Column(TypeName ="decimal(18,2)")]
        public decimal Price { get; set; }

        [RegularExpression(@"[A-Z+]*")]
        public string Rating { get; set; } = string.Empty;
    }
}
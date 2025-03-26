using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Humanizer.Localisation;

namespace BlazorWebAppMovies1.Models
{
	public class Movies
	{
		public int Id { get; set; }

		[Required]
		public string? Title { get; set; }

		[Display(Name = "Release Date")]
		public DateOnly ReleaseDate { get; set; }

		public int GenreId { get; set; }

		[ForeignKey("GenreId")]
		public virtual Genre? Genre { get; set; }

		[DataType(DataType.Currency)]
		[Column(TypeName = "decimal(18, 2)")]
		public decimal Price { get; set; }
	}
}

using System.ComponentModel.DataAnnotations;

namespace BlazorWebAppMovies1.Models
{
	public class Genre
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[Display(Name = "Genre Name")]
		[StringLength(100)]
		public string? Name { get; set; }

		
		public virtual ICollection<Movies> Movies { get; set; } = new List<Movies>();
	}
}

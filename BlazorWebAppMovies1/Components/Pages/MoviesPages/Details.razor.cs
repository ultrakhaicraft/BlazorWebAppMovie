using BlazorWebAppMovies1.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace BlazorWebAppMovies1.Components.Pages.MoviesPages
{
	public partial class Details
	{
		private Movies? movies;
		private Genre genre;

		[SupplyParameterFromQuery]
		private int Id { get; set; }

		protected override async Task OnInitializedAsync()
		{
			using var context = DbFactory.CreateDbContext();
			movies = await context.Movies.FirstOrDefaultAsync(m => m.Id == Id);
			if (movies is null)
			{
				NavigationManager.NavigateTo("notfound");
			}
			else
			{
				genre = await context.Genre.FirstOrDefaultAsync(mbox => mbox.Id == movies.GenreId);
			}
		}
	}
}
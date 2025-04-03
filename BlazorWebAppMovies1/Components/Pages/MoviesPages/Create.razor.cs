using BlazorWebAppMovies1.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace BlazorWebAppMovies1.Components.Pages.MoviesPages
{
	public partial class Create
	{
		[SupplyParameterFromForm]
		private Movies Movies { get; set; } = new();

		private List<Genre> Genres { get; set; } = new();

		protected override async Task OnInitializedAsync()
		{
			using var context = DbFactory.CreateDbContext();
			Genres = await context.Genre.ToListAsync();
		}

		private async Task AddMovies()
		{
			using var context = DbFactory.CreateDbContext();
			context.Movies.Add(Movies);
			await context.SaveChangesAsync();
			NavigationManager.NavigateTo("/movies");
		}
	}
}
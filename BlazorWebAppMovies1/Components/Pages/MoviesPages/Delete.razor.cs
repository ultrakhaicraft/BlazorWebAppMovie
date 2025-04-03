using BlazorWebAppMovies1.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace BlazorWebAppMovies1.Components.Pages.MoviesPages
{
	public partial class Delete
	{
		private Movies? movies;

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
		}

		private async Task DeleteMovies()
		{
			using var context = DbFactory.CreateDbContext();
			context.Movies.Remove(movies!);
			await context.SaveChangesAsync();
			NavigationManager.NavigateTo("/movies");
		}
	}
}
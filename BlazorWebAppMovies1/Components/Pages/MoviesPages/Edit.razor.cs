using BlazorWebAppMovies1.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace BlazorWebAppMovies1.Components.Pages.MoviesPages
{
	public partial class Edit
	{
		[SupplyParameterFromQuery]
		private int Id { get; set; }

		[SupplyParameterFromForm]
		private Movies? Movies { get; set; }

		private List<Genre> Genres { get; set; } = new();

		protected override async Task OnInitializedAsync()
		{
			using var context = DbFactory.CreateDbContext();
			Genres = await context.Genre.ToListAsync();
			Movies ??= await context.Movies.FirstOrDefaultAsync(m => m.Id == Id);

			if (Movies is null)
			{
				NavigationManager.NavigateTo("notfound");
			}
		}


		private async Task UpdateMovies()
		{
			using var context = DbFactory.CreateDbContext();
			context.Attach(Movies!).State = EntityState.Modified;

			try
			{
				await context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!MoviesExists(Movies!.Id))
				{
					NavigationManager.NavigateTo("notfound");
				}
				else
				{
					throw;
				}
			}

			NavigationManager.NavigateTo("/movies");
		}

		private bool MoviesExists(int id)
		{
			using var context = DbFactory.CreateDbContext();
			return context.Movies.Any(e => e.Id == id);
		}
	}
}
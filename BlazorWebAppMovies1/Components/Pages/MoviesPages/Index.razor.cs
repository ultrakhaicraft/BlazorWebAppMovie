using BlazorWebAppMovies1.Data;

namespace BlazorWebAppMovies1.Components.Pages.MoviesPages
{
	public partial class Index
	{
		private BlazorWebAppMovies1Context context = default!;

		protected override void OnInitialized()
		{
			context = DbFactory.CreateDbContext();
		}

		public async ValueTask DisposeAsync() => await context.DisposeAsync();
	}
}
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using TechCareer_BootCamp_MovieProject_Services.AbstractServices;

namespace TechCareer_BootCamp_MovieProject_UI.TagHelpers
{
	[HtmlTargetElement("div", Attributes = "movies")]
	public class LastestMoviesTagHelper : TagHelper
	{
		private readonly IServiceManager _manager;

		public LastestMoviesTagHelper(IServiceManager manager)
		{
			_manager = manager;
		}
		[HtmlAttributeName("number")]
		public int lastestMoviesCount { get; set; }
		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			TagBuilder div = new TagBuilder("div"); //bu satirlar <div class="my-3"></div>' a karsilik gelmektedir.
			div.Attributes.Add("class", "my-3");

			TagBuilder h6 = new TagBuilder("h6");
			h6.Attributes.Add("class", "lead");

			TagBuilder icon = new TagBuilder("i");
			icon.Attributes.Add("class", "fa fa-box text-secondary");

			h6.InnerHtml.AppendHtml(icon); //<i> etiketi ve Lastest Products ifadesi h6'nin icinde oldugu icin bu sekilde ifade edilmeli.
			h6.InnerHtml.AppendHtml("Lastest Movies");

			div.InnerHtml.AppendHtml(h6); //ayni sekilde h6 da divin icerisinde barinmaktadir.

			TagBuilder ul = new TagBuilder("ul");

			var movies = _manager.MovieService.GetLastestMovies(lastestMoviesCount, false);
			foreach (var movie in movies)
			{
				TagBuilder li = new TagBuilder("li");

				TagBuilder a = new TagBuilder("a");
				a.Attributes.Add("href", $"Movies/Details/{movie.Id}");
				a.InnerHtml.AppendHtml(movie.OriginalTitle!);

				li.InnerHtml.AppendHtml(a);
				ul.InnerHtml.AppendHtml(li);
			}
			div.InnerHtml.AppendHtml(ul);
			output.Content.AppendHtml(div);
		}
	}
}

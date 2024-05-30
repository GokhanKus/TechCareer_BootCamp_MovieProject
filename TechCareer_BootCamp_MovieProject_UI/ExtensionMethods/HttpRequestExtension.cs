namespace TechCareer_BootCamp_MovieProject_UI.ExtensionMethods
{
	public static class HttpRequestExtension
	{
		public static string PathAndQuery(this HttpRequest request)//bu HttpRequest classini genisletmek istiyoruz ya da bu metotu bu classa kazandırmak istiyoruz, verilen parametre bunun içindir.
		{
			PathString path = request.QueryString.HasValue ? $"{request.Path}{request.QueryString}" : request.Path.ToString();
			return path; 
		}
	}
}


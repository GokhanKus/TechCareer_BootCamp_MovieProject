using Newtonsoft.Json;
using TechCareer_BootCamp_MovieProject_Model.Entities;
using TechCareer_BootCamp_MovieProject_UI.ExtensionMethods;

namespace TechCareer_BootCamp_MovieProject_UI.Models
{
	public class SessionFavMovie : FavoriteMoviesList
	{
		#region Json Ignore

		/* JsonIgnore
		 Bu ifade, SessionCart sınıfında bulunan Session adlı özelliğin JSON serileştirmesi sırasında dikkate alınmamasını sağlar.
		JsonIgnore özelliği, JSON serileştirmesi sırasında belirli bir özelliğin atlanmasını sağlayan bir özelliktir.
		Özellikle Session özelliğinin üzerinde bulunan [JsonIgnore] özniteliği, bu özelliğin JSON serileştirmesi sırasında dikkate alınmamasını istediğinizi belirtir.
		Yani, eğer bir nesne, örneğin bir SessionCart nesnesi, JSON formatına dönüştürülürken, bu özellik JSON çıktısında yer almayacaktır.
		Bu özellik, örneğin, bir nesnenin belirli durum bilgilerini içeriyorsa ve bu durum bilgilerinin dışa aktarılmasını istemiyorsanız veya 
		bu özelliği JSON çıktısından hariç tutmak istiyorsanız kullanışlı olabilir. Bu sayede JSON çıktısı daha temiz ve ihtiyaçları karşılayan bir şekilde oluşturulabilir.
		*/

		#endregion
		[JsonIgnore]//sessionun tekrar kendisini yazmaması icin 
		public ISession? Session { get; set; }

		//app calismaya baslarken belli servisler kullanilir.serviceProvider uzerinden ihtiyac duydugumuz servisi alacagiz.
		public static FavoriteMoviesList GetFavMovie(IServiceProvider serviceProvider)
		{
			//oturum(session) bilgilerini okuyalim, IHttpContextAccessor araciligiyla HttpContext nesnesine ve Session propuna erisim saglayalim
			ISession? session = serviceProvider.GetRequiredService<IHttpContextAccessor>().HttpContext?.Session;
			//burada session.GetJson(), SetJson() metotlari SessionExtension'dan geliyor(this ISession session) yazarak erisim saglandi?
			SessionFavMovie FavoriteMoviesList = session?.GetJson<SessionFavMovie>("FavoriteMoviesList") ?? new SessionFavMovie();
			FavoriteMoviesList.Session = session;
			return FavoriteMoviesList;
		}
		public override void AddItem(Movie movie)
		{
			//base kısmında kalıtım alınan classtaki(Cart.cs) virtual metot calırıs alttaki satirda extradan yapılan islem vs.
			//(override(metodu genisletiyoruz bir nevi.))
			base.AddItem(movie);
			Session?.SetJson<SessionFavMovie>("FavoriteMoviesList", this);// veriyi sessiona yazmis oluyoruz. this = bu sınıfın kendisini serialize et
		}
		public override void RemoveItem(Movie movie)
		{
			base.RemoveItem(movie);
			Session?.SetJson<SessionFavMovie>("FavoriteMoviesList", this);
		}
		public override void Clear()
		{
			base.Clear();
			Session?.Remove("FavoriteMoviesList");
		}
	}
}

using Newtonsoft.Json;

namespace TechCareer_BootCamp_MovieProject_UI.ExtensionMethods
{
	public static class SessionExtension
	{
		public static void SetJson(this ISession session, string key, object value)
		{
			//object ile gelen value degerini cozumleyip (string'e cevirip -json formatina cevirip)veriyi sessionda hafızaya alıyoruz.
			session.SetString(key, JsonConvert.SerializeObject(value));
		}
		public static void SetJson<T>(this ISession session, string key, T value)
		{
			//ustteki metotla islevi aynidir bu sadece generic versiyonu bizden bir T tipi bekler.
			session.SetString(key, JsonConvert.SerializeObject(value));
		}
		public static T? GetJson<T>(this ISession session, string key) where T : class
		{
			var data = session.GetString(key);
			return data is null
				? default(T)
				: JsonConvert.DeserializeObject<T>(data); //deserialize ederek json formatindaki veriyi T tipine donusturur.

			#region 1.yontem
			//var data = session.GetString(key);
			//if (string.IsNullOrEmpty(data))
			//{
			//	return null;
			//}
			//T? value = JsonConvert.DeserializeObject<T>(data);
			//return value;
			#endregion
		}
	}
}

//ozet bilgi, amac: verileri hafızada ve geriye yonelik requestleri hafızada tutmak ve konfigurasyon ayarları yapmak program.cs (orn. idletimeout)
//bu classta ilgili fonksiyonları yazıyoruz.veriyi hafızaya alma veriyi getirme gibi islemler..

//set isleminde kısıtımız var byte[], int ve string tipinde veri tutabiliyoruz, eger class bilgisi tutmak istersen once serialize sonra deserialize islemi yapariz.
//bu sinif bunun icin olusturuldu
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechCareer_BootCamp_MovieProject_Model.ViewModels.IdentityModels
{
	public record UserViewModelForUpdate : UserViewModel
	{
		//HashSet bir koleksiyon yapısıdır ve koleksiyon yapısı oldugu icin tekrar eden bir string ifadesi buraya eklenemez,
		public HashSet<string> UserRoles { get; set; } = new HashSet<string>();
    }
}

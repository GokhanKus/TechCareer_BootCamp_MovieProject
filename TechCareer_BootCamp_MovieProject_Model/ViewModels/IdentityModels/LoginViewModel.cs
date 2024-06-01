using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechCareer_BootCamp_MovieProject_Model.ViewModels.IdentityModels
{
	public class LoginViewModel
	{
		//set yerine private set yaparsam sadece bu class icerisinde deger ataması yapabilirim diger yerlerde degistirilmesine izin verilmez
		[Required]
		public string? UserName { get; init; }//private set olursa sayfa uzerinden deger ataması da yapamayız null gelir
		[Required]
		public string? Password { get; set; }
		public bool RememberMe{ get; set; }

		private string? _returnUrl;
		public string ReturnUrl //user giris yapinca yonlendirelim
		{
			get { return _returnUrl ?? "/"; }
			set { _returnUrl = value; }
		}
    }
}

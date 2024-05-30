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
		[Required]
		public string? UserName { get; set; }
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

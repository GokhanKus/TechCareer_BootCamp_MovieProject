using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechCareer_BootCamp_MovieProject_Model.ViewModels.IdentityModels
{
	public record UserViewModel
	{
		[Required]
		[DataType(DataType.Text)]
		public string? UserName { get; init; }

		[Required]
		[DataType(DataType.EmailAddress)]
		public string? Email { get; init; }

		[DataType(DataType.PhoneNumber)]
		public string? PhoneNumber { get; init; }
		public HashSet<string> Roles { get; set; } = new HashSet<string>(); //get;set; yapip yazmaya izin verelim
		//hashset ile tanimlarsak ayni veriyi eklemeye izin vermez hata da vermez orn rollere admin, user, editor,admin atadik 3 rol olur admini bir daha almaz etc.
	}
}

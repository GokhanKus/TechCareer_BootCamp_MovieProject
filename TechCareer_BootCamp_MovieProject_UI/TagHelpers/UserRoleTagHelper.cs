using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Drawing.Text;
using TechCareer_BootCamp_MovieProject_Services.AbstractServices;
using TechCareer_BootCamp_MovieProject_UI.Controllers;

namespace TechCareer_BootCamp_MovieProject_UI.TagHelpers
{
	[HtmlTargetElement("td", Attributes = "asp-role-users")]//td etiketi altında calisacak "asp-role-users" tagi => <td asp-role-users="@user.UserName"></td> olacak
	public class UserRoleTagHelper : TagHelper
	{
		private readonly UserManager<IdentityUser> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;
		public UserRoleTagHelper(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
		{
			_userManager = userManager;
			_roleManager = roleManager;
		}
		[HtmlAttributeName("asp-role-users")]
		public string UserName { get; set; } = null!;
		public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
		{
			var user = await _userManager.FindByNameAsync(UserName);
			var roles = _roleManager.Roles.Select(r => r.Name!).ToList();

			TagBuilder ul = new TagBuilder("ul");
			foreach (var role in roles)
			{
				TagBuilder li = new TagBuilder("li");
				if (await _userManager.IsInRoleAsync(user, role)) //user'a ait rolleri listeleyelim
				{
					li.InnerHtml.Append(role);
					ul.InnerHtml.AppendHtml(li);
				}
			}
			output.Content.AppendHtml(ul);
		}
	}
}

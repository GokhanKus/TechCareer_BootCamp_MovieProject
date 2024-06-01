using AutoMapper;
using Microsoft.AspNetCore.Identity;
using TechCareer_BootCamp_MovieProject_Model.Entities;
using TechCareer_BootCamp_MovieProject_Model.ViewModels.ActorModels;
using TechCareer_BootCamp_MovieProject_Model.ViewModels.DirectorModels;
using TechCareer_BootCamp_MovieProject_Model.ViewModels.IdentityModels;
using TechCareer_BootCamp_MovieProject_Model.ViewModels.MovieModels;

namespace TechCareer_BootCamp_MovieProject_Services.Mapper
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Actor, ActorViewModelWithDetails>();
			CreateMap<ActorViewModelForInsertion, Actor>();
			CreateMap<ActorViewModelForUpdate, Actor>().ReverseMap(); //actorden modele, modelden de actore aktarim olacak o yuzden reverse

			CreateMap<DirectorViewModelForInsertion, Director>();
			CreateMap<DirectorViewModelForUpdate, Director>().ReverseMap();

			CreateMap<Movie, MovieViewModelWithDetails>();
			CreateMap<MovieViewModelForInsertion, Movie>();
			CreateMap<MovieViewModelForUpdate, Movie>().ReverseMap();

			CreateMap<UserViewModelForInsertion, IdentityUser>();
		}
	}
}

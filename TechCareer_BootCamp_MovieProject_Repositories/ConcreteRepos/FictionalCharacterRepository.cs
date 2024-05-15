using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechCareer_BootCamp_MovieProject_Model.Entities;
using TechCareer_BootCamp_MovieProject_Repositories.AbstractRepos;
using TechCareer_BootCamp_MovieProject_Repositories.BaseRepos;
using TechCareer_BootCamp_MovieProject_Repositories.Context;

namespace TechCareer_BootCamp_MovieProject_Repositories.ConcreteRepos
{
	public class FictionalCharacterRepository : BaseRepository<FictionalCharacter>, IFictionalCharacterRepository
	{
		public FictionalCharacterRepository(MovieDbContext context) : base(context)
		{

		}
		public async Task<IEnumerable<FictionalCharacter>> GetAllFictionalCharsWithActors(bool trackChanges)
		{
			var fictCharsWithActor =await _context.FictionalCharacters.Include(f => f.Actor).ToListAsync();
			return fictCharsWithActor;
		}
		public async Task<FictionalCharacter>? GetOneFictionalCharWithActor(int? id)
		{
			var fictCharWithActor = await _context.FictionalCharacters.Include(f => f.Actor).FirstOrDefaultAsync(f => f.Id == id);
			return fictCharWithActor;
		}
	}
}

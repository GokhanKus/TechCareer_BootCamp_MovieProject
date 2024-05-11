using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TechCareer_BootCamp_MovieProject_Model.BaseEntities;
using TechCareer_BootCamp_MovieProject_Repositories.Context;

namespace TechCareer_BootCamp_MovieProject_Repositories.BaseRepos
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, IEntity, new()
    {
        //ben bu contexti devraldigim(kalitim) classlarda da kullanabilmek istedigim icin private yerine protected yaptım.
        //ayrıca class abstract oldugu icin public olmasının bir anlamı yok dogru mu cunku newlenemez bir class 
        protected readonly MovieDbContext _context; 
        protected BaseRepository(MovieDbContext context)
        {
            _context = context;
        }
        public void Create(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }
        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }
        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }
        public IQueryable<TEntity> FindAll(bool trackChanges)
        {
            return trackChanges ? _context.Set<TEntity>() //bu, bir liste geldi ve ef core listeyi izleyecek demek
                : _context.Set<TEntity>().AsNoTracking(); //ama eger degisiklikler izlenmeyecekse yine ilgili nesneye set olacagiz 
        }
        public TEntity? FindByCondition(Expression<Func<TEntity, bool>> expression, bool trackChanges)
        {
            return trackChanges
                ? _context.Set<TEntity>().FirstOrDefault(expression)
                : _context.Set<TEntity>().AsNoTracking().FirstOrDefault(expression);

            //return trackChanges
            //	? _context.Set<TEntity>().Where(expression).SingleOrDefault()
            //	: _context.Set<TEntity>().Where(expression).AsNoTracking().SingleOrDefault();

            //Set<> : belirtliecek olan TEntity'nin örnegini kaydetmek icin ve sorgulama yapılabilecek bir entity icin dbset olusturulur
        }
    }
}

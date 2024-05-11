using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TechCareer_BootCamp_MovieProject_Repositories.BaseRepos
{
    public interface IBaseRepository<TEntity>
    {
        IQueryable<TEntity> GetAll(bool trackChanges);//EF Core'un performansini artirmak icin degisiklikleri izleyelim??(trackChanges)
                                                       //IEnumerable<TEntity> FindAll(bool trackChanges);
        TEntity? GetByCondition(Expression<Func<TEntity, bool>> expression, bool trackChanges);
        void Create(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);
    }
}

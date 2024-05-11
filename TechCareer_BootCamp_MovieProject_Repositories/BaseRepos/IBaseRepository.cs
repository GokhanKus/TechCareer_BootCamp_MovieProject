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
        IQueryable<TEntity> FindAll(bool trackChanges);//EF Core'un performansini artirmak icin degisiklikleri izleyelim??(trackChanges)
                                                       //IEnumerable<TEntity> FindAll(bool trackChanges);
        TEntity? FindByCondition(Expression<Func<TEntity, bool>> expression, bool trackChanges);
        void Create(TEntity entity);
        void Remove(TEntity entity);
        void Update(TEntity entity);
    }
}

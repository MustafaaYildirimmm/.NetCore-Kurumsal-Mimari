using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IService<TEntity>
        where TEntity:class,new()
    {
        IDataResult<TEntity> GetById(int Id);
        IDataResult<List<TEntity>> GetList();
        IDataResult<List<TEntity>> GetListByObjectId(int Id);
        IResult Add(TEntity entity);
        IResult Delete(TEntity entity);
        IResult Update(TEntity entity);
    }
}

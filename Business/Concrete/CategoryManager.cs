using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public IResult Add(Category entity)
        {
            try
            {
                _categoryDal.Add(entity);
                return new SuccessResult("Category eklendi");
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.ToString());
            }
        }

        public IResult Delete(Category entity)
        {
            try
            {
                _categoryDal.Delete(entity);
                return new SuccessResult("Category silindi");
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.ToString());
            }
        }

        public IDataResult<Category> GetById(int Id)
        {
            try
            {
                return new SuccessDataResult<Category>(_categoryDal.Get(t => t.CategoryID == Id));
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Category>(ex.ToString());
            }
        }

        public IDataResult<List<Category>> GetList()
        {
            try
            {
                return new SuccessDataResult<List<Category>>(_categoryDal.GetList());
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<Category>>(ex.ToString());
            }
        }


        public IResult Update(Category entity)
        {
            try
            {
                _categoryDal.Update(entity);
                return new SuccessResult("Kategori düzenlendi.");
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.ToString());
            }
        }
    }
}

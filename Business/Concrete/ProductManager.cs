using Business.Abstract;
using Business.Constant;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EF;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        //ef bağlı olmaması için injection uygulandı.
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IResult Add(Product product)
        {
            try
            {
                _productDal.Add(product);
                return new SuccessResult(Messages.ProductAdded);
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }

        public IResult Delete(Product product)
        {
            try
            {
                _productDal.Delete(product);
                return new SuccessResult("Silme işlemi başarılı");
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }

        public IDataResult<Product> GetById(int productId)
        {
            try
            {
                return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));

            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Product>(ex.ToString());
            }
        }

        public IDataResult<List<Product>> GetList()
        {
            try
            {
                return new SuccessDataResult<List<Product>>(_productDal.GetList());

            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<Product>>(ex.ToString());
            }
        }

        public IDataResult<List<Product>> GetListByCategoryId(int categoryId)
        {
            try
            {
                return new SuccessDataResult<List<Product>>(_productDal.GetList(filter=> filter.CategoryId == categoryId));

            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<Product>>(ex.ToString());
            }
        }

        public IResult Update(Product product)
        {
            try
            {
                _productDal.Update(product);
                return new SuccessResult("Başarı ile güncellendi.");
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
            
        }
    }
}

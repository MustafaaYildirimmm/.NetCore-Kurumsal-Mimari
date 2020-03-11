using Core.DataAccess;
using Core.DataAccess.EF;
using DataAccess.Abstract;
using DataAccess.Concrete.EF.Contexts;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EF
{
    public class EfProductDal : EFRepositoryBase<Product, NorthwindContext>, IProductDal
    {
    }
}

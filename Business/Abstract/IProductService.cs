﻿using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService:IService<Product>
    {
        IDataResult<List<Product>> GetListByCategoryId(int Id);
    }
}

﻿using CSharpEgitimKampi.DataAccessLayer.Abstract;
using CSharpEgitimKampi.DataAccessLayer.Repositories;
using CSharpEgitimKampi301.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEgitimKampi.DataAccessLayer.EntityFramework
{
    public class EfCustomerDal : GenericRepository<Customer>,ICustomerDal
    {
    }
}

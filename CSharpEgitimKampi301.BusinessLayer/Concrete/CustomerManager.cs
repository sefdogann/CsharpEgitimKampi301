using CSharpEgitimKampi.DataAccessLayer.Abstract;
using CSharpEgitimKampi301.BusinessLayer.Abstract;
using CSharpEgitimKampi301.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEgitimKampi301.BusinessLayer.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public void TDelete(Customer entity)
        {
            _customerDal.Delete(entity);
        }

        public List<Customer> TGetall()
        {
            return _customerDal.Getall();
        }

        public Customer TGetById(int id)
        {
            return _customerDal.GetById(id);
        }

        public void TInsert(Customer entity)
        {
            if(entity.CustomerName!="" && entity.CustomerSurname !="" && entity.CustomerName.Length >=3 
                && entity.CustomerCity!=null&&entity.CustomerName.Length <=30)
            {
                _customerDal.Insert(entity);
            }
            else
            {
                //Throw an exception
            }
        }

        public void TUpdate(Customer entity)
        {
            _customerDal.Update(entity);
        }
    }
}

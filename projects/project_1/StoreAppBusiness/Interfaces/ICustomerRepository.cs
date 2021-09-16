using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StoreAppDBContext.Models;

namespace StoreAppBusiness.Interfaces
{
  public interface ICustomerRepository
  {
    Task<List<Customer>> CustomerListAsync();

    Task<Customer> LoginCustomerAsync(Customer customer);

    Task<Customer> RegisterCustomerAsync(Customer customer);
    void CustOrderList();
    void CustOrderList(string customer);
  }
}

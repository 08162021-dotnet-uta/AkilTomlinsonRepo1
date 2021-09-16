using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreAppBusiness.Interfaces;
using StoreAppDBContext.Models;
using dbcust = StoreAppDBContext.Models.Customer;

namespace StoreAppUI.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class CustomerController : Controller
  {
    private readonly ICustomerRepository _customerRepo;


    public CustomerController(ICustomerRepository cRepo)
    {
      _customerRepo = cRepo;
    }


    // GET: Customer
    public ActionResult Index()
    {
      return View();
    }

    // GET: Customer/Details/5
    [HttpGet("GetCustomers")]
    public async Task<List<Customer>> Details()
    {
      List<Customer> customer = await _customerRepo.CustomerListAsync();

      return customer;
    }

    // GET: Customer/Create
    [HttpPost("register")]
    public async Task<ActionResult<Customer>> Create(Customer cust)
    {
      if (!ModelState.IsValid) return BadRequest();

      Customer cust1 = await _customerRepo.RegisterCustomerAsync(cust);
      if (cust1 == null)
      {
        return NotFound();
      }

      return Created($"~customer/{cust1.CustomerId}", cust1);
    }

    // POST: Customer/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(IFormCollection collection)
    {
      try
      {
        // TODO: Add insert logic here

        return RedirectToAction(nameof(Index));
      }
      catch
      {
        return View();
      }
    }

    // GET: Customer/Edit/5
    public ActionResult Edit(int id)
    {
      return View();
    }

    // POST: Customer/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, IFormCollection collection)
    {
      try
      {
        // TODO: Add update logic here

        return RedirectToAction(nameof(Index));
      }
      catch
      {
        return View();
      }
    }

    // GET: Customer/Delete/5
    public ActionResult Delete(int id)
    {
      return View();
    }

    // POST: Customer/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, IFormCollection collection)
    {
      try
      {
        // TODO: Add delete logic here

        return RedirectToAction(nameof(Index));
      }
      catch
      {
        return View();
      }
    }

    [HttpGet("login/{FirstName}/{LastName}")]
    public async Task<ActionResult<Customer>> LoginOG(string FirstName, string LastName)
    {
      if (!ModelState.IsValid) return BadRequest();

      Customer cust = new Customer() { FirstName = FirstName, LastName = LastName };
      Customer cust1 = await _customerRepo.LoginCustomerAsync(cust);
      if (cust1 == null)
      {
        return NotFound();
      }
      return Ok(cust1);

    }

    // [HttpGet("GetLogin")]
    // public async Task<ActionResult<Customer>> Login()
    // {
    //   if (!ModelState.IsValid) return BadRequest();

    //   Customer cust = new Customer() { FirstName = "Jawn", LastName = "Dough" };
    //   Customer cust1 = await _customerRepo.LoginCustomerAsync(cust);
    //   if (cust1 == null)
    //   {
    //     return NotFound();
    //   }
    //   return Ok(cust1);

    // }



  }//EoC
}//EoF
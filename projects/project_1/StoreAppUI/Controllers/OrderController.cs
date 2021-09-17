using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreAppBusiness.Interfaces;
using StoreAppDBContext.Models;

namespace StoreAppUI.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class OrderController : Controller
  {

    private readonly IOrderRepository _orderRepo;


    public OrderController(IOrderRepository oRepo)
    {
      _orderRepo = oRepo;
    }
    // GET: Order
    public ActionResult Index()
    {
      return View();
    }

    // GET: Order/Details/5
    [HttpGet("PopulateOrder/{OrderId}/{ProductId}/{Quantity}")]
    public ActionResult PopulateOrder(string OrderId, string ProductId, string Quantity)
    {
      if (!ModelState.IsValid) return BadRequest();

      Task<int> popOrder = _orderRepo.PopulateOrderProductsAsync(OrderId, ProductId, Quantity);

      return Ok(popOrder);

    }

    // GET: Order/Create
    [HttpGet("CreateOrder/{CustomerId}/{StoreId}")]
    public ActionResult CreateOrder(string CustomerId, string StoreId)
    {
      if (!ModelState.IsValid) return BadRequest();
      //return Ok(12);

      Task<Order> orderId = _orderRepo.CreateOrderAsync(CustomerId, StoreId);

      return Ok(orderId);
    }

    // POST: Order/Create
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

    // GET: Order/Edit/5
    public ActionResult Edit(int id)
    {
      return View();
    }

    // POST: Order/Edit/5
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

    // GET: Order/Delete/5
    public ActionResult Delete(int id)
    {
      return View();
    }

    // POST: Order/Delete/5
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
  }
}
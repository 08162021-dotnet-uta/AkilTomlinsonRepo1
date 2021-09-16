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
  public class StoreController : Controller
  {

    private readonly IStoreRepository _storeRepo;

    public StoreController(IStoreRepository sRepo)
    {
      _storeRepo = sRepo;
    }
    // GET: Store
    public ActionResult Index()
    {
      return View();
    }

    // GET: Store/Details/5
    [HttpGet("GetStores")]
    public async Task<List<Store>> Details()
    {
      List<Store> store = await _storeRepo.StoreListAsync();
      return store;
    }

    // GET: Store/Create
    public ActionResult Create()
    {
      return View();
    }

    // POST: Store/Create
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

    // GET: Store/Edit/5
    public ActionResult Edit(int id)
    {
      return View();
    }

    // POST: Store/Edit/5
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

    // GET: Store/Delete/5
    public ActionResult Delete(int id)
    {
      return View();
    }

    // POST: Store/Delete/5
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
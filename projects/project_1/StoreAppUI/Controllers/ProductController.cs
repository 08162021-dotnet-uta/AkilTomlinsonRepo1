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
  public class ProductController : Controller
  {
    private readonly IProductRepository _productRepo;


    public ProductController(IProductRepository pRepo)
    {
      _productRepo = pRepo;
    }



    // GET: Product
    public ActionResult Index()
    {
      return View();
    }

    // GET: Product/Details/5
    [HttpGet("GetProducts/{store}")]
    public async Task<List<ViewStoreProduct>> Details(string store)
    {
      ViewStoreProduct VSP = new ViewStoreProduct() { StoreName = store };
      List<ViewStoreProduct> VSP1 = await _productRepo.StoreProductListAsync(VSP.StoreName);

      return VSP1;

    }

    [HttpGet("GetProductData/{productId}")]
    public async Task<ViewStoreProduct> ProductData(string productId)
    {
      //ViewStoreProduct VSP = new ViewStoreProduct() { ProductId = productId };
      ViewStoreProduct VSP1 = await _productRepo.ProductDataAsync(productId);

      return VSP1;

    }

    // GET: Product/Create
    public ActionResult Create()
    {
      return View();
    }

    // POST: Product/Create
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

    // GET: Product/Edit/5
    public ActionResult Edit(int id)
    {
      return View();
    }

    // POST: Product/Edit/5
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

    // GET: Product/Delete/5
    public ActionResult Delete(int id)
    {
      return View();
    }

    // POST: Product/Delete/5
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
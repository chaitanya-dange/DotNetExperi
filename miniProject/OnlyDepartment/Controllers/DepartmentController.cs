using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using OnlyDepartment.Models;
using BOL;
using BLL;
using DAL;

namespace OnlyDepartment.Controllers;

public class DepartmentController : Controller
{
    private readonly ILogger<DepartmentController> _logger;

    public DepartmentController(ILogger<DepartmentController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
       CatalogManager cat= new CatalogManager();
       List<Department> list= cat.GetAllDepartment();
    //    this.ViewData["dept"]=list;
       ViewBag.lt=list;
        return View();
    }

      public IActionResult Details(int id)
    {
       CatalogManager cat= new CatalogManager();
       Department detail_id= cat.GetDepartmentDetail(id);
       /* this.ViewData["dept"]=list; */
       ViewBag.abc=detail_id;
        return View();
    }

    [HttpGet]
     public IActionResult Insert()
    {
      
        return View();
       
    }
        [HttpPost]
         public IActionResult Insert(Department dept)
    {
       CatalogManager cat= new CatalogManager();
       cat.Insert(dept);
        return RedirectToAction("Index");
       
    }

        public IActionResult Delete(int  id)
    {
       CatalogManager cat= new CatalogManager();
       cat.Delete(id);
         return RedirectToAction("Index");
       
       
    }


    

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

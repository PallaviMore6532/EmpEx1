using EmpEx1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Security.Cryptography;

namespace EmpEx.Controllers
{

	public class HomeController : Controller
    {
        DemoContext context;
        public HomeController(DemoContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
			ViewBag.EName = new MultiSelectList(this.context.Emps.ToList(), "EmpID", "EmpName");
			return View(this.context.EmpEducations.ToList());
        }


        public IActionResult SearchbyName(Int64 EName=0)
        {
			ViewBag.EName = new MultiSelectList(this.context.Emps.ToList(), "EmpID", "EmpName");

            if(EName == 0)
            {
                var v=this.context.EmpEducations.ToList();
                return View("Index", v);
            }
            else
            {
                var v = this.context.EmpEducations.ToList().Where(p => p.Emp.EmpID==EName);
                return View("Index", v.ToList());
            }


		}
		[HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string EmpName, string[] CollegeName, string[] Field, int[] TotalMarks, int[] ObtainMarks, string[] standard)
        {
           
             
                Emp p1 = new Emp();
                p1.EmpName = EmpName;


                for (int i = 0; i<TotalMarks.Count(); i++)
                {

                    EmpEducation p = new EmpEducation();
                    p.CollegeName = CollegeName[i];
                    p.Field = Field[i];
                    p.TotalMarks = TotalMarks[i];
                    p.ObtainMarks = ObtainMarks[i];
                    p.standard=standard[i];
                    p1.EmpEducations.Add(p);


                }

                this.context.Emps.Add(p1);


                this.context.SaveChanges();
                return RedirectToAction("Index");
           

        }


        [HttpGet]
		public IActionResult Edit(Int64 id,Int64 eid)
		{
			HttpContext.Session.SetString("EmpID", eid.ToString());
			Int64 cid = Convert.ToInt64(HttpContext.Session.GetString("EmpID"));
			var v = this.context.EmpEducations.Find(id);
			return View(v);

			

		}

        [HttpPost]
        public IActionResult Edit(EmpEducation rec)
        {
            if (ModelState.IsValid)
            {
                this.context.Entry(rec).State=Microsoft.EntityFrameworkCore.EntityState.Modified;
                this.context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rec);

        }

		[HttpGet]
		public IActionResult Delete(Int64 id)
		{
			var v = this.context.EmpEducations.Find(id);
            this.context.EmpEducations.Remove(v);
            this.context.SaveChanges();
            return RedirectToAction("Index");

		}

		[HttpGet]
		public IActionResult Details(Int64 id)
		{
			var v = this.context.EmpEducations.Find(id);
            return View(v);

		}






	}

   
}

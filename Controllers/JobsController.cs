using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASPFinal.Controllers
{
	public class JobsController : Controller
	{
		// GET: JobsController
		public ActionResult Index()
		{
			return View();
		}

		// GET: JobsController/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: JobsController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: JobsController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: JobsController/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: JobsController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: JobsController/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: JobsController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}
	}
}

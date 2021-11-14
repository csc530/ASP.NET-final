using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASPFinal.Models;
using careerPortals.Data;
using Microsoft.AspNetCore.Authorization;

namespace ASPFinal.Controllers
{
	[Authorize("")]
	public class AccountsController : Controller
	{
		private readonly ApplicationDbContext _context;

		public AccountsController(ApplicationDbContext context)
		{
			_context = context;
		}

		// GET: Accounts
		[AllowAnonymous]
		public async Task<IActionResult> Index()
		{
			//puts accounts the own/created first then the rest
			List<Account> accounts = await _context.Accounts
				.Where(acc => acc.UserId == User.Identity.Name)
				.OrderBy(a => a.Name)
				.ToListAsync();
			accounts.AddRange(await _context.Accounts
				.Where(acc => acc.UserId != User.Identity.Name&&!acc.Client)
				.OrderBy(a => a.Name)
				.ToListAsync());
			return View(accounts);
		}

		// GET: Accounts/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if(id == null)
			{
				return NotFound();
			}

			var account = await _context.Accounts
				.FirstOrDefaultAsync(m => m.AccountId == id);
			if(account == null)
			{
				return NotFound();
			}

			return View(account);
		}

		// GET: Accounts/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: Accounts/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("AccountId,UserId,Name,Buisness,Description,Client")] Account account)
		{
			if(ModelState.IsValid)
			{
				_context.Add(account);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(account);
		}

		// GET: Accounts/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if(id == null)
			{
				return NotFound();
			}

			var account = await _context.Accounts.FindAsync(id);
			if(account == null)
			{
				return NotFound();
			}
			return View(account);
		}

		// POST: Accounts/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("AccountId,UserId,Name,Buisness,Client,Description")] Account account)
		{
			if(id != account.AccountId)
			{
				return NotFound();
			}

			if(ModelState.IsValid)
			{
				try
				{
					_context.Update(account);
					await _context.SaveChangesAsync();
				}
				catch(DbUpdateConcurrencyException)
				{
					if(!AccountExists(account.AccountId))
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}
				return RedirectToAction(nameof(Index));
			}
			return View(account);
		}

		// GET: Accounts/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if(id == null)
			{
				return NotFound();
			}

			var account = await _context.Accounts
				.FirstOrDefaultAsync(m => m.AccountId == id);
			if(account == null)
			{
				return NotFound();
			}

			return View(account);
		}

		// POST: Accounts/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var account = await _context.Accounts.FindAsync(id);
			_context.Accounts.Remove(account);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool AccountExists(int id)
		{
			return _context.Accounts.Any(e => e.AccountId == id);
		}
	}
}

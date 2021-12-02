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
    public class JobPostsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JobPostsController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: JobPosts
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.JobPosts.Include(j => j.Account).Include(j => j.JobStatus);
            return View("Index", await applicationDbContext.ToListAsync());
        }

        // GET: JobPosts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return View("404");
               // return NotFound();
            }

            var jobPost = await _context.JobPosts
                .Include(j => j.Account)
                .Include(j => j.JobStatus)
                .FirstOrDefaultAsync(m => m.JobPostId == id);
            if (jobPost == null)
            {
                return View("404");
               // return NotFound();
            }

            return View("Details", jobPost);
        }

        // GET: JobPosts/Create
        public IActionResult Create()
        {
            ViewData["AccountId"] = new SelectList(_context.Accounts.Where(a=>a.UserId==User.Identity.Name), "AccountId", "Name");
            ViewData["JobStatusId"] = new SelectList(_context.JobStatus, "JobStatusId", "Name");
            return View("Create");
        }

        // POST: JobPosts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("JobPostId,JobName,Description,JobStatusId,AccountId,AcceptedById")] JobPost jobPost)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jobPost);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AcceptedById"] = new SelectList(_context.Accounts, "AccountId", "Name", jobPost.AcceptedById);
            ViewData["AccountId"] = new SelectList(_context.Accounts.Where(a => a.UserId == User.Identity.Name), "AccountId", "Name", jobPost.AccountId);
            ViewData["JobStatusId"] = new SelectList(_context.JobStatus, "JobStatusId", "Name", jobPost.JobStatusId);
            return View("Create", jobPost);
        }

        // GET: JobPosts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return View("404");
                //return NotFound();
            }

            var jobPost = await _context.JobPosts.FindAsync(id);
            if (jobPost == null)
            {
                return View("404");
                //return NotFound();
            }
            ViewData["AcceptedById"] = new SelectList(_context.Accounts, "AccountId", "Name", jobPost.AcceptedById);
            ViewData["AccountId"] = new SelectList(_context.Accounts.Where(a=>a.UserId==User.Identity.Name), "AccountId", "Name", jobPost.AccountId);
            ViewData["JobStatusId"] = new SelectList(_context.JobStatus, "JobStatusId", "Name", jobPost.JobStatusId);
            return View("Edit", jobPost);
        }

        // POST: JobPosts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("JobPostId,JobName,Description,JobStatusId,AccountId,AcceptedById")] JobPost jobPost)
        {
            if (id != jobPost.JobPostId)
            {
                return View("404");
                //return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jobPost);
                    await _context.SaveChangesAsync();
                }
                //No code coverage for the below block as I can't replicate the DbUpdateConcurrencyException
                //And you said it's alright if I just skip it
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobPostExists(jobPost.JobPostId))
                    {
                        return View("404");
                        //return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AcceptedById"] = new SelectList(_context.Accounts, "AccountId", "Name", jobPost.AcceptedById);
            ViewData["AccountId"] = new SelectList(_context.Accounts.Where(a => a.UserId == User.Identity.Name), "AccountId", "Name", jobPost.AccountId);
            ViewData["JobStatusId"] = new SelectList(_context.JobStatus, "JobStatusId", "Name", jobPost.JobStatusId);
            return View("Edit", jobPost);
        }

        // GET: JobPosts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return View("404");
                //return NotFound();
            }

            var jobPost = await _context.JobPosts
                .Include(j => j.Account)
                .Include(j => j.JobStatus)
                .FirstOrDefaultAsync(m => m.JobPostId == id);
            if (jobPost == null)
            {
                return View("404");
                //return NotFound();
            }

            return View("Delete", jobPost);
        }

        // POST: JobPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jobPost = await _context.JobPosts.FindAsync(id);
            _context.JobPosts.Remove(jobPost);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //No test coverage because it is called within the catch of DBConcurrencyException handler
        private bool JobPostExists(int id)
        {
            return _context.JobPosts.Any(e => e.JobPostId == id);
        }
    }
}

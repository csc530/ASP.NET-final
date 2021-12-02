using System;
using System.Collections.Generic;
using ASPFinal.Controllers;
using ASPFinal.Models;
using careerPortals.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ASPTests
{
	[TestClass]
	public class JopPostsControllerTests
	{
		public ApplicationDbContext _context;
		public JobPostsController controller;
		List<JobPost> jobPosts;
		List<Account> accounts;
		JobStatus status = new JobStatus { Name = "open", JobStatusId = 0 };
		[TestInitialize]
		public void Initialize()

		{
			//setup in-memory databasw
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
				.UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
			_context = new ApplicationDbContext(options);
			//create mock data for tests
			accounts = new List<Account>{
				new Account{ AccountId=01,Description="plip xi ipsuu",Name="Thlisee",UserId="pop@fake.ia"},
				new Account{ AccountId=101,Description="xi ipsuu",Name="Esee",UserId="E.see@reallyreal.com"},
				new Account{ AccountId=21,Description="ipsuu",Name="Molly",UserId="nope@facemail.moc"},
				new Account{ AccountId=013,Description="Descriptionu aha haha",Name="Popadon",UserId="brampton@canada.ca"},
			};
			jobPosts = new List<JobPost>
			{
				new JobPost{JobStatus=status ,Account = accounts[0], Description="stuff", AccountId=accounts[0].AccountId,
					AcceptedBy=accounts[1],AcceptedById=accounts[1].AccountId, JobName="Help", JobPostId=1},
				new JobPost{JobStatus=status , Account = accounts[2], Description="I broke a vase please fix it", AccountId=accounts[2].AccountId,
					AcceptedBy=null,AcceptedById=null, JobName="Help me", JobPostId=21},
				new JobPost{JobStatus=status , Account = accounts[3], Description="Yea I need unit test for my college class please :)", AccountId=accounts[3].AccountId,
					AcceptedBy=accounts[2],AcceptedById=accounts[2].AccountId, JobName="Please fix this", JobPostId=13}
			};
			foreach(var acc in accounts)
				_context.Add(acc);
			_context.SaveChanges();
			foreach(var post in jobPosts)
				_context.Add(post);
			_context.SaveChanges();
			controller = new JobPostsController(_context);
		}
		#region Index
		[TestMethod]
		public void Index()
		{
			var result = (ViewResult)controller.Index().Result;
			Assert.AreEqual("Index", result.ViewName);
		}
		#endregion
		#region Details
		[TestMethod]
		public void NullDetailID()
		{
			var result = (ViewResult)controller.Details(null).Result;
			Assert.AreEqual("404", result.ViewName);
		}
		[TestMethod]
		public void InvalidDetailID()
		{
			var result = (ViewResult)controller.Details(-861).Result;
			Assert.AreEqual("404", result.ViewName);
		}
		[TestMethod]
		public void ValidDetailID()
		{
			var result = (ViewResult)controller.Details(001).Result;
			Assert.AreEqual("Details", result.ViewName);
		}
		#endregion
		#region Create
		[TestMethod]
		public void retrunsToView()
		{
			var result = (ViewResult)controller.Create();
			Assert.AreEqual("Create", result.ViewName);
		}
		[TestMethod]
		public void InvalidModel()
		{
			controller.ModelState.AddModelError("JobPost", "Invalid");
			var jobpost = new JobPost
			{
				Account = accounts[0],
				JobName = "Finish my test",
				JobStatus = status,
				AccountId = accounts[0].AccountId,
				Description = "Please finish my math test I'm at SWG",
				JobPostId = 101,
				JobStatusId = status.JobStatusId
			};
			var result = (ViewResult)controller.Create(jobpost).Result;
			Assert.AreEqual("Create", result.ViewName);
		}
		[TestMethod]
		public void ValidModelReturnView()
		{
			var jobpost = new JobPost
			{
				Account = accounts[0],
				JobName = "Finish my test",
				JobStatus = status,
				AccountId = accounts[0].AccountId,
				Description = "Please finish my math test I'm at SWG",
				JobPostId = 101,
				JobStatusId = status.JobStatusId
			};
			var result = (RedirectToActionResult)controller.Create(jobpost).Result;
			Assert.AreEqual("Index", result.ActionName);
		}

		[TestMethod]
		public void CreateRefleftedInDB()
		{
			var jobpost = new JobPost
			{
				Account = accounts[0],
				JobName = "Finish my test",
				JobStatus = status,
				AccountId = accounts[0].AccountId,
				Description = "Please finish my math test I'm at SWG",
				JobPostId = 101,
				JobStatusId = status.JobStatusId
			};
			_ = controller.Create(jobpost).Result;
			var result = _context.JobPosts.Find(jobpost.JobPostId);
			Assert.AreEqual(jobpost, result);
		}
		#endregion
		#region Edit
		[TestMethod]
		public void NullEditID()
		{
			var result = (ViewResult)controller.Edit(null).Result;
			Assert.AreEqual("404", result.ViewName);
		}
		[TestMethod]
		public void InvalidEditID()
		{
			var result = (ViewResult)controller.Edit(87861).Result;
			Assert.AreEqual("404", result.ViewName);
		}
		[TestMethod]
		public void ValidEditID()
		{
			var result = (ViewResult)controller.Edit(001).Result;
			Assert.AreEqual("Edit", result.ViewName);
		}
		#endregion
		#region Edit Post
		[TestMethod]
		public void NonMatchingEditIDs()
		{
			var result = (ViewResult)controller.Edit(-541, jobPosts[0]).Result;
			Assert.AreEqual("404", result.ViewName);
		}
		[TestMethod]
		public void InvalidEditModel()
		{
			controller.ModelState.AddModelError("Invalid", "JobPost model after edit is invalid");
			var result = (ViewResult)controller.Edit(jobPosts[0].JobPostId,jobPosts[0]).Result;
			Assert.AreEqual("Edit", result.ViewName);
		}
		[TestMethod]
		public void ValidEdit()
		{
			var result = (RedirectToActionResult)controller.Edit(jobPosts[0].JobPostId, jobPosts[0]).Result;
			Assert.AreEqual("Index", result.ActionName);
		}
		[TestMethod]
		public void EditReflectedInDB()
		{
			var jobpost = jobPosts[1];
			jobpost.Description = "Changed";
			jobpost.JobName = "New Changed Job";
			var _ = controller.Edit(jobpost.JobPostId, jobpost);
			var result = _context.JobPosts.Find(jobpost.JobPostId);
			Assert.AreEqual(jobpost, result);

		}
/**		[TestMethod]
		public void DBConcurrencyExceptionHandled()
		{
			jobPosts[0].JobName = "A new Changed name";
			_context.Add(jobPosts[0]);
//unwaited 
			controller.Edit(jobPosts[0].JobPostId, jobPosts[0]);
			_context.SaveChanges();
			jobPosts[0].JobName = "A better changed name because I chnaged my mind";
			var result = (ViewResult)controller.Edit(jobPosts[0].JobPostId, jobPosts[0]).Result;
			Assert.AreEqual("404",result.ViewName);
		}
**/
		#endregion
		#region Delete
		[TestMethod]
		public void NullDeleteID()
		{
			var result = (ViewResult)controller.Delete(null).Result;
			Assert.AreEqual("404", result.ViewName);
		}
		[TestMethod]
		public void InvalidDeleteID()
		{
			var result = (ViewResult)controller.Delete(916615188).Result;
			Assert.AreEqual("404", result.ViewName);
		}
		[TestMethod]
		public void ValidDeleteID()
		{
			var result = (ViewResult)controller.Delete(1).Result;
			Assert.AreEqual("Delete", result.ViewName);
		}
		[TestMethod]
		public void DeleteReflectedInDB()
		{
			var _ = controller.DeleteConfirmed(1);
			var result =  _context.JobPosts.Find(1);
			Assert.AreEqual(null, result);
		}
		#endregion

	}
}

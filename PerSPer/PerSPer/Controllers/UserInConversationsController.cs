using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PerSPer.Models;
using Microsoft.AspNet.Identity;

namespace PerSPer.Controllers
{
    [Authorize]
    public class UserInConversationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: UserInConversations
        public ActionResult Index(int ConversationId)
        {
            var usersInConversations = db.UsersInConversations.Where(c=>c.ConversationId==ConversationId).Include(u => u.ApplicationUser).Include(u => u.Conversation);
            ViewBag.ConversationId = ConversationId;
            
            return View(usersInConversations.ToList());
        }

        
        // GET: UserInConversations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserInConversation userInConversation = db.UsersInConversations.Find(id);
            if (userInConversation == null)
            {
                return HttpNotFound();
            }
            return View(userInConversation);
        }

        // GET: UserInConversations/Create
        public ActionResult Create(int ConversationId)
        {
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email");
            ViewBag.ConversationId = ConversationId;
            return View();
        }

        // POST: UserInConversations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Owner,ConversationId,UserId")] UserInConversation userInConversation)
        {
            if (ModelState.IsValid)
            {
                db.UsersInConversations.Add(userInConversation);
                db.SaveChanges();
                return RedirectToAction("Index", new { ConversationId = userInConversation.ConversationId});
            }

            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", userInConversation.UserId);
            ViewBag.ConversationId = new SelectList(db.Conversations, "Id", "Name", userInConversation.ConversationId);
            return View(userInConversation);
        }

        // GET: UserInConversations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserInConversation userInConversation = db.UsersInConversations.Find(id);
            if (userInConversation == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", userInConversation.UserId);
            ViewBag.ConversationId = new SelectList(db.Conversations, "Id", "Name", userInConversation.ConversationId);
            return View(userInConversation);
        }

        // POST: UserInConversations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Owner,ConversationId,UserId")] UserInConversation userInConversation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userInConversation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { ConversationId = userInConversation.ConversationId });
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", userInConversation.UserId);
            ViewBag.ConversationId = new SelectList(db.Conversations, "Id", "Name", userInConversation.ConversationId);
            return View(userInConversation);
        }

        // GET: UserInConversations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserInConversation userInConversation = db.UsersInConversations.Find(id);
            if (userInConversation == null)
            {
                return HttpNotFound();
            }
            return View(userInConversation);
        }

        // POST: UserInConversations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserInConversation userInConversation = db.UsersInConversations.Find(id);
            db.UsersInConversations.Remove(userInConversation);
            db.SaveChanges();
            return RedirectToAction("Index", new { ConversationId = userInConversation.ConversationId });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

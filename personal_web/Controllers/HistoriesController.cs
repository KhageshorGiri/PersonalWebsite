using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using personal_web.Iterfaces;
using personal_web.Model_Context;
using personal_web.Models;
using personal_web.Reositories;

namespace personal_web.Controllers
{
    public class HistoriesController : Controller
    {
        private readonly IHistory historyRepository;

        public HistoriesController()
        {
            this.historyRepository = new IHistoryRepository(new PersonalWeb_context());
        }

        // GET: Histories
        public ActionResult Index()
        {
            return View(historyRepository.GetHistories());
        }


        // GET: Histories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Histories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HistoryID,Description")] History history)
        {
            if (ModelState.IsValid)
            {
                historyRepository.CreateHistory(history);
                return RedirectToAction("create");
            }

            return View(history);
        }

        // GET: Histories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            History history = historyRepository.GetHistory(Convert.ToInt32(id));
            if (history == null)
            {
                return HttpNotFound();
            }
            return View(history);
        }

        // POST: Histories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HistoryID,Description")] History history)
        {
            if (ModelState.IsValid)
            {
                historyRepository.UpdateHistory(history);
                return RedirectToAction("create");
            }
            return View(history);
        }

        // GET: Histories/Delete/5
        public ActionResult Delete(int? id)
        {
            History history = historyRepository.GetHistory(Convert.ToInt32(id));
            if (history == null)
            {
                return HttpNotFound();
            }
            historyRepository.DeleteHistory(history);
            return RedirectToAction("create");
        }

        
    }
}

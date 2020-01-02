using SuperHeroStories.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperHeroStories.Controllers
{
    public class SuperHeroController : Controller
    {
        ApplicationDbContext context;
        public SuperHeroController()
        {
            context = new ApplicationDbContext();
        }
        // GET: SuperHero
        public ActionResult Index()
        {

            return View(context.People.ToList());
        }

        // GET: SuperHero/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SuperHero/Create
        public ActionResult Create()
        {
            SuperHero superhero = new SuperHero();
            return View(superhero);
        }

        // POST: SuperHero/Create
        [HttpPost]
        public ActionResult Create(SuperHero superHero)
        {
            try
            {
                // TODO: Add insert logic here
                context.People.Add(superHero);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SuperHero/Edit/5
        public ActionResult Edit(int id)
        {
            SuperHero superHero = context.People.Where(e => e.Id == id).FirstOrDefault();
            return View(superHero);
        }

        // POST: SuperHero/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, SuperHero superHero)
        {
            try
            {

                // TODO: Add update logic here
                SuperHero superHeroToUpdate = context.People.Find(id);
                superHeroToUpdate.AlterEgo = superHero.AlterEgo;
                superHeroToUpdate.CatchPhrase = superHero.CatchPhrase;
                superHeroToUpdate.PrimaryAbility = superHero.PrimaryAbility;
                superHeroToUpdate.SecondaryAbility = superHero.SecondaryAbility;
                superHeroToUpdate.SuperHeroName = superHero.SuperHeroName;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SuperHero/Delete/5
        public ActionResult Delete(int id)
        {
            SuperHero superHero = context.People.Find(id);
            return View(superHero);
        }

        // POST: SuperHero/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, SuperHero superHero)
        {
            try
            {
                // TODO: Add delete logic here
                SuperHero super = context.People.Find(id);
                context.People.Remove(super);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

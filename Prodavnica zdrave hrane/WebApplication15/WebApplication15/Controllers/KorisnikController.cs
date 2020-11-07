using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication15.Models;
using System.Data.Entity;

namespace WebApplication15.Controllers
{
    public class KorisnikController : Controller
    {
        // GET: Korisnik
        public ActionResult AddOrEdit(int id=0)
        {
            Korisnik korisnik = new Korisnik();
            return View(korisnik);
        }
        [HttpPost]
        public ActionResult AddOrEdit(Korisnik korisnik)
        {
            using(ProdavnicaEntities db=new ProdavnicaEntities())
            {
                if (db.Korisniks.Any(x => x.Gmail == korisnik.Gmail))
                {
                    ViewBag.DuplicateMessage = "Korisnik vec postoji";
                    return View("AddOrEdit", korisnik);
                }
                else

                {
                    korisnik.Racun = 0;
                    db.Korisniks.Add(korisnik);
                    db.SaveChanges();
                }
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Registracija uspesna";
            return View("AddOrEdit", new Korisnik());
        }
        [HttpGet]
        public ActionResult Login()
        {

            Korisnik korisnik = new Korisnik();
            return View(korisnik);
        }
        [HttpPost]
        public ActionResult Login(Korisnik korisnik)
        {
            using(ProdavnicaEntities db=new ProdavnicaEntities())
            {
                var korisnikDetails = db.Korisniks.Where(x => x.Gmail == korisnik.Gmail && x.Password == korisnik.Password).FirstOrDefault();
                string admin = "stefan@gmail.com";
                if (korisnikDetails == null)
                {
                    ViewBag.ErrorLogin = "Pogresna email adresa ili password";
                    return View("Login", korisnik);
                }
                else if(admin==korisnik.Gmail)
                {
                    
                    Session["Ime"] = korisnikDetails.Ime;
                    Session["KorisnikID"] = korisnikDetails.KorisnikID;
                    Session["Prezime"] = korisnikDetails.Prezime;
                    Session["Gmail"] = korisnikDetails.Gmail;
                    Session["Racun"] = korisnikDetails.Racun;
                    Session["Password"] = korisnikDetails.Password;
                    return RedirectToAction("AdminProdavnica", "Proizvod");
                }
                else
                {
                    // Session["KorisnikID,Ime,Prezime,Gmail,Racun,Password"] = korisnikDetails.ToString();
                    Session["korpa"] = null;
                    Session["Ime"] = korisnikDetails.Ime;
                    Session["KorisnikID"] = korisnikDetails.KorisnikID;
                    Session["Prezime"] = korisnikDetails.Prezime;
                    Session["Gmail"] = korisnikDetails.Gmail;
                    Session["Racun"] = korisnikDetails.Racun;
                    Session["Password"] = korisnikDetails.Password;
                    return RedirectToAction("Index", "Proizvod");
                }
            }
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login", "Korisnik");
        }
        public ActionResult Edit(int id , int racun)
        {
            using(ProdavnicaEntities db=new ProdavnicaEntities())
            {
                return View(db.Korisniks.Where(x => x.KorisnikID == id).FirstOrDefault());
            }
        }
        [HttpPost]
        public ActionResult Edit(int id , Korisnik korisnik)
        {
            try
            {
                using(ProdavnicaEntities db=new ProdavnicaEntities())
                {
                    
                    db.Entry(korisnik).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Login");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Korisnici(string searching, string SortOrder)
        {
            using (ProdavnicaEntities db = new ProdavnicaEntities())
            {
                return View(db.Korisniks.Where(x => x.Ime.Contains(searching) || searching == null).ToList());
            }
        }
        public ActionResult Edit1(int id, int racun)
        {
            using (ProdavnicaEntities db = new ProdavnicaEntities())
            {
                return View(db.Korisniks.Where(x => x.KorisnikID == id).FirstOrDefault());
            }
        }
        [HttpPost]
        public ActionResult Edit1(int id, Korisnik korisnik)
        {
            try
            {
                using (ProdavnicaEntities db = new ProdavnicaEntities())
                {

                    db.Entry(korisnik).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Korisnici");
            }
            catch
            {
                return View();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication15.Models;
using System.Data.Entity;
using System.IO;

namespace WebApplication15.Controllers
{
    public class ProizvodController : Controller
    {
        // GET: Proizvod
        public ActionResult Index(string searching,string SortOrder)
        {
            using(ProdavnicaEntities db=new ProdavnicaEntities())
            {
                return View(db.ProdavnicaProizvodis.Where(x => x.Ime.Contains(searching) || searching == null).ToList());
            }
        }
        public ActionResult AdminProdavnica(string searching, string SortOrder)
        {
            using (ProdavnicaEntities db = new ProdavnicaEntities())
            {
                return View(db.ProdavnicaProizvodis.Where(x => x.Ime.Contains(searching) || searching == null).ToList());
            }
        }
        public ActionResult AdminMagacin(string searching, string SortOrder)
        {
            using (ProdavnicaEntities db = new ProdavnicaEntities())
            {
                return View(db.MagacinProizvodis.Where(x => x.Ime.Contains(searching) || searching == null).ToList());
            }
        }
        public ActionResult Lista(string searching, string SortOrder)
        {
            using (ProdavnicaEntities db = new ProdavnicaEntities())
            {
                return View(db.ProdavnicaProizvodis.Where(x => x.Ime.Contains(searching) || searching == null).ToList());
            }
        }
        public ActionResult Lista2(string searching, string SortOrder)
        {
            using (ProdavnicaEntities db = new ProdavnicaEntities())
            {
                return View(db.ProdavnicaProizvodis.Where(x => x.Ime.Contains(searching) || searching == null).ToList());
            }
        }
        public ActionResult Create()
        {
            
                return View();
            
        }
        [HttpPost]
        public ActionResult Create(ProdavnicaProizvodi proizvod)
        {
            try
            {
                using(ProdavnicaEntities db=new ProdavnicaEntities())
                {
                    db.ProdavnicaProizvodis.Add(proizvod);
                    db.SaveChanges();
                }
                return RedirectToAction("AdminProdavnica");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Edit(int id)
        {
            using(ProdavnicaEntities db=new ProdavnicaEntities())
            {
                return View(db.ProdavnicaProizvodis.Where(x=>x.ProizvodID==id).FirstOrDefault());
            }
        }
        [HttpPost]
        public ActionResult Edit(int id,ProdavnicaProizvodi proizvodi)
        {
            try
            {
                using(ProdavnicaEntities db=new ProdavnicaEntities())
                {
                    db.Entry(proizvodi).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("AdminProdavnica");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Delete(int id)
        {
            using (ProdavnicaEntities db=new ProdavnicaEntities())
            {
                return View(db.ProdavnicaProizvodis.Where(x => x.ProizvodID == id).FirstOrDefault());
            }
        }
        [HttpPost]
        public ActionResult Delete(int id,FormCollection collection)
        {
            try
            {
                using(ProdavnicaEntities db=new ProdavnicaEntities())
                {
                    ProdavnicaProizvodi proizvod = db.ProdavnicaProizvodis.Where(x => x.ProizvodID == id).FirstOrDefault();
                    db.ProdavnicaProizvodis.Remove(proizvod);
                    db.SaveChanges();
                }
                return RedirectToAction("AdminProdavnica");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult CreateMagacin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateMagacin(MagacinProizvodi proizvod)
        {
            try
            {
                using (ProdavnicaEntities db = new ProdavnicaEntities())
                {
                    db.MagacinProizvodis.Add(proizvod);
                    db.SaveChanges();
                }
                return RedirectToAction("AdminMagacin");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult EditMagacin(int id)
        {
            using (ProdavnicaEntities db = new ProdavnicaEntities())
            {
                return View(db.MagacinProizvodis.Where(x => x.ProizvodID == id).FirstOrDefault());
            }
        }
        [HttpPost]
        public ActionResult EditMagacin(int id, MagacinProizvodi proizvodi)
        {
            try
            {
                using (ProdavnicaEntities db = new ProdavnicaEntities())
                {
                    db.Entry(proizvodi).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("AdminMagacin");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult DeleteMagacin(int id)
        {
            using (ProdavnicaEntities db = new ProdavnicaEntities())
            {
                return View(db.MagacinProizvodis.Where(x => x.ProizvodID == id).FirstOrDefault());
            }
        }
        [HttpPost]
        public ActionResult DeleteMagacin(int id, FormCollection collection)
        {
            try
            {
                using (ProdavnicaEntities db = new ProdavnicaEntities())
                {
                    MagacinProizvodi proizvod = db.MagacinProizvodis.Where(x => x.ProizvodID == id).FirstOrDefault();
                    db.MagacinProizvodis.Remove(proizvod);
                    db.SaveChanges();
                }
                return RedirectToAction("AdminMagacin");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Prebaci(int id)
        {
            using (ProdavnicaEntities db = new ProdavnicaEntities())
            {
                return View(db.MagacinProizvodis.Where(x => x.ProizvodID == id).FirstOrDefault());
            }
        }
        [HttpPost]
        public ActionResult Prebaci(int id, ProdavnicaProizvodi proizvodi)
        {
            try
            {
                using (ProdavnicaEntities db = new ProdavnicaEntities())
                {
                    db.ProdavnicaProizvodis.Add(proizvodi);
                    db.SaveChanges();
                    MagacinProizvodi proizvod = db.MagacinProizvodis.Where(x => x.ProizvodID == id).FirstOrDefault();
                    db.MagacinProizvodis.Remove(proizvod);
                    db.SaveChanges();
                }

                return RedirectToAction("AdminMagacin");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Dobavljac()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Dobavljac(string text)
        {
            string path = Server.MapPath("~/Dobavljac/Dobavljac.txt");
            using (StreamWriter sw = System.IO.File.CreateText(path))
            {
                sw.WriteLine(text);
            }
            return RedirectToAction("AdminProdavnica");
        }
        public ActionResult PorukaAdminu()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PorukaAdminu(string text)
        {
            string path = Server.MapPath("~/Dobavljac/KorisniciPoruke.txt");
            string line = "--------------------------------------";
            using (StreamWriter sw = System.IO.File.AppendText(path))
            {
                sw.WriteLine(line);
                sw.WriteLine(text);
            }
            return RedirectToAction("Index");
        }

    }
}
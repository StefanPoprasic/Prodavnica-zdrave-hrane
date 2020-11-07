using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication15.Models;
using System.Data.Entity;

namespace WebApplication15.Controllers
{
    public class KorpaController : Controller
    {
        // GET: Korpa
        ProdavnicaEntities db = new ProdavnicaEntities();
        public ActionResult Index()
        {
            return View();
        }
        private int Postoji(int id)
        {
            List<Item> korpa = (List<Item>)Session["korpa"];
            for (int i = 0; i < korpa.Count; i++)
                if (korpa[i].Proizvodi.ProizvodID == id)
                    return i;
            return -1;
        }
        public ActionResult Izbaci(int id)
        {
            int index = Postoji(id);
            List<Item> korpa = (List<Item>)Session["korpa"];
            korpa.RemoveAt(index);
            Session["korpa"] = korpa;
            return View("Cart");
        }
        
        public ActionResult Kupi(int id)
        {
           
            if (Session["korpa"] == null)
            {
                List<Item> korpa = new List<Item>();
                korpa.Add(new Item(db.ProdavnicaProizvodis.Find(id), 1));
                Session["korpa"] = korpa;
               
            }
            else
            {
                List<Item> korpa = (List<Item>)Session["korpa"];
                int index = Postoji(id);
                if (index == -1)
                    korpa.Add(new Item(db.ProdavnicaProizvodis.Find(id), 1));
                else
                    korpa[index].Kolicina++;
                Session["korpa"] = korpa;
                
                
            }
            return View("Cart");
            
        }
    }
}
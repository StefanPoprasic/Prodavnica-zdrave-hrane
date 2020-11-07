using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication15.Models;

namespace WebApplication15.Controllers
{
    public class Item
    {
        private Korisnik korisnik = new Korisnik();
        private ProdavnicaProizvodi proizvod = new ProdavnicaProizvodi();
        private int kolicina;
        public ProdavnicaProizvodi Proizvodi { get => proizvod; set => proizvod = value; }
        public Korisnik korisnici { get => korisnik; set => korisnik = value; }
        public int Kolicina { get => kolicina; set => kolicina = value; }
        
        public Item()
        {

        }
        public Item(ProdavnicaProizvodi proizvod,int kolicina)
        {
            
            this.proizvod=proizvod;
            this.kolicina = kolicina;
            
        }
    }
}
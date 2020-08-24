using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InstagramTutorialWebApi.Models
{
    public class Kullanici
    {
        public int Id { get; set; }
        public string KullaniciAd { get; set; }
        public string Sifre { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Mail { get; set; }
        public string Profil { get; set; }



    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InstagramTutorialWebApi.Models
{
    public class Gonderi
    {
        public int Id { get; set; }

        public int KullaniciId { get; set; }

        public string Resim { get; set; }
        public string Aciklama { get; set; }

        public string Tarih { get; set; }
    }
}
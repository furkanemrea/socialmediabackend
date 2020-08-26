using InstagramTutorialWebApi.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InstagramTutorialWebApi.Controllers
{
    public class PostsController : ApiController
    {
        public HttpResponseMessage Get()
        {
            DataTable dt = new DataTable();
            string query = @"select Kullanici.Ad,Kullanici.Soyad,Kullanici.Profil,Kullanici.KullaniciAd,Gonderi.Resim,Gonderi.Aciklama,Gonderi.Tarih,Gonderi.Begeni from Gonderi inner join Kullanici on Gonderi.KullaniciId=Kullanici.Id";

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["InstaProject"].ConnectionString);
            var command = new SqlCommand(query, con);

            using (var da = new SqlDataAdapter(command))
            {
                command.CommandType = CommandType.Text;
                da.Fill(dt);
            }
            return Request.CreateResponse(HttpStatusCode.OK, dt);

        }
        public string Post(Gonderi gonderi)
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["InstaProject"].ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into Gonderi (KullaniciId,Resim,Aciklama,Tarih,Begeni) values (@p1,@p2,@p3,@p4,0)", con);
                cmd.Parameters.AddWithValue("@p1", gonderi.KullaniciId);
                cmd.Parameters.AddWithValue("@p2", gonderi.Resim);
                cmd.Parameters.AddWithValue("@p3", gonderi.Aciklama);
                cmd.Parameters.AddWithValue("@p4", DateTime.Now.ToShortDateString());
                
                cmd.ExecuteNonQuery();
                return "Added";

            }
            catch (Exception)
            {

                return "Error";
            }
          

        }
    }
}

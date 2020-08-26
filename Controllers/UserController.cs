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
    public class UserController : ApiController
    {
        public HttpResponseMessage Get(int Id)
        {
            DataTable dt = new DataTable();
            string query = @"select * from Kullanici where Id="+Id;

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["InstaProject"].ConnectionString);
            var command = new SqlCommand(query, con);

            using (var da = new SqlDataAdapter(command))
            {
                command.CommandType = CommandType.Text;
                da.Fill(dt);
            }
            return Request.CreateResponse(HttpStatusCode.OK, dt);
        }
        public string Post(Kullanici kullanici)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["InstaProject"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Kullanici where KullaniciAd='" + kullanici.KullaniciAd + "' and Sifre='" + kullanici.Sifre + "'", con);

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
                return  "Added Succesfully"; 
               
            }
            else
            {
                con.Close();
                return  "Add operation failed"; 
               
            }





            //using (var da = new SqlDataAdapter(command))
            //{
            //    command.CommandType = CommandType.Text;
            //    da.Fill(dt);
            //}


        }
    }
}

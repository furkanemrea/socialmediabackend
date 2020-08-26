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
    public class ValuesController : ApiController
    {
        // GET api/values
        public HttpResponseMessage Get()
        {
            DataTable dt = new DataTable();
            string query = @"select * from Kullanici";

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["InstaProject"].ConnectionString);
            var command = new SqlCommand(query, con);

            using (var da = new SqlDataAdapter(command))
            {
                command.CommandType = CommandType.Text;
                da.Fill(dt);
            }
            return Request.CreateResponse(HttpStatusCode.OK, dt);

        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public string Post(Kullanici user)
        {
            try
            {
                DataTable table = new DataTable();



                string query = @"insert into Kullanici (KullaniciAd,Sifre,Ad,Soyad,Mail,Profil) values (
            '" + user.KullaniciAd + @"',
            '" + user.Sifre + @"',
            '" + user.Ad + @"',
            '" + user.Soyad + @"',
            '" + user.Mail + @"',
            '" + user.Profil + @"')";




                var con = new SqlConnection(ConfigurationManager.ConnectionStrings["InstaProject"].ConnectionString);
                var command = new SqlCommand(query, con);

                using (var da = new SqlDataAdapter(command))
                {
                    command.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Added succesfully";
            }
            catch (Exception ex)
            {

                return "Failed to add" + ex.Message;
            }

        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}

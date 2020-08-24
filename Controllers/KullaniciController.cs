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
    public class KullaniciController : ApiController
    {
        HttpResponseMessage Get()
        {
            DataTable dt = new DataTable();
            string query = @"select * from Kullanici";

            var con = new SqlConnection(ConfigurationManager.ConnectionStrings["InstaProject"].ConnectionString);
            var command = new SqlCommand(query, con);

            using (var da = new SqlDataAdapter(command))
            {
                command.CommandType = CommandType.Text;
                da.Fill(dt);
            }
            return Request.CreateResponse(HttpStatusCode.OK, dt);

        }
       
    }
}

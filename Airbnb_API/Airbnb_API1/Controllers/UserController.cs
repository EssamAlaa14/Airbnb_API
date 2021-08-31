using Airbnb_API1.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Airbnb_API1.Controllers
{
    public class UserController : ApiController
    {
        //airbnbDB
        public HttpResponseMessage Get()
        {
            string query = @" select
       *
 from
                    dbo.Users
                    ";
            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.
                ConnectionStrings["airbnbDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);


        }

        public string Post(User user)
        {
            try
            {
                string query = @"
                      insert into dbo.users values
                    (
                    '" +user.User_Fname + @"'
                    ,'" + user.User_Lname + @"'
                    ,'"+user.Age+@"'
                    ,'" + user.User_Email + @"'
                    ,'" + user.User_Password + @"'
                    ,'" + user.User_Phone + @"'
                    ,'" + user.User_type + @"'
                    )
                    ";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["airbnbDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Added Successfully!!";
            }
            catch (Exception)
            {

                return "Failed to Add!!";
            }
        }


        public string Put(User user )
        {
            try
            {
                //'" +user.User_Fname + @"'
                //    ,'" + user.User_Lname + @"'
                //    ,'"+user.Age+@"'
                //    ,'" + user.User_Email + @"'
                //    ,'" + user.User_Password + @"'
                //    ,'" + user.User_Phone + @"'
                //    ,'" + user.User_type + @"'
                //    )
                //    ";

                string query = @"
                    update dbo.users set 
                    User_Fname='" +user.User_Fname + @"'
                   , User_Lname='" +user.User_Lname +@"'
                    ,Age='" + user.Age +@"'
                    ,User_Email='" + user.User_Email +@"'
                    ,User_Password='" + user.User_Password +@"'
                    ,User_Phone='" + user.User_Phone +@"'
                    ,User_type='" + user.User_type  +@"'
                    
                    where UserID=" + user.UserID + @"

                    ";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["airbnbDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Updated Successfully!!";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);


                return "Failed to Update!!";
            }
        }


        public string Delete(int id)
        {
            try
            {
                string query = @"
                    delete from dbo.users 
                    where UserID=" + id + @"
                    ";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["airbnbDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Deleted Successfully!!";
            }
            catch (Exception)
            {

                return "Failed to Delete!!";
            }

        }
        [Route("api/User/SaveFile")]
        public string SaveFile()
        {
            try
            {
                var httpRequest = HttpContext.Current.Request;
                var postedFile = httpRequest.Files[0];
                string filename = postedFile.FileName;
                var physicalPath = HttpContext.Current.Server.MapPath("~/assets/" + filename);

                postedFile.SaveAs(physicalPath);
                

                return filename;
            }
            catch (Exception)
            {

                return "anonymous.png";
            }
        }

    }
}

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
    public class LocationController : ApiController
    {
        //api/location
        public HttpResponseMessage Get()
        {
            string query = @"
                   select Location_Number,Loc_address,Location_Des,Location_Price,Loc_type,Loc_startdate
,Loc_enddate,Location_IS_Reserved,Loc_longtiute,Loc_latitude,User_ID,City_ID,Country_ID from dbo.Locations
                    ";
            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.
                ConnectionStrings["AirbnbDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);


        }

        public string Post(Location loc)
        {
            try
            {
                string query = @"
                      insert into dbo.users values
                    (
                    '" + loc.Location_Number + @"'
                    ,'" + loc.Loc_address + @"'
                    ,'" + loc.Location_Des + @"'
                    ,'" + loc.Location_Price + @"'
                    ,'" + loc.Loc_type + @"'
                    ,'" + loc.Loc_startdate + @"'
                    ,'" + loc.Loc_enddate + @"'
                    ,'" + loc.Location_IS_Reserved + @"'
                    ,'" + loc.Loc_longtiute + @"'
                    ,'" + loc.Loc_latitude + @"'
                    ,'" + loc.User_ID + @"'
                    ,'" + loc.City_ID + @"'
                    ,'" + loc.Country_ID + @"'
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


        public string Put(Location loc)
        {
            try
            {
                //'" + loc.Location_Number + @"'
                //    ,'" + loc.Loc_address + @"'
                //    ,'" + loc.Location_Des + @"'
                //    ,'" + loc.Location_Price + @"'
                //    ,'" + loc.Loc_type + @"'
                //    ,'" + loc.Loc_startdate + @"'
                //    ,'" + loc.Loc_enddate + @"'
                //    ,'" + loc.Location_IS_Reserved + @"'
                //    ,'" + loc.Loc_longtiute + @"'
                //    ,'" + loc.Loc_latitude + @"'
                //    ,'" + loc.User_ID + @"'
                //    ,'" + loc.City_ID + @"'
                //    ,'" + loc.Country_ID + @"'

                string query = @"
                    update dbo.Locations set 
                   Location_Number ='" + loc.Location_Number + @"'
                    ,Loc_address='" + loc.Loc_address + @"'
                    ,Location_Des='" + loc.Location_Des + @"'
                    ,Location_Price='" + loc.Location_Price + @"'
                    ,Loc_type='" + loc.Loc_type + @"'
                    ,Loc_startdate='" + loc.Loc_startdate + @"'
                    ,Loc_enddate='" + loc.Loc_enddate + @"'
                    ,Location_IS_Reserved='" + loc.Location_IS_Reserved + @"'
                    ,Loc_longtiute='" + loc.Loc_longtiute + @"'
                    ,Loc_latitude='" + loc.Loc_latitude + @"'
                    ,User_ID='" + loc.User_ID + @"'
                    ,City_ID'" + loc.City_ID + @"'
                    ,Country_ID='" + loc.Country_ID + @"";

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
            catch (Exception)
            {

                return "Failed to Update!!";
            }
        }


        public string Delete(int id)
        {
            try
            {
                string query = @"
                    delete from dbo.Locations 
                    where Loc_ID=" + id + @"
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
        [Route("api/Location/SaveFile")]
        public string SaveFile()
        {
            try
            {
                var httpRequest = HttpContext.Current.Request;
                var postedFile = httpRequest.Files[0];
                string filename = postedFile.FileName;
                var physicalPath = HttpContext.Current.Server.MapPath("~/LocAssets/" + filename);

                postedFile.SaveAs(physicalPath);


                return filename;
            }
            catch (Exception)
            {

                return "anonymous.png";
            }

        }

        [Route("api/Location/Search")]
        [HttpGet]
        public DataTable search(int p,string t,string c)
        {
            
            string query = @"
                   select * from Locations l
                 inner join Countries c on l.Country_ID =c.Country_ID
                        where Location_Price='" + p + @"' 
                        and  Loc_type='" + t+ @"'
                     and c.County_name='"+c+@"'"
                        ;
            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.
                ConnectionStrings["AirbnbDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }

            return  table;


        }
    }
}

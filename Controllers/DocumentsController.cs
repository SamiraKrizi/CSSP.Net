using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using CbcSelfServicePortal.Models;

namespace CbcSelfServicePortal.Controllers
{
    public class DocumentsController : ApiController
    {


        [HttpPost]
        [Route("api/UploadFile")]
        public async Task<string> UploadFile()
        {
            var ctx = HttpContext.Current;
            var root = ctx.Server.MapPath("~/App_Data");
            var provider =
                new MultipartFormDataStreamProvider(root);

            try
            {
                await Request.Content
                    .ReadAsMultipartAsync(provider);

                foreach (var file in provider.FileData)
                {
                    var name = file.Headers
                        .ContentDisposition
                        .FileName;

                    // remove double quotes from string.
                    name = name.Trim('"');

                    var localFileName = file.LocalFileName;
                    var filePath = Path.Combine(
                        root, "files", name);

                    //File.Move(localFileName, filePath);

                    //SaveFilePathSQLServerADO(localFileName, filePath);
                    //SaveFileBinarySQLServerADO(localFileName, name);

                    //SaveFilePathSQLServerEF(localFileName, filePath)

                    SaveFileBinarySQLServerEF(localFileName, name);

                    if (File.Exists(localFileName))
                        File.Delete(localFileName);
                }
            }
            catch (Exception e)
            {
                return $"Error: {e.Message}";
            }

            return "File uploaded!";
        }

        #region ADO.NET
        private void SaveFilePathSQLServerADO(
             string localFile, string filePath)
        {
            // 1) Move file to folder
            File.Move(localFile, filePath);

            // 2) connection string
            var connStr =
                "Data Source=DESKTOP-IMMM0G3;" +
                "Initial Catalog=CSSP;" +
                "Integrated Security=true;";

            // 3) Insert in DB
            var query =
                "Insert into Documents(Type, Size ,File) " +
                "values (@Type, @Size, @File);";

            using (var conn = new SqlConnection(connStr))
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.Add(
                    "@FilePath",
                    SqlDbType.VarChar,
                    200)
                    .Value = filePath;

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
        private void SaveFileBinarySQLServerADO(
            string localFile, string fileName)
        {
            // 1) Get file binary
            byte[] fileBytes;
            using (var fs = new FileStream(
                localFile, FileMode.Open, FileAccess.Read))
            {
                fileBytes = new byte[fs.Length];
                fs.Read(
                    fileBytes, 0, Convert.ToInt32(fs.Length));
            }

            // 2) connection string
            var connStr =
                "Data Source=DESKTOP-IMMM0G3;" +
                "Initial Catalog=CSSP;" +
                "Integrated Security=true;";

            // 3) Insert in DB
            var query =
                "Insert into Documents(Type, Size ,File) " +
                "values (@Type, @Size, @File);";

            using (var conn = new SqlConnection(connStr))
            using (var cmd = new SqlCommand(query, conn))
            {

                cmd.Parameters.Add(
                  "@Type",
                  SqlDbType.VarChar, 50)
                  .Value = fileName;

                cmd.Parameters.Add(
                    "@Size",
                    SqlDbType.Int)
                    .Value = fileBytes.Length;

                cmd.Parameters.Add(
                    "@File",
                    SqlDbType.VarBinary)
                    .Value = fileBytes;

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
        #endregion

        #region Entity Framework
        private void SaveFilePathSQLServerEF(
            string localFile, string filePath)
        {
            // 1) Move file to folder
            File.Move(localFile, filePath);

            // 2) Create a File Location object
            var fl = new Documents()
            {
                // FilePath = filePath
            };

            // 3) Add and save it in database
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Documents.Add(fl);

                ctx.SaveChanges();
            }

        }

        private void SaveFileBinarySQLServerEF(
            string localFile, string fileName)
        {
            // 1) Get file binary
            byte[] fileBytes;
            using (var fs = new FileStream(
                localFile, FileMode.Open, FileAccess.Read))
            {
                fileBytes = new byte[fs.Length];
                fs.Read(
                    fileBytes, 0, Convert.ToInt32(fs.Length));
            }

            // 2) Create a Files object
            var file = new Documents()
            {
                File = fileBytes,
                Type = fileName,
                Size = fileBytes.Length
            };

            // 3) Add and save it in database
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Documents.Add(file);

                ctx.SaveChanges();
            }

        }
        #endregion
    }
}
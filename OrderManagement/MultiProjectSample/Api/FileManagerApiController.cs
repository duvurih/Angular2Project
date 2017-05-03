using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace MultiProjectSample.Api
{
    [RoutePrefix("api/file")]
    public class FileManagerApiController : ApiController
    {
        /// <summary>
        /// Uploading File from a .net client application
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("uploadimagefromstream/{id}/imageStream")]
        public async Task<HttpResponseMessage> UploadImageFromStream(string id)
        {
            Stream imageStream = await Request.Content.ReadAsStreamAsync();
            string path;
            if (System.Web.HttpContext.Current == null)
            {
                //self hosting
                path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            }
            else
            {
                //IIS hosting
                path = HttpContext.Current.Server.MapPath("~");
            }
            string imagePath = Path.Combine(path, @"Images\", id + ".jpg");
            using(FileStream fs = new FileStream(imagePath, FileMode.Create))
            {
                await imageStream.CopyToAsync(fs);
                fs.Close();
            }
            imageStream.Close();

            //change the version of agent, so the client will reload its photo
            //Agent agent = _repository.Get(id);
            //agent.Version++;
            //_repository.Update(agent);

            var response = Request.CreateResponse(HttpStatusCode.Accepted);
            return response;
        }

        /// <summary>
        /// Uploading file from a .net web application form
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("uploadimagefromform/{id}/imageForm")]
        public async Task<HttpResponseMessage> UploadImageFromForm(string id)
        {
            string path;
            if (System.Web.HttpContext.Current == null)
            {
                //self hosting
                path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            }
            else
            {
                //IIS hosting
                path = HttpContext.Current.Server.MapPath("~");
            }
            string imagePath = Path.Combine(path, @"Images\");

            var streamProvider = new MultipartFormDataStreamProvider(imagePath);
            await Request.Content.ReadAsMultipartAsync(streamProvider);
            MultipartFileData fileData = streamProvider.FileData[0];
            string newFileName = Path.Combine(imagePath, id + ".jpg");
            if (File.Exists(newFileName))
            {
                File.Delete(newFileName);
            }
            File.Move(fileData.LocalFileName, newFileName);

            //change the version of agent, so the client will reload its photo
            //Agent agent = _repository.Get(id);
            //agent.Version++;
            //_repository.Update(agent);

            var response = Request.CreateResponse(HttpStatusCode.Accepted);
            return response;
        }

        [HttpGet]
        [Route("getasstream")]
        public HttpResponseMessage GetAsStream()
        {
            Request.Headers.AcceptEncoding.Clear();
            HttpResponseMessage response = Request.CreateResponse();

            response.Content = new PushStreamContent(
                    (stream, headers, context) =>
                    {
                        StreamWriter sWriter = new StreamWriter(stream);
                        StreamWriter sw = (StreamWriter)sWriter;

                        //foreach (var agent in _repository.GetAll())
                        //{
                        //    FullName = agent.FullName,
                        //    Link = GetAgenLocation(agent.id)
                        //};

                        StringBuilder sb = new StringBuilder();
                        TextWriter tw = new StringWriter(sb);
                        JsonSerializer js = new JsonSerializer();
                        //js.Serialize(tw, thinAgent);
                        string jstring = sb.ToString();
                        sw.WriteLine(jstring);
                        sw.Flush();
                        Thread.Sleep(2000);
                    }
                );
            return response;
        }
    }
}

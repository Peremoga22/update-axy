using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using web.Data.ModelDtos.ModelDataCast;

namespace web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataCastController : ControllerBase
    {
        private readonly IHostEnvironment _environment;

        public DataCastController(IHostEnvironment environment)
        {
            _environment = environment;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] string id, [FromForm] string jsonString)
        {
            string filepath = string.Empty;

            if (jsonString != null)
            {
                var date = DateTime.Now.ToString("dd-MM-yyyy");
                string path = Path.Combine(_environment.ContentRootPath, $"wwwroot\\dataCast\\{id}\\{date}");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                               
                var localTime = DateTime.Now.ToString("hh-mm-ss");
              
                filepath = $"{path}\\{localTime}" + ".json";                             
                System.IO.File.WriteAllText(filepath, jsonString.ToString());

                return Ok();
            }

            return NoContent();
        }
    }
}

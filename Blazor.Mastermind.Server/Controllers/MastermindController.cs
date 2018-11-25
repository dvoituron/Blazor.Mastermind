using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Blazor.Mastermind.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Blazor.Mastermind.Server.Controllers
{
    [Route("api/[controller]")]
    public class MastermindController : Controller
    {
        private FileInfo AssemblyFile => new FileInfo(Assembly.GetEntryAssembly().Location);
        private string DataFilename => Path.Combine(AssemblyFile.Directory.FullName, "Gamer-YMdiUW7eeHAr.json");

        [HttpPost("[action]")]
        public void Save([FromBody] Gamer gamer)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(gamer, Newtonsoft.Json.Formatting.None);

            string allData = ReadAllData();
            allData = allData.Replace("]", $"{(allData.Length > 4 ? ',' : ' ')}    {json}{Environment.NewLine}]");

            System.IO.File.WriteAllText(DataFilename, allData);
        }

        [HttpGet("[action]")]
        public IEnumerable<Gamer> Load()
        {
            string allData = ReadAllData();
            return Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<Gamer>>(allData);
        }

        // Read data file
        private string ReadAllData()
        {
            string allData = System.IO.File.Exists(DataFilename) ?
                                 System.IO.File.ReadAllText(DataFilename) :
                                 String.Empty;

            if (String.IsNullOrEmpty(allData))
                return $"[{Environment.NewLine}]";
            else
                return allData;
        }
    }
}
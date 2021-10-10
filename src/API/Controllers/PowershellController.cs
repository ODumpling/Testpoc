using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PowershellController : ControllerBase
    {
        private readonly ILogger<PowershellController> _logger;

        public PowershellController(ILogger<PowershellController> logger)
        {
            _logger = logger;
        }

        // GET
        [HttpGet]
        public async Task<WindowsRootInfo> Get()
        {
            var scriptContents = new StringBuilder();
            scriptContents.AppendLine("Get-ComputerInfo | ConvertTo-Json");

            var scriptParameters = new Dictionary<string, object>() { };

            var psObjects = await PowershellCommand.RunScript(scriptContents.ToString(), scriptParameters);

            var resultString = psObjects[0].BaseObject.ToString();

            if (resultString == null) return new WindowsRootInfo();
            var result = JsonSerializer.Deserialize<WindowsRootInfo>(resultString);

            return result;

        }

        [HttpPost("execute")]
        public async Task<JsonResult> ExecuteScript([FromBody]ScriptOptions options)
        {
            var scriptResult = await ScriptExists(options.Script);

            if (scriptResult.Exists == false)
            {
                throw new CommandNotFoundException();
            }

            // var scriptParameters = new Dictionary<string, object>() { };

            var psObjects = await PowershellCommand.RunScript(scriptResult.Content, options.Parameters);

            var resultString = psObjects[0].BaseObject.ToString();

            if (resultString != null)
            {
                return new JsonResult(resultString);
            }

            return new JsonResult("");
        }

        private async Task<ScriptResult> ScriptExists(string script)
        {
            var scriptsDirectory = Directory.GetCurrentDirectory() + "\\PowershellScripts\\" ;
            var filePath = scriptsDirectory + script;
            var files = Directory.GetFiles(scriptsDirectory , "*.ps1",
                SearchOption.AllDirectories);
            if (files.Any(item => item == filePath))
            {
                string content;
                using (var sr = new StreamReader(filePath))
                 content = await sr.ReadToEndAsync();

                return new ScriptResult(true , scriptsDirectory + script, content);
            }
            return new ScriptResult( false , null, null );
        }
    }

    public class ScriptOptions
    {
        public string Script { get; set; }
        public Dictionary<string, object> Parameters {get;set;}
    }

    public class ScriptResult
    {
        public ScriptResult(bool exists, string scriptPath, string content)
        {
            Exists = exists;
            ScriptPath = scriptPath;
            Content = content;
        }

        public bool Exists { get; }
        public string ScriptPath { get; }
        public string Content { get; }
    }
}
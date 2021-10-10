using System.Collections.Generic;
using System.Management.Automation;
using System.Threading.Tasks;

namespace API.Services
{
    public static class PowershellCommand
    {
        public static async Task<PSDataCollection<PSObject>> RunScript(string scriptContents,
            Dictionary<string, object> scriptParameters)
        {
            // create a new hosted PowerShell instance using the default runspace.
            // wrap in a using statement to ensure resources are cleaned up.

            using var ps = PowerShell.Create();
            // specify the script code to run.
            ps.AddScript(scriptContents);

            // specify the parameters to pass into the script.
            ps.AddParameters(scriptParameters);

            // execute the script and await the result.
            var pipelineObjects = await ps.InvokeAsync();

            // print the resulting pipeline objects to the console.
            // foreach (var item in pipelineObjects)
            // {
            //     Console.WriteLine(item.BaseObject.ToString());
            // }

            return pipelineObjects;
        }
    }
}
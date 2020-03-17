using System;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTestingConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Process process = new Process();
            process.EnableRaisingEvents = true;

            process.StartInfo.FileName = "dotnet";
            process.StartInfo.WorkingDirectory = "";
            process.StartInfo.Arguments = "new --list --type project";
            Console.WriteLine(string.Format("Executing dotnet new --list --type project"));

            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            process.StartInfo.UseShellExecute = false;

            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardInput = true;

            process.OutputDataReceived += (sender, args) => Console.WriteLine(args.Data);
            process.ErrorDataReceived += (sender, args) => Console.WriteLine(args.Data);
            try
            {
                process.Start();
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();
                process.WaitForExit();
            }
            catch (Exception e)
            {
                Console.WriteLine("exception: {0}", e);
            }
            Console.WriteLine("Bye!");
        }
    }
}

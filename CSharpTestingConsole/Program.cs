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
            bool useHiddenWindow = true;

            Console.WriteLine("Hit a key when you're ready!");
            Console.ReadKey();
            Console.WriteLine(string.Format("Executing dotnet new --list --type project"));

            Process process = new Process();
            process.EnableRaisingEvents = true;

            process.StartInfo.FileName = "dotnet";
            process.StartInfo.Arguments = "new --list --type project";

            process.StartInfo.CreateNoWindow = useHiddenWindow;
            if (useHiddenWindow)
            {
                process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                process.StartInfo.UseShellExecute = false;

                process.StartInfo.RedirectStandardOutput = true;
                process.OutputDataReceived += (sender, args) => Console.WriteLine(args.Data);
            }
            try
            {
                process.Start();
                if (useHiddenWindow)
                {
                    process.BeginOutputReadLine();
                }
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

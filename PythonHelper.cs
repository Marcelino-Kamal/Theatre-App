using System.Diagnostics;
namespace Theatre_App.Helpers
{
    

    public static class PythonRunner
    {
        public static string RunPythonScript(string scriptPath, string argument)
        {
            var psi = new ProcessStartInfo
            {
                FileName = "python",
                Arguments = $"\"{scriptPath}\" \"{argument}\"",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using var process = Process.Start(psi);
            string result = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            return result;
        }
    }
}

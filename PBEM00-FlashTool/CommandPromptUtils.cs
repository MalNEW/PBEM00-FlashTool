using Files;
using PBEM00_FlashTool;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPrompt_Functions
{
    public class CommandPrompt
    {
        public static void Start()
        {
            FilesINI ConfigINI = new FilesINI();
            string INIPath = Convert.ToString(System.AppDomain.CurrentDomain.BaseDirectory) + "Config.ini";
            string adbPath = ConfigINI.INIRead("Paths", "adbPath", INIPath);
            Process p = new Process();
            p.StartInfo.FileName = $"C:\\Windows\\System32\\cmd.exe";
            p.StartInfo.Arguments = $"/k start {GlobalVar.defaultPath}\\Data\\fastbootFlash.bat";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.OutputDataReceived += new DataReceivedEventHandler(p_OutputDataReceived);
            p.Start();
            p.BeginOutputReadLine();
            p.BeginErrorReadLine(); // 开始读取错误输出 Begin read stderr
            p.WaitForExit(); // 等待进程结束 Wait for process end
        }

        // 输出打印的信息 Get stdout
        static void p_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Data))
            {
                AppendText(e.Data + Environment.NewLine);
                
            }
        }

        public delegate void AppendTextCallback(string text);

        public static void AppendText(string text)
        {
            GlobalVar.dependencesStatus = text;
            Console.WriteLine(text);
            GlobalVar.fastbootOutput = text;
        }
    }
}
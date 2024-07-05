/**
 * ========================================================================
 * ||   作者 Author : MalNEW aka. Malware_MEZM                           ||
 * ||   Repo : https://github.com/PBEM00-ofpFlashScript                  ||
 * ||   Github : https://github.com/MalNEW                               ||
 * ||   B站 Bilibili : https://space.bilibili.com/66695591               ||
 * ||   QQ : 1032173768                                                  ||
 * ||                                                                    ||
 * ||   特别感谢 Special thanks:                                         ||
 * ||   oppo_decrypt by bkerler (https://github.com/bkerler/oppo_decrypt)||
 * ========================================================================
 */

using Files;
using FlashScript;
using System.Diagnostics;
using System.DirectoryServices.ActiveDirectory;
using System.IO;
using System.Windows;

namespace PBEM00_FlashTool_ofp_decrypt
{

    internal class ofp_decrypt
    {
        
        // 程序主入口
        public static void Main()
        {
            // 声明默认配置文件路径
            string INIPath = Convert.ToString(System.AppDomain.CurrentDomain.BaseDirectory) + "Config.ini";
            string programPath = Convert.ToString(System.AppDomain.CurrentDomain.BaseDirectory) + "\\";


            FilesINI ConfigINI = new FilesINI();
            // 读配置文件
            string pythonPath;
            string scriptPath;
            string ofpPath;
            pythonPath = ConfigINI.INIRead("PythonScriptConfig", "pythonPath", INIPath);
            scriptPath = programPath + "\\Scripts\\decrypt.py";
            ofpPath = ConfigINI.INIRead("Paths","ofpPath",INIPath);

            

            Console.Title = "PBEM00 ofp FlashTool V1.0";
            Console.WriteLine("====================================================================");
            Console.WriteLine("特别感谢 Special thanks:\n"+
                "oppo_decrypt by bkerler (https://github.com/bkerler/oppo_decrypt)");
            Console.WriteLine("====================================================================");
            RunDecryptScript();
        }

        // 删除工作目录中的ofp解密文件 Clean output folder files
        public static void CleanOutputFolder(string folderPath)
        {
            FilesINI ConfigINI = new FilesINI();
            string INIPath = Convert.ToString(System.AppDomain.CurrentDomain.BaseDirectory) + "Config.ini"; // 声明默认配置文件路径 Define config file path
            string showCleanLog = ConfigINI.INIRead("Options", "showCleanLog", INIPath);
            if (Directory.Exists(folderPath))
            {
                DirectoryInfo di = new DirectoryInfo(folderPath);

                foreach (FileInfo file in di.GetFiles())
                {
                    try
                    {
                        file.Delete();
                        if (showCleanLog == "true")
                        {
                            Console.WriteLine($"文件已清理 Deleted file: {file.FullName}"); // 如果'showCleanLog'为真则显示日志 if 'showCleanLog' = 'true' then display logs
                        }
                        // 如果'showCleanLog'为假则不显示日志 if 'showCleanLog' = 'false' then disable display logs
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"清理文件失败 Error deleting file: {file.FullName}, 原因 Exception: {ex.Message}");
                    }
                }

                foreach (DirectoryInfo dir in di.GetDirectories())
                {
                    try
                    {
                        dir.Delete(true);
                        Console.WriteLine($"已删除目录 Deleted directory: {dir.FullName}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"删除目录时发生错误 Error deleting directory: {dir.FullName}, 原因 Exception: {ex.Message}");
                    }
                }
            }
            else
            {
                Console.WriteLine($"目录不存在 Directory does not exist: {folderPath}");
            }
        }

        // 运行oppo_decrypt解密脚本 Run oppo_decrypt script
        public static void RunDecryptScript()
        {
            // 执行oppo_decrypt python脚本 Execute oppo_decrypt script
            FilesINI ConfigINI = new FilesINI();

            // 创建Process类用来执行Python脚本 Create process class to run python script
            Process p = new Process(); 

            // 声明默认配置文件路径 Define config file path
            string INIPath = Convert.ToString(System.AppDomain.CurrentDomain.BaseDirectory) + "Config.ini";

            // 声明程序运行路径 Define program path
            string programPath = Convert.ToString(System.AppDomain.CurrentDomain.BaseDirectory) + "\\";

            // 声明Python路径 Define python path
            string pythonPath;
            pythonPath = ConfigINI.INIRead("PythonScriptConfig", "pythonPath", INIPath);

            // 声明oppo_decrypt脚本路径 Define oppo_decrypt path
            string scriptPath = ConfigINI.INIRead("PythonScriptConfig", "scriptPath", INIPath);

            // 声明ofp路径和输出路径 Define ofp path and output path
            string ofpPath = ConfigINI.INIRead("Paths","ofpPath",INIPath);
            string outputPath = ConfigINI.INIRead("Paths", "outputPath", INIPath);

            // 选项设置 Define options
            string cleanWorkFolder = ConfigINI.INIRead("Options", "cleanWorkFolder", INIPath); // 声明是否需要在执行前清理文件 Clean/keep output files before executing
            string disableDecrypt = ConfigINI.INIRead("Options", "disableDecrypt", INIPath); // 声明是否需要禁用解密 Enable/disable ofp decrypt
            string startFlashAfterDecrypt = ConfigINI.INIRead("Options", "startFlashAfterDecrypt", INIPath); // 是否在解密完成后开始刷写 Start/exit after decrypt complete

            // 检查disableDecrypt的值 Check 'disableDecrypt' value to enable/disable decrypt
            if (disableDecrypt.ToLower() == "true")
            {
                Console.WriteLine("已禁用解密 Decrypt disabled");
                FlashScript.FlashScript.flashDecryptedFiles();
                Environment.Exit(0);
            }

            // 检查cleanWorkFolder的值 Check 'cleanWorkFolder' value to clean working folder
            if (cleanWorkFolder.ToLower() == "true")
            {
                CleanOutputFolder($"{programPath}\\Data\\Output\\");
            }
            
            // 声明Python可执行文件名 Define python executable path
            p.StartInfo.FileName = pythonPath + "\\python.exe";

            // 是否需要清理工作目录 Check 'cleanWorkFolder' to execute 'CleanOutputFolder();'
            if (cleanWorkFolder == "true")
            {
                Console.Title = "预处理中... Pre-Processing...";
                Console.WriteLine("正在清理工作目录... Cleaning working folder...");
                string workingFolderFiles = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "Output");
                CleanOutputFolder(workingFolderFiles);
            }
            else
            {
                Console.WriteLine("已禁用解密前清理工作目录，文件将被覆盖 Clean working folder before decrypt has been disabled,files will be overwrite");
            }
            Console.Title = "处理中 Processing [1/2]";
            Console.WriteLine("处理中，请坐和放宽 Processing,please sit down and relax. [Decrypting ofp file 1/2]");
            p.StartInfo.Arguments = $"{scriptPath} {ofpPath} {outputPath} >nul";
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
            if (startFlashAfterDecrypt == "true")
            {
                FlashScript.FlashScript.flashDecryptedFiles(); // 开始刷写文件 Start flashing
            }
            else
            p.ErrorDataReceived += new DataReceivedEventHandler(p_ErrorDataReceived); // 捕获错误输出 Get stderr
        }

        // 输出打印的信息 Get stdout
        static void p_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Data))
            {
                AppendText(e.Data + Environment.NewLine);
            }
        }

        // 定义错误信息 Define stderr
        static void p_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Data))
            {
                AppendText("ERROR: " + e.Data + Environment.NewLine);
            }
        }

        public delegate void AppendTextCallback(string text);

        public static void AppendText(string text)
        {
            FilesINI ConfigINI = new FilesINI();
            // 声明默认配置文件路径 Define config file path
            string INIPath = Convert.ToString(AppDomain.CurrentDomain.BaseDirectory) + "Config.ini";

            string showDecryptLog = ConfigINI.INIRead("Options", "showDecryptLog", INIPath); // 是否显示解密详细信息 Show/hide decrypt information
            if (showDecryptLog == "true") 
            {
                Console.WriteLine(text);     //此处在控制台输出.py文件print的结果 Get python stdout
            }
            // 关闭解密详细信息 Disable decrypt information
            
        }


    }
}

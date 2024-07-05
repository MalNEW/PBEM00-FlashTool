/**
 * ========================================================================
 *    作者 Author : MalNEW aka. Malware_MEZM                           
 *    Repo : https://github.com/PBEM00-FlashTool                       
 *    Github : https://github.com/MalNEW                               
 *    B站 Bilibili : https://space.bilibili.com/66695591               
 *    QQ : 1032173768                                                  
 *                                                                     
 *    特别感谢 Special thanks:                                          
 *    oppo_decrypt by bkerler (https://github.com/bkerler/oppo_decrypt)
 * ========================================================================
 */

using Files;
using ConsoleHelper;
using FlashScript;
using CommandPrompt_Functions;
using PBEM00_FlashTool;
using System.Diagnostics;
using System.DirectoryServices.ActiveDirectory;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows;
using Microsoft.Win32;

namespace PBEM00_FlashTool_ofp_decrypt
{

    internal class ofp_decrypt
    {
        
        // 程序主入口
        public static int Main()
        {
            FilesINI ConfigINI = new FilesINI(); // 初始化INI配置读写 Initialization INI read/write

            // 声明全局变量 Define global var
            {
                // 路径设置 Set paths
                GlobalVar.INIPath = Convert.ToString(System.AppDomain.CurrentDomain.BaseDirectory) + "Config.ini";
                GlobalVar.programPath = Convert.ToString(System.AppDomain.CurrentDomain.BaseDirectory) + "\\";
                GlobalVar.defaultPath = Convert.ToString(System.AppDomain.CurrentDomain.BaseDirectory);
                GlobalVar.pythonPath = GetPythonPath();
                GlobalVar.scriptPath = GlobalVar.programPath + "\\Data\\oppo_decrypt.py";
                GlobalVar.outputPath = ConfigINI.INIRead("Paths", "outputPath", GlobalVar.INIPath);
                GlobalVar.ofpPath = ConfigINI.INIRead("Paths", "ofpPath", GlobalVar.INIPath);
                GlobalVar.showDecryptLog = ConfigINI.INIRead("Options", "showDecryptLog", GlobalVar.INIPath); // 是否显示解密详细信息 Show/hide decrypt information
                GlobalVar.adbPath = ConfigINI.INIRead("Paths", "adbPath", GlobalVar.INIPath);
                // 选项设置 Set options
                GlobalVar.cleanWorkFolder = ConfigINI.INIRead("Options", "cleanWorkFolder", GlobalVar.INIPath); // 声明是否需要在执行前清理文件 Clean/keep output files before executing
                GlobalVar.disableDecrypt = ConfigINI.INIRead("Options", "disableDecrypt", GlobalVar.INIPath); // 声明是否需要禁用解密 Enable/disable ofp decrypt
                GlobalVar.startFlashAfterDecrypt = ConfigINI.INIRead("Options", "startFlashAfterDecrypt", GlobalVar.INIPath); // 是否在解密完成后开始刷写 Start/exit after decrypt complete
            }

            // 判断配置文件是否存在 Detect if Config.ini exists
            {
                if (!File.Exists(GlobalVar.INIPath))
                {
                    // 创建配置文件 
                    try
                    {
                        File.Copy($"{GlobalVar.defaultPath}\\Config.example.ini", GlobalVar.INIPath);
                        // 创建默认INI文件参数 Create default config
                        {
                            ConfigINI.INIWrite("PythonScriptConfig", "pythonPath", "", GlobalVar.INIPath);
                            ConfigINI.INIWrite("PythonScriptConfig", "scriptPath", "\".\\Data\\decrypt.py\"", GlobalVar.INIPath);
                            ConfigINI.INIWrite("Paths", "ofpPath", "", GlobalVar.INIPath);
                            ConfigINI.INIWrite("Paths", "outputPath", "\".\\Data\\Output\"", GlobalVar.INIPath);
                            ConfigINI.INIWrite("Paths", "adbPath", "\".\\Data\\\"", GlobalVar.INIPath);
                            ConfigINI.INIWrite("Options", "cleanWorkFolder", "true", GlobalVar.INIPath);
                            ConfigINI.INIWrite("Options", "startFlashAfterDecrypt", "true", GlobalVar.INIPath);
                            ConfigINI.INIWrite("Options", "showDecryptLog", "true", GlobalVar.INIPath);
                            ConfigINI.INIWrite("Options", "showCleanLog", "true", GlobalVar.INIPath);
                            ConfigINI.INIWrite("Options", "disableDecrypt", "false", GlobalVar.INIPath);
                        }

                    }
                    catch (Exception e)
                    {
                        Log.WriteErrorLine($"[ERROR] {e}");
                    }
                }
            }

            // 检测配置文件路径是否为空 Detect if Config.ini paths empty
            {
                if (GlobalVar.pythonPath == "")
                {
                    GlobalVar.pythonPath = GetPythonPath();
                    Log.WriteInfoLine($"[INFO] 已获取Python路径 Get python path ({GetPythonPath()})");
                }
                else if (!File.Exists(GlobalVar.scriptPath))
                {
                    Log.WriteErrorLine("[ERROR] 未找到脚本文件 Scripts file not found");
                    return 255;
                }

                if (GlobalVar.ofpPath == "")
                {
                    Log.WriteErrorLine("[ERROR] ofp路径不能为空 ofpPath cannot be empty");
                    return 255;
                }
            }

            // 主要功能 Main function
            {
                Console.Title = "PBEM00 ofp FlashTool V1.0-debug";
                Console.WriteLine("====================================================================");
                Console.WriteLine("特别感谢 Special thanks:\n" +
                    "oppo_decrypt by bkerler (https://github.com/bkerler/oppo_decrypt)");
                Console.WriteLine("====================================================================");
                RunDecryptScript();
                return 0;
            }
            
        }

        // 获取Python路径 Get python path
        static string GetPythonPath()
        {
            using (var key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Python\PythonCore"))
            {
                if (key != null)
                {
                    foreach (var subKeyName in key.GetSubKeyNames())
                    {
                        using (var subKey = key.OpenSubKey($@"{subKeyName}\InstallPath"))
                        {
                            if (subKey != null)
                            {
                                return subKey.GetValue("ExecutablePath") as string;
                            }
                        }
                    }
                }
            }
            return null;
        }


        // 删除工作目录中的ofp解密文件 Clean output folder files [别动 动了必出BUG If you touch it then it will glitch!]
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
                            Log.WriteInfoLine($"[INFO] 文件已清理 Deleted file: {file.FullName}"); // 如果'showCleanLog'为真则显示日志 if 'showCleanLog' = 'true' then display logs
                        }
                        // 如果'showCleanLog'为假则不显示日志 if 'showCleanLog' = 'false' then disable display logs
                    }
                    catch (Exception ex)
                    {
                        Log.WriteErrorLine($"[ERROR] 清理文件失败 Error deleting file: {file.FullName}, 原因 Exception: {ex.Message}");
                    }
                }

                foreach (DirectoryInfo dir in di.GetDirectories())
                {
                    try
                    {
                        dir.Delete(true);
                        Log.WriteInfoLine($"[INFO] 已删除目录 Deleted directory: {dir.FullName}");
                    }
                    catch (Exception ex)
                    {
                        Log.WriteErrorLine($"[ERROR] 删除目录时发生错误 Error deleting directory: {dir.FullName}, 原因 Exception: {ex.Message}");
                    }
                }
            }
            else
            {
                Log.WriteErrorLine($"[ERROR] 目录不存在 Directory does not exist: {folderPath}");
            }
        }

        // 运行oppo_decrypt解密脚本 Run oppo_decrypt script
        public static void RunDecryptScript()
        {
            // 执行oppo_decrypt python脚本 Execute oppo_decrypt script
            FilesINI ConfigINI = new FilesINI();

            // 创建Process类用来执行Python脚本 Create process class to run python script
            Process pythonProcess = new Process(); 

            // 检查disableDecrypt的值 Check 'disableDecrypt' value to enable/disable decrypt
            if (GlobalVar.disableDecrypt.ToLower() == "true")
            {
                Console.WriteLine("已禁用解密 Decrypt disabled");
                FlashScript.FlashScript.flashDecryptedFiles();
                Environment.Exit(0);
            }
            else
            // 检查cleanWorkFolder的值 Check 'cleanWorkFolder' value to clean working folder
            if (GlobalVar.cleanWorkFolder.ToLower() == "true")
            {
                CleanOutputFolder($"{GlobalVar.programPath}\\Data\\Output\\");
            }
            
            // 是否需要清理工作目录 Check 'cleanWorkFolder' to execute 'CleanOutputFolder();'
            if (GlobalVar.cleanWorkFolder == "true")
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
            Log.WriteInfoLine("[INFO] 处理中，请坐和放宽 Processing,please sit down and relax. [Decrypting ofp file 1/2]");
            // 开始解包 Start decrypt
                pythonProcess.StartInfo.FileName = GlobalVar.pythonPath;
                pythonProcess.StartInfo.Arguments = $"{GlobalVar.scriptPath} {GlobalVar.ofpPath} {GlobalVar.outputPath} > ProgramLog.log";
                pythonProcess.StartInfo.UseShellExecute = false;
                pythonProcess.StartInfo.RedirectStandardOutput = true;
                pythonProcess.StartInfo.RedirectStandardInput = true;
                pythonProcess.StartInfo.RedirectStandardError = true;
                pythonProcess.StartInfo.CreateNoWindow = true;
                pythonProcess.OutputDataReceived += new DataReceivedEventHandler(p_OutputDataReceived);
                pythonProcess.Start();
                pythonProcess.BeginOutputReadLine();
                pythonProcess.BeginErrorReadLine(); // 开始读取错误输出 Begin read stderr
                pythonProcess.WaitForExit(); // 等待进程结束 Wait for process end
                if (GlobalVar.startFlashAfterDecrypt == "true")
                {
                    FlashScript.FlashScript.flashDecryptedFiles(); // 开始刷写文件 Start flashing
                }
                pythonProcess.ErrorDataReceived += new DataReceivedEventHandler(p_ErrorDataReceived); // 捕获错误输出 Get stderr

            
        }

        // 标准输出 STDOUT
        static void p_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Data))
            {
                AppendText(e.Data + Environment.NewLine);
            }
        }

        // 标准错误 STDERR
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
            
            
            if (GlobalVar.showDecryptLog == "true") 
            {
                Log.WritePythonInfo(text);     //此处在控制台输出.py文件print的结果 Get python stdout

                try
                {
                    // 使用StreamWriter创建并写入文件内容
                    using (StreamWriter writer = new StreamWriter($"{GlobalVar.defaultPath}\\ProgramLog.log",true))
                    {

                    }
                    // 输出成功信息
                    Log.WriteInfoLine("[INFO] 已创建日志文件 Created log file");
                }
                catch (Exception ex)
                {
                    // 捕获并输出异常信息
                    Log.WriteErrorLine("[ERROR] 发生错误，请截图提交issues或联系开发者！ 错误信息:" + ex.Message);
                }

                try
                {
                    // 使用StreamReader读取文件内容
                    using (StreamReader reader = new StreamReader($"{GlobalVar.defaultPath}\\ProgramLog.log", true))
                    {
                        string content = reader.ReadToEnd();
                    }
                }
                catch (Exception ex)
                {
                    // 捕获并输出异常信息
                    Log.WriteErrorLine("[ERROR] 发生错误，请截图提交issues或联系开发者！ 错误信息:" + ex.Message);
                }

                try
                {
                    // 使用StreamWriter创建并写入文件

                    


                    using (StreamWriter writer = new StreamWriter($"{GlobalVar.defaultPath}\\ProgramLog.log", true))
                    {
                        DateTime now = DateTime.Now;
                        string formattedTime = now.ToString("yyyy-MM-dd HH:mm:ss");
                        writer.WriteLine($"{GlobalVar.logContent}[{formattedTime}] {text}");
                    }

                    
                }
                catch (Exception ex)
                {
                    // 捕获并输出异常信息
                    Log.WriteErrorLine("[ERROR] 发生错误，请截图提交issues或联系开发者！ 错误信息:" + ex.Message);
                }

                


                
            }

        }


    }
}

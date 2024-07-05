using Files;
using CommandPrompt_Functions;
using PBEM00_FlashTool;
using System;
using System.Diagnostics;
using System.Windows;

namespace FlashScript
{
    internal class FlashScript
    {
        public static void flashDecryptedFiles()
        {
            

            // 声明adb与配置文件路径 Define adb and config file path
            FilesINI ConfigINI = new FilesINI();
            string INIPath = Convert.ToString(System.AppDomain.CurrentDomain.BaseDirectory) + "Config.ini";
            

            // 开始刷写镜像 Start flashing images
            Console.Title = "注意 Notice";
            Console.WriteLine("确保你的手机已进入fastboot模式，按回车开始刷写 Make sure your phone is in fastboot mode,press enter to flash");
            Console.ReadLine();
            
            // 启动Windows的cmd控制台
            CommandPrompt.Start();
        }

    }

}
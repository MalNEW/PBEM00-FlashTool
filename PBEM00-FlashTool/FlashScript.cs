using Files;
using System;
using System.Diagnostics;

namespace FlashScript
{
    internal class FlashScript
    {
        /*
          ("fastboot flash abl .\\Data\\Output\\abl.elf"+
            "fastboot flash aop .\\Data\\Output\\aop.mbn"+
            "fastboot flash apdp .\\Data\\Output\\dpAP.mbn"+
            "fastboot flash bluetooth .\\Data\\Output\\BTFM.bin"+
            "fastboot flash boot .\\Data\\Output\\boot.img"+
            "fastboot flash cache .\\Data\\Output\\cache.img"+
            "fastboot flash cdt .\\Data\\Output\\oppo.mbn"+
            "fastboot flash cmnlib .\\Data\\Output\\cmnlib.mbn"+
            "fastboot flash cmnlib64 .\\Data\\Output\\cmnlib64.mbn"+
            "fastboot flash devcfg .\\Data\\Output\\devcfg.mbn"+
            "fastboot flash dsp .\\Data\\Output\\dspso.bin"+
            "fastboot flash dtbo .\\Data\\Output\\dtbo.img"+
            "fastboot flash hyp .\\Data\\Output\\hyp.mbn"+
            "fastboot flash hypbak .\\Data\\Output\\hyp.mbn"+
            "fastboot flash keymaster .\\Data\\Output\\keymaster64.mbn"+
            "fastboot flash logfs .\\Data\\Output\\logfs_ufs_8mb.bin"+
            "fastboot flash modem .\\Data\\Output\\NON-HLOS.bin"+
            "fastboot flash msadp .\\Data\\Output\\dpMSA.mbn"+
            "fastboot flash oppodycnvbk .\\Data\\Output\\dynamic_nvbk.bin"+
            "fastboot flash opporeserve1 .\\Data\\Output\\emmc_fw.bin"+
            "fastboot flash opporeserve2 .\\Data\\Output\\opporeserve2.img"+
            "fastboot flash oppostanvbk .\\Data\\Output\\static_nvbk.bin"+
            "fastboot flash perist .\\Data\\Output\\persist.img"+
            "fastboot flash qupfw .\\Data\\Output\\qupv3fw.elf"+
            "fastboot flash recovery .\\Data\\Output\\recovery.img"+
            "fastboot flash sec .\\Data\\Output\\sec_smt.dat"+
            "fastboot flash splash .\\Data\\Output\\splash.img"+
            "fastboot flash storsec .\\Data\\Output\\storsec.mbn"+
            "fastboot flash system .\\Data\\Output\\system.img"+
            "fastboot flash tz .\\Data\\Output\\tz.mbn"+
            "fastboot flash userdata .\\Data\\Output\\userdata.img"+
            "fastboot flash vbmeta .\\Data\\Output\\vbmeta.img"+
            "fastboot flash vendor .\\Data\\Output\\vendor.img"+ 
            "fastboot flash xbl .\\Data\\Output\\xbl.elf"+
            "fastboot flash xbl_config .\\Data\\Output\\xbl_config.elf")
            */
        

        // TODO : 刷入解包后的文件 Flash decrypted files

        public static void flashDecryptedFiles()
        {

            // DEFINES
            string abl = "flash abl .\\Data\\Output\\abl.elf";
            string aop = "flash aop .\\Data\\Output\\aop.mbn";
            string apdp = "flash apdp .\\Data\\Output\\dpAP.mbn";
            string bluetooth = "flash bluetooth .\\Data\\Output\\BTFM.bin";
            string boot = "flash boot .\\Data\\Output\\boot.img";
            string cache = "flash cache .\\Data\\Output\\cache.img";
            string cdt = "flash cdt .\\Data\\Output\\oppo.mbn";
            string cmnlib = "flash cmnlib .\\Data\\Output\\cmnlib.mbn";
            string cmnlib64 = "flash cmnlib64 .\\Data\\Output\\cmnlib64.mbn";
            string devcfg = "flash devcfg .\\Data\\Output\\devcfg.mbn";
            string dsp = "flash dsp .\\Data\\Output\\dspso.bin";
            string dtbo = "flash dtbo .\\Data\\Output\\dtbo.img";
            string hyp = "flash hyp .\\Data\\Output\\hyp.mbn";
            string hypbak = "flash hypbak .\\Data\\Output\\hyp.mbn";
            string keymaster = "flash keymaster .\\Data\\Output\\keymaster64.mbn";
            string logfs = "flash logfs .\\Data\\Output\\logfs_ufs_8mb.bin";
            string modem = "flash modem .\\Data\\Output\\NON-HLOS.bin";
            string msadp = "flash msadp .\\Data\\Output\\dpMSA.mbn";
            string oppodycnvbk = "flash oppodycnvbk .\\Data\\Output\\dynamic_nvbk.bin";
            string opporeserve1 = "flash opporeserve1 .\\Data\\Output\\emmc_fw.bin";
            string opporeserve2 = "flash opporeserve2 .\\Data\\Output\\opporeserve2.img";
            string oppostanvbk = "flash oppostanvbk .\\Data\\Output\\static_nvbk.bin";
            string perist = "flash perist .\\Data\\Output\\persist.img";
            string qupfw = "flash qupfw .\\Data\\Output\\qupv3fw.elf";
            string recovery = "flash recovery .\\Data\\Output\\recovery.img";
            string sec = "flash sec .\\Data\\Output\\sec_smt.dat";
            string splash = "flash splash .\\Data\\Output\\splash.img";
            string storsec = "flash storsec .\\Data\\Output\\storsec.mbn";
            string system = "flash system .\\Data\\Output\\system.img";
            string tz = "flash tz .\\Data\\Output\\tz.mbn";
            string userdata = "flash userdata .\\Data\\Output\\userdata.img";
            string vbmeta = "flash vbmeta .\\Data\\Output\\vbmeta.img";
            string vendor = "flash vendor .\\Data\\Output\\vendor.img";
            string xbl = "flash xbl .\\Data\\Output\\xbl.elf";
            string xbl_config = "flash xbl_config .\\Data\\Output\\xbl_config.elf";


            // 声明adb路径 Define adb path
            FilesINI ConfigINI = new FilesINI();
            string INIPath = Convert.ToString(System.AppDomain.CurrentDomain.BaseDirectory) + "Config.ini";
            string adbPath = ConfigINI.INIRead("Paths", "adbPath", INIPath);

            Process p = new Process();
            // 开始刷写镜像 Start flashing images
            Console.Title = "注意 Notice";
            Console.WriteLine("确保你的手机已进入fastboot模式，按回车开始刷写 Make sure your phone is in fastboot mode,press enter to flash");
            Console.ReadLine();

            Console.WriteLine("正在刷写abl分区... Flashing abl partation...");
            //Process.Start($"{adbPath}\\fastboot \"devices\"");
            p.StartInfo.FileName = $"{adbPath}\\fastboot.exe";
            p.StartInfo.Arguments = abl ;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.Start();
            Console.WriteLine(p.StandardOutput.ReadToEnd());
            p.WaitForExit();

            Console.WriteLine("正在刷写aop分区... Flashing aop partation...");
            p.StartInfo.Arguments = aop;
            p.Start();
            Console.WriteLine(p.StandardOutput.ReadToEnd());
            p.WaitForExit();

            Console.WriteLine("正在刷写apdp分区... Flashing apdp partation...");
            p.StartInfo.Arguments = apdp;
            p.Start();
            Console.WriteLine(p.StandardOutput.ReadToEnd());
            p.WaitForExit();

            Console.WriteLine("正在刷写bluetooth分区... Flashing bluetooth partation...");
            p.StartInfo.Arguments = bluetooth;
            p.Start();
            Console.WriteLine(p.StandardOutput.ReadToEnd());
            p.WaitForExit();

            Console.WriteLine("正在刷写boot分区... Flashing boot partation...");
            p.StartInfo.Arguments = boot;
            p.Start();
            Console.WriteLine(p.StandardOutput.ReadToEnd());
            p.WaitForExit();

            Console.WriteLine("正在刷写cdt分区... Flashing cdt partation...");
            p.StartInfo.Arguments = cdt;
            p.Start();
            Console.WriteLine(p.StandardOutput.ReadToEnd());
            p.WaitForExit();

            Console.WriteLine("正在刷写cmnlib分区... Flashing cmnlib partation...");
            p.StartInfo.Arguments = cmnlib;
            p.Start();
            Console.WriteLine(p.StandardOutput.ReadToEnd());
            p.WaitForExit();

            Console.WriteLine("正在刷写cmnlib64分区... Flashing cmnlib64 partation...");
            p.StartInfo.Arguments = cmnlib64;
            p.Start();
            Console.WriteLine(p.StandardOutput.ReadToEnd());
            p.WaitForExit();

            Console.WriteLine("正在刷写devcfg分区... Flashing devcfg partation...");
            p.StartInfo.Arguments = devcfg;
            p.Start();
            Console.WriteLine(p.StandardOutput.ReadToEnd());
            p.WaitForExit();

            Console.WriteLine("正在刷写dsp分区... Flashing dsp partation...");
            p.StartInfo.Arguments = dsp;
            p.Start();
            Console.WriteLine(p.StandardOutput.ReadToEnd());
            p.WaitForExit();

            Console.WriteLine("正在刷写dtbo分区... Flashing dtbo partation...");
            p.StartInfo.Arguments = dtbo;
            p.Start();
            Console.WriteLine(p.StandardOutput.ReadToEnd());
            p.WaitForExit();

            Console.WriteLine("正在刷写hyp分区... Flashing hyp partation...");
            p.StartInfo.Arguments = hyp;
            p.Start();
            Console.WriteLine(p.StandardOutput.ReadToEnd());
            p.WaitForExit();

            Console.WriteLine("正在刷写hypbak分区... Flashing hypbak partation...");
            p.StartInfo.Arguments = hypbak;
            p.Start();
            Console.WriteLine(p.StandardOutput.ReadToEnd());
            p.WaitForExit();

            Console.WriteLine("正在刷写keymaster分区... Flashing keymaster partation...");
            p.StartInfo.Arguments = keymaster;
            p.Start();
            Console.WriteLine(p.StandardOutput.ReadToEnd());
            p.WaitForExit();

            Console.WriteLine("正在刷写logfs分区... Flashing logfs partation...");
            p.StartInfo.Arguments = logfs;
            p.Start();
            Console.WriteLine(p.StandardOutput.ReadToEnd());
            p.WaitForExit();

            Console.WriteLine("正在刷写modem分区... Flashing modem partation...");
            p.StartInfo.Arguments = modem;
            p.Start();
            Console.WriteLine(p.StandardOutput.ReadToEnd());
            p.WaitForExit();

            Console.WriteLine("正在刷写msadp分区... Flashing msadp partation...");
            p.StartInfo.Arguments = msadp;
            p.Start();
            Console.WriteLine(p.StandardOutput.ReadToEnd());
            p.WaitForExit();

            Console.WriteLine("正在刷写oppodycnvbk分区... Flashing oppodycnvbk partation...");
            p.StartInfo.Arguments = oppodycnvbk;
            p.Start();
            Console.WriteLine(p.StandardOutput.ReadToEnd());
            p.WaitForExit();

            Console.WriteLine("正在刷写opporeserve1分区... Flashing opporeserve1 partation...");
            p.StartInfo.Arguments = opporeserve1;
            p.Start();
            Console.WriteLine(p.StandardOutput.ReadToEnd());
            p.WaitForExit();

            Console.WriteLine("正在刷写opporeserve2分区... Flashing opporeserve2 partation...");
            p.StartInfo.Arguments = opporeserve2;
            p.Start();
            Console.WriteLine(p.StandardOutput.ReadToEnd());
            p.WaitForExit();

            Console.WriteLine("正在刷写oppostanvbk分区... Flashing oppostanvbk partation...");
            p.StartInfo.Arguments = oppostanvbk;
            p.Start();
            Console.WriteLine(p.StandardOutput.ReadToEnd());
            p.WaitForExit();

            Console.WriteLine("正在刷写perist分区... Flashing perist partation...");
            p.StartInfo.Arguments = perist;
            p.Start();
            Console.WriteLine(p.StandardOutput.ReadToEnd());
            p.WaitForExit();

            Console.WriteLine("正在刷写qupfw分区... Flashing qupfw partation...");
            p.StartInfo.Arguments = qupfw;
            p.Start();
            Console.WriteLine(p.StandardOutput.ReadToEnd());
            p.WaitForExit();

            Console.WriteLine("正在刷写recovery分区... Flashing recovery partation...");
            p.StartInfo.Arguments = recovery;
            p.Start();
            Console.WriteLine(p.StandardOutput.ReadToEnd());
            p.WaitForExit();

            Console.WriteLine("正在刷写sec分区... Flashing sec partation...");
            p.StartInfo.Arguments = sec;
            p.Start();
            Console.WriteLine(p.StandardOutput.ReadToEnd());
            p.WaitForExit();

            Console.WriteLine("正在刷写splash分区... Flashing splash partation...");
            p.StartInfo.Arguments = splash;
            p.Start();
            Console.WriteLine(p.StandardOutput.ReadToEnd());
            p.WaitForExit();

            Console.WriteLine("正在刷写storsec分区... Flashing storsec partation...");
            p.StartInfo.Arguments = storsec;
            p.Start();
            Console.WriteLine(p.StandardOutput.ReadToEnd());
            p.WaitForExit();

            Console.WriteLine("正在刷写system分区... Flashing system partation...");
            p.StartInfo.Arguments = system;
            p.Start();
            Console.WriteLine(p.StandardOutput.ReadToEnd());
            p.WaitForExit();

            Console.WriteLine("正在刷写tz分区... Flashing tz partation...");
            p.StartInfo.Arguments = tz;
            p.Start();
            Console.WriteLine(p.StandardOutput.ReadToEnd());
            p.WaitForExit();

            Console.WriteLine("正在刷写userdata分区... Flashing userdata partation...");
            p.StartInfo.Arguments = userdata;
            p.Start();
            Console.WriteLine(p.StandardOutput.ReadToEnd());
            p.WaitForExit();

            Console.WriteLine("正在刷写vbmeta分区... Flashing vbmeta partation...");
            p.StartInfo.Arguments = vbmeta;
            p.Start();
            Console.WriteLine(p.StandardOutput.ReadToEnd());
            p.WaitForExit();

            Console.WriteLine("正在刷写vendor分区... Flashing vendor partation...");
            p.StartInfo.Arguments = vendor;
            p.Start();
            Console.WriteLine(p.StandardOutput.ReadToEnd());
            p.WaitForExit();

            Console.WriteLine("正在刷写xbl分区... Flashing xbl partation...");
            p.StartInfo.Arguments = xbl;
            p.Start();
            Console.WriteLine(p.StandardOutput.ReadToEnd());
            p.WaitForExit();

            Console.WriteLine("正在刷写xbl_config分区... Flashing xbl_config partation...");
            p.StartInfo.Arguments = xbl_config;
            p.Start();
            Console.WriteLine(p.StandardOutput.ReadToEnd());
            p.WaitForExit();


            Console.ReadLine();
        }
    }
}

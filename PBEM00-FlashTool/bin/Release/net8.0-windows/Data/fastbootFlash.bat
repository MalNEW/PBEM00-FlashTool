@echo off
echo ==============================================================================
echo 通过[工具目录]\Scripts\realScript.bat自定义刷机脚本
echo ==============================================================================


cls
echo ===========================警告==================================
echo.                           		                
echo  刷机操作存在风险，可能导致设备损坏、数据丢失等不可预见情形    
echo  由此产生的一切后果均由您自行承担。本工具对因您未正确操作而引发的设备故障或其他损失，以及任何法律责任均不承担
echo  您应在充分知晓刷机风险与自身能力后，谨慎决定是否进行刷机操作
echo  按下回车后代表您同意承担设备损坏、数据丢失的风险
echo.
echo =================================================================
echo.
echo ==========================WARNING================================
echo. 
Echo Flashing is risky and can lead to unforeseen situations such as device damage and data loss    
echo You shall be solely responsible for all consequences arising therefrom. This tool is not responsible for equipment failure or other losses caused by your improper use, as well as any legal liability
echo You should carefully decide whether to flash or not after fully understanding the risks and capabilities of flashing
echo.
echo =================================================================

pause
echo [INFO] 正在开始刷写...
%~dp0\fastboot.exe flash abl %~dp0\Output\abl.elf
echo abl分区刷写完成

echo [INFO] 开始刷写aop分区...
%~dp0\fastboot.exe flash aop %~dp0\Output\aop.mbn
echo [SUCCESS] abl分区刷写完成


echo [INFO] 开始刷写apdp分区...
%~dp0\fastboot.exe flash apdp %~dp0\Output\dpAP.mbn
echo [SUCCESS] apdp分区刷写完成


echo [INFO] 开始刷写bluetooth分区...
%~dp0\fastboot.exe flash bluetooth %~dp0\Output\BTFM.bin
echo [SUCCESS] bluetooth分区刷写完成

echo [INFO] 开始刷写boot分区...
%~dp0\fastboot.exe flash boot %~dp0\Output\boot.img
echo [SUCCESS] boot分区刷写完成

echo [INFO] 开始刷写cache分区...
%~dp0\fastboot.exe flash cache %~dp0\Output\cache.img
echo [SUCCESS] cache分区刷写完成

REM echo [INFO] 开始刷写cdt分区...
REM %~dp0\fastboot.exe flash cdt %~dp0\Output\oppo.mbn
echo [SUCCESS] cdt分区刷写完成

echo [INFO] 开始刷写cmnlib分区...
%~dp0\fastboot.exe flash cmnlib %~dp0\Output\cmnlib.mbn
echo [SUCCESS] cmnlib分区刷写完成

echo [INFO] 开始刷写cmnlib64分区...
%~dp0\fastboot.exe flash cmnlib64 %~dp0\Output\cmnlib64.mbn
echo [SUCCESS] cmnlib64分区刷写完成

echo [INFO] 开始刷写devcfg分区...
%~dp0\fastboot.exe flash devcfg %~dp0\Output\devcfg.mbn
echo [SUCCESS] devcfg分区刷写完成

echo [INFO] 开始刷写dsp分区...
%~dp0\fastboot.exe flash dsp %~dp0\Output\dspso.bin
echo [SUCCESS] dsp分区刷写完成

echo [INFO] 开始刷写dtbo分区...
%~dp0\fastboot.exe flash dtbo %~dp0\Output\dtbo.img
echo [SUCCESS] dtbo分区刷写完成

echo [INFO] 开始刷写hyp分区...
%~dp0\fastboot.exe flash hyp %~dp0\Output\hyp.mbn
echo [SUCCESS] hyp分区刷写完成

echo [INFO] 开始刷写hypbak分区...
%~dp0\fastboot.exe flash hypbak %~dp0\Output\hyp.mbn
echo [SUCCESS] hypbak分区刷写完成

echo [INFO] 开始刷写keymaster分区...
%~dp0\fastboot.exe flash keymaster %~dp0\Output\keymaster64.mbn
echo [SUCCESS] keymaster分区刷写完成

echo [INFO] 开始刷写logfs分区...
%~dp0\fastboot.exe flash logfs %~dp0\Output\logfs_ufs_8mb.bin
echo [SUCCESS] logfs分区刷写完成

echo [INFO] 开始刷写modem分区...
%~dp0\fastboot.exe flash modem %~dp0\Output\NON-HLOS.bin
echo [SUCCESS] modem分区刷写完成

echo [INFO] 开始刷写msadp分区...
%~dp0\fastboot.exe flash msadp %~dp0\Output\dpMSA.mbn
echo [SUCCESS] msadp分区刷写完成

echo [INFO] 开始刷写oppodycnvbk分区...
%~dp0\fastboot.exe flash oppodycnvbk %~dp0\Output\dynamic_nvbk.bin
echo [SUCCESS] oppodycnvbk分区刷写完成

echo [INFO] 开始刷写opporeserve1分区...
%~dp0\fastboot.exe flash opporeserve1 %~dp0\Output\emmc_fw.bin
echo [SUCCESS] opporeserve1分区刷写完成

echo [INFO] 开始刷写opporeserve2分区...
%~dp0\fastboot.exe flash opporeserve2 %~dp0\Output\opporeserve2.img
echo [SUCCESS] opporeserve2分区刷写完成

echo [INFO] 开始刷写oppostanvbk分区...
%~dp0\fastboot.exe flash oppostanvbk %~dp0\Output\static_nvbk.bin
echo [SUCCESS] oppostanvbk分区刷写完成

echo [INFO] 开始刷写perist分区...
%~dp0\fastboot.exe flash perist %~dp0\Output\persist.img
echo [SUCCESS] perist分区刷写完成

echo [INFO] 开始刷写qupfw分区...
%~dp0\fastboot.exe flash qupfw %~dp0\Output\qupv3fw.elf
echo [SUCCESS] qupfw分区刷写完成

echo [INFO] 开始刷写recovery分区...
%~dp0\fastboot.exe flash recovery %~dp0\Output\recovery.img
echo [SUCCESS] recovery分区刷写完成

echo [INFO] 开始刷写sec分区...
%~dp0\fastboot.exe flash sec %~dp0\Output\sec_smt.dat
echo [SUCCESS] sec分区刷写完成

echo [INFO] 开始刷写splash分区...
%~dp0\fastboot.exe flash splash %~dp0\Output\splash.img
echo [SUCCESS] splash分区刷写完成

echo [INFO] 开始刷写storsec分区...
%~dp0\fastboot.exe flash storsec %~dp0\Output\storsec.mbn
echo [SUCCESS] storsec分区刷写完成

echo [INFO] 开始刷写system分区...
%~dp0\fastboot.exe flash system %~dp0\Output\system.img
echo [SUCCESS] system分区刷写完成

echo [INFO] 开始刷写tz分区...
%~dp0\fastboot.exe flash tz %~dp0\Output\tz.mbn
echo [SUCCESS] tz分区刷写完成

echo [INFO] 开始刷写userdata分区...
%~dp0\fastboot.exe flash userdata %~dp0\Output\userdata.img
echo [SUCCESS] userdata分区刷写完成

echo [INFO] 开始刷写vbmeta分区...
%~dp0\fastboot.exe flash vbmeta %~dp0\Output\vbmeta.img
echo [SUCCESS] vbmeta分区刷写完成

echo [INFO] 开始刷写vendor分区...
%~dp0\fastboot.exe flash vendor %~dp0\Output\vendor.img 
echo [SUCCESS] vendor分区刷写完成


echo [INFO] 开始刷写xbl分区...
%~dp0\fastboot.exe flash xbl %~dp0\Output\xbl.elf
echo [SUCCESS] xbl分区刷写完成


echo [INFO] 开始刷写xbl_config分区...
%~dp0\fastboot.exe flash xbl_config %~dp0\Output\xbl_config.elf
echo [SUCCESS] xbl_config分区刷写完成

echo ===================================================
echo 全部分区刷写完成 即将重启设备... 3
echo ===================================================
timeout /t 1 > nul
echo ===================================================
echo 全部分区刷写完成 即将重启设备... 2
echo ===================================================
timeout /t 1 > nul
echo ===================================================
echo 全部分区刷写完成 即将重启设备... 1
echo ===================================================
timeout /t 1 > nul
echo ===================================================
echo 全部分区刷写完成 即将重启设备... 0
echo ===================================================
echo ===================================================
echo 正在向设备发送重启命令...
echo ===================================================
%~dp0\fastboot.exe reboot


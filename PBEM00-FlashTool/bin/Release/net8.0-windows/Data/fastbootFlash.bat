@echo off
echo ==============================================================================
echo ͨ��[����Ŀ¼]\Scripts\realScript.bat�Զ���ˢ���ű�
echo ==============================================================================


cls
echo ===========================����==================================
echo.                           		                
echo  ˢ���������ڷ��գ����ܵ����豸�𻵡����ݶ�ʧ�Ȳ���Ԥ������    
echo  �ɴ˲�����һ�к�����������ге��������߶�����δ��ȷ�������������豸���ϻ�������ʧ���Լ��κη������ξ����е�
echo  ��Ӧ�ڳ��֪��ˢ�����������������󣬽��������Ƿ����ˢ������
echo  ���»س��������ͬ��е��豸�𻵡����ݶ�ʧ�ķ���
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
echo [INFO] ���ڿ�ʼˢд...
%~dp0\fastboot.exe flash abl %~dp0\Output\abl.elf
echo abl����ˢд���

echo [INFO] ��ʼˢдaop����...
%~dp0\fastboot.exe flash aop %~dp0\Output\aop.mbn
echo [SUCCESS] abl����ˢд���


echo [INFO] ��ʼˢдapdp����...
%~dp0\fastboot.exe flash apdp %~dp0\Output\dpAP.mbn
echo [SUCCESS] apdp����ˢд���


echo [INFO] ��ʼˢдbluetooth����...
%~dp0\fastboot.exe flash bluetooth %~dp0\Output\BTFM.bin
echo [SUCCESS] bluetooth����ˢд���

echo [INFO] ��ʼˢдboot����...
%~dp0\fastboot.exe flash boot %~dp0\Output\boot.img
echo [SUCCESS] boot����ˢд���

echo [INFO] ��ʼˢдcache����...
%~dp0\fastboot.exe flash cache %~dp0\Output\cache.img
echo [SUCCESS] cache����ˢд���

REM echo [INFO] ��ʼˢдcdt����...
REM %~dp0\fastboot.exe flash cdt %~dp0\Output\oppo.mbn
echo [SUCCESS] cdt����ˢд���

echo [INFO] ��ʼˢдcmnlib����...
%~dp0\fastboot.exe flash cmnlib %~dp0\Output\cmnlib.mbn
echo [SUCCESS] cmnlib����ˢд���

echo [INFO] ��ʼˢдcmnlib64����...
%~dp0\fastboot.exe flash cmnlib64 %~dp0\Output\cmnlib64.mbn
echo [SUCCESS] cmnlib64����ˢд���

echo [INFO] ��ʼˢдdevcfg����...
%~dp0\fastboot.exe flash devcfg %~dp0\Output\devcfg.mbn
echo [SUCCESS] devcfg����ˢд���

echo [INFO] ��ʼˢдdsp����...
%~dp0\fastboot.exe flash dsp %~dp0\Output\dspso.bin
echo [SUCCESS] dsp����ˢд���

echo [INFO] ��ʼˢдdtbo����...
%~dp0\fastboot.exe flash dtbo %~dp0\Output\dtbo.img
echo [SUCCESS] dtbo����ˢд���

echo [INFO] ��ʼˢдhyp����...
%~dp0\fastboot.exe flash hyp %~dp0\Output\hyp.mbn
echo [SUCCESS] hyp����ˢд���

echo [INFO] ��ʼˢдhypbak����...
%~dp0\fastboot.exe flash hypbak %~dp0\Output\hyp.mbn
echo [SUCCESS] hypbak����ˢд���

echo [INFO] ��ʼˢдkeymaster����...
%~dp0\fastboot.exe flash keymaster %~dp0\Output\keymaster64.mbn
echo [SUCCESS] keymaster����ˢд���

echo [INFO] ��ʼˢдlogfs����...
%~dp0\fastboot.exe flash logfs %~dp0\Output\logfs_ufs_8mb.bin
echo [SUCCESS] logfs����ˢд���

echo [INFO] ��ʼˢдmodem����...
%~dp0\fastboot.exe flash modem %~dp0\Output\NON-HLOS.bin
echo [SUCCESS] modem����ˢд���

echo [INFO] ��ʼˢдmsadp����...
%~dp0\fastboot.exe flash msadp %~dp0\Output\dpMSA.mbn
echo [SUCCESS] msadp����ˢд���

echo [INFO] ��ʼˢдoppodycnvbk����...
%~dp0\fastboot.exe flash oppodycnvbk %~dp0\Output\dynamic_nvbk.bin
echo [SUCCESS] oppodycnvbk����ˢд���

echo [INFO] ��ʼˢдopporeserve1����...
%~dp0\fastboot.exe flash opporeserve1 %~dp0\Output\emmc_fw.bin
echo [SUCCESS] opporeserve1����ˢд���

echo [INFO] ��ʼˢдopporeserve2����...
%~dp0\fastboot.exe flash opporeserve2 %~dp0\Output\opporeserve2.img
echo [SUCCESS] opporeserve2����ˢд���

echo [INFO] ��ʼˢдoppostanvbk����...
%~dp0\fastboot.exe flash oppostanvbk %~dp0\Output\static_nvbk.bin
echo [SUCCESS] oppostanvbk����ˢд���

echo [INFO] ��ʼˢдperist����...
%~dp0\fastboot.exe flash perist %~dp0\Output\persist.img
echo [SUCCESS] perist����ˢд���

echo [INFO] ��ʼˢдqupfw����...
%~dp0\fastboot.exe flash qupfw %~dp0\Output\qupv3fw.elf
echo [SUCCESS] qupfw����ˢд���

echo [INFO] ��ʼˢдrecovery����...
%~dp0\fastboot.exe flash recovery %~dp0\Output\recovery.img
echo [SUCCESS] recovery����ˢд���

echo [INFO] ��ʼˢдsec����...
%~dp0\fastboot.exe flash sec %~dp0\Output\sec_smt.dat
echo [SUCCESS] sec����ˢд���

echo [INFO] ��ʼˢдsplash����...
%~dp0\fastboot.exe flash splash %~dp0\Output\splash.img
echo [SUCCESS] splash����ˢд���

echo [INFO] ��ʼˢдstorsec����...
%~dp0\fastboot.exe flash storsec %~dp0\Output\storsec.mbn
echo [SUCCESS] storsec����ˢд���

echo [INFO] ��ʼˢдsystem����...
%~dp0\fastboot.exe flash system %~dp0\Output\system.img
echo [SUCCESS] system����ˢд���

echo [INFO] ��ʼˢдtz����...
%~dp0\fastboot.exe flash tz %~dp0\Output\tz.mbn
echo [SUCCESS] tz����ˢд���

echo [INFO] ��ʼˢдuserdata����...
%~dp0\fastboot.exe flash userdata %~dp0\Output\userdata.img
echo [SUCCESS] userdata����ˢд���

echo [INFO] ��ʼˢдvbmeta����...
%~dp0\fastboot.exe flash vbmeta %~dp0\Output\vbmeta.img
echo [SUCCESS] vbmeta����ˢд���

echo [INFO] ��ʼˢдvendor����...
%~dp0\fastboot.exe flash vendor %~dp0\Output\vendor.img 
echo [SUCCESS] vendor����ˢд���


echo [INFO] ��ʼˢдxbl����...
%~dp0\fastboot.exe flash xbl %~dp0\Output\xbl.elf
echo [SUCCESS] xbl����ˢд���


echo [INFO] ��ʼˢдxbl_config����...
%~dp0\fastboot.exe flash xbl_config %~dp0\Output\xbl_config.elf
echo [SUCCESS] xbl_config����ˢд���

echo ===================================================
echo ȫ������ˢд��� ���������豸... 3
echo ===================================================
timeout /t 1 > nul
echo ===================================================
echo ȫ������ˢд��� ���������豸... 2
echo ===================================================
timeout /t 1 > nul
echo ===================================================
echo ȫ������ˢд��� ���������豸... 1
echo ===================================================
timeout /t 1 > nul
echo ===================================================
echo ȫ������ˢд��� ���������豸... 0
echo ===================================================
echo ===================================================
echo �������豸������������...
echo ===================================================
%~dp0\fastboot.exe reboot


@echo off
echo ==============================================================================
echo ͨ��[����Ŀ¼]\Scripts\realScript.bat�Զ���ˢ���ű�
echo ==============================================================================

echo [DEBUG] ���Fastboot·��
dir /a .\ | findstr "fastboot.exe"

echo [DEBUG] ��⾵���ļ�·��[elf]
dir /a .\Output\ | findstr "abl.elf"

echo [DEBUG] ��⾵���ļ�·��[mbn]
dir /a .\Output\ | findstr "tz.mbn"

echo [DEBUG] ��⾵���ļ�·��[bin]
dir /a .\Output\ | findstr "dynamic_nvbk.bin"

echo [DEBUG] ��⾵���ļ�·��[img]
dir /a .\Output\ | findstr "system.img"

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
.\fastboot.exe flash abl .\Output\abl.elf
echo abl����ˢд���

echo [INFO] ��ʼˢдaop����...
.\fastboot.exe flash aop .\Output\aop.mbn
echo [SUCCESS] abl����ˢд���


echo [INFO] ��ʼˢдapdp����...
.\fastboot.exe flash apdp .\Output\dpAP.mbn
echo [SUCCESS] apdp����ˢд���


echo [INFO] ��ʼˢдbluetooth����...
.\fastboot.exe flash bluetooth .\Output\BTFM.bin
echo [SUCCESS] bluetooth����ˢд���

echo [INFO] ��ʼˢдboot����...
.\fastboot.exe flash boot .\Output\boot.img
echo [SUCCESS] boot����ˢд���

echo [INFO] ��ʼˢдcache����...
.\fastboot.exe flash cache .\Output\cache.img
echo [SUCCESS] cache����ˢд���

REM echo [INFO] ��ʼˢдcdt����...
REM .\fastboot.exe flash cdt .\Output\oppo.mbn
echo [SUCCESS] cdt����ˢд���

echo [INFO] ��ʼˢдcmnlib����...
.\fastboot.exe flash cmnlib .\Output\cmnlib.mbn
echo [SUCCESS] cmnlib����ˢд���

echo [INFO] ��ʼˢдcmnlib64����...
.\fastboot.exe flash cmnlib64 .\Output\cmnlib64.mbn
echo [SUCCESS] cmnlib64����ˢд���

echo [INFO] ��ʼˢдdevcfg����...
.\fastboot.exe flash devcfg .\Output\devcfg.mbn
echo [SUCCESS] devcfg����ˢд���

echo [INFO] ��ʼˢдdsp����...
.\fastboot.exe flash dsp .\Output\dspso.bin
echo [SUCCESS] dsp����ˢд���

echo [INFO] ��ʼˢдdtbo����...
.\fastboot.exe flash dtbo .\Output\dtbo.img
echo [SUCCESS] dtbo����ˢд���

echo [INFO] ��ʼˢдhyp����...
.\fastboot.exe flash hyp .\Output\hyp.mbn
echo [SUCCESS] hyp����ˢд���

echo [INFO] ��ʼˢдhypbak����...
.\fastboot.exe flash hypbak .\Output\hyp.mbn
echo [SUCCESS] hypbak����ˢд���

echo [INFO] ��ʼˢдkeymaster����...
.\fastboot.exe flash keymaster .\Output\keymaster64.mbn
echo [SUCCESS] keymaster����ˢд���

echo [INFO] ��ʼˢдlogfs����...
.\fastboot.exe flash logfs .\Output\logfs_ufs_8mb.bin
echo [SUCCESS] logfs����ˢд���

echo [INFO] ��ʼˢдmodem����...
.\fastboot.exe flash modem .\Output\NON-HLOS.bin
echo [SUCCESS] modem����ˢд���

echo [INFO] ��ʼˢдmsadp����...
.\fastboot.exe flash msadp .\Output\dpMSA.mbn
echo [SUCCESS] msadp����ˢд���

echo [INFO] ��ʼˢдoppodycnvbk����...
.\fastboot.exe flash oppodycnvbk .\Output\dynamic_nvbk.bin
echo [SUCCESS] oppodycnvbk����ˢд���

echo [INFO] ��ʼˢдopporeserve1����...
.\fastboot.exe flash opporeserve1 .\Output\emmc_fw.bin
echo [SUCCESS] opporeserve1����ˢд���

echo [INFO] ��ʼˢдopporeserve2����...
.\fastboot.exe flash opporeserve2 .\Output\opporeserve2.img
echo [SUCCESS] opporeserve2����ˢд���

echo [INFO] ��ʼˢдoppostanvbk����...
.\fastboot.exe flash oppostanvbk .\Output\static_nvbk.bin
echo [SUCCESS] oppostanvbk����ˢд���

echo [INFO] ��ʼˢдperist����...
.\fastboot.exe flash perist .\Output\persist.img
echo [SUCCESS] perist����ˢд���

echo [INFO] ��ʼˢдqupfw����...
.\fastboot.exe flash qupfw .\Output\qupv3fw.elf
echo [SUCCESS] qupfw����ˢд���

echo [INFO] ��ʼˢдrecovery����...
.\fastboot.exe flash recovery .\Output\recovery.img
echo [SUCCESS] recovery����ˢд���

echo [INFO] ��ʼˢдsec����...
.\fastboot.exe flash sec .\Output\sec_smt.dat
echo [SUCCESS] sec����ˢд���

echo [INFO] ��ʼˢдsplash����...
.\fastboot.exe flash splash .\Output\splash.img
echo [SUCCESS] splash����ˢд���

echo [INFO] ��ʼˢдstorsec����...
.\fastboot.exe flash storsec .\Output\storsec.mbn
echo [SUCCESS] storsec����ˢд���

echo [INFO] ��ʼˢдsystem����...
.\fastboot.exe flash system .\Output\system.img
echo [SUCCESS] system����ˢд���

echo [INFO] ��ʼˢдtz����...
.\fastboot.exe flash tz .\Output\tz.mbn
echo [SUCCESS] tz����ˢд���

echo [INFO] ��ʼˢдuserdata����...
.\fastboot.exe flash userdata .\Output\userdata.img
echo [SUCCESS] userdata����ˢд���

echo [INFO] ��ʼˢдvbmeta����...
.\fastboot.exe flash vbmeta .\Output\vbmeta.img
echo [SUCCESS] vbmeta����ˢд���

echo [INFO] ��ʼˢдvendor����...
.\fastboot.exe flash vendor .\Output\vendor.img 
echo [SUCCESS] vendor����ˢд���


echo [INFO] ��ʼˢдxbl����...
.\fastboot.exe flash xbl .\Output\xbl.elf
echo [SUCCESS] xbl����ˢд���


echo [INFO] ��ʼˢдxbl_config����...
.\fastboot.exe flash xbl_config .\Output\xbl_config.elf
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
.\fastboot.exe reboot


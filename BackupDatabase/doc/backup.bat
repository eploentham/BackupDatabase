//--- Begin Batch File ---//
::
:: Creates a backup of all databases in MySQL.
:: Zip, encrypts and emails the backup file.
::
:: Each database is saved to a seperate file in a new folder.
:: The folder is zipped and then deleted. 
:: the zipped backup is encrypted and then emailed, unless the file exceeds the maximum filesize
:: In all cases the logfile is emailed.
:: The encrypted backup is deleted, leaving the unencrypted zipfile on your local machine.
::
:: Version 1.1 
::
:: Changes in version 1.1 (released June 29th, 2006)
:: - backups are now sent to the address specified by the mailto variable
::
:: The initial version 1.0 was released on May 27th, 2006
:: 
::
:: This version of the script was written by Mathieu van Loon (mathieu-public@jijenik.com)
:: It is based heavily on the script by Wade Hedgren (see comments at http://dev.mysql.com/doc/refman/5.0/en/mysqldump.html)
::
:: This script requires several freeware libraries:
:: - zipgenius (a compression tool), www.zipgenius.it
:: - blat (an emailer tool), www.blat.net
:: - doff (extracts datetime, ignores regional formatting), www.jfitz.com/dos/index.html
::
:: Some areas where this script could be improved:
:: - include error trapping and handling
:: - make steps such as encryption and email optional 
:: - allow the user to specify a single database on the command line
::
@echo off

::
:: Configuration options
::

:: The threshold for emailing the backup file. If the backup is larger 
:: it will not be emailed (the logfile is always sent).
set maxmailsize=10000000

:: The passphrase used to encrypt the zipfile. Longer is more secure.
set passphrase=secret

:: Name of the database user
set dbuser=root

:: Password for the database user
set dbpass=Ekartc2c5

:: Recipients of database backup, comma seperated, enclosed in quotes
set mailto="backups@example.com,backups2@example.com"

:: From address for email
set mailfrom="MySQL Backup Service <noreply@example.com>"

:: Email server
set mailsmtp=localhost

:: Email subject
set mailsubject="MySQL Backup"

:: directory where logfiles are stored
set logdir=C:\DatabaseBackups\logs

:: directory where backup files are stored
set bkupdir=C:\DatabaseBackups

:: Install folder of MySQL
set mysqldir=C:\xampp\mysql\bin

:: Data directory of MySQL (only used to enumerate databases, we use mysqldump for backup)
set datadir=D:\Data\MySQL

:: Path of zipgenius compression tool
set zip=C:\Program Files\7-Zip

:: Path of blat mail tool
set mail=C:\DatabaseBackups\Backupscript\libraries\Blat250\full\blat.exe

:: Path of doff date tool (specify only the folder not the exe)
set doff=D:\DatabaseBackups\Backupscript\libraries\doff10

::
::
:: NO NEED TO CHANGE ANYTHING BELOW
::
::

:: get the date and then parse it into variables
pushd %doff%
for /f %%i in ('doff.exe yyyymmdd_hhmiss') do set fn=%%i
for /f %%i in ('doff.exe dd-mm-yyyy hh:mi:ss') do set nicedate=%%i
popd

set logfile="%logdir%\%fn%_Backuplog.txt"

:: Switch to the data directory to enumerate the folders
pushd "%datadir%"

:: Write to the log file
echo Beginning MySQLDump Process > %logfile%
echo Start Time = %nicedate% >> %logfile%
echo --------------------------- >> %logfile%
echo. >> %logfile%

:: Create the backup folder
if not exist "%bkupdir%\%fn%\" (
echo Making Directory %fn%
echo Making Directory %fn% >> %logfile%

mkdir "%bkupdir%\%fn%"
)

:: Loop through the data structure in the data dir to get the database names
for /d %%f in (*) do (

:: Run mysqldump on each database and compress the data by piping through gZip
echo Backing up database %fn%_%%f.sql
echo Backing up database %fn%_%%f.sql >> %logfile%
"%mysqldir%\bin\mysqldump" --user=%dbuser% --password=%dbpass% --databases %%f --opt --quote-names --allow-keywords --complete-insert > "%bkupdir%\%fn%\%fn%_%%f.sql"
echo Done... >> %logfile%
)

:: return from data dir
popd

pushd %bkupdir%

echo Zipping databases
echo Zipping databases >> %logfile%
REM C9 : maximum compression
REM AM : Delete source files
REM F1 : Store relative path
REM R1 : include subfolders
REM K0 : Do not display progress

"%zip%" -add "%fn%_MySQLBackup.zip" C9 AM F1 R1 K0 +"%bkupdir%\%fn%"

echo Crypting zipfile
echo Crypting zipfile >> %logfile%

REM C : Create non-executable zip
REM S : Do not delete after x tries
REM 3 : Use AES encryption
"%zip%" -encrypt "%fn%_MySQLBackup.zip" C S 3 "%passphrase%" %mailfrom%

echo Deleting directory %fn%
echo Deleting directory %fn% >> %logfile%

rmdir /s /q "%bkupdir%\%fn%"

:: Go back and get the end time for the script
set endtime=1

:: return from backup dir
popd

:: update the nicedate for the log
pushd %doff%
for /f %%i in ('doff.exe dd-mm-yyyy hh:mi:ss') do set nicedate=%%i
popd

:: Write to the log file
echo. >> %logfile%
echo --------------------------- >> %logfile%
echo MySQLDump Process Finished >> %logfile%
echo End Time = %nicedate% >> %logfile%
echo. >> %logfile%

:: Send the log file in an e-mail, include the backup file if it is not too large
:: We use the CALL Trick to enable determination of the filesize (type CALL /? at prompt for info)
:: note that you _must_ specify the full filename as the argument

pushd %bkupdir%
Call :MAILFILE "%bkupdir%\%fn%_MySQLBackup.czip"
echo Backup completed
goto :EOF

:MAILFILE

if /i %~z1 LSS %maxmailsize% (
echo Emailing backup file
"%mail%" %logfile% -q -attach %1 -serverSMTP %mailsmtp% -f %mailfrom% -to %mailto% -subject %mailsubject%
) ELSE (
echo Size of backup file %~z1 B exceeds configured email size %maxmailsize% B.
echo Emailing logfile only
echo Size of backup file %~z1 B exceeds configured email size %maxmailsize% B. only emailing logfile. >> %logfile%

"%mail%" %logfile% -q -serverSMTP %mailsmtp% -f %mailfrom% -to %mailto% -subject %mailsubject%
)

echo Deleting encrypted backup file
del %1

popd
//--- End Batch File ---//
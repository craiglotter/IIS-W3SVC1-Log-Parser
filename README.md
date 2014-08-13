IIS W3SVC1 Log Parser
=====================

Based on the IIS W3SVC1 Log Monitor program code, IIS W3SVC1 Log Parser is used to parse specified IIS W3SVC1 format log files and place the results into a MsAccess database. The form of a valid W3SVC1 compliant log file is recorded in the editable config.ini load file.

The default format of valid log files is as follows: (single line, space delimited)
date time s-sitename s-computername s-ip cs-method cs-uri-stem cs-uri-query 
s-port cs-username c-ip cs-version cs(User-Agent) cs(Cookie) cs(Referer)
cs-host sc-status sc-substatus sc-win32-status sc-bytes cs-bytes 
time-taken

Created by Craig Lotter, October 2005

*********************************

Project Details:

Coded in Visual Basic .NET using Visual Studio .NET 2003
Implements concepts such as threading, file manipulation and SQL statements.
Level of Complexity: simple

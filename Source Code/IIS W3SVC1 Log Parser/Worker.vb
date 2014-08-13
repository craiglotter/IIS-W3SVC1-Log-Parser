Imports System.IO
Imports System.Web.Mail
Public Class Worker

    Inherits System.ComponentModel.Component

    ' Declares the variables you will use to hold your thread objects.

    Public WorkerThread As System.Threading.Thread

    Public savepath As String = ""
    Public logfolder As String = ""
    Public tablelist() As String
    
    Public result As String = ""

    Public Event WorkerComplete(ByVal Result As String)
    Public Event WorkerProgress(ByVal filesparsed As Long, ByVal entriesfound As Long, ByVal currentfile As String, ByVal totalfiles As Long, ByVal bytesread As Long, ByVal bytestotal As Long)
    Public Event WorkerFileUpdate(ByVal entriesfound As Long, ByVal currentfile As String)


#Region " Component Designer generated code "

    Public Sub New(ByVal Container As System.ComponentModel.IContainer)
        MyClass.New()

        'Required for Windows.Forms Class Composition Designer support
        Container.Add(Me)
    End Sub

    Public Sub New()
        MyBase.New()

        'This call is required by the Component Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Component overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Component Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Component Designer
    'It can be modified using the Component Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        components = New System.ComponentModel.Container
    End Sub

#End Region

    Private Sub Error_Handler(ByVal exc As Exception)
        Try
            If exc.Message.IndexOf("Thread was being aborted") < 0 Then
                Dim Display_Message1 As New Display_Message("The Worker Thread encountered the following problem: " & vbCrLf & exc.ToString)
                Display_Message1.ShowDialog()
                Dim dir As DirectoryInfo = New DirectoryInfo((Application.StartupPath & "\").Replace("\\", "\") & "Error Logs")
                If dir.Exists = False Then
                    dir.Create()
                End If
                Dim filewriter As StreamWriter = New StreamWriter((Application.StartupPath & "\").Replace("\\", "\") & "Error Logs\" & Format(Now(), "yyyyMMdd") & "_Error_Log.txt", True)
                filewriter.WriteLine("#" & Format(Now(), "dd/MM/yyyy hh:mm:ss tt") & " - " & exc.ToString)
                filewriter.Flush()
                filewriter.Close()
            End If
        Catch ex As Exception
            MsgBox("An error occurred in IIS W3SVC1 Log Parser's error handling routine. The application will try to recover from this serious error.", MsgBoxStyle.Critical, "Critical Error Encountered")
        End Try
    End Sub

    Private Sub Error_Handler(ByVal message As String)
        Try
            If message.IndexOf("Thread was being aborted") < 0 Then
                Dim Display_Message1 As New Display_Message("The Worker Thread encountered the following problem: " & vbCrLf & message)
                Display_Message1.ShowDialog()
                Dim dir As DirectoryInfo = New DirectoryInfo((Application.StartupPath & "\").Replace("\\", "\") & "Error Logs")
                If dir.Exists = False Then
                    dir.Create()
                End If
                Dim filewriter As StreamWriter = New StreamWriter((Application.StartupPath & "\").Replace("\\", "\") & "Error Logs\" & Format(Now(), "yyyyMMdd") & "_Error_Log.txt", True)
                filewriter.WriteLine("#" & Format(Now(), "dd/MM/yyyy hh:mm:ss tt") & " - " & message)
                filewriter.Flush()
                filewriter.Close()
            End If
        Catch ex As Exception
            MsgBox("An error occurred in IIS W3SVC1 Log Parser's error handling routine. The application will try to recover from this serious error.", MsgBoxStyle.Critical, "Critical Error Encountered")
        End Try
    End Sub

    Public Sub ChooseThreads(ByVal threadNumber As Integer)
        Try
            ' Determines which thread to start based on the value it receives.
            Select Case threadNumber
                Case 1
                    ' Sets the thread using the AddressOf the subroutine where
                    ' the thread will start.
                    WorkerThread = New System.Threading.Thread(AddressOf WorkerExecute)
                    ' Starts the thread.
                    WorkerThread.Start()

            End Select
        Catch ex As Exception
            Error_Handler(ex.Message)
        End Try
    End Sub

    Public Sub WorkerExecute()
        Try
            Dim path, path2 As String
            path = savepath
            path2 = (Application.StartupPath & "\").Replace("\\", "\") & "IIS W3SVC1 Log Template.mdb"
            Dim databasebackup As FileInfo = New FileInfo(path2)
            If databasebackup.Exists = True Then
                Dim database As FileInfo = New FileInfo(path)
                If database.Exists = False Then
                    If databasebackup.Exists = True Then
                        File.Copy(path2, path)
                    End If
                End If
                Dim dinfo As DirectoryInfo = New DirectoryInfo(logfolder)

                database = (New FileInfo(path))
                While database.Exists = False

                End While

                If database.Exists = True Then
                    If dinfo.Exists = True Then
                        If dinfo.GetFiles.Length > 0 Then

                            Dim Conn As Data.OleDb.OleDbConnection
                            Conn = New Data.OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & database.FullName & ";")
                            Conn.Open()


                            dinfo = New DirectoryInfo(logfolder)
                            Dim finfo As FileInfo
                            Dim count As Integer
                            count = dinfo.GetFiles.Length
                            Dim runner As Long = 0
                            Dim linecount As Long
                            linecount = 0
                            Dim filelinecount As Long
                            filelinecount = 0
                            Dim filebytesread As Long
                            filebytesread = 0
                            Dim totalfilecount As Long = dinfo.GetFiles.Length
                            Dim run As Integer


                            


                            For Each finfo In dinfo.GetFiles
                                Try
                                    RaiseEvent WorkerProgress(runner, linecount, finfo.Name, dinfo.GetFiles.Length, 0, finfo.Length)
                                    runner = runner + 1
                                    If runner <= count And count > 0 Then



                                        Dim filereader As StreamReader
                                        filereader = New StreamReader(finfo.FullName, True)




                                        Dim sql As String
                                        Dim lineread As String
                                        filelinecount = 0
                                        filebytesread = 0
                                        lineread = filereader.ReadLine()
                                        While Not lineread Is Nothing
                                            Try

                                           
                                            filebytesread = filebytesread + (lineread.Length)
                                            If Not lineread.StartsWith("#") = True And lineread.Length > 0 Then
                                                linecount = linecount + 1
                                                filelinecount = filelinecount + 1

                                                RaiseEvent WorkerProgress(runner, linecount, finfo.Name, dinfo.GetFiles.Length, filebytesread, finfo.Length)
                                                RaiseEvent WorkerFileUpdate(filelinecount, finfo.Name)
                                                Dim results As String()
                                                lineread = lineread.Replace("""", "``")
                                                results = lineread.Split(" ")
                                                Dim small As String

                                                run = 0
                                                If results.Length = tablelist.Length Then


                                                    For Each small In results
                                                        Dim count2 As Long

                                                        sql = "select * from " & "log_" & tablelist(run) & " where log_value = """ & small & """"

                                                        Dim recset As Data.OleDb.OleDbCommand = New Data.OleDb.OleDbCommand(sql, Conn)
                                                        Dim recread As Data.OleDb.OleDbDataReader
                                                        recread = recset.ExecuteReader()
                                                        Dim action As Boolean
                                                        If recread.HasRows Then
                                                            recread.Read()
                                                            count2 = CLng(recread.Item(recread.GetOrdinal("log_count"))) + 1
                                                            action = True
                                                        Else
                                                            count2 = 1
                                                            action = False
                                                        End If

                                                        recread.Close()
                                                        recset.Dispose()

                                                        If small.Length > 255 Then
                                                            small = small.Substring(0, 255)
                                                        End If
                                                        If action = True Then
                                                            sql = "update " & "log_" & tablelist(run) & " set log_count = " & count2 & " where log_value = """ & small & """"
                                                        Else
                                                            sql = "insert into " & "log_" & tablelist(run) & " values (""" & small & """," & count2 & ")"
                                                        End If

                                                        recset = New Data.OleDb.OleDbCommand(sql, Conn)
                                                        Dim result As Integer
                                                        result = (recset.ExecuteNonQuery())
                                                        recset.Dispose()
                                                        run = run + 1

                                                    Next
                                                Else

                                                    sql = "insert into log_errors values (""" & lineread & """)"
                                                    Dim recset As Data.OleDb.OleDbCommand
                                                    recset = New Data.OleDb.OleDbCommand(sql, Conn)
                                                    Dim result As Integer
                                                    result = (recset.ExecuteNonQuery())
                                                    recset.Dispose()

                                                End If
                                            End If


                                                lineread = filereader.ReadLine()
                                            Catch ex As Exception
                                                Error_Handler("An """ & ex.Message & """ error occurred while parsing the log file.")
                                            End Try
                                        End While
                                        RaiseEvent WorkerProgress(runner, linecount, finfo.Name, dinfo.GetFiles.Length, finfo.Length, finfo.Length)
                                        filereader.Close()
                                        'File.Delete(finfo.FullName)
                                    End If
                                Catch ex As Exception
                                    Error_Handler("An """ & ex.Message & """ error occurred while parsing the log file.")
                                End Try

                            Next


                            Conn.Close()
                            Conn.Dispose()
                            database = Nothing


                        Else
                            RaiseEvent WorkerProgress(0, 0, "", 0, 0, 0)
                            Error_Handler("The specified log folder is empty.")
                        End If
                    Else
                        RaiseEvent WorkerProgress(0, 0, "", 0, 0, 0)
                        Error_Handler("The specified log folder doesn't exist.")
                    End If
                Else
                    RaiseEvent WorkerProgress(0, 0, "", 0, 0, 0)
                    Error_Handler("No valid Database could be located to store results in.")
                End If
            Else
                RaiseEvent WorkerProgress(0, 0, "", 0, 0, 0)
                Error_Handler("No valid Database could be located to store results in.")
            End If
            result = "Success"
            RaiseEvent WorkerComplete(result)
        Catch ex As Exception
            result = "Failure"
            RaiseEvent WorkerComplete(result)
        End Try

        WorkerThread.Abort()
    End Sub







End Class

Imports Microsoft.Win32
Imports System.IO

Public Class Monitor_Program
    Inherits System.Windows.Forms.Form

    Dim WithEvents Worker1 As Worker
    Public Delegate Sub WorkerhHandler(ByVal Result As String)
    Public Delegate Sub WorkerProgresshHandler(ByVal filesparsed As Long, ByVal entriesfound As Long, ByVal currentfile As String, ByVal totalfiles As Long, ByVal bytesread As Long, ByVal bytestotal As Long)
    Public Delegate Sub WorkerFileUpdatehHandler(ByVal entriesfound As Long, ByVal currentfile As String)



#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Worker1 = New Worker
        AddHandler Worker1.WorkerComplete, AddressOf WorkerHandler
        AddHandler Worker1.WorkerProgress, AddressOf WorkerProgressHandler
        AddHandler Worker1.WorkerFileUpdate, AddressOf WorkerFileUpdateHandler
    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents ContextMenu1 As System.Windows.Forms.ContextMenu
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents label22 As System.Windows.Forms.TextBox
    Friend WithEvents secretlabel As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents Update_Listbox As System.Windows.Forms.CheckBox
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents savepathtxt As System.Windows.Forms.TextBox
    Friend WithEvents logfoldertxt As System.Windows.Forms.TextBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Button4 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Monitor_Program))
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Button3 = New System.Windows.Forms.Button
        Me.Label25 = New System.Windows.Forms.Label
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.savepathtxt = New System.Windows.Forms.TextBox
        Me.logfoldertxt = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Update_Listbox = New System.Windows.Forms.CheckBox
        Me.ListBox1 = New System.Windows.Forms.ListBox
        Me.label22 = New System.Windows.Forms.TextBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.PictureBox5 = New System.Windows.Forms.PictureBox
        Me.PictureBox4 = New System.Windows.Forms.PictureBox
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.Label8 = New System.Windows.Forms.Label
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ContextMenu1 = New System.Windows.Forms.ContextMenu
        Me.MenuItem1 = New System.Windows.Forms.MenuItem
        Me.MenuItem2 = New System.Windows.Forms.MenuItem
        Me.MenuItem3 = New System.Windows.Forms.MenuItem
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.secretlabel = New System.Windows.Forms.Label
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog
        Me.Label9 = New System.Windows.Forms.Label
        Me.Button4 = New System.Windows.Forms.Button
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Peru
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label17)
        Me.Panel1.Controls.Add(Me.Label20)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Controls.Add(Me.Label25)
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.savepathtxt)
        Me.Panel1.Controls.Add(Me.logfoldertxt)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.label22)
        Me.Panel1.Controls.Add(Me.Label23)
        Me.Panel1.Controls.Add(Me.Label19)
        Me.Panel1.Controls.Add(Me.Label18)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.PictureBox5)
        Me.Panel1.Controls.Add(Me.PictureBox4)
        Me.Panel1.Controls.Add(Me.PictureBox3)
        Me.Panel1.Controls.Add(Me.PictureBox2)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label24)
        Me.Panel1.Location = New System.Drawing.Point(8, 31)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(600, 233)
        Me.Panel1.TabIndex = 11
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Peru
        Me.Label17.ForeColor = System.Drawing.Color.Gold
        Me.Label17.Location = New System.Drawing.Point(144, 136)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(152, 16)
        Me.Label17.TabIndex = 58
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.Peru
        Me.Label20.Location = New System.Drawing.Point(8, 136)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(288, 16)
        Me.Label20.TabIndex = 57
        Me.Label20.Text = "Current Log Progress:"
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Peru
        Me.Label13.Location = New System.Drawing.Point(144, 120)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(152, 16)
        Me.Label13.TabIndex = 56
        Me.Label13.Text = "0"
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Peru
        Me.Label16.Location = New System.Drawing.Point(8, 120)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(288, 16)
        Me.Label16.TabIndex = 55
        Me.Label16.Text = "Current Log Bytes Read:"
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.SandyBrown
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Location = New System.Drawing.Point(488, 192)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(96, 23)
        Me.Button3.TabIndex = 54
        Me.Button3.Text = "Parse Log Files"
        '
        'Label25
        '
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(304, 8)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(109, 16)
        Me.Label25.TabIndex = 53
        Me.Label25.Text = "SAVE PATH"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.Black
        Me.Button2.Location = New System.Drawing.Point(530, 26)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(56, 16)
        Me.Button2.TabIndex = 51
        Me.Button2.Text = "BROWSE"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.Black
        Me.Button1.Location = New System.Drawing.Point(234, 26)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(56, 16)
        Me.Button1.TabIndex = 50
        Me.Button1.Text = "BROWSE"
        '
        'savepathtxt
        '
        Me.savepathtxt.BackColor = System.Drawing.Color.WhiteSmoke
        Me.savepathtxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.savepathtxt.Location = New System.Drawing.Point(304, 24)
        Me.savepathtxt.Name = "savepathtxt"
        Me.savepathtxt.ReadOnly = True
        Me.savepathtxt.Size = New System.Drawing.Size(224, 20)
        Me.savepathtxt.TabIndex = 49
        Me.savepathtxt.Text = ""
        '
        'logfoldertxt
        '
        Me.logfoldertxt.BackColor = System.Drawing.Color.WhiteSmoke
        Me.logfoldertxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.logfoldertxt.Location = New System.Drawing.Point(8, 24)
        Me.logfoldertxt.Name = "logfoldertxt"
        Me.logfoldertxt.ReadOnly = True
        Me.logfoldertxt.Size = New System.Drawing.Size(224, 20)
        Me.logfoldertxt.TabIndex = 48
        Me.logfoldertxt.Text = ""
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Update_Listbox)
        Me.GroupBox1.Controls.Add(Me.ListBox1)
        Me.GroupBox1.Location = New System.Drawing.Point(304, 56)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(280, 116)
        Me.GroupBox1.TabIndex = 47
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Log Files Parsed this Session"
        '
        'Update_Listbox
        '
        Me.Update_Listbox.BackColor = System.Drawing.Color.Peru
        Me.Update_Listbox.Checked = True
        Me.Update_Listbox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Update_Listbox.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Update_Listbox.ForeColor = System.Drawing.Color.White
        Me.Update_Listbox.Location = New System.Drawing.Point(254, 8)
        Me.Update_Listbox.Name = "Update_Listbox"
        Me.Update_Listbox.Size = New System.Drawing.Size(16, 16)
        Me.Update_Listbox.TabIndex = 48
        '
        'ListBox1
        '
        Me.ListBox1.BackColor = System.Drawing.Color.Peru
        Me.ListBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListBox1.ForeColor = System.Drawing.Color.Gold
        Me.ListBox1.Location = New System.Drawing.Point(8, 28)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(264, 78)
        Me.ListBox1.TabIndex = 0
        '
        'label22
        '
        Me.label22.BackColor = System.Drawing.Color.Peru
        Me.label22.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.label22.ForeColor = System.Drawing.Color.White
        Me.label22.Location = New System.Drawing.Point(144, 104)
        Me.label22.Name = "label22"
        Me.label22.Size = New System.Drawing.Size(152, 13)
        Me.label22.TabIndex = 46
        Me.label22.Text = ""
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.Color.Peru
        Me.Label23.Location = New System.Drawing.Point(8, 104)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(272, 16)
        Me.Label23.TabIndex = 44
        Me.Label23.Text = "Current Log File:"
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.Peru
        Me.Label19.Location = New System.Drawing.Point(144, 168)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(152, 16)
        Me.Label19.TabIndex = 41
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.Peru
        Me.Label18.Location = New System.Drawing.Point(144, 152)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(152, 16)
        Me.Label18.TabIndex = 40
        Me.Label18.Text = "0"
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Peru
        Me.Label15.Location = New System.Drawing.Point(8, 168)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(288, 16)
        Me.Label15.TabIndex = 37
        Me.Label15.Text = "Analysis End:"
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Peru
        Me.Label14.Location = New System.Drawing.Point(8, 152)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(288, 16)
        Me.Label14.TabIndex = 36
        Me.Label14.Text = "Total Entries Analysed:"
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Peru
        Me.Label12.Location = New System.Drawing.Point(144, 88)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(152, 16)
        Me.Label12.TabIndex = 35
        Me.Label12.Text = "0"
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Peru
        Me.Label11.Location = New System.Drawing.Point(144, 72)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(152, 16)
        Me.Label11.TabIndex = 34
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Peru
        Me.Label10.Location = New System.Drawing.Point(144, 56)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(152, 16)
        Me.Label10.TabIndex = 33
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.White
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Gray
        Me.Label7.Location = New System.Drawing.Point(16, 185)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(112, 26)
        Me.Label7.TabIndex = 32
        Me.Label7.Text = "Resting..."
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Peru
        Me.Label6.Location = New System.Drawing.Point(8, 88)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(272, 16)
        Me.Label6.TabIndex = 31
        Me.Label6.Text = "Log Files Parsed:"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Peru
        Me.Label5.Location = New System.Drawing.Point(8, 72)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(272, 16)
        Me.Label5.TabIndex = 30
        Me.Label5.Text = "Analysis Start:"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Peru
        Me.Label3.Location = New System.Drawing.Point(8, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(272, 16)
        Me.Label3.TabIndex = 29
        Me.Label3.Text = "Program Launched:"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.LimeGreen
        Me.Label1.Location = New System.Drawing.Point(224, 192)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 16)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = "Monitoring"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PictureBox5
        '
        Me.PictureBox5.BackgroundImage = CType(resources.GetObject("PictureBox5.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(200, 192)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox5.TabIndex = 26
        Me.PictureBox5.TabStop = False
        '
        'PictureBox4
        '
        Me.PictureBox4.BackgroundImage = CType(resources.GetObject("PictureBox4.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(184, 192)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox4.TabIndex = 25
        Me.PictureBox4.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.BackgroundImage = CType(resources.GetObject("PictureBox3.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(168, 192)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox3.TabIndex = 24
        Me.PictureBox3.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackgroundImage = CType(resources.GetObject("PictureBox2.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(152, 192)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox2.TabIndex = 23
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(136, 192)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox1.TabIndex = 22
        Me.PictureBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Location = New System.Drawing.Point(8, 184)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(288, 32)
        Me.Label2.TabIndex = 28
        Me.Label2.Text = "Label2"
        '
        'Label24
        '
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(8, 8)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(109, 16)
        Me.Label24.TabIndex = 52
        Me.Label24.Text = "LOG FOLDER"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.IndianRed
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(8, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(120, 24)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "IIS Log Parser"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ImageList1
        '
        Me.ImageList1.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'Timer2
        '
        Me.Timer2.Interval = 1000
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(504, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(112, 16)
        Me.Label8.TabIndex = 33
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.ToolTip1.SetToolTip(Me.Label8, "Current System Time")
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.ContextMenu = Me.ContextMenu1
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "Resting..."
        Me.NotifyIcon1.Visible = True
        '
        'ContextMenu1
        '
        Me.ContextMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1, Me.MenuItem2, Me.MenuItem3})
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 0
        Me.MenuItem1.Text = "Display Monitor Screen"
        '
        'MenuItem2
        '
        Me.MenuItem2.Index = 1
        Me.MenuItem2.Text = "-"
        '
        'MenuItem3
        '
        Me.MenuItem3.Index = 2
        Me.MenuItem3.Text = "Exit Application"
        '
        'secretlabel
        '
        Me.secretlabel.BackColor = System.Drawing.Color.Silver
        Me.secretlabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.secretlabel.ForeColor = System.Drawing.Color.Gray
        Me.secretlabel.Location = New System.Drawing.Point(0, 216)
        Me.secretlabel.Name = "secretlabel"
        Me.secretlabel.Size = New System.Drawing.Size(8, 8)
        Me.secretlabel.TabIndex = 47
        Me.secretlabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.secretlabel.Visible = False
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.DefaultExt = "mdb"
        Me.SaveFileDialog1.Filter = "MSAccess files|*.mdb"
        Me.SaveFileDialog1.Title = "Database Save Path"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(504, 2)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(109, 8)
        Me.Label9.TabIndex = 54
        Me.Label9.Text = "BUILD 20051003.1"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Button4
        '
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.ForeColor = System.Drawing.Color.Black
        Me.Button4.Location = New System.Drawing.Point(392, 8)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(88, 16)
        Me.Button4.TabIndex = 59
        Me.Button4.Text = "KILL PROCESSES"
        '
        'Monitor_Program
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.SandyBrown
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(618, 272)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.secretlabel)
        Me.Controls.Add(Me.Button4)
        Me.ForeColor = System.Drawing.Color.White
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(624, 304)
        Me.MinimumSize = New System.Drawing.Size(624, 304)
        Me.Name = "Monitor_Program"
        Me.ShowInTaskbar = False
        Me.Text = "IIS W3SVC1 Log Parser"
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region






    Private current_light As Integer = 0
    Private current_colour As Integer = 0
    Private currently_working As Boolean = False

    Private logfolder As String
    Private savepath As String
    Private tablelist() As String



    Private Sub Error_Handler(ByVal ex As Exception)
        Try
            If ex.message.IndexOf("Thread was being aborted") < 0 Then
                Dim Display_Message1 As New Display_Message("The Monitoring Program encountered the following problem: " & vbCrLf & ex.ToString)
                Display_Message1.ShowDialog()
                Dim dir As DirectoryInfo = New DirectoryInfo((Application.StartupPath & "\").Replace("\\", "\") & "Error Logs")
                If dir.Exists = False Then
                    dir.Create()
                End If
                Dim filewriter As StreamWriter = New StreamWriter((Application.StartupPath & "\").Replace("\\", "\") & "Error Logs\" & Format(Now(), "yyyyMMdd") & "_Error_Log.txt", True)
                filewriter.WriteLine("#" & Format(Now(), "dd/MM/yyyy hh:mm:ss tt") & " - " & ex.ToString)
                filewriter.Flush()
                filewriter.Close()
            End If
        Catch exc As Exception

            MsgBox("An error occurred in IIS W3SVC1 Log Parser's error handling routine. The application will try to recover from this serious error.", MsgBoxStyle.Critical, "Critical Error Encountered")
        End Try
    End Sub


    Private Sub Error_Handler(ByVal message As String)
        Try
            If message.IndexOf("Thread was being aborted") < 0 Then
                Dim Display_Message1 As New Display_Message("The Monitoring Program encountered the following problem: " & vbCrLf & message)
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
        Catch exc As Exception

            MsgBox("An error occurred in IIS W3SVC1 Log Parser's error handling routine. The application will try to recover from this serious error.", MsgBoxStyle.Critical, "Critical Error Encountered")
        End Try
    End Sub

    Public Sub Load_Registry_Values()
        Try


            Dim configflag As Boolean
            configflag = False
            Dim str As String
            Dim keyflag1 As Boolean = False
            Dim oReg As RegistryKey = Registry.LocalMachine
            Dim keys() As String = oReg.GetSubKeyNames()
            System.Array.Sort(keys)

            For Each str In keys
                If str.Equals("Software\IIS W3SVC1 Log Parser") = True Then
                    keyflag1 = True
                    Exit For
                End If
            Next str

            If keyflag1 = False Then
                oReg.CreateSubKey("Software\IIS W3SVC1 Log Parser")
            End If

            keyflag1 = False

            Dim oKey As RegistryKey = oReg.OpenSubKey("Software\IIS W3SVC1 Log Parser", True)

            str = oKey.GetValue("logfolder")
            If Not IsNothing(str) And Not (str = "") Then
                logfolder = str
            Else
                configflag = True
                oKey.SetValue("logfolder", (Application.StartupPath & "\Logs").Replace("\\", "\"))
                logfolder = (Application.StartupPath & "\Logs").Replace("\\", "\")
            End If

            str = oKey.GetValue("savepath")
            If Not IsNothing(str) And Not (str = "") Then
                savepath = str
            Else
                configflag = True
                oKey.SetValue("savepath", (Application.StartupPath & "\Logs\savedDB.mdb").Replace("\\", "\"))
                savepath = (Application.StartupPath & "\Logs\savedDB.mdb").Replace("\\", "\")
            End If

            savepathtxt.Text = savepath
            logfoldertxt.Text = logfolder

            oKey.Close()
            oReg.Close()

        Catch ex As Exception
            Error_Handler("An """ & ex.Message & """ error occurred while loading required registry values. The program will attempt to recover shortly.")
        End Try
    End Sub

    Private Sub Save_Registry_Values()
        Try
            Dim oReg As RegistryKey = Registry.LocalMachine
            Dim oKey As RegistryKey = oReg.OpenSubKey("Software\IIS W3SVC1 Log Parser", True)

            oKey.SetValue("savepath", savepathtxt.Text)
            oKey.SetValue("logfolder", logfoldertxt.Text)

            oKey.Close()
            oReg.Close()
        Catch ex As Exception
            Error_Handler("An """ & ex.Message & """ error occurred while saving required registry values. The program will attempt to recover shortly.")
        End Try
    End Sub

    Private Sub run_green_lights()
        Try
            Label1.ForeColor = Color.LimeGreen
            Label1.Text = "Monitoring"
            Label7.Text = "Resting..."

            current_light = current_light - 1
            If current_light < 1 Then
                current_light = 5
            End If
            current_colour = 0
            PictureBox1.Image = ImageList1.Images(1)
            PictureBox2.Image = ImageList1.Images(1)
            PictureBox3.Image = ImageList1.Images(1)
            PictureBox4.Image = ImageList1.Images(1)
            PictureBox5.Image = ImageList1.Images(1)

            Select Case current_light
                Case 0

                    PictureBox1.Image = ImageList1.Images(0)
                Case 1

                    PictureBox2.Image = ImageList1.Images(0)
                Case 2

                    PictureBox3.Image = ImageList1.Images(0)
                Case 3

                    PictureBox4.Image = ImageList1.Images(0)
                Case 4

                    PictureBox5.Image = ImageList1.Images(0)
                Case 5

                    PictureBox1.Image = ImageList1.Images(0)
            End Select

            current_light = current_light + 1
            If current_light > 5 Then
                current_light = 1
            End If
        Catch ex As Exception
            Error_Handler("An """ & ex.Message & """ error occurred while changing status light colour. The program will attempt to recover shortly.")
        End Try
    End Sub

    Private Sub run_orange_lights()
        Try
            Label1.ForeColor = Color.DarkOrange
            Label1.Text = "Working"

            current_light = current_light - 1
            If current_light < 1 Then
                current_light = 5
            End If
            current_colour = 1
            PictureBox1.Image = ImageList1.Images(3)
            PictureBox2.Image = ImageList1.Images(3)
            PictureBox3.Image = ImageList1.Images(3)
            PictureBox4.Image = ImageList1.Images(3)
            PictureBox5.Image = ImageList1.Images(3)
            Select Case current_light
                Case 0
                    PictureBox1.Image = ImageList1.Images(2)
                Case 1
                    PictureBox2.Image = ImageList1.Images(2)
                Case 2
                    PictureBox3.Image = ImageList1.Images(2)
                Case 3
                    PictureBox4.Image = ImageList1.Images(2)
                Case 4
                    PictureBox5.Image = ImageList1.Images(2)
                Case 5
                    PictureBox1.Image = ImageList1.Images(2)
            End Select

            current_light = current_light + 1
            If current_light > 5 Then
                current_light = 1
            End If
        Catch ex As Exception
            Error_Handler("An """ & ex.Message & """ error occurred while changing status light colour. The program will attempt to recover shortly.")
        End Try
    End Sub

    Private Sub run_lights()
        Try
            If current_colour = 1 Then
                Select Case current_light
                    Case 0
                        PictureBox5.Image = ImageList1.Images(3)
                        PictureBox1.Image = ImageList1.Images(2)
                    Case 1
                        PictureBox1.Image = ImageList1.Images(3)
                        PictureBox2.Image = ImageList1.Images(2)
                    Case 2
                        PictureBox2.Image = ImageList1.Images(3)
                        PictureBox3.Image = ImageList1.Images(2)
                    Case 3
                        PictureBox3.Image = ImageList1.Images(3)
                        PictureBox4.Image = ImageList1.Images(2)
                    Case 4
                        PictureBox4.Image = ImageList1.Images(3)
                        PictureBox5.Image = ImageList1.Images(2)
                    Case 5
                        PictureBox5.Image = ImageList1.Images(3)
                        PictureBox1.Image = ImageList1.Images(2)
                End Select
            Else
                Select Case current_light
                    Case 0
                        PictureBox5.Image = ImageList1.Images(1)
                        PictureBox1.Image = ImageList1.Images(0)
                    Case 1
                        PictureBox1.Image = ImageList1.Images(1)
                        PictureBox2.Image = ImageList1.Images(0)
                    Case 2
                        PictureBox2.Image = ImageList1.Images(1)
                        PictureBox3.Image = ImageList1.Images(0)
                    Case 3
                        PictureBox3.Image = ImageList1.Images(1)
                        PictureBox4.Image = ImageList1.Images(0)
                    Case 4
                        PictureBox4.Image = ImageList1.Images(1)
                        PictureBox5.Image = ImageList1.Images(0)
                    Case 5
                        PictureBox5.Image = ImageList1.Images(1)
                        PictureBox1.Image = ImageList1.Images(0)
                End Select

            End If

            current_light = current_light + 1
            If current_light > 5 Then
                current_light = 1
            End If
        Catch ex As Exception
            Error_Handler("An """ & ex.Message & """ error occurred while loading the status light strip. The program will attempt to recover shortly.")
        End Try
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        Try
            run_lights()
            Label8.Text = Format(Now(), "dd/MM/yyyy hh:mm:ss tt")
        Catch ex As Exception
            Error_Handler(ex)
        End Try
    End Sub

    Private Sub Monitor_Program_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If File.Exists((Application.StartupPath & "\").Replace("\\", "\") & "config.ini") = False Then
                If File.Exists((Application.StartupPath & "\").Replace("\\", "\") & "default_config.ini") = True Then
                    File.Copy((Application.StartupPath & "\").Replace("\\", "\") & "default_config.ini", (Application.StartupPath & "\").Replace("\\", "\") & "config.ini")
                End If

            End If

            If File.Exists((Application.StartupPath & "\").Replace("\\", "\") & "config.ini") = True Then


                Dim filereader As IO.StreamReader = New StreamReader((Application.StartupPath & "\").Replace("\\", "\") & "config.ini")
                Dim tables As String = ""
                Dim line As String = ""
                While True
                    line = filereader.ReadLine
                    If line Is Nothing = True Then
                        Exit While
                    End If
                    tables = tables & " " & line
                End While
                tables = tables.Trim
                filereader.Close()
                tablelist = tables.Split(" ")

                Label8.Text = Format(Now(), "dd/MM/yyyy hh:mm:ss tt")
                Label10.Text = Format(Now(), "dd/MM/yyyy hh:mm:ss tt")
                Label11.Text = "0"
                Load_Registry_Values()

                Timer2.Start()

            Else
                Dim displ As Display_Message = New Display_Message("No required config.ini file could be located in the application startup folder. This application will no be forced to shutdown.")
                displ.ShowDialog()
                Application.Exit()
            End If
        Catch ex As Exception
            Error_Handler("An """ & ex.Message & """ error occurred while loading the monitoring screen. The program will attempt to recover shortly.")
        End Try
    End Sub

    Private Sub monitor_program_closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        Try
            Save_Registry_Values()
            If Worker1.WorkerThread Is Nothing = False Then


            Worker1.WorkerThread.Abort()
                Worker1.Dispose()
            End If
            NotifyIcon1.Dispose()
            Application.Exit()
        Catch ex As Exception
            Error_Handler("An """ & ex.Message & """ error occurred while closing the Monitoring screen. The program will attempt to recover shortly.")
        End Try
    End Sub



    Public Sub WorkerHandler(ByVal Result As String)
        Try
            currently_working = False
            Label19.Text = Format(Now(), "dd/MM/yyyy hh:mm:ss tt")
            ' Label23.Text = "Ignored Log File:"
            Label6.Text = "Log Files Parsed:"

            Label7.Text = secretlabel.Text
            NotifyIcon1.Text = "Resting... "
            run_green_lights()
        Catch ex As Exception
            Error_Handler(ex.Message)
        End Try
    End Sub

    Public Sub WorkerProgressHandler(ByVal filesparsed As Long, ByVal entriesfound As Long, ByVal currentfile As String, ByVal totalfiles As Long, ByVal bytesread As Long, ByVal bytestotal As Long)
        Try
            ' Displays the returned value in the appropriate label.
            Label12.Text = (filesparsed).ToString & " (of " & totalfiles.ToString & ")"
            Label18.Text = (entriesfound).ToString
            Label13.Text = bytesread.ToString & " (of " & bytestotal.ToString & ")"
            Label17.Text = Math.Round(((bytesread / bytestotal) * 100), 2) & "%"
            label22.Text = currentfile
            label22.Select(0, 0)
        Catch ex As Exception
            Error_Handler(ex.Message)
        End Try
    End Sub

    Public Sub WorkerFileUpdateHandler(ByVal entriesfound As Long, ByVal currentfile As String)
        Try
            Dim run As Integer = 0
            Dim worked As Boolean = False
            If ListBox1.Items.Count > 0 Then
                Dim search As IEnumerator
                search = ListBox1.Items.GetEnumerator()

                While search.MoveNext
                    If search.Current.ToString().StartsWith(currentfile) Then
                        If Update_Listbox.Checked = True Then
                            ListBox1.Items.Item(run) = (currentfile & ": " & entriesfound & " entries")
                        End If
                        worked = True
                        Exit While
                    End If
                    run = run + 1
                End While
            End If
            If worked = False Then
                ListBox1.Items.Insert(0, currentfile & ": " & entriesfound & " entries")
            End If
            If Update_Listbox.Checked = True Then
                ListBox1.SelectedIndex = 0
            End If

        Catch ex As Exception
            Error_Handler(ex.Message)
        End Try
    End Sub

    Private Sub run_worker()
        run_orange_lights()
        Label11.Text = ""
        Label12.Text = ""
        Label18.Text = ""
        Label19.Text = ""
        ListBox1.Items.Clear()

        Label11.Text = Format(Now(), "dd/MM/yyyy hh:mm:ss tt")
        Label23.Text = "Current Log File:"
        Label6.Text = "Parsing Log File:"

        Worker1.savepath = savepathtxt.Text
        Worker1.logfolder = logfoldertxt.Text
        Worker1.tablelist = tablelist

        Worker1.ChooseThreads(1)
        currently_working = True
    End Sub






    Private Sub MenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem3.Click
        Try
            Save_Registry_Values()
            Worker1.Dispose()
            NotifyIcon1.Dispose()
            Application.Exit()
        Catch ex As Exception
            Error_Handler("An """ & ex.Message & """ error occurred while closing IIS W3SVC1 Log Parser. The program will attempt to recover shortly.")
        End Try
    End Sub

    Private Sub show_application()
        Try
            Me.Opacity = 1

            Me.BringToFront()
            Me.Refresh()
            Me.WindowState = FormWindowState.Normal

        Catch ex As Exception
            Error_Handler("An """ & ex.Message & """ error occurred while trying to display the main screen. The program will attempt to recover shortly.")
        End Try
    End Sub

    Private Sub NotifyIcon1_dblclick(ByVal sender As Object, ByVal e As System.EventArgs) Handles NotifyIcon1.DoubleClick
        show_application()
    End Sub
    Private Sub NotifyIcon1_snglclick(ByVal sender As Object, ByVal e As System.EventArgs) Handles NotifyIcon1.Click
        show_application()
    End Sub

    Private Sub MenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem1.Click
        show_application()
    End Sub

    Private Sub monitor_program_resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        Try

            If Me.WindowState = FormWindowState.Minimized Then
                NotifyIcon1.Visible = True
                Me.Opacity = 0
            End If
        Catch ex As Exception
            Error_Handler("An """ & ex.Message & """ error occurred while trying to display the main screen. The program will attempt to recover shortly.")
        End Try
    End Sub

    Private Sub force_check()
        Try
            Label7.Text = "Busy Working..."
            NotifyIcon1.Text = "Parsing Log Files..."
            If currently_working = False Then
                run_worker()
            End If
            If currently_working = False Then
                'Label7.Text = "Next Check: " & Format(Now().AddMinutes(Double.Parse(interval)), "dd/MM/yyyy hh:mm:ss tt").ToString
            End If
            'secretlabel.Text = "Next Check: " & Format(Now().AddMinutes(Double.Parse(interval)), "dd/MM/yyyy hh:mm:ss tt").ToString
        Catch ex As Exception
            Error_Handler("An """ & ex.Message & """ error occurred while checking the applications' status. The program will attempt to recover shortly.")
        End Try
    End Sub



    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        force_check()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim result As DialogResult = FolderBrowserDialog1.ShowDialog()
            If Not result = DialogResult.Cancel Then
                logfoldertxt.Text = FolderBrowserDialog1.SelectedPath
                logfolder = FolderBrowserDialog1.SelectedPath
            End If

        Catch ex As Exception
            Error_Handler(ex)
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            Dim result As DialogResult = SaveFileDialog1.ShowDialog()
            If Not result = DialogResult.Cancel Then
                savepathtxt.Text = SaveFileDialog1.FileName
                savepath = SaveFileDialog1.FileName
            End If

        Catch ex As Exception
            Error_Handler(ex)
        End Try
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            Worker1.WorkerThread.Abort()
        Catch ex As Exception
            Error_Handler(ex)
        Finally
            currently_working = False
            Label19.Text = Format(Now(), "dd/MM/yyyy hh:mm:ss tt")
            ' Label23.Text = "Ignored Log File:"
            Label6.Text = "Log Files Parsed:"

            Label7.Text = secretlabel.Text
            NotifyIcon1.Text = "Resting... "
            run_green_lights()
        End Try

    End Sub
End Class

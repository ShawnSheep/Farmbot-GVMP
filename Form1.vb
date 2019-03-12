Imports System.Runtime.InteropServices



Public Class Form1

    Private Declare Function RegisterHotKey Lib "user32" (ByVal hWnd As IntPtr, ByVal id As Integer, ByVal fsModifier As Integer, ByVal vk As Integer) As Integer
    Private Declare Sub UnregisterHotKey Lib "user32" (ByVal hWnd As IntPtr, ByVal id As Integer)
    Declare Function FindWindow Lib "user32" Alias "FindWindowA" _
                 (ByVal lpClassName As String, ByVal lpWindowName As String) As IntPtr
    Declare Function SendMessage Lib "user32" Alias "SendMessageA" _
                 (ByVal hWnd As IntPtr, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As IntPtr
    Const WM_KEYDOWN As Integer = &H100
    Const WM_UP As Integer = &H101
    Const VK_E As Integer = &H45
    Private Const Key_NONE As Integer = &H0
    Private Const WM_HOTKEY As Integer = &H312

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Button1.BackColor = Color.Green
        Button2.BackColor = Color.Red
        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Interval = CInt(TestNumber.Text)
        Dim destination As IntPtr = FindWindow(Nothing, "RAGE Multiplayer")
        SendMessage(destination, WM_KEYDOWN, VK_E, 0)
        SendMessage(destination, WM_UP, VK_E, 0)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Button1.BackColor = Color.White
        Button2.BackColor = Color.White
        Timer1.Stop()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click


        Dim TestNumber1 As Integer

        TestNumber1 = Integer.Parse(TestNumber.Text)
        TestNumber1 = TestNumber1 + 100
        TestNumber.Text = TestNumber1.ToString()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim TestNumber1 As Integer

        TestNumber1 = Integer.Parse(TestNumber.Text)
        TestNumber1 = TestNumber1 - 100
        TestNumber.Text = TestNumber1.ToString()
    End Sub
    Protected Overrides Sub WndProc(ByRef m As Message)
        If m.Msg = WM_HOTKEY Then

            Select Case m.WParam
                Case 1
                    Button1.PerformClick()
                Case 2
                    Button2.PerformClick()
            End Select
        End If
        MyBase.WndProc(m)
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TestNumber.Text = "1000"
        RegisterHotKey(Me.Handle, 1, Key_NONE, Keys.F10)
        RegisterHotKey(Me.Handle, 2, Key_NONE, Keys.F11)
    End Sub
    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        UnregisterHotKey(Me.Handle, 1)
        UnregisterHotKey(Me.Handle, 2)
    End Sub
End Class
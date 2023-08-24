Imports System.Data.SqlClient
Imports System.Xml

Public Class Dashboard
    Dim Con = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Desktop\Univesty_MS\Univesty_MSDb.mdf;Integrated Security=True;Connect Timeout=30")
    Private Sub CountStUd()
        Dim StNum As Integer
        Con.Open()
        Dim sql = "select COUNT(*) from StudentTbl"
        Dim cmd As New SqlCommand
        cmd = New SqlCommand(sql, Con)
        StNum = cmd.ExecuteScalar
        StdentsS.Text = StNum
        Con.Close()
    End Sub

    Private Sub CountLecturers()
        Dim TNum As Integer
        Con.Open()
        Dim sql = "select COUNT(*) from TeacherTbl"
        Dim cmd As New SqlCommand
        cmd = New SqlCommand(sql, Con)
        TNum = cmd.ExecuteScalar
        LecturersS.Text = TNum
        Con.Close()
    End Sub

    Private Sub CountDep()
        Dim DepNum As Integer
        Con.Open()
        Dim sql = "select COUNT(*) from DepartmentTbl"
        Dim cmd As New SqlCommand
        cmd = New SqlCommand(sql, Con)
        DepNum = cmd.ExecuteScalar
        DepartmentS.Text = DepNum
        Con.Close()
    End Sub

    Private Sub SumPayment()
        Dim FeesAmount As Integer
        Con.Open()
        Dim sql = "select Sum(Amount) from PaymentTbl"
        Dim cmd As New SqlCommand
        cmd = New SqlCommand(sql, Con)
        FeesAmount = cmd.ExecuteScalar
        Dim Am As String
        Am = Convert.ToString(FeesAmount)
        PaymentS.Text = "Rs." + Am
        Con.Close()
    End Sub

    Private Sub Dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CountStUd()
        CountLecturers()
        CountDep()
        SumPayment()
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Application.Exit()
    End Sub

    Private Sub PictureBox8_Click(sender As Object, e As EventArgs) Handles PictureBox8.Click
        Dim obj = New Login()
        obj.Show()
        Me.Hide()
    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click
        Dim obj = New Lecturers()
        obj.Show()
        Me.Hide()
    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.Click
        Dim obj = New Students()
        obj.Show()
        Me.Hide()
    End Sub

    Private Sub Label12_Click(sender As Object, e As EventArgs) Handles Label12.Click
        Dim obj = New Payment()
        obj.Show()
        Me.Hide()
    End Sub

    Private Sub Label13_Click(sender As Object, e As EventArgs) Handles Label13.Click
        Dim obj = New Department()
        obj.Show()
        Me.Hide()
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click

    End Sub

    Private Sub Panel4_Paint(sender As Object, e As PaintEventArgs) Handles Panel4.Paint, Panel9.Paint, Panel7.Paint, Panel3.Paint

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click, Label8.Click, Label17.Click, Label15.Click

    End Sub

    Private Sub Panel5_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Panel7_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Stdlbl_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Stdlbl_Click_1(sender As Object, e As EventArgs) Handles StdentsS.Click, LecturersS.Click, PaymentS.Click, DepartmentS.Click

    End Sub

    Private Sub Panel11_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Panel7_Paint_1(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub PictureBox12_Click(sender As Object, e As EventArgs) Handles PictureBox12.Click, PictureBox16.Click

    End Sub

    Private Sub PictureBox17_Click(sender As Object, e As EventArgs) Handles PictureBox17.Click

    End Sub

    Private Sub Panel10_Paint(sender As Object, e As PaintEventArgs) Handles Panel10.Paint

    End Sub

    Private Sub Label18_Click(sender As Object, e As EventArgs) Handles Label18.Click

    End Sub

    Private Sub Label19_Click(sender As Object, e As EventArgs) Handles Label19.Click

    End Sub

    Private Sub Label20_Click(sender As Object, e As EventArgs) Handles Label20.Click

    End Sub

    Private Sub Label21_Click(sender As Object, e As EventArgs) Handles Label21.Click

    End Sub

    Private Sub Panel5_Paint_1(sender As Object, e As PaintEventArgs) Handles Panel5.Paint

    End Sub

    Private Sub PictureBox9_Click(sender As Object, e As EventArgs) Handles PictureBox9.Click
        Dim obj = New Login()
        obj.Show()
        Me.Hide()
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        Dim obj = New Students()
        obj.Show()
        Me.Hide()
    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click
        Dim obj = New Lecturers()
        obj.Show()
        Me.Hide()
    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        Dim obj = New Payment()
        obj.Show()
        Me.Hide()
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        Dim obj = New Department()
        obj.Show()
        Me.Hide()
    End Sub
End Class
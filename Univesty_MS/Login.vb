Imports System.Data.SqlClient

Public Class Login
    Dim Con = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Desktop\Univesty_MS\Univesty_MSDb.mdf;Integrated Security=True;Connect Timeout=30")
    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Application.Exit()
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        UserNameTb.Text = ""
        PasswordTb.Text = ""
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If UserNameTb.Text = "" Or PasswordTb.Text = "" Then
            MsgBox(" Enter UserName and Password")
        ElseIf UserNameTb.Text = "Gayan" And PasswordTb.Text = "gayan@123" Then
            Dim obj = New Students
            obj.Show()
            Me.Hide()
        Else
            MsgBox("Wrong password or UserName")
            UserNameTb.Text = ""
            PasswordTb.Text = ""
        End If
    End Sub

    Private Sub PasswordTb_TextChanged(sender As Object, e As EventArgs) Handles PasswordTb.TextChanged

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub UserNameTb_TextChanged(sender As Object, e As EventArgs) Handles UserNameTb.TextChanged

    End Sub

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
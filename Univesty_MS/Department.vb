Imports System.Data.SqlClient
Public Class Department
    Dim Con = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Desktop\Univesty_MS\Univesty_MSDb.mdf;Integrated Security=True;Connect Timeout=30")
    Private Sub Display()
        Con.open()
        Dim query = "Select * from DepartmentTbl"
        Dim Adapter As SqlDataAdapter
        Dim cmd = New SqlCommand(query, Con)
        Adapter = New SqlDataAdapter(cmd)
        Dim builder = New SqlCommandBuilder(Adapter)
        Dim ds As C : \Users\User\Desktop\Univesty_MS
        ds = New DataSet
        Adapter.Fill(ds)
        DepartmentDGV.DataSource = ds.Tables(0)
        Con.Close()
    End Sub
    Private Sub Savebtn_Click(sender As Object, e As EventArgs) Handles Savebtn.Click
        If DeptNameTb.Text = "" Or DescTb.Text = "" Or DurationTb.Text = "" Then
            MsgBox("Missing Information")
        Else
            Try
                Con.open()
                Dim query = "insert into DepartmentTbl values('" & DeptNameTb.Text & "','" & DescTb.Text & "'," & DurationTb.Text & ")"
                Dim cmd As SqlCommand
                cmd = New SqlCommand(query, Con)
                cmd.ExecuteNonQuery()
                MsgBox("Department Details Saved")
                Con.close()
                Display()
                reset()
            Catch ex As Exception
                MsgBox(ex.Message)

            End Try
        End If
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Application.Exit()
    End Sub

    Private Sub Department_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Display()
    End Sub
    Private Sub reset()
        DeptNameTb.Text = ""
        DurationTb.Text = ""
        DescTb.Text = ""

    End Sub
    Private Sub Resetbtn_Click(sender As Object, e As EventArgs) Handles Resetbtn.Click
        reset()
    End Sub

    Private Sub Deletebtn_Click(sender As Object, e As EventArgs) Handles Deletebtn.Click
        If key = 0 Then
            MsgBox("Select The Department")
        Else
            Try
                Con.Open()
                Dim query = "delete from DepartmentTbl where DeptID = " & key & ""
                Dim cmd As SqlCommand
                cmd = New SqlCommand(query, Con)
                cmd.ExecuteNonQuery()
                MsgBox("Department Details Deleted")
                Con.close()
                Display()
                reset()
            Catch ex As Exception
                MsgBox(ex.Message)

            End Try
        End If
    End Sub

    Dim key = 0
    Private Sub DepartmentDGV_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DepartmentDGV.CellMouseClick
        Dim row As DataGridViewRow = DepartmentDGV.Rows(e.RowIndex)
        DeptNameTb.Text = row.cells(1).value.ToString
        DescTb.Text = row.cells(2).value.ToString
        DurationTb.Text = row.cells(3).value.ToString
        If DeptNameTb.Text = "" Then
            key = 0
        Else
            key = Convert.ToInt32(row.Cells(0).Value.ToString)
        End If
    End Sub

    Private Sub Editbtn_Click(sender As Object, e As EventArgs) Handles Editbtn.Click
        If DeptNameTb.Text = "" Or DescTb.Text = "" Or DurationTb.Text = "" Then
            MsgBox("Missing Information")
        Else
            Try
                Con.open()
                Dim query = "update DepartmentTbl set DeptName = '" & DeptNameTb.Text & "',DeptDesc = '" & DescTb.Text & "',DepDur=" & DurationTb.Text & " where DeptID =" & key & ""
                Dim cmd As SqlCommand
                cmd = New SqlCommand(query, Con)
                cmd.ExecuteNonQuery()
                MsgBox("Department Details Updated")
                Con.close()
                Display()
                reset()
            Catch ex As Exception
                MsgBox(ex.Message)

            End Try
        End If
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
        Dim obj = New Dashboard()
        obj.Show()
        Me.Hide()
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Label14_Click(sender As Object, e As EventArgs) Handles Label14.Click
        Dim obj = New Lecturers()
        obj.Show()
        Me.Hide()
    End Sub

    Private Sub Label9_Click_1(sender As Object, e As EventArgs) Handles Label9.Click
        Dim obj = New Students()
        obj.Show()
        Me.Hide()
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click
        Dim obj = New Payment()
        obj.Show()
        Me.Hide()
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        Dim obj = New Dashboard()
        obj.Show()
        Me.Hide()
    End Sub
End Class

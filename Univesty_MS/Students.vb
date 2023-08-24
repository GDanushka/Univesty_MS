Imports System.Data.SqlClient
Public Class Students
    Dim Con = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Desktop\Univesty_MS\Univesty_MSDb.mdf;Integrated Security=True;Connect Timeout=30")
    Private Sub fillDepartment()
        Con.open()
        Dim query = "select * from DepartmentTbl"
        Dim cmd As New SqlCommand(query, Con)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim Tbl As New DataTable()
        adapter.Fill(Tbl)
        DepCb.DataSource = Tbl
        DepCb.DisplayMember = "DeptName"
        DepCb.ValueMember = "DeptName"
        Con.Close()
    End Sub
    Private Sub Display()
        Con.open()
        Dim query = "Select * from StudentTbl"
        Dim Adapter As SqlDataAdapter
        Dim cmd = New SqlCommand(query, Con)
        Adapter = New SqlDataAdapter(cmd)
        Dim builder = New SqlCommandBuilder(Adapter)
        Dim ds As DataSet
        ds = New DataSet
        Adapter.Fill(ds)
        StudentDGV.DataSource = ds.Tables(0)
        Con.Close()
    End Sub

    Private Sub NoDueList()
        Con.open()
        Dim query = "Select * from StudentTbl where StFees >= 100000"
        Dim Adapter As SqlDataAdapter
        Dim cmd = New SqlCommand(query, Con)
        Adapter = New SqlDataAdapter(cmd)
        Dim builder = New SqlCommandBuilder(Adapter)
        Dim ds As DataSet
        ds = New DataSet
        Adapter.Fill(ds)
        StudentDGV.DataSource = ds.Tables(0)
        Con.Close()
    End Sub

    Private Sub clear()
        StNameTb.Text = ""
        FeesTb.Text = ""
        PhoneTb.Text = ""
        GenCb.SelectedIndex = 0
        DepCb.SelectedIndex = 0

    End Sub
    Private Sub Savebtn_Click(sender As Object, e As EventArgs) Handles Savebtn.Click
        If StNameTb.Text = "" Or PhoneTb.Text = "" Or FeesTb.Text = "" Or GenCb.SelectedIndex = -1 Or DepCb.SelectedIndex = -1 Then
            MsgBox("Missing Information")
        Else
            Try
                Con.open()
                Dim query = "insert into StudentTbl values('" & StNameTb.Text & "','" & GenCb.SelectedItem.ToString & "','" & StDOB.Value.Date & "','" & PhoneTb.Text & "','" & DepCb.SelectedValue.ToString & "'," & FeesTb.Text & ")"
                Dim cmd As SqlCommand
                cmd = New SqlCommand(query, Con)
                cmd.ExecuteNonQuery()
                MsgBox("Student Details Saved")
                Con.close()
                Display()
                clear()
            Catch ex As Exception
                MsgBox(ex.Message)

            End Try
        End If
    End Sub

    Private Sub Students_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fillDepartment()
        Display()
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Application.Exit()
    End Sub

    Private Sub Resetbtn_Click(sender As Object, e As EventArgs) Handles Resetbtn.Click
        clear()
    End Sub

    Dim key = 0
    Private Sub StudentDGV_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles StudentDGV.CellMouseClick
        Dim row As DataGridViewRow = StudentDGV.Rows(e.RowIndex)
        StNameTb.Text = row.Cells(1).Value.ToString
        GenCb.SelectedItem = row.Cells(2).Value.ToString
        StDOB.Text = row.Cells(3).Value.ToString
        PhoneTb.Text = row.Cells(4).Value.ToString
        DepCb.SelectedValue = row.Cells(5).Value.ToString
        FeesTb.Text = row.Cells(6).Value.ToString
        If StNameTb.Text = "" Then
            key = 0
        Else
            key = Convert.ToInt32(row.Cells(0).Value.ToString)
        End If
    End Sub

    Private Sub Deletebtn_Click(sender As Object, e As EventArgs) Handles Deletebtn.Click
        If key = 0 Then
            MsgBox("Select The Student")
        Else
            Try
                Con.Open()
                Dim query = "delete from StudentTbl where StID = " & key & ""
                Dim cmd As SqlCommand
                cmd = New SqlCommand(query, Con)
                cmd.ExecuteNonQuery()
                MsgBox("Student Details Deleted")
                Con.close()
                Display()
                clear()
            Catch ex As Exception
                MsgBox(ex.Message)

            End Try
        End If
    End Sub

    Private Sub Editbtn_Click(sender As Object, e As EventArgs) Handles Editbtn.Click
        If StNameTb.Text = "" Or PhoneTb.Text = "" Or FeesTb.Text = "" Or GenCb.SelectedIndex = -1 Or DepCb.SelectedIndex = -1 Then
            MsgBox("Missing Information")
        Else
            Try
                Con.open()
                Dim query = "update StudentTbl set StName = '" & StNameTb.Text & "',StGender = '" & GenCb.SelectedItem.ToString() & "',StDOB=" & StDOB.Text & "',StPhone = '" & PhoneTb.Text & "',StDep='" & DepCb.SelectedValue.ToString() & "',StFees = " & FeesTb.Text & " where StID =" & key & ""
                Dim cmd As SqlCommand
                cmd = New SqlCommand(query, Con)
                cmd.ExecuteNonQuery()
                MsgBox("Student Details Updated")
                Con.close()
                Display()
                clear()
            Catch ex As Exception
                MsgBox(ex.Message)

            End Try
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        NoDueList()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Display()
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
        Dim obj = New Department()
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

    Private Sub Label9_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub StudentDGV_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles StudentDGV.CellContentClick

    End Sub

    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub
End Class
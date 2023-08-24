Imports System.Data.SqlClient
Public Class Lecturers
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
        Dim query = "Select * from TeacherTbl"
        Dim Adapter As SqlDataAdapter
        Dim cmd = New SqlCommand(query, Con)
        Adapter = New SqlDataAdapter(cmd)
        Dim builder = New SqlCommandBuilder(Adapter)
        Dim ds As DataSet
        ds = New DataSet
        Adapter.Fill(ds)
        TeacherDGV.DataSource = ds.Tables(0)
        Con.Close()
    End Sub
    Private Sub Clear()
        TNameTb.Text = ""
        GenCb.SelectedIndex = 0
        PhoneTb.Text = ""
        DepCb.SelectedIndex = 0
        TAddTb.Text = ""

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Savebtn.Click
        If TNameTb.Text = "" Or GenCb.SelectedIndex = -1 Or PhoneTb.Text = "" Or DepCb.SelectedIndex = -1 Or TAddTb.Text = "" Then
            MsgBox("Missing Information")
        Else
            Try
                Con.open()
                Dim query = "insert into TeacherTbl values('" & TNameTb.Text & "','" & GenCb.SelectedItem.ToString & "','" & TDOB.Value.Date & "','" & PhoneTb.Text & "','" & DepCb.SelectedValue.ToString & "','" & TAddTb.Text & "')"
                Dim cmd As SqlCommand
                cmd = New SqlCommand(query, Con)
                cmd.ExecuteNonQuery()
                MsgBox("Lecturer Details Saved")
                Con.close()
                Display()
                Clear()
            Catch ex As Exception
                MsgBox(ex.Message)

            End Try
        End If
    End Sub

    Private Sub Teachers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fillDepartment()
        Display()
    End Sub

    Private Sub Resetbtn_Click(sender As Object, e As EventArgs) Handles Resetbtn.Click
        Clear()
    End Sub

    Private Sub Deletebtn_Click(sender As Object, e As EventArgs) Handles Deletebtn.Click
        If key = 0 Then
            MsgBox("Select The Lecturer")
        Else
            Try
                Con.Open()
                Dim query = "delete from TeacherTbl where TID = " & key & ""
                Dim cmd As SqlCommand
                cmd = New SqlCommand(query, Con)
                cmd.ExecuteNonQuery()
                MsgBox("Lecturer Details Deleted")
                Con.close()
                Display()
                Clear()
            Catch ex As Exception
                MsgBox(ex.Message)

            End Try
        End If
    End Sub

    Dim key = 0
    Private Sub TeacherDGV_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles TeacherDGV.CellMouseClick
        Dim row As DataGridViewRow = TeacherDGV.Rows(e.RowIndex)
        TNameTb.Text = row.Cells(1).Value.ToString
        GenCb.SelectedItem = row.Cells(2).Value.ToString
        TDOB.Text = row.Cells(3).Value.ToString
        PhoneTb.Text = row.Cells(4).Value.ToString
        DepCb.SelectedValue = row.Cells(5).Value.ToString
        TAddTb.Text = row.Cells(6).Value.ToString
        If TNameTb.Text = "" Then
            key = 0
        Else
            key = Convert.ToInt32(row.Cells(0).Value.ToString)
        End If
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Application.Exit()
    End Sub

    Private Sub Editbtn_Click(sender As Object, e As EventArgs) Handles Editbtn.Click
        If TNameTb.Text = "" Or GenCb.SelectedIndex = -1 Or PhoneTb.Text = "" Or DepCb.SelectedIndex = -1 Or TAddTb.Text = "" Then
            MsgBox("Missing Information")
        Else
            Try
                Con.open()
                Dim query = "update TeacherTbl set TName = '" & TNameTb.Text & "',TGender = '" & GenCb.SelectedItem.ToString() & "',TDOB= '" & TDOB.Text & "',TPhone = '" & PhoneTb.Text & "',TDept='" & DepCb.SelectedValue.ToString() & "',TAdd = '" & TAddTb.Text & "' where TId =" & key & ""
                Dim cmd As SqlCommand
                cmd = New SqlCommand(query, Con)
                cmd.ExecuteNonQuery()
                MsgBox("Lecturer Details Updated")
                Con.close()
                Display()
                Clear()
            Catch ex As Exception
                MsgBox(ex.Message)

            End Try
        End If
    End Sub

    Private Sub Label13_Click(sender As Object, e As EventArgs) Handles Label13.Click
        Dim obj = New Dashboard()
        obj.Show()
        Me.Hide()
    End Sub

    Private Sub Label12_Click(sender As Object, e As EventArgs) Handles Label12.Click
        Dim obj = New Payment()
        obj.Show()
        Me.Hide()
    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.Click
        Dim obj = New Department()
        obj.Show()
        Me.Hide()
    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click
        Dim obj = New Students()
        obj.Show()
        Me.Hide()
    End Sub

    Private Sub PictureBox8_Click(sender As Object, e As EventArgs) Handles PictureBox8.Click
        Dim obj = New Login()
        obj.Show()
        Me.Hide()
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub
End Class
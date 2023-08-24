Imports System.Data.SqlClient

Public Class Payment

    Dim Con = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Desktop\Univesty_MS\Univesty_MSDb.mdf;Integrated Security=True;Connect Timeout=30")

    Private Sub fillStudent()
        Con.open()
        Dim query = "select * from StudentTbl"
        Dim cmd As New SqlCommand(query, Con)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim Tbl As New DataTable()
        adapter.Fill(Tbl)
        AccStIDCb.DataSource = Tbl
        AccStIDCb.DisplayMember = "StID"
        AccStIDCb.ValueMember = "StID"
        Con.Close()
    End Sub
    Private Sub Display()
        Con.open()
        Dim query = "Select * from PaymentTbl"
        Dim Adapter As SqlDataAdapter
        Dim cmd = New SqlCommand(query, Con)
        Adapter = New SqlDataAdapter(cmd)
        Dim builder = New SqlCommandBuilder(Adapter)
        Dim ds As DataSet
        ds = New DataSet
        Adapter.Fill(ds)
        FeesDGV.DataSource = ds.Tables(0)
        Con.Close()
    End Sub

    Private Sub clear()
        TAmountTb.Text = ""
        AccNameTb.Text = ""
        AccStIDCb.SelectedIndex = -1
    End Sub

    Private Sub GetStName()
        Con.open()
        Dim query = "select * from StudentTbl where StID = " & AccStIDCb.SelectedValue.ToString() & ""
        Dim cmd As New SqlCommand(query, Con)
        Dim dt As New DataTable
        Dim reader As SqlDataReader
        reader = cmd.ExecuteReader
        While reader.Read
            AccNameTb.Text = reader(1).ToString()
        End While
        Con.Close()
    End Sub


    Private Sub Fees_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Display()
        fillStudent()
    End Sub
    Private Sub updateStudent()
        Try
            Con.open()
            Dim query = "update StudentTbl set StFees = " & TAmountTb.Text & " where StID =" & AccStIDCb.SelectedValue.ToString() & ""
            Dim cmd As SqlCommand
            cmd = New SqlCommand(query, Con)
            cmd.ExecuteNonQuery()
            MsgBox("Student Updated")
            Con.close()
            'Display()
            'clear()
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub
    Private Sub Paybtn_Click(sender As Object, e As EventArgs) Handles Paybtn.Click
        If AccNameTb.Text = "" Or TAmountTb.Text = " " Then
            MsgBox("Missing Information")
        ElseIf Convert.ToInt32(TAmountTb.Text) > 100000 Or Convert.ToInt32(TAmountTb.Text) < 1 Then
            MsgBox("Wrong Amount")
        Else
            Try
                Con.open()
                Dim query = "insert into PaymentTbl values(" & AccStIDCb.SelectedValue.ToString() & ",'" & AccNameTb.Text & "'," & TAmountTb.Text & ")"
                Dim cmd As SqlCommand
                cmd = New SqlCommand(query, Con)
                cmd.ExecuteNonQuery()
                MsgBox("Payment Succesfull")
                Con.close()
                Display()
                updateStudent()
                clear()
            Catch ex As Exception
                MsgBox(ex.Message)

            End Try
        End If
    End Sub

    Private Sub AccStIDCb_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles AccStIDCb.SelectionChangeCommitted
        GetStName()
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Application.Exit()
    End Sub
    Dim key = 0
    Private Sub FeesDGV_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles FeesDGV.CellMouseClick
        Dim row As DataGridViewRow = FeesDGV.Rows(e.RowIndex)
        AccStIDCb.SelectedValue = row.Cells(1).Value.ToString
        AccNameTb.Text = row.Cells(2).Value.ToString
        TAmountTb.Text = row.Cells(3).Value.ToString
        If AccNameTb.Text = "" Then
            key = 0
        Else
            key = Convert.ToInt32(row.Cells(0).Value.ToString)
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
        Dim obj = New Department()
        obj.Show()
        Me.Hide()
    End Sub

    Private Sub Label12_Click(sender As Object, e As EventArgs) Handles Label12.Click
        Dim obj = New Students()
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

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub
End Class
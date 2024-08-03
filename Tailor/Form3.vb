Imports MySql.Data.MySqlClient
Public Class Form3
    Dim connectionString As String = "server=localhost;database=db_tailoring;username=root;password="
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub back_Click(sender As Object, e As EventArgs) Handles back.Click
        txtFname.Clear()
        txtLname.Clear()
        txtContactnum.Clear()
        txtEmail.Clear()
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub enter_Click(sender As Object, e As EventArgs) Handles enter.Click
        Select Case MsgBox("Are you sure you want to checkout with this information?", MsgBoxStyle.YesNoCancel, "Warning!")
            Case MsgBoxResult.Yes
                Try
                    Using conn As New MySqlConnection(connectionString)
                        conn.Open()
                        Dim query As String = "INSERT INTO customer_table (fname, lname, contactnum, email) VALUES (@fname, @lname,@contactnum, @email)"
                        Using cmd As New MySqlCommand(query, conn)
                            cmd.Parameters.AddWithValue("@fname", txtFname.Text)
                            cmd.Parameters.AddWithValue("@lname", txtLname.Text)
                            cmd.Parameters.AddWithValue("@email", txtEmail.Text)
                            Dim contactnum As Integer
                            If Integer.TryParse(txtContactnum.Text, contactnum) Then
                                cmd.Parameters.AddWithValue("@contactnum", contactnum)
                            Else
                                MessageBox.Show("Invalid contact number")
                                Return
                            End If
                            cmd.ExecuteNonQuery()
                        End Using
                    End Using
                    Form2.Show()
                    Me.Hide()
                Catch ex As Exception

                End Try
            Case MsgBoxResult.Cancel

            Case MsgBoxResult.No
                txtFname.Clear()
                txtLname.Clear()
                txtContactnum.Clear()
                txtEmail.Clear()
        End Select
    End Sub
End Class
Imports MySql.Data.MySqlClient

Public Class Form2

    Dim connectionString As String = "server=localhost;database=db_tailoring;username=root;password="

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadInventory()
    End Sub

    Private Sub LoadInventory()
        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Dim query As String = "SELECT * FROM inventory_table"
                Using cmd As New MySqlCommand(query, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        Dim dat As New DataTable()
                        dat.Load(reader)
                        DataGridView1.DataSource = dat
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading inventory: " & ex.Message)
        End Try
    End Sub

    Private Sub btnSubtract_Click(sender As Object, e As EventArgs) Handles btnSubtract.Click
        Try
            Dim selectedRow As DataGridViewRow = DataGridView1.CurrentRow
            Dim selectedId As Integer = Convert.ToInt32(selectedRow.Cells("id").Value)
            Dim currentQuantity As Integer = Convert.ToInt32(selectedRow.Cells("quantity").Value)


            Dim quantityToSubtract As Integer
            If Integer.TryParse(InputBox("Enter quantity to subtract:"), quantityToSubtract) Then
                If quantityToSubtract > currentQuantity Then
                    MessageBox.Show("Cannot subtract more than current quantity.")
                    Return
                End If


                Using conn As New MySqlConnection(connectionString)
                    conn.Open()
                    Dim query As String = "UPDATE inventory_table SET quantity = quantity - @quantity WHERE id = @id"
                    Using cmd As New MySqlCommand(query, conn)
                        cmd.Parameters.AddWithValue("@quantity", quantityToSubtract)
                        cmd.Parameters.AddWithValue("@id", selectedId)
                        cmd.ExecuteNonQuery()
                    End Using
                End Using

                LoadInventory()
                MessageBox.Show(quantityToSubtract & " units subtracted from inventory.")
            Else
                MessageBox.Show("Invalid quantity.")
            End If
        Catch ex As Exception
            MessageBox.Show("Error subtracting quantity: " & ex.Message)
        End Try
    End Sub
End Class
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
        Dim con As MySqlConnection = New MySqlConnection(connectionString)
        Dim query1 As String = "SELECT customer_id FROM customer_table"
        Using myCommand As New MySqlCommand("SELECT * FROM customer_table ORDER BY customer_id DESC limit 1", con)
            Try
                con.Open()
                Using myData = myCommand.ExecuteReader()
                    If myData.HasRows Then
                        myData.Read()
                        cusnum.Text = myData.Item("customer_id")
                    End If
                End Using
            Catch ex As Exception
            End Try
        End Using
    End Sub

    Private Sub btnSubtract_Click(sender As Object, e As EventArgs) Handles btnSubtract.Click
        Try
            Dim selectedRow As DataGridViewRow = DataGridView1.CurrentRow
            Dim selectedId As Integer = Convert.ToInt32(selectedRow.Cells("inventory_id").Value)
            Dim currentQuantity As Integer = Convert.ToInt32(selectedRow.Cells("quantity").Value)
            Dim quantityToSubtract As Integer
            If Integer.TryParse(InputBox("Enter quantity to checkout:"), quantityToSubtract) Then
                If quantityToSubtract > currentQuantity Then
                    MessageBox.Show("Cannot checkout more than current quantity.")
                    Return
                End If
                Using conn As New MySqlConnection(connectionString)
                    conn.Open()
                    Dim query As String = "UPDATE inventory_table SET quantity = quantity - @quantity WHERE inventory_id = @inventory_id"
                    Using cmd As New MySqlCommand(query, conn)
                        cmd.Parameters.AddWithValue("@quantity", quantityToSubtract)
                        cmd.Parameters.AddWithValue("@inventory_id", selectedId)
                        cmd.ExecuteNonQuery()
                    End Using
                End Using
                LoadInventory()
                MessageBox.Show(quantityToSubtract & " units subtracted from inventory.")
                Using conn1 As New MySqlConnection(connectionString)
                    conn1.Open()
                    Dim query2 As String = "INSERT INTO ordertable (customer_id, inventory_id, order_date) VALUES (@customer_id, @inventory_id, @order_date)"
                    Using cmd As New MySqlCommand(query2, conn1)
                        cmd.Parameters.AddWithValue("@customer_id", cusnum.Text)
                        cmd.Parameters.AddWithValue("@order_date", date1.Text)
                        cmd.Parameters.AddWithValue("@inventory_id", selectedId)
                        cmd.ExecuteNonQuery()
                    End Using
                End Using
            Else
                MessageBox.Show("Invalid quantity.")
            End If
        Catch ex As Exception
            MessageBox.Show("Error subtracting quantity: " & ex.Message)
        End Try
    End Sub

    Private Sub back1_Click(sender As Object, e As EventArgs) Handles back1.Click
        Form3.Show()
        Me.Hide()
    End Sub

End Class
Imports MySql.Data.MySqlClient

Public Class Form1

    Dim connectionString As String = "server=localhost;database=db_tailoring;username=root;password="

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadInventory()
        Dim dat As New DataTable()
        Dim adap As New MySqlDataAdapter("SELECT * FROM db_tailoring.inventory_table", connectionString)
        adap.Fill(dat)
        DataGridView1.DataSource = dat
    End Sub

    Private Sub LoadInventory()
        Try
            Dim dat As New DataTable()
            Dim adap As New MySqlDataAdapter("SELECT * FROM inventory_table", connectionString)
            adap.Fill(dat)
            DataGridView1.DataSource = dat
        Catch ex As Exception
            MessageBox.Show("Error loading inventory: " & ex.Message)
        End Try
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Dim query As String = "INSERT INTO inventory_table (name, quantity, price) VALUES (@name, @quantity, @price)"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@name", txtName.Text)
                    Dim quantity As Integer
                    If Integer.TryParse(txtQuantity.Text, quantity) Then
                        cmd.Parameters.AddWithValue("@quantity", quantity)
                    Else
                        MessageBox.Show("Invalid quantity")
                        Return
                    End If
                    Dim price As Decimal
                    If Decimal.TryParse(txtPrice.Text, price) Then
                        cmd.Parameters.AddWithValue("@price", price)
                    Else
                        MessageBox.Show("Invalid price")
                        Return
                    End If
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            LoadInventory()
        Catch ex As Exception
            MessageBox.Show("Error adding item: " & ex.Message)
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            Dim selectedId As Integer = Convert.ToInt32(DataGridView1.CurrentRow.Cells("id").Value)
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Dim query As String = "DELETE FROM inventory_table WHERE id = @id"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@id", selectedId)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            LoadInventory()
        Catch ex As Exception
            MessageBox.Show("Error deleting item: " & ex.Message)
        End Try
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Try
            If DataGridView1.SelectedRows.Count > 0 Then
                Dim selectedId As Integer = Convert.ToInt32(DataGridView1.CurrentRow.Cells("id").Value)

                Using conn As New MySqlConnection(connectionString)
                    conn.Open()
                    Dim query As String = "UPDATE inventory_table SET name = @name, quantity = @quantity, price = @price WHERE id = @id"
                    Using cmd As New MySqlCommand(query, conn)
                        cmd.Parameters.AddWithValue("@name", txtName.Text)
                        Dim quantity As Integer
                        If Integer.TryParse(txtQuantity.Text, quantity) Then
                            cmd.Parameters.AddWithValue("@quantity", quantity)
                        Else
                            MessageBox.Show("Invalid quantity")
                            Return
                        End If
                        Dim price As Decimal
                        If Decimal.TryParse(txtPrice.Text, price) Then
                            cmd.Parameters.AddWithValue("@price", price)
                        Else
                            MessageBox.Show("Invalid price")
                            Return
                        End If
                        cmd.Parameters.AddWithValue("@id", selectedId)
                        cmd.ExecuteNonQuery()
                    End Using
                End Using
                LoadInventory()
            Else
                MessageBox.Show("Please select a row to update.")
            End If
        Catch ex As Exception
            MessageBox.Show("Error updating item: " & ex.Message)
        End Try
    End Sub

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        If DataGridView1.SelectedRows.Count > 0 Then
            Dim row As DataGridViewRow = DataGridView1.SelectedRows(0)
            txtName.Text = row.Cells("name").Value.ToString()
            txtQuantity.Text = row.Cells("quantity").Value.ToString()
            txtPrice.Text = row.Cells("price").Value.ToString()
        End If
    End Sub

    Private Sub Usermode_Click(sender As Object, e As EventArgs) Handles Usermode.Click
        Form3.Show()
        Me.Hide()
    End Sub

    Private Sub adminbtn_Click(sender As Object, e As EventArgs) Handles adminbtn.Click
        Form4.Show()
        Me.Hide()
    End Sub
End Class
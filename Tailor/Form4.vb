Imports MySql.Data.MySqlClient
Public Class Form4

    Dim connectionString As String = "server=localhost;database=db_tailoring;username=root;password="

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadInventory()
        Dim dat As New DataTable()
        Dim adap As New MySqlDataAdapter("SELECT * FROM db_tailoring.inventory_table", connectionString)
        adap.Fill(dat)
        DataGridView1.DataSource = dat
        Dim dat1 As New DataTable()
        Dim adap1 As New MySqlDataAdapter("SELECT * FROM db_tailoring.customer_table", connectionString)
        adap1.Fill(dat1)
        DataGridView2.DataSource = dat1
        Dim dat2 As New DataTable()
        Dim adap2 As New MySqlDataAdapter("SELECT * FROM db_tailoring.ordertable", connectionString)
        adap2.Fill(dat2)
        DataGridView3.DataSource = dat2
    End Sub

    Private Sub LoadInventory()
        Try
            Dim dat As New DataTable()
            Dim adap As New MySqlDataAdapter("SELECT * FROM inventory_table", connectionString)
            adap.Fill(dat)
            DataGridView1.DataSource = dat
            Dim dat1 As New DataTable()
            Dim adap1 As New MySqlDataAdapter("SELECT * FROM db_tailoring.customer_table", connectionString)
            adap1.Fill(dat1)
            DataGridView2.DataSource = dat1
            Dim dat2 As New DataTable()
            Dim adap2 As New MySqlDataAdapter("SELECT * FROM db_tailoring.ordertable", connectionString)
            adap2.Fill(dat2)
            DataGridView3.DataSource = dat2
        Catch ex As Exception
            MessageBox.Show("Error loading inventory: " & ex.Message)
        End Try
    End Sub

    Private Sub btnAdd1_Click(sender As Object, e As EventArgs) Handles btnAdd1.Click
        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Dim query As String = "INSERT INTO inventory_table (name, quantity, price) VALUES (@name, @quantity, @price)"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@name", txtName1.Text)
                    Dim quantity As Integer
                    If Integer.TryParse(txtQuantity1.Text, quantity) Then
                        cmd.Parameters.AddWithValue("@quantity", quantity)
                    Else
                        MessageBox.Show("Invalid quantity")
                        Return
                    End If
                    Dim price As Decimal
                    If Decimal.TryParse(txtPrice1.Text, price) Then
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

    Private Sub btnDelete1_Click(sender As Object, e As EventArgs) Handles btnDelete1.Click
        Try
            Dim selectedId As Integer = Convert.ToInt32(DataGridView1.CurrentRow.Cells("inventory_id").Value)

            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Dim query As String = "DELETE FROM inventory_table WHERE inventory_id = @inventory_id"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@inventory_id", selectedId)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            LoadInventory()
        Catch ex As Exception
            MessageBox.Show("Error deleting item: " & ex.Message)
        End Try
    End Sub

    Private Sub btnUpdate1_Click(sender As Object, e As EventArgs) Handles btnUpdate1.Click
        Try
            If DataGridView1.SelectedRows.Count > 0 Then
                Dim selectedId As Integer = Convert.ToInt32(DataGridView1.CurrentRow.Cells("inventory_id").Value)
                Using conn As New MySqlConnection(connectionString)
                    conn.Open()
                    Dim query As String = "UPDATE inventory_table SET name = @name, quantity = @quantity, price = @price WHERE inventory_id = @inventory_id"
                    Using cmd As New MySqlCommand(query, conn)
                        cmd.Parameters.AddWithValue("@name", txtName1.Text)
                        Dim quantity As Integer
                        If Integer.TryParse(txtQuantity1.Text, quantity) Then
                            cmd.Parameters.AddWithValue("@quantity", quantity)
                        Else
                            MessageBox.Show("Invalid quantity")
                            Return
                        End If
                        Dim price As Decimal
                        If Decimal.TryParse(txtPrice1.Text, price) Then
                            cmd.Parameters.AddWithValue("@price", price)
                        Else
                            MessageBox.Show("Invalid price")
                            Return
                        End If
                        cmd.Parameters.AddWithValue("@inventory_id", selectedId)
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
            txtName1.Text = row.Cells("name").Value.ToString()
            txtQuantity1.Text = row.Cells("quantity").Value.ToString()
            txtPrice1.Text = row.Cells("price").Value.ToString()
        End If
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        SearchInventory()
    End Sub

    Private Sub SearchInventory()
        Dim searchTerm As String = txtSearch.Text.Trim()

        If String.IsNullOrEmpty(searchTerm) Then
            MessageBox.Show("Please enter a search term.")
            Return
        End If

        Try
            Dim query As String = "SELECT * FROM inventory_table WHERE name LIKE @searchTerm"
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@searchTerm", "%" & searchTerm & "%")
                    Dim adap As New MySqlDataAdapter(cmd)
                    Dim dat As New DataTable()
                    adap.Fill(dat)
                    DataGridView1.DataSource = dat
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error searching inventory: " & ex.Message)
        End Try
    End Sub

    Private Sub btnAdd2_Click(sender As Object, e As EventArgs) Handles btnAdd2.Click
        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Dim query As String = "INSERT INTO customer_table (fname, lname, contactnum, email) VALUES (@fname, @lname,@contactnum, @email)"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@fname", txtFname1.Text)
                    cmd.Parameters.AddWithValue("@lname", txtLname1.Text)
                    cmd.Parameters.AddWithValue("@email", txtEmail1.Text)
                    Dim contactnum As Integer
                    If Integer.TryParse(txtContactnum1.Text, contactnum) Then
                        cmd.Parameters.AddWithValue("@contactnum", contactnum)
                    Else
                        MessageBox.Show("Invalid contact number")
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

    Private Sub btnDelete2_Click(sender As Object, e As EventArgs) Handles btnDelete2.Click
        Try
            Dim selectedId As Integer = Convert.ToInt32(DataGridView1.CurrentRow.Cells("customer_id").Value)

            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Dim query As String = "DELETE FROM customer_table WHERE customer_id = @customer_id"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@customer_id", selectedId)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            LoadInventory()
        Catch ex As Exception
            MessageBox.Show("Error deleting item: " & ex.Message)
        End Try
    End Sub

    Private Sub btnUpdate2_Click(sender As Object, e As EventArgs) Handles btnUpdate2.Click
        Try
            If DataGridView2.SelectedRows.Count > 0 Then
                Dim selectedcusID As Integer = Convert.ToInt32(DataGridView2.CurrentRow.Cells("customer_id").Value)
                Using conn As New MySqlConnection(connectionString)
                    conn.Open()
                    Dim query As String = "UPDATE customer_table SET fname = @fname, lname = @lname, contactnum = @contactnum, email = @email WHERE customer_id = @customer_id"
                    Using cmd As New MySqlCommand(query, conn)
                        cmd.Parameters.AddWithValue("@fname", txtFname1.Text)
                        cmd.Parameters.AddWithValue("@lname", txtLname1.Text)
                        cmd.Parameters.AddWithValue("@email", txtEmail1.Text)
                        Dim contactnum As Integer
                        If Integer.TryParse(txtContactnum1.Text, contactnum) Then
                            cmd.Parameters.AddWithValue("@contactnum", contactnum)
                        Else
                            MessageBox.Show("Invalid contact number")
                            Return
                        End If
                        cmd.Parameters.AddWithValue("@customer_id", selectedcusID)
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

    Private Sub DataGridView2_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView2.SelectionChanged
        If DataGridView2.SelectedRows.Count > 0 Then
            Dim row As DataGridViewRow = DataGridView2.SelectedRows(0)
            txtFname1.Text = row.Cells("fname").Value.ToString()
            txtLname1.Text = row.Cells("lname").Value.ToString()
            txtContactnum1.Text = row.Cells("contactnum").Value.ToString()
            txtEmail1.Text = row.Cells("email").Value.ToString()
        End If
    End Sub

    Private Sub btnSearch1_Click(sender As Object, e As EventArgs) Handles btnSearch1.Click
        SearchInventory1()
    End Sub

    Private Sub SearchInventory1()
        Dim searchTerm1 As String = txtSearch1.Text.Trim()

        If String.IsNullOrEmpty(searchTerm1) Then
            MessageBox.Show("Please enter a search term.")
            Return
        End If

        Try
            Dim query As String = "SELECT * FROM customer_table WHERE fname LIKE @searchTerm"
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@searchTerm", "%" & searchTerm1 & "%")
                    Dim adap1 As New MySqlDataAdapter(cmd)
                    Dim dat1 As New DataTable()
                    adap1.Fill(dat1)
                    DataGridView2.DataSource = dat1
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error searching customer table: " & ex.Message)
        End Try
    End Sub

    Private Sub btnSearch2_Click(sender As Object, e As EventArgs) Handles btnSearch2.Click
        SearchInventory2()
    End Sub

    Private Sub SearchInventory2()
        Dim searchTerm2 As String = txtSearch2.Text.Trim()

        If String.IsNullOrEmpty(searchTerm2) Then
            MessageBox.Show("Please enter a search term.")
            Return
        End If

        Try
            Dim query As String = "SELECT * FROM ordertable WHERE fname LIKE @searchTerm"
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@searchTerm", "%" & searchTerm2 & "%")
                    Dim adap2 As New MySqlDataAdapter(cmd)
                    Dim dat2 As New DataTable()
                    adap2.Fill(dat2)
                    DataGridView3.DataSource = dat2
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error searching customer table: " & ex.Message)
        End Try
    End Sub

    Private Sub Workermode_Click(sender As Object, e As EventArgs) Handles Workermode.Click
        txtName1.Clear()
        txtQuantity1.Clear()
        txtPrice1.Clear()
        txtSearch.Clear()
        txtFname1.Clear()
        txtLname1.Clear()
        txtContactnum1.Clear()
        txtEmail1.Clear()
        txtSearch1.Clear()
        Form1.Show()
        Me.Hide()
    End Sub
End Class
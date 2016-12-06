Imports MySql.Data.MySqlClient
Public Class bookslist

    'Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    ' refreshhh()

    'End Sub

    ' Dim connStr As String = "Server=127.0.0.1;Port=3306;Database=library_system;Uid=root;Pwd=;"
    'Dim selDelete As String = "none"
    'Dim celDetail As String = "none"
    'Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
    '    Form2.Show()
    '    Me.Close()
    'End Sub

    Private Sub bookslist_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        refreshhh()

    End Sub
    Public Sub refreshhh()
        ListView1.Items.Clear()
        Dim lstview As New ListViewItem()

        Dim connStr As String = "Server=127.0.0.1;Port=3306;Database=library_system;Uid=root;Pwd=;"



        Try

            Dim query1 As String = "SELECT * from books_list ORDER BY Title ASC"

            Dim connection As New MySqlConnection(connStr)

            Dim cmd As New MySqlCommand(query1, connection)

            connection.Open()

            Dim reader As MySqlDataReader

            reader = cmd.ExecuteReader()

            While reader.Read()

                ComboBox1.Items.Add(reader.GetString(1))
                lstview = ListView1.Items.Add(reader.GetString(0))
                lstview.SubItems.Add(reader.GetString(1))
                lstview.SubItems.Add(reader.GetString(2))
                lstview.SubItems.Add(reader.GetString(3))
                lstview.SubItems.Add(reader.GetString(4))

            End While

            reader.Close()
            connection.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub


    Public Sub borrow()

        Dim connStr As String = "Server=127.0.0.1;Port=3306;Database=library_system;Uid=root;Pwd=;"
        Dim valueQuan As Integer


        Try

            Dim query1 As String = "SELECT quantity FROM books_list WHERE title = '" & ComboBox1.Text & "'"

            Dim connection As New MySqlConnection(connStr)

            Dim cmd As New MySqlCommand(query1, connection)

            connection.Open()

            Dim reader As MySqlDataReader

            reader = cmd.ExecuteReader()

            While reader.Read()

                If reader.GetString(0) = 0 Then
                    valueQuan = 0
                    MsgBox("Quantity is Zero for " + ComboBox1.Text)
                Else
                    valueQuan = reader.GetString(0) - 1
                    MsgBox("Successfully Borrowed " + ComboBox1.Text)


                   
                End If

                form10.Show()
                Me.Close()

            End While

            Dim query2 As String = "UPDATE books_list SET Quantity = '" & valueQuan & "' "
            query2 += " WHERE title = '" & ComboBox1.Text & "'"

            Dim connection2 As New MySqlConnection(connStr)

            Dim cmd2 As New MySqlCommand(query2, connection2)

            connection2.Open()

            cmd2.ExecuteNonQuery()


            reader.Close()
            connection.Close()


            connection2.Close()





        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        refreshhh()
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If ComboBox1.Text = "" Then
            MsgBox("Please select a book")
        Else
            borrow()

        End If
    End Sub


    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Form2.Show()
        Me.Close()
    End Sub

    Private Sub AboutUsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutUsToolStripMenuItem.Click
        Form6.Close()
        Me.Close()
    End Sub

   
    
End Class
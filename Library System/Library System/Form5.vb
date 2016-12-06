Imports MySql.Data.MySqlClient
Public Class Form5
    Dim connStr As String = "Server=127.0.0.1;Port=3306;Database=library_system;Uid=root;Pwd=;"
    ' Dim lstview As New ListViewItem()
    Dim day1 As Integer
    Dim day2 As Integer


    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Form2.Show()
        Me.Close()
    End Sub

    ' Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
    Private Sub Form5_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim lvwitem As New ListViewItem()


        Try

            Dim query1 As String = "SELECT books_list.ISBN,books_list.Title,books_list.Category,books_list.Quantity,books_list.Pages,author.Author,author.Co_Author,author.Copyright FROM books_list INNER JOIN author ON books_list.ISBN=author.ISBN"


            Dim connection As New MySqlConnection(connStr)

            Dim cmd As New MySqlCommand(query1, connection)

            connection.Open()

            Dim reader As MySqlDataReader

            reader = cmd.ExecuteReader()

            ' cmd.ExecuteNonQuery()


            While reader.Read()

                lvwitem = ListView1.Items.Add(reader.GetString(0))
                lvwitem.SubItems.Add(reader.GetString(1))
                lvwitem.SubItems.Add(reader.GetString(2))
                lvwitem.SubItems.Add(reader.GetString(3))
                lvwitem.SubItems.Add(reader.GetString(4))
                lvwitem.SubItems.Add(reader.GetString(5))
                lvwitem.SubItems.Add(reader.GetString(6))
                lvwitem.SubItems.Add(reader.GetString(7))
                ' lvwitem.SubItems.Add(reader.GetString(8))
                'lvwitem.SubItems.Add(reader.GetString(9))

            End While
            reader.Close()
            connection.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub ListView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.DoubleClick
        If ListView1.Items.Count > 0 Then
            Summary.Label1.Text = ListView1.SelectedItems(0).Text
            Summary.Label2.Text = ListView1.SelectedItems(0).SubItems(1).Text
            Summary.Label3.Text = ListView1.SelectedItems(0).SubItems(2).Text
            Summary.Label4.Text = ListView1.SelectedItems(0).SubItems(3).Text
            Summary.Label5.Text = ListView1.SelectedItems(0).SubItems(4).Text
            Summary.Label6.Text = ListView1.SelectedItems(0).SubItems(5).Text
            Summary.Label7.Text = ListView1.SelectedItems(0).SubItems(6).Text
            Summary.Label8.Text = ListView1.SelectedItems(0).SubItems(7).Text

        End If
        Summary.Show()
        Me.Close()


    End Sub

    ''Public Property CustomFormat As String
    ''Public Sub SetMyCustomFormat()
    ''    'Set the Format type and the CustomFormat string.'
    ''    dateTimePicker1.Format = DateTimePickerFormat.Custom'
    ''    dateTimePicker1.CustomFormat = "MMMM dd, yyyy - dddd"'
    ''End Sub

    '            day1 = DateTimePicker1.Value.DayOfYear
    '            day2 = DateTimePicker2.Value.DayOfYear

    '            If day1 > day2 Then
    '                MsgBox("return date invalid")
    '            Else

    '            End If



    ' Dim connStr As String = "Server=127.0.0.1;Port=3306;Database=library_system;Uid=root;Pwd=;"



    '    Try

    'Dim query1 As String = "SELECT * from books_list ORDER BY Title ASC"

    'Dim connection As New MySqlConnection(connStr)

    'Dim cmd As New MySqlCommand(query1, connection)

    '        connection.Open()

    'Dim reader As MySqlDataReader

    '        reader = cmd.ExecuteReader()

    '        While reader.Read()

    '' ComboBox1.Items.Add(reader.GetString(1))
    '            lstview = ListView1.Items.Add(reader.GetString(0))
    '            lstview.SubItems.Add(reader.GetString(1))
    '            lstview.SubItems.Add(reader.GetString(2))
    '            lstview.SubItems.Add(reader.GetString(3))
    '            lstview.SubItems.Add(reader.GetString(4))

    '        End While

    '        reader.Close()
    '        connection.Close()

    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub
End Class
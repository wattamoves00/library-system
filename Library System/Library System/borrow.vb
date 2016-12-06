Imports MySql.Data.MySqlClient
Public Class form10
    Dim connStr As String = "Server=127.0.0.1;Port=3306;Database=library_system;Uid=root;Pwd=;"
    Dim day1 As String
    Dim day2 As String
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or ComboBox1.Text = "" Or TextBox4.Text = "" Then
            MsgBox("Please complete the loanform")

        Else
            Try

                Dim query1 As String = "INSERT INTO loanform VALUES('" & TextBox1.Text & "'"
                query1 += " ,'" & TextBox2.Text & "' ,'" & TextBox3.Text & "','" & ComboBox1.Text & "'"
                query1 += ",'" & DateTimePicker1.Value & "','" & DateTimePicker2.Value & "','" & TextBox4.Text & "')"

                Dim connection As New MySqlConnection(connStr)

                Dim cmd As New MySqlCommand(query1, connection)

                ' SetMyCustomFormat()

                connection.Open()

                cmd.ExecuteNonQuery()


                connection.Close()
                fieldClear()
                Form2.Show()
                Me.Close()

                MsgBox("Successfully Borrowed")
                day1 = DateTimePicker1.Value
                day2 = DateTimePicker2.Value



                If day1 > day2 Then
                    MsgBox("return date invalid")
                Else

                End If
            Catch ex As Exception
                MsgBox(ex.Message)

            End Try

        End If
    End Sub

    Public Sub fieldClear()

        PictureBox1.Text = ""
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        DateTimePicker1.Value = ""
        DateTimePicker2.Value = ""
        TextBox4.Text = ""

    End Sub
    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged

    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Form2.Show()
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Form9.Show()
        Me.Close()
    End Sub

    Private Sub TextBox2_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox2.KeyUp
        If (Char.IsNumber(ChrW(e.KeyCode))) Then
            MsgBox("Enter a letter for Borrower Name")
            TextBox2.Text = ""
        End If
    End Sub
    
End Class
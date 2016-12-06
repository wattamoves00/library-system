Imports MySql.Data.MySqlClient
Public Class Form4
    Dim connStr As String = "Server=127.0.0.1;Port=3306;Database=library_system;Uid=root;Pwd=;"


    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Form2.Show()
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox7.Text = "" Or ComboBox1.Text = "" Or TextBox7.Text = "" Then
            MsgBox("Please complete the student information")
        Else

            Try

                Dim query1 As String = "INSERT INTO books_list VALUES('" & TextBox1.Text & "'"
                query1 += " ,'" & TextBox2.Text & "' ,'" & ComboBox1.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "')"
                Dim query As String = "INSERT INTO author VALUES('" & TextBox5.Text & "','" & TextBox6.Text & "','" & TextBox7.Text & "')"

                Dim connection As New MySqlConnection(connStr)

                Dim cmd As New MySqlCommand(query1, connection)

                Dim cmd1 As New MySqlCommand(query, connection)


                connection.Open()

                cmd.ExecuteNonQuery()



                connection.Close()
                fieldClear()

                If TextBox5.Text = "" Then
                    TextBox5.Text = "NONE"

                End If

                Form2.Show()
                Me.Close()

                MsgBox("Data Added")

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If

    End Sub

    Public Sub fieldClear()

        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        ComboBox1.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""

    End Sub

    Private Sub TextBox3_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox3.KeyUp
        If (Not Char.IsNumber(ChrW(e.KeyCode))) Then
            MsgBox("Enter a number for quantity")
            TextBox3.Text = ""
        End If
    End Sub

    Private Sub TextBox4_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox4.KeyUp
        If (Not Char.IsNumber(ChrW(e.KeyCode))) Then
            MsgBox("Enter a number for pages")
            TextBox4.Text = ""
        End If
    End Sub

    Private Sub TextBox5_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox5.KeyUp
        If (Char.IsNumber(ChrW(e.KeyCode))) Then
            MsgBox("Enter a number for author name")
            TextBox5.Text = ""
        End If
    End Sub

    Private Sub TextBox6_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox6.KeyUp
        If (Char.IsNumber(ChrW(e.KeyCode))) Then
            MsgBox("Enter a letter for co-author name")
            TextBox6.Text = ""
        End If
    End Sub

    Private Sub TextBox7_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox7.KeyUp
        If (Not Char.IsNumber(ChrW(e.KeyCode))) Then
            MsgBox("Enter a number for copyright")
            TextBox7.Text = ""
        End If
    End Sub

    Private Sub TextBox2_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox2.KeyUp
        If (Char.IsNumber(ChrW(e.KeyCode))) Then
            MsgBox("Enter a letter for title")
            TextBox2.Text = ""
        End If
    End Sub


End Class
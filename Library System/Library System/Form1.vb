Imports MySql.Data.MySqlClient

Public Class Form1
    Dim connStr As String = "Server=127.0.0.1;Port=3306;Database=library_system;Uid=root;Pwd=;"
    ' Dim reader As New MySqlDataReader

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            'Dim con As New MySqlConnection
            'Dim cmd As New MySqlCommand
            'Dim reader As My


            Dim querylogin As String = "SELECT * FROM login WHERE Username='" & TextBox1.Text & "' AND Password='" & TextBox2.Text & "'"
            Dim connection As New MySqlConnection(connStr)
            Dim cmd As New MySqlCommand(querylogin, connection)
            Dim reader As MySqlDataReader



            connection.Open()
            reader = cmd.ExecuteReader()



            If reader.HasRows Then

                Form2.Show()
                Me.Close()
            Else
                MsgBox("Invalid Username or Password")
                TextBox1.Text = ""
                TextBox2.Text = ""


                reader.Close()
                connection.Close()

            End If
        Catch ex As Exception

        End Try

       
    End Sub

    
End Class

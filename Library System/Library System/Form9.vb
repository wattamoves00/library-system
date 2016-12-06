Imports MySql.Data.MySqlClient
Public Class Form9
    Dim connStr As String = "Server=127.0.0.1;Port=3306;Database=library_system;Uid=root;Pwd=;"
    Dim selDelete As String = "none"

    

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        ListView1.Items.Clear()
        Dim lvwitem As New ListViewItem()


        Try

            Dim query As String = "SELECT * FROM student WHERE "
            query += "S_ID = '" & TextBox1.Text & "' "
            query += "OR F_Name LIKE '%" & TextBox1.Text & "%' "
            query += "OR Mid_Name LIKE '%" & TextBox1.Text & "%' "
            query += "OR L_Name LIKE '%" & TextBox1.Text & "%' "
            ' query += "OR Address LIKE '%" & TextBox1.Text & "%' "

            Dim connection As New MySqlConnection(connStr)

            Dim cmd As New MySqlCommand(query, connection)

            connection.Open()

            Dim reader As MySqlDataReader

            reader = cmd.ExecuteReader()

            While reader.Read()

                
                lvwitem = ListView1.Items.Add(reader.GetString(0))
                lvwitem.SubItems.Add(reader.GetString(1) & " " & reader.GetString(2) & " " & reader.GetString(3))
                lvwitem.SubItems.Add(reader.GetString(4))
                lvwitem.SubItems.Add(reader.GetString(5))
                lvwitem.SubItems.Add(reader.GetString(6))
                lvwitem.SubItems.Add(reader.GetString(7))

            End While
            reader.Close()
            connection.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If ListView1.SelectedIndices.Count > 0 Then
            selDelete = ListView1.Items(ListView1.SelectedIndices(0)).Text
            MsgBox(selDelete)
        End If

    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim Ask As MsgBoxResult = MsgBox("Are you sure you want to Delete Id number: " & selDelete, MsgBoxStyle.OkCancel)


        If Ask = MsgBoxResult.Ok Then

            ListView1.Items.Clear()


            Try

                Dim query1 As String = "DELETE FROM student WHERE S_ID='" & selDelete & "'"


                Dim connection As New MySqlConnection(connStr)

                Dim cmd As New MySqlCommand(query1, connection)

                connection.Open()

                cmd.ExecuteNonQuery()



                connection.Close()



                MsgBox("Data Deleted")
                selDelete = ""
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try



        Else
            MsgBox("Cancelled Deletion")
            selDelete = ""

        End If
    End Sub

    Private Sub TextBox1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TextBox1.MouseDown

        TextBox1.Text = ""

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        form10.Show()
        Me.Close()
    End Sub

    Private Sub AbuotUsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AbuotUsToolStripMenuItem.Click
        Form6.Show()
        Me.Close()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Form2.Show()
        Me.Close()
    End Sub

End Class
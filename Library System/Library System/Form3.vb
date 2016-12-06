Imports MySql.Data.MySqlClient
Public Class Form3

    Dim connStr As String = "Server=127.0.0.1;Port=3306;Database=library_system;Uid=root;Pwd=;"
    Dim selDelete As String = "none"


    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Form2.Show()
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox7.Text = "" Or ComboBox1.Text = "" Or TextBox7.Text = "" Then
            MsgBox("Please complete the student information")
        Else
            Try

                Dim query1 As String = "INSERT INTO student VALUES('" & TextBox1.Text & "'"
                query1 += " ,'" & TextBox2.Text & "' ,'" & TextBox3.Text & "','" & TextBox4.Text & "'"
                query1 += ",'" & TextBox5.Text & "','" & TextBox6.Text & "','" & ComboBox1.Text & "','" & TextBox7.Text & "')"

                Dim connection As New MySqlConnection(connStr)

                Dim cmd As New MySqlCommand(query1, connection)



                connection.Open()

                cmd.ExecuteNonQuery()



                connection.Close()
                fieldClear()
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
        TextBox5.Text = ""
        TextBox6.Text = ""
        ComboBox1.Text = ""
        TextBox7.Text = ""

    End Sub
   
    Private Sub AboutUsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutUsToolStripMenuItem.Click
        Form6.Show()
        Me.Close()
    End Sub

    Private Sub TextBox2_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox2.KeyUp
        If (Char.IsNumber(ChrW(e.KeyCode))) Then
            MsgBox("Enter a letter for First Name")
            TextBox2.Text = ""
        End If
    End Sub

    Private Sub TextBox3_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox3.KeyUp
        If (Char.IsNumber(ChrW(e.KeyCode))) Then
            MsgBox("Enter a letter for Mid Initial")
            TextBox3.Text = ""
        End If
    End Sub

    Private Sub TextBox4_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox4.KeyUp
        If (Char.IsNumber(ChrW(e.KeyCode))) Then
            MsgBox("Enter a letter for Last Name")
            TextBox4.Text = ""
        End If
    End Sub

    Private Sub TextBox7_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox7.KeyUp
        If (Not Char.IsNumber(ChrW(e.KeyCode))) Then
            MsgBox("Enter a number for Year Level")
            TextBox7.Text = ""
        End If
    End Sub

    'Private Sub TextBox6_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox6.KeyUp
    '    Dim contact As String
    '    Dim txtlength As Integer
    '    contact = Trim(TextBox6.Text)
    '    txtlength = contact.Length

    '    If txtlength < 10 Then
    '        MsgBox("Contact Number is incomplete")

    '    ElseIf txtlength > 10 Then
    '        MsgBox("Contact Number is almost 11 digits")
    '    End If

    'End Sub


    'Private Sub TextBox6_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox6.MouseLeave
    '    Dim contact As String
    '    Dim txtlength As Integer
    '    contact = Trim(TextBox6.Text)
    '    txtlength = contact.Length
    '    ' If txtlength <= 10 Then
    '    For txtlength = 0 To 10

    '    Next
    '    MsgBox("Contact Number is incomplete")

    '    If txtlength <= 10 Then
    '        MsgBox("Contact Number is more than 11 digits")
    '    End If

    'End Sub

   

    Private Sub TextBox6_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox6.LostFocus
       

    End Sub

   
    Private Sub TextBox6_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox6.Leave
        Dim contact As String
        Dim txtlength As Integer
        contact = Trim(TextBox6.Text)
        txtlength = contact.Length

        If txtlength < 10 Then
            MsgBox("Contact Number is incomplete")
            TextBox6.Focus()

        ElseIf txtlength > 10 Then
            MsgBox("Invalid contact number")
            TextBox6.Focus()
            TextBox6.Text = ""
        End If
    End Sub

End Class
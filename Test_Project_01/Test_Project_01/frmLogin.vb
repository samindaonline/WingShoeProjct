Public Class frmLogin

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim strlogin As String = "NOT OK"

        If txtUsername.Text = "admin" Or txtUsername.Text = "cashier" Or txtUsername.Text = "storekeeper" Then
            If txtPassword.Text = "admin" And txtUsername.Text = "admin" Then
                Module1.user = "admin"
                strlogin = "OK"
            ElseIf txtPassword.Text = "123" And txtUsername.Text = "cashier" Then
                Module1.user = "cashier"
                strlogin = "OK"
            ElseIf txtPassword.Text = "123" And txtUsername.Text = "storekeeper" Then
                Module1.user = "storekeeper"
                strlogin = "OK"
            Else
                txtPassword.BackColor = Color.Pink
                MessageBox.Show("Incorrect Password", "Invalid input!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtPassword.Clear()
                txtPassword.Focus()
                txtPassword.BackColor = Color.White
                strlogin = "NOT OK"
            End If
        Else
            txtUsername.BackColor = Color.Pink
            MessageBox.Show("Incorrect Username", "Invalid input!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtUsername.Clear()
            txtUsername.Focus()
            txtUsername.BackColor = Color.White
        End If

        If strlogin = "OK" Then
            Module1.loginStatus = "OK"

            Dim frmdashboard As New frmDashboard
            frmdashboard.MdiParent = frmMainDashboard
            frmdashboard.Show()

            Me.Close()
        Else
            Module1.loginStatus = "NOT"
            'MessageBox.Show("Please enter valid user name and password")
        End If

    End Sub

    Private Sub txtPassword_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim strlogin As String = "NOT OK"

            If txtUsername.Text = "admin" Or txtUsername.Text = "cashier" Or txtUsername.Text = "storekeeper" Then
                If txtPassword.Text = "admin" And txtUsername.Text = "admin" Then
                    Module1.user = "admin"
                    strlogin = "OK"
                ElseIf txtPassword.Text = "123" And txtUsername.Text = "cashier" Then
                    Module1.user = "cashier"
                    strlogin = "OK"
                ElseIf txtPassword.Text = "123" And txtUsername.Text = "storekeeper" Then
                    Module1.user = "storekeeper"
                    strlogin = "OK"
                Else
                    txtPassword.BackColor = Color.Pink
                    MessageBox.Show("Incorrect Password", "Invalid input!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtPassword.Clear()
                    txtPassword.Focus()
                    txtPassword.BackColor = Color.White
                    strlogin = "NOT OK"
                End If
            Else
                txtUsername.BackColor = Color.Pink
                MessageBox.Show("Incorrect Username", "Invalid input!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtUsername.Clear()
                txtUsername.Focus()
                txtUsername.BackColor = Color.White
            End If

            If strlogin = "OK" Then
                Module1.loginStatus = "OK"
                Dim frmdashboard As New frmDashboard
                frmdashboard.MdiParent = frmMainDashboard
                frmdashboard.Show()
                Me.Close()
            Else
                Module1.loginStatus = "NOT"
                'MessageBox.Show("Please enter valid user name and password")
            End If
        End If
    End Sub

    Private Sub txtUsername_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUsername.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtPassword.Text = "" Then
                txtPassword.Focus()
            Else
                Dim strlogin As String = "NOT OK"

                If txtUsername.Text = "admin" Or txtUsername.Text = "cashier" Or txtUsername.Text = "storekeeper" Then
                    If txtPassword.Text = "admin" And txtUsername.Text = "admin" Then
                        Module1.user = "admin"
                        strlogin = "OK"
                    ElseIf txtPassword.Text = "123" And txtUsername.Text = "cashier" Then
                        Module1.user = "cashier"
                        strlogin = "OK"
                    ElseIf txtPassword.Text = "123" And txtUsername.Text = "storekeeper" Then
                        Module1.user = "storekeeper"
                        strlogin = "OK"
                    Else
                        txtPassword.BackColor = Color.Pink
                        MessageBox.Show("Incorrect Password", "Invalid input!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        txtPassword.Clear()
                        txtPassword.Focus()
                        txtPassword.BackColor = Color.White
                        strlogin = "NOT OK"
                    End If
                Else
                    txtUsername.BackColor = Color.Pink
                    MessageBox.Show("Incorrect Username", "Invalid input!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtUsername.Clear()
                    txtUsername.Focus()
                    txtUsername.BackColor = Color.White
                End If

                If strlogin = "OK" Then
                    Module1.loginStatus = "OK"

                    Dim frmdashboard As New frmDashboard
                    frmdashboard.MdiParent = frmMainDashboard
                    frmdashboard.Show()

                    Me.Close()
                Else
                    Module1.loginStatus = "NOT"
                    'MessageBox.Show("Please enter valid user name and password")
                End If
            End If

        End If
    End Sub

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()
        Timer1.Interval = 100
        chkShowPassword.BackColor = System.Drawing.Color.Transparent
    End Sub


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If chkShowPassword.Checked = True Then
            txtPassword.PasswordChar = ""
        Else
            txtPassword.PasswordChar = "*"
        End If
    End Sub

End Class
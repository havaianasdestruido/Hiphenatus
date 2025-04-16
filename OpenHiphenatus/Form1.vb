Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MessageBox.Show(
            "Welcome to OpenHiphenatus! Here you can select which shaders you can run without harming you computer."
            )
    End Sub

    Public Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Hiphenatus.Form1.Shader1()
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Hiphenatus.Form1.Shader2()
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Hiphenatus.Form1.Shader3()
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Hiphenatus.Form1.Shader4()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Hiphenatus.Form1.Shader5()
    End Sub
End Class

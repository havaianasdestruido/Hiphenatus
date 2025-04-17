Public Class Form1
    ' Very VERY simple GUI for Shaders debugging and testing.
    ' OpenHiphenatus is basically just that, a Form filled of buttons,
    ' just like MEMZ Clean!

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MessageBox.Show(
            "Welcome to OpenHiphenatus! Here you can select which shaders you can run without harming you computer."
            )
    End Sub
    Public Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Hiphenatus.Form1.
            Shader1()
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Hiphenatus.Form1.
            Shader2()
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Hiphenatus.Form1.
            Shader3()
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Hiphenatus.Form1.
            Shader4()
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Hiphenatus.Form1.
            Shader5()
    End Sub
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        'TODO: Fix it ASAP.
        Throw New NotImplementedException("This shader is not implemented [to OH] yet.")
    End Sub
End Class

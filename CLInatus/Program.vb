Imports System
Imports System.Windows.Forms ' Adicionada referência necessária
Imports Hiphenatus

Module Program
    Sub Main(args As String())
        ' Corrigido para acessar o método Shader1 como um membro compartilhado
        Hiphenatus.Form1.Shader1()
    End Sub
End Module

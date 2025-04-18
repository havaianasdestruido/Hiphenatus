Namespace My
    ' Os seguintes eventos estão disponíveis para MyApplication:
    ' Inicialização: Ocorre quando o aplicativo é iniciado, antes da criação do formulário de inicialização.
    ' Desligamento: Ocorre após todos os formulários de aplicativo serem fechados. Esse evento não ocorrerá se o aplicativo for encerrado de forma anormal.
    ' UnhandledException: Ocorre se o aplicativo encontra uma exceção sem tratamento.
    ' StartupNextInstance: Ocorre durante a inicialização de um aplicativo de instância única quando o aplicativo já está ativo.
    ' NetworkAvailabilityChanged: Ocorre quando a conexão de rede é conectada ou desconectada.
    Partial Friend Class MyApplication
        ' Evento de inicialização
        Private Sub MyApplication_Startup(sender As Object, e As Microsoft.VisualBasic.ApplicationServices.StartupEventArgs) Handles Me.Startup
            ' Código executado durante a inicialização do aplicativo
            Console.WriteLine("Aplicativo iniciado!")
        End Sub

        ' Evento de desligamento
        Private Sub MyApplication_Shutdown(sender As Object, e As EventArgs) Handles Me.Shutdown
            ' Código executado durante o desligamento do aplicativo
            Console.WriteLine("Aplicativo encerrado!")
        End Sub

        ' Evento de exceção sem tratamento
        Private Sub MyApplication_UnhandledException(sender As Object, e As Microsoft.VisualBasic.ApplicationServices.UnhandledExceptionEventArgs) Handles Me.UnhandledException
            ' Código executado quando uma exceção sem tratamento ocorre
            Console.WriteLine($"Erro: {e.Exception.Message}")
            e.ExitApplication = False ' Define se o aplicativo deve ser encerrado
        End Sub

        ' Evento de nova instância de inicialização
        'Private Sub MyApplication_StartupNextInstance(sender As Object, e As Microsoft.VisualBasic.ApplicationServices.StartupNextInstanceEventArgs) Handles Me.StartupNextInstance
        '    ' Código executado quando uma nova instância do aplicativo é iniciada
        '    Console.WriteLine("Nova instância do aplicativo detectada!")
        'End Sub

        ' Evento de alteração de disponibilidade de rede
        'Private' Sub MyApplication_NetworkAvailabilityChanged(sender As Object, e As Microsoft.VisualBasic.Devices.NetworkAvailableEventArgs) Handles Me.NetworkAvailabilityChanged
        ' Código executado quando o estado da rede muda
        'If e.IsNetworkAvailable Then
        '        Console.WriteLine("Conexão de rede disponível!")
        'Else
        '        Console.WriteLine("Conexão de rede indisponível!")
        'End If
        'End Sub
    End Class
End Namespace

Imports Microsoft.AspNetCore
Imports Microsoft.AspNetCore.Hosting

Namespace AspNetCoreDashboardUseDifferentCaches
	Public Class Program
		Public Shared Sub Main(ByVal args() As String)
			BuildWebHost(args).Run()
		End Sub

		Public Shared Function BuildWebHost(ByVal args() As String) As IWebHost
			Return WebHost.CreateDefaultBuilder(args).UseStartup(Of Startup)().Build()
		End Function
	End Class
End Namespace
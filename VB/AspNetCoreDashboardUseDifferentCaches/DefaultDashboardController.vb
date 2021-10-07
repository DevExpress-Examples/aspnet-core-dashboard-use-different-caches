Imports DevExpress.DashboardAspNetCore
Imports DevExpress.DashboardWeb
Imports Microsoft.AspNetCore.DataProtection

' For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

Namespace AspNetCoreDashboardUseDifferentCaches
	Public Class DefaultDashboardController
		Inherits DashboardController

		Public Sub New(ByVal configurator As DashboardConfigurator, Optional ByVal dataProtectionProvider As IDataProtectionProvider = Nothing)
			MyBase.New(configurator, dataProtectionProvider)
		End Sub
	End Class
End Namespace

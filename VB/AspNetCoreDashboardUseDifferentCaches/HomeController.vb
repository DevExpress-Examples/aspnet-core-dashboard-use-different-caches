Imports Microsoft.AspNetCore.Mvc

' For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

Namespace AspNetCoreDashboardUseDifferentCaches
	Public Class HomeController
		Inherits Controller

		' GET: /<controller>/
		Public Function Index() As IActionResult
			Return View()
		End Function
		Public Function Refresh(<FromServices> ByVal cacheManager As CacheManager) As IActionResult
			cacheManager.ResetCache()
			Return Ok()
		End Function
	End Class
End Namespace

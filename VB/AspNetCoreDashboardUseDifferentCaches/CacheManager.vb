Imports Microsoft.AspNetCore.Http

Namespace AspNetCoreDashboardUseDifferentCaches
	Public Class CacheManager
		Private Const SessionKey As String = "UniqueCacheParam"
		Protected ReadOnly Property HttpContextAccessor() As IHttpContextAccessor

'INSTANT VB NOTE: The variable httpContextAccessor was renamed since Visual Basic does not handle local variables named the same as class members well:
		Public Sub New(ByVal httpContextAccessor_Renamed As IHttpContextAccessor)
			Me.HttpContextAccessor = httpContextAccessor_Renamed
		End Sub

		Public Sub ResetCache()
			HttpContextAccessor?.HttpContext?.Session?.SetString(SessionKey,Guid.NewGuid().ToString())
		End Sub
		Public ReadOnly Property UniqueCacheParam() As Guid
			Get
				Dim session As ISession = HttpContextAccessor?.HttpContext?.Session
				If session Is Nothing Then
					Return Guid.Empty
				Else
					If String.IsNullOrEmpty(session.GetString(SessionKey)) Then
						ResetCache()
					End If
					Return Guid.Parse(session.GetString(SessionKey))
				End If
			End Get
		End Property
	End Class
End Namespace

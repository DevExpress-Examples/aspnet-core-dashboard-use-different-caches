Imports DevExpress.AspNetCore
Imports DevExpress.DashboardAspNetCore
Imports DevExpress.DashboardCommon
Imports DevExpress.DashboardWeb
Imports DevExpress.DataAccess.Excel
Imports DevExpress.DataAccess.Sql
Imports Microsoft.AspNetCore.Builder
Imports Microsoft.AspNetCore.Hosting
Imports Microsoft.AspNetCore.Http
Imports Microsoft.Extensions.Configuration
Imports Microsoft.Extensions.DependencyInjection
Imports Microsoft.Extensions.DependencyInjection.Extensions
Imports Microsoft.Extensions.FileProviders

Namespace AspNetCoreDashboardUseDifferentCaches
	Public Class Startup
'INSTANT VB NOTE: The variable configuration was renamed since Visual Basic does not handle local variables named the same as class members well:
		Public Sub New(ByVal configuration_Renamed As IConfiguration, ByVal hostingEnvironment As IHostingEnvironment)
			Me.Configuration = configuration_Renamed
			FileProvider = hostingEnvironment.ContentRootFileProvider
			DashboardExportSettings.CompatibilityMode = DashboardExportCompatibilityMode.Restricted
		End Sub

		Public ReadOnly Property FileProvider() As IFileProvider
		Public ReadOnly Property Configuration() As IConfiguration

		' This method gets called by the runtime. Use this method to add services to the container.
		Public Sub ConfigureServices(ByVal services As IServiceCollection)
			services.AddMvc()
			services.AddScoped(Of DashboardConfigurator)(Function(serviceProvider As IServiceProvider)
															 Dim configurator As New DashboardConfigurator()

															 configurator.SetConnectionStringsProvider(New DashboardConnectionStringsProvider(Configuration))
															 Dim dashboardFileStorage As New DashboardFileStorage(FileProvider.GetFileInfo("Data/Dashboards").PhysicalPath)
															 configurator.SetDashboardStorage(dashboardFileStorage)
															 Dim dataSourceStorage As New DataSourceInMemoryStorage()
															 Dim sqlDataSource As New DashboardSqlDataSource("SQL Data Source", "NWindConnectionString")
															 sqlDataSource.DataProcessingMode = DataProcessingMode.Client
															 Dim query As SelectQuery = SelectQueryFluentBuilder.AddTable("Categories").Join("Products", "CategoryID").SelectAllColumns().Build("Products_Categories")
															 sqlDataSource.Queries.Add(query)
															 dataSourceStorage.RegisterDataSource("sqlDataSource", sqlDataSource.SaveToXml())
															 Dim objDataSource As New DashboardObjectDataSource("Object Data Source")
															 dataSourceStorage.RegisterDataSource("objDataSource", objDataSource.SaveToXml())
															 Dim excelDataSource As New DashboardExcelDataSource("Excel Data Source")
															 excelDataSource.FileName = FileProvider.GetFileInfo("Data/Sales.xlsx").PhysicalPath
															 excelDataSource.SourceOptions = New ExcelSourceOptions(New ExcelWorksheetSettings("Sheet1"))
															 dataSourceStorage.RegisterDataSource("excelDataSource", excelDataSource.SaveToXml())
															 configurator.SetDataSourceStorage(dataSourceStorage)
															 AddHandler configurator.DataLoading, Sub(s, e)
																									  If e.DataSourceName = "Object Data Source" Then
																										  e.Data = Invoices.CreateData()
																									  End If
																								  End Sub
															 AddHandler configurator.CustomParameters, Sub(sender, e)
																										   e.Parameters.Add(New DashboardParameter("UniqueCacheParam", GetType(Guid), serviceProvider.GetService(Of CacheManager)().UniqueCacheParam))
																									   End Sub
															 AddHandler configurator.ConfigureDataReloadingTimeout, Sub(s, e)
																														If e.DashboardId = "dashboard1" Then
																															e.DataReloadingTimeout = New TimeSpan(1, 0, 0)
																														End If
																													End Sub
															 Return configurator
														 End Function)

			services.AddDevExpressControls(Sub(options) options.Resources = ResourcesType.ThirdParty Or ResourcesType.DevExtreme)

			services.AddDistributedMemoryCache().AddSession()
			services.TryAddSingleton(Of IHttpContextAccessor,HttpContextAccessor)()
			services.AddSingleton(Of CacheManager)(Function(serviceProvider) New CacheManager(serviceProvider.GetService(Of IHttpContextAccessor)()))
		End Sub

		' This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		Public Sub Configure(ByVal app As IApplicationBuilder, ByVal env As IHostingEnvironment)
			app.UseDevExpressControls()
			If env.IsDevelopment() Then
				app.UseDeveloperExceptionPage()
			Else
				app.UseExceptionHandler("/Home/Error")
			End If
			app.UseStaticFiles()

			app.UseSession()

			app.UseMvc(Sub(routes)
						   routes.MapDashboardRoute("api/dashboard", "DefaultDashboard")
						   routes.MapRoute(name:= "default", template:= "{controller=Home}/{action=Index}/{id?}")
			End Sub)
		End Sub
	End Class
End Namespace
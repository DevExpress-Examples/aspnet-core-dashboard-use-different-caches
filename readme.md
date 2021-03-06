_Files to look at:_

- [Index.cshtml](/CS/AspNetCoreDashboardUseDifferentCaches/Pages/Index.cshtml) (VB: [Index.cshtml](/VB/AspNetCoreDashboardUseDifferentCaches/Pages/Index.cshtml))
- [HomeController.cs](/CS/AspNetCoreDashboardUseDifferentCaches/HomeController.cs) (VB: [HomeController.vb](/VB/AspNetCoreDashboardUseDifferentCaches/HomeController.vb))
- [Startup.cs](/CS/AspNetCoreDashboardUseDifferentCaches/Startup.cs) (VB: [Startup.vb](/VB/AspNetCoreDashboardUseDifferentCaches/Startup.vb))
- [CacheManager.cs](/CS/AspNetCoreDashboardUseDifferentCaches/CacheManager.cs) (VB: [CacheManager.vb](/VB/AspNetCoreDashboardUseDifferentCaches/CacheManager.vb))

# How to Reset the Cache Forcedly in ASP.NET Core Dashboard
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/188187035/)**
<!-- run online end -->

To refresh the data source cache on the server side, pass a unique parameter value to the [DashboardConfigurator.CustomParameters](http://docs.devexpress.com/Dashboard/DevExpress.DashboardWeb.DashboardConfigurator.CustomParameters) event.

For instance, you can store a unique GUID value within a session as a parameter and update its value in your code when it is necessary to refresh the cache.

Use the **Refresh Cache** button to update the cache forcedly.

Note that you can refresh the data source cache on the client side. For this, call the [DashboardControl.reloadData](https://docs.devexpress.com/Dashboard/js-DevExpress.Dashboard.DashboardControl#js_DevExpress_Dashboard_DashboardControl_reloadData) client method.

See [Manage an In-Memory Data Cache](https://docs.devexpress.com/Dashboard/400987) for details.

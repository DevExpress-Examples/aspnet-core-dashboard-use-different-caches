<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/188187035/21.2.1%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T828694)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->

# Dashboard for ASP.NET Core - How to Reset the Data Source Cache

The following example shows how you can manage the cache in the ASP.NET Core Dashboard control.

To refresh the data source cache **on the server**, pass a unique parameter value to the [DashboardConfigurator.CustomParameters](http://docs.devexpress.com/Dashboard/DevExpress.DashboardWeb.DashboardConfigurator.CustomParameters) event. You can store the unique GUID value within a session as a parameter and update its value in your code when it is necessary to refresh the cache.

To refresh the data source cache **on the client**, you can call the [DashboardControl.reloadData](https://docs.devexpress.com/Dashboard/js-DevExpress.Dashboard.DashboardControl#js_DevExpress_Dashboard_DashboardControl_reloadData) client method.

- Click **Refresh Cache (Server)** to force the cache reset on the server.
- Click **Refresh Cache (Client)** to force the cache reset using the client API.

![](reset-cache-buttons.png)

## Files to Review

- [Index.cshtml](/CS/AspNetCoreDashboardUseDifferentCaches/Views/Home/Index.cshtml)
- [_Layout.cshtml](/CS/AspNetCoreDashboardUseDifferentCaches/Views/Shared/_Layout.cshtml#L19-L31)
- [HomeController.cs](/CS/AspNetCoreDashboardUseDifferentCaches/Controllers/HomeController.cs#L13-L16)
- [Startup.cs](/CS/AspNetCoreDashboardUseDifferentCaches/Startup.cs#L57)
- [CacheManager.cs](/CS/AspNetCoreDashboardUseDifferentCaches/CacheManager.cs)

## Documentation

- [Manage an In-Memory Data Cache](https://docs.devexpress.com/Dashboard/400983/web-dashboard/dashboard-backend/manage-an-in-memory-data-cache)

## More Examples

- [Dashboard for ASP.NET Core - How to Use Parameters to Update a Specific Dashboard Item Without Refreshing the Entire Dashboard](https://github.com/DevExpress-Examples/asp-net-core-dashboard-refresh-item-on-parameter-change)
- [Dashboard for Web Forms - How to Reset the Data Source Cache](https://github.com/DevExpress-Examples/web-forms-dashboard-use-different-caches)
- [Dashboard for MVC - How to Reset the Data Source Cache](https://github.com/DevExpress-Examples/mvc-dashboard-use-different-caches)
<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=aspnet-core-dashboard-use-different-caches&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=aspnet-core-dashboard-use-different-caches&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->

# Power BI Embedded MVC Application
This is an ASP.NET MVC Application that has an integrated Power BI Embedded Report.

What you need is to update 3 keys in the web.config:

''' Web.Config Configuration
    <add key="powerbi:AccessKey" value="s6hs+xGx6jAhDlNWqyTNW7IaSampyxmgvZ4+3fY/ORbHzecQOIVsik+e3WPqN1cK3SsQ/vmBp2Hbucvp7YHNqw==" />
    <add key="powerbi:ApiUrl" value="https://api.powerbi.com" />
    <add key="powerbi:WorkspaceCollection" value="PBIEDemo" />
    <add key="powerbi:WorkspaceId" value="9c155666-7e65-4694-ac71-f80e4898035f" />
'''

Then, Run the app and you will be able to embed first report you have imported in Power BI workspace collection in Azure.

Detailed blog post is here: http://www.mostafaelzoghbi.com/2016/04/power-bi-embedded-step-by-step.html

A screen shot of the running application:

![pbiemvccapture](https://cloud.githubusercontent.com/assets/11993393/19364182/2249867a-915b-11e6-8e8a-6f14e9114682.PNG)


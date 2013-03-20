<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="HQAccessPoint.UI._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:ScriptManagerProxy ID="sm" runat="server">
        <Services>
            <asp:ServiceReference Path="~/Services/WidgetService.svc" />
        </Services>
    </asp:ScriptManagerProxy>

    <script type="text/javascript">
        function callService() {
            debugger;
            IWidgetService.GetAllWidgets(function (data) {
                debugger;
                $.each(data, function (i,cb) {
                    $("#WidgetHolder").append(cb.Name);
                });
            }, function (error) {
                debugger;
                alert("Error: " + error);
            });
            return false;
        }
    
    </script>
    <h2>
        Welcome to ASP.NET!
    </h2>
    <p>
        To learn more about ASP.NET visit <a href="http://www.asp.net" title="ASP.NET Website">www.asp.net</a>.
    </p>
    <p>
        You can also find <a href="http://go.microsoft.com/fwlink/?LinkID=152368&amp;clcid=0x409"
            title="MSDN ASP.NET Docs">documentation on ASP.NET at MSDN</a>.
    </p>

    <button id="CallService" onclick="return callService();">Call Service</button>

    <div id="WidgetHolder">
        
    
    </div>
</asp:Content>

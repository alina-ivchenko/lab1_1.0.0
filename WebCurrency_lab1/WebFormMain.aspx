<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormMain.aspx.cs" Inherits="WebCurrency_lab1.WebFormMain" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    </head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
        <p>
            <asp:Table ID="TableCur" runat="server">
            </asp:Table>
        </p>
        <p>
            <asp:Label ID="Label1" runat="server" Text="Время последнего обновления:  "></asp:Label>
            <asp:Label ID="LabelTimeUpdate" runat="server"></asp:Label>
        </p>
    </form>
</body>
</html>

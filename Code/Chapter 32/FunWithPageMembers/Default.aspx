<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <strong style="font-weight: 700">Basic Request / Response Info<br />
        <br />
        <asp:Button ID="btnGetBrowserStats" runat="server" 
            OnClick="btnGetBrowserStats_Click" Text="Get Stats" />
        <br />
        <br />
        <asp:Label ID="lblOutput" runat="server"></asp:Label>
        </strong>
    
    </div>
    </form>
</body>
</html>

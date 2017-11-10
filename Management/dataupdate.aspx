<%@ Page Language="C#" AutoEventWireup="true" CodeFile="dataupdate.aspx.cs" Inherits="dataupdate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:FileUpload runat="server" ID="flData" />
    <asp:Button runat="server" ID="btnGo" Text="Update" OnClick="btnGo_Click" />
    </div>
    </form>
</body>
</html>

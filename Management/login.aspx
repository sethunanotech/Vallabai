<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:TextBox runat="server" ID="txtInput"></asp:TextBox>    
    <asp:Button runat="server" ID="btnConvert" Text="Convert" OnClick="btnConvert_Click" />
    </div>
    </form>
</body>
</html>

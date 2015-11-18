<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SimpleProxy.WebForms.Test.Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Hello world!</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Hello world!</h1>

            <p>(We have some PageMethods here too)</p>
        </div>

        <asp:ScriptManager runat="server" ID="ScriptManager1" EnablePageMethods="True"></asp:ScriptManager>
    </form>
</body>
</html>

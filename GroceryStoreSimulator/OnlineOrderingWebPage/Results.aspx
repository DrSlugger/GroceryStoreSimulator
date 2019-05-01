<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Results.aspx.cs" Inherits="Results" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Online Ordering</title>
    <link href="https://fonts.googleapis.com/css?family=Libre+Baskerville|Roboto" rel="stylesheet" />
    <link rel="stylesheet" href="style.css" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="box2"><h1>Your order.</h1></div>
        <div class="box">
            <h3>Order Number: </h3>
            <asp:Label ID="lblOrderNumber" runat="server" Text="[OrderNumber]"></asp:Label>
            <h3>Order Details: </h3>
            <asp:BulletedList ID="bltDetailsList" runat="server"></asp:BulletedList>
            <h5>Submit another order?</h5>
            <asp:Button ID="btnReturn" runat="server" Text="Go Back" OnClick="btn_Return_Click" />
        </div>
    </form>
</body>
</html>

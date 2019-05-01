<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Order.aspx.cs" Inherits="Order" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Online Ordering</title>
    <link href="https://fonts.googleapis.com/css?family=Libre+Baskerville|Roboto" rel="stylesheet">
    <link rel="stylesheet" href="style.css" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="box2"><h1>Enter your order here.</h1></div>
        <div class="box">
            <h3>Items available at this store</h3>
            <asp:ListBox ID="lstItems" runat="server"></asp:ListBox>
            <br />
            <h5>Item quantity</h5>
            <asp:TextBox ID="tbxQuantity" runat="server"></asp:TextBox>
            <br /><br />
            <asp:Button ID="btnAddToCart" runat="server" Text="Add to cart" OnClick="btnAddToCart_Click" />
            <h3>Items in cart</h3>
            <asp:ListBox ID="lstCart" runat="server"></asp:ListBox>
            <h5>Current total: </h5><asp:Label ID="lblTotalCost" runat="server" Text="[Total]"></asp:Label>
            <br /><br />
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
        </div>
    </form>
</body>
</html>

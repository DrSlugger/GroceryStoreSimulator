<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Online Ordering</title>
    <link href="https://fonts.googleapis.com/css?family=Libre+Baskerville|Roboto" rel="stylesheet">
    <link rel="stylesheet" href="style.css" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="box2"><h1>Welcome to Marbatch Mart</h1></div>
    <div class="box">
        <asp:Image ID="imgGroceries" runat="server" ImageUrl="~/App_Themes/DefaultTheme/Groceries.bmp" />
        <h3>Enter your Loyalty Number</h3>
        <asp:TextBox ID="tbxLoyaltyNumber" runat="server"></asp:TextBox>
        <h3>Select a Store</h3>
        <asp:DropDownList ID="drpStores" runat="server" AutoPostBack="false"></asp:DropDownList>
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
    </div>
    </form>
</body>
</html>

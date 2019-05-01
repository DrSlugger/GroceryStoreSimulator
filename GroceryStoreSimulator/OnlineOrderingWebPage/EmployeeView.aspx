<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EmployeeView.aspx.cs" Inherits="EmployeeView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Online Ordering</title>
    <link href="https://fonts.googleapis.com/css?family=Libre+Baskerville|Roboto" rel="stylesheet">
    <link rel="stylesheet" href="style.css" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="box2"><h1>Employee View</h1></div>
        <div class="box">
            <h3>Pending Orders</h3>
            <h5>Mark orders as "delivered" here.</h5>
            <asp:CheckBoxList ID="CheckBoxList1" runat="server"></asp:CheckBoxList>
            <asp:Button ID="btn_SubmitCheckedOrders" runat="server" Text="Submit" />
            <h3>System Report</h3>
            <h5>Order History</h5>
            <asp:BulletedList ID="BulletedList1" runat="server"></asp:BulletedList>
        </div>
    </form>
</body>
</html>

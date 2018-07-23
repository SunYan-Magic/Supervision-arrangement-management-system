<%@ Page Language="C#" AutoEventWireup="true" CodeFile="addtime.aspx.cs" Inherits="Admin_addtime" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>设定考试时间</title>
    <base target="_self"/>
    <link href="../css/Style.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../js/themes/default/easyui.css"/>
	<link rel="stylesheet" type="text/css" href="../js/themes/icon.css"/>
	<script type="text/javascript" src="../js/jquery-1.7.1.min.js"></script>
	<script type="text/javascript" src="../js/jquery.easyui.min.js"></script>
	<script language="JavaScript" type="text/javascript" >
        window.name="mywin";
    </script> 
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <teble>
    <tr>
    
        
        <asp:Button ID="Button1" runat="server" BorderStyle="Inset" BorderWidth="1px" Height="21px" Width="102px" onclick="Button1_Click" Text="考试起始时间" /><br /><br />
        <asp:Calendar ID="Calendar1" runat="server" Visible="False" onselectionchanged="Calendar1_SelectionChanged" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="200px" Width="220px">
            <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
            <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
            <OtherMonthDayStyle ForeColor="#999999" />
            <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
            <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
            <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
            <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
            <WeekendDayStyle BackColor="#CCCCFF" />
        </asp:Calendar>
        
        </tr>
        <tr>
        <asp:Button ID="Button2" runat="server" BorderStyle="Inset" BorderWidth="1px" Height="21px" Width="102px" onclick="Button2_Click" Text=" 考试结束日期" />
        <asp:Calendar ID="Calendar2" runat="server" Visible="False" onselectionchanged="Calendar2_SelectionChanged" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="200px" Width="220px">
            <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
            <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
            <OtherMonthDayStyle ForeColor="#999999" />
            <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
            <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
            <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
            <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
            <WeekendDayStyle BackColor="#CCCCFF" />
        </asp:Calendar>
            </tr>
       <tr> <asp:Button ID="Button3" runat="server" BorderStyle="Inset" BorderWidth="1px" Height="21px" Width="102px" onclick="Button3_Click" Text="确定" />
           </tr></teble>
    </div>
        </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="admin_timemanage.aspx.cs" Inherits="Admin_admin_timemanage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>预请求管理</title>
    <link href="../css/Style.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../js/themes/default/easyui.css"/>
	<link rel="stylesheet" type="text/css" href="../js/themes/icon.css"/>
	<script type="text/javascript" src="../js/jquery-1.7.1.min.js"></script>
	<script type="text/javascript" src="../js/jquery.easyui.min.js"></script>
    <style type="text/css">
        .auto-style1 {
            height: 54px;
        }
        .auto-style3 {
            width: 398px;
        }
        .auto-style4 {
            width: 398px;
            height: 30px;
        }
    </style>
</head>
<body>
    <form id="form2" runat="server">
    <div>
    <table style="height: 179px">
            <tr>
                <td style="font-size:30px;" class="auto-style1">
                    时间管理</td>
            </tr>
        <tr>
                <td align="center" class="auto-style3">
                    考试起始日期：<asp:Label ID="date1" runat="server" ForeColor="Black" Font-Size="14px"></asp:Label>
                    </td>
            </tr>
            <tr>
                <td align="center" class="auto-style4">
                    考试终止日期：<asp:Label ID="date2" runat="server" ForeColor="Black" Font-Size="14px"></asp:Label>
                </td>
            </tr>
         <tr>
                <td>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                    <asp:LinkButton ID="lbtnadd" class="easyui-linkbutton" plain="true" iconCls="icon-add" runat="server" OnClick="lbtnadd_Click">添加</asp:LinkButton>&nbsp; 
                    &nbsp;&nbsp;<asp:LinkButton ID="lbtnrefresh" class="easyui-linkbutton" plain="true" iconCls="icon-reload" runat="server" OnClick="lbtnrefresh_Click">刷新</asp:LinkButton>
                   
                <td style="width: 100px">
                </td>
            </tr>
        </table>
    
   
    </div>
    </form>
</body>
</html>

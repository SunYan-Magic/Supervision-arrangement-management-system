<%@ Page Language="C#" AutoEventWireup="true" CodeFile="updateclass.aspx.cs" Inherits="Admin_updateclass" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>修改专业信息</title>
    <base target="_self"/>
    <link href="../css/Style.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../js/themes/default/easyui.css"/>
	<link rel="stylesheet" type="text/css" href="../js/themes/icon.css"/>
	<script type="text/javascript" src="../js/jquery-1.7.1.min.js"></script>
	<script type="text/javascript" src="../js/jquery.easyui.min.js"></script>
    <script language="JavaScript" type="text/javascript" >
        window.name="mywin2";
    </script> 
    <style type="text/css">
        .auto-style1 {
            width: 83px;
        }
        .auto-style2 {
            width: 288px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" target="mywin2">
    <div>
        <table>
            <tr>
                <td colspan="2" style="font-size:30px;">
                    修改专业信息</td>
            </tr>
            <tr>
                <td class="auto-style1">
                </td>
                <td class="auto-style2">
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                   ID&nbsp;        号：</td>
                <td class="auto-style2">
                    <asp:TextBox ID="classid" runat="server" CssClass="tb"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="classid" Display="Dynamic"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    专业名称：</td>
                <td class="auto-style2">
                    <asp:TextBox ID="bjname" runat="server" CssClass="tb"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvname" runat="server" ErrorMessage="*" ControlToValidate="bjname" Display="Dynamic"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    专业编码：</td>
                <td class="auto-style2">
                    <asp:TextBox ID="bjcode" runat="server" CssClass="tb">
                    </asp:TextBox><asp:RequiredFieldValidator ID="rfvcode" runat="server" ErrorMessage="*" ControlToValidate="bjcode" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="bjcode"
                       Display="Dynamic" ErrorMessage="请输入正确的专业编码" ValidationExpression="^\d{10}$"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    专业人数：</td>
                <td class="auto-style2">
                    <asp:TextBox ID="bjnum" runat="server" CssClass="tb"></asp:TextBox>
                    <asp:RequiredFieldValidator
                        ID="rfvnum" runat="server" Display="Dynamic" ErrorMessage="*" ControlToValidate="bjnum"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revnum" runat="server" ControlToValidate="bjnum"
                       Display="Dynamic" ErrorMessage="请输入正确的人数" ValidationExpression="\d+$"></asp:RegularExpressionValidator></td>
               
            </tr>
            <tr>
                <td class="auto-style1">
                </td>
                <td class="auto-style2">
                    <asp:LinkButton ID="lbtnupd" class="easyui-linkbutton" runat="server" OnClick="lbtnupd_Click">修改</asp:LinkButton></td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>

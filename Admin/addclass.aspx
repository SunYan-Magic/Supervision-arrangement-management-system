<%@ Page Language="C#" AutoEventWireup="true" CodeFile="addclass.aspx.cs" Inherits="Admin_addclass" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>添加专业</title>
    <base target="_self"/>
    <link href="../css/Style.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../js/themes/default/easyui.css"/>
	<link rel="stylesheet" type="text/css" href="../js/themes/icon.css"/>
	<script type="text/javascript" src="../js/jquery-1.7.1.min.js"></script>
	<script type="text/javascript" src="../js/jquery.easyui.min.js"></script>
	<script language="JavaScript" type="text/javascript" >
        window.name="mywin";
    </script> 
    <style type="text/css">
        .auto-style1 {
            width: 80px;
            height: 30px;
        }
        .auto-style2 {
            width: 239px;
            height: 30px;
        }
        .auto-style3 {
            width: 80px;
            height: 25px;
        }
        .auto-style4 {
            width: 239px;
            height: 25px;
        }
        .auto-style5 {
            width: 239px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" target="mywin">
    <div>
        <table>
            <tr>
                <td colspan="2" style="font-size:30px;">
                    添加专业</td>
            </tr>
            <tr>
                <td align="right" style="width: 65px">
                </td>
                <td class="auto-style5">
                </td>
            </tr>
            <tr>
                <td align="right" class="auto-style3">
                    专业名称：</td>
                <td class="auto-style4">
                    <asp:TextBox ID="bjname" runat="server" CssClass="tb"></asp:TextBox>
                    <asp:RequiredFieldValidator
                        ID="rfvname" runat="server" ControlToValidate="bjname" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 80px">
                    专业编码：</td>
                <td class="auto-style5">
                    <asp:TextBox ID="bjcode" runat="server" CssClass="tb"></asp:TextBox>
                    <asp:RequiredFieldValidator
                        ID="rfvcode" runat="server" Display="Dynamic" ErrorMessage="*" ControlToValidate="bjcode"></asp:RequiredFieldValidator>
                     <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="bjcode"
                       Display="Dynamic" ErrorMessage="请输入正确的专业编码" ValidationExpression="^\d{10}$"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 80px">
                    专业人数：</td>
                <td class="auto-style5">
                    <asp:TextBox ID="bjnum" runat="server" CssClass="tb"></asp:TextBox>
                    <asp:RequiredFieldValidator
                        ID="rfvnum" runat="server" Display="Dynamic" ErrorMessage="*" ControlToValidate="bjnum"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revnum" runat="server" ControlToValidate="bjnum"
                       Display="Dynamic" ErrorMessage="请输入正确的人数" ValidationExpression="\d+$"></asp:RegularExpressionValidator></td>
               
            </tr>
            <tr>
                <td align="right" class="auto-style1">
                </td>
                <td class="auto-style2">
                    <asp:LinkButton ID="lbtnadd" class="easyui-linkbutton" runat="server" OnClick="lbtnadd_Click">添加</asp:LinkButton></td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="addroom.aspx.cs" Inherits="Admin_addroom" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>添加考场</title>
    <base target="_self"/>
    <link href="../css/Style.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../js/themes/default/easyui.css"/>
	<link rel="stylesheet" type="text/css" href="../js/themes/icon.css"/>
	<script type="text/javascript" src="../js/jquery-1.7.1.min.js"></script>
	<script type="text/javascript" src="../js/jquery.easyui.min.js"></script>
	<script language="JavaScript" type="text/javascript" >
	    window.name = "mywin";
    </script> 
    <style type="text/css">
        .auto-style2 {
            width: 282px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" target="mywin">
    <div style="width: 322px">
        <table>
            <tr>
                <td colspan="2" style="font-size:30px;">
                    添加考场</td>
            </tr>
            <tr>
                <td align="right" style="width: 65px">
                </td>
                <td class="auto-style2">
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 80px">
                    考场名称：</td>
                <td class="auto-style2">
                    <asp:TextBox ID="kcname" runat="server" CssClass="tb"></asp:TextBox>
                    <asp:RequiredFieldValidator
                        ID="rfvname" runat="server" ControlToValidate="kcname" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 80px">
                    考场编码：</td>
                <td class="auto-style2">
                    <asp:TextBox ID="kccode" runat="server" CssClass="tb"></asp:TextBox>
                    <asp:RequiredFieldValidator
                        ID="rfvcode" runat="server" Display="Dynamic" ErrorMessage="*" ControlToValidate="kccode"></asp:RequiredFieldValidator>
                     <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="kccode"
                       Display="Dynamic" ErrorMessage="请输入正确的考场编码" ValidationExpression="^[0-9A-Z]{6}$"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 80px">
                    考场容量：</td>
                <td class="auto-style5">
                    <asp:TextBox ID="kcnum" runat="server" CssClass="tb"></asp:TextBox>
                    <asp:RequiredFieldValidator
                        ID="rfvnum" runat="server" Display="Dynamic" ErrorMessage="*" ControlToValidate="kcnum"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revnum" runat="server" ControlToValidate="kcnum"
                       Display="Dynamic" ErrorMessage="请输入正确的容量" ValidationExpression="\d+$"></asp:RegularExpressionValidator></td>
               
            </tr>
            <tr>
                <td align="right" style="width: 80px">
                </td>
                <td class="auto-style2">
                    <asp:LinkButton ID="lbtnadd" class="easyui-linkbutton" runat="server" OnClick="lbtnadd_Click">添加</asp:LinkButton></td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>

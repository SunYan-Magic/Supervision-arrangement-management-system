<%@ Page Language="C#" AutoEventWireup="true" CodeFile="addteacher.aspx.cs" Inherits="Admin_addteacher" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>添加老师信息</title>
    <base target="_self"/>
    <link href="../css/Style.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../js/themes/default/easyui.css"/>
	<link rel="stylesheet" type="text/css" href="../js/themes/icon.css"/>
	<script type="text/javascript" src="../js/jquery-1.7.1.min.js"></script>
	<script type="text/javascript" src="../js/jquery.easyui.min.js"></script>
	<script language="JavaScript" type="text/javascript" >
	    window.name = "mywin";
	    window.onload = showdropitem;
	    function showdropitem() {
	        var el = document.getElementsByTagName("select");
	        for (i = 0; i < el.length; i++) {
	            for (j = 0; j < el[i].options.length; j++) {
	                el[i].options[j].title = el[i].options[j].text;
	            }
	        }
	    }
    </script> 
    <style type="text/css">
        .auto-style2 {
            width: 257px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" target="mywin">
    <div>
      <table>
            <tr>
                <td colspan="2" style="font-size:30px;">
                    添加老师信息</td>
            </tr>
            <tr>
                <td align="right" style="width: 65px">
                </td>
                <td class="auto-style2">
                </td>
            </tr>
         
            <tr>
                <td align="right" style="width: 100px">
                    老师姓名：</td>
                <td class="auto-style2">
                    <asp:TextBox ID="lsname" runat="server" CssClass="tb"></asp:TextBox><asp:RequiredFieldValidator
                        ID="rfvname" runat="server" ControlToValidate="lsname" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 100px">
                    老师编码：</td>
                <td class="auto-style2">
                    <asp:TextBox ID="lscode" runat="server" CssClass="tb"></asp:TextBox><asp:RequiredFieldValidator
                        ID="rfvcode" runat="server" Display="Dynamic" ErrorMessage="*" ControlToValidate="lscode"></asp:RequiredFieldValidator>
                     <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="lscode"
                       Display="Dynamic" ErrorMessage="请输入正确的老师编码" ValidationExpression="^\d{9}$"></asp:RegularExpressionValidator>
                </td>
            </tr>
          
             <tr>
                <td align="right" style="width: 100px">
                    老师电话：</td>
                <td class="auto-style2">
                    <asp:TextBox ID="lstel" runat="server" CssClass="tb"></asp:TextBox><asp:RequiredFieldValidator
                        ID="rfvtel" runat="server" Display="Dynamic" ErrorMessage="*" ControlToValidate="lstel"></asp:RequiredFieldValidator>               
                <asp:RegularExpressionValidator ID="revnum" runat="server" ControlToValidate="lstel"
                       Display="Dynamic" ErrorMessage="请输入正确的手机号" ValidationExpression="^0{0,1}(13[4-9]|15[7-9]|15[0-2])[0-9]{8}$"></asp:RegularExpressionValidator></td> 
            </tr>
          
            <tr>
                <td align="right" style="width: 65px">
                </td>
                <td class="auto-style2">
                    <asp:LinkButton ID="lbtnadd" class="easyui-linkbutton" runat="server" OnClick="lbtnadd_Click">确认</asp:LinkButton></td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>

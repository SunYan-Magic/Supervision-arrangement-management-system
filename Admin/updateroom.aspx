<%@ Page Language="C#" AutoEventWireup="true" CodeFile="updateroom.aspx.cs" Inherits="Admin_updateroom" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>修改考场</title>
    <base target="_self"/>
    <link href="../css/Style.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../js/themes/default/easyui.css"/>
	<link rel="stylesheet" type="text/css" href="../js/themes/icon.css"/>
	<script type="text/javascript" src="../js/jquery-1.7.1.min.js"></script>
	<script type="text/javascript" src="../js/jquery.easyui.min.js"></script>
	<script type="text/javascript" >
	   window.name="mywin";
	</script>
    <style type="text/css">
        .auto-style1 {
            width: 388px;
        }
        .auto-style2 {
            height: 23px;
            width: 388px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" target="mywin">
    <div style="width: 387px">
      <table>
            <tr>
                <td colspan="2" style="font-size:30px;">
                    修改考场</td>
            </tr>
            <tr>
                <td align="right" style="width: 65px">
                </td>
                <td class="auto-style1">
                </td>
            </tr>
          <tr>
                <td align="right" style="width: 100px">
                   ID号：</td>
                <td class="auto-style1">
                    <asp:TextBox ID="roomid" runat="server" CssClass="btb"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="roomid" Display="Dynamic"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 100px">
                    考场名称：</td>
                <td class="auto-style1">
                    <asp:TextBox ID="kcname" runat="server" CssClass="btb"></asp:TextBox>
                    <asp:RequiredFieldValidator
                        ID="rfvname" runat="server" ControlToValidate="kcname" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 100px">
                    考场编码：</td>
                <td class="auto-style1">
                    <asp:TextBox ID="kccode" runat="server" CssClass="btb"></asp:TextBox>
                    <asp:RequiredFieldValidator
                        ID="rfvcode" runat="server" Display="Dynamic" ErrorMessage="*" ControlToValidate="kccode"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="kccode"
                       Display="Dynamic" ErrorMessage="请输入正确的考场编码" ValidationExpression="^[0-9A-Z]{6}$"></asp:RegularExpressionValidator>
                </td>
            </tr>
           
           <tr>
               <td align="right" style="width: 100px; height: 23px;">
                   考场容量：</td>
               <td class="auto-style2">
                   <asp:TextBox ID="kcnum" runat="server" CssClass="btb"></asp:TextBox>
                   <asp:RequiredFieldValidator ID="rfvcount" runat="server" ControlToValidate="kcnum"
                       Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
                   <asp:RegularExpressionValidator ID="revcount" runat="server" ControlToValidate="kcnum"
                       Display="Dynamic" ErrorMessage="请输入正确的考场容量" ValidationExpression="\d+$"></asp:RegularExpressionValidator></td>
           </tr>
           
            <tr>
                <td align="right" style="width: 65px">
                </td>
                <td class="auto-style1">
                    <asp:LinkButton ID="lbtnupd" class="easyui-linkbutton" runat="server" OnClick="lbtnadd_Click">修改</asp:LinkButton></td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>

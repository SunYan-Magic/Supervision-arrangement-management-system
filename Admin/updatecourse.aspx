<%@ Page Language="C#" AutoEventWireup="true" CodeFile="updatecourse.aspx.cs" Inherits="Admin_updatecourse" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>修改课程</title>
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
            width: 116px;
        }
        .auto-style2 {
            width: 308px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" target="mywin">
    <div>
      <table>
            <tr>
                <td colspan="2" style="font-size:30px;">
                    修改课程</td>
            </tr>
            <tr>
                <td align="right" class="auto-style1">
                </td>
                <td class="auto-style2">
                </td>
            </tr>
          <tr>
                <td align="right" class="auto-style1">
                   ID号：</td>
                <td class="auto-style2">
                    <asp:TextBox ID="courseid" runat="server" CssClass="btb"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="courseid" Display="Dynamic"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right" class="auto-style1">
                    课程名称：</td>
                <td class="auto-style2">
                    <asp:TextBox ID="kcname" runat="server" CssClass="btb"></asp:TextBox>
                    <asp:RequiredFieldValidator
                        ID="rfvname" runat="server" ControlToValidate="kcname" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right" class="auto-style1">
                    课程编码：</td>
                <td class="auto-style2">
                    <asp:TextBox ID="kccode" runat="server" CssClass="btb"></asp:TextBox>
                    <asp:RequiredFieldValidator
                        ID="rfvcode" runat="server" Display="Dynamic" ErrorMessage="*" ControlToValidate="kccode"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="kccode"
                       Display="Dynamic" ErrorMessage="请输入正确的课程编码" ValidationExpression="^\d{8}$"></asp:RegularExpressionValidator>
                </td>
            </tr>
                  
          <tr>
               <td align="right" class="auto-style1">
                   专业编码：</td>
               <td class="auto-style2">
                   <asp:TextBox ID="bjcode" runat="server" CssClass="btb"></asp:TextBox>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="bjcode"
                       Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
                   <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="bjcode"
                       Display="Dynamic" ErrorMessage="请输入正确的专业编码" ValidationExpression="^\d{10}$"></asp:RegularExpressionValidator>
               </td>
           </tr>
          <tr>
               <td align="right" class="auto-style1">
                   授课老师编码：</td>
               <td class="auto-style2">
                   <asp:TextBox ID="kcteacher" runat="server" CssClass="btb"></asp:TextBox>
                   <asp:RequiredFieldValidator ID="rfvtea" runat="server" ControlToValidate="kcteacher"
                       Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
                   <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="kcteacher"
                       Display="Dynamic" ErrorMessage="请输入正确的老师编码" ValidationExpression="^\d{9}$"></asp:RegularExpressionValidator>
               </td>
           </tr>       
            <tr>
                <td align="right" class="auto-style1">
                </td>
                <td class="auto-style2">
                    <asp:LinkButton ID="lbtnupd" class="easyui-linkbutton" runat="server" OnClick="lbtnadd_Click">修改</asp:LinkButton></td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>

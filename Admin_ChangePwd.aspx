<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin_ChangePwd.aspx.cs" Inherits="Admin_ChangePwd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>密码管理</title>
    <link href="css/Style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td colspan="2" style="font-size:30px;">
                    修改密码</td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 100px">
                </td>
                <td style="width: 226px">
                </td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px" align="right">
                    旧 密 码：</td>
                <td style="width: 226px">
                    <asp:TextBox ID="tbpwd" runat="server" CssClass="tb" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvpwd" runat="server" ControlToValidate="tbpwd"
                        Display="Dynamic" ErrorMessage="请输入原来的密码"></asp:RequiredFieldValidator></td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px" align="right">
                    新 密 码：</td>
                <td style="width: 226px">
                    <asp:TextBox ID="tbnewpwd" runat="server" CssClass="tb" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvnew" runat="server" ControlToValidate="tbnewpwd"
                        Display="Dynamic" ErrorMessage="请输入新密码"></asp:RequiredFieldValidator></td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px" align="right">
                    确认密码：</td>
                <td style="width: 226px">
                    <asp:TextBox ID="tbrepwd" runat="server" CssClass="tb" TextMode="Password"></asp:TextBox>
                    <asp:CompareValidator ID="cvpwd" runat="server" ControlToCompare="tbnewpwd" ControlToValidate="tbrepwd"
                        Display="Dynamic" ErrorMessage="两次输入密码不相同"></asp:CompareValidator></td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
                </td>
                <td class="auto-style2">
                    <asp:LinkButton ID="Button1" class="easyui-linkbutton" runat="server" OnClick="Button1_Click">确认修改</asp:LinkButton></td>               
                <td style="width: 100px">
                </td>
            </tr>
           
            </table>

      <table >
          <tr>
                <td align="right" style="width: 100px">
                </td>
                <td style="width: 226px">
                </td>
                <td style="width: 100px">
                </td>
            </tr>
           <tr>
                <td style="width: 100px">
                </td>
                <td class="auto-style2">
                    <asp:LinkButton ID="lbtnupd" class="easyui-linkbutton" runat="server" OnClick="Button2_Click">修改老师密码</asp:LinkButton></td>               
                <td style="width: 100px">
                </td>
            </tr>
      </table>
    </div>
    </form>
</body>
</html>

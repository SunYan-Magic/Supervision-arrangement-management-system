<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SetTeacherPwd.aspx.cs" Inherits="SetTeacherPwd" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>添加班级</title>
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
            width: 165px;
            height: 30px;
        }
        .auto-style3 {
            width: 80px;
            height: 25px;
        }
        .auto-style4 {
            width: 165px;
            height: 25px;
        }
        .auto-style5 {
            width: 165px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" target="mywin">
    <div>
        <table>
             <tr>
                <td colspan="2" style="font-size:30px;">
                    修改老师密码</td>
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
                     老师编码：</td>
                <td style="width: 226px">
                    <asp:TextBox ID="lscode" runat="server" CssClass="tb"></asp:TextBox></td>  
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px" align="right">
                    新 密 码：</td>
                <td style="width: 226px">
                    <asp:TextBox ID="lspw" runat="server" CssClass="tb" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="lspw"
                        Display="Dynamic" ErrorMessage="请输入新密码"></asp:RequiredFieldValidator></td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                 <td style="width: 100px" align="right">
                    确认密码：</td>
                <td style="width: 226px">
                    <asp:TextBox ID="lspw2" runat="server" CssClass="tb" TextMode="Password"></asp:TextBox>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="lspw" ControlToValidate="lspw2"
                        Display="Dynamic" ErrorMessage="两次输入密码不相同"></asp:CompareValidator></td>
                <td style="width: 100px">
                </td>
         </tr>
            <tr>
                <td style="width: 100px">
                </td>
                <td class="auto-style2">
                    <asp:LinkButton ID="Button2" class="easyui-linkbutton" runat="server" OnClick="Button2_Click">修改</asp:LinkButton></td>               
                <td style="width: 100px">
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>


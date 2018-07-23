<%@ Page Language="C#" AutoEventWireup="true" CodeFile="admin_teachermanage.aspx.cs" 
Inherits="Admin_admin_teachermanage" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>老师管理</title>
    <link href="../css/Style.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../js/themes/default/easyui.css"/>
	<link rel="stylesheet" type="text/css" href="../js/themes/icon.css"/>
	<script type="text/javascript" src="../js/jquery-1.7.1.min.js"></script>
	<script type="text/javascript" src="../js/jquery.easyui.min.js"></script>
    <style type="text/css">
        .auto-style1 {
            width: 257px;
        }
        .auto-style4 {
            width: 355px;
        }
        .auto-style5 {
            width: 372px;
        }
        #form1 {
            height: 312px;
            width: 485px;
        }
    </style>
 </head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td colspan="2" style="font-size:30px;">
                    老师管理</td>
                <td class="auto-style1">
                </td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td class="auto-style5">
                </td>
                <td class="auto-style4">
                </td>
                <td class="auto-style1">
                </td>
                <td style="width: 100px">
                </td>
            </tr>        
             <tr>
                <td class="auto-style5">
                    老师名称：<asp:TextBox ID="lsnamesearch" runat="server" CssClass="tb"></asp:TextBox></td>
                <td class="auto-style4">
                    老师编码：<asp:TextBox ID="lscodesearch" runat="server" CssClass="tb"></asp:TextBox></td>
                <td class="auto-style1">
                    <asp:LinkButton ID="lbtnsearch" class="easyui-linkbutton" plain="true" iconCls="icon-search" runat="server" OnClick="lbtnsearch_Click">查询</asp:LinkButton></td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:LinkButton ID="lbtnadd" class="easyui-linkbutton" plain="true" iconCls="icon-add" runat="server" OnClick="lbtnadd_Click">添加</asp:LinkButton>&nbsp; 
                    <asp:LinkButton ID="lbtnupd" class="easyui-linkbutton" plain="true" iconCls="icon-edit" runat="server" OnClick="lbtnupd_Click">修改</asp:LinkButton>
                    &nbsp; &nbsp;<asp:LinkButton ID="lbtndel" class="easyui-linkbutton" plain="true" iconCls="icon-cancel" runat="server" OnClick="lbtndel_Click" OnClientClick="return confirm('确定删除选择的老师吗？')">删除</asp:LinkButton>
                    &nbsp;&nbsp;<asp:LinkButton ID="lbtnrefresh" class="easyui-linkbutton" plain="true" iconCls="icon-reload" runat="server" OnClick="lbtnrefresh_Click">刷新</asp:LinkButton>
                    &nbsp; &nbsp; &nbsp;<asp:CheckBox ID="cball" runat="server" Text="全选" AutoPostBack="True" OnCheckedChanged="cball_CheckedChanged" />
                    &nbsp;
                    <asp:CheckBox ID="cbno" runat="server" Text="反选" AutoPostBack="True" OnCheckedChanged="cbno_CheckedChanged" /></td>
            </tr>
        </table>
    
    </div>
        <asp:GridView ID="gvteacher" runat="server" AutoGenerateColumns="False" Width="400px" OnRowDataBound="gvteacher_RowDataBound"  DataKeyNames="teacherID" style="margin-right: 124px"  >
            <Columns>
                <asp:TemplateField HeaderText="选">
                    <ItemTemplate>
                        <asp:CheckBox ID="cbsel" runat="server" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="20px" />
                </asp:TemplateField>
                <asp:BoundField DataField="teacherID" HeaderText="序列号" InsertVisible="False" ReadOnly="True" SortExpression="teacherID" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                <asp:BoundField DataField="teachername" HeaderText="老师名称" SortExpression="teachername"><ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="teachercode" HeaderText="老师编码" SortExpression="teachercode"><ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                
                <asp:BoundField DataField="teachermonnum" HeaderText="teachermonnum" SortExpression="teachermonnum" Visible="False">
                </asp:BoundField>                
                <asp:BoundField DataField="teacherpw" HeaderText="teacherpw" SortExpression="teacherpw" Visible="False">
                </asp:BoundField>
                <asp:BoundField DataField="teachertel" HeaderText="老师电话" SortExpression="teachertel"><ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>                
                <asp:CheckBoxField DataField="teacherbool" HeaderText="teacherbool" SortExpression="teacherbool" Visible="False" />
                <asp:CheckBoxField DataField="teacherbool2" HeaderText="teacherbool2" SortExpression="teacherbool2" Visible="False" />               
            </Columns>
            <EmptyDataTemplate>
                还没有老师信息
            </EmptyDataTemplate>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:monitorConnectionString %>" SelectCommand="SELECT * FROM [teacher] ORDER BY [teachercode] ASC"></asp:SqlDataSource>
        <webdiyer:aspnetpager id="anpteacher" runat="server" firstpagetext="首页" horizontalalign="Left"  lastpagetext="尾页" nextpagetext="后页" pagesize="13" prevpagetext="前页" 
showpageindexbox="Always" AlwaysShowFirstLastPageNumber="True" CssClass="anpager" CurrentPageButtonClass="cpb" NumericButtonCount="3" Wrap="False" OnPageChanged="anpcatalog_PageChanged" style="margin-top:5px;" UrlPageIndexName=""></webdiyer:aspnetpager>
    </form>
</body>
</html>



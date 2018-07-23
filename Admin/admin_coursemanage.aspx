<%@ Page Language="C#" AutoEventWireup="true" CodeFile="admin_coursemanage.aspx.cs" Inherits="Admin_admin_classmanage" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>课程管理</title>
    <link href="../css/Style.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../js/themes/default/easyui.css"/>
	<link rel="stylesheet" type="text/css" href="../js/themes/icon.css"/>
	<script type="text/javascript" src="../js/jquery-1.7.1.min.js"></script>
	<script type="text/javascript" src="../js/jquery.easyui.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <table>
            <tr>
                <td colspan="2" style="font-size:30px;">
                    课程管理</td>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td style="width: 152px">
                </td>
                <td style="width: 175px">
                </td>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
               <td style="width: 175px">
                    课程名称：<asp:TextBox ID="kcnamesearch" runat="server" CssClass="tb"></asp:TextBox></td>
                <td style="width: 175px">
                    课程编码：<asp:TextBox ID="kccodesearch" runat="server" CssClass="tb"></asp:TextBox></td>
                <td style="width: 100px">
                    <asp:LinkButton ID="lbtnsearch" class="easyui-linkbutton" plain="true" iconCls="icon-search" runat="server" OnClick="lbtnsearch_Click">查询</asp:LinkButton></td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:LinkButton ID="lbtnadd" class="easyui-linkbutton" plain="true" iconCls="icon-add" runat="server" OnClick="lbtnadd_Click">添加</asp:LinkButton>&nbsp; 
                    <asp:LinkButton ID="lbtnupd" class="easyui-linkbutton" plain="true" iconCls="icon-edit" runat="server" OnClick="lbtnupd_Click">修改</asp:LinkButton>
                    &nbsp; &nbsp;<asp:LinkButton ID="lbtndel" class="easyui-linkbutton" plain="true" iconCls="icon-cancel" runat="server" OnClick="lbtndel_Click" OnClientClick="return confirm('确定删除选择的课程吗？')">删除</asp:LinkButton>
                    &nbsp;&nbsp;<asp:LinkButton ID="lbtnrefresh" class="easyui-linkbutton" plain="true" iconCls="icon-reload" runat="server" OnClick="lbtnrefresh_Click">刷新</asp:LinkButton>
                    &nbsp; &nbsp; &nbsp;<asp:CheckBox ID="cball" runat="server" Text="全选" AutoPostBack="True" OnCheckedChanged="cball_CheckedChanged" />
                    &nbsp;
                    <asp:CheckBox ID="cbno" runat="server" Text="反选" AutoPostBack="True" OnCheckedChanged="cbno_CheckedChanged" /></td>
                <td style="width: 100px">
                </td>
            </tr>
        </table>
    
    </div>
        <asp:GridView ID="gvcourse" runat="server" AutoGenerateColumns="False" Width="562px" OnRowDataBound="gvclass_RowDataBound" DataKeyNames="courseID" >
            <Columns>
                <asp:TemplateField HeaderText="选">
                    <ItemTemplate>
                        <asp:CheckBox ID="cbsel" runat="server" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="20px" />
                </asp:TemplateField>
                <asp:BoundField DataField="courseID" HeaderText="ID号" InsertVisible="False" ReadOnly="True" SortExpression="courseID"><ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                 <asp:BoundField DataField="coursename" HeaderText="课程名称" SortExpression="coursename"><ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="coursecode" HeaderText="课程编码" SortExpression="coursecode"><ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
               
                <asp:CheckBoxField DataField="coursebool" HeaderText="coursebool" SortExpression="coursebool" Visible="False" />
                
                
                <asp:BoundField DataField="classcode" HeaderText="专业编码" SortExpression="classcode"><ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                <asp:BoundField DataField="teachercode" HeaderText="授课老师编码" SortExpression="teachercode"><ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:CheckBoxField DataField="coursebool2" HeaderText="coursebool2" SortExpression="coursebool2" Visible="False" />
                <asp:BoundField DataField="classnum" HeaderText="classnum" SortExpression="classnum" Visible="False" />
                
            </Columns>
            <EmptyDataTemplate>
                还没有课程信息
            </EmptyDataTemplate>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:monitorConnectionString %>" SelectCommand="SELECT * FROM [course] ORDER BY [coursecode] ASC,[classcode] ASC"></asp:SqlDataSource>
        <webdiyer:aspnetpager id="anpcourse" runat="server" firstpagetext="首页" horizontalalign="Left"
         lastpagetext="尾页" nextpagetext="后页" pagesize="13" prevpagetext="前页" showpageindexbox="Always" AlwaysShowFirstLastPageNumber="True" CssClass="anpager" CurrentPageButtonClass="cpb" NumericButtonCount="3" Wrap="False" OnPageChanged="anpcatalog_PageChanged" style="margin-top:5px;" UrlPageIndexName=""></webdiyer:aspnetpager>
    </form>
</body>
</html>

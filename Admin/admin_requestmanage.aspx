<%@ Page Language="C#" AutoEventWireup="true" CodeFile="admin_requestmanage.aspx.cs" Inherits="Admin_admin_requestmanage" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
    <head runat="server">
    <title>预请求管理</title>
    <link href="../css/Style.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../js/themes/default/easyui.css"/>
	<link rel="stylesheet" type="text/css" href="../js/themes/icon.css"/>
	<script type="text/javascript" src="../js/jquery-1.7.1.min.js"></script>
	<script type="text/javascript" src="../js/jquery.easyui.min.js"></script>
    <style type="text/css">
        .auto-style6 {
            width: 406px;
            height: 30px;
        }
        .auto-style7 {
            width: 524px;
        }
        .auto-style14 {
            width: 406px;
            height: 54px;
        }
        .auto-style15 {
            width: 406px;
        }
        .auto-style16 {
            width: 176px;
            height: 54px;
        }
        #form1 {
            width: 527px;
        }
        .auto-style17 {
            height: 24px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table class="auto-style7">
            <tr>
                <td style="font-size:30px;" class="auto-style14">
                    预请求管理</td>
                <td class="auto-style16">
                </td>
            </tr>
        
        <tr>
                <td align="center" class="auto-style15">
                    &nbsp;&nbsp;
                    监考起始日期：<asp:Label ID="date1" runat="server" ForeColor="Black" Font-Size="14px"></asp:Label>
                    </td>
             </tr><tr>
                <td align="center" class="auto-style6">
                    &nbsp;&nbsp;
                    监考终止日期：<asp:Label ID="date2" runat="server" ForeColor="Black" Font-Size="14px"></asp:Label>
                </td>
            </tr>
       
              <tr>    <td colspan="3" class="auto-style17">
                    &nbsp;&nbsp;<asp:LinkButton ID="lbtnrefresh" class="easyui-linkbutton" plain="true" iconCls="icon-reload" runat="server" OnClick="fresh_Click">刷新</asp:LinkButton>
                     &nbsp;&nbsp;<asp:LinkButton ID="LinkButton1" class="easyui-linkbutton" plain="true" iconCls="icon-ok" runat="server" OnClick="yes_Click" OnClientClick="return confirm('确定通过所选请求吗？如果所选请求已经审核，则审核结果不再改变！')">通过</asp:LinkButton>
                     &nbsp;&nbsp;<asp:LinkButton ID="LinkButton2" class="easyui-linkbutton" plain="true" iconCls="icon-cancel" runat="server" OnClick="no_Click" OnClientClick="return confirm('确定驳回所选请求吗？如果所选请求已经审核，则审核结果不再改变！')">驳回</asp:LinkButton>
                  &nbsp; &nbsp; &nbsp;<asp:CheckBox ID="cball" runat="server" Text="全选" AutoPostBack="True" OnCheckedChanged="cball_CheckedChanged" />
                    &nbsp;
                    <asp:CheckBox ID="cbno" runat="server" Text="反选" AutoPostBack="True" OnCheckedChanged="cbno_CheckedChanged" /></td>
            </tr>
        </table>
    </div>
        <asp:GridView ID="gvrequest" runat="server" AutoGenerateColumns="False" Width="400px"  OnRowDataBound="gvrequest_RowDataBound"   style="margin-right: 124px" DataKeyNames="requestID" >
            <Columns>
                <asp:TemplateField HeaderText="选">
                    <ItemTemplate>
                        <asp:CheckBox ID="cbsel" runat="server" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="20px" />
                </asp:TemplateField>
                <asp:BoundField DataField="requestID" HeaderText="序列号" InsertVisible="False" ReadOnly="True" SortExpression="requestID"  Visible="False"><ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>                                         
                <asp:BoundField DataField="teachercode" HeaderText="老师编码" SortExpression="teachercode"><ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                   <asp:BoundField DataField="datecannot" HeaderText="不能监考日期" DataFormatString="{0:yyyy-MM-dd}" SortExpression="datecannot"><ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
              <asp:TemplateField HeaderText="请求处理状态">
                  <ItemTemplate ><%#"True".Equals(Eval("requeststate").ToString())?"等待审核":"已审核" %></ItemTemplate><ItemStyle HorizontalAlign="Center" /></asp:TemplateField>
                <asp:TemplateField HeaderText="请求处理结果">
                  <ItemTemplate ><%#"True".Equals(Eval("requeststate").ToString())?"等待审核":"True".Equals(Eval("requestresult").ToString())?"审核通过":"驳回请求" %></ItemTemplate><ItemStyle HorizontalAlign="Center" /></asp:TemplateField>          
                
            </Columns>
            <EmptyDataTemplate>
                还没有预请求管理信息
            </EmptyDataTemplate>
        </asp:GridView>
        
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:monitorConnectionString %>" SelectCommand="SELECT * FROM [request] ORDER BY [requeststate] DESC,[requestresult] DESC"></asp:SqlDataSource>
        
       <webdiyer:aspnetpager id="anprequest" runat="server" firstpagetext="首页" horizontalalign="Left"
         lastpagetext="尾页" nextpagetext="后页" pagesize="15" prevpagetext="前页" showpageindexbox="Always" AlwaysShowFirstLastPageNumber="True" CssClass="anpager" CurrentPageButtonClass="cpb" NumericButtonCount="3" Wrap="False" OnPageChanged="anpcatalog_PageChanged" style="margin-top:5px;" UrlPageIndexName=""></webdiyer:aspnetpager>
     </form>
</body>
</html>


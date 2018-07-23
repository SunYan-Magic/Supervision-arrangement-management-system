<%@ Page Language="C#" AutoEventWireup="true" CodeFile="admin_monitormanage.aspx.cs" Inherits="Admin_admin_monitormanage" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>监考安排</title>
    <link href="../css/Style.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../js/themes/default/easyui.css"/>
	<link rel="stylesheet" type="text/css" href="../js/themes/icon.css"/>
	<script type="text/javascript" src="../js/jquery-1.7.1.min.js"></script>
	<script type="text/javascript" src="../js/jquery.easyui.min.js"></script>
    <style type="text/css">
        #form1 {
            height: 467px;
        }
        .auto-style1 {
            width: 566px;
        }
        .auto-style2 {
            height: 77px;
        }
        .auto-style3 {
            width: 268px;
        }
        .auto-style4 {
            height: 77px;
            width: 268px;
        }
        .auto-style5 {
            width: 285px;
        }
        .auto-style6 {
            height: 77px;
            width: 285px;
        }
        .auto-style7 {
            height: 77px;
            width: 566px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <table style="width: 842px">
            <tr>
                <td colspan="2" style="font-size:30px;">
                    监考安排</td>
                <td class="auto-style1">
                </td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                </td>
                <td class="auto-style5">
                </td>
                <td class="auto-style1">
                </td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td colspan="3" style="font-size:15px;">
                    您好！管理员：
                     
                    <br />
                    <br />
&nbsp;&nbsp; 请最后确认您已经成功添加专业信息、考试课程信息和考场信息，并已经处理完老师们的监考请求！
                     
                    <br />
&nbsp;&nbsp; 注意：如果信息添加不完全，将得不到理想的监考结果！<br />
                    <br />
                    <tr>
                        <td class="auto-style4">
                            &nbsp;</td><td class="auto-style6">
                    <asp:Button ID="Button1" runat="server" BorderStyle="Inset" BorderWidth="1px" Height="21px" Width="155px" onclick="Button1_Click" Text="确定进行监考安排" />
                  </td><td class="auto-style7">  &nbsp;</td><td class="auto-style2">
                        &nbsp;</td>

            </tr>
            <tr>
                <td colspan="3">
                    &nbsp;&nbsp;<asp:LinkButton ID="lbtnrefresh" class="easyui-linkbutton" plain="true" iconCls="icon-reload" runat="server" OnClick="fresh_Click">刷新</asp:LinkButton>
                    &nbsp;&nbsp; &nbsp; &nbsp;<asp:LinkButton ID="LinkButton2" class="easyui-linkbutton" plain="true" iconCls="icon-cancel" runat="server" OnClick="del_Click" OnClientClick="return confirm('确定清空选择的监考安排吗？')">清空</asp:LinkButton>
                    
                    &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; <asp:LinkButton ID="LinkButton1" class="easyui-linkbutton" plain="true" iconCls="icon-down" runat="server" OnClick="download_Click">下载</asp:LinkButton>     
                         
                <td style="width: 100px">
                </td>
            </tr>
        </table>
    
    </div>
        <asp:GridView ID="gvmonitor" runat="server" AutoGenerateColumns="False" Width="842px" OnRowDataBound="gvmonitor_RowDataBound" style="margin-right: 124px"  DataKeyNames="monitorID" >
            <Columns>
               
                <asp:BoundField DataField="monitorID" HeaderText="监考序列" InsertVisible="False" ReadOnly="True" SortExpression="monitorID" Visible="False"><ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="coursecode" HeaderText="课程编码" SortExpression="coursecode"><ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="classcode" HeaderText="专业编码" SortExpression="classcode" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                <asp:BoundField DataField="roomcode" HeaderText="考场编码" SortExpression="roomcode"> <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="coursedate" HeaderText="考试日期" DataFormatString="{0:yyyy-MM-dd}" SortExpression="coursedate"><ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                 <asp:TemplateField HeaderText="当日时间段">
                  <ItemTemplate ><%#"1".Equals(Eval("dateperiod").ToString())?"9:00-11:00":"2:00-4:00" %></ItemTemplate><ItemStyle HorizontalAlign="Center" /></asp:TemplateField>    
                <asp:BoundField DataField="teachercode1" HeaderText="老师1编码" SortExpression="teachercode1"><ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="teachertel1" HeaderText="老师1电话" SortExpression="teachertel1"><ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="teachercode2" HeaderText="老师2编码" SortExpression="teachercode2"><ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="teachertel2" HeaderText="老师2电话" SortExpression="teachertel2"><ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="teachercode3" HeaderText="老师3编码" SortExpression="teachercode3"><ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="teachertel3" HeaderText="老师3电话" SortExpression="teachertel3"><ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>                
            </Columns>
            <EmptyDataTemplate>
                还没有监考安排信息
            </EmptyDataTemplate>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:monitorConnectionString %>" SelectCommand="SELECT * FROM [monitorplan] ORDER BY [coursedate] ASC,[dateperiod] ASC"></asp:SqlDataSource>
        <webdiyer:aspnetpager id="anpmonitor" runat="server" firstpagetext="首页" horizontalalign="Left"
         lastpagetext="尾页" nextpagetext="后页" pagesize="10" prevpagetext="前页" showpageindexbox="Always" AlwaysShowFirstLastPageNumber="True" CssClass="anpager" CurrentPageButtonClass="cpb" NumericButtonCount="3" Wrap="False" OnPageChanged="anpcatalog_PageChanged" style="margin-top:5px;" UrlPageIndexName=""></webdiyer:aspnetpager>
    </form>
</body>
</html>

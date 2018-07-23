<%@ Page Language="C#" AutoEventWireup="true" CodeFile="teacher_ViewMyMonitor.aspx.cs" Inherits="Teacher_teacher_ViewMyMonitor" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>监考</title>
    <link href="../css/Style.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../js/themes/default/easyui.css"/>
	<link rel="stylesheet" type="text/css" href="../js/themes/icon.css"/>
	<script type="text/javascript" src="../js/jquery-1.7.1.min.js"></script>
	<script type="text/javascript" src="../js/jquery.easyui.min.js"></script>
    <style type="text/css">
        #form1 {
            height: 467px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <table>
            <tr>
                <td colspan="2" style="font-size:30px;">
                    我的监考</td>
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
                <td colspan="3" style="font-size:15px;">
                    您好！<asp:Label ID="lsname" runat="server" ForeColor="Black" Font-Size="14px"></asp:Label>：
                    </td>

            </tr>
            <tr>
                <td colspan="3">
                    &nbsp;&nbsp;<asp:LinkButton ID="lbtnrefresh" class="easyui-linkbutton" plain="true" iconCls="icon-reload" runat="server" OnClick="fresh_Click">刷新</asp:LinkButton>
        
                   
                    &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;<asp:LinkButton ID="LinkButton1" class="easyui-linkbutton" plain="true" iconCls="icon-down" runat="server" OnClick="down_Click">下载</asp:LinkButton>
                </td>
                <td style="width: 100px">
                </td>
            </tr>
        </table>
    
    </div>
        <asp:GridView ID="gvmonitor" runat="server" AutoGenerateColumns="False" Width="562px" OnRowDataBound="gvmonitor_RowDataBound" DataKeyNames="monitorID" >
            <Columns>
                <asp:BoundField DataField="monitorID" HeaderText="序   号"  ReadOnly="True" SortExpression="monitorID" Visible="False"><ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="coursecode" HeaderText="课程编码" SortExpression="coursecode"><ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>     
                <asp:BoundField DataField="classcode" HeaderText="专业编码" SortExpression="classcode" ><ItemStyle HorizontalAlign="Center" /> </asp:BoundField>
                
                <asp:BoundField DataField="roomcode" HeaderText="考场编码" SortExpression="roomcode"><ItemStyle HorizontalAlign="Center" />               
                </asp:BoundField>
                <asp:BoundField DataField="teachercode1" HeaderText="teachercode1" SortExpression="teachercode1" Visible="False">
                </asp:BoundField>
                <asp:BoundField DataField="teachercode3" HeaderText="teachercode3" SortExpression="teachercode3" Visible="False" />
                <asp:BoundField DataField="teachercode2" HeaderText="teachercode2" SortExpression="teachercode2" Visible="False" />
                <asp:BoundField DataField="coursedate" HeaderText="监考日期" SortExpression="coursedate" DataFormatString="{0:yyyy-MM-dd}"><ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>                
                 <asp:TemplateField HeaderText="当日时间段">
                  <ItemTemplate ><%#"1".Equals(Eval("dateperiod").ToString())?"9:00-11:00":"14:00-16:00" %></ItemTemplate><ItemStyle HorizontalAlign="Center" /></asp:TemplateField>             
                                    
                <asp:BoundField DataField="teachertel1" HeaderText="teachertel1" SortExpression="teachertel1" Visible="False">
                </asp:BoundField>
                <asp:BoundField DataField="teachertel2" HeaderText="teachertel2" SortExpression="teachertel2" Visible="False" />
                <asp:BoundField DataField="teachertel3" HeaderText="teachertel3" SortExpression="teachertel3" Visible="False" />
                
            </Columns>
            <EmptyDataTemplate>
                还没有监考信息
            </EmptyDataTemplate>            
        </asp:GridView>
        
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:monitorConnectionString %>" SelectCommand="SELECT * FROM [monitorplan] ORDER BY [monitorID], [coursedate], [dateperiod]"></asp:SqlDataSource>
        <webdiyer:aspnetpager id="anprequest" runat="server" firstpagetext="首页" horizontalalign="Left"
         lastpagetext="尾页" nextpagetext="后页" pagesize="15" prevpagetext="前页" showpageindexbox="Always" AlwaysShowFirstLastPageNumber="True" CssClass="anpager" CurrentPageButtonClass="cpb" NumericButtonCount="3" Wrap="False" OnPageChanged="anpcatalog_PageChanged" style="margin-top:5px;" UrlPageIndexName=""></webdiyer:aspnetpager>
  
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="teacher_request.aspx.cs" Inherits="Teacher_teacher_request" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>监考预请求</title>
    <link href="../css/Style.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../js/themes/default/easyui.css"/>
	<link rel="stylesheet" type="text/css" href="../js/themes/icon.css"/>
	<script type="text/javascript" src="../js/jquery-1.7.1.min.js"></script>
	<script type="text/javascript" src="../js/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="My97DatePicker/WdatePicker.js"></script>
    <style type="text/css">
        #form1 {
            height: 467px;
        }
        .auto-style2 {
            width: 1008px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td colspan="8" style="font-size: 30px">我的监考预请求
                </td>
            </tr>
            <tr>
                <td colspan="3" style="font-size: 15px">
                </td>
            </tr>
            <tr>
                <td colspan="3" style="font-size:15px;">
                    您好！<asp:Label ID="llname" runat="server" ForeColor="Black" Font-Size="14px"></asp:Label>：
                    </td>

            </tr>
            <tr>
                <td align="center" class="auto-style2">
                   考试起始日期：<asp:Label ID="date1" runat="server" ForeColor="Black" Font-Size="14px"></asp:Label>
                    </td>
            </tr>
            <tr>
                <td align="center" class="auto-style2">
                    考试终止日期：<asp:Label ID="date2" runat="server" ForeColor="Black" Font-Size="14px"></asp:Label>
                </td>
            </tr>
             <tr>
                <td colspan="3" style="font-size: 15px">&nbsp;&nbsp;&nbsp; 如果您在考试安排中有不能监考日期，请提出申请，确定申请后请耐心等待审核结果。
                </td>
            </tr>
             <tr>
                <td colspan="3" style="font-size: 15px">
                    <asp:Button ID="Button1" runat="server" BorderStyle="Inset" BorderWidth="1px" Height="21px" Width="102px" onclick="Button1_Click" Text="不能监考日期" />
                    <asp:Calendar ID="Calendar1" runat="server" Visible="False" onselectionchanged="Calendar1_SelectionChanged" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="200px" Width="220px">
                        <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                        <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                        <OtherMonthDayStyle ForeColor="#999999" />
                        <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                        <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                        <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                        <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                        <WeekendDayStyle BackColor="#CCCCFF" />
                    </asp:Calendar>
                    <asp:Button  ID="Button2" runat="server" BorderStyle="Inset" BorderWidth="1px" Height="21px" Width="102px" onclick="Button2_Click" Text="确定"  />
                </td>
            </tr>
            <tr>
                <td colspan="3">
                     <asp:LinkButton ID="lbtnrefresh" class="easyui-linkbutton" plain="true" iconCls="icon-reload" runat="server" OnClick="lbtnrefresh_Click">刷新</asp:LinkButton>       
                    &nbsp; &nbsp;<asp:LinkButton ID="lbtndel" class="easyui-linkbutton" plain="true" iconCls="icon-cancel" runat="server" OnClick="lbtndel_Click" OnClientClick="return confirm('确定撤销所选请求吗？未处理请求撤销后将无该请求记录！已被处理请求撤销无效！')">撤销</asp:LinkButton>
                    &nbsp; &nbsp; &nbsp;<asp:CheckBox ID="cball" runat="server" Text="全选" AutoPostBack="True" OnCheckedChanged="cball_CheckedChanged" />
                    &nbsp;
                    <asp:CheckBox ID="cbno" runat="server" Text="反选" AutoPostBack="True" OnCheckedChanged="cbno_CheckedChanged" /></td>
                <td style="width: 100px">
                </td>
            </tr>
        </table>    
    </div>           
        <asp:GridView ID="gvrequest" runat="server" AutoGenerateColumns="False" OnRowDataBound="gvrequest_RowDataBound1"
            Width="486px" OnRowDeleting="gvrequest_RowDeleting" DataKeyNames="requestID"
             OnPageIndexChanging ="GridView_PageIndexChanging" AllowPaging="True"   >
            <Columns>
                <asp:TemplateField HeaderText="选">
                    <ItemTemplate>
                        <asp:CheckBox ID="cbsel" runat="server" />
                    </ItemTemplate>     
                    <ItemStyle HorizontalAlign="Center" Width="20px" />  </asp:TemplateField>
                <asp:BoundField DataField="requestID" HeaderText="requestID" InsertVisible="False" ReadOnly="True" SortExpression="requestID" Visible="False">
                </asp:BoundField>
                <asp:BoundField DataField="teachercode" HeaderText="teachercode" SortExpression="teachercode" Visible="False">
                </asp:BoundField>                
                <asp:BoundField DataField="datecannot" HeaderText="不能监考日期" DataFormatString="{0:yyyy-MM-dd}" SortExpression="datecannot"><ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                    <asp:TemplateField HeaderText="请求处理状态">
                  <ItemTemplate ><%#"True".Equals(Eval("requeststate").ToString())?"等待审核":"已审核" %></ItemTemplate><ItemStyle HorizontalAlign="Center" /></asp:TemplateField>
                <asp:TemplateField HeaderText="请求处理结果">
                  <ItemTemplate ><%#"True".Equals(Eval("requeststate").ToString())?"等待审核":"True".Equals(Eval("requestresult").ToString())?"审核通过":"驳回请求" %></ItemTemplate><ItemStyle HorizontalAlign="Center" /></asp:TemplateField>          
                
            </Columns>
            <EmptyDataTemplate>
                还没有不能监考日期信息
            </EmptyDataTemplate>
        </asp:GridView>      
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:monitorConnectionString %>" SelectCommand="SELECT * FROM [request] WHERE ([teachercode] = @teachercode) ">
            
        </asp:SqlDataSource>         
    </form>
</body>
</html>

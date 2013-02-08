<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SalesReturnPage.aspx.cs" Inherits="RedGlovePermission.Web.Admin.Programs.Sales.SalesReturnPage" %>

<%@ Register Assembly="SamApp.WebControls.NestableGridView" Namespace="SamApp.WebControls"
    TagPrefix="NestableGridView" %>

<%@ Register Assembly="SamApp.WebControls.SearchGridView" Namespace="SamApp.WebControls"
    TagPrefix="SearchGridView" %>

<%@ Import Namespace="RedGlove.Core.Languages" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script type="text/javascript">
    function GetProductNew(myObj) {
        var table = document.getElementById("<%=gvMaster.ClientID %>");
        for (var i = 0; i < table.rows.length; i++) {
            if (!is_null(table.rows[i].cells[0].getElementsByTagName("input")[0])) 
                if (myObj.name == table.rows[i].cells[0].getElementsByTagName("input")[0].name) 
                    break;
        };
        window.open('../../Tools/Products.aspx?TextBoxId=B' + i.toString(), '', 'height=530,width=750,status=no,toolbar=no,menubar=no,location=no', '');
    }
</script>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>
        <%=ResourceManager.GetString("SalesReturnPage_Title_name")%></title>
    <link href="../../../Inc/Style/<%=Request.Cookies["UIStyle"].Value%>/css/indexControl.css" rel="stylesheet" type="text/css" />
    <link href="../../../Inc/Style/<%=Request.Cookies["UIStyle"].Value%>/css/GridView.css" rel="stylesheet" type="text/css" />

    <script src="../../../Inc/Script/pub.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="divToolBar" class="topBar">
        <div class="toolBar">
        </div>
        <div class="moduleName">
            <%=ResourceManager.GetString("SalesReturnPage_Title_name")%></div>
    </div>
    <asp:UpdatePanel ID="CustomPanel1" runat="server">
        <ContentTemplate>
            <div id="title" class="childtoolbar">
            <div class="rowdiv" style="margin-left: 3px;">
                    <%=ResourceManager.GetString("SalesOrderPage_Lab_0_2")%>:</div>
                <div class="rowdiv">
                    <asp:DropDownList ID="CompanyList" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="CompanyList_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
            </div>
    <div>
        <div id="GridViewMsg" style="padding: 5px;" runat="server">  
            <NestableGridView:NestableGridView ID="gvMaster" runat="server" 
                AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" 
                CellPadding="4" ChildTableID="pnlChild" DataKeyNames="ReturnID" 
                DataSourceID="dsMaster" ForeColor="#333333" GridLines="None" Height="183px" 
                onaddrow="gvMaster_AddRow" onpageindexchanged="gvMaster_PageIndexChanged" 
                onprerender="gvMaster_PreRender" onrowcommand="gvMaster_RowCommand" 
                onrowediting = "gvMaster_RowEditing"
                onrowdatabound="gvMaster_RowDataBound" onrowdeleting="gvMaster_RowDeleting" 
                onrowupdated="gvMaster_RowUpdated" onrowupdating="gvMaster_RowUpdating" 
                onsearchgrid="gvMaster_SearchGrid" 
                onselectedindexchanged="gvMaster_SelectedIndexChanged" 
                onselectedindexchanging="gvMaster_SelectedIndexChanging" 
                onsorted="gvMaster_Sorted" PageSize="5" ShowAddButton="True" 
                ShowEmptyHeader="False" ShowFooter="True" Width="100%"  >
                <SearchFilters><asp:ListItem Value="MA001">客戶</asp:ListItem><asp:ListItem Value="ReturnID">單號</asp:ListItem></SearchFilters>
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField HeaderText="開閉" ShowHeader="False"><ItemTemplate>
                    <asp:ImageButton ID="imgButSel" runat="server" CausesValidation="False" 
                                CommandName="Select" ImageUrl="~/Images/noselect.gif" Text="選擇" /></ItemTemplate></asp:TemplateField>
                    <asp:TemplateField><ItemTemplate><asp:Panel ID="pnlChild" runat="server" Visible="false" Width="100%"><table width="100%"><tr><td><SearchGridView:SearchGridView ID="gvChild" runat="server" AllowPaging="True" 
                                                AllowSorting="True" AutoGenerateColumns="False" BackColor="White" 
                                                BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                                                DataKeyNames="ReturnID" DataSourceID="dsChild" GridLines="Horizontal" 
                                                onaddrow="gvChild_AddRow" onrowcommand="gvChild_RowCommand" 
                                                onrowdeleting="gvChild_RowDeleting" onrowupdated="gvChild_RowUpdated" 
                                                onrowupdating="gvChild_RowUpdating" onsearchgrid="gvChild_SearchGrid" 
                                                onrowdatabound="gvChild_RowDataBound" 
                                                PageSize="5" ShowAddButton="True" ShowEmptyHeader="False" ShowFooter="True" 
                                                Width="100%"><SearchFilters><asp:ListItem Value="MB001">產品編號</asp:ListItem></SearchFilters><FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" /><RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" /><EmptyDataRowStyle BackColor="#F7F6F3" ForeColor="#333333" /><Columns><asp:BoundField DataField="Seq" HeaderText="項次" ReadOnly="True" SortExpression="Seq" /><asp:BoundField DataField="MB001" HeaderText="產品編號" SortExpression="MB001"><ItemStyle HorizontalAlign="Left" /></asp:BoundField><asp:BoundField DataField="MB002" HeaderText="品名" ReadOnly="True" SortExpression="MB002"><ItemStyle HorizontalAlign="Left" /></asp:BoundField><asp:BoundField DataField="MB003" HeaderText="規格" ReadOnly="True" SortExpression="MB003"><ItemStyle HorizontalAlign="Left" /></asp:BoundField><asp:BoundField DataField="MB004" HeaderText="單位" ReadOnly="True" SortExpression="MB004" /><asp:BoundField DataField="Qty" HeaderText="數量" SortExpression="Qty" ><ItemStyle HorizontalAlign="Right" /></asp:BoundField><asp:BoundField DataField="UnitPrice" HeaderText="單價" SortExpression="UnitPrice" ><ItemStyle HorizontalAlign="Right" /></asp:BoundField><asp:BoundField DataField="Discount" DataFormatString="{0:P0}" HeaderText="折扣" SortExpression="Discount" ><ItemStyle HorizontalAlign="Right" /></asp:BoundField><asp:BoundField DataField="Amount" DataFormatString="{0:f2}" HeaderText="金額" ReadOnly="True" SortExpression="Amount" ><ItemStyle HorizontalAlign="Right" /></asp:BoundField><asp:CommandField ButtonType="Image" CancelImageUrl="~/Images/cancel.gif" 
                                                        EditImageUrl="~/Images/edit.gif" HeaderText="編輯" ShowEditButton="True" 
                                                        UpdateImageUrl="~/Images/update.gif"><ItemStyle HorizontalAlign="Center" /></asp:CommandField><asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/delete.gif" 
                                                        HeaderText="刪除" ShowDeleteButton="True" ShowHeader="True"><ItemStyle HorizontalAlign="Center" /></asp:CommandField></Columns><PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
<EmptyDataTemplate><table style="width:100%;">
<tr><td width="20%"><%=ResourceManager.GetString("SalesOrderPage_Lab_1_1")%></td><td width="70%"><asp:TextBox ID="tbMB001" runat="server" Height="21px" MaxLength="40" 
                                                    onclick="GetProductNew(this)" Width="98%"></asp:TextBox></td><td width="5%"></td></tr>
<tr><td width="20%"><%=ResourceManager.GetString("SalesOrderPage_Lab_1_2")%></td><td><asp:TextBox ID="tbQty" runat="server" Height="21px" MaxLength="20" Width="98%"></asp:TextBox></td><td></td></tr>
<tr><td width="20%"><%=ResourceManager.GetString("SalesOrderPage_Lab_1_4")%></td><td><asp:TextBox ID="tbUnitPrice" runat="server" Height="21px" Width="98%"></asp:TextBox></td></tr>
<tr><td width="20%"><%=ResourceManager.GetString("SalesOrderPage_Lab_1_6")%></td><td><asp:TextBox ID="tbDiscount" runat="server" Height="21px" Width="98%" >1</asp:TextBox></td><td><asp:ImageButton ID="ImageButton1" runat="server" CommandName="InsertNew" 
                                                                    ImageUrl="~/Images/update.gif" /><asp:ImageButton ID="ImageButton2" runat="server" CommandName="InsertCancel" 
                                                                    ImageUrl="~/Images/cancel.gif" /></td></tr></table></EmptyDataTemplate><SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" /><HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" /><AlternatingRowStyle BackColor="#F7F7F7" /></SearchGridView:SearchGridView></td></tr></table></asp:Panel><asp:SqlDataSource ID="dsChild" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:NorthWindCSConnectionString %>" 
                                DeleteCommand="delete Sales_Return_DTL where ReturnID=@ReturnID and Seq=@SEQM" 
                                InsertCommand="INSERT INTO Sales_Return_DTL(ReturnID, Seq, MB001, Qty, UnitPrice, Discount, Creator, Create_Date) VALUES (@ReturnID, @Seq, @MB001, @Qty, @UnitPrice, @Discount, @Creator, @Create_Date)" 
                                SelectCommand="SELECT S.ReturnID, S.Seq, S.MB001, I.MB002, I.MB003, I.MB004, S.Qty, S.UnitPrice, S.Discount, S.Qty*S.UnitPrice*S.Discount as Amount FROM Sales_Return_DTL S left join INVMB I on S.MB001=I.MB001 WHERE (S.ReturnID = @ReturnID)" 
                                UpdateCommand="UPDATE Sales_Return_DTL SET MB001 = @MB001, Qty = @Qty, UnitPrice = @UnitPrice, Discount=@Discount, MODIFIER = @MODIFIER, MODI_DATE = @MODI_DATE WHERE (ReturnID = @ReturnID and Seq = @SEQM)">
                                <SelectParameters><asp:Parameter Name="ReturnID" /></SelectParameters>
                                <DeleteParameters><asp:Parameter Name="ReturnID" /><asp:Parameter Name="SEQM" /></DeleteParameters>
                                <UpdateParameters><asp:Parameter Name="MB001" /><asp:Parameter Name="Qty" /><asp:Parameter Name="UnitPrice" /><asp:Parameter Name="Discount" /><asp:Parameter Name="MODIFIER" /><asp:Parameter Name="MODI_DATE" /><asp:Parameter Name="ReturnID" /><asp:Parameter Name="SEQM" /></UpdateParameters>
                                <InsertParameters><asp:Parameter Name="ReturnID" /><asp:Parameter Name="Seq" /><asp:Parameter Name="MB001" /><asp:Parameter Name="Qty" /><asp:Parameter Name="UnitPrice" /><asp:Parameter Name="Discount" /><asp:Parameter Name="CREATOR" /><asp:Parameter Name="CREATE_DATE" /></InsertParameters></asp:SqlDataSource>
                    <asp:HiddenField ID="_hfChildSearch" runat="server" /></ItemTemplate></asp:TemplateField>
                    <asp:CommandField ButtonType="Image" CancelImageUrl="~/Images/cancel.gif" 
                        EditImageUrl="~/Images/edit.gif" HeaderText="編輯" 
                        InsertImageUrl="~/Images/update.gif" NewImageUrl="~/Images/new.gif" 
                        ShowEditButton="True" UpdateImageUrl="~/Images/update.gif"><ItemStyle HorizontalAlign="Center" /></asp:CommandField>
                    <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/delete.gif" 
                        HeaderText="刪除" ShowDeleteButton="True" ShowHeader="True"><ItemStyle HorizontalAlign="Center" /></asp:CommandField>
                    <asp:BoundField DataField="ReturnID" HeaderText="單號" InsertVisible="False" 
                        ReadOnly="True" SortExpression="ReturnID"><ItemStyle HorizontalAlign="Left" /></asp:BoundField>
                    <asp:BoundField DataField="MA001" HeaderText="客戶" SortExpression="MA001"><ItemStyle HorizontalAlign="Left" /></asp:BoundField>
                    <asp:BoundField DataField="MA002" HeaderText="簡稱" ReadOnly="True" SortExpression="MA002"><ItemStyle HorizontalAlign="Left" /></asp:BoundField>
                    <asp:BoundField DataField="Return_Date" HeaderText="退回日期" 
                        SortExpression="Return_Date" />
                    <asp:BoundField DataField="CaseNo" HeaderText="案件編號" SortExpression="CaseNo"><ItemStyle HorizontalAlign="Left" /></asp:BoundField>
                    <asp:BoundField DataField="CaseDescription" HeaderText="案件名稱" ReadOnly="True" SortExpression="CaseDescription"><ItemStyle HorizontalAlign="Left" /></asp:BoundField>
                    <asp:TemplateField HeaderText="業務組"><ItemTemplate><asp:Label ID="Lab_Department" runat="server" Text='<%# Eval("Department") %>'></asp:Label></ItemTemplate><EditItemTemplate><asp:DropDownList ID="ddl_Department2" runat="server" Width="10em"></asp:DropDownList></EditItemTemplate><ItemStyle HorizontalAlign="Left" Wrap="False" /></asp:TemplateField>
                    <asp:TemplateField HeaderText="稅率"><ItemTemplate><asp:Label ID="Lab_TaxRate" runat="server" Text='<%# Eval("TaxRate") %>'></asp:Label></ItemTemplate><EditItemTemplate><asp:DropDownList ID="ddl_TaxRate2" runat="server" Width="10em"></asp:DropDownList></EditItemTemplate><ItemStyle HorizontalAlign="Right" Wrap="False" /></asp:TemplateField>
                    <asp:BoundField DataField="Total" HeaderText="未稅退貨金額" ReadOnly="True" SortExpression="Total"><ItemStyle HorizontalAlign="Right" /></asp:BoundField>
                    <asp:BoundField DataField="Tax" HeaderText="稅額" ReadOnly="True" SortExpression="Tax"><ItemStyle HorizontalAlign="Right" /></asp:BoundField>
                    <asp:TemplateField HeaderText="列印" ShowHeader="False"><ItemTemplate>
                    <asp:Button ID="btPrint" runat="server" Height="21px" Width="98%"></asp:Button>              
                    </ItemTemplate></asp:TemplateField>
                    <asp:BoundField DataField="Remark" HeaderText="備註" SortExpression="Remark"><ItemStyle HorizontalAlign="Left" /></asp:BoundField>
                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <EmptyDataRowStyle BackColor="#EFF3FB" />
                <EmptyDataTemplate>
                    <table style="width:50%;">
                        <tr>
                            <td>
                                <%=ResourceManager.GetString("SalesOrderPage_Lab_0_4")%>
                            </td>
                            <td>
                                <asp:TextBox ID="tbCaseNO" runat="server" Height="21px" 
                                onclick="window.open('../../Tools/Case.aspx?TextBoxId=CtbCaseNo', '','height=315,width=750,status=no,toolbar=no,menubar=no,location=no', '');"
                                    Width="98%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td width="20%">
                                <%=ResourceManager.GetString("SalesOrderPage_Lab_0_1")%>
                            </td>
                            <td width="70%">
                                <asp:TextBox ID="tbMA001" runat="server" Height="21px" MaxLength="15" 
                                onclick="window.open('../../Tools/Customers.aspx?TextBoxId=BtbMA001', '','height=550,width=750,status=no,toolbar=no,menubar=no,location=no', '');" 
                                    Width="98%"></asp:TextBox>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <%=ResourceManager.GetString("SalesReturnPage_Lab_0_3")%>
                            </td>
                            <td>
                                <asp:TextBox ID="tbReturn_Date" runat="server" Height="21px" 
                                onclick="window.open('../../Tools/Calendar.aspx?TextBoxId=CtbReturn_Date', '','height=315,width=350,status=no,toolbar=no,menubar=no,location=no', '');"
                                    Width="98%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <%=ResourceManager.GetString("SalesOrderPage_Lab_0_5")%>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddl_Department" runat="server" Width="10em" OnInit="ddl_Department_OnInit"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <%=ResourceManager.GetString("SalesOrderPage_Lab_0_6")%>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddl_TaxRate" runat="server" Width="10em" OnInit="ddl_TaxRate_OnInit"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <%=ResourceManager.GetString("SalesOrderPage_Lab_0_10")%>
                            </td>
                            <td>
                                <asp:TextBox ID="tbRemark" runat="server" Height="21px" 
                                    Width="98%"></asp:TextBox>
                            </td>
                            <td>
                                <asp:ImageButton ID="ImageButton3" runat="server" CommandName="InsertNewM" 
                                    ImageUrl="~/Images/update.gif" />
                                <asp:ImageButton ID="ImageButton4" runat="server" CommandName="InsertCancelM" 
                                    ImageUrl="~/Images/cancel.gif" />
                            </td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            </NestableGridView:NestableGridView>
        <asp:SqlDataSource ID="dsMaster" runat="server"
            ConnectionString="<%$ ConnectionStrings:NorthWindCSConnectionString %>" 
            SelectCommand="SELECT S.*,C.MA002,B.CaseDescription FROM [Sales_Return] S left join [COPMA] C on S.MA001=C.MA001 left join [Basic_Case] B on S.CaseNo=B.CaseNo where (S.Company=@Company)" 
            DeleteCommand="DELETE FROM Sales_Return WHERE (ReturnID = @ReturnID)"                   
            UpdateCommand="UPDATE Sales_Return SET MA001 = @MA001, Return_DATE = @Return_DATE, CaseNo=@CaseNo, Department=@Department, TaxRate=@TaxRate, Total=@Total, Tax=@Tax, Remark=@Remark, MODIFIER = @MODIFIER, MODI_DATE = @MODI_DATE where ReturnID = @ReturnID" 
            InsertCommand="INSERT INTO Sales_Return(ReturnID, MA001, COMPANY, Return_DATE, CaseNo, Department, TaxRate, Total, Tax, Remark, CREATOR, CREATE_DATE) VALUES (@ReturnID, @MA001, @COMPANY, @Return_DATE, @CaseNo, @Department, @TaxRate, @Total, @Tax, @Remark, @CREATOR, @CREATE_DATE)">
            <DeleteParameters>
                <asp:Parameter Name="ReturnID" />
            </DeleteParameters>
            <FilterParameters>
                <asp:ControlParameter ControlID="_hfSearch" Name="filExp" 
                    PropertyName="Value" />
            </FilterParameters>
            <SelectParameters><asp:Parameter Name="Company" /></SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="MA001" />
                <asp:Parameter Name="Return_DATE" />
                <asp:Parameter Name="CaseNo" />
                <asp:Parameter Name="Department" />
                <asp:Parameter Name="TaxRate" />
                <asp:Parameter Name="Total" />
                <asp:Parameter Name="Tax" />
                <asp:Parameter Name="Remark" />
                <asp:Parameter Name="MODIFIER" />
                <asp:Parameter Name="MODI_DATE" />
                <asp:Parameter Name="ReturnID" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="ReturnID" />
                <asp:Parameter Name="MA001" />
                <asp:Parameter Name="COMPANY" />
                <asp:Parameter Name="Return_DATE" />
                <asp:Parameter Name="CaseNo" />
                <asp:Parameter Name="Department" />
                <asp:Parameter Name="TaxRate" />
                <asp:Parameter Name="Total" />
                <asp:Parameter Name="Tax" />
                <asp:Parameter Name="Remark" />
                <asp:Parameter Name="CREATOR" />
                <asp:Parameter Name="CREATE_DATE" />
            </InsertParameters>
        </asp:SqlDataSource>
    </div>
    <asp:HiddenField ID="_hfSearch" runat="server" />
    </ContentTemplate>
    </asp:UpdatePanel>
       <script type="text/javascript">
           function is_null(obj) {
               if (typeof (obj) == 'undefined' || obj == null)
                   return true;
               return false;
           }
           function GetDate(mySelect) {
               var table = document.getElementById("<%=gvMaster.ClientID %>");
               if (!is_null(table.rows[mySelect].cells[8]))
                   if (!is_null(table.rows[mySelect].cells[8].getElementsByTagName("input")[0]))
                       window.open('../../Tools/Calendar.aspx?TextBoxId=A' + mySelect, '', 'height=315,width=350,status=no,toolbar=no,menubar=no,location=no', '');
           }
           function GetCustomer(mySelect) {
               var table = document.getElementById("<%=gvMaster.ClientID %>");
               if (!is_null(table.rows[mySelect].cells[6]))
                   if (!is_null(table.rows[mySelect].cells[6].getElementsByTagName("input")[0]))
                       window.open('../../Tools/Customers.aspx?TextBoxId=AgvMaster,6,7,' + mySelect, '', 'height=530,width=750,status=no,toolbar=no,menubar=no,location=no', '');
           }
           function GetCase(mySelect) {
               var table = document.getElementById("<%=gvMaster.ClientID %>");
               if (!is_null(table.rows[mySelect].cells[9]))
                   if (!is_null(table.rows[mySelect].cells[9].getElementsByTagName("input")[0]))
                       window.open('../../Tools/Case.aspx?TextBoxId=AgvMaster,9,10,' + mySelect, '', 'height=530,width=750,status=no,toolbar=no,menubar=no,location=no', '');
           }
           function GetProduct(mySelect, myObj) {
               if (!is_null(myObj.getElementsByTagName("input")[0])) {
                   var table = document.getElementById("<%=gvMaster.ClientID %>");
                   var arr = new Array();
                   var bingo;
                   for (var i = 0; i < table.rows.length; i++) {
                       if (!is_null(table.rows[i].cells[0].getElementsByTagName("input")[0])) {
                           arr = table.rows[i].cells[0].getElementsByTagName("input");
                           bingo = false;
                           for (var j = 0; j < arr.length; j++) {
                               if (myObj.getElementsByTagName("input")[0].name == table.rows[i].cells[0].getElementsByTagName("input")[j].name) {
                                   bingo = true;
                                   break;
                               };
                           };
                           if (bingo) break;
                       };
                   };
                   window.open('../../Tools/Products.aspx?TextBoxId=A' + i.toString() + ',' + j.toString() + ',' + mySelect, '', 'height=530,width=750,status=no,toolbar=no,menubar=no,location=no', '');
               }
           }
           function PrintOrder(mySelect) {

               sc = window.open('../../Report/Sales_ReturnRPT.aspx?TextBoxId=' + mySelect, '', 'resizable=yes,scrollbars=yes,status=no,menubar=no,toolbar=no,location=no', '');
               sc.resizeTo((screen.availWidth), (screen.availHeight));
               sc.moveTo(0, 0);
           }
  </script> 
    </form>
    </body>
</html>

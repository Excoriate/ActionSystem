<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Web.UX.ASPNetApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <p>
        <br />
        Ejemplo - Consumo desde el Backend.</p>   
    <div class="form-horizontal">
    <table class="nav-justified">
        <tr>
            <td style="width: 117px; height: 28px;"></td>
            <td style="width: 222px; height: 28px;">
                <asp:Button ID="btn_Apply" runat="server" OnClick="btn_Apply_Click" Text="Apply" Width="100%" CssClass="btn-success" />
            </td>
            <td style="width: 101px; height: 28px;"></td>
            <td style="height: 28px">
            </td>
        </tr>
        <tr>
            <td style="width: 117px">Funciones</td>
            <td style="width: 222px">
                <asp:DropDownList ID="ddl_ListFunctions" runat="server" CssClass="form-control">
                </asp:DropDownList>
            </td>
            <td style="width: 101px">&nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 117px">&nbsp;</td>
            <td style="width: 222px">
               
                <asp:Button ID="btn_ListarTodos" runat="server" OnClick="btn_ListarTodos_Click" Text="Show All" Width="100%"  CssClass="btn btn-block btn-lg"
                 />
            </td>
            <td style="width: 101px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>      </div>
    <p>
        &nbsp;</p>
    
    <p>
    </p>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div align="center">
                <asp:GridView ID="gv_Persons" runat="server" CssClass="table table-hover table-striped" GridLines="None" >
                    <AlternatingRowStyle BackColor="#CCCCCC" />
                    <FooterStyle BackColor="#CCCCCC" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#808080" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#383838" />
                    <RowStyle CssClass="cursor-pointer" />
                </asp:GridView>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btn_SaveChanges" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
    <p>
    </p>
    <p>
    </p>    
    
    <!-- ATR: Insert new Person -->
<div class="modal fade" id="modalAddNewUser" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
    <div class="modal-dialog">
        <asp:UpdatePanel ID="upModal" runat="server" ChildrenAsTriggers="True" UpdateMode="Always">
            <ContentTemplate>
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                        <h4 class="modal-title"><asp:Label ID="lblModalTitle" runat="server" Text=""></asp:Label></h4>
                    </div>
                    <div class="modal-body">   
                        <div class="form-group">    
                         <label class="control-label" >Name</label> <asp:Label ID="lbl_Name_Validation" runat="server" Text="" CssClass="label label-warning"></asp:Label>
                        <asp:TextBox ID="txt_Name" runat="server" CssClass="form-control"></asp:TextBox><br>
                            
                            <label class="control-label" >LastName</label> <asp:Label ID="lbl_LastName_Validation" runat="server" Text="" CssClass="label label-warning"></asp:Label>
                            <asp:TextBox ID="txt_LastName" runat="server" CssClass="form-control"></asp:TextBox><br>
                            <label class="control-label" >Rut Numeric.</label>  <asp:Label ID="lbl_RutNum_Validation" runat="server" Text="" CssClass="label label-warning"></asp:Label>
                            <asp:TextBox ID="txt_RutN" runat="server" CssClass="form-control"></asp:TextBox><br>
                            <label class="control-label" >Rut Div.</label>                               <asp:Label ID="lbl_RutDv_Validation" runat="server" Text="" CssClass="label label-warning"></asp:Label>
                            <asp:TextBox ID="txt_RutDV" runat="server" CssClass="form-control"></asp:TextBox><br>
                     </div>

                    </div>
                    <div class="modal-footer">   
                        <asp:LinkButton aria-hidden="true" class="btn btn-success" 
                             data-dismiss="Close" ID="btn_SaveChanges" OnClick="btn_SaveChanges_Click1"
                             runat="server" UseSubmitBehavior="false">Save Changes</asp:LinkButton>
                        
                        <button class="btn btn-info" data-dismiss="modal" aria-hidden="true">Close</button>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</div>

</asp:Content>

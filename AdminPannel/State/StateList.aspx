<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.master" AutoEventWireup="true" CodeFile="StateList.aspx.cs" Inherits="AdminPannel_State_StateList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <div class="text-center container">
        <h2 class="bg-primary" style="padding:5px">State List</h2>
    </div>
    
    <div class="container">
         <asp:GridView ID="gvStateList" runat="server" AutoGenerateColumns="false" OnRowCommand="gvStateList_RowCommand" >
             <Columns>
                 <asp:TemplateField>
                     <ItemTemplate>
                         <asp:Button runat="server" id="btnDelete" Text="Delete" class="btn btn-danger btn-sm " CommandName="DeleteRecord" CommandArgument='<%# Eval("StateID").ToString() %>' ></asp:Button>
                         <asp:HyperLink runat="server" id="btnEdit" Text="Edit" class="btn btn-warning btn-sm " CommandName="EditRecord" NavigateUrl='<%# "~/AdminPannel/State/StateAddEditList.aspx?StateID=" + Eval("StateID").ToString() %>'></asp:HyperLink>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:BoundField HeaderText="Country Name" DataField="CountryName" />
                  <asp:BoundField HeaderText="State ID" DataField="StateID" />
                 <asp:BoundField HeaderText="State Name" DataField="StateName" />
                 <asp:BoundField HeaderText="State Code" DataField="StateCode" />
             </Columns>
         </asp:GridView>
        </div>

    <div class="text-center container">
        <asp:Label ID="lblMessage" runat="server" ></asp:Label>
    </div>




    
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.master" AutoEventWireup="true" CodeFile="ContactCategoryList.aspx.cs" Inherits="AdminPannel_ContactCategory_ContactCategoryList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <div class="text-center container">
        <h2 class="bg-primary" style="padding:5px">Contact Category List</h2>
    </div>
    
    <div class="container">
         <asp:GridView ID="gvContactCategoryList" runat="server" AutoGenerateColumns="false" OnRowCommand="gvContactCategoryList_RowCommand" >
             <Columns>
                 <asp:TemplateField>
                     <ItemTemplate>
                         <asp:Button runat="server" id="btnDelete" Text="Delete" class="btn btn-danger btn-sm " CommandName="DeleteRecord" CommandArgument='<%# Eval("ContactCategoryID").ToString() %>' ></asp:Button>
                         <asp:HyperLink runat="server" id="btnEdit" Text="Edit" class="btn btn-warning btn-sm " NavigateUrl='<%# "~/AdminPannel/ContactCategory/ContactCategoryAddEditList.aspx?ContactCategoryID=" +Eval("ContactCategoryID").ToString() %>'></asp:HyperLink>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:BoundField HeaderText="Contact Category ID" DataField="ContactCategoryID" />                
                 <asp:BoundField HeaderText="Contact Category Name" DataField="ContactCategoryName" />
                 <asp:BoundField HeaderText="Creation Date" DataField="CreationDate" />
             </Columns>
         </asp:GridView>
    </div>

    <div class="text-center container">
        <asp:Label ID="lblMessage" runat="server" ></asp:Label>
    </div>


</asp:Content>


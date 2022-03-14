<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.master" AutoEventWireup="true" CodeFile="ContactList.aspx.cs" Inherits="AdminPannel_Contact_ContactList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <div class="text-center container">
        <h2 class="bg-primary" style="padding:5px">Contact List</h2>
    </div>
    
    <div class="container">
         <asp:GridView ID="gvContactList" runat="server" AutoGenerateColumns="false" OnRowCommand="gvContactList_RowCommand" >
             <Columns>
                 <asp:TemplateField>
                     <ItemTemplate>
                         <asp:Button runat="server" id="btnDelete" Text="Delete" class="btn btn-danger btn-sm " CommandName="DeleteRecord" CommandArgument='<%# Eval("ContactID").ToString() %>' ></asp:Button>
                         <asp:HyperLink runat="server" id="btnEdit" Text="Edit" class="btn btn-warning btn-sm " CommandName="EditRecord" NavigateUrl='<%# "~/AdminPannel/Contact/ContactAddEditList.aspx?ContactID=" +Eval("ContactID").ToString() %>'></asp:HyperLink>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:BoundField HeaderText="Country Name" DataField="CountryName" />
                 <asp:BoundField HeaderText="State Name" DataField="StateName" />
                 <asp:BoundField HeaderText="City Name" DataField="CityName" />
                 <asp:BoundField HeaderText="Contact Category Name" DataField="ContactCategoryName" />
                 <asp:BoundField HeaderText="Contact ID" DataField="ContactID" />
                 <asp:BoundField HeaderText="Contact Name" DataField="ContactName" />
                 <asp:BoundField HeaderText="Contact Number" DataField="ContactNo" />
                 <asp:BoundField HeaderText="E-mail ID" DataField="Email" />
                 <asp:BoundField HeaderText="Address" DataField="Address" />
                 <asp:BoundField HeaderText="Creation Date" DataField="CreationDate" />
             </Columns>
         </asp:GridView>
    </div>

    <div class="text-center container">
        <asp:Label ID="lblMessage" runat="server" ></asp:Label>
    </div>



</asp:Content>


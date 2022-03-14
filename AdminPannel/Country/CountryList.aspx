<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.master" AutoEventWireup="true" CodeFile="CountryList.aspx.cs" Inherits="AdminPannel_Country_CountryList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
     <div class="text-center container">
        <h2 class="bg-primary" style="padding:5px">Country List</h2>
    </div>
    
    <div class="container">
         <asp:GridView ID="gvCountryList" runat="server" AutoGenerateColumns="false" OnRowCommand="gvCountryList_RowCommand">
             <Columns>
                 <asp:TemplateField>
                     <ItemTemplate>
                         <asp:Button runat="server" id="btnDelete" Text="Delete" class="btn btn-danger btn-sm " CommandName="DeleteRecord" CommandArgument='<%# Eval("CountryID").ToString() %>' ></asp:Button>
                         <asp:HyperLink runat="server" id="hlEdit" Text="Edit" class="btn btn-warning btn-sm " CommandName="EditRecord" NavigateUrl='<%# "~/AdminPannel/Country/CountryAddEdit.aspx?CountryID=" + Eval("CountryID").ToString() %>'></asp:HyperLink>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:BoundField HeaderText="Country ID" DataField="CountryID" />
                 <asp:BoundField HeaderText="Country Name" DataField="CountryName" />
                 <asp:BoundField HeaderText="Creation Date" DataField="CreationDate" />
             </Columns>
         </asp:GridView>
    </div>

    <div class="text-center container">
        <asp:Label ID="lblMessage" runat="server" ></asp:Label>
    </div>
    


</asp:Content>


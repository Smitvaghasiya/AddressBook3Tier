<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.master" AutoEventWireup="true" CodeFile="CityList.aspx.cs" Inherits="AdminPannel_City_CityList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>




<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="text-center container">
        <h2 class="bg-primary" style="padding:5px">City List</h2>
    </div>
    
    <div class="container">
         <asp:GridView ID="gvCityList" runat="server" AutoGenerateColumns="false" OnRowCommand="gvCityList_RowCommand"  >
             <Columns>
                 <asp:TemplateField>
                     <ItemTemplate>
                         <asp:Button runat="server" id="btnDelete" Text="Delete" class="btn btn-danger btn-sm " CommandName="DeleteRecord" CommandArgument='<%# Eval("CityID").ToString() %>' ></asp:Button>
                         <asp:HyperLink runat="server" id="btnEdit" Text="Edit" class="btn btn-warning btn-sm " CommandName="EditRecord" NavigateUrl='<%# "~/AdminPannel/City/CityAddEditList.aspx?CityID="+ Eval("CityID").ToString() %>'></asp:HyperLink>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:BoundField HeaderText="State Name" DataField="StateName" />                
                 <asp:BoundField HeaderText="City ID" DataField="CityID" />
                 <asp:BoundField HeaderText="City Name" DataField="CityName" />
                 <asp:BoundField HeaderText="STD Code" DataField="STDCode" />
             </Columns>
         </asp:GridView>
    </div>

    <div class="text-center container">
        <asp:Label ID="lblMessage" runat="server" EnableViewState="False" ></asp:Label>
    </div>




</asp:Content>


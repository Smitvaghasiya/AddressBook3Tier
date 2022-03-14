<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.master" AutoEventWireup="true" CodeFile="ContactCategoryAddEditList.aspx.cs" Inherits="AdminPannel_ContactCategory_ContactCategoryAddEditList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="container text-center">
        <h2 class="bg-primary" style="padding:5px"><asp:Label runat="server" ID="lblAddEditMode"></asp:Label></h2>
    </div>

     <div class="container">
        <div class="row">
            <div class="">
                <table class="table table-borderless">
                    <tbody>
                        <tr>
                            <th scope="row ">
                                <asp:Label runat="server" ID="lblContactCategoryName" Text="Enter Contact Category"></asp:Label></th>
                            <td>
                                <asp:TextBox runat="server" ID="txtContactCategoryName" CssClass="form-control"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td colspan="3" class="text-center">
                                <asp:Label ID="lblErrorMessage" runat="server" EnableViewState="False"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" class="text-center">
                                <asp:Button ID="btnSubmit" Text="Submit" CssClass="btn btn-primary" runat="server" OnClick="btnSubmit_Click"></asp:Button>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>



</asp:Content>


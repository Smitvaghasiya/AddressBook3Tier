<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.master" AutoEventWireup="true" CodeFile="CountryAddEdit.aspx.cs" Inherits="AdminPannel_Country_CountryAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="text-center container">
        <h2 class="bg-info" style="padding:5px"><asp:Label runat="server" ID="lblCountryMode" EnableViewState="False"></asp:Label></h2>
    </div>


       <div class="container">
        <div class="row">
            <div class="">
                <table class="table table-borderless">
                    <tbody>
                        <tr>
                            <th scope="row ">
                                <asp:Label runat="server" ID="lblCountryName" Text="Enter Country Name"></asp:Label></th>
                            <td>
                                <asp:TextBox runat="server" ID="txtCountryName" CssClass="form-control"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <th scope="row">
                                <asp:Label runat="server" ID="lblCountryCode" Text="Enter Country Code"></asp:Label></th>
                            <td>
                                <asp:TextBox runat="server" ID="txtCountryCode" CssClass="form-control"></asp:TextBox></td>
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


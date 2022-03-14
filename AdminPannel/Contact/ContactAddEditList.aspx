<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.master" AutoEventWireup="true" CodeFile="ContactAddEditList.aspx.cs" Inherits="AdminPannel_Contact_ContactAddEditList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="container text-center">
        <h2 class="bg-primary" style="padding:5px"><asp:Label runat="server" ID="lblAddEditMode"></asp:Label></h2>
    </div>

     <div class="container">
        <div class="">
                <table class="table table-borderless">
                    <tbody>
                        <tr>
                            <th scope="row ">
                                <asp:Label runat="server" ID="lblCountryList" Text="Select Country List"></asp:Label></th>
                            <td>
                                <asp:DropDownList runat="server" ID="ddlCountry" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged"></asp:DropDownList>

                            </td>
                        </tr>
                        <tr>
                            <th scope="row ">
                                <asp:Label runat="server" ID="lblStateList" Text="Select State List"></asp:Label></th>
                            <td>
                                <asp:DropDownList runat="server" ID="ddlState" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlState_SelectedIndexChanged"></asp:DropDownList>

                            </td>
                        </tr>
                        <tr>
                            <th scope="row ">
                                <asp:Label runat="server" ID="lblCityList" Text="Select City List"></asp:Label></th>
                            <td>
                                <asp:DropDownList runat="server" ID="ddlCity" CssClass="form-control" AutoPostBack="True"></asp:DropDownList>

                            </td>
                        </tr>
                        <tr>
                            <th scope="row ">
                                <asp:Label runat="server" ID="lblContactCategory" Text="Select Contact Category List"></asp:Label></th>
                            <td>
                                <asp:DropDownList runat="server" ID="ddlContactCategory" CssClass="form-control" AutoPostBack="True"></asp:DropDownList>

                            </td>
                        </tr>
                        <tr>
                            <th scope="row">
                                <asp:Label runat="server" ID="lblContactName" Text="Enter Contact Name"></asp:Label></th>
                            <td>
                                <asp:TextBox runat="server" ID="txtContactName" CssClass="form-control"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <th scope="row">
                                <asp:Label runat="server" ID="lblContactNo" Text="Enter Contact Number"></asp:Label></th>
                            <td>
                                <asp:TextBox runat="server" ID="txtContactNo" CssClass="form-control"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <th scope="row">
                                <asp:Label runat="server" ID="lblEmail" Text="Enter Email Id"></asp:Label></th>
                            <td>
                                <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <th scope="row">
                                <asp:Label runat="server" ID="lblAddress" Text="Enter Address"></asp:Label></th>
                            <td>
                                <asp:TextBox runat="server" ID="txtAddress" CssClass="form-control"></asp:TextBox></td>
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


</asp:Content>


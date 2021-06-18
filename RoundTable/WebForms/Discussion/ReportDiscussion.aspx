<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/RoundTable_master.Master" AutoEventWireup="true" CodeBehind="ReportDiscussion.aspx.cs" Inherits="RoundTable.WebForms.Discussion.ReportDiscussion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <header
        class="relative m-5 mt-0 px-5 py-4 bg-white rounded-lg flex flex-row shadow-md h-auto transition ease-in-out duration-1000">
        <div class="relative px-0 flex flex-row flex-grow">
            <div class="flex flex-col justify-center">
                <span class="block text-4xl font-bold mb-2 font-title text-gray-700">Submit Report</span>
                <span class="block opacity-80">Please describe your concerns and we'll look into it</span>
            </div>
        </div>
    </header>
    <div
        class="mt-0 m-5 p-5 bg-white rounded-lg flex flex-row justify-between shadow-md h-auto transition ease-in-out duration-1300">
        <div
            class="flex flex-row items-center justify-start hover:bg-gray-300 text-gray-600 hover:text-gray-700 w-auto h-auto rounded-lg cursor-pointer transition ease-in-out duration-300">
            <asp:DropDownList ID="DropDownList1" runat="server" ToolTip="Select a Report Category" CssClass="h-12 w-auto sm:w-64 px-2 border-2 rounded-lg cursor-pointer hover:bg-gray-100 transition ease-in-out duration-300" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="DropDownList1" InitialValue="[Select a Report Category]" ErrorMessage="*Required" ValidationGroup="ReportDiscussion" Display="Dynamic" CssClass="text-red-600 text-sm mx-2" />
        </div>
    </div>
    <div
        class="mt-0 m-5 p-5 bg-white rounded-lg flex flex-col justify-between shadow-md h-auto transition ease-in-out duration-300">
        <div class="mb-5 relative">
            <asp:TextBox ID="TextBox1" runat="server" placeholder="Title" ToolTip="Title" Enabled="false" CssClass="overflow-auto h-12 w-full px-2 pr-12 border-2 rounded-lg cursor-pointer hover:bg-gray-100 transition ease-in-out duration-300"></asp:TextBox>
        </div>
        <div>
            <asp:TextBox ID="TextBox2" runat="server" placeholder="Text (Optional)" TextMode="MultiLine" ToolTip="Text" CssClass="overflow-auto min-h-20 h-64 w-full p-2 border-2 rounded-lg cursor-pointer hover:bg-gray-100 transition ease-in-out duration-300"></asp:TextBox>
        </div>
    </div>
    <div
        class="mt-0 m-5 p-5 bg-white rounded-lg flex flex-row justify-end shadow-md h-auto transition ease-in-out duration-300">
        <asp:Button ID="Button1" runat="server" Text="Discard" CssClass="mr-5 h-12 w-24 sm:w-40 px-2 border-2 rounded-lg cursor-pointer bg-white hover:bg-gray-100 transition ease-in-out duration-300" OnClick="Button1_Click" OnClientClick="return confirm('Are you sure to discard the current report?')" />
        <asp:Button ID="Button2" runat="server" Text="Send" CssClass="h-12 w-24 sm:w-40 px-2 border-2 rounded-lg cursor-pointer bg-gray-800 hover:bg-gray-700 text-white transition ease-in-out duration-300" OnClick="Button2_Click" ValidationGroup="ReportDiscussion" />
    </div>
</asp:Content>

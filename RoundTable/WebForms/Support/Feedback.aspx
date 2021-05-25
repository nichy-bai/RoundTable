<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/RoundTable_master.Master" AutoEventWireup="true" CodeBehind="Feedback.aspx.cs" Inherits="RoundTable.WebForms.Support.Feedback" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <header
        class="relative m-5 px-5 py-4 bg-white rounded-lg flex flex-row shadow-md h-auto dark:bg-dark-200 dark:text-gray-200 transition ease-in-out duration-1000">
        <div class="relative px-0 flex flex-row flex-grow">
            <div class="flex flex-col justify-center">
                <span class="block text-4xl font-bold mb-2 font-title text-gray-700">Send Feedback</span>
                <span class="block opacity-80">Tell us how you feel</span>
            </div>
        </div>
    </header>
    <div
        class="mt-0 m-5 p-5 bg-white rounded-lg flex flex-row justify-between shadow-md h-auto dark:bg-dark-200 dark:text-gray-200 transition ease-in-out duration-1300">
        <div
            class="flex flex-row items-center justify-start dark:bg-dark-300 hover:bg-gray-300 dark:hover:bg-dark-400 text-gray-600 dark:text-gray-200 hover:text-gray-700 dark:hover:text-gray-100 w-auto h-auto rounded-lg cursor-pointer transition ease-in-out duration-300">
            <asp:DropDownList ID="DropDownList1" runat="server" DataTextField="topicName" ToolTip="Select a Feedback Category" CssClass="h-12 w-auto sm:w-64 px-2 border-2 rounded-lg cursor-pointer hover:bg-gray-100 transition ease-in-out duration-300" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            </asp:DropDownList>
        </div>
    </div>
    <div
        class="mt-0 m-5 p-5 bg-white rounded-lg flex flex-col justify-between shadow-md h-auto dark:bg-dark-200 dark:text-gray-200 transition ease-in-out duration-300">
        <div class="mb-5 relative">
            <asp:TextBox ID="TextBox1" runat="server" placeholder="Title" ToolTip="Title" onkeyup="countChar(this)" onkeydown="countChar(this)" CssClass="overflow-auto h-12 w-full px-2 pr-12 border-2 rounded-lg cursor-pointer hover:bg-gray-100 transition ease-in-out duration-300"></asp:TextBox>
            <div class="numberOfChar absolute top-1/4 right-3 text-gray-500"></div>
        </div>
        <div>
            <asp:TextBox ID="TextBox2" runat="server" placeholder="Text (Optional)" TextMode="MultiLine" ToolTip="Text" CssClass="overflow-auto min-h-20 h-64 w-full p-2 border-2 rounded-lg cursor-pointer hover:bg-gray-100 transition ease-in-out duration-300"></asp:TextBox>
        </div>
    </div>
    <div
        class="mt-0 m-5 p-5 bg-white rounded-lg flex flex-row justify-end shadow-md h-auto dark:bg-dark-200 dark:text-gray-200 transition ease-in-out duration-300">
        <asp:Button ID="Button1" runat="server" Text="Discard" CssClass="mr-5 h-12 w-24 sm:w-40 px-2 border-2 rounded-lg cursor-pointer bg-white hover:bg-gray-100 transition ease-in-out duration-300" OnClick="Button1_Click" OnClientClick="return confirm('Are you sure to discard the current feedback?')" />
        <asp:Button ID="Button2" runat="server" Text="Send" CssClass="h-12 w-24 sm:w-40 px-2 border-2 rounded-lg cursor-pointer bg-gray-800 hover:bg-gray-700 text-white transition ease-in-out duration-300" />
    </div>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>
    <script>
        function countChar(val) {
            var len = val.value.length;
            if (len > 300) {
                val.value = val.value.substring(0, 300);
            } else {
                $('.numberOfChar').text(300 - len);
            }
        };
    </script>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/RoundTable_master.Master" AutoEventWireup="true" CodeBehind="Searchpage.aspx.cs" Inherits="RoundTable.WebForms.Search.Searchpage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="SearchStyles/jquery-ui.min.css" rel="stylesheet" />
    <script src="SearchScripts/jquery.js"></script>
    <script src="SearchScripts/jquery-ui.min.js"></script>
    <script>
        $.extend($.ui.autocomplete.prototype.options, {
            open: function (event, ui) {
                $(this).autocomplete("widget").css({
                    "width": ($(this).outerWidth() + "px")
                });
            }
        });
    </script>
    <script type="text/javascript">
        $(function () {
            $('#<%= txtSearch.ClientID %>').autocomplete({
               source: function (request, response) {
                   $.ajax({
                       url: "SearchService.asmx/searchQuery",
                       data: "{ 'keyword': '" + request.term + "' }",
                       type: "POST",
                       dataType: "json",
                       contentType: "application/json;charset=utf-8",
                       success: function (result) {
                           response(result.d);
                       },
                       error: function (result) {
                           alert('There is a problem processing your request');
                       }
                   });
               }
           });
       });
    </script>
    <header
        class="relative m-5 mt-0 px-5 py-4 bg-white rounded-lg flex flex-row shadow-md h-auto dark:bg-dark-200 dark:text-gray-200 transition ease-in-out duration-1000">
        <div class="relative px-0 flex flex-col flex-grow">
            <div class="flex flex-col justify-center">
                <span class="block text-4xl font-bold mb-2 font-title">Search</span>
                <%--<span class="block opacity-80">Search RoundTable.</span>--%>
            </div>
            <div class="flex flex-row justify-between space-x-2">
                <div class="w-4/5">
                   <%-- <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>--%>
                    <asp:TextBox ID="txtSearch" runat="server" placeholder="Search" CssClass="overflow-auto h-12 w-full px-2 pr-12 border-2 rounded-lg cursor-text hover:bg-gray-100 transition ease-in-out duration-300"></asp:TextBox>
                    <%--<ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server"
                        TargetControlID="txtSearch" 
                        ServiceMethod="SearchCustomers" 
                        EnableCaching="true" 
                        MinimumPrefixLength="1" 
                        CompletionSetCount="1" 
                        CompletionInterval="10">
                    </ajaxToolkit:AutoCompleteExtender>--%>
                </div>
                <div class="w-1/5">
                    <asp:LinkButton ID="btnSearch" runat="server" OnClick="btnSearch_Click" CssClass="flex flex-row justify-center px-4 py-2.5 text-sm capitalize text-white bg-indigo-500 hover:bg-white hover:text-indigo-500 rounded-xl border-2 border-indigo-500 transition ease-in-out duration-300">
                        <svg 
                            class="w-6 h-6" 
                            fill="none" 
                            stroke="currentColor" 
                            viewBox="0 0 24 24" 
                            xmlns="http://www.w3.org/2000/svg">
                            <path 
                                stroke-linecap="round" 
                                stroke-linejoin="round" 
                                stroke-width="2" 
                                d="M21 21l-6-6m2-5a7 7 0 11-14 0 7 7 0 0114 0z">
                            </path>
                        </svg>
                    </asp:LinkButton>
                </div>
            </div>
        </div>
    </header>
    <div
        class="mt-0 m-5 px-5 py-4 bg-white rounded-lg flex flex-row shadow-md h-auto dark:bg-dark-200 dark:text-gray-200 transition ease-in-out duration-1000">
        test
    </div>
    <asp:Label ID="lblNoResult" runat="server" Text="Tiuuu"></asp:Label>
    <asp:Repeater ID="Repeater1" runat="server">
        <ItemTemplate>
            <div
                class="mt-0 m-5 bg-white rounded-lg flex flex-col shadow-md h-auto dark:bg-dark-200 dark:text-gray-200 transition ease-in-out duration-1000">
                <asp:Label ID="lblName" runat="server" Text='<%#Eval("postTitle") %>'></asp:Label>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>

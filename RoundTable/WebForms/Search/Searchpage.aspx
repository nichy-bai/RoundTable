<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/RoundTable_master.Master" AutoEventWireup="true" CodeBehind="Searchpage.aspx.cs" Inherits="RoundTable.WebForms.Search.Searchpage" %>
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
        class="relative m-5 mt-0 px-5 py-4 bg-white rounded-lg flex flex-row shadow-md h-auto transition ease-in-out duration-1000">
        <div class="relative px-0 flex flex-col flex-grow">
            <div class="flex flex-col justify-center">
                <span class="block text-4xl font-bold mb-2 font-title">Search</span>
                <%--<span class="block opacity-80">Search RoundTable.</span>--%>
            </div>
            <div class="flex flex-row justify-between space-x-4">
                <div class="si-wrapper w-11/12">
                   <%-- <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>--%>
                    <asp:TextBox ID="txtSearch" runat="server" TextMode="Search" placeholder="Search" CssClass="speech-input overflow-auto h-12 w-full px-2 pr-12 border-2 rounded-lg cursor-text hover:bg-gray-100 transition ease-in-out duration-300"></asp:TextBox>
                    <%--<ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server"
                        TargetControlID="txtSearch" 
                        ServiceMethod="SearchCustomers" 
                        EnableCaching="true" 
                        MinimumPrefixLength="1" 
                        CompletionSetCount="1" 
                        CompletionInterval="10">
                    </ajaxToolkit:AutoCompleteExtender>--%>
                </div>
                <div class="1/12">
                    <asp:LinkButton ID="btnSearch" runat="server" OnClick="btnSearch_Click" CssClass="flex flex-row justify-center px-4 py-2.5 text-sm capitalize text-white bg-indigo-600 hover:bg-white hover:text-indigo-600 rounded-xl border-2 border-indigo-600 transition ease-in-out duration-300 shadow-2xl">
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
                <div>
                    <%--<asp:LinkButton ID="btnVoice" runat="server" CssClass="si-btn flex flex-row justify-center px-4 py-2.5 text-sm capitalize text-white bg-indigo-500 hover:bg-white hover:text-indigo-500 rounded-xl border-2 border-indigo-500 transition ease-in-out duration-300 shadow-2xl">
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
                                d="M19 11a7 7 0 01-7 7m0 0a7 7 0 01-7-7m7 7v4m0 0H8m4 0h4m-4-8a3 3 0 01-3-3V5a3 3 0 116 0v6a3 3 0 01-3 3z">
                            </path>
                        </svg>
                    </asp:LinkButton>--%>
                    <%--<button class="flex flex-row justify-center px-4 py-2.5 text-sm capitalize text-white bg-indigo-500 hover:bg-white hover:text-indigo-500 rounded-xl border-2 border-indigo-500 transition ease-in-out duration-300 shadow-2xl" id="btnVoice">
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
                                d="M19 11a7 7 0 01-7 7m0 0a7 7 0 01-7-7m7 7v4m0 0H8m4 0h4m-4-8a3 3 0 01-3-3V5a3 3 0 116 0v6a3 3 0 01-3 3z">
                            </path>
                        </svg>
                    </button>--%>
                </div>
            </div>
        </div>
    </header>
    <div
        class="mt-0 m-5 px-5 py-4 bg-white rounded-lg flex flex-col shadow-md h-auto transition ease-in-out duration-1000">
        <div class="flex flex-row items-center">
            <div class="block text-base font-bold font-title text-gray-600">Sort By</div>
            <div class="ml-2">
                <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" CssClass="h-8 w-auto px-2 border-0 rounded-lg cursor-pointer transition ease-in-out duration-300" AutoPostBack="True">
                    <asp:ListItem>Latest</asp:ListItem>
                    <asp:ListItem>Oldest</asp:ListItem>
                    <asp:ListItem>Featured</asp:ListItem>
                    <asp:ListItem>Trending</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
    </div>
    <div
        class="mt-0 m-5 px-5 py-4 bg-white rounded-lg flex flex-col shadow-md h-auto transition ease-in-out duration-1000">
        <div>
            <span class="block text-2xl font-bold mb-2 font-title">Tags</span>
        </div>
        <div class="relative flex flex-row flex-wrap justify-items-center">
            <div class="mr-4 my-2">
                <asp:Button ID="Button0" runat="server" Text="All Topics" CssClass="cursor-pointer text-white bg-indigo-600 hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded" OnClick="Button0_Click"/>
            </div>
            <div class="mr-4 my-2">
                <asp:Button ID="Button1" runat="server" Text="Computer Science" CssClass="cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded" OnClick="Button1_Click"/>
            </div>
            <div class="mr-4 my-2">
                <asp:Button ID="Button2" runat="server" Text="Social Sciences" CssClass="cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded" OnClick="Button2_Click"/>
            </div>
            <div class="mr-4 my-2">
                <asp:Button ID="Button3" runat="server" Text="Natural Science" CssClass="cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded" OnClick="Button3_Click"/>
            </div>
            <div class="mr-4 my-2">
                <asp:Button ID="Button4" runat="server" Text="Mathematics" CssClass="cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded" OnClick="Button4_Click"/>
            </div>
            <div class="mr-4 my-2">
                <asp:Button ID="Button5" runat="server" Text="Medicine & Health" CssClass="cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded" OnClick="Button5_Click"/>
            </div>
            <div class="mr-4 my-2">
                <asp:Button ID="Button6" runat="server" Text="Humanities & Arts" CssClass="cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded" OnClick="Button6_Click"/>
            </div>
            <div class="mr-4 my-2">
                <asp:Button ID="Button7" runat="server" Text="Business & Finance" CssClass="cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded" OnClick="Button7_Click"/>
            </div>
            <div class="mr-4 my-2">
                <asp:Button ID="Button8" runat="server" Text="History" CssClass="cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded" OnClick="Button8_Click"/>
            </div>
            <div class="mr-4 my-2">
                <asp:Button ID="Button9" runat="server" Text="Society & Politics" CssClass="cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded" OnClick="Button9_Click"/>
            </div>
            <div class="mr-4 my-2">
                <asp:Button ID="Button10" runat="server" Text="Literature & Language" CssClass="cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded" OnClick="Button10_Click"/>
            </div>
            <div class="mr-4 my-2">
                <asp:Button ID="Button11" runat="server" Text="Others" CssClass="cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded" OnClick="Button11_Click"/>
            </div>
        </div>
    </div>
    <div>
        <asp:Label ID="lblNoResult" runat="server" Text="" CssClass="flex justify-center items-center"></asp:Label>
    </div>
    
    <asp:Repeater ID="Repeater1" runat="server">
        <ItemTemplate>
            <div
                class="mt-0 m-5 bg-white rounded-lg flex flex-col shadow-md h-auto transition ease-in-out duration-1000">
                <asp:LinkButton ID="postBody_btn" runat="server" CssClass="flex flex-col cursor-pointer hover:shadow-md hover:text-gray-800 p-5 px-6 rounded-lg transition ease-in-out duration-500 border-r-4 border-b-4 border-transparent hover:border-gray-600" OnCommand="postBody_btn_Command" CommandArgument='<%#Eval("postID") %>' OnClientClick="window.document.forms[0].target='_blank';">
                    <div class="flex flex-row justify-start border-b-2 pb-2">
                        <%--User detail--%>
                        <div>
                            <div class="flex flex-row items-center">
                                <asp:Image ID="post_user_img" runat="server" ImageUrl='<%#Eval("profilePicture").ToString().Length > 0 ? Eval("profilePicture") : "~/ProfileImages/Default.png" %>' CssClass="w-12 h-12 rounded-full" />
                                <div class="flex flex-col px-4 justify-start items-start">
                                    <div class="font-medium">
                                        <abbr title="<%#Eval("name") %>" style="text-decoration: none;"><%#Eval("userID") %></abbr>
                                    </div>
                                    <div class="text-sm opacity-80 no-underline">
                                        <abbr title="<%#DataBinder.Eval(Container.DataItem, "postDate", "{0:dddd, dd/MM/yyyy h:mm:ss tt}") %>" style="text-decoration: none;"><%#DataBinder.Eval(Container.DataItem, "postDate", "{0:d MMMM yyyy}") %></abbr>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <%--Discussion title--%>
                    <div class="my-5 break-words" style="max-width: 100vh;">
                        <asp:Label ID="postID_lbl" runat="server" Text='<%#Eval("postID") %>' Visible="false"></asp:Label>
                        <asp:Label ID="postTitle_lbl" runat="server" Text='<%#Eval("postTitle") %>' CssClass="text-xl font-medium py-2"></asp:Label>
                    </div>
                    <%--Discussion tag--%>
                    <div class="flex flex-row my-2 items-center">
                        <asp:Label ID="topic_lbl" runat="server" ToolTip='<%#Eval("topicDesc") %>' CssClass="mr-5">
                        <div class="flex flex-row justify-center items-center text-sm md:text-md border-2 rounded-lg bg-gray-100 px-2 py-1">
                            <div class="mr-1">#</div>
                            <div>
                                <%#Eval("topicName") %>
                            </div>
                        </div>
                        </asp:Label>
                        <asp:Label ID="tag_lbl" runat="server" ToolTip='<%#Eval("tagDesc") %>'>
                        <div class="flex flex-row justify-center items-center text-sm md:text-md border-2 rounded-lg bg-gray-100 px-2 py-1">
                            <div class="mr-1">#</div>
                            <div>
                                <%#Eval("tagName") %>
                            </div>
                        </div>
                        </asp:Label>
                    </div>
                    <%--Reaction--%>
                    <div class="flex flex-row items-center flex-wrap">
                        <%--Like--%>
                        <div class="mr-5 mt-4">
                            <div class="flex flex-row justify-start items-center">
                                <svg
                                    class="w-6 h-6"
                                    fill="none"
                                    stroke="currentColor"
                                    viewBox="0 0 24 24"
                                    xmlns="http://www.w3.org/2000/svg">
                                    <path
                                        stroke-linecap="round"
                                        stroke-linejoin="round"
                                        stroke-width="1.5"
                                        d="M4.318 6.318a4.5 4.5 0 000 6.364L12 20.364l7.682-7.682a4.5 4.5 0 00-6.364-6.364L12 7.636l-1.318-1.318a4.5 4.5 0 00-6.364 0z">
                                    </path>
                                </svg>
                                <div class="px-1"><%#Eval("totalLike") %></div>
                            </div>
                        </div>
                        <%--Comment--%>
                        <div class="mr-5 mt-4">
                            <div class="flex flex-row justify-start items-center">
                                <svg
                                    class="w-6 h-6"
                                    fill="none"
                                    stroke="currentColor"
                                    viewBox="0 0 24 24"
                                    xmlns="http://www.w3.org/2000/svg">
                                    <path
                                        stroke-linecap="round"
                                        stroke-linejoin="round"
                                        stroke-width="1.5"
                                        d="M17 8h2a2 2 0 012 2v6a2 2 0 01-2 2h-2v4l-4-4H9a1.994 1.994 0 01-1.414-.586m0 0L11 14h4a2 2 0 002-2V6a2 2 0 00-2-2H5a2 2 0 00-2 2v6a2 2 0 002 2h2v4l.586-.586z">
                                    </path>
                                </svg>
                                <div class="px-1"><%#Eval("totalComment") %></div>
                            </div>
                        </div>
                        <%--Bookmark--%>
                        <div class="mr-5 mt-4">
                            <div class="flex flex-row justify-start items-center">
                                <svg
                                    class="w-6 h-6"
                                    fill="none"
                                    stroke="currentColor"
                                    viewBox="0 0 24 24"
                                    xmlns="http://www.w3.org/2000/svg">
                                    <path
                                        stroke-linecap="round"
                                        stroke-linejoin="round"
                                        stroke-width="1.5"
                                        d="M5 5a2 2 0 012-2h10a2 2 0 012 2v16l-7-3.5L5 21V5z">
                                    </path>
                                </svg>
                                <div class="px-1"><%#Eval("totalBookmark") %></div>
                            </div>
                        </div>
                        <%--View--%>
                        <div class="mr-5 mt-4">
                            <div class="flex flex-row justify-start items-center">
                                <svg
                                    class="w-6 h-6"
                                    fill="none"
                                    stroke="currentColor"
                                    viewBox="0 0 24 24"
                                    xmlns="http://www.w3.org/2000/svg">
                                    <path
                                        stroke-linecap="round"
                                        stroke-linejoin="round"
                                        stroke-width="1.5"
                                        d="M15 12a3 3 0 11-6 0 3 3 0 016 0z">
                                    </path>
                                    <path
                                        stroke-linecap="round"
                                        stroke-linejoin="round"
                                        stroke-width="1.5"
                                        d="M2.458 12C3.732 7.943 7.523 5 12 5c4.478 0 8.268 2.943 9.542 7-1.274 4.057-5.064 7-9.542 7-4.477 0-8.268-2.943-9.542-7z">
                                    </path>
                                </svg>
                                <div class="px-1"><%#Eval("totalView") %></div>
                            </div>
                        </div>
                    </div>
                </asp:LinkButton>
            </div>
        </ItemTemplate>
    </asp:Repeater>
    <link href="SearchStyles/speech-input.css" rel="stylesheet" />
    <script src="SearchScripts/speech-input.js"></script>
    <script async="" defer="" src="https://buttons.github.io/buttons.js"></script>
</asp:Content>

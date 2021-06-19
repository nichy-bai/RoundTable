<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/RoundTable_master.Master" AutoEventWireup="true" CodeBehind="Bookmark.aspx.cs" Inherits="RoundTable.WebForms.Bookmark.Bookmark" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .customize-scrollbar::-webkit-scrollbar {
            width: 2px;
        }

        .customize-scrollbar::-webkit-scrollbar-thumb {
            background-color: #E5E7EB;
        }

            .customize-scrollbar::-webkit-scrollbar-thumb:hover {
                background-color: #9CA3AF;
            }
    </style>
    <header
        class="relative m-5 mt-0 px-5 py-4 bg-white rounded-lg flex flex-row shadow-md h-auto transition ease-in-out duration-1000">
        <div class="relative px-0 flex flex-row flex-grow">
            <div class="flex flex-col justify-center">
                <span class="block text-4xl font-bold mb-2 font-title text-gray-700">Bookmark</span>
                <span class="block opacity-80">Access your saved discussion posts</span>
            </div>
        </div>
        <div class="flex flex-row items-center ml-4">
            <asp:LinkButton ID="remove_bookmark_btn" runat="server" ToolTip="Remove all your bookmarks" CssClass="w-auto flex flex-row justify-center items-center p-3 bg-gray-700 rounded-lg text-gray-100 hover:shadow-md hover:bg-gray-600 ease-in-out duration-300" OnCommand="remove_bookmark_btn_Command" OnClientClick="return confirm('Are you sure to remove all bookmarks?')">
                <svg
                    class="w-8 h-8"
                    fill="none"
                    stroke="currentColor"
                    viewBox="0 0 24 24"
                    xmlns="http://www.w3.org/2000/svg">
                    <path
                        stroke-linecap="round"
                        stroke-linejoin="round"
                        stroke-width="1.5"
                        d="M 9 14 l 6 -6 M 5 5 a 2 2 0 0 1 2 -2 h 10 a 2 2 0 0 1 2 2 v 16 l -7 -3.5 L 5 21 V 5 z M 9 8 L 15 14">
                    </path>
                </svg>
                <span class="ml-2 hidden sm:inline font-title">Clear All</span>
            </asp:LinkButton>
        </div>
    </header>

    <%--View bookmark--%>
    <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
        <ItemTemplate>
            <asp:Panel ID="post_panel" runat="server" CssClass="mt-0 m-5 bg-white rounded-lg flex flex-col shadow-md h-auto transition ease-in-out duration-1000">
                <asp:LinkButton ID="bookmarkBody_btn" runat="server" CssClass="flex flex-col cursor-pointer hover:shadow-md hover:text-gray-800 p-5 px-6 rounded-lg transition ease-in-out duration-500 border-r-4 border-b-4 border-transparent hover:border-gray-600" OnCommand="bookmarkBody_btn_Command" CommandArgument='<%#Eval("postID") %>' OnClientClick="window.document.forms[0].target='_blank';">
                    <asp:Panel ID="user_detail_panel" runat="server" CssClass="flex flex-row justify-start border-b-2 pb-2 mb-5">
                        <%--User detail--%>
                        <div>
                            <div class="flex flex-row">
                                <svg
                                    class="w-12 h-12"
                                    fill="none"
                                    stroke="currentColor"
                                    viewBox="0 0 24 24"
                                    xmlns="http://www.w3.org/2000/svg">
                                    <path
                                        stroke-linecap="round"
                                        stroke-linejoin="round"
                                        stroke-width="1"
                                        d="M5.121 17.804A13.937 13.937 0 0112 16c2.5 0 4.847.655 6.879 1.804M15 10a3 3 0 11-6 0 3 3 0 016 0zm6 2a9 9 0 11-18 0 9 9 0 0118 0z">
                                    </path>
                                </svg>
                                <div class="flex flex-col px-4 justify-start items-start">
                                    <div class="font-medium">
                                        <abbr title="<%#Eval("name") %>" style="text-decoration: none;"><%#Eval("postUserID") %></abbr>
                                    </div>
                                    <div class="flex flex-wrap text-sm text-gray-600">
                                        <abbr class="mr-2" title="<%#DataBinder.Eval(Container.DataItem, "postDate", "{0:dddd, dd/MM/yyyy h:mm:ss tt}") %>" style="text-decoration: none;"><%#DataBinder.Eval(Container.DataItem, "postDate", "{0:d MMMM yyyy}") %></abbr>
                                        <asp:Label ID="edit_date_lbl" runat="server" CssClass="no-underline" Visible='<%# DataBinder.Eval(Container.DataItem, "editDate", "{0:dddd, dd/MM/yyyy h:mm:ss tt}").ToString().Length > 0 ? true : false %>' ToolTip='<%# "Edited on " + DataBinder.Eval(Container.DataItem, "editDate", "{0:dddd, dd/MM/yyyy h:mm:ss tt}") %>' Text='<%# "(Edited on " + DataBinder.Eval(Container.DataItem, "editDate", "{0:d MMMM yyyy}") + ")" %>'></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </asp:Panel>

                    <%--Discussion title--%>
                    <div class="mb-5">
                        <asp:Label ID="postTitle_lbl" runat="server" Text='<%#Eval("postTitle") %>' CssClass="text-xl font-medium py-2"></asp:Label>
                    </div>

                    <%--Compact layout's user detail--%>
                    <asp:Panel ID="compact_user_panel" runat="server" Visible="false" CssClass="flex flex-row flex-wrap text-sm text-gray-600 mb-2">
                        <span>—&nbsp;</span>
                        <abbr title="<%#Eval("name") %>" style="text-decoration: none;"><%#Eval("postUserID") %></abbr>
                        <span>&nbsp;@&nbsp;</span>
                        <abbr class="mr-2" title="<%#DataBinder.Eval(Container.DataItem, "postDate", "{0:dddd, dd/MM/yyyy h:mm:ss tt}") %>" style="text-decoration: none;"><%#DataBinder.Eval(Container.DataItem, "postDate", "{0:d MMMM yyyy}") %></abbr>
                        <asp:Label ID="Label1" runat="server" CssClass="no-underline" Visible='<%# DataBinder.Eval(Container.DataItem, "editDate", "{0:dddd, dd/MM/yyyy h:mm:ss tt}").ToString().Length > 0 ? true : false %>' ToolTip='<%# "Edited on " + DataBinder.Eval(Container.DataItem, "editDate", "{0:dddd, dd/MM/yyyy h:mm:ss tt}") %>' Text='<%# "(Edited on " + DataBinder.Eval(Container.DataItem, "editDate", "{0:d MMMM yyyy}") + ")" %>'></asp:Label>
                    </asp:Panel>

                    <%--Cozy layout's post content--%>
                    <asp:Panel ID="cozy_content_panel" runat="server" Visible="false" CssClass="flex flex-row flex-wrap mb-2">
                        <asp:Label ID="postContent_lbl" runat="server" Text='<%#Eval("postContent").ToString().Length > 0 ? Eval("postContent") : "(No Content)"%>' CssClass="text-gray-700 py-2 w-full h-auto max-h-40 overflow-y-auto hover:border-gray-200 border-t-2 border-b-2 border-transparent transition ease-in-out duration-500 customize-scrollbar"></asp:Label>
                    </asp:Panel>

                    <%--Discussion tag--%>
                    <asp:Panel ID="tag_panel" runat="server" CssClass="flex flex-row my-2 items-center">
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
                    </asp:Panel>

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
            </asp:Panel>
        </ItemTemplate>
        <FooterTemplate>
            <div class="flex flex-col justify-center items-center mx-5">
                <asp:Panel ID="noBookmark_panel" runat="server" Visible="false" CssClass="text-gray-500 mt-5 mb-2 md:mt-10">
                    <svg
                        class="w-12 h-12 md:w-14 md:h-14"
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
                </asp:Panel>
                <asp:Label ID="noBookmark_lbl" runat="server" CssClass="text-gray-500 text-xl text-center font-medium mb-2" Text="You haven't bookmarked anything on RoundTable yet" Visible="false"></asp:Label>
                <asp:Label ID="noBookmark_lbl_2" runat="server" CssClass="text-gray-500 text-center mb-5" Text="Posts you bookmark will appear here" Visible="false"></asp:Label>
                <asp:LinkButton ID="homepage_btn" runat="server" Text="Go to homepage" CssClass="text-sm font-medium px-4 py-2 mb-0 md:mb-8 border-2 border-indigo-600 text-indigo-600 rounded-lg w-auto hover:bg-indigo-600 hover:text-white transition ease-in-out duration-300" OnCommand="homepage_btn_Command" Visible="false"></asp:LinkButton>
                <asp:Label ID="footer_lbl" runat="server" CssClass="invisible text-gray-400 text-center mt-5" Text="There are no more bookmarks to show."></asp:Label>
            </div>
        </FooterTemplate>
    </asp:Repeater>

    <%--Recommend post--%>
    <asp:Label ID="recommend_lbl" runat="server" CssClass="text-gray-500 text-center pt-10 pb-4 mx-5 border-t-2" Text="Recommended discussion post" Visible="false"></asp:Label>

    <asp:Panel ID="recommend_panel" runat="server" Visible="false" CssClass="mt-0 m-5 bg-white rounded-lg flex flex-col shadow-md h-auto transition ease-in-out duration-1000">
        <asp:LinkButton ID="recommendBody_btn" runat="server" CssClass="flex flex-col cursor-pointer hover:shadow-md hover:text-gray-800 p-5 px-6 rounded-lg transition ease-in-out duration-500 border-r-4 border-b-4 border-transparent hover:border-gray-600" OnCommand="recommendBody_btn_Command">
            <asp:Panel ID="recommend_user_detail_panel" runat="server" CssClass="flex flex-row justify-start border-b-2 pb-2 mb-5">
                <%--User detail--%>
                <div>
                    <div class="flex flex-row">
                        <svg
                            class="w-12 h-12"
                            fill="none"
                            stroke="currentColor"
                            viewBox="0 0 24 24"
                            xmlns="http://www.w3.org/2000/svg">
                            <path
                                stroke-linecap="round"
                                stroke-linejoin="round"
                                stroke-width="1"
                                d="M5.121 17.804A13.937 13.937 0 0112 16c2.5 0 4.847.655 6.879 1.804M15 10a3 3 0 11-6 0 3 3 0 016 0zm6 2a9 9 0 11-18 0 9 9 0 0118 0z">
                            </path>
                        </svg>
                        <div class="flex flex-col px-4 justify-start items-start">
                            <div class="font-medium">
                                <asp:Label ID="recommend_username_lbl" runat="server" CssClass="no-underline"></asp:Label>
                            </div>
                            <div class="flex flex-wrap text-sm text-gray-600">
                                <asp:Label ID="recommend_date_lbl" runat="server" CssClass="no-underline"></asp:Label>
                                <asp:Label ID="recommend_edit_date_lbl" runat="server" CssClass="no-underline"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>

            <%--Discussion title--%>
            <div class="mb-5">
                <asp:Label ID="recommend_postID_lbl" runat="server" Visible="false"></asp:Label>
                <asp:Label ID="recommend_postTitle_lbl" runat="server" CssClass="text-xl font-medium py-2"></asp:Label>
            </div>

            <%--Discussion tag--%>
            <asp:Panel ID="recommend_tag_panel" runat="server" CssClass="flex flex-row my-2 items-center">
                <asp:Label ID="recommend_topic_lbl" runat="server" CssClass="mr-5">
                    <div class="flex flex-row justify-center items-center text-sm md:text-md border-2 rounded-lg bg-gray-100 px-2 py-1">
                        <div class="mr-1">#</div>
                        <asp:Label ID="recommend_topic_name" runat="server"></asp:Label>
                    </div>
                </asp:Label>
                <asp:Label ID="tag_lbl" runat="server">
                    <div class="flex flex-row justify-center items-center text-sm md:text-md border-2 rounded-lg bg-gray-100 px-2 py-1">
                        <div class="mr-1">#</div>
                        <asp:Label ID="recommend_tag_name" runat="server"></asp:Label>
                    </div>
                </asp:Label>
            </asp:Panel>

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
                        <asp:Label ID="recommend_like_lbl" runat="server" CssClass="px-1"></asp:Label>
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
                        <asp:Label ID="recommend_comment_lbl" runat="server" CssClass="px-1"></asp:Label>
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
                        <asp:Label ID="recommend_bookmark_lbl" runat="server" CssClass="px-1"></asp:Label>
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
                        <asp:Label ID="recommend_view_lbl" runat="server" CssClass="px-1"></asp:Label>
                    </div>
                </div>
            </div>
        </asp:LinkButton>
    </asp:Panel>
</asp:Content>

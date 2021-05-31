<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/RoundTable_master.Master" AutoEventWireup="true" CodeBehind="DiscussionPost.aspx.cs" Inherits="RoundTable.WebForms.Discussion.DiscussionPost" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div
        class="mt-0 m-5 p-5 px-6 bg-white rounded-lg flex flex-col shadow-md h-auto dark:bg-dark-200 dark:text-gray-200 transition ease-in-out duration-1000">
        <div class="flex flex-row justify-between border-b-2 pb-2">
            <%--User detail--%>
            <div>
                <a href="#" class="flex flex-row hover:underline transition ease-in-out duration-300">
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
                            <asp:Label ID="userID_lbl" runat="server" Text="[userID]"></asp:Label>
                        </div>
                        <div class="text-sm opacity-80 no-underline">
                            <asp:Label ID="postDate_lbl" runat="server" Text="[postDate]"></asp:Label>
                        </div>
                    </div>
                </a>
            </div>
            <%--Three dots--%>
            <div class="flex flex-row justify-center items-center dropbtn relative">
                <a href="#" class="hover:text-indigo-600 transition ease-in-out duration-300" onclick="postDropdown()">
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
                            d="M12 5v.01M12 12v.01M12 19v.01M12 6a1 1 0 110-2 1 1 0 010 2zm0 7a1 1 0 110-2 1 1 0 010 2zm0 7a1 1 0 110-2 1 1 0 010 2z">
                        </path>
                    </svg>
                </a>
                <%--Dropdown--%>
                <div id="post-dropdown" class="dropdown-content hidden flex flex-col absolute top-10 right-0 w-48 bg-white border-2 rounded-xl">
                    <div>
                        <asp:LinkButton runat="server" ID="dropbtn1" Text="Share Bookmark" CssClass="flex flex-row px-4 py-3 text-sm capitalize text-gray-700 hover:bg-indigo-500 hover:text-white rounded-xl transition ease-in-out duration-300">
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
                                            d="M8.684 13.342C8.886 12.938 9 12.482 9 12c0-.482-.114-.938-.316-1.342m0 2.684a3 3 0 110-2.684m0 2.684l6.632 3.316m-6.632-6l6.632-3.316m0 0a3 3 0 105.367-2.684 3 3 0 00-5.367 2.684zm0 9.316a3 3 0 105.368 2.684 3 3 0 00-5.368-2.684z">
                                        </path>
                                    </svg>
                                    <span class="pl-2">Share Bookmark</span>
                        </asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
        <%--Discussion title--%>
        <div class="my-5">
            <asp:Label ID="postTitle_lbl" runat="server" Text="[postTitle]" CssClass="text-xl font-medium py-2"></asp:Label>
        </div>
        <%--Discussion content--%>
        <div class="mb-5">
            <asp:Label ID="postContent_lbl" runat="server" Text="[postContent]" CssClass="text-md py-2"></asp:Label>
        </div>
        <%--Discussion tag--%>
        <div class="flex flex-row mb-10">
            <a href="#" class="mr-5">
                <div class="text-sm md:text-md border-2 rounded-lg bg-gray-100 px-2 py-1 hover:bg-white transition ease-in-out duration-300">
                    <asp:Label ID="topicName_lbl" runat="server" Text="[#topicName]"></asp:Label>
                </div>
            </a>
            <a href="#" class="mr-5">
                <div class="text-sm md:text-md border-2 rounded-lg bg-gray-100 px-2 py-1 hover:bg-white transition ease-in-out duration-300">
                    <asp:Label ID="tagName_lbl" runat="server" Text="[#tagName]"></asp:Label>
                </div>
            </a>
        </div>
        <%--Reaction--%>
        <div class="flex flex-row items-center">
            <%--Like--%>
            <div class="mr-5">
                <a href="#" class="flex flex-row justify-start items-center hover:text-indigo-600 transition ease-in-out duration-300" title="Like">
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
                    <div class="px-1"><asp:Label ID="postLike_lbl" runat="server" Text="[postLike]"></asp:Label></div>
                </a>
            </div>
            <%--Comment--%>
            <div class="mr-5">
                <a href="#" class="flex flex-row justify-start items-center hover:text-indigo-600 transition ease-in-out duration-300" title="Comment">
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
                    <div class="px-1"><asp:Label ID="postComment_lbl" runat="server" Text="[postComment]"></asp:Label></div>
                </a>
            </div>
            <%--Bookmark--%>
            <div class="mr-5">
                <a href="#" class="flex flex-row justify-start items-center hover:text-indigo-600 transition ease-in-out duration-300" title="Bookmark">
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
                </a>
            </div>
        </div>
    </div>

    <%--Add comment--%>
    <div
        class="relative m-5 mt-0 px-5 py-4 bg-white rounded-lg flex flex-row shadow-md h-auto dark:bg-dark-200 dark:text-gray-200 transition ease-in-out duration-1000">
        <div class="flex flex-row flex-grow justify-between items-start">
            <div class="flex-grow">
                <asp:TextBox ID="comment_txt" runat="server" placeholder="Comment" ToolTip="Comment" TextMode="MultiLine" CssClass="h-14 w-full px-2 py-3 border-2 rounded-lg cursor-pointer hover:bg-gray-100 transition ease-in-out duration-300"></asp:TextBox>
            </div>
            <div class="ml-5">
                <asp:LinkButton ID="comment_btn" runat="server" CssClass="w-auto flex flex-row justify-center items-center p-3 bg-gray-700 rounded-lg text-gray-100 hover:shadow-md hover:bg-gray-600 dark:bg-dark-300 dark:hover:bg-dark-400 ease-in-out duration-300">
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
                        d="M8 10h.01M12 10h.01M16 10h.01M9 16H5a2 2 0 01-2-2V6a2 2 0 012-2h14a2 2 0 012 2v8a2 2 0 01-2 2h-5l-5 5v-5z">
                    </path>
                </svg>
                <span class="ml-2 hidden sm:inline font-title">Comment</span>
                </asp:LinkButton>
            </div>
        </div>
    </div>

    <%--View comment--%>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT DiscussionComment.commentID, DiscussionComment.commentContent, DiscussionComment.commentDate, DiscussionComment.postID, DiscussionComment.userID, [User].name, [User].profilePicture FROM DiscussionComment INNER JOIN [User] ON DiscussionComment.userID = [User].userID WHERE (DiscussionComment.postID = @postID) ORDER BY DiscussionComment.commentDate ASC"></asp:SqlDataSource>

    <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1" OnItemDataBound="Repeater1_ItemDataBound">
        <ItemTemplate>
            <div
                class="mt-0 m-5 p-5 px-6 bg-white rounded-lg flex flex-col shadow-md h-auto dark:bg-dark-200 dark:text-gray-200 transition ease-in-out duration-1000">
                <div class="flex flex-row justify-between border-b-2 pb-2">
                    <%--User detail--%>
                    <div>
                        <a href="#" class="flex flex-row hover:underline transition ease-in-out duration-300">
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
                                    <abbr title="<%#Eval("name") %>" style="text-decoration: none;"><%#Eval("userID") %></abbr>
                                </div>
                                <div class="text-sm opacity-80 no-underline">
                                    <abbr title="<%#DataBinder.Eval(Container.DataItem, "commentDate", "{0:dddd, dd/MM/yyyy h:mm:ss tt}") %>" style="text-decoration: none;"><%#DataBinder.Eval(Container.DataItem, "commentDate", "{0:d MMMM yyyy}") %></abbr>
                                </div>
                            </div>
                        </a>
                    </div>
                    <%--Three dots--%>
                    <div class="flex flex-row justify-center items-center dropbtn relative">
                        <a href="#" class="hover:text-indigo-600 transition ease-in-out duration-300" onclick="postDropdown()">
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
                                    d="M12 5v.01M12 12v.01M12 19v.01M12 6a1 1 0 110-2 1 1 0 010 2zm0 7a1 1 0 110-2 1 1 0 010 2zm0 7a1 1 0 110-2 1 1 0 010 2z">
                                </path>
                            </svg>
                        </a>
                        <%--Dropdown--%>
                        <div id="post-dropdown" class="dropdown-content hidden flex flex-col absolute top-10 right-0 w-48 bg-white border-2 rounded-xl">
                            <div>
                                <asp:LinkButton runat="server" ID="dropbtn1" Text="Share Bookmark" CssClass="flex flex-row px-4 py-3 text-sm capitalize text-gray-700 hover:bg-indigo-500 hover:text-white rounded-xl transition ease-in-out duration-300">
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
                                            d="M8.684 13.342C8.886 12.938 9 12.482 9 12c0-.482-.114-.938-.316-1.342m0 2.684a3 3 0 110-2.684m0 2.684l6.632 3.316m-6.632-6l6.632-3.316m0 0a3 3 0 105.367-2.684 3 3 0 00-5.367 2.684zm0 9.316a3 3 0 105.368 2.684 3 3 0 00-5.368-2.684z">
                                        </path>
                                    </svg>
                                    <span class="pl-2">Share Bookmark</span>
                                </asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
                <%--Discussion comment--%>
                <div class="my-5">
                    <div class="px-1"><%#Eval("commentContent") %></div>
                </div>
            </div>
        </ItemTemplate>
        <FooterTemplate>
            <asp:Label ID="noComment_lbl" runat="server" CssClass="text-gray-400 text-center mt-10 mb-14" Text="No comment yet" Visible="false"></asp:Label>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>

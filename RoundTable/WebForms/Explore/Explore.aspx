<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/RoundTable_master.Master" AutoEventWireup="true" CodeBehind="Explore.aspx.cs" Inherits="RoundTable.WebForms.Explore.Explore" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <header
        class="relative m-5 mt-0 px-5 py-4 bg-white rounded-lg flex flex-row shadow-md h-auto transition ease-in-out duration-1000">
        <div class="relative px-0 flex flex-row flex-grow">
            <div class="flex flex-col justify-center">
                <span class="block text-4xl font-bold mb-2 font-title text-gray-700">Explore</span>
                <span class="block opacity-80">Explore rising discussions in various categories.</span>
            </div>
        </div>
    </header>
    <div runat="server" id="recommendations_div"
        class="mt-0 m-5 px-5 py-4 bg-white rounded-lg flex flex-col shadow-md h-auto transition ease-in-out duration-1000">
        <div class="flex flex-row justify-between items-center mb-4">
            <div class="block text-2xl font-bold mb-2 font-title text-gray-700">Posts You Might Like...</div>
        </div>
        <div class="flex flex-row flex-wrap justify-evenly">
            <asp:Repeater ID="Repeater4" runat="server">
                <ItemTemplate>
                    <%--<div
                        class="mt-0 m-5 bg-gray-100 rounded-lg flex flex-row flex-wrap shadow-md h-auto transition ease-in-out duration-1000">--%>
                    <div class="border-0 rounded-lg transition ease-in-out duration-300 px-2 py-1 mx-2 my-2 h-40 bg-gradient-to-r from-indigo-600 via-indigo-400 to-indigo-300 hover:shadow-xl">
                        <asp:LinkButton ID="post_btn" runat="server" CssClass="" OnCommand="post_btn_Command" CommandArgument='<%#Eval("postID") %>'>
                            <%--Discussion title--%>
                            <div class="flex flex-col my-4 break-words" style="max-width: 30vh; min-width: 30vh">
                                <asp:Label ID="postID_lbl" runat="server" Text='<%#Eval("postID") %>' Visible="false"></asp:Label>
                                <asp:Label ID="postTitle_lbl" runat="server" Text='<%#Eval("postTitle") %>' CssClass="text-lg text-white font-medium pt-4 truncate"></asp:Label>
                            </div>
                            <div class="font-normal text-white">
                                <%#Eval("userID") %>
                            </div>
                            <%--Discussion tag--%>
                            <div class="flex flex-row my-2 items-center">
                                <asp:Label ID="topic_lbl" runat="server" ToolTip='<%#Eval("topicDesc") %>' CssClass="mr-5">
                                <div class="flex flex-row justify-center items-center text-indigo-600 text-xs md:text-md border-2 border-indigo-600 rounded-lg bg-gray-200 px-2 py-1">
                                <div class="mr-1">#</div>
                                    <div>
                                        <%#Eval("topicName") %>
                                    </div>
                                </div>
                                </asp:Label>
                            </div>
                        </asp:LinkButton>
                    </div>
                    

                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
    <div
        class="mt-0 m-5 px-5 py-4 bg-white rounded-lg flex flex-col shadow-md h-auto transition ease-in-out duration-1000">
        <div class="flex flex-row justify-between items-center mb-4">
            <div class="block text-2xl font-bold mb-2 font-title text-gray-700">Rising Topics</div>
            <div class="flex flex-row space-x-2 text-indigo-600 animate-bounce hover:opacity-80 cursor-default">
                <div>
                    <svg class="w-6 h-6" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M13 7h8m0 0v8m0-8l-8 8-4-4-6 6"></path></svg>
                </div>
                <div>
                    Today's Top 3 Trending Topics
                </div>
            </div>
            <%--<div class="animate-pulse">
                <asp:LinkButton ID="trendingTopic_btn" runat="server" OnCommand="trendingTopic_btn_Command" CssClass="hover:text-indigo-600">
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
                            d="M13 5l7 7-7 7M5 5l7 7-7 7">
                        </path>
                    </svg>
                </asp:LinkButton>
            </div>--%>
        </div>
        <div class="flex flex-row flex-wrap justify-evenly items-center">
            <asp:Repeater ID="Repeater2" runat="server" DataSourceID="SqlDataSource2">
                <ItemTemplate>
                    <%--<div
                    class="mt-0 m-5 bg-white rounded-lg flex flex-row shadow-md h-auto transition ease-in-out duration-1000">--%>
                    <asp:LinkButton ID="topic_btn" runat="server" CssClass="" OnCommand="topic_btn_Command" CommandArgument='<%#Eval("topicID") %>'>
                             <div class="flex flex-row justify-center items-center px-2 py-1 mx-2 text-gray-700 hover:text-indigo-600 text-md md:text-2xl border-2 border-transparent hover:border-indigo-600 rounded-lg transition ease-in-out duration-300">
                                 <div class="mr-1 md:text-xl">#</div>
                                <div>
                                    <%#Eval("topicName") %>
                                </div>
                             </div>
                    </asp:LinkButton>
                    <%--</div>--%>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <asp:SqlDataSource runat="server" ID="SqlDataSource2" ConnectionString='<%$ ConnectionStrings:ConnectionString %>' SelectCommand="SELECT TOP (3) Post.topicID, COUNT(*) AS totalTopic, Topic.topicName, Topic.topicDesc FROM Post INNER JOIN Topic ON Post.topicID = Topic.topicID GROUP BY Post.topicID, Topic.topicName, Topic.topicDesc ORDER BY totalTopic DESC"></asp:SqlDataSource>
    </div>
    <div
        class="mt-0 m-5 px-5 py-4 bg-white rounded-lg flex flex-col shadow-md h-auto transition ease-in-out duration-1000">
        <div class="mb-4">
            <div id="tags" class="block text-2xl font-bold mb-2 font-title text-gray-700">Discover More Topics</div>
        </div>
        <div class="flex flex-row flex-wrap justify-center">
            <asp:Repeater ID="Repeater3" runat="server" DataSourceID="SqlDataSource3">
                <ItemTemplate>
                    <div
                    class="mt-0 m-5 border-2 border-indigo-600 bg-indigo-600 hover:bg-white text-white hover:text-indigo-600 rounded-lg flex flex-row flex-wrap justify-center items-center shadow h-auto transition ease-in-out duration-300 w-full md:w-1/4 hover:shadow-lg cursor-pointer">
                    <asp:LinkButton ID="topic_btn" runat="server" CssClass="" OnCommand="topic_btn_Command" CommandArgument='<%#Eval("topicID") %>'>
                             <div class="flex flex-wrap flex-row justify-center items-center text-md md:text-base my-2">
                                 <%--<div class="mr-1">#</div>--%>
                                <div>
                                    <%#Eval("topicName") %>
                                </div>
                             </div>
                    </asp:LinkButton>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <asp:SqlDataSource runat="server" ID="SqlDataSource3" ConnectionString='<%$ ConnectionStrings:ConnectionString %>' SelectCommand="SELECT Topic.* FROM Topic"></asp:SqlDataSource>
        </div>
    </div>
    <div
        class="mt-0 m-5 px-5 py-4 bg-white rounded-lg flex flex-col shadow-md h-auto transition ease-in-out duration-1000">
        <div class="flex flex-row justify-between items-center mb-4">
            <div class="block text-2xl font-bold mb-2 font-title text-gray-700">Trending Discussion Posts</div>
            <div class="text-indigo-600 animate-pulse hover:opacity-80 cursor-pointer">
                <asp:LinkButton ID="trendingPost_btn" runat="server" OnCommand="trendingPost_btn_Command" CssClass="flex flex-row space-x-2">
                <div>
                    View More
                </div>
                <div>
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
                            d="M13 5l7 7-7 7M5 5l7 7-7 7">
                        </path>
                    </svg>
                </div>
                </asp:LinkButton>
            </div>
        </div>
        <div>
            <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1">
                <ItemTemplate>
                    <div
                        class="mt-0 m-5 bg-gray-100 rounded-lg flex flex-col shadow-md h-auto transition ease-in-out duration-1000">
                        <asp:LinkButton ID="post_btn" runat="server" CssClass="flex flex-col cursor-pointer hover:shadow-md hover:text-gray-800 p-5 px-6 rounded-lg transition ease-in-out duration-500 border-r-4 border-b-4 border-transparent hover:border-gray-600" OnCommand="post_btn_Command" CommandArgument='<%#Eval("postID") %>'>
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
                                                <abbr class="mr-2" title="<%#DataBinder.Eval(Container.DataItem, "postDate", "{0:dddd, dd/MM/yyyy h:mm:ss tt}") %>" style="text-decoration: none;"><%#DataBinder.Eval(Container.DataItem, "postDate", "{0:d MMMM yyyy}") %></abbr>
                                                <asp:Label ID="edit_date_lbl" runat="server" CssClass="no-underline" Visible='<%# DataBinder.Eval(Container.DataItem, "editDate", "{0:dddd, dd/MM/yyyy h:mm:ss tt}").ToString().Length > 0 ? true : false %>' ToolTip='<%# "Edited on " + DataBinder.Eval(Container.DataItem, "editDate", "{0:dddd, dd/MM/yyyy h:mm:ss tt}") %>' Text='<%# "(Edited on " + DataBinder.Eval(Container.DataItem, "editDate", "{0:d MMMM yyyy}") + ")" %>'></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <%--Discussion title--%>
                            <div class="my-5 break-words" style="max-width:100vh;">
                                <asp:Label ID="postID_lbl" runat="server" Text='<%#Eval("postID") %>' Visible="false"></asp:Label>
                                <asp:Label ID="postTitle_lbl" runat="server" Text='<%#Eval("postTitle") %>' CssClass="text-xl font-medium py-2"></asp:Label>
                            </div>
                            <%--Discussion tag--%>
                            <div class="flex flex-row my-2 items-center">
                                <asp:Label ID="topic_lbl" runat="server" ToolTip='<%#Eval("topicDesc") %>' CssClass="mr-5">
                        <div class="flex flex-row justify-center items-center text-sm md:text-md border-2 rounded-lg bg-white px-2 py-1">
                            <div class="mr-1">#</div>
                            <div>
                                <%#Eval("topicName") %>
                            </div>
                        </div>
                                </asp:Label>
                                <asp:Label ID="tag_lbl" runat="server" ToolTip='<%#Eval("tagDesc") %>'>
                        <div class="flex flex-row justify-center items-center text-sm md:text-md border-2 rounded-lg bg-white px-2 py-1">
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
            <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT TOP (3) Post.postID, Post.postTitle, Post.postContent, Post.postDate, Post.postStatus, Post.editDate, Tag.tagID, Tag.tagName, Tag.tagDesc, Topic.topicID, Topic.topicName, Topic.topicDesc, [User].userID, [User].name, [User].profilePicture, (SELECT COUNT(*) AS Expr1 FROM DiscussionLike WHERE (postID = Post.postID) AND (likeStatus = 1)) AS totalLike, (SELECT COUNT(*) AS Expr1 FROM DiscussionComment WHERE (postID = Post.postID)) AS totalComment, (SELECT COUNT(*) AS Expr1 FROM Bookmark WHERE (postID = Post.postID) AND (bookmarkStatus = 1)) AS totalBookmark, (SELECT COUNT(*) AS Expr1 FROM DiscussionView WHERE (postID = Post.postID)) AS totalView FROM Post INNER JOIN Tag ON Post.tagID = Tag.tagID INNER JOIN Topic ON Post.topicID = Topic.topicID INNER JOIN [User] ON Post.userID = [User].userID WHERE (Post.postStatus = 1) ORDER BY totalView DESC"></asp:SqlDataSource>
        </div>
    </div>
</asp:Content>

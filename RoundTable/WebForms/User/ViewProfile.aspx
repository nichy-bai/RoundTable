<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/RoundTable_master.Master" AutoEventWireup="true" CodeBehind="ViewProfile.aspx.cs" Inherits="RoundTable.WebForms.User.ViewProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../../Content/css/UserProfile.css" rel="stylesheet" />
    <script src="http://code.jquery.com/jquery-1.10.2.min.js" type="text/javascript"></script>
    <header
        class="relative m-5 mt-0 px-5 py-4 bg-white rounded-lg flex flex-row shadow-md h-auto transition ease-in-out duration-1000">
        <div class="relative px-0 flex flex-row flex-grow">
            <div class="flex flex-col justify-center">
                <span class="block text-4xl font-bold mb-2 font-title text-gray-700">Profile</span>
                <span class="block opacity-80">Information about this user</span>
            </div>
        </div>
    </header>
    <div
        class="mt-0 m-5 p-5 px-6 bg-white rounded-lg flex flex-col shadow-md h-auto transition ease-in-out duration-1000">
        <div class="relative px-0 flex flex-row flex-grow flex-wrap pb-20 md:pb-0">
            <div class="items-start w-40 min-w-full sm:min-w-0 mt-0 md:mt-2 mr-5">
                <div class="flex flex-row justify-center">
                    <div>
                        <asp:Image ID="imgProfilePic" runat="server" class="profile-pic" />
                    </div>
                </div>
            </div>
            <div class="flex flex-row flex-wrap justify-center sm:justify-between">
                
            </div>
            <div class="flex flex-col flex-1 text-gray-800 w-full">
                <div class="flex flex-wrap break-all sm:break-normal justify-center md:justify-start border-b-2">
                    <asp:Label ID="lblName" runat="server" Text="" CssClass="text-3xl font-bold py-2 truncate"></asp:Label>
                </div>
                <div class="flex flex-row flex-wrap justify-start items-center my-5">
                    <div class="border-2 rounded-lg bg-gray-100 px-2 py-1 m-2">
                        <asp:Label ID="lblGender" runat="server" Text="" CssClass="text-md font-normal text-center"></asp:Label>
                    </div>
                    <div class="border-2 rounded-lg bg-gray-100 px-2 py-1 m-2">
                        <asp:Label ID="lblDOB" runat="server" Text="" CssClass="text-md font-normal text-center"></asp:Label>
                    </div>
                    <div class="border-2 rounded-lg bg-gray-100 px-2 py-1 m-2">
                        <asp:Label ID="lblEmail" runat="server" Text="" CssClass="text-md font-normal text-center"></asp:Label>
                    </div>
                </div>
                <div class="m-2">
                    <asp:Label ID="lblProfileDesc" runat="server" Text="" CssClass="text-lg text-gray-700 font-normal w-full break-normal break-all"></asp:Label>
                    
                </div>
            </div>
        </div>
    </div>
    <div
        class="mt-0 m-5 p-5 px-6 bg-white rounded-lg flex flex-col shadow-md h-auto transition ease-in-out duration-1000">
        <div>
            <div class="flex flex-row flex-nowrap justify-between items-center mb-5">
                <div class="block text-3xl font-bold font-title text-gray-700">
                    Activities
                </div>
                <div class="flex flex-row flex-wrap text-md text-gray-600">
                    <div>Total: </div>
                    <asp:Label ID="lblTopicPosted" runat="server" Text="" CssClass="ml-1"></asp:Label>
                </div>
            </div>
            <div class="flex flex-col h-96 overflow-auto">
                <div>
                    <asp:Label ID="noPost_lbl" runat="server" CssClass="flex justify-center items-center text-gray-400 text-center mt-10 mb-14" Text="No activities yet." Visible="false"></asp:Label>
                </div>
                <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1">
                    <ItemTemplate>
                        <div
                            class="mt-0 m-5 bg-gray-100 rounded-lg flex flex-col shadow-md h-auto transition ease-in-out duration-1000">
                            <asp:LinkButton ID="post_btn" runat="server" CssClass="flex flex-col cursor-pointer hover:shadow-md hover:text-gray-800 p-5 px-6 rounded-lg transition ease-in-out duration-500 border-r-4 border-b-4 border-transparent hover:border-gray-600" OnCommand="post_btn_Command" CommandArgument='<%#Eval("postID") %>' OnClientClick="window.document.forms[0].target='_blank';">
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
                                <div class="mt-5">
                                    <asp:Label ID="postID_lbl" runat="server" Text='<%#Eval("postID") %>' Visible="false"></asp:Label>
                                    <asp:Label ID="postTitle_lbl" runat="server" Text='<%#Eval("postTitle") %>' CssClass="text-xl font-medium py-2"></asp:Label>
                                </div>
                                <div class="flex justify-end animate-pulse text-indigo-600">
                                    View More
                                </div>
                            </asp:LinkButton>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:ConnectionString %>' SelectCommand="SELECT Post.postID, Post.postTitle, Post.postContent, Post.postDate, Post.postStatus, Post.editDate, Tag.tagID, Tag.tagName, Tag.tagDesc, Topic.topicID, Topic.topicName, Topic.topicDesc, [User].userID, [User].name, [User].profilePicture, (SELECT COUNT(*) AS Expr1 FROM DiscussionLike WHERE (postID = Post.postID) AND (likeStatus = 1)) AS totalLike, (SELECT COUNT(*) AS Expr1 FROM DiscussionComment WHERE (postID = Post.postID)) AS totalComment, (SELECT COUNT(*) AS Expr1 FROM Bookmark WHERE (postID = Post.postID) AND (bookmarkStatus = 1)) AS totalBookmark, (SELECT COUNT(*) AS Expr1 FROM DiscussionView WHERE (postID = Post.postID)) AS totalView FROM Post INNER JOIN Tag ON Post.tagID = Tag.tagID INNER JOIN Topic ON Post.topicID = Topic.topicID INNER JOIN [User] ON Post.userID = [User].userID WHERE (Post.postStatus = 1) AND ([User].userID = @UserID) ORDER BY totalComment DESC">
                <SelectParameters>
                    <asp:QueryStringParameter QueryStringField="userid" Name="UserID"></asp:QueryStringParameter>

                </SelectParameters>
            </asp:SqlDataSource>
        </div>
    </div>
</asp:Content>

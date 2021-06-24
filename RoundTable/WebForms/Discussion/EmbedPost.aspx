<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmbedPost.aspx.cs" Inherits="RoundTable.WebForms.Discussion.EmbedPost" %>

<!DOCTYPE html>

<html lang="en">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <link href="~/Content/icons/favicon.png" rel="icon" />
    <link href="~/Content/css/style.css" rel="stylesheet" />
    <link rel="preconnect" href="https://fonts.gstatic.com">
    <link href="https://fonts.googleapis.com/css2?family=Roboto:ital,wght@0,100;0,300;0,400;0,500;0,700;0,900;1,100;1,300;1,400;1,500;1,700;1,900&display=swap" rel="stylesheet">
    <link href="https://unpkg.com/tailwindcss@^2/dist/tailwind.min.css" rel="stylesheet">

    <title>RoundTable</title>
</head>
<body>
    <a href="#" target="_blank" id="embed_btn" runat="server" class="p-5 px-6 bg-white rounded-lg flex flex-col h-auto border-2 max-w-2xl">
        <div class="flex flex-row justify-between border-b-2 pb-2">
            <%--User detail--%>
            <div>
                <div class="flex flex-row">
                    <asp:Image ID="post_user_img" runat="server" ImageUrl="~/ProfileImages/Default.png" CssClass="w-12 h-12 rounded-full" />
                    <div class="flex flex-col px-4 justify-start items-start">
                        <div class="font-medium">
                            <asp:Label ID="userID_lbl" runat="server" Text="[userID]"></asp:Label>
                        </div>
                        <div class="flex flex-wrap text-sm opacity-80 no-underline">
                            <asp:Label ID="postDate_lbl" runat="server" Text="[postDate]" CssClass="mr-2"></asp:Label>
                            <asp:Label ID="editDate_lbl" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <%--Discussion title--%>
        <div class="my-5 break-words" style="max-width:100%;">
            <asp:Label ID="postTitle_lbl" runat="server" Text="[postTitle]" CssClass="text-xl font-medium py-2"></asp:Label>
        </div>
        <%--Discussion tag--%>
        <div class="flex flex-row my-2 items-center">
            <div class="mr-5">
                <div runat="server" class="flex flex-row justify-center items-center text-sm md:text-md border-2 rounded-lg bg-gray-100 px-2 py-1 transition ease-in-out duration-300">
                    <div class="mr-1">#</div>
                    <div>
                        <asp:Label ID="topicName_lbl" runat="server" Text="[#topicName]"></asp:Label>
                    </div>
                </div>
            </div>
            <div>
                <div runat="server" class="flex flex-row justify-center items-center text-sm md:text-md border-2 rounded-lg bg-gray-100 px-2 py-1 transition ease-in-out duration-300">
                    <div class="mr-1">#</div>
                    <div>
                        <asp:Label ID="tagName_lbl" runat="server" Text="[#tagName]"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
        <%--Reaction--%>
        <div class="flex flex-row items-center flex-wrap">
            <%--Like--%>
            <div class="mr-4 mt-4">
                <div class="flex flex-row justify-start items-center hover:bg-gray-100 px-2 py-1 rounded-lg transition ease-in-out duration-300">
                    <svg
                        runat="server"
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
                    <div class="px-1">
                        <asp:Label ID="postLike_lbl" runat="server" Text="[postLike]"></asp:Label>
                    </div>
                </div>
            </div>
            <%--Comment--%>
            <div class="mr-4 mt-4">
                <div class="flex flex-row justify-start items-center hover:bg-gray-100 px-2 py-1 rounded-lg transition ease-in-out duration-300">
                    <svg
                        runat="server"
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
                    <div class="px-1">
                        <asp:Label ID="postComment_lbl" runat="server" Text="[postComment]"></asp:Label>
                    </div>
                </div>
            </div>
            <%--Bookmark--%>
            <div class="mr-4 mt-4">
                <div class="flex flex-row justify-start items-center hover:bg-gray-100 px-2 py-1 rounded-lg transition ease-in-out duration-300">
                    <svg
                        runat="server"
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
                    <div class="px-1">
                        <asp:Label ID="postBookmark_lbl" runat="server" Text="[postBookmark]"></asp:Label>
                    </div>
                </div>
            </div>
            <%--View--%>
            <div class="mr-4 mt-4">
                <div class="flex flex-row justify-start items-center hover:bg-gray-100 px-2 py-1 rounded-lg transition ease-in-out duration-300">
                    <svg
                        runat="server"
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
                    <div class="px-1">
                        <asp:Label ID="postView_lbl" runat="server" Text="[postView]"></asp:Label>
                    </div>
                </div>
            </div>
            <%--Report--%>
            <div class="mr-4 mt-4">
                <asp:Panel ID="post_report_panel" runat="server" CssClass="flex flex-row justify-start items-center px-2 py-1 text-yellow-600 cursor-help" Visible="false">
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
                            d="M12 9v2m0 4h.01m-6.938 4h13.856c1.54 0 2.502-1.667 1.732-3L13.732 4c-.77-1.333-2.694-1.333-3.464 0L3.34 16c-.77 1.333.192 3 1.732 3z">
                        </path>
                    </svg>
                </asp:Panel>
            </div>
        </div>
    </a>
</body>
</html>

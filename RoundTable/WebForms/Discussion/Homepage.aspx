<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/RoundTable_master.Master" AutoEventWireup="true" CodeBehind="Homepage.aspx.cs" Inherits="RoundTable.WebForms.Discussion.Homepage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <header
        class="relative m-5 px-5 py-4 bg-white rounded-lg flex flex-row shadow-md h-auto dark:bg-dark-200 dark:text-gray-200 transition ease-in-out duration-1000">
        <div class="relative px-0 flex flex-row flex-grow">
            <div class="flex flex-col justify-center">
                <span class="block text-4xl font-bold mb-2 font-title text-gray-700">Homepage</span>
                <span class="block opacity-80">Recent discussions from the community</span>
            </div>
        </div>
        <div class="flex flex-row items-center ml-4">
            <a
                href="#"
                class="w-auto flex flex-row justify-center items-center p-3 bg-gray-700 rounded-lg text-gray-100 hover:shadow-md hover:bg-gray-600 dark:bg-dark-300 dark:hover:bg-dark-400 ease-in-out duration-300">
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
                        d="M12 6V4m0 2a2 2 0 100 4m0-4a2 2 0 110 4m-6 8a2 2 0 100-4m0 4a2 2 0 110-4m0 4v2m0-6V4m6 6v10m6-2a2 2 0 100-4m0 4a2 2 0 110-4m0 4v2m0-6V4">
                    </path>
                </svg>
                <span class="ml-2 hidden sm:inline font-title">Personalize</span>
            </a>
        </div>
    </header>
    <div
        class="mt-0 m-5 px-5 py-4 bg-white rounded-lg flex flex-row shadow-md h-auto dark-theme">
        <div
            class="bg-gray-200 dark:bg-dark-300 hover:bg-gray-300 dark:hover:bg-dark-400 text-gray-600 dark:text-gray-200 hover:text-gray-700 dark:hover:text-gray-100 w-full h-auto rounded-lg cursor-pointer transition ease-in-out duration-1000">
            <a
                href="CreateDiscussion.aspx"
                class="px-0 flex flex-row flex-grow items-center m-5 text-lg h-auto">
                <svg
                    class="w-8 h-8 mr-3"
                    fill="none"
                    stroke="currentColor"
                    viewBox="0 0 24 24"
                    xmlns="http://www.w3.org/2000/svg">
                    <path
                        stroke-linecap="round"
                        stroke-linejoin="round"
                        stroke-width="1.5"
                        d="M12 9v3m0 0v3m0-3h3m-3 0H9m12 0a9 9 0 11-18 0 9 9 0 0118 0z">
                    </path>
                </svg>
                <span>Start a discussion</span>
                <span class="tracking-wider">...</span>
            </a>
        </div>
    </div>
    <%--Discussion Post--%>
    <div
        class="mt-0 m-5 p-5 bg-white rounded-lg flex flex-col shadow-md h-auto dark:bg-dark-200 dark:text-gray-200 transition ease-in-out duration-1000">
        <div class="flex flex-row justify-between mb-4 border-b-2 pb-2">
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
                    <div class="flex flex-col px-4 justify-center items-start">
                        <div class="font-medium">Loremipsum</div>
                        <div class="text-sm opacity-80">29 May 2021</div>
                    </div>
                </a>
            </div>
            <%--Three dots--%>
            <div class="flex flex-row justify-center items-center">
                <a href="#" class="hover:text-indigo-600 transition ease-in-out duration-300">
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
            </div>
        </div>
        <%--Discussion title--%>
        <div>
            <a href="#">
                <div class="text-xl font-medium mb-5 py-2 hover:underline transition ease-in-out duration-300">
                    This is the post title. The very first discussion post.This is the post title. The very first discussion post.This is the post title. The very first discussion post.This is the post title. The very first discussion post.This is the post title. The very first discussion post.This is the post title.
                </div>
            </a>
        </div>
        <%--Discussion tag--%>
        <div class="flex flex-row mb-10">
            <a href="#" class="mr-5">
                <div class="border-2 rounded-lg bg-gray-100 px-2 py-1 hover:bg-white transition ease-in-out duration-300">#Topic Topic</div>
            </a>
            <a href="#" class="mr-5">
                <div class="border-2 rounded-lg bg-gray-100 px-2 py-1 hover:bg-white transition ease-in-out duration-300">#Tag Tag</div>
            </a>
        </div>
        <%--Reaction--%>
        <div class="flex flex-row items-center">
            <%--Like--%>
            <div class="mr-5">
                <a href="#" class="flex flex-row justify-center items-center hover:text-indigo-600 transition ease-in-out duration-300">
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
                    <div class="px-1">123,456</div>
                </a>
            </div>
            <%--Comment--%>
            <div class="mr-5">
                <a href="#" class="flex flex-row justify-center items-center hover:text-indigo-600 transition ease-in-out duration-300">
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
                    <div class="px-1">123,456</div>
                </a>
            </div>
            <%--Bookmark--%>
            <div class="mr-5">
                <a href="#" class="flex flex-row justify-center items-center hover:text-indigo-600 transition ease-in-out duration-300">
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
                    <div class="px-1">123,456</div>
                </a>
            </div>
        </div>
    </div>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Post]"></asp:SqlDataSource>
    <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1">
        <ItemTemplate>
            <div
                class="mt-0 m-5 p-5 bg-white rounded-lg flex flex-col shadow-md h-auto dark:bg-dark-200 dark:text-gray-200 transition ease-in-out duration-1000">
                <div class="flex flex-row justify-between mb-4 border-b-2 pb-2">
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
                            <div class="flex flex-col px-4 justify-center items-start">
                                <div class="font-medium">Loremipsum</div>
                                <div class="text-sm opacity-80">
                                    <%#DataBinder.Eval(Container.DataItem, "postDate", "{0:d MMMM yyyy}") %>
                                </div>
                            </div>
                        </a>
                    </div>
                    <%--Three dots--%>
                    <div class="flex flex-row justify-center items-center">
                        <a href="#" class="hover:text-indigo-600 transition ease-in-out duration-300">
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
                    </div>
                </div>
                <%--Discussion title--%>
                <div>
                    <a href="#">
                        <div class="text-xl font-medium mb-5 py-2 hover:underline transition ease-in-out duration-300">
                            <%#Eval("postTitle") %>
                        </div>
                    </a>
                </div>
                <%--Discussion tag--%>
                <div class="flex flex-row mb-10">
                    <a href="#" class="mr-5">
                        <div class="border-2 rounded-lg bg-gray-100 px-2 py-1 hover:bg-white transition ease-in-out duration-300">#Topic Topic</div>
                    </a>
                    <a href="#" class="mr-5">
                        <div class="border-2 rounded-lg bg-gray-100 px-2 py-1 hover:bg-white transition ease-in-out duration-300">#Tag Tag</div>
                    </a>
                </div>
                <%--Reaction--%>
                <div class="flex flex-row items-center">
                    <%--Like--%>
                    <div class="mr-5">
                        <a href="#" class="flex flex-row justify-start items-center hover:text-indigo-600 transition ease-in-out duration-300">
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
                            <div class="px-1"><%#Eval("postLike") %></div>
                        </a>
                    </div>
                    <%--Comment--%>
                    <div class="mr-5">
                        <a href="#" class="flex flex-row justify-start items-center hover:text-indigo-600 transition ease-in-out duration-300">
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
                            <div class="px-1"><%#Eval("postComment") %></div>
                        </a>
                    </div>
                    <%--Bookmark--%>
                    <div class="mr-5">
                        <a href="#" class="flex flex-row justify-start items-center hover:text-indigo-600 transition ease-in-out duration-300">
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
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>

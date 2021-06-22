<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/RoundTable_master.Master" AutoEventWireup="true" CodeBehind="Changelog.aspx.cs" Inherits="RoundTable.WebForms.Support.Changelog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
        <div class="relative m-5 mt-0 px-5 py-4 bg-white text-black rounded-lg flex flex-col shadow-md h-auto">
            <div class="container mx-auto flex flex-col items-start md:flex-row my-12 md:my-20">
                <div class="flex flex-col w-full sticky md:top-36 lg:w-1/2 md:w-1/3 mt-2 md:mt-12 px-8 mb-5 md:mb-0">
                    <p class="text-indigo-600 uppercase tracking-loose">RoundTable</p>
                    <p class="text-3xl md:text-4xl leading-normal md:leading-relaxed mb-2 capitalize font-medium">Changelog<span class="text-gray-600 font-normal">: See what's new</span></p>
                    <p class="text-sm md:text-base mb-4 text-gray-800">
                        The changelog will include records of changes such as bug fixes, new features, feature upgrades, etc. We will also include why the changes were made and how these changes will improve RoundTable for you.
                    </p>
                    <a href="../Support/SupportDetail.aspx""
                        class="bg-transparent mr-auto hover:bg-indigo-600 text-indigo-600 hover:text-white rounded-lg shadow hover:shadow-md py-2 px-4 border border-indigo-600 hover:border-transparent transition ease-in-out duration-300">View More</a>
                </div>
                <div class="ml-0 md:ml-12 lg:w-2/3 sticky">
                    <div class="container mx-auto w-full h-full">
                        <div class="relative wrap overflow-hidden py-10 md:p-10 h-full">
                            <div class="border-2-2 border-indigo-600 absolute h-full border"
                                style="right: 50%; border: 2px solid #4F46E5; border-radius: 1%;">
                            </div>
                            <div class="mb-8 flex justify-between flex-row-reverse items-center w-full left-timeline">
                                <div class="order-1 w-5/12"></div>
                                <div class="order-1 w-5/12 px-1 py-4 text-right">
                                    <p class="mb-3 text-base text-indigo-600">21 June 2021</p>
                                    <h4 class="mb-3 font-bold text-lg md:text-2xl capitalize">Introducing RoundTable Changelog</h4>
                                    <p class="bg-green-500 w-auto inline px-2 py-1 rounded-lg text-white mb-3 text-center text-sm">Added</p>
                                    <p class="mt-3 text-sm md:text-base leading-snug text-opacity-100">
                                        This is a changelog for the changelog! We created this changelog page to keep you updated on the changes made on RoudTable regularly.
                                    </p>
                                </div>
                            </div>
                            <div class="mb-8 flex justify-between items-center w-full right-timeline">
                                <div class="order-1 w-5/12"></div>
                                <div class="order-1  w-5/12 px-1 py-4 text-left">
                                    <p class="mb-3 text-base text-indigo-600">18 June 2021</p>
                                    <h4 class="mb-3 font-bold text-lg md:text-2xl capitalize">New explore page and reply comment feature</h4>
                                    <p class="bg-green-500 w-auto inline px-2 py-1 rounded-lg text-white mb-3 text-center text-sm">Added</p>
                                    <p class="mt-3 text-sm md:text-base leading-snug text-opacity-100">
                                        Discovering new discussion posts couldn't be easier. Users can now reply to replies to the discussion post. Yeah, more interaction.
                                    </p>
                                </div>
                            </div>
                            <div class="mb-8 flex justify-between flex-row-reverse items-center w-full left-timeline">
                                <div class="order-1 w-5/12"></div>
                                <div class="order-1 w-5/12 px-1 py-4 text-right">
                                    <p class="mb-3 text-base text-indigo-600">14 June 2021</p>
                                    <h4 class="mb-3 font-bold text-lg md:text-2xl capitalize">Better Discussion Experience With various features</h4>
                                    <p class="bg-indigo-500 w-auto inline px-2 py-1 rounded-lg text-white mb-3 text-center text-sm">Updated</p>
                                    <p class="mt-3 text-sm md:text-base leading-snug text-opacity-100">
                                        Users can now use the powerful and flexible rich text editor on RoundTable to better initiate discussions. A profanity detector has also been added to create a better discussion environment.
                                    </p>
                                </div>
                            </div>
                            <div class="mb-8 flex justify-between items-center w-full right-timeline">
                                <div class="order-1 w-5/12"></div>
                                <div class="order-1  w-5/12 px-1 py-4 text-left">
                                    <p class="mb-3 text-base text-indigo-600">11 June 2021</p>
                                    <h4 class="mb-3 font-bold text-lg md:text-2xl capitalize">New voice search function and homepage personalization</h4>
                                    <p class="bg-green-500 w-auto inline px-2 py-1 rounded-lg text-white mb-3 text-center text-sm">Added</p>
                                    <p class="mt-3 text-sm md:text-base leading-snug text-opacity-100">
                                        Users can now search using their voice through microphone input, without typing. Homepage personalization can be used to customize the layout and content delivered to users.
                                    </p>
                                </div>
                            </div>
                            <div class="mb-8 flex justify-between flex-row-reverse items-center w-full left-timeline">
                                <div class="order-1 w-5/12"></div>
                                <div class="order-1 w-5/12 px-1 py-4 text-right">
                                    <p class="mb-3 text-base text-indigo-600">7 June 2021</p>
                                    <h4 class="mb-3 font-bold text-lg md:text-2xl capitalize">Improved discussion post interaction</h4>
                                    <p class="bg-indigo-500 w-auto inline px-2 py-1 rounded-lg text-white mb-3 text-center text-sm">Updated</p>
                                    <p class="mt-3 text-sm md:text-base leading-snug text-opacity-100">
                                        Added multiple ways for users to interact with discussion posts, such as editing and sharing posts. The discussion post is now tracking the number of views.
                                    </p>
                                </div>
                            </div>
                            <div class="mb-8 flex justify-between items-center w-full right-timeline">
                                <div class="order-1 w-5/12"></div>
                                <div class="order-1  w-5/12 px-1 py-4 text-left">
                                    <p class="mb-3 text-base text-indigo-600">2 June 2021</p>
                                    <h4 class="mb-3 font-bold text-lg md:text-2xl capitalize">Updates to user profile, searching, chatbot and more</h4>
                                    <p class="bg-indigo-500 w-auto inline px-2 py-1 rounded-lg text-white mb-3 text-center text-sm">Updated</p>
                                    <p class="mt-3 text-sm md:text-base leading-snug text-opacity-100">
                                        Shorten the process for smoother login and registration activity and better search function. Also, smarter chatbot for smarter user!
                                    </p>
                                </div>
                            </div>
                            <div class="mb-8 flex justify-between flex-row-reverse items-center w-full left-timeline">
                                <div class="order-1 w-5/12"></div>
                                <div class="order-1 w-5/12 px-1 py-4 text-right">
                                    <p class="mb-3 text-base text-indigo-600">24 May 2021</p>
                                    <h4 class="mb-3 font-bold text-lg md:text-2xl capitalize">New Feature: Chatbot on RoundTable</h4>
                                    <p class="bg-green-500 w-auto inline px-2 py-1 rounded-lg text-white mb-3 text-center text-sm">Added</p>
                                    <p class="mt-3 text-sm md:text-base leading-snug text-opacity-100">
                                        The chatbots will provide synchronous communication, so individuals can get instant responses by chatting with them in real-time.
                                    </p>
                                </div>
                            </div>

                            <div class="mb-8 flex justify-between items-center w-full right-timeline">
                                <div class="order-1 w-5/12"></div>

                                <div class="order-1  w-5/12 px-1 py-4">
                                    <p class="mb-3 text-base text-indigo-600">19 May 2021</p>
                                    <h4 class="mb-3 font-bold text-lg md:text-2xl text-left capitalize">Introducing RoundTable</h4>
                                    <p class="bg-green-500 w-auto inline px-2 py-1 rounded-lg text-white mb-3 text-center text-sm">Added</p>
                                    <p class="mt-3 text-sm md:text-base leading-snug text-opacity-100">
                                        Roundtable, a remote meeting platform, the so-called online discussion platform was proposed and initiated.
                                    </p>
                                </div>
                            </div>
                        </div>
                        <img class="mx-auto w-full md:w-2/3 h-auto mt-10 md:mt-20" src="../../Content/img/changelog_illustration_1.svg" />
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>

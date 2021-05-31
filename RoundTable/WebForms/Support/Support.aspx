<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/RoundTable_master.Master" AutoEventWireup="true" CodeBehind="Support.aspx.cs" Inherits="RoundTable.WebForms.Support.Support" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div
        class="relative m-5 mt-0 px-5 py-4 bg-white rounded-lg flex flex-col shadow-md h-auto dark:bg-dark-200 dark:text-gray-200 transition ease-in-out duration-1000">
        <div class="relative px-0 flex flex-row flex-grow">
            <div class="flex flex-col justify-center items-center w-full mt-5">
                <div class="text-3xl lg:text-5xl font-bold mb-2 font-title tracking-wide flex flex-row justify-center items-center py-5 text-gray-800 flex-wrap">
                    <svg
                        class="hidden md:block"
                        width="80"
                        height="80"
                        viewBox="0 0 500 500"
                        fill="none"
                        xmlns="http://www.w3.org/2000/svg">
                        <path
                            fill-rule="evenodd"
                            clip-rule="evenodd"
                            d="M500 250.594C500 297.339 487.232 341.094 465 378.547V255.361V239.927L451.202 233.011L261.702 138.03L250.5 132.416L239.298 138.03L49.7979 233.011L36 239.927V255.361V380.217C13.1518 342.397 0 298.035 0 250.594C0 112.195 111.929 0 250 0C388.071 0 500 112.195 500 250.594ZM415 295.856V438.861C376.969 472.377 328.698 494.498 275.5 499.9V365.776L415 295.856ZM225.5 365.776V500C172.372 494.82 124.115 472.971 86 439.738V295.856L225.5 365.776Z"
                            fill="currentColor" />
                    </svg>
                    <div class="flex flex-row">
                        <div class="ml-5">RoundTable</div>
                        <div class="flex justify-center items-center opacity-50 tracking-normal">&nbsp;support</div>
                    </div>
                </div>
                <div class="text-xl text-center mb-5 w-4/5 lg:w-1/2 opacity-80 font-bold text-2xl">How can we help?</div>
                <div class="text-xl font-medium text-center w-4/5 lg:w-1/2 opacity-60">Your go-to guides for understanding RoundTable a little better</div>
            </div>
        </div>
        <div class="my-10 flex justify-center items-center invert">
            <img src="../../Content/img/support_illustration_2.svg" alt="illustration_2" class="w-11/12 md:w-2/5 h-auto">
        </div>
        <div class="flex flex-row justify-center items-center">
            <a
                href="SupportDetail.aspx"
                class="w-auto flex flex-row justify-center items-center p-3 bg-gray-700 rounded-lg text-gray-100 hover:shadow-md hover:bg-gray-600 dark:bg-dark-300 dark:hover:bg-dark-400 ease-in-out duration-300">
                <svg class="w-8 h-8"
                    fill="none"
                    stroke="currentColor"
                    viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg">
                    <path
                        stroke-linecap="round"
                        stroke-linejoin="round"
                        stroke-width="1.5" d="M13 9l3 3m0 0l-3 3m3-3H8m13 0a9 9 0 11-18 0 9 9 0 0118 0z">
                    </path>
                </svg>
                <span class="mx-2 hidden sm:inline font-title">Getting Started</span>
            </a>
        </div>
        <div class="flex flex-row flex-wrap justify-evenly items-center my-20">
            <div class="flex flex-col my-5">
                <div>
                    <div class="font-bold text-2xl mb-4 text-gray-700 hover:text-indigo-600 transition ease-in-out duration-300">Getting Started</div>
                    <div class="my-2">
                        <a href="#" class="text-indigo-700 hover:text-indigo-600 hover:underline">Using RoundTable</a>
                    </div>
                    <div class="my-2">
                        <a href="#" class="text-indigo-700 hover:text-indigo-600 hover:underline">RoundTable Glossary</a>
                    </div>
                    <div class="my-2">
                        <a href="#" class="text-indigo-700 hover:text-indigo-600 hover:underline">Create Discussion Post</a>
                    </div>
                    <div class="my-2">
                        <a href="#" class="text-indigo-700 hover:text-indigo-600 hover:underline">Bug Reports and Feature Requests</a>
                    </div>
                </div>
            </div>
            <div class="flex flex-col my-5">
                <div>
                    <div class="font-bold text-2xl mb-4 text-gray-700 hover:text-indigo-600 transition ease-in-out duration-300">FAQs</div>
                    <div class="my-2">
                        <a href="#" class="text-indigo-700 hover:text-indigo-600 hover:underline">Using RoundTable</a>
                    </div>
                    <div class="my-2">
                        <a href="#" class="text-indigo-700 hover:text-indigo-600 hover:underline">RoundTable Glossary</a>
                    </div>
                    <div class="my-2">
                        <a href="#" class="text-indigo-700 hover:text-indigo-600 hover:underline">Create Discussion Post</a>
                    </div>
                    <div class="my-2">
                        <a href="#" class="text-indigo-700 hover:text-indigo-600 hover:underline">Bug Reports and Feature Requests</a>
                    </div>
                </div>
            </div>
            <div class="flex flex-col my-5">
                <div>
                    <div class="font-bold text-2xl mb-4 text-gray-700 hover:text-indigo-600 transition ease-in-out duration-300">Tips & Tricks</div>
                    <div class="my-2">
                        <a href="#" class="text-indigo-700 hover:text-indigo-600 hover:underline">Using RoundTable</a>
                    </div>
                    <div class="my-2">
                        <a href="#" class="text-indigo-700 hover:text-indigo-600 hover:underline">RoundTable Glossary</a>
                    </div>
                    <div class="my-2">
                        <a href="#" class="text-indigo-700 hover:text-indigo-600 hover:underline">Create Discussion Post</a>
                    </div>
                    <div class="my-2">
                        <a href="#" class="text-indigo-700 hover:text-indigo-600 hover:underline">Bug Reports and Feature Requests</a>
                    </div>
                </div>
            </div>
        </div>

        <div class="my-10 flex justify-center items-center invert">
            <img src="../../Content/img/support_illustration_1.svg" alt="illustration_2" class="w-11/12 md:w-2/5 h-auto">
        </div>
        <div class="text-xl text-center my-10 opacity-80 font-bold text-2xl">Still having problem?</div>
        <div class="flex flex-row justify-center items-center mb-20">
            <a
                href="Feedback.aspx"
                class="w-auto flex flex-row justify-center items-center p-3 bg-gray-700 rounded-lg text-gray-100 hover:shadow-md hover:bg-gray-600 dark:bg-dark-300 dark:hover:bg-dark-400 ease-in-out duration-300">
                <svg class="w-8 h-8"
                    fill="none"
                    stroke="currentColor"
                    viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg">
                    <path
                        stroke-linecap="round"
                        stroke-linejoin="round"
                        stroke-width="1.5" d="M3 8l7.89 5.26a2 2 0 002.22 0L21 8M5 19h14a2 2 0 002-2V7a2 2 0 00-2-2H5a2 2 0 00-2 2v10a2 2 0 002 2z">
                    </path>
                </svg>
                <span class="mx-2 hidden sm:inline font-title">Contact Us</span>
            </a>
        </div>
    </div>
    <%--Footer--%>
    <div
        class="hidden md:flex mt-0 m-5 p-10 bg-white rounded-lg flex-row flex-wrap justify-between items-center shadow-md h-auto dark:bg-dark-200 dark:text-gray-200 transition ease-in-out duration-1000">
        <div class="flex flex-col items-start justify-items-start">
            <div class="text-2xl font-bold mb-2 font-title tracking-wide flex flex-row justify-center items-center text-gray-800">
                <svg
                    width="40"
                    height="40"
                    viewBox="0 0 500 500"
                    fill="none"
                    xmlns="http://www.w3.org/2000/svg">
                    <path
                        fill-rule="evenodd"
                        clip-rule="evenodd"
                        d="M500 250.594C500 297.339 487.232 341.094 465 378.547V255.361V239.927L451.202 233.011L261.702 138.03L250.5 132.416L239.298 138.03L49.7979 233.011L36 239.927V255.361V380.217C13.1518 342.397 0 298.035 0 250.594C0 112.195 111.929 0 250 0C388.071 0 500 112.195 500 250.594ZM415 295.856V438.861C376.969 472.377 328.698 494.498 275.5 499.9V365.776L415 295.856ZM225.5 365.776V500C172.372 494.82 124.115 472.971 86 439.738V295.856L225.5 365.776Z"
                        fill="currentColor" />
                </svg>
                <span class="ml-3">RoundTable</span>
            </div>
            <div class="my-5">
                <span
                    class="font-sm font-title hover:text-indigo-600 dark:hover:text-indigo-500 transition ease-in-out duration-300 cursor-default">&#169; 2021 RoundTable</span>
            </div>
        </div>
        <div>
            <div class="grid grid-cols-1 gap-x-4 gap-y-1 w-64">
                <a href="#" class="hover:bg-gray-200 dark:hover:bg-dark-300 rounded-lg px-4 py-2 transition ease-in-out duration-300">About</a>
                <a href="#" class="hover:bg-gray-200 dark:hover:bg-dark-300 rounded-lg px-4 py-2 transition ease-in-out duration-300">Support</a>
                <a href="#" class="hover:bg-gray-200 dark:hover:bg-dark-300 rounded-lg px-4 py-2 transition ease-in-out duration-300">Logo & Media</a>
                <a href="#" class="hover:bg-gray-200 dark:hover:bg-dark-300 rounded-lg px-4 py-2 transition ease-in-out duration-300">Privacy</a>
                <a href="#" class="hover:bg-gray-200 dark:hover:bg-dark-300 rounded-lg px-4 py-2 transition ease-in-out duration-300">Terms and Conditions</a>
            </div>
        </div>
    </div>
    <%--End of Footer--%>
</asp:Content>

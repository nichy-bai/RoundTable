﻿<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/RoundTable_master.Master" AutoEventWireup="true" CodeBehind="Homepage.aspx.cs" Inherits="RoundTable.WebForms.Discussion.Homepage" %>

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
    <div
        class="mt-0 m-5 px-5 py-4 bg-white rounded-lg flex flex-row shadow-md h-auto dark:bg-dark-200 dark:text-gray-200 transition ease-in-out duration-1000">
        test
    </div>
</asp:Content>

﻿<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/RoundTable_master.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="RoundTable.WebForms.Support.About" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div
        class="relative m-5 mt-0 px-5 py-4 bg-white rounded-lg flex flex-col shadow-md h-auto transition ease-in-out duration-1000">
        <div class="relative px-0 flex flex-row flex-grow">
            <div class="flex flex-col justify-center items-center w-full">
                <div class="text-3xl md:text-5xl font-bold mb-2 font-title tracking-wide flex flex-row justify-center items-center py-5 text-gray-800">
                    <svg
                        width="64"
                        height="64"
                        viewBox="0 0 500 500"
                        fill="none"
                        xmlns="http://www.w3.org/2000/svg">
                        <path
                            fill-rule="evenodd"
                            clip-rule="evenodd"
                            d="M500 250.594C500 297.339 487.232 341.094 465 378.547V255.361V239.927L451.202 233.011L261.702 138.03L250.5 132.416L239.298 138.03L49.7979 233.011L36 239.927V255.361V380.217C13.1518 342.397 0 298.035 0 250.594C0 112.195 111.929 0 250 0C388.071 0 500 112.195 500 250.594ZM415 295.856V438.861C376.969 472.377 328.698 494.498 275.5 499.9V365.776L415 295.856ZM225.5 365.776V500C172.372 494.82 124.115 472.971 86 439.738V295.856L225.5 365.776Z"
                            fill="currentColor" />
                    </svg>
                    <span class="ml-5">RoundTable</span>
                </div>
                <div class="text-md md:text-xl font-medium text-center my-5 w-4/5 lg:w-1/2 text-gray-600">RoundTable is the easiest way to start an asynchronous discussion for free and connect with the user through our global community!</div>
            </div>
        </div>
        <div class="my-10 flex justify-center items-center">
            <img src="../../Content/img/about_illustration_1.svg" alt="illustration_1" class="w-11/12 md:w-3/5 h-auto">
        </div>
        <div class="flex flex-col justify-center items-center text-center mt-20 mb-10">
            <div class="uppercase font-bold mb-5 text-gray-800">Our Mission</div>
            <div class="text-md md:text-xl font-medium text-center w-4/5 md:w-1/2 opacity-80">Connect people from all over the world and help them easily share knowledge and grow.</div>
        </div>
        <div class="mt-10 mb-20 flex justify-center items-center">
            <img src="../../Content/img/about_illustration_2.svg" alt="illustration_1" class="w-11/12 md:w-3/5 h-auto">
        </div>
    </div>
</asp:Content>

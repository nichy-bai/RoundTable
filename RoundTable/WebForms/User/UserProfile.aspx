<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/RoundTable_master.Master" AutoEventWireup="true" CodeBehind="UserProfile.aspx.cs" Inherits="RoundTable.WebForms.User.UserProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../../Content/css/UserProfile.css" rel="stylesheet" />
    <header
        class="relative m-5 px-5 py-4 bg-white rounded-lg flex flex-row shadow-md h-auto dark:bg-dark-200 dark:text-gray-200 transition ease-in-out duration-1000">
        <div class="relative px-0 flex flex-row flex-grow">
            <div class="flex flex-col justify-center">
                <span class="block text-4xl font-bold mb-2 font-title">Profile</span>
                <span class="block opacity-80">Information about the user</span>
            </div>
        </div>  
    </header>
     <div
        class="mt-0 m-5 px-5 py-4 bg-white rounded-lg flex flex-row shadow-md h-auto dark:bg-dark-200 dark:text-gray-200 transition ease-in-out duration-1000">
        <div class="relative px-0 flex flex-row flex-grow">
            <div class="items-start">
                <span class="flex flex-row justify-center">
                <%--<svg
                    class="w-20 h-20 flex-initial"
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
                </svg>--%>
                    <div class="avatar">
                        <asp:ImageButton ID="profilePic" runat="server" CssClass="img-raised profileimg" ImageUrl="" data-toggle="modal" data-target="#modalForm" OnClientClick="return false;" BorderStyle="None" />
                    </div>    
            </span>
            </div>
            <div class="flex flex-col flex-1">
                <span class="mb-10">
                    <%--<asp:Label ID="lblName" runat="server" Text="Name" CssClass=""></asp:Label>--%>
                    <asp:TextBox ID="txtName" BorderStyle="None" BackColor="Transparent" runat="server" Text='Name' Enabled="false" CssClass="text-3xl ml-10 font-bold"></asp:TextBox>
                </span>
                <span class="flex text-xl ml-10 mt-10 font-bold">
                    Topic Posted
                    <asp:Label ID="lblTopicPosted" runat="server" Text="69" CssClass="ml-5 text-lg font-medium"></asp:Label>
                </span>
                <span class="right-0 absolute mt-10 mr-20">
                    <asp:Button ID="btnEditProfile" runat="server" Text="Edit Profile" OnClick="btnEditProfile_Click" CssClass="font-bold px-6 py-2 border-2 rounded border-black" />
                </span>

                <div class="flex text-xl ml-10 mt-10 font-bold justify-between">
                    Gender
                    <asp:TextBox ID="txtGender" BorderStyle="None" BackColor="Transparent" runat="server" Text='M' Enabled="false" CssClass="mr-48 text-lg"></asp:TextBox>
                </div>
             
                <div class="flex text-xl ml-10 font-bold justify-between">
                    Date Of Birth
                    <asp:TextBox ID="txtDOB" BorderStyle="None" BackColor="Transparent" runat="server" Text='' TextMode="Date" Enabled="false" CssClass="mr-48 pr-5 text-lg"></asp:TextBox>
                </div>

                <div class="flex text-xl ml-10 font-bold justify-between">
                    Email
                     <asp:TextBox ID="txtEmail" BorderStyle="None" BackColor="Transparent" runat="server" Text='Email' Enabled="false" CssClass="mr-48 text-lg "></asp:TextBox>
                </div>

                <span class="text-xl ml-10 font-bold justify-between">
                    Area Of Interest
                </span>

                <span class="ml-10 mb-5 text-lg">
                    <asp:TextBox ID="txtAreaOfInterest" BorderStyle="None" BackColor="Transparent" runat="server" Text='Area Of Interest' Enabled="false" CssClass=""></asp:TextBox>
                </span>

            </div>
            </div>
        </div>  
    
</asp:Content>

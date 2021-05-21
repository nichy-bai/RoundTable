<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/RoundTable_master.Master" AutoEventWireup="true" CodeBehind="UserProfile.aspx.cs" Inherits="RoundTable.WebForms.User.UserProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                <svg
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
                </svg>
            </span>
            </div>
            <div class="flex flex-col flex-1">
                <span class="mb-10">
                    <%--<asp:Label ID="lblName" runat="server" Text="Name" CssClass=""></asp:Label>--%>
                    <asp:TextBox ID="txtName" BorderStyle="None" BackColor="Transparent" runat="server" Text='Name' Enabled="false" CssClass="text-2xl ml-10 font-bold"></asp:TextBox>
                </span>
                <span class="right-0 absolute mt-10">
                    <asp:Button ID="btnEditProfile" runat="server" Text="Edit Profile" OnClick="btnEditProfile_Click" CssClass="font-bold p-4 border-4 border-black" />
                </span>

                <span class="text-xl ml-10 mt-10 font-bold">
                    Gender
                    <asp:TextBox ID="txtGender" BorderStyle="None" BackColor="Transparent" runat="server" Text='M' Enabled="false" CssClass="text-lg right-0 absolute"></asp:TextBox>
                </span>
             
                <span class="text-xl ml-10 font-bold">
                    Date Of Birth
                    <asp:TextBox ID="txtDOB" BorderStyle="None" BackColor="Transparent" runat="server" Text='' TextMode="Date" Enabled="false" CssClass="text-lg right-0 absolute"></asp:TextBox>
                </span>

                <span class="text-xl ml-10 font-bold">
                    Email
                     <asp:TextBox ID="txtEmail" BorderStyle="None" BackColor="Transparent" runat="server" Text='Email' Enabled="false" CssClass="text-lg right-0 absolute"></asp:TextBox>
                </span>

                <span class="text-xl ml-10 font-bold">
                    Area Of Interest
                </span>

                <span class="ml-10 text-lg">
                    <asp:TextBox ID="txtAreaOfInterest" BorderStyle="None" BackColor="Transparent" runat="server" Text='Area Of Interest' Enabled="false" CssClass=""></asp:TextBox>
                </span>

            </div>
            </div>
        </div>  
    
</asp:Content>

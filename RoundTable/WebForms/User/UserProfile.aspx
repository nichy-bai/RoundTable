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
         <asp:MultiView ID="MultiViewProfile" runat="server">
             <asp:View ID="ProfileView" runat="server">
                 <div class="relative px-0 flex flex-row flex-grow">
                     <div class="items-start">
                         <div class="flex flex-row justify-center">
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
                             <div <%--class="avatar"--%>>
                                 <asp:Image ID="imgProfilePic" runat="server" class="profile-pic" />
                                 <%--<asp:ImageButton ID="profilePic" runat="server" CssClass="img-raised profileimg" ImageUrl="" data-toggle="modal" data-target="#modalForm" OnClientClick="return false;" BorderStyle="None" />--%>
                             </div>
                         </div>
                     </div>
                     <div class="flex flex-col flex-1">
                         <span class="mb-10">
                             <asp:Label ID="lblName" runat="server" Text="" CssClass="text-3xl ml-10 font-bold"></asp:Label>
                             <%--<asp:TextBox ID="txtName" BorderStyle="None" BackColor="Transparent" runat="server" Text='Name' Enabled="false" CssClass="text-3xl ml-10 font-bold"></asp:TextBox>--%>
                         </span>
                         <span class="flex text-xl ml-10 mt-10 font-bold">Topic Posted
                    <asp:Label ID="lblTopicPosted" runat="server" Text="" CssClass="ml-5 text-lg font-medium"></asp:Label>
                         </span>
                         <span class="right-0 absolute mt-10 mr-20">
                             <asp:Button ID="btnEditProfile" runat="server" Text="Edit Profile" OnClick="btnEditProfile_Click" CssClass="editProfile-btn cursor-pointer font-bold py-3 px-6 rounded bg-indigo-600 <%--font-bold px-6 py-2 border-2 rounded border-black--%>" />
                         </span>

                         <div class="flex text-xl ml-10 mt-10 font-bold justify-between">
                             Gender
                    <asp:Label ID="lblGender" runat="server" Text="" CssClass="mr-48 text-lg font-normal"></asp:Label>
                             <%--<asp:TextBox ID="txtGender" BorderStyle="None" BackColor="Transparent" runat="server" Text='M' Enabled="false" CssClass="mr-48 text-lg"></asp:TextBox>--%>
                         </div>

                         <div class="flex text-xl ml-10 font-bold justify-between">
                             Date Of Birth
                    <asp:Label ID="lblDOB" runat="server" Text="" CssClass="mr-48 text-lg font-normal"></asp:Label>
                             <%--<asp:TextBox ID="txtDOB" BorderStyle="None" BackColor="Transparent" runat="server" Text='' TextMode="Date" Enabled="false" CssClass="mr-48 pr-5 text-lg"></asp:TextBox>--%>
                         </div>

                         <div class="flex text-xl ml-10 font-bold justify-between">
                             Email
                     <asp:Label ID="lblEmail" runat="server" Text="" CssClass="mr-48 text-lg font-normal"></asp:Label>
                             <%--<asp:TextBox ID="txtEmail" BorderStyle="None" BackColor="Transparent" runat="server" Text='Email' Enabled="false" CssClass="mr-48 text-lg "></asp:TextBox>--%>
                         </div>

                         <%--<span class="text-xl ml-10 font-bold justify-between">Area Of Interest
                         </span>

                         <span class="ml-10 mb-5 text-lg font-normal">
                             <asp:Label ID="lblAreaOfInterest" runat="server" Width="50px" Text="" CssClass=""></asp:Label>
                             <asp:TextBox ID="txtAreaOfInterest" BorderStyle="None" BackColor="Transparent" runat="server" Text='Area Of Interest' Enabled="false" CssClass=""></asp:TextBox>
                         </span>--%>

                     </div>
                 </div>
             </asp:View>
             <asp:View ID="EditProfileView" runat="server">
                 <div class="relative px-0 flex flex-row flex-grow">
                     <div class="items-start">
                         <div class="flex flex-row justify-center">
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
                                 <asp:Image ID="profilePicture" runat="server" class="profile-pic" />
                                 <%--<asp:ImageButton ID="profilePic" runat="server" CssClass="img-raised profileimg" ImageUrl="" data-toggle="modal" data-target="#modalForm" OnClientClick="return false;" BorderStyle="None" />--%>
                             </div>
                         </div>
                     </div>
                     <div class="flex flex-col flex-1">
                         <span class="mb-10 text-3xl ml-10 font-bold">Name
                    <asp:TextBox ID="txtName" runat="server" Width="250px" Height="50px" CssClass=" border-2 border-black"></asp:TextBox>
                             <%--<asp:TextBox ID="txtName" BorderStyle="None" BackColor="Transparent" runat="server" Text='Name' Enabled="false" CssClass="text-3xl ml-10 font-bold"></asp:TextBox>--%>
                         </span>
                         <span class="flex text-xl ml-10 mt-10 font-bold">Topic Posted
                    <asp:Label ID="lblTopicPosted1" runat="server" Text="" CssClass="ml-5 text-lg font-medium"></asp:Label>
                         </span>
                         <%--<span class="right-0 absolute mt-10 mr-20">
                    <asp:Button ID="btnEditProfile" runat="server" Text="Edit Profile" OnClick="btnEditProfile_Click" CssClass="font-bold px-6 py-2 border-2 rounded border-black" />
                </span>--%>

                         <div class="flex text-xl ml-10 mt-10 font-bold justify-between">
                             Gender
                      <asp:DropDownList ID="ddlGender" runat="server" Width="250px" CssClass=" border-2 border-black mr-48">
                          <asp:ListItem Value="-">Select Gender</asp:ListItem>
                          <asp:ListItem Value="M">Male</asp:ListItem>
                          <asp:ListItem Value="F">Female</asp:ListItem>
                      </asp:DropDownList>
                             <%--<asp:TextBox ID="txtGender" runat="server" Width="250px" CssClass=" border-2 border-black mr-48"></asp:TextBox>--%>
                             <%--<asp:TextBox ID="txtGender" BorderStyle="None" BackColor="Transparent" runat="server" Text='M' Enabled="false" CssClass="mr-48 text-lg"></asp:TextBox>--%>
                         </div>

                         <div class="flex text-xl ml-10 mt-2 font-bold justify-between">
                             Date Of Birth
                    <asp:TextBox ID="txtDOB" runat="server" TextMode="Date" Width="250px" CssClass=" border-2 border-black mr-48"></asp:TextBox>
                             <%--<asp:RangeValidator ID="DateRangeValidator" runat="server" ControlToValidate="txtDOB" ForeColor="red" ErrorMessage="Date of birth cannot be larger than current date" Type="Date" Display="Dynamic"></asp:RangeValidator>--%>
                             <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtDOB" ForeColor="red" runat="server" ErrorMessage="This field is required" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                             <%--<asp:TextBox ID="txtDOB" BorderStyle="None" BackColor="Transparent" runat="server" Text='' TextMode="Date" Enabled="false" CssClass="mr-48 pr-5 text-lg"></asp:TextBox>--%>
                         </div>

                         <div class="flex text-xl ml-10 mt-2 font-bold justify-between">
                             Email
                     <asp:TextBox ID="txtEmail" runat="server" Width="250px" CssClass=" border-2 border-black mr-48"></asp:TextBox>
                             <%--<asp:TextBox ID="txtEmail" BorderStyle="None" BackColor="Transparent" runat="server" Text='Email' Enabled="false" CssClass="mr-48 text-lg "></asp:TextBox>--%>
                         </div>

                         <%--<div class="text-xl ml-10 font-bold justify-between">
                             Area Of Interest
                         </div>

                         <div class="ml-10 mb-5 mt-2 text-xl">
                             <asp:TextBox ID="txtAreaOfInterest" runat="server" Width="250px" CssClass=" border-2 border-black"></asp:TextBox>
                             <asp:TextBox ID="txtAreaOfInterest" BorderStyle="None" BackColor="Transparent" runat="server" Text='Area Of Interest' Enabled="false" CssClass=""></asp:TextBox>
                             <asp:CheckBoxList ID="cblAOI" runat="server">
                                 
                                 <asp:ListItem>Machine Learning</asp:ListItem>
                                 <asp:ListItem>Science</asp:ListItem>
                                 
                             </asp:CheckBoxList>

                         </div>--%>

                         <div class="flex justify-end mt-10">
                             <span>
                                 <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" CssClass="font-bold px-6 py-2 border-2 rounded border-black mr-10" />
                                 <asp:Button ID="btnSaveChanges" runat="server" Text="Save Changes" OnClick="btnSaveChanges_Click" CssClass="font-bold px-6 py-2 border-2 rounded border-black" />
                             </span>

                         </div>

                     </div>
                 </div>
             </asp:View>
         </asp:MultiView>
        </div>  
</asp:Content>

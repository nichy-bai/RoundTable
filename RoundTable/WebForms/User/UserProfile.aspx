<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/RoundTable_master.Master" AutoEventWireup="true" CodeBehind="UserProfile.aspx.cs" Inherits="RoundTable.WebForms.User.UserProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../../Content/css/UserProfile.css" rel="stylesheet" />
    <script src="http://code.jquery.com/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">
		function ImagePreview(input) {
			if (input.files && input.files[0]) {
				var reader = new FileReader();
				reader.onload = function (e) {
					$('#<%=uploadImg.ClientID%>').prop('src', e.target.result)
						.width(300)
						.height("auto");
				};
				reader.readAsDataURL(input.files[0]);
			}
		}
    </script>
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
        class="mt-0 m-5 p-5 px-6 bg-white rounded-lg flex flex-col shadow-md h-auto dark:bg-dark-200 dark:text-gray-200 transition ease-in-out duration-1000">
        <asp:MultiView ID="MultiViewProfile" runat="server">
            <%--ProfileView--%>
            <asp:View ID="ProfileView" runat="server">
                <div class="relative px-0 flex flex-row flex-grow flex-wrap">
                    <div class="items-start w-40 min-w-full sm:min-w-0">
                        <div class="flex flex-row justify-center">
                            <div>
                                <asp:Image ID="imgProfilePic" runat="server" class="profile-pic" />
                                <%--<asp:ImageButton ID="profilePic" runat="server" CssClass="img-raised profileimg" ImageUrl="" data-toggle="modal" data-target="#modalForm" OnClientClick="return false;" BorderStyle="None" />--%>
                            </div>
                        </div>
                    </div>
                    <div class="flex flex-col flex-1">
                        <div class="flex flex-row justify-between">
                            <div>
                                <asp:Label ID="lblName" runat="server" Text="" CssClass="text-3xl ml-10 font-bold"></asp:Label>
                            </div>
                            <div class="right-0 absolute">
                                <asp:Button ID="btnEditProfile" runat="server" Text="Edit Profile" OnClick="btnEditProfile_Click" CssClass="editProfile-btn <%--font-bold px-6 py-2 border-2 rounded border-black--%>" />
                            </div>
                        </div>

                        <div class="flex flex-wrap text-xl ml-10 mt-10 font-bold">
                            Topic Posted
                             <asp:Label ID="lblTopicPosted" runat="server" Text="" CssClass="ml-5 text-lg font-medium"></asp:Label>
                        </div>
                        <div class="flex flex-wrap text-xl ml-10 mt-10 font-bold justify-between">
                            Gender
                             <asp:Label ID="lblGender" runat="server" Text="" CssClass="mr-16 text-lg font-normal"></asp:Label>
                        </div>
                        <div class="flex flex-wrap text-xl ml-10 font-bold justify-between">
                            Date Of Birth
                             <asp:Label ID="lblDOB" runat="server" Text="" CssClass="mr-16 text-lg font-normal"></asp:Label>
                        </div>
                        <div class="flex flex-wrap text-xl ml-10 font-bold justify-between">
                            Email
                             <asp:Label ID="lblEmail" runat="server" Text="" CssClass="mr-16 text-lg font-normal"></asp:Label>
                        </div>
                        <div class="flex flex-wrap text-xl flex-col ml-10 font-bold justify-between">
                            <div>
                                Profile Description
                            </div>
                            <div>
                                <%--<asp:Label ID="lblProfileDesc" runat="server" Text="" CssClass="mr-48 text-lg font-normal border-2"></asp:Label>--%>
                                <asp:TextBox ID="txtProfileViewDesc" Text="adasd" Enabled="false" runat="server" BorderStyle="None" BackColor="Transparent" ReadOnly="true" CssClass="w-full"></asp:TextBox>
                            </div>
                        </div>

                    </div>
                </div>
            </asp:View>
            <%--EditProfileView--%>
            <asp:View ID="EditProfileView" runat="server">
                <div class="relative px-0 flex flex-row flex-grow flex-wrap">
                    <div class="items-start w-40 min-w-full sm:min-w-0">
                        <div class="flex flex-col justify-center items-center">
                            <div>
                                <asp:Image ID="profilePicture" runat="server" class="profile-pic" />
                            </div>
                        </div>
                    </div>
                    <div class="flex flex-col flex-1">
                        <%--<div class="flex text-xl ml-10 mt-10 font-bold">Topic Posted
                    <asp:Label ID="lblTopicPosted1" runat="server" Text="" CssClass="ml-5 text-lg font-medium"></asp:Label>
                         </div>--%>
                        <div class="flex ml-10 justify-between space-x-3">
                            <div class="text-xl font-bold w-1/5">
                                Name
                            </div>
                            <div class="w-4/5">
                                <asp:TextBox ID="txtName" runat="server" placeholder="Name" ToolTip="Name" CssClass="w-full p-2 border-2 rounded-lg cursor-pointer hover:bg-gray-100 transition ease-in-out duration-300"></asp:TextBox>
                            </div>
                        </div>
                        <div class="flex ml-10 mt-3 justify-between space-x-3">
                            <div class="text-xl font-bold w-1/5">
                                Profile Photo
                            </div>
                            <div class="w-4/5">
                                <asp:FileUpload ID="FileUpload" runat="server" CssClass="w-full cursor-pointer inline-flex items-center px-4 py-2 bg-white rounded-md font-semibold text-xs text-gray-700 uppercase tracking-widest hover:text-gray-500 active:text-gray-800 active:bg-gray-50 transition ease-in-out duration-150 ml-2" onchange="ImagePreview(this);" />
                                <asp:Image ID="uploadImg" runat="server" CssClass="border-2" />
                            </div>
                        </div>
                        <%--<div>
                                 <asp:Button ID="btnUpload" runat="server" Text="Upload Photo" CssClass="cursor-pointer inline-flex items-center px-4 py-2 bg-white border border-gray-300 rounded-md font-semibold text-xs text-gray-700 uppercase tracking-widest shadow-sm hover:text-gray-500 focus:outline-none focus:border-blue-400 focus:shadow-outline-blue active:text-gray-800 active:bg-gray-50 transition ease-in-out duration-150 ml-2" OnClick="btnUpload_Click"/>
                             </div>--%>
                        <%--<div class="flex ml-10 justify-between space-x-6">
                             <div class="text-xl font-bold w-1/5">
                                 Profile Picture
                             </div>
                             <div class="w-4/5">
                                 <asp:TextBox ID="TextBox1" runat="server" placeholder="Name" ToolTip="Name" CssClass="w-full p-2 border-2 rounded-lg cursor-pointer hover:bg-gray-100 transition ease-in-out duration-300"></asp:TextBox>
                             </div>
                         </div>--%>
                        <div class="flex ml-10 mt-3 justify-between space-x-3">
                            <div class="text-xl font-bold w-1/5">
                                Gender
                            </div>
                            <div class="w-4/5">
                                <asp:DropDownList ID="ddlGender" runat="server" ToolTip="Gender" CssClass="w-full p-2 border-2 rounded-lg cursor-pointer hover:bg-gray-100 transition ease-in-out duration-300">
                                    <asp:ListItem Value="-">Select Gender</asp:ListItem>
                                    <asp:ListItem Value="M">Male</asp:ListItem>
                                    <asp:ListItem Value="F">Female</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="flex ml-10 mt-3 justify-between space-x-3">
                            <div class="text-xl font-bold w-1/5">
                                D.O.B
                            </div>
                            <div class="w-4/5">
                                <asp:TextBox ID="txtDOB" runat="server" placeholder="Date Of Birth" TextMode="Date" ToolTip="Date Of Birth" CssClass="w-full p-2 border-2 rounded-lg cursor-pointer hover:bg-gray-100 transition ease-in-out duration-300"></asp:TextBox>
                            </div>
                        </div>
                        <div class="flex ml-10 mt-3 justify-between space-x-3">
                            <div class="text-xl font-bold w-1/5">
                                Email
                            </div>
                            <div class="w-4/5">
                                <asp:TextBox ID="txtEmail" runat="server" placeholder="Email" TextMode="Email" ToolTip="Email" CssClass="w-full p-2 border-2 rounded-lg cursor-pointer hover:bg-gray-100 transition ease-in-out duration-300"></asp:TextBox>
                            </div>
                        </div>
                        <div class="flex text-xl ml-10 mt-6 font-bold justify-between">
                            Profile Description
                        </div>
                        <div class="ml-10 mt-2">
                            <asp:TextBox ID="txtProfileDesc" runat="server" placeholder="Profile Description (Optional)" TextMode="MultiLine" ToolTip="Profile Description" CssClass="overflow-auto min-h-20 h-64 w-full p-2 border-2 rounded-lg cursor-pointer hover:bg-gray-100 transition ease-in-out duration-300"></asp:TextBox>
                        </div>
                        <div class="flex justify-end mt-4">
                            <span>
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" CssClass="cancel-btn font-bold px-6 py-2 border-2 rounded border-black" />
                                <asp:Button ID="btnSaveChanges" runat="server" Text="Save Changes" OnClick="btnSaveChanges_Click" CssClass="save-btn font-bold px-6 py-2 border-2 rounded border-black" />
                            </span>

                        </div>

                    </div>
                </div>
            </asp:View>
        </asp:MultiView>
    </div>  
</asp:Content>

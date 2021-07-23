<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/RoundTable_master.Master" AutoEventWireup="true" CodeBehind="Notification.aspx.cs" Inherits="RoundTable.WebForms.User.Notification" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <header
        class="relative m-5 mt-0 px-5 py-4 bg-white rounded-lg flex flex-row shadow-md h-auto transition ease-in-out duration-1000">
        <div class="relative px-0 flex flex-row flex-grow">
            <div class="flex flex-col justify-center">
                <span class="block text-4xl font-bold mb-2 font-title text-gray-700">Notifications</span>
                <span class="block opacity-80">All your notifications</span>
            </div>
        </div>
    </header>

    <asp:Label ID="noPost_lbl" runat="server" Text="No notification yet" Visible="false" CssClass="flex justify-center items-center text-gray-700 font-medium text-lg my-10"></asp:Label>

    <div runat="server" id="notifications_div"
        class="mt-0 m-5 p-5 px-6 bg-white rounded-lg flex flex-col shadow-md h-auto transition ease-in-out duration-1000">

        
        <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1">
            <ItemTemplate>
                <div class="flex flex-row justify-between items-center py-4 border-b-2">
                    <div class="flex justify-start items-center">
                        <asp:Image ID="post_user_img" runat="server" ImageUrl='<%#Eval("profilePicture") %>' CssClass="w-12 h-12 rounded-full" />
                        <asp:Label ID="notificationContent" runat="server" Text='<%#Eval("notificationContent") %>' CssClass="ml-5"></asp:Label>
                    </div>
                    <div class="flex justify-end items-center">
                        <asp:Label ID="notification_DateTime" runat="server" Text='<%#Eval("notificationDate") %>' CssClass="mr-5"></asp:Label>
                        <asp:LinkButton ID="delete_notification_btn" runat="server" ToolTip="Remove Notification" CssClass="text-gray-500 hover:text-indigo-600 transition ease-in-out duration-300" CommandArgument='<%#Eval("ID") %>' OnCommand="delete_notification_btn_Command" OnClientClick="return confirm('Are you sure to remove this notification?')">
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
                                    d="M6 18L18 6M6 6l12 12">
                                </path>
                            </svg>
                        </asp:LinkButton>
                    </div>
                </div>

            </ItemTemplate>
        </asp:Repeater>
        <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:ConnectionString %>' SelectCommand="SELECT TOP(20) Notification.ID, Notification.userID, Notification.notificationContent, Notification.notificationDate, Notification.postUserID, [User].profilePicture FROM Notification INNER JOIN [User] ON Notification.userID = [User].userID AND Notification.userID = [User].userID WHERE (Notification.postUserID = @postUserID)">
            <SelectParameters>
                <asp:SessionParameter SessionField="UserID" Name="postUserID" Type="String"></asp:SessionParameter>
            </SelectParameters>
        </asp:SqlDataSource>
    </div>
</asp:Content>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginError.aspx.cs" Inherits="RoundTable.LoginError" %>

<!DOCTYPE html>

<html lang="en">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <title>Login to continue</title>
    <link href="~/Content/icons/favicon.png" rel="icon" />
    <link href="~/Content/css/style.css" rel="stylesheet" />
    <link rel="preconnect" href="https://fonts.gstatic.com">
    <link href="https://fonts.googleapis.com/css2?family=Roboto:ital,wght@0,100;0,300;0,400;0,500;0,700;0,900;1,100;1,300;1,400;1,500;1,700;1,900&display=swap" rel="stylesheet">
    <link href="https://unpkg.com/tailwindcss@^2/dist/tailwind.min.css" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
        <div class="flex flex-col w-screen h-screen justify-center items-center">
            <div class="my-10 flex justify-center items-center">
                <img src="../../Content/img/login_illustration_1.svg" alt="illustration_1" class="w-11/12 md:w-4/5 h-auto">
            </div>
            <p class="text-md md:text-xl p-2 mb-10 font-medium text-gray-700">You must login in order to access this feature.</p>
            <div class="flex flex-row justify-center space-x-6">
                <a href="User/UserLogin.aspx"
                    class="bg-indigo-600 hover:bg-white text-white hover:text-indigo-600 rounded-lg shadow-md py-2 px-4 border-2 border-indigo-600 transition ease-in-out duration-300">Login</a>
                <a href="User/UserRegistration.aspx"
                    class="bg-transparent hover:bg-indigo-600 text-indigo-600 hover:text-white rounded-lg shadow-md py-2 px-4 border-2 border-indigo-600 transition ease-in-out duration-300">Sign Up</a>
            </div>
            <a href="Discussion/Homepage.aspx" class="text-indigo-500 flex flex-row justify-center items-center mt-10 hover:opacity-80 transition ease-in-out duration-300">
                <svg class="w-6 h-6"
                    fill="none"
                    stroke="currentColor"
                    viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg">
                    <path
                        stroke-linecap="round"
                        stroke-linejoin="round"
                        stroke-width="1.5"
                        d="M7 16l-4-4m0 0l4-4m-4 4h18">
                    </path>
                </svg>
                <span class="mx-1 font-title text-sm">Back to homepage</span>
            </a>

        </div>
    </form>
</body>
</html>

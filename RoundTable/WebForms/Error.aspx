<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="RoundTable.WebForms.Error" %>

<!DOCTYPE html>

<html lang="en">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <title>Error</title>
    <link href="~/Content/icons/favicon.png" rel="icon" />
    <link href="~/Content/css/style.css" rel="stylesheet" />
    <link rel="preconnect" href="https://fonts.gstatic.com">
    <link href="https://fonts.googleapis.com/css2?family=Roboto:ital,wght@0,100;0,300;0,400;0,500;0,700;0,900;1,100;1,300;1,400;1,500;1,700;1,900&display=swap" rel="stylesheet">
    <link href="https://unpkg.com/tailwindcss@^2/dist/tailwind.min.css" rel="stylesheet">
</head>
<body>
    <div class="min-w-screen min-h-screen bg-indigo-200 flex items-center p-5 lg:p-20 overflow-hidden relative">
        <div class="flex-1 min-h-full min-w-full rounded-3xl bg-white shadow-xl p-10 lg:p-20 text-gray-800 relative md:flex items-center text-center md:text-left">
            <div class="w-full md:w-1/2">
                <div class="mb-10 lg:mb-20">
                    <a href="Discussion/Homepage.aspx" class="text-gray-700 transition ease-in-out duration-300 flex items-center font-bold text-2xl justify-center md:justify-start">
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
                        <span class="ml-2">RoundTable</span>
                    </a>
                </div>
                <div class="mb-10 md:mb-20 text-gray-600 font-normal">
                    <h1 class="font-bold uppercase text-5xl lg:text-5xl text-indigo-300 mb-5 md:mb-2">Oops! </h1>
                    <h1 class="font-bold uppercase text-3xl lg:text-4xl text-indigo-500 mb-10">An error has occurred.</h1>
                    <p>The page you're looking for isn't available.</p>
                    <p>If the problem persists, please contact us via <a href="mailto:roundtable.cs@gmail.com" class="underline hover:text-indigo-500 transition ease-in-out duration-300">email</a> or the <a href="Support/Feedback.aspx" class="underline hover:text-indigo-500 transition ease-in-out duration-300">feedback</a> function.</p>
                </div>
                <div class="mb-20 md:mb-0">
                    <a href="Discussion/Homepage.aspx" class="text-indigo-500 flex flex-row md:justify-start justify-center items-center mt-10 hover:opacity-80 transition ease-in-out duration-300 text-md">
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
                        <span class="mx-1 font-title">Back to homepage</span>
                    </a>
                </div>
            </div>
            <div class="w-full md:w-1/2 text-center">
                <img src="../../Content/img/error_illustration_1.svg" alt="illustration_1" class="w-full max-w-lg lg:max-w-full mx-auto">
            </div>
        </div>
        <div class="w-64 md:w-96 h-96 md:h-full bg-indigo-200 bg-opacity-20 absolute -top-64 md:-top-96 right-20 md:right-32 rounded-full pointer-events-none -rotate-45 transform"></div>
        <div class="w-96 h-full bg-indigo-200 bg-opacity-20 absolute -bottom-96 right-64 rounded-full pointer-events-none -rotate-45 transform"></div>
    </div>
</body>
</html>

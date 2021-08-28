<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="RoundTable.WebForms.User.ForgotPassword" %>

<!DOCTYPE html>

<html lang="en">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <title>RoundTable</title>
    <link href="~/Content/icons/favicon.png" rel="icon" />
    <link href="~/Content/css/style.css" rel="stylesheet" />
    <link rel="preconnect" href="https://fonts.gstatic.com" />
    <link href="https://fonts.googleapis.com/css2?family=Roboto:ital,wght@0,100;0,300;0,400;0,500;0,700;0,900;1,100;1,300;1,400;1,500;1,700;1,900&display=swap" rel="stylesheet" />
    <link href="https://unpkg.com/tailwindcss@^2/dist/tailwind.min.css" rel="stylesheet" />
    <link href="../../Content/css/UserLoginRegister.css" rel="stylesheet" />
    <style>
        .input {
            transition: border 0.2s ease-in-out;
            min-width: 280px
        }

            .input:focus + .label,
            .input:active + .label,
            .input.filled + .label {
                font-size: .75rem;
                transition: all 0.2s ease-out;
                top: -0.1rem;
                color: #667eea;
            }

        .label {
            transition: all 0.2s ease-out;
            top: 0.4rem;
            left: 0;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="h-screen flex flex-row justify-center items-center bg-indigo-400 overflow-y-auto overflow-x-hidden sm:overflow-hidden">
            <div class="shadow-xl py-6 bg-white max-w-xl rounded-lg">
                <div class="flex flex-col justify-center px-10">
                    <div class="flex justify-center items-center text-2xl font-black mb-6">
                        <a href="../Discussion/Homepage.aspx" class="hover:text-indigo-600 transition ease-in-out duration-300" title="Back to homepage">
                            <svg
                                width="45"
                                height="45"
                                viewBox="0 0 500 500"
                                fill="none"
                                xmlns="http://www.w3.org/2000/svg">
                                <path
                                    fill-rule="evenodd"
                                    clip-rule="evenodd"
                                    d="M500 250.594C500 297.339 487.232 341.094 465 378.547V255.361V239.927L451.202 233.011L261.702 138.03L250.5 132.416L239.298 138.03L49.7979 233.011L36 239.927V255.361V380.217C13.1518 342.397 0 298.035 0 250.594C0 112.195 111.929 0 250 0C388.071 0 500 112.195 500 250.594ZM415 295.856V438.861C376.969 472.377 328.698 494.498 275.5 499.9V365.776L415 295.856ZM225.5 365.776V500C172.372 494.82 124.115 472.971 86 439.738V295.856L225.5 365.776Z"
                                    fill="currentColor" />
                            </svg>
                        </a>
                        <span class="ml-2">Forgot Password</span>
                    </div>
                    <div class="flex flex-col">
                        <div class="mb-8 relative">
                            <asp:TextBox ID="txtUserID" runat="server" CssClass="input border border-gray-400 appearance-none rounded-lg px-3 py-3 pt-5 pb-2 focus focus:border-indigo-600 focus:outline-none active:outline-none active:border-indigo-600"></asp:TextBox>
                            <label for="txtUserID" class="label absolute mb-0 -mt-2 pt-4 pl-3 leading-tighter text-gray-400 text-base mt-2 cursor-text">Username</label>
                            <div class="absolute">
                                <asp:RequiredFieldValidator ID="rfvName" runat="server" ErrorMessage="Username is required." ControlToValidate="txtUserID" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="mb-8 relative">
                            <asp:TextBox ID="txtNewPassword" runat="server" type="password" CssClass="input border border-gray-400 appearance-none rounded-lg px-3 py-3 pt-5 pb-2 focus focus:border-indigo-600 focus:outline-none active:outline-none active:border-indigo-600"></asp:TextBox>
                            <label for="txtNewPassword" class="label absolute mb-0 -mt-2 pt-4 pl-3 leading-tighter text-gray-400 text-base mt-2 cursor-text">New Password</label>
                            <div class="">
                                <div class="absolute"><asp:RequiredFieldValidator ID="rfvPassword" runat="server" ErrorMessage="Password is required." ControlToValidate="txtNewPassword" ForeColor="Red"></asp:RequiredFieldValidator></div>
                                <div class="absolute"><asp:RegularExpressionValidator ID="revPassword" runat="server" ErrorMessage="Must between 6 to 20 characters." ControlToValidate="txtNewPassword" ForeColor="Red" ValidationExpression="^.{6,20}$"></asp:RegularExpressionValidator></div>
                            </div>
                        </div>
                        <div class="mb-8 relative">
                            <asp:TextBox ID="txtConfirmPassword" runat="server" type="password" CssClass="input border border-gray-400 appearance-none rounded-lg px-3 py-3 pt-5 pb-2 focus focus:border-indigo-600 focus:outline-none active:outline-none active:border-indigo-600"></asp:TextBox>
                            <label for="txtConfirmPassword" class="label absolute mb-0 -mt-2 pt-4 pl-3 leading-tighter text-gray-400 text-base mt-2 cursor-text">Confirm Password</label>
                            <div class="absolute">
                                <asp:RequiredFieldValidator ID="rfvConfirmPassword" runat="server" ErrorMessage="Confirm Password is required." ControlToValidate="txtConfirmPassword" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                            <div class="absolute">
                                <asp:CompareValidator ID="cvPassword" runat="server" ErrorMessage="Password not matched." ControlToCompare="txtNewPassword" ControlToValidate="txtConfirmPassword" ForeColor="Red"></asp:CompareValidator>
                            </div>
                        </div>
                        <div class="flex flex-row justify-evenly items-center space-x-4 relative">
                            <div class="relative">
                                <asp:TextBox ID="txtVerificationCode" runat="server" TextMode="Password" CssClass="input border border-gray-400 appearance-none rounded-lg px-3 py-3 pt-5 pb-2 focus focus:border-indigo-600 focus:outline-none active:outline-none active:border-indigo-600"></asp:TextBox>
                                <label for="txtVerificationCode" class="label absolute mb-0 -mt-2 pt-4 pl-3 leading-tighter text-gray-400 text-base mt-2 cursor-text">Verification Code</label>
                            </div>
                            <div class="absolute p-1 right-0">
                                <asp:Button ID="btnGetCode" runat="server" Text="Get Code" CssClass="bg-white border-2 border-indigo-600 text-indigo-600 p-2 font-bold rounded-lg text-sm font-thin cursor-pointer hover:bg-indigo-600 hover:text-white hover:shadow-md transition ease-in-out duration-300" OnClick="btnGetCode_Click" />
                            </div>
                        </div>

                        <div class="mb-4 w-64">
                            <asp:Label ID="lblGetCode" runat="server" Text="" CssClass="mb-2 text-gray-700"></asp:Label>
                        </div>

                        <div class="mb-4 w-full">
                            <asp:Button ID="btnChangePassword" runat="server" Text="Change Password" CssClass="login-btn font-bold py-3 px-6 rounded-lg" OnClick="btnChangePassword_Click" />
                        </div>
                        <div class="flex justify-center border-t border-gray-400 my-2 pt-2">
                            Already on RoundTable?<span><a href="UserLogin.aspx" style="text-decoration: none" class="ml-1 font-bold hover:text-indigo-600">Login</a></span>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
    <script>
        var toggleInputContainer = function (input) {
            if (input.value != "") {
                input.classList.add('filled');
            } else {
                input.classList.remove('filled');
            }
        }

        var labels = document.querySelectorAll('.label');
        for (var i = 0; i < labels.length; i++) {
            labels[i].addEventListener('click', function () {
                this.previousElementSibling.focus();
            });
        }

        window.addEventListener("load", function () {
            var inputs = document.getElementsByClassName("input");
            for (var i = 0; i < inputs.length; i++) {
                console.log('looped');
                inputs[i].addEventListener('keyup', function () {
                    toggleInputContainer(this);
                });
                toggleInputContainer(inputs[i]);
            }
        });
    </script>
</body>
</html>

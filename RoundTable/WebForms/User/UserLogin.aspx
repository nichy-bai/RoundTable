<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserLogin.aspx.cs" Inherits="RoundTable.WebForms.User.UserLogin" %>

<!DOCTYPE html>

<html lang="en">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <title>RoundTable</title>
    <link href="~/Content/icons/favicon.png" rel="icon" />
    <link href="~/Content/css/style.css" rel="stylesheet" />
    <link rel="preconnect" href="https://fonts.gstatic.com">
    <link href="https://fonts.googleapis.com/css2?family=Roboto:ital,wght@0,100;0,300;0,400;0,500;0,700;0,900;1,100;1,300;1,400;1,500;1,700;1,900&display=swap" rel="stylesheet">
    <link href="https://unpkg.com/tailwindcss@^2/dist/tailwind.min.css" rel="stylesheet">
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
        <div class="h-screen flex flex-row justify-center items-center bg-indigo-400 overflow-y-auto sm:overflow-hidden">
            <div class="shadow-xl p-10 bg-white max-w-xl rounded-lg">
                <div class="flex flex-col justify-center">
                    <div class="flex justify-center items-center text-4xl font-black mb-6">
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
                        <span class="ml-2">Login</span>
                    </div>
                    <asp:Label ID="lblLoginStatus" runat="server" Text="" CssClass=" text-red-600 mb-2"></asp:Label>
                    <div class="mb-8 relative">
                        <asp:TextBox ID="txtUserID" runat="server" CssClass="input border border-gray-400 appearance-none rounded-lg w-full px-3 py-3 pt-5 pb-2 focus focus:border-indigo-600 focus:outline-none active:outline-none active:border-indigo-600"></asp:TextBox>
                        <label for="txtUserID" class="label absolute mb-0 -mt-2 pt-4 pl-3 leading-tighter text-gray-400 text-base mt-2 cursor-text">Username</label>
                        <div class="absolute"><asp:RequiredFieldValidator ID="rfvUserID" runat="server" ErrorMessage="Username is required." ControlToValidate="txtUserID" ForeColor="Red"></asp:RequiredFieldValidator></div>
                        <div class="absolute"><asp:RegularExpressionValidator ID="revUserID" runat="server" ErrorMessage="Username must between 3 to 12 characters." ControlToValidate="txtUserID" ForeColor="Red" ValidationExpression="(\s|.){3,12}"></asp:RegularExpressionValidator></div>
                    </div>
                    <div class="mb-6 relative">
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="input border border-gray-400 appearance-none rounded-lg w-full px-3 py-3 pt-5 pb-2 focus focus:border-indigo-600 focus:outline-none active:outline-none active:border-indigo-600"></asp:TextBox>
                        <label for="txtPassword" class="label absolute mb-0 -mt-2 pt-4 pl-3 leading-tighter text-gray-400 text-base mt-2 cursor-text">Password</label>
                        <div class="absolute"><asp:RequiredFieldValidator ID="rfvPassword" runat="server" ErrorMessage="Password is required." ControlToValidate="txtPassword" ForeColor="Red"></asp:RequiredFieldValidator></div>
                    </div>
                    <div class="mb-4 relative">
                        <asp:LinkButton ID="btnForgotPassword" runat="server" CssClass="hover:underline text-sm" OnClick="btnForgotPassword_Click" Text="Forgot Password?"></asp:LinkButton>
                    </div>
                    <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="login-btn font-bold py-3 px-6 rounded-lg" OnClick="btnLogin_Click" />
                    <div class="flex justify-center border-t border-gray-400 mt-8 pt-5">
                        New to RoundTable?<span><a href="UserRegistration.aspx" style="text-decoration: none" class="ml-1 font-bold hover:text-indigo-600 transition ease-in-out duration-300">Sign Up</a></span>
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

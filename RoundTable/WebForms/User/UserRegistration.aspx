<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserRegistration.aspx.cs" Inherits="RoundTable.WebForms.User.UserRegistration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
        <div class="h-screen flex flex-row justify-center items-center bg-indigo-400">
            <div class="shadow-xl p-10 bg-white max-w-xl rounded">
                <div class="flex flex-col justify-center">
                    <div class="flex justify-center text-4xl font-black mb-6">Sign Up</div>
                    <asp:Label ID="lblSignUpStatus" runat="server" Text="" CssClass=" text-red-600 mb-2"></asp:Label>
                    <div class="mb-4 relative">
                        <asp:TextBox ID="txtName" runat="server" CssClass="input border border-gray-400 appearance-none rounded w-full px-3 py-3 pt-5 pb-2 focus focus:border-indigo-600 focus:outline-none active:outline-none active:border-indigo-600"></asp:TextBox>
                        <label for="txtName" class="label absolute mb-0 -mt-2 pt-4 pl-3 leading-tighter text-gray-400 text-base mt-2 cursor-text">Name</label>
                    </div>
                    <div class="mb-4 relative">
                        <asp:TextBox ID="txtUserID" runat="server" CssClass="input border border-gray-400 appearance-none rounded w-full px-3 py-3 pt-5 pb-2 focus focus:border-indigo-600 focus:outline-none active:outline-none active:border-indigo-600"></asp:TextBox>
                        <label for="txtUserID" class="label absolute mb-0 -mt-2 pt-4 pl-3 leading-tighter text-gray-400 text-base mt-2 cursor-text">Username</label>
                    </div>
                    <div class="mb-4 relative">
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="input border border-gray-400 appearance-none rounded w-full px-3 py-3 pt-5 pb-2 focus focus:border-indigo-600 focus:outline-none active:outline-none active:border-indigo-600"></asp:TextBox>
                        <label for="txtEmail" class="label absolute mb-0 -mt-2 pt-4 pl-3 leading-tighter text-gray-400 text-base mt-2 cursor-text">Email</label>
                    </div>
                    <div class="mb-4 relative">
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="input border border-gray-400 appearance-none rounded w-full px-3 py-3 pt-5 pb-2 focus focus:border-indigo-600 focus:outline-none active:outline-none active:border-indigo-600"></asp:TextBox>
                        <label for="txtPassword" class="label absolute mb-0 -mt-2 pt-4 pl-3 leading-tighter text-gray-400 text-base mt-2 cursor-text">Password</label>
                    </div>
                    <div class="mb-4 relative">
                        <asp:TextBox ID="txtDOB" runat="server" TextMode="Date" CssClass="input border border-gray-400 appearance-none rounded w-full px-3 pt-6 pb-2 focus focus:border-indigo-600 focus:outline-none active:outline-none active:border-indigo-600"></asp:TextBox>
                        <label for="txtDOB" class="label absolute mb-0 -mt-2 pt-4 pl-3 leading-tighter text-gray-400 text-base mt-2 cursor-text">Date Of Birth</label>
                    </div>
                    <div class="mb-4 relative">
                        <div class="text-gray-400 text-base">Gender</div>
                        <asp:RadioButtonList ID="rblGender" runat="server" RepeatDirection="Vertical" RepeatLayout="Flow" CssClass="">
                            <asp:ListItem Value="M">Male</asp:ListItem>
                            <asp:ListItem Value="F">Female</asp:ListItem>
                            <asp:ListItem Value="-">Prefer not to say</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                    <asp:Button ID="btnSignUp" runat="server" Text="Sign Up" CssClass="login-btn font-bold py-3 px-6 rounded" OnClick="btnSignUp_Click" />
                    <div class="flex justify-center border-t border-gray-400 mt-8 pt-5">
                        Already on RoundTable?<span><a href="UserLogin.aspx" style="text-decoration:none" class="ml-1 font-bold hover:text-indigo-600">Login</a></span>
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

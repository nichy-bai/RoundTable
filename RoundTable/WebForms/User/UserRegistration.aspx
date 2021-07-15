<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserRegistration.aspx.cs" Inherits="RoundTable.WebForms.User.UserRegistration" %>

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
        <div class="h-screen flex flex-row justify-center items-center bg-indigo-400 overflow-y-auto sm:overflow-hidden">
            <div class="shadow-xl py-6 bg-white max-w-xl rounded-lg">
                <div class="flex flex-col justify-center px-16">
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
                        <span class="ml-2">Sign Up</span>
                    </div>
                    
                    <div class="mb-12 relative">
                        <asp:TextBox ID="txtName" runat="server" CssClass="input border border-gray-400 appearance-none rounded-lg w-full px-3 py-3 pt-5 pb-2 focus focus:border-indigo-600 focus:outline-none active:outline-none active:border-indigo-600"></asp:TextBox>
                        <label for="txtName" class="label absolute mb-0 -mt-2 pt-4 pl-3 leading-tighter text-gray-400 text-base mt-2 cursor-text">Name</label>
                        <div class="absolute"><asp:RequiredFieldValidator ID="rfvName" runat="server" ErrorMessage="Name is required." ControlToValidate="txtName" ForeColor="Red"></asp:RequiredFieldValidator></div>
                    </div>
                    <div class="mb-12 relative">
                        <asp:TextBox ID="txtUserID" runat="server" CssClass="input border border-gray-400 appearance-none rounded-lg w-full px-3 py-3 pt-5 pb-2 focus focus:border-indigo-600 focus:outline-none active:outline-none active:border-indigo-600"></asp:TextBox>
                        <label for="txtUserID" class="label absolute mb-0 -mt-2 pt-4 pl-3 leading-tighter text-gray-400 text-base mt-2 cursor-text">Username</label>
                        <div class="absolute"><asp:RequiredFieldValidator ID="rfvUserID" runat="server" ErrorMessage="Username is required." ControlToValidate="txtUserID" ForeColor="Red"></asp:RequiredFieldValidator></div>
                        <div class="absolute"><asp:RegularExpressionValidator ID="revUserID" runat="server" ErrorMessage="Must between 3 to 12 characters." ControlToValidate="txtUserID" ForeColor="Red" ValidationExpression="(\s|.){3,12}"></asp:RegularExpressionValidator></div>
                        <div class="absolute mt-6"><asp:RegularExpressionValidator ID="revUserChar" runat="server" ErrorMessage="Cannot contain special characters." ControlToValidate="txtUserID" ForeColor="Red" ValidationExpression="[a-zA-Z0-9]*[^!@%~?:#$%^&*()0']"></asp:RegularExpressionValidator></div>
                        <div class="absolute"><asp:Label ID="lblSignUpStatus" runat="server" Text="" ForeColor="Red"></asp:Label></div>
                    </div>
                    <div class="mb-12 relative">
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="input border border-gray-400 appearance-none rounded-lg w-full px-3 py-3 pt-5 pb-2 focus focus:border-indigo-600 focus:outline-none active:outline-none active:border-indigo-600"></asp:TextBox>
                        <label for="txtEmail" class="label absolute mb-0 -mt-2 pt-4 pl-3 leading-tighter text-gray-400 text-base mt-2 cursor-text">Email</label>
                        <div class="absolute"><asp:RequiredFieldValidator ID="rfvEmail" runat="server" ErrorMessage="Email is required." ControlToValidate="txtEmail" ForeColor="Red"></asp:RequiredFieldValidator></div>
                        <div class="absolute"><asp:RegularExpressionValidator ID="revEmail" runat="server" ErrorMessage="Invalid email. Please enter email as name@email.com" ControlToValidate="txtEmail" ForeColor="Red" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"></asp:RegularExpressionValidator></div>
                    </div>
                    <div class="mb-12 relative">
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="input border border-gray-400 appearance-none rounded-lg w-full px-3 py-3 pt-5 pb-2 focus focus:border-indigo-600 focus:outline-none active:outline-none active:border-indigo-600"></asp:TextBox>
                        <label for="txtPassword" class="label absolute mb-0 -mt-2 pt-4 pl-3 leading-tighter text-gray-400 text-base mt-2 cursor-text">Password</label>
                        <div class="absolute"><asp:RequiredFieldValidator ID="rfvPassword" runat="server" ErrorMessage="Password is required." ControlToValidate="txtPassword" ForeColor="Red"></asp:RequiredFieldValidator></div>
                        <%--<div class="absolute"><asp:Label ID="lblPasswordValidation" runat="server" Text="" ForeColor="Red"></asp:Label></div>--%>
                        <div class="absolute"><asp:RegularExpressionValidator ID="revPassword" runat="server" ErrorMessage="Must between 6 to 20 characters." ControlToValidate="txtPassword" ForeColor="Red" ValidationExpression="^.{4,20}$"></asp:RegularExpressionValidator></div>
                    </div>
                    <div class="mb-12 relative">
                        <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" CssClass="input border border-gray-400 appearance-none rounded-lg w-full px-3 py-3 pt-5 pb-2 focus focus:border-indigo-600 focus:outline-none active:outline-none active:border-indigo-600"></asp:TextBox>
                        <label for="txtConfirmPassword" class="label absolute mb-0 -mt-2 pt-4 pl-3 leading-tighter text-gray-400 text-base mt-2 cursor-text">Confirm Password</label>
                        <div class="absolute"><asp:RequiredFieldValidator ID="rfvConfirmPassword" runat="server" ErrorMessage="Confirm Password is required." ControlToValidate="txtConfirmPassword" ForeColor="Red"></asp:RequiredFieldValidator></div>
                        <div class="absolute"><asp:CompareValidator ID="cvPassword" runat="server" ErrorMessage="Password not matched." ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword" ForeColor="Red"></asp:CompareValidator></div>
                    </div>
                    <%--<div class="mb-4 relative">
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
                    </div>--%>
                    <asp:Button ID="btnSignUp" runat="server" Text="Sign Up" CssClass="login-btn font-bold py-3 px-6 rounded-lg" OnClick="btnSignUp_Click" />
                    <div class="flex justify-center border-t border-gray-400 mt-4 pt-2">
                        Already on RoundTable?<span><a href="UserLogin.aspx" style="text-decoration:none" class="ml-1 font-bold hover:text-indigo-600 transition ease-in-out duration-300">Login</a></span>
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

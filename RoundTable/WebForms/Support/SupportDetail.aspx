<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/RoundTable_master.Master" AutoEventWireup="true" CodeBehind="SupportDetail.aspx.cs" Inherits="RoundTable.WebForms.Support.SupportDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .keyboard {
            border: 1px solid gray;
            font-size: 1rem;
            box-shadow: 1px 0 1px 0 #eee, 0 2px 0 2px #ccc, 0 2px 0 3px #444;
            -webkit-border-radius: 3px;
            -moz-border-radius: 3px;
            border-radius: 3px;
            margin: 2px 3px;
            padding: 1px 5px;
        }
    </style>
    <div
        class="support-body relative m-5 mt-0 px-5 md:px-10 py-4 bg-white rounded-lg flex flex-col shadow-md h-auto transition ease-in-out duration-1000">
        <div class="text-3xl lg:text-5xl font-bold md:mt-5 mb-5 md:mb-20 font-title tracking-wide flex flex-row justify-center items-center py-5 text-gray-800 flex-wrap">
            <a href="Support.aspx">
                <svg
                    class="hidden md:block"
                    width="80"
                    height="80"
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
            <a href="Support.aspx">
                <div class="flex flex-row flex-wrap justify-center">
                    <div class="md:ml-5">RoundTable</div>
                    <div class="flex justify-center items-center opacity-50 tracking-normal">&nbsp;support</div>
                </div>
            </a>
        </div>
        <hr class="md:hidden" />
        <div class="flex flex-row justify-evenly mb-20">
            <%--Body--%>
            <div class="support-content md:w-3/4 lg:w-2/4 text-justify leading-7 md:leading-8 md:pr-10">
                <section id="start">
                    <h2 class="py-5 md:py-10 font-bold text-3xl">Getting Started</h2>
                    <p>RoundTable is the easiest way to start an asynchronous discussion for free and connect with the user through our 🌐global community!</p>
                    <br />
                    <p>With RoundTable, you can <a href="#start-4" class="text-indigo-500 hover:underline">start</a> a discussion or <a href="#start-5" class="text-indigo-500 hover:underline">participate</a> in a discussion with other people on the same topic.</p>
                    <br />

                    <section id="start-1">
                        <h3 class="py-5 md:py-10 font-medium text-2xl">Using RoundTable</h3>
                        <p>In all disciplines, a discussion is essential to learning because it helps individuals interpret knowledge rather than simply obtain it. The purpose of the discussion is to get individuals to practice thinking about the material of the course. In addition to helping individuals learn from each other, encouraging and stimulating conversations and discussions may also help individuals better understand and retain information.</p>
                        <br />
                        <p>By using RoundTable, individuals can start a discussion with their 📱smartphone or 💻computer, which is much easier than conventional methods. As this is an asynchronous form of discussion, individuals may need to wait for responses from others within a certain time frame.</p>
                        <br />
                    </section>

                    <section id="start-2" class="md:mt-10">
                        <h3 class="py-5 md:py-10 font-medium text-2xl">How RoundTable Works</h3>
                        <p>When you start the discussion, RoundTable uses a sorting algorithm to display them on the discussion feed. This allows individuals interested in the same topic to find your posts more easily.</p>
                        <br />
                        <p>We also feature top articles on the ⭐featured and 🔥trending section as homepage content personalization options. Your only focus should be discussion; Roundtable aims to put discussion posts in the spotlight, helping you facilitate discussions and reach the audience you want.</p>
                        <br />
                        <p>RoundTable provides the elements of a learning management system that can support online discussions determined by topics between individuals participating in the online discussions.  At this stage, people can uphold their viewpoints by incorporating various kinds of media. This is the online central point where individuals send messages to discuss specific topics.</p>
                        <br />
                        <p>Each conversation usually contains the original post, which is usually a question, but sometimes contains provocative statements that other individuals have not answered or have not answered in subsequent posts. Online discussions are certainly not the most cutting-edge, but they are typically a good approach to achieve learning objectives, and therefore it is an important tool or platform for an individual to use constructively.</p>
                        <br />
                    </section>

                    <section id="start-3" class="md:mt-10">
                        <h3 class="py-5 md:py-10 font-medium text-2xl">Create an Account</h3>
                        <p>To get started with RoundTable, you need to create a free account on the <a href="../User/UserRegistration.aspx" class="text-indigo-500 hover:underline" target="_blank">registration</a> page. Only some important information is required to create an account, namely your name, account username, email and password.</p>
                        <br />
                        <p>Using your RoundTable account, you can access many functions that are only available to registered users, such as starting discussions, participating in discussions, bookmarking discussion posts, customizing your profile details, and changing your profile picture, and much more.</p>
                        <br />
                        <p>Sign in and Create an account using the passwordless authentication process with your 📧 email address or 👾 social accounts is in our list, which will be added in the future. Stay tuned.</p>
                        <br />
                    </section>

                    <section id="start-4" class="md:mt-10">
                        <h3 class="py-5 md:py-10 font-medium text-2xl">Start A Discussion</h3>
                        <p>You can start a discussion with a powerful rich text editor and distribute your content to all RoundTable users, your followers, and the public who follow tags related to your posts.</p>
                        <br />
                        <p>Here is how to start the discussion on RoundTable:</p>
                        <div class="flex flex-col">
                            <div class="flex flex-row flex-nowrap pl-5 mb-2">
                                <div class="select-none mr-2">1.</div>
                                <div>Log in to your RoundTable account. If you have not registered yet, please click <a href="../User/UserRegistration.aspx" class="text-indigo-500 hover:underline" target="_blank">here</a> to register.</div>
                            </div>
                            <div class="flex flex-row flex-nowrap pl-5 mb-2">
                                <div class="select-none mr-2">2.</div>
                                <div>Click on the Start a discussion... button at the top of your feed.</div>
                            </div>
                            <div class="flex flex-row flex-nowrap pl-5 mb-2">
                                <div class="select-none mr-2">3.</div>
                                <div>You will see a powerful rich text editor appear on the page.</div>
                            </div>
                            <div class="flex flex-row flex-nowrap pl-5 mb-2">
                                <div class="select-none mr-2">4.</div>
                                <div>First, select the relevant topic from the drop-down list provided on the left. The second drop-down list is for related tags that will be changed according to the selected topic.</div>
                            </div>
                            <div class="flex flex-row flex-nowrap pl-5 mb-2">
                                <div class="select-none mr-2">5.</div>
                                <div>Enter your discussion title in the title field, and enter your discussion content in the text field below. The discussion title is required and cannot exceed 300 characters in length. On the other hand, the discussion content is optional, you can leave it blank.</div>
                            </div>
                            <div class="flex flex-row flex-nowrap pl-5 mb-2">
                                <div class="select-none mr-2">6.</div>
                                <div>Click the Post button, and your discussion will be successfully initiated and published to the RoundTable.</div>
                            </div>
                            <div class="flex flex-row flex-nowrap pl-5 mb-2">
                                <div class="select-none mr-2">7.</div>
                                <div>For more information, you can view the discussion you started on your <a href="../User/UserRegistration.aspx" class="text-indigo-500 hover:underline" target="_blank">profile</a> page.</div>
                            </div>
                        </div>
                        <br />
                    </section>

                    <section id="start-5" class="md:mt-10">
                        <h3 class="py-5 md:py-10 font-medium text-2xl">Participate In A Discussion</h3>
                        <p>You can read discussion posts from thousands of users from different regions, interact with them by reacting to their posts, and provide feedback by commenting and sharing their posts.</p>
                        <br />
                        <p>What can you do to participate in the discussion:</p>
                        <div class="flex flex-col">
                            <div class="flex flex-row flex-nowrap pl-5 mb-2">
                                <div class="select-none mr-2">1.</div>
                                <div>Like ❤️</div>
                            </div>
                            <div class="flex flex-row flex-nowrap pl-5 mb-2">
                                <div class="select-none mr-2">2.</div>
                                <div>Comment 💬</div>
                            </div>
                            <div class="flex flex-row flex-nowrap pl-5 mb-2">
                                <div class="select-none mr-2">3.</div>
                                <div>Bookmark 🔖</div>
                            </div>
                            <div class="flex flex-row flex-nowrap pl-5 mb-2">
                                <div class="select-none mr-2">4.</div>
                                <div>Share 📎</div>
                            </div>
                            <div class="flex flex-row flex-nowrap pl-5 mb-2">
                                <div class="select-none mr-2">5.</div>
                                <div>Reply to comment 🗨️</div>
                            </div>
                        </div>
                        <br />
                        <p>Don’t forget to search for tags you like to make sure you are viewing discussion posts that match your interests.</p>
                        <br />
                    </section>
                    <section id="start-6" class="md:mt-10">
                        <h3 class="py-5 md:py-10 font-medium text-2xl">Search For Discussions</h3>
                        <p>You can search for discussion posts throughout the entire database of RoundTable.</p>
                        <br />
                        <p>Moreover, you can also filter the search results by using the tags or by using the sort by feature in the search page.</p>
                        <br />
                    </section>
                    <section id="start-7" class="md:mt-10">
                        <h3 class="py-5 md:py-10 font-medium text-2xl">Post Recommendations</h3>
                        <p>There is a random post recommending feature in RoundTable. However, you will only able to access it after you have logged in to your RoundTable account. If you have not registered yet, please click <a href="../User/UserRegistration.aspx" class="text-indigo-500 hover:underline" target="_blank">here</a> to register.</p>
                        <br />
                         <p>Here is how to acquire post recommendations on RoundTable:</p>
                        <div class="flex flex-col">
                            <div class="flex flex-row flex-nowrap pl-5 mb-2">
                                <div class="select-none mr-2">1.</div>
                                <div>Log in to your RoundTable account. If you have not registered yet, please click <a href="../User/UserRegistration.aspx" class="text-indigo-500 hover:underline" target="_blank">here</a> to register.</div>
                            </div>
                            <div class="flex flex-row flex-nowrap pl-5 mb-2">
                                <div class="select-none mr-2">2.</div>
                                <div>Click on 🌐 Explore at the side menu.</div>
                            </div>
                            <div class="flex flex-row flex-nowrap pl-5 mb-2">
                                <div class="select-none mr-2">3.</div>
                                <div>You will be able to see a <span class="font-bold">Posts You Might Like...</span> section in the Explore page. This is where you will be able to acquire recommendations from RoundTable.</div>
                            </div>
                        </div>
                        <br />
                    </section>
                    <section id="start-8" class="md:mt-10">
                        <h3 class="py-5 md:py-10 font-medium text-2xl">Edit Profile</h3>
                        <p>You can edit your profile by clicking on your profile icon at the side menu or click <a href="../User/UserRegistration.aspx" class="text-indigo-500 hover:underline" target="_blank">here</a>. Information such as Name, Gender,D.O.B, Email Profile Photo and Profile Description are customisable.</p>
                        <br />
                    </section>
                </section>
                <hr />
                <section id="faq">
                    <h2 class="py-5 md:py-10 mt-10 font-bold text-3xl">FAQs</h2>
                    <p>Find below frequently asked questions about RoundTable:</p>
                    <br />

                    <section id="faq-1">
                        <h3 class="py-5 md:py-10 font-medium text-2xl">How to Insert Media or Hyperlinks in the Discussion Content?</h3>
                        <p>When you start a discussion, you may need to insert media or hyperlinks to further elaborate on your discussion. Don't worry, because the rich text editor in RoundTable comes with various markup functions for you to customize your content.</p>
                        <br />
                        <p>To achieve this, just proceed to start the discussion and you will notice that there are various button menus at the top of the editor. Click <i>Insert</i> and you will see the button.</p>
                        <br />
                        <img src="https://www.tendenci.com/files/2538/" class="w-full h-auto" />
                        <br />
                    </section>

                    <section id="faq-2" class="md:mt-10">
                        <h3 class="py-5 md:py-10 font-medium text-2xl">What's a Markdown Format?</h3>
                        <p>Markdown is a lightweight plaintext markup language that you can use to add elements to plaintext documents rather than using the older WYSIWYG editor. RoundTable's editor supports the Markdown syntax and allows you to format your discussion easily.</p>
                        <br />
                        <img src="https://spandcrm2013.files.wordpress.com/2018/10/tinymce1.png" class="w-full h-auto" />
                        <br />
                    </section>

                    <section id="faq-3" class="md:mt-10">
                        <h3 class="py-5 md:py-10 font-medium text-2xl">How to Customize the Homepage?</h3>
                        <p>RoundTable provides a variety of options for you to customize the homepage design. You can customize the content of the homepage, the sort order and the font size of the title.</p>
                        <br />
                        <p>To customize the homepage, first navigate to the homepage. Then click the <i>Personalize</i> button at the top of the screen. A modal box will appear with various options. Select the options you want and click <i>Confirm</i>. Your choices will be automatically saved and stored in a cookie.</p>
                        <br />
                        <p>*For more information about 🍪 cookies, please read our privacy policy.</p>
                        <br />
                    </section>

                    <section id="faq-4" class="md:mt-10">
                        <h3 class="py-5 md:py-10 font-medium text-2xl">Where Can I Find RoundTable's Privacy Policy and Terms of Service?</h3>
                        <p>This is our <a href="Privacy.aspx" class="text-indigo-500 hover:underline" target="_blank">Privacy policy</a> and <a href="Terms.aspx" class="text-indigo-500 hover:underline" target="_blank">Terms of Service</a>.</p>
                        <br />
                    </section>

                    <section id="faq-5" class="md:mt-10">
                        <h3 class="py-5 md:py-10 font-medium text-2xl">How Can I Know Who Has Commented on My Post?</h3>
                        <p>There is a 🔔 <a href="Notification.aspx" class="text-indigo-500 hover:underline" target="_blank">Notification</a> page which is located at the side menu on top of the profile icon.</p>
                        <br />
                        <p>You can access your notifications at the Notification page and navigate to the discussion post and check out who has commented on your post.</p>
                        <br />
                    </section>
                </section>
                <hr />
                <section id="tip">
                    <h2 class="py-5 md:py-10 mt-10 font-bold text-3xl">Tips & Tricks</h2>
                    <p>Find below tips and tricks about RoundTable:</p>
                    <br />

                    <section id="tip-1">
                        <h3 class="py-5 md:py-10 font-medium text-2xl">Rich Text Editor Shortcuts</h3>
                        <p>This is a list of available keyboard shortcuts within the editor body.</p>
                        <br />
                        <table class="w-full border-collapse table-auto text-center">
                            <tr class="border-b-2">
                                <th class="pb-2">Action</th>
                                <th class="pb-2">PC Shortcut</th>
                                <th class="pb-2 hidden lg:inline">Mac Shortcut</th>
                            </tr>
                            <tr>
                                <td class="py-4">Bold</td>
                                <td class="py-4"><span class="keyboard">Ctrl</span> + <span class="keyboard">B</span></td>
                                <td class="py-4 hidden lg:block"><span class="keyboard">⌘</span> + <span class="keyboard">B</span></td>
                            </tr>
                            <tr>
                                <td class="pb-4">Italic</td>
                                <td class="pb-4"><span class="keyboard">Ctrl</span> + <span class="keyboard">I</span></td>
                                <td class="pb-4 hidden lg:block"><span class="keyboard">⌘</span> + <span class="keyboard">I</span></td>
                            </tr>
                            <tr>
                                <td class="pb-4">Underline</td>
                                <td class="pb-4"><span class="keyboard">Ctrl</span> + <span class="keyboard">U</span></td>
                                <td class="pb-4 hidden lg:block"><span class="keyboard">⌘</span> + <span class="keyboard">U</span></td>
                            </tr>
                            <tr>
                                <td class="pb-4">Select All</td>
                                <td class="pb-4"><span class="keyboard">Ctrl</span> + <span class="keyboard">A</span></td>
                                <td class="pb-4 hidden lg:block"><span class="keyboard">⌘</span> + <span class="keyboard">A</span></td>
                            </tr>
                            <tr>
                                <td class="pb-4">Redo</td>
                                <td class="pb-4"><span class="keyboard">Ctrl</span> + <span class="keyboard">Y</span></td>
                                <td class="pb-4 hidden lg:block"><span class="keyboard">⌘</span> + <span class="keyboard">Y</span></td>
                            </tr>
                            <tr>
                                <td class="pb-4">Undo</td>
                                <td class="pb-4"><span class="keyboard">Ctrl</span> + <span class="keyboard">Z</span></td>
                                <td class="pb-4 hidden lg:block"><span class="keyboard">⌘</span> + <span class="keyboard">Z</span></td>
                            </tr>
                            <tr>
                                <td class="pb-4">Insert link</td>
                                <td class="pb-4"><span class="keyboard">Ctrl</span> + <span class="keyboard">K</span></td>
                                <td class="pb-4 hidden lg:block"><span class="keyboard">⌘</span> + <span class="keyboard">K</span></td>
                            </tr>
                            <tr>
                                <td class="pb-4">Save</td>
                                <td class="pb-4"><span class="keyboard">Ctrl</span> + <span class="keyboard">S</span></td>
                                <td class="pb-4 hidden lg:block"><span class="keyboard">⌘</span> + <span class="keyboard">S</span></td>
                            </tr>
                            <tr>
                                <td class="pb-4">Find</td>
                                <td class="pb-4"><span class="keyboard">Ctrl</span> + <span class="keyboard">F</span></td>
                                <td class="pb-4 hidden lg:block"><span class="keyboard">⌘</span> + <span class="keyboard">F</span></td>
                            </tr>
                            <tr>
                                <td class="pb-4">Help</td>
                                <td class="pb-4"><span class="keyboard">Alt</span> + <span class="keyboard">0</span></td>
                                <td class="pb-4 hidden lg:block"><span class="keyboard">⌥</span> + <span class="keyboard">0</span></td>
                            </tr>
                            <tr>
                                <td class="pb-4">Header 1</td>
                                <td class="pb-4"><span class="keyboard">Alt</span> + <span class="keyboard">Shift</span> + <span class="keyboard">1</span></td>
                                <td class="pb-4 hidden lg:block"><span class="keyboard">⌘</span> + <span class="keyboard">⌥</span> + <span class="keyboard">1</span></td>
                            </tr>
                            <tr>
                                <td class="pb-4">Header 2</td>
                                <td class="pb-4"><span class="keyboard">Alt</span> + <span class="keyboard">Shift</span> + <span class="keyboard">2</span></td>
                                <td class="pb-4 hidden lg:block"><span class="keyboard">⌘</span> + <span class="keyboard">⌥</span> + <span class="keyboard">2</span></td>
                            </tr>
                            <tr>
                                <td class="pb-4">Header 3</td>
                                <td class="pb-4"><span class="keyboard">Alt</span> + <span class="keyboard">Shift</span> + <span class="keyboard">3</span></td>
                                <td class="pb-4 hidden lg:block"><span class="keyboard">⌘</span> + <span class="keyboard">⌥</span> + <span class="keyboard">3</span></td>
                            </tr>
                            <tr>
                                <td class="pb-4">Paragraph</td>
                                <td class="pb-4"><span class="keyboard">Alt</span> + <span class="keyboard">Shift</span> + <span class="keyboard">7</span></td>
                                <td class="pb-4 hidden lg:block"><span class="keyboard">⌘</span> + <span class="keyboard">⌥</span> + <span class="keyboard">7</span></td>
                            </tr>
                            <tr>
                                <td class="pb-4">Div</td>
                                <td class="pb-4"><span class="keyboard">Alt</span> + <span class="keyboard">Shift</span> + <span class="keyboard">8</span></td>
                                <td class="pb-4 hidden lg:block"><span class="keyboard">⌘</span> + <span class="keyboard">⌥</span> + <span class="keyboard">8</span></td>
                            </tr>
                            <tr>
                                <td class="pb-4">Fullscreen</td>
                                <td class="pb-4"><span class="keyboard">Alt</span> + <span class="keyboard">Shift</span> + <span class="keyboard">F</span></td>
                                <td class="pb-4 hidden lg:block"><span class="keyboard">⌘</span> + <span class="keyboard">⌥</span> + <span class="keyboard">F</span></td>
                            </tr>
                        </table>
                    </section>

                    <section id="tip-2" class="md:mt-10">
                        <h3 class="py-5 md:py-10 font-medium text-2xl">RoundTable Chatbot</h3>
                        <p>RoundTable can not only conduct asynchronous discussions, but you can also communicate with RoundTable Chatbot synchronously at any time.</p>
                        <br />
                        <p>You can see the chatbot button in the lower right corner of the screen. Clicking the button will open a small chat window. In order to open the RoundTable Chatbot window faster, you can also use shortcut key by clicking <span class="keyboard">Ctrl</span> + <span class="keyboard">\</span> on Windows or <span class="keyboard">⌘</span> + <span class="keyboard">\</span> on Mac OS.</p>
                        <br />
                        <p>After the conversation starts, you can start talking with the chatbot by typing in the text box and pressing <span class="keyboard">Enter</span>.</p>
                        <br />
                        <p>You can ask any questions about RoundTable, such as discussions, bookmarks, login, registration, etc. The chatbot will try to respond to your inquiries, so please be patient.</p>
                        <br />
                        <p>You can also give developers <a href="Feedback.aspx" class="text-indigo-500 hover:underline" target="_blank">feedback</a> about the chatbot’s conversation experience so that they can further improve the chatbot.</p>
                        <br />
                    </section>

                    <section id="tip-3" class="md:mt-10">
                        <h3 class="py-5 md:py-10 font-medium text-2xl">Voice Search Feature</h3>
                        <p>Other than typing search, RoundTable also provides a voice search feature in the search page as well. With this voice search feature, you can input text into the search bar by using your own voice.</p>
                        <br />
                        <p>All you need to do is click on the 🎤 microphone icon and speak. After completing the recording, just simply hit the <span class="keyboard">Enter</span> key and the results will be returned according to the inputted text.</p>
                        <br />
                    </section>
                </section>
            </div>
            <%--Table of Content--%>
            <div class="support-section-nav hidden lg:block sticky top-8 self-start border-l-2 p-5 pr-0">
                <ol class="w-60">
                    <li><a href="#start">Getting Started</a>
                        <ul>
                            <li class="pl-4"><a href="#start-1">Using RoundTable</a></li>
                            <li class="pl-4"><a href="#start-2">How RoundTable Works</a></li>
                            <li class="pl-4"><a href="#start-3">Create an Account</a></li>
                            <li class="pl-4"><a href="#start-4">Start A Discussion</a></li>
                            <li class="pl-4"><a href="#start-5">Participate In A Discussion</a></li>
                            <li class="pl-4"><a href="#start-6">Search For Discussions</a></li>
                            <li class="pl-4"><a href="#start-7">Post Recommendations</a></li>
                            <li class="pl-4"><a href="#start-8">Edit Profile</a></li>
                        </ul>
                    </li>
                    <li class="mt-2"><a href="#faq">FAQs</a>
                        <ul>
                            <li class="pl-4"><a href="#faq-1">Insert Media or Hyperlinks</a></li>
                            <li class="pl-4"><a href="#faq-2">Markdown Format</a></li>
                            <li class="pl-4"><a href="#faq-3">Customize Homepage</a></li>
                            <li class="pl-4"><a href="#faq-4">Privacy Policy and Terms</a></li>
                            <li class="pl-4"><a href="#faq-5">Notifications</a></li>
                        </ul>
                    </li>
                    <li class="mt-2"><a href="#tip">Tips & Tricks</a>
                        <ul>
                            <li class="pl-4"><a href="#tip-1">Rich Text Editor Shortcuts</a></li>
                            <li class="pl-4"><a href="#tip-2">RoundTable Chatbot</a></li>
                            <li class="pl-4"><a href="#tip-3">Voice Search Feature</a></li>
                        </ul>
                    </li>
                </ol>
            </div>
        </div>
    </div>
</asp:Content>

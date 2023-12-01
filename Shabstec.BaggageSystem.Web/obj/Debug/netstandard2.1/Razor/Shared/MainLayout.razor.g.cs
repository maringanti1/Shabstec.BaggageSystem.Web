#pragma checksum "C:\Repository\RabbitMQ\Shabstec.BaggageSystem\Shabstec.BaggageSystem.Web\Shared\MainLayout.razor" "{8829d00f-11b8-4213-878b-770e8597ac16}" "f241a8f2145fa0f46c11a6a06a4503d2582032439f19f0cfc79a994d2084719b"
// <auto-generated/>
#pragma warning disable 1591
namespace Shabstec.BaggageSystem.Web.Shared
{
    #line hidden
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Repository\RabbitMQ\Shabstec.BaggageSystem\Shabstec.BaggageSystem.Web\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Repository\RabbitMQ\Shabstec.BaggageSystem\Shabstec.BaggageSystem.Web\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Repository\RabbitMQ\Shabstec.BaggageSystem\Shabstec.BaggageSystem.Web\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Repository\RabbitMQ\Shabstec.BaggageSystem\Shabstec.BaggageSystem.Web\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Repository\RabbitMQ\Shabstec.BaggageSystem\Shabstec.BaggageSystem.Web\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Repository\RabbitMQ\Shabstec.BaggageSystem\Shabstec.BaggageSystem.Web\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Repository\RabbitMQ\Shabstec.BaggageSystem\Shabstec.BaggageSystem.Web\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Repository\RabbitMQ\Shabstec.BaggageSystem\Shabstec.BaggageSystem.Web\_Imports.razor"
using Shabstec.BaggageSystem.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Repository\RabbitMQ\Shabstec.BaggageSystem\Shabstec.BaggageSystem.Web\_Imports.razor"
using Shabstec.BaggageSystem.Web.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Repository\RabbitMQ\Shabstec.BaggageSystem\Shabstec.BaggageSystem.Web\_Imports.razor"
using Shabstec.BaggageSystem.Web.Pages;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Repository\RabbitMQ\Shabstec.BaggageSystem\Shabstec.BaggageSystem.Web\_Imports.razor"
using BlazorApp.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Repository\RabbitMQ\Shabstec.BaggageSystem\Shabstec.BaggageSystem.Web\_Imports.razor"
using BlazorApp.Web.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Repository\RabbitMQ\Shabstec.BaggageSystem\Shabstec.BaggageSystem.Web\_Imports.razor"
using BlazorApp.Helpers;

#line default
#line hidden
#nullable disable
    public partial class MainLayout : LayoutComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<style>\r\n    .main {\r\n        padding: 20px;\r\n    }\r\n\r\n    .login-link {\r\n        /* Your existing styles for the login link */\r\n        text-decoration: solid; /* Remove the default underline for links */\r\n        color: white; /* Set the text color for the login link */\r\n    }\r\n\r\n    .header-box {\r\n        background-color: #333; /* Set your desired background color */\r\n        padding: 10px;\r\n        display: flex;\r\n        justify-content: space-between;\r\n        align-items: center;\r\n    }\r\n\r\n    .header-menu {\r\n        position: absolute;\r\n        top: 0;\r\n        left: 0;\r\n        z-index: 1;\r\n        width: 100%;\r\n        padding: 20px;\r\n        /*background-color: rgba(255, 255, 255, 0.7);\r\n                box-shadow: 0 2px 5px rgba(0, 0, 0, 0.1);*/\r\n        display: flex;\r\n        justify-content: space-between;\r\n        align-items: center;\r\n    }\r\n\r\n        .header-menu a {\r\n            text-decoration: none;\r\n            color: white;\r\n            margin: 0 10px;\r\n        }\r\n\r\n    .header-title {\r\n        font-weight: bold;\r\n        font-size: 20px;\r\n        text-align: center;\r\n        flex-grow: 1; /* Takes up available space and centers the title */\r\n    }\r\n\r\n    .header-container {\r\n        display: flex;\r\n        justify-content: space-between;\r\n        align-items: center;\r\n    }\r\n\r\n    .register-button {\r\n        display: inline-block;\r\n        padding: 15px 30px;\r\n        font-size: 18px;\r\n        font-weight: bold;\r\n        text-align: center;\r\n        text-decoration: none;\r\n        background-color: #007bff; /* Bootstrap\'s primary color */\r\n        color: #fff;\r\n        border-radius: 5px;\r\n        transition: background-color 0.3s ease;\r\n        z-index: 2; /* Put it on top of the overlay */\r\n    }\r\n\r\n        .register-button:hover {\r\n            background-color: #0056b3; /* Darker shade on hover */\r\n        }\r\n\r\n    .background-image {\r\n        position: fixed;\r\n        top: 0;\r\n        left: 0;\r\n        width: 100%;\r\n        height: 100%;\r\n        z-index: -1;\r\n        /* Set your background image properties here */\r\n        background: url(\'sample1.webp\') no-repeat center center fixed;\r\n        background-size: cover;\r\n        /* Additional styles for overlay or effects if needed */\r\n    }\r\n\r\n    .content {\r\n        position: relative;\r\n        z-index: 1; /* Ensure the content is above the background image */\r\n    }\r\n\r\n    /* Other styles for header-menu, center-container, main-content, etc. */\r\n\r\n</style>\r\n");
            __builder.AddMarkupContent(1, "<div class=\"background-image\">\r\n    \r\n</div>\r\n");
            __builder.OpenElement(2, "div");
            __builder.AddAttribute(3, "class", "sidebar");
            __builder.AddMarkupContent(4, "\r\n");
#nullable restore
#line 99 "C:\Repository\RabbitMQ\Shabstec.BaggageSystem\Shabstec.BaggageSystem.Web\Shared\MainLayout.razor"
     if (user != null && !string.IsNullOrEmpty(user.FirstName))
    {

#line default
#line hidden
#nullable disable
            __builder.AddContent(5, "        ");
            __builder.OpenComponent<global::Shabstec.BaggageSystem.Web.Shared.NavMainMenu>(6);
            __builder.CloseComponent();
            __builder.AddMarkupContent(7, "\r\n");
#nullable restore
#line 102 "C:\Repository\RabbitMQ\Shabstec.BaggageSystem\Shabstec.BaggageSystem.Web\Shared\MainLayout.razor"
    }
    else
    {

#line default
#line hidden
#nullable disable
            __builder.AddContent(8, "        ");
            __builder.OpenComponent<global::Shabstec.BaggageSystem.Web.Shared.NavMenu>(9);
            __builder.CloseComponent();
            __builder.AddMarkupContent(10, "\r\n");
#nullable restore
#line 106 "C:\Repository\RabbitMQ\Shabstec.BaggageSystem\Shabstec.BaggageSystem.Web\Shared\MainLayout.razor"
    }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(11, "\r\n");
            __builder.OpenElement(12, "div");
            __builder.AddAttribute(13, "class", "main");
            __builder.AddMarkupContent(14, "\r\n\r\n");
#nullable restore
#line 110 "C:\Repository\RabbitMQ\Shabstec.BaggageSystem\Shabstec.BaggageSystem.Web\Shared\MainLayout.razor"
     if (user != null && !string.IsNullOrEmpty(user.FirstName))
    {

#line default
#line hidden
#nullable disable
            __builder.AddContent(15, "        ");
            __builder.OpenElement(16, "div");
            __builder.AddAttribute(17, "class", "header-container");
            __builder.AddAttribute(18, "style", "color:white");
            __builder.AddMarkupContent(19, "\r\n            ");
            __builder.AddMarkupContent(20, "<div class=\"header-title\" style=\"color:white; font-weight:700; text-align:center;\">\r\n                <h1>Shabstec Baggage Broker</h1>\r\n            </div>\r\n            Hello, ");
#nullable restore
#line 116 "C:\Repository\RabbitMQ\Shabstec.BaggageSystem\Shabstec.BaggageSystem.Web\Shared\MainLayout.razor"
__builder.AddContent(21, user.FirstName);

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(22, "\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(23, "\r\n");
#nullable restore
#line 121 "C:\Repository\RabbitMQ\Shabstec.BaggageSystem\Shabstec.BaggageSystem.Web\Shared\MainLayout.razor"
            
    }
    else
    {

#line default
#line hidden
#nullable disable
            __builder.AddContent(24, "        ");
            __builder.AddMarkupContent(25, @"<div class=""header-container"" style=""color:white"">
            <div class=""header-title"" style=""color:white; font-weight:700; text-align:center;"">
                <h1>Shabstec Baggage Broker</h1>
            </div>
            <div style=""max-width: 100%"">
                <a data-ux-btn=""primary"" class=""register-button"" href=""/login"" data-ux=""ButtonPrimary"">
                    Login
                </a>
            </div>
        </div>
");
#nullable restore
#line 136 "C:\Repository\RabbitMQ\Shabstec.BaggageSystem\Shabstec.BaggageSystem.Web\Shared\MainLayout.razor"

    }

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(26, "    \r\n    ");
#nullable restore
#line 139 "C:\Repository\RabbitMQ\Shabstec.BaggageSystem\Shabstec.BaggageSystem.Web\Shared\MainLayout.razor"
__builder.AddContent(27, Body);

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(28, "\r\n");
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 164 "C:\Repository\RabbitMQ\Shabstec.BaggageSystem\Shabstec.BaggageSystem.Web\Shared\MainLayout.razor"
       
    private User user;
    protected override async Task OnInitializedAsync()
    {
        user = await AccountService.GetLoggedInUserDetails();
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IAccountService AccountService { get; set; }
    }
}
#pragma warning restore 1591
#pragma checksum "C:\GITRepos\Shabstec.BaggageSystem.Web\Shabstec.BaggageSystem\Shabstec.BaggageSystem.Web\Pages\UserDashboard.razor" "{8829d00f-11b8-4213-878b-770e8597ac16}" "1c0f02aeaf497038da5e31fe89f2654feed3f7ffe43a9df6cc91feee93d2ba73"
// <auto-generated/>
#pragma warning disable 1591
namespace Shabstec.BaggageSystem.Web.Pages
{
    #line hidden
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\GITRepos\Shabstec.BaggageSystem.Web\Shabstec.BaggageSystem\Shabstec.BaggageSystem.Web\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\GITRepos\Shabstec.BaggageSystem.Web\Shabstec.BaggageSystem\Shabstec.BaggageSystem.Web\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\GITRepos\Shabstec.BaggageSystem.Web\Shabstec.BaggageSystem\Shabstec.BaggageSystem.Web\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\GITRepos\Shabstec.BaggageSystem.Web\Shabstec.BaggageSystem\Shabstec.BaggageSystem.Web\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\GITRepos\Shabstec.BaggageSystem.Web\Shabstec.BaggageSystem\Shabstec.BaggageSystem.Web\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\GITRepos\Shabstec.BaggageSystem.Web\Shabstec.BaggageSystem\Shabstec.BaggageSystem.Web\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\GITRepos\Shabstec.BaggageSystem.Web\Shabstec.BaggageSystem\Shabstec.BaggageSystem.Web\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\GITRepos\Shabstec.BaggageSystem.Web\Shabstec.BaggageSystem\Shabstec.BaggageSystem.Web\_Imports.razor"
using Shabstec.BaggageSystem.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\GITRepos\Shabstec.BaggageSystem.Web\Shabstec.BaggageSystem\Shabstec.BaggageSystem.Web\_Imports.razor"
using Shabstec.BaggageSystem.Web.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\GITRepos\Shabstec.BaggageSystem.Web\Shabstec.BaggageSystem\Shabstec.BaggageSystem.Web\_Imports.razor"
using Shabstec.BaggageSystem.Web.Pages;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\GITRepos\Shabstec.BaggageSystem.Web\Shabstec.BaggageSystem\Shabstec.BaggageSystem.Web\_Imports.razor"
using BlazorApp.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\GITRepos\Shabstec.BaggageSystem.Web\Shabstec.BaggageSystem\Shabstec.BaggageSystem.Web\_Imports.razor"
using BlazorApp.Helpers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\GITRepos\Shabstec.BaggageSystem.Web\Shabstec.BaggageSystem\Shabstec.BaggageSystem.Web\Pages\UserDashboard.razor"
using BlazorApp.Web.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\GITRepos\Shabstec.BaggageSystem.Web\Shabstec.BaggageSystem\Shabstec.BaggageSystem.Web\Pages\UserDashboard.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\GITRepos\Shabstec.BaggageSystem.Web\Shabstec.BaggageSystem\Shabstec.BaggageSystem.Web\Pages\UserDashboard.razor"
           [Authorize]

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Components.LayoutAttribute(typeof(MainLayout))]
    [global::Microsoft.AspNetCore.Components.RouteAttribute("/users")]
    public partial class UserDashboard : global::Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "style", "color:white");
            __builder.AddMarkupContent(2, "\r\n");
            __builder.AddMarkupContent(3, "<h1>Users</h1>\r\n");
            __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Routing.NavLink>(4);
            __builder.AddAttribute(5, "href", (object)("users/add"));
            __builder.AddAttribute(6, "class", (object)("btn btn-sm btn-success mb-2"));
            __builder.AddAttribute(7, "ChildContent", (global::Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddContent(8, "Add User");
            }
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(9, "\r\n    ");
            __builder.OpenElement(10, "table");
            __builder.AddAttribute(11, "class", "table table-striped");
            __builder.AddAttribute(12, "style", "color:white; background-color: slateblue");
            __builder.AddMarkupContent(13, "\r\n        ");
            __builder.AddMarkupContent(14, "<thead style=\"background-color:green;\">\r\n        <tr>\r\n            <th style=\"width: 30%\">First Name</th>\r\n            <th style=\"width: 30%\">Last Name</th>\r\n            <th style=\"width: 30%\">Username</th>\r\n        </tr>\r\n    </thead>\r\n    ");
            __builder.OpenElement(15, "tbody");
            __builder.AddMarkupContent(16, "\r\n");
#nullable restore
#line 19 "C:\GITRepos\Shabstec.BaggageSystem.Web\Shabstec.BaggageSystem\Shabstec.BaggageSystem.Web\Pages\UserDashboard.razor"
         if (users != null)
        {
            foreach (var user in users)
            {

#line default
#line hidden
#nullable disable
            __builder.AddContent(17, "                ");
            __builder.OpenElement(18, "tr");
            __builder.AddMarkupContent(19, "\r\n                    ");
            __builder.OpenElement(20, "td");
#nullable restore
#line 24 "C:\GITRepos\Shabstec.BaggageSystem.Web\Shabstec.BaggageSystem\Shabstec.BaggageSystem.Web\Pages\UserDashboard.razor"
__builder.AddContent(21, user.FirstName);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(22, "\r\n                    ");
            __builder.OpenElement(23, "td");
#nullable restore
#line 25 "C:\GITRepos\Shabstec.BaggageSystem.Web\Shabstec.BaggageSystem\Shabstec.BaggageSystem.Web\Pages\UserDashboard.razor"
__builder.AddContent(24, user.LastName);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(25, "\r\n                    ");
            __builder.OpenElement(26, "td");
#nullable restore
#line 26 "C:\GITRepos\Shabstec.BaggageSystem.Web\Shabstec.BaggageSystem\Shabstec.BaggageSystem.Web\Pages\UserDashboard.razor"
__builder.AddContent(27, user.Username);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(28, "\r\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(29, "\r\n");
#nullable restore
#line 28 "C:\GITRepos\Shabstec.BaggageSystem.Web\Shabstec.BaggageSystem\Shabstec.BaggageSystem.Web\Pages\UserDashboard.razor"
            }
        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 30 "C:\GITRepos\Shabstec.BaggageSystem.Web\Shabstec.BaggageSystem\Shabstec.BaggageSystem.Web\Pages\UserDashboard.razor"
         if (loading)
        {

#line default
#line hidden
#nullable disable
            __builder.AddContent(30, "            ");
            __builder.AddMarkupContent(31, "<tr>\r\n                <td colspan=\"4\" class=\"text-center\">\r\n                    <span class=\"spinner-border spinner-border-lg align-center\"></span>\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 37 "C:\GITRepos\Shabstec.BaggageSystem.Web\Shabstec.BaggageSystem\Shabstec.BaggageSystem.Web\Pages\UserDashboard.razor"
        }

#line default
#line hidden
#nullable disable
            __builder.AddContent(32, "    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(33, "\r\n");
            __builder.CloseElement();
            __builder.AddMarkupContent(34, "\r\n");
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 42 "C:\GITRepos\Shabstec.BaggageSystem.Web\Shabstec.BaggageSystem\Shabstec.BaggageSystem.Web\Pages\UserDashboard.razor"
       
    private bool loading;
    private List<User> users;

    protected override async Task OnInitializedAsync()
    {
        loading = true;
        users = await AccountService.GetAll();
        loading = false;
    }

    private async void DeleteUser(string id) 
    {
        var user = users.First(x => x.Id == id);
        user.IsDeleting = true;
        await AccountService.Delete(id);
        users.Remove(user);
        StateHasChanged();
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IAccountService AccountService { get; set; }
    }
}
#pragma warning restore 1591

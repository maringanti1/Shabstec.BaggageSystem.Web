// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

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
#line 12 "C:\GITRepos\Shabstec.BaggageSystem.Web\Shabstec.BaggageSystem\Shabstec.BaggageSystem.Web\_Imports.razor"
using BlazorApp.Web.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\GITRepos\Shabstec.BaggageSystem.Web\Shabstec.BaggageSystem\Shabstec.BaggageSystem.Web\_Imports.razor"
using BlazorApp.Helpers;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Components.RouteAttribute("/alert")]
    public partial class AlertComponent : global::Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 22 "C:\GITRepos\Shabstec.BaggageSystem.Web\Shabstec.BaggageSystem\Shabstec.BaggageSystem.Web\Pages\AlertComponent.razor"
       
    private bool IsAlertVisible { get; set; }
    private string AlertMessage { get; set; }
    private bool ShowInput { get; set; }
    private bool ShowCancel { get; set; }
    private string InputValue { get; set; }

    public void ShowAlert(string message)
    {
        IsAlertVisible = true;
        AlertMessage = message;
        ShowInput = false;
        ShowCancel = false;
    }

    public void ShowConfirm(string message)
    {
        IsAlertVisible = true;
        AlertMessage = message;
        ShowInput = false;
        ShowCancel = true;
    }

    public void ShowPrompt(string message, string defaultValue = "")
    {
        IsAlertVisible = true;
        AlertMessage = message;
        ShowInput = true;
        ShowCancel = true;
        InputValue = defaultValue;
    }

    private void OnOkClick()
    {
        // Handle OK button click
        IsAlertVisible = false;
        // Perform any additional logic here based on the alert type
    }

    private void OnCancelClick()
    {
        // Handle Cancel button click
        IsAlertVisible = false;
        // Perform any additional logic here based on the alert type
    }

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591

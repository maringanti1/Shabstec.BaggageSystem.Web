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
#line 13 "C:\GITRepos\Shabstec.BaggageSystem.Web\Shabstec.BaggageSystem\Shabstec.BaggageSystem.Web\_Imports.razor"
using BlazorApp.Helpers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\GITRepos\Shabstec.BaggageSystem.Web\Shabstec.BaggageSystem\Shabstec.BaggageSystem.Web\Pages\ConfigEdit.razor"
using BlazorApp.Web.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\GITRepos\Shabstec.BaggageSystem.Web\Shabstec.BaggageSystem\Shabstec.BaggageSystem.Web\Pages\ConfigEdit.razor"
using Shabstec.BaggageSystem.Web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Components.RouteAttribute("/editconfiguration")]
    public partial class ConfigEdit : global::Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 82 "C:\GITRepos\Shabstec.BaggageSystem.Web\Shabstec.BaggageSystem\Shabstec.BaggageSystem.Web\Pages\ConfigEdit.razor"
       
    private Configuration model = new Configuration();
    private bool loading;
    private string enteredAirlineCodes;
    private string validationError;
    private string validationErrorNew;
    private User user;
     private string id;
    protected override async Task OnInitializedAsync()
    { 
         loading = true;
        // Load configuration data based on the provided ID in the query string
        //var uri = NavigationManager.ToBaseRelativePath(NavigationManager.Uri);
        //var id = QueryHelpers.ParseQuery(uri).TryGetValue("id", out var idValue) ? idValue.FirstOrDefault() : null; 
        var uri = new Uri(NavigationManager.Uri);
        var query = uri.Query.TrimStart('?');
        var keyValuePairs = query.Split('&')
            .Select(x => x.Split('='))
            .ToDictionary(x => x[0], x => x.Length > 1 ? x[1] : null);

        if (keyValuePairs.ContainsKey("id"))
        {
            id = keyValuePairs["id"];
        }

        if (!string.IsNullOrEmpty(id))
        {
            User user = await AccountService.GetLoggedInUserDetails();
            if (user != null)
            {
                model = await AccountService.GetConfigurationByID(user.Username, user.Organisation, id);
            }
        }
        await LoadAirLinesListAsync();
        loading = false;
    }
        
     private bool ValidateSubscribeToCodes(string args)
{        
    enteredAirlineCodes = args?.ToString(); 
    // Split the entered codes by commas
    var enteredCodes = enteredAirlineCodes?.Split(','); 
    //var mergedList = AvailableAirlines.Concat(AvailableAirports).ToList();
    List<AirlineInfo> mergedList = new List<AirlineInfo>();
    // Add all items from AvailableAirlines and AvailableAirports to the mergedList
    mergedList.AddRange(AvailableAirlines);
    mergedList.AddRange(AvailableAirports);
    // Validate each entered code
    foreach (var code in enteredCodes)
    {
        var trimmedCode = code.Trim(); 
        // Check if the trimmed code exists in AvailableAirlines
        var exists = mergedList.Any(airline => airline.Code == trimmedCode);  
        if (!exists)
        {            
            // Handle validation error (you can set an error message or perform other actions)
            Console.WriteLine($"Invalid airline/airport code: {trimmedCode}");
            // Set validation error message
            validationErrorNew = validationErrorNew + $"Invalid airline/airport code: {trimmedCode}. Please correct.";
            loading = false;
            return false; // Stop further validation
        }
        
    } 
    loading = false;
    // Validation successful if no errors found
    return true; 
}

    private bool ValidatePublishToCodes(string args)
{        
    enteredAirlineCodes = args?.ToString(); 
    // Split the entered codes by commas
    var enteredCodes = enteredAirlineCodes?.Split(','); 
    //var mergedList = AvailableAirlines.Concat(AvailableAirports).ToList();
    List<AirlineInfo> mergedList = new List<AirlineInfo>();
    // Add all items from AvailableAirlines and AvailableAirports to the mergedList
    mergedList.AddRange(AvailableAirlines);
    mergedList.AddRange(AvailableAirports);
    // Validate each entered code
    foreach (var code in enteredCodes)
    {
        var trimmedCode = code.Trim(); 
        // Check if the trimmed code exists in AvailableAirlines
        var exists = mergedList.Any(airline => airline.Code == trimmedCode);  
        if (!exists)
        {            
            // Handle validation error (you can set an error message or perform other actions)
            Console.WriteLine($"Invalid airline/airport code: {trimmedCode}");
            // Set validation error message
            validationError = validationError + $"Invalid airline/airport code: {trimmedCode}. Please correct.";
            loading = false;
            return false; // Stop further validation
        }
        
    } 
    loading = false;
    // Validation successful if no errors found
    return true; 
} 

    public List<AirlineInfo> AvailableAirlines { get; private set; }
    public List<AirlineInfo> AvailableAirports { get; private set; }

    public async Task LoadAirLinesListAsync()
    {
        loading = true;
        AvailableAirlines = new List<AirlineInfo>();
        AvailableAirlines = await AccountService.GetAirlineList();
        AvailableAirports = new List<AirlineInfo>();
        AvailableAirports = await AccountService.GetAirportCodes();
        loading = false;
    }
     
    private async void OnValidSubmit()
    {
        AlertService.Clear(); 
        loading = true; 
        try
        {
            bool validPublishToAirline = ValidatePublishToCodes(model.PublishTo);
            if(validPublishToAirline == false)
            {
             await jsRuntime.InvokeVoidAsync("showError", "PublishTo list is invalid. Please correct!");
             loading = false;
             return;
            } 

            bool validSubscribeToAirline = ValidateSubscribeToCodes(model.SubscribeTo);
            if(validSubscribeToAirline == false)
            {
             await jsRuntime.InvokeVoidAsync("showError", "SubscribeTo list is invalid. Please correct!");
             loading = false;
             return;
            } 
             
            user = await AccountService.GetLoggedInUserDetails();
            // Set readonly model properties
            model.UserName = user.Username;
            model.Organization = user.Organisation;
            model.id = id;
            await AccountService.Baggage(model);            
            await jsRuntime.InvokeVoidAsync("showAlert", "Configuration updated successfully!");
            NavigationManager.NavigateTo("configuration");
            loading = false;
        }
        catch (Exception ex)
        {
            AlertService.Error(ex.Message);
             await jsRuntime.InvokeVoidAsync("showError", "Configuration failed to update!");
            loading = false;
            StateHasChanged();
        }
        finally
        {
        loading = false;
        }
    }

    private void ResetForm()
    {
        // Reset the form by creating a new Configuration object
        model = new Configuration();
    } 

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private Microsoft.AspNetCore.Components.NavigationManager NavigationManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IAccountService AccountService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IAlertService AlertService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime jsRuntime { get; set; }
    }
}
#pragma warning restore 1591
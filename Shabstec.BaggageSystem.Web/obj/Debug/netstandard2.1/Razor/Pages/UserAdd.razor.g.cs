#pragma checksum "C:\Repository\RabbitMQ\Shabstec.BaggageSystem\Shabstec.BaggageSystem.Web\Pages\UserAdd.razor" "{8829d00f-11b8-4213-878b-770e8597ac16}" "f9829a0ead98dcae99389e8d76c772cd2d8918f04e2eed4aa53797feec4e2c1b"
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
#nullable restore
#line 2 "C:\Repository\RabbitMQ\Shabstec.BaggageSystem\Shabstec.BaggageSystem.Web\Pages\UserAdd.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Repository\RabbitMQ\Shabstec.BaggageSystem\Shabstec.BaggageSystem.Web\Pages\UserAdd.razor"
           [Authorize]

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Components.LayoutAttribute(typeof(MainLayout))]
    [global::Microsoft.AspNetCore.Components.RouteAttribute("/users/add")]
    public partial class UserAdd : global::Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h1>Add User</h1>\r\n");
            __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.EditForm>(1);
            __builder.AddAttribute(2, "Model", (object)(global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<global::System.Object>(
#nullable restore
#line 10 "C:\Repository\RabbitMQ\Shabstec.BaggageSystem\Shabstec.BaggageSystem.Web\Pages\UserAdd.razor"
                  model

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(3, "OnValidSubmit", (object)(global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<global::Microsoft.AspNetCore.Components.EventCallback<global::Microsoft.AspNetCore.Components.Forms.EditContext>>(global::Microsoft.AspNetCore.Components.EventCallback.Factory.Create<global::Microsoft.AspNetCore.Components.Forms.EditContext>(this, 
#nullable restore
#line 10 "C:\Repository\RabbitMQ\Shabstec.BaggageSystem\Shabstec.BaggageSystem.Web\Pages\UserAdd.razor"
                                        OnValidSubmit

#line default
#line hidden
#nullable disable
            ))));
            __builder.AddAttribute(4, "ChildContent", (global::Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Forms.EditContext>)((context) => (__builder2) => {
                __builder2.AddMarkupContent(5, "\r\n    ");
                __builder2.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator>(6);
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(7, "\r\n    ");
                __builder2.OpenElement(8, "div");
                __builder2.AddAttribute(9, "class", "form-row");
                __builder2.AddMarkupContent(10, "\r\n        ");
                __builder2.OpenElement(11, "div");
                __builder2.AddAttribute(12, "class", "form-group col");
                __builder2.AddMarkupContent(13, "\r\n            ");
                __builder2.AddMarkupContent(14, "<label>First Name</label>\r\n            ");
                __builder2.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.InputText>(15);
                __builder2.AddAttribute(16, "class", (object)("form-control"));
                __builder2.AddAttribute(17, "Value", (object)(global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<global::System.String>(
#nullable restore
#line 15 "C:\Repository\RabbitMQ\Shabstec.BaggageSystem\Shabstec.BaggageSystem.Web\Pages\UserAdd.razor"
                                    model.FirstName

#line default
#line hidden
#nullable disable
                )));
                __builder2.AddAttribute(18, "ValueChanged", (object)(global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<global::Microsoft.AspNetCore.Components.EventCallback<global::System.String>>(global::Microsoft.AspNetCore.Components.EventCallback.Factory.Create<global::System.String>(this, global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => model.FirstName = __value, model.FirstName)))));
                __builder2.AddAttribute(19, "ValueExpression", (object)(global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<global::System.Linq.Expressions.Expression<System.Func<System.String>>>(() => model.FirstName)));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(20, "\r\n            ");
                global::__Blazor.Shabstec.BaggageSystem.Web.Pages.UserAdd.TypeInference.CreateValidationMessage_0(__builder2, 21, 22, 
#nullable restore
#line 16 "C:\Repository\RabbitMQ\Shabstec.BaggageSystem\Shabstec.BaggageSystem.Web\Pages\UserAdd.razor"
                                      () => model.FirstName

#line default
#line hidden
#nullable disable
                );
                __builder2.AddMarkupContent(23, "\r\n        ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(24, "\r\n        ");
                __builder2.OpenElement(25, "div");
                __builder2.AddAttribute(26, "class", "form-group col");
                __builder2.AddMarkupContent(27, "\r\n            ");
                __builder2.AddMarkupContent(28, "<label>Last Name</label>\r\n            ");
                __builder2.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.InputText>(29);
                __builder2.AddAttribute(30, "class", (object)("form-control"));
                __builder2.AddAttribute(31, "Value", (object)(global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<global::System.String>(
#nullable restore
#line 20 "C:\Repository\RabbitMQ\Shabstec.BaggageSystem\Shabstec.BaggageSystem.Web\Pages\UserAdd.razor"
                                    model.LastName

#line default
#line hidden
#nullable disable
                )));
                __builder2.AddAttribute(32, "ValueChanged", (object)(global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<global::Microsoft.AspNetCore.Components.EventCallback<global::System.String>>(global::Microsoft.AspNetCore.Components.EventCallback.Factory.Create<global::System.String>(this, global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => model.LastName = __value, model.LastName)))));
                __builder2.AddAttribute(33, "ValueExpression", (object)(global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<global::System.Linq.Expressions.Expression<System.Func<System.String>>>(() => model.LastName)));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(34, "\r\n            ");
                global::__Blazor.Shabstec.BaggageSystem.Web.Pages.UserAdd.TypeInference.CreateValidationMessage_1(__builder2, 35, 36, 
#nullable restore
#line 21 "C:\Repository\RabbitMQ\Shabstec.BaggageSystem\Shabstec.BaggageSystem.Web\Pages\UserAdd.razor"
                                      () => model.LastName

#line default
#line hidden
#nullable disable
                );
                __builder2.AddMarkupContent(37, "\r\n        ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(38, "\r\n    ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(39, "\r\n    ");
                __builder2.OpenElement(40, "div");
                __builder2.AddAttribute(41, "class", "form-row");
                __builder2.AddMarkupContent(42, "\r\n        ");
                __builder2.OpenElement(43, "div");
                __builder2.AddAttribute(44, "class", "form-group col");
                __builder2.AddMarkupContent(45, "\r\n            ");
                __builder2.AddMarkupContent(46, "<label>Username</label>\r\n            ");
                __builder2.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.InputText>(47);
                __builder2.AddAttribute(48, "class", (object)("form-control"));
                __builder2.AddAttribute(49, "Value", (object)(global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<global::System.String>(
#nullable restore
#line 27 "C:\Repository\RabbitMQ\Shabstec.BaggageSystem\Shabstec.BaggageSystem.Web\Pages\UserAdd.razor"
                                    model.Username

#line default
#line hidden
#nullable disable
                )));
                __builder2.AddAttribute(50, "ValueChanged", (object)(global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<global::Microsoft.AspNetCore.Components.EventCallback<global::System.String>>(global::Microsoft.AspNetCore.Components.EventCallback.Factory.Create<global::System.String>(this, global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => model.Username = __value, model.Username)))));
                __builder2.AddAttribute(51, "ValueExpression", (object)(global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<global::System.Linq.Expressions.Expression<System.Func<System.String>>>(() => model.Username)));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(52, "\r\n            ");
                global::__Blazor.Shabstec.BaggageSystem.Web.Pages.UserAdd.TypeInference.CreateValidationMessage_2(__builder2, 53, 54, 
#nullable restore
#line 28 "C:\Repository\RabbitMQ\Shabstec.BaggageSystem\Shabstec.BaggageSystem.Web\Pages\UserAdd.razor"
                                      () => model.Username

#line default
#line hidden
#nullable disable
                );
                __builder2.AddMarkupContent(55, "\r\n        ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(56, "\r\n        ");
                __builder2.OpenElement(57, "div");
                __builder2.AddAttribute(58, "class", "form-group col");
                __builder2.AddMarkupContent(59, "\r\n            ");
                __builder2.AddMarkupContent(60, "<label>Password</label>\r\n            ");
                __builder2.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.InputText>(61);
                __builder2.AddAttribute(62, "type", (object)("password"));
                __builder2.AddAttribute(63, "class", (object)("form-control"));
                __builder2.AddAttribute(64, "Value", (object)(global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<global::System.String>(
#nullable restore
#line 32 "C:\Repository\RabbitMQ\Shabstec.BaggageSystem\Shabstec.BaggageSystem.Web\Pages\UserAdd.razor"
                                    model.Password

#line default
#line hidden
#nullable disable
                )));
                __builder2.AddAttribute(65, "ValueChanged", (object)(global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<global::Microsoft.AspNetCore.Components.EventCallback<global::System.String>>(global::Microsoft.AspNetCore.Components.EventCallback.Factory.Create<global::System.String>(this, global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => model.Password = __value, model.Password)))));
                __builder2.AddAttribute(66, "ValueExpression", (object)(global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<global::System.Linq.Expressions.Expression<System.Func<System.String>>>(() => model.Password)));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(67, "\r\n            ");
                global::__Blazor.Shabstec.BaggageSystem.Web.Pages.UserAdd.TypeInference.CreateValidationMessage_3(__builder2, 68, 69, 
#nullable restore
#line 33 "C:\Repository\RabbitMQ\Shabstec.BaggageSystem\Shabstec.BaggageSystem.Web\Pages\UserAdd.razor"
                                      () => model.Password

#line default
#line hidden
#nullable disable
                );
                __builder2.AddMarkupContent(70, "\r\n        ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(71, "\r\n    ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(72, "\r\n    ");
                __builder2.OpenElement(73, "div");
                __builder2.AddAttribute(74, "class", "form-group");
                __builder2.AddMarkupContent(75, "\r\n        ");
                __builder2.OpenElement(76, "button");
                __builder2.AddAttribute(77, "disabled", 
#nullable restore
#line 37 "C:\Repository\RabbitMQ\Shabstec.BaggageSystem\Shabstec.BaggageSystem.Web\Pages\UserAdd.razor"
                           loading

#line default
#line hidden
#nullable disable
                );
                __builder2.AddAttribute(78, "class", "btn btn-primary");
                __builder2.AddMarkupContent(79, "\r\n");
#nullable restore
#line 38 "C:\Repository\RabbitMQ\Shabstec.BaggageSystem\Shabstec.BaggageSystem.Web\Pages\UserAdd.razor"
             if (loading) 
            {

#line default
#line hidden
#nullable disable
                __builder2.AddMarkupContent(80, "                <span class=\"spinner-border spinner-border-sm mr-1\"></span>\r\n");
#nullable restore
#line 41 "C:\Repository\RabbitMQ\Shabstec.BaggageSystem\Shabstec.BaggageSystem.Web\Pages\UserAdd.razor"
            }

#line default
#line hidden
#nullable disable
                __builder2.AddMarkupContent(81, "            Save\r\n        ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(82, "\r\n        ");
                __builder2.OpenComponent<global::Microsoft.AspNetCore.Components.Routing.NavLink>(83);
                __builder2.AddAttribute(84, "href", (object)("users"));
                __builder2.AddAttribute(85, "class", (object)("btn btn-link"));
                __builder2.AddAttribute(86, "ChildContent", (global::Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.AddContent(87, "Cancel");
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(88, "\r\n    ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(89, "\r\n");
            }
            ));
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
#nullable restore
#line 48 "C:\Repository\RabbitMQ\Shabstec.BaggageSystem\Shabstec.BaggageSystem.Web\Pages\UserAdd.razor"
       
    private AddUser model = new AddUser();
    private bool loading;

    private async void OnValidSubmit()
    {
        loading = true;
        try
        {
            await AccountService.AddUser(model);
            AlertService.Success("User added successfully", keepAfterRouteChange: true);
            NavigationManager.NavigateTo("users");
        }
        catch (Exception ex)
        {
            AlertService.Error(ex.Message);
            loading = false;
            StateHasChanged();
        }
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IAccountService AccountService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IAlertService AlertService { get; set; }
    }
}
namespace __Blazor.Shabstec.BaggageSystem.Web.Pages.UserAdd
{
    #line hidden
    internal static class TypeInference
    {
        public static void CreateValidationMessage_0<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg0)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.ValidationMessage<TValue>>(seq);
        __builder.AddAttribute(__seq0, "For", (object)__arg0);
        __builder.CloseComponent();
        }
        public static void CreateValidationMessage_1<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg0)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.ValidationMessage<TValue>>(seq);
        __builder.AddAttribute(__seq0, "For", (object)__arg0);
        __builder.CloseComponent();
        }
        public static void CreateValidationMessage_2<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg0)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.ValidationMessage<TValue>>(seq);
        __builder.AddAttribute(__seq0, "For", (object)__arg0);
        __builder.CloseComponent();
        }
        public static void CreateValidationMessage_3<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg0)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.ValidationMessage<TValue>>(seq);
        __builder.AddAttribute(__seq0, "For", (object)__arg0);
        __builder.CloseComponent();
        }
    }
}
#pragma warning restore 1591

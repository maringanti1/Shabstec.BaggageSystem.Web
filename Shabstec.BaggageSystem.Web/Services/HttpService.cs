using BlazorApp.Helpers;
using BlazorApp.Web.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorApp.Services
{
    public interface IHttpService
    {
        Task<T> Get<T>(string uri);
        Task Post(string uri, object value);
        Task<T> Post<T>(string uri, object value);
        Task Put(string uri, object value);
        Task<T> Put<T>(string uri, object value);
        Task Delete(string uri);
        Task<T> Delete<T>(string uri); 
    }

    public class HttpService : IHttpService
    {
        private HttpClient _httpClient;
        private NavigationManager _navigationManager;
        private ILocalStorageService _localStorageService;
        private IConfiguration _configuration;

        public HttpService(
            HttpClient httpClient,
            NavigationManager navigationManager,
            ILocalStorageService localStorageService,
            IConfiguration configuration
        ) {
            _httpClient = httpClient;
            _navigationManager = navigationManager;
            _localStorageService = localStorageService;
            _configuration = configuration;
        }

        public async Task<T> Get<T>(string uri)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            return await sendRequest<T>(request);
        }

        public async Task Post(string uri, object value)
        {
            var request = createRequest(HttpMethod.Post, uri, value);
            await sendRequest(request);
        }

        public async Task<T> Post<T>(string uri, object value)
        {
            var request = createRequest(HttpMethod.Post, uri, value);
            return await sendRequest<T>(request);
        }

        public async Task Put(string uri, object value)
        {
            var request = createRequest(HttpMethod.Put, uri, value);
            await sendRequest(request);
        }

        public async Task<T> Put<T>(string uri, object value)
        {
            var request = createRequest(HttpMethod.Put, uri, value);
            return await sendRequest<T>(request);
        }

        public async Task Delete(string uri)
        {
            var request = createRequest(HttpMethod.Delete, uri);
            await sendRequest(request);
        }

        public async Task<T> Delete<T>(string uri)
        {
            var request = createRequest(HttpMethod.Delete, uri);
            return await sendRequest<T>(request);
        }

        // helper methods

        private HttpRequestMessage createRequest(HttpMethod method, string uri, object value = null)
        {
            var request = new HttpRequestMessage(method, uri);
            if (value != null)
                request.Content = new StringContent(JsonSerializer.Serialize(value), Encoding.UTF8, "application/json");
            return request;
        }

        private async Task sendRequest(HttpRequestMessage request)
        {
            // Set the Origin header to indicate the source of the request
            //request.Headers.Add("Origin", "https://localhost:44330"); // Replace with your client's actual origin
            await addJwtHeader(request);

            // send request
            using var response = await _httpClient.SendAsync(request);

            // auto logout on 401 response
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                _navigationManager.NavigateTo("account/logout");
                return;
            }

            await handleErrors(response);
        }

        private async Task<T> sendRequest<T>(HttpRequestMessage request)
        {
            request.Headers.Add("Content-Type", "application/json");

            // Add JWT token or other headers if needed
            await addJwtHeader(request);         
            
            // Send the request
            using var response = await _httpClient.SendAsync(request);

            // Handle unauthorized response (401)
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                _navigationManager.NavigateTo("account/logout");
                return default;
            }

            await handleErrors(response);

            // Ensure successful response before attempting to deserialize
            if (response.IsSuccessStatusCode)
            {
                // Deserialize the response content to the specified entity type (T)
                return await response.Content.ReadFromJsonAsync<T>();
            }
            else
            {
                // Handle other non-success status codes as needed
                // You might throw an exception or return a default value, depending on your use case
                return default;
            }
        }



        //private async Task<T> sendRequest<T>(HttpRequestMessage request)
        //{
        //    await addJwtHeader(request);
        //    //request.Headers.Add("Content-Type", "application/json");

        //    //// Serialize your data to JSON and set it as the request content
        //    //var data = new { key1 = "value1", key2 = "value2" };
        //    //var json = JsonSerializer.Serialize(data);
        //    //request.Content = new StringContent(json, Encoding.UTF8, "application/json");


        //    // send request
        //    using var response = await _httpClient.SendAsync(request);

        //    // auto logout on 401 response
        //    if (response.StatusCode == HttpStatusCode.Unauthorized)
        //    {
        //        _navigationManager.NavigateTo("account/logout");
        //        return default;
        //    }

        //    await handleErrors(response);

        //    var options = new JsonSerializerOptions();
        //    options.PropertyNameCaseInsensitive = true;
        //    options.Converters.Add(new StringConverter());
        //    return await response.Content.ReadFromJsonAsync<T>(options);
        //}

        private async Task addJwtHeader(HttpRequestMessage request)
        {
            // add jwt auth header if user is logged in and request is to the api url
            var user = await _localStorageService.GetItem<User>("user");
            var isApiUrl = !request.RequestUri.IsAbsoluteUri;
            if (user != null && isApiUrl)
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", null);
        }

        private async Task handleErrors(HttpResponseMessage response)
        {
            // throw exception on error response
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadFromJsonAsync<Dictionary<string, string>>();
                throw new Exception(error["message"]);
            }
        }

     
    }
}
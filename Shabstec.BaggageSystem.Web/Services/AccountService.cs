using BlazorApp.Web.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;
using Configuration = BlazorApp.Web.Models.Configuration;
using Shabstec.BaggageSystem.Web.Models;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Linq;
using Microsoft.JSInterop;

namespace BlazorApp.Services
{
    public interface IAccountService
    {
        BlazorApp.Web.Models.User storedUserData { get; }
        Task Initialize();
        Task<bool> Login(Login model);
        Task Logout();
        Task Register(Registration model);

        Task AddUser(AddUser model);
        Task<List<BlazorApp.Web.Models.User>> GetAll();
        Task<IList<Configuration>> GetAllConfigurations(string userName, string organisation);
        Task<Configuration> GetConfigurationByID(string Username, string Organisation, string id);
        Task<IList<Configuration>> GetUserConfigurations(string userName, string organisation);
        Task<IList<BrokerMessage>> GetAllMessages(string userName, string organisation);
        Task<IList<BrokerMessage>> GetAllPublishedMessages(string userName, string organisation); 
        Task<BlazorApp.Web.Models.User> GetLoggedInUserDetails();
        Task<BlazorApp.Web.Models.User> GetById(string id);
        Task Update(string id, EditUser model);
        Task Delete(string id);
        Task Baggage(Configuration model);
        Task LaunchDeployment(Configuration configuration);
        Task<List<string>> GetCountryCodeList();
        Task<List<AirlineInfo>> GetAirlineList();

        Task<List<AirlineInfo>> GetAirportCodes();

        Task<bool> UploadMessage(MessageModel messageModel);
    }

    public class AccountService : IAccountService
    {
        private readonly ILogger<AccountService> logger;
        private IHttpService _httpService;
        private NavigationManager _navigationManager;
        private ILocalStorageService _localStorageService;
        private string _userKey = "user";
        private readonly HttpClient httpClient;
        public BlazorApp.Web.Models.User storedUserData { get; private set; }


        public AccountService(ILogger<AccountService> logger,
            IHttpService httpService,
            NavigationManager navigationManager,
            ILocalStorageService localStorageService,
            IConfiguration configuration
        )
        {
            this.logger = logger;
            _httpService = httpService;
            _navigationManager = navigationManager;
            _localStorageService = localStorageService;
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(configuration["ApiUrl"]);
        }

        public AccountService()
        {
        }

        public async Task Initialize()
        {
            storedUserData = await _localStorageService.GetItem<BlazorApp.Web.Models.User>(_userKey);

        }


        public async Task<BlazorApp.Web.Models.User> GetLoggedInUserDetails()
        {
            try
            {
                storedUserData = await _localStorageService.GetItem<BlazorApp.Web.Models.User>(_userKey);
                if (storedUserData == null || DateTime.Now.Ticks > storedUserData.ExpirationTimestamp)
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return storedUserData;
        }


        // Define the expiration duration (1 hour in milliseconds)
        private const long _expirationDuration = 1 * 60 * 60 * 1000; // 1 hour in milliseconds

        public async Task<bool> Login(Login model)
        {
            storedUserData = null;
            await _localStorageService.RemoveItem(_userKey);
            Web.Models.User userDetails = new Web.Models.User();
            try
            {
                // Send the POST request with the model
                HttpResponseMessage response = await httpClient.PostAsJsonAsync("/User/Authenticate", model);

                if (response.IsSuccessStatusCode)
                {
                    userDetails = await response.Content.ReadFromJsonAsync<BlazorApp.Web.Models.User>();
                    storedUserData = new Web.Models.User();
                    // Update User properties with data from the model
                    storedUserData.FirstName = userDetails.FirstName;
                    storedUserData.LastName = userDetails.LastName;
                    storedUserData.Username = userDetails.Username;
                    storedUserData.Organisation = userDetails.Organisation;
                    // Store user data with a timestamp in localStorage
                    DateTime expirationTime = DateTime.Now.AddMilliseconds(_expirationDuration);
                    storedUserData.ExpirationTimestamp = expirationTime.Ticks;
                    await _localStorageService.SetItem(_userKey, storedUserData);
                    return true;
                }
                else
                {
                    storedUserData = null;
                    await _localStorageService.RemoveItem(_userKey);
                    logger.LogError("An error occurred in Login");
                    _navigationManager.NavigateTo("/");
                    return false;
                    // Handle the error response here
                }
            }
            catch (Exception ex)
            {
                storedUserData = null;
                await _localStorageService.RemoveItem(_userKey);
                // Log the exception using the injected logger
                logger.LogError(ex, "An error occurred in Login");
                _navigationManager.NavigateTo("/");
                return false;
            }
        }

        public async Task Logout()
        {
            storedUserData = null;
            await _localStorageService.RemoveItem(_userKey);
            _navigationManager.NavigateTo("/");
        }

        public async Task AddUser(AddUser model)
        {
            try
            {
                // Send the POST request with the model
                HttpResponseMessage response = await httpClient.PostAsJsonAsync("/User/CreateUser", model);
                if (response.IsSuccessStatusCode)
                {
                    // Deserialize the response content into a User object
                    storedUserData = await response.Content.ReadFromJsonAsync<BlazorApp.Web.Models.User>();
                    // Store the User object in localStorage or wherever you need
                    storedUserData = null;
                    await _localStorageService.RemoveItem(_userKey);
                }
                else
                {
                    // Handle the error response here
                }
            }
            catch (Exception ex)
            {
                // Log the exception using the injected logger
                logger.LogError(ex, "An error occurred in Register");
            }
        }

        public async Task Register(Registration model)
        {
            try
            {
                // Send the POST request with the model
                HttpResponseMessage response = await httpClient.PostAsJsonAsync("/User/RegisterUser", model);

                if (response.IsSuccessStatusCode)
                {
                    // Deserialize the response content into a User object
                    //User = await response.Content.ReadFromJsonAsync<BlazorApp.Web.Models.User>(); 
                    // Store the User object in localStorage or wherever you need
                    await _localStorageService.RemoveItem(_userKey);
                }
                else
                {
                    await _localStorageService.RemoveItem(_userKey);
                    // Handle the error response here
                }
            }
            catch (Exception ex)
            {
                // Log the exception using the injected logger
                logger.LogError(ex, "An error occurred in Register");
            }
        }
        public async Task<bool> UploadMessage(MessageModel messageModel)
        {
            try
            {
                // Send the POST request with the model
                HttpResponseMessage response = await httpClient.PostAsJsonAsync("/Baggage/UploadMessage", messageModel);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                // Log the exception using the injected logger
                logger.LogError(ex, "An error occurred in Baggage");
                return false;
            }
        }

        public async Task Baggage(Configuration model)
        {
            model.UserName = storedUserData.Username;
            try
            {

                // Send the POST request with the model
                HttpResponseMessage response = await httpClient.PostAsJsonAsync("/Baggage/SaveConfiguration", model);

                if (response.IsSuccessStatusCode)
                {
                    // Deserialize the response content into a User object

                }
                else
                {
                    // Handle the error response here
                }
            }
            catch (Exception ex)
            {
                // Log the exception using the injected logger
                logger.LogError(ex, "An error occurred in Baggage");
            }
        }
        public async Task<Configuration> GetConfigurationByID(string userName, string organisation, string id)
        {
            try
            {
                // Send the GET request to retrieve configurations
                //HttpResponseMessage response = await httpClient.GetAsync("/Baggage/GetAllConfigurations");
                //List<Configuration> configurations = new List<Configuration>();
                string url = $"/Baggage/GetAllConfigurations?userName={Uri.EscapeDataString(userName)}&organisation={Uri.EscapeDataString(organisation)}";
                // Send the POST request to retrieve configurations
                //HttpResponseMessage response = await httpClient.GetAsync("/Baggage/GetAllConfigurations");
                HttpResponseMessage response = await httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    // Read the response content as a string 
                    string responseContent = await response.Content.ReadAsStringAsync();
                    // Create JsonSerializerOptions with CaseInsensitivePropertyNamingPolicy
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase, // or JsonNamingPolicy.SnakeCase
                                                                           // Add any additional options if needed
                    };
                    // Deserialize the response content into a list of Configuration objects
                    List<Configuration> configurations = JsonSerializer.Deserialize<List<Configuration>>(responseContent, options);
                    // Filter configurations based on userName and organisation
                    configurations = configurations
                        .Where(x => x.Organization?.ToLower() == organisation.ToLower() &&
                                    x.UserName?.ToLower() == userName.ToLower() && x.id == id)
                        .ToList();
                    return configurations.FirstOrDefault();
                }
                else
                {
                    // Handle the error response here, e.g., log or throw a custom exception
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Failed to retrieve configurations. Status code: {response.StatusCode}. Error message: {errorMessage}");
                }
            }
            catch (Exception ex)
            {
                // Log the exception using the injected logger
                logger.LogError(ex, "An error occurred in GetUserConfigurations");
                return null;
            }
        }

        public async Task<IList<Configuration>> GetUserConfigurations(string userName, string organisation)
        {
            try
            {
                // Send the GET request to retrieve configurations
                //HttpResponseMessage response = await httpClient.GetAsync("/Baggage/GetAllConfigurations");
                //List<Configuration> configurations = new List<Configuration>();
                string url = $"/Baggage/GetAllConfigurations?userName={Uri.EscapeDataString(userName)}&organisation={Uri.EscapeDataString(organisation)}";
                // Send the POST request to retrieve configurations
                //HttpResponseMessage response = await httpClient.GetAsync("/Baggage/GetAllConfigurations");
                HttpResponseMessage response = await httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    // Read the response content as a string 
                    string responseContent = await response.Content.ReadAsStringAsync();
                    // Create JsonSerializerOptions with CaseInsensitivePropertyNamingPolicy
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase, // or JsonNamingPolicy.SnakeCase
                                                                           // Add any additional options if needed
                    };
                    // Deserialize the response content into a list of Configuration objects
                    List<Configuration> configurations = JsonSerializer.Deserialize<List<Configuration>>(responseContent, options);
                    // Filter configurations based on userName and organisation
                    configurations = configurations
                        .Where(x => x.Organization?.ToLower() == organisation.ToLower() &&
                                    x.UserName?.ToLower() == userName.ToLower())
                        .ToList();
                    return configurations;
                }
                else
                {
                    // Handle the error response here, e.g., log or throw a custom exception
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Failed to retrieve configurations. Status code: {response.StatusCode}. Error message: {errorMessage}");
                }
            }
            catch (Exception ex)
            {
                // Log the exception using the injected logger
                logger.LogError(ex, "An error occurred in GetUserConfigurations");
                return null;
            }
        }

        public async Task<IList<Configuration>> GetAllConfigurations(string userName, string organisation)
        {
            try
            {
                List<Configuration> configurations = new List<Configuration>();
                string url = $"/Baggage/GetAllConfigurations?userName={Uri.EscapeDataString(userName)}&organisation={Uri.EscapeDataString(organisation)}";
                // Send the POST request to retrieve configurations
                //HttpResponseMessage response = await httpClient.GetAsync("/Baggage/GetAllConfigurations");
                HttpResponseMessage response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    // Deserialize the response content into a list of Configuration objects
                    configurations = await response.Content.ReadFromJsonAsync<List<Configuration>>(); 
                }
                else
                {
                    // Handle the error response here, e.g., log or throw an exception
                    // For example, you can throw an exception with a specific message:
                    throw new Exception("Failed to retrieve configurations. Status code: " + response.StatusCode);
                }
                return configurations;
            }
            catch (Exception ex)
            {
                // Log the exception using the injected logger
                logger.LogError(ex, "An error occurred in GetAllConfigurations");
                return null;
            }

        }

        public async Task LaunchDeployment(Configuration configuration)
        {

            try
            {
                // Send a POST request to the BuildAndPushImages action
                var response = await httpClient.PostAsJsonAsync("api/deployment/BuildAndPushImages", configuration);

                if (response.IsSuccessStatusCode)
                {
                    // Handle success
                    // You can display a success message or perform other actions
                }
                else
                {
                    // Handle failure
                    // You can display an error message or perform other error-handling actions
                }
            }
            catch (Exception ex)
            {
                // Log the exception using the injected logger
                logger.LogError(ex, "An error occurred in LaunchDeployment");
                return;
            }
        }

        public async Task<List<BlazorApp.Web.Models.User>> GetAll()
        {
            List<BlazorApp.Web.Models.User> users = new List<BlazorApp.Web.Models.User>();
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync("/User/GetAllUsers");

                if (response.IsSuccessStatusCode)
                {
                    // Deserialize the response content into a list of Configuration objects
                    users = await response.Content.ReadFromJsonAsync<List<BlazorApp.Web.Models.User>>();
                }
                else
                {
                    // Handle the error response here, e.g., log or throw an exception
                    // For example, you can throw an exception with a specific message:
                    throw new Exception("Failed to retrieve users. Status code: " + response.StatusCode);
                }
                return users;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred in GetAll");
                return users;
            }
        }

        public Task<BlazorApp.Web.Models.User> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Task Update(string id, EditUser model)
        {
            throw new NotImplementedException();
        }

        public Task Delete(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<BrokerMessage>> GetAllMessages(string userName, string organisation)
        {
            try
            {
                List<BrokerMessage> configurations = new List<BrokerMessage>();
                // Construct the URL with query parameters
                string url = $"/Baggage/GetAllMessages?userName={Uri.EscapeDataString(userName)}&organisation={Uri.EscapeDataString(organisation)}";

                // Send the GET request to retrieve configurations
                HttpResponseMessage response = await httpClient.GetAsync(url);
                configurations = configurations
                       .Where(x => x.ClientID?.ToLower() == organisation.ToLower())
                       .ToList();
                if (response.IsSuccessStatusCode)
                {
                    // Deserialize the response content into a list of Configuration objects
                    configurations = await response.Content.ReadFromJsonAsync<List<BrokerMessage>>();
                }
                else
                {
                    // Handle the error response here, e.g., log or throw an exception
                    // For example, you can throw an exception with a specific message:
                    throw new Exception("Failed to retrieve configurations. Status code: " + response.StatusCode);
                }
                return configurations;
            }
            catch (Exception ex)
            {
                // Log the exception using the injected logger
                logger.LogError(ex, "An error occurred in GetAllConfigurations");
                return null;
            }

        }

        public async Task<IList<BrokerMessage>> GetAllPublishedMessages(string userName, string organisation)
        {
            try
            {
                List<BrokerMessage> configurations = new List<BrokerMessage>();
                // Construct the URL with query parameters
                string url = $"/Baggage/GetAllPublishedMessages?userName={Uri.EscapeDataString(userName)}&organisation={Uri.EscapeDataString(organisation)}";

                // Send the GET request to retrieve configurations
                HttpResponseMessage response = await httpClient.GetAsync(url);
                configurations = configurations
                       .Where(x => x.ClientID?.ToLower() == organisation.ToLower())
                       .ToList();
                if (response.IsSuccessStatusCode)
                {
                    // Deserialize the response content into a list of Configuration objects
                    configurations = await response.Content.ReadFromJsonAsync<List<BrokerMessage>>();
                }
                else
                {
                    // Handle the error response here, e.g., log or throw an exception
                    // For example, you can throw an exception with a specific message:
                    throw new Exception("Failed to retrieve configurations. Status code: " + response.StatusCode);
                }
                return configurations;
            }
            catch (Exception ex)
            {
                // Log the exception using the injected logger
                logger.LogError(ex, "An error occurred in GetAllConfigurations");
                return null;
            }

        }

        public async Task<List<string>> GetCountryCodeList()
        {
            List<string> countries = new List<string>();
            try
            {

                HttpResponseMessage response = await httpClient.GetAsync("/Baggage/GetAllCountryCodes");
                if (response.IsSuccessStatusCode)
                {
                    countries = await response.Content.ReadFromJsonAsync<List<string>>();
                }
                return countries;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<AirlineInfo>> GetAirlineList()
        {
            List<AirlineInfo> airlines = new List<AirlineInfo>();
            try
            {

                HttpResponseMessage response = await httpClient.GetAsync("/Baggage/GetAirlineCodes");
                if (response.IsSuccessStatusCode)
                {
                    airlines = await response.Content.ReadFromJsonAsync<List<AirlineInfo>>();
                }
                return airlines;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<AirlineInfo>> GetAirportCodes()
        {
            List<AirlineInfo> airports = new List<AirlineInfo>();
            try
            {

                HttpResponseMessage response = await httpClient.GetAsync("/Baggage/GetAirportCodes");
                if (response.IsSuccessStatusCode)
                {
                    airports = await response.Content.ReadFromJsonAsync<List<AirlineInfo>>();
                }
                return airports;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //public async Task  DownloadMessage(BrokerMessage configuration)
        //{
        //    try
        //    {
        //        // Serialize the configuration object to a query string
        //        string queryString = $"?param1={configuration.Message}&param2={configuration.CreateDate}&param3={configuration.ClientID}"; // Adjust property names accordingly

        //        // Send the GET request to retrieve configurations
        //        HttpResponseMessage response = await httpClient.GetAsync("/Baggage/DownloadMessage" + queryString);

        //        if (response.IsSuccessStatusCode)
        //        {
        //            // Check the response content type, assuming it's an octet-stream
        //            var contentType = response.Content.Headers.ContentType?.ToString() ?? "application/octet-stream";

        //            // Extract the file content from the response
        //            var fileContent = await response.Content.ReadAsByteArrayAsync();

        //            // Return the file as a FileContentResult
        //            return System.IO.File(fileContent, contentType, "yourDownloadedFile.xml");
        //        }
        //        else
        //        {
        //            // Handle the error response here, e.g., log or throw an exception
        //            // For example, you can throw an exception with a specific message:
        //            throw new Exception("Failed to retrieve configurations. Status code: " + response.StatusCode);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log the exception using the injected logger
        //        logger.LogError(ex, "An error occurred in GetAllConfigurations");
        //        return null;
        //    }
        //}
        //private async Task DownloadFile(BrokerMessage brokerMessage)
        //{
        //    try
        //    {
        //        // Replace with the actual values from your BrokerMessage
        //        var param1 = brokerMessage.Message;

        //        // Convert the string to byte array assuming it's a base64-encoded string
        //        var fileContent = Convert.FromBase64String(param1);

        //        // Trigger the file download using JavaScript interop
        //        await JSRuntime.InvokeVoidAsync("downloadFile", fileContent, "yourDownloadedFile.xml");
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log or handle the exception as needed
        //        logger.LogError(ex, "An error occurred in DownloadFile");
        //    }
        //}

    }
}
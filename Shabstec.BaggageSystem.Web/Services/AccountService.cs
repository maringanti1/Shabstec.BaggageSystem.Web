using BlazorApp.Web.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging; 
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Configuration = BlazorApp.Web.Models.Configuration;

namespace BlazorApp.Services
{
    public interface IAccountService
    {
        BlazorApp.Web.Models.User User { get; }
        Task Initialize();
        Task Login(Login model);
        Task Logout();
        Task Register(Registration model);

        Task AddUser(AddUser model);
        Task<List<BlazorApp.Web.Models.User>> GetAll();
        Task<IList<Configuration>> GetAllConfigurations();
        Task<IList<BrokerMessage>> GetAllMessages();
        Task<BlazorApp.Web.Models.User> GetLoggedInUserDetails();

        Task<BlazorApp.Web.Models.User> GetById(string id);
        Task Update(string id, EditUser model);
        Task Delete(string id);

        Task Baggage(Configuration model);
        Task LaunchDeployment(Configuration configuration);
    }

    public class AccountService : IAccountService
    {
        private readonly ILogger<AccountService> logger;
        private IHttpService _httpService;
        private NavigationManager _navigationManager;
        private ILocalStorageService _localStorageService;
        private string _userKey = "user";
        private readonly HttpClient httpClient;
        public BlazorApp.Web.Models.User User { get; private set; }

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

        public async Task  Initialize()
        {
            User = await _localStorageService.GetItem<BlazorApp.Web.Models.User>(_userKey);
        }


        public async Task<BlazorApp.Web.Models.User> GetLoggedInUserDetails()
        {
           return User = await _localStorageService.GetItem<BlazorApp.Web.Models.User>(_userKey);
        }



        public async Task Login(Login model)
        { 
            Web.Models.User user = new Web.Models.User();
            try
            {
                // Send the POST request with the model
                HttpResponseMessage response = await httpClient.PostAsJsonAsync("/User/Authenticate", model);

                if (response.IsSuccessStatusCode)
                {
                    // Update User properties with data from the model
                    user.FirstName = model.Username;
                    user.LastName = model.Username;
                    user.Username = model.Username; 
                    User = user;
                    await _localStorageService.SetItem(_userKey, user);
                }
                else
                {
                    User = null;
                    await _localStorageService.RemoveItem(_userKey);
                    logger.LogError("An error occurred in Login");
                    // Handle the error response here
                }
            }
            catch (Exception ex)
            {
                User = null;
                await _localStorageService.RemoveItem(_userKey);
                // Log the exception using the injected logger
                logger.LogError(ex, "An error occurred in Login");
            }
        }

        public async Task Logout()
        {
            User = null;
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
                    User = await response.Content.ReadFromJsonAsync<BlazorApp.Web.Models.User>();



                    // Store the User object in localStorage or wherever you need
                    await _localStorageService.SetItem(_userKey, User);
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
                    User = await response.Content.ReadFromJsonAsync<BlazorApp.Web.Models.User>(); 
                    // Store the User object in localStorage or wherever you need
                    await _localStorageService.SetItem(_userKey, User);
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

        public async Task Baggage(Configuration model)
        {
            model.UserName = User.Username;
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

        public async Task<IList<Configuration>> GetAllConfigurations()
        {
            try
            {
                List<Configuration> configurations = new List<Configuration>();

                // Send the POST request to retrieve configurations
                HttpResponseMessage response = await httpClient.GetAsync("/Baggage/GetAllConfigurations");

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
            }catch(Exception ex)
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

        public async Task<IList<BrokerMessage>> GetAllMessages()
        {
            try
            {
                List<BrokerMessage> configurations = new List<BrokerMessage>();

                // Send the POST request to retrieve configurations
                HttpResponseMessage response = await httpClient.GetAsync("/Baggage/GetAllMessages");

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
    }
}
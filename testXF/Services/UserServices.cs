using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using testXF.Models;

namespace testXF.Services
{
    public class UserServices
    {
        private const string url = "https://jsonplaceholder.typicode.com/posts/";
        public async Task<List<User>> GetUsersAsync()
        {
            RestClient<User> restClient = new RestClient<User>(url);
            var users = await restClient.GetAsync();

            return null;
        }
        public async Task<bool> PostAsync(User user)
        {
            RestClient<User> restClient = new RestClient<User>(url);
            var res = await restClient.PostAsync(user);

            return res;
        }
    }
}

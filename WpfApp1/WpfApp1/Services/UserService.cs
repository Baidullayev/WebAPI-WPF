using MahApps.Metro.Controls.Dialogs;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using WpfApp1.Models;

namespace WpfApp1.Services
{
    
    class UserService
    {
        HttpService httpService = new HttpService();
        public List<User> GetAllUsers()
        {
            string url = "http://localhost:4702/api/users/getall";
            var httpResponce = httpService.HttpWebRequest(null, url);
            var users = JsonConvert.DeserializeObject<List<User>>(httpResponce);
            return users;
        }
        public string Create(string username, string firstname, string lastname, string password)
        {
            string url = "http://localhost:4702/api/users/create";
            object jsonObject = JsonConvert.SerializeObject(new
            {
                username = username,
                firstname = firstname,
                lastname = lastname,
                password = password
            });

            string httpResponce = httpService.HttpWebRequest(jsonObject, url);
            return httpResponce;
            //List<User> allUsers = new List<User>(JsonConvert.DeserializeObject<List<User>>(result));
        }

        public string Authenticate(string username = "test", string password = "test")
        {
            string url = "http://localhost:4702/api/users/authenticate";
                object jsonObject = JsonConvert.SerializeObject(new {
                    username = username,
                    password = password
                });
            string httpResponce = httpService.HttpWebRequest(jsonObject, url);


            if(httpResponce.Contains("username"))
            {
                try
                {
                    User response = JsonConvert.DeserializeObject<User>(httpResponce);
                    App.username = response.Username;
                    App.userToken = response.Token;
                    App.id = response.Id;
                    MainWindow s =  new MainWindow();
                    ((MainWindow)System.Windows.Application.Current.MainWindow).SignOutMenuItem.Header = "Sign out " + response.Username;
                    //s.chaChangeMenuItemHeader.
                    return "success";
                }catch(Exception ex)
                {
                    return ex.Message;
                }

            }else if(httpResponce.Contains("(400)"))
            {
                return "Incorrect login or password";
            }
            return httpResponce;
        }
     }
}
    


using CVApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CVApp.Services
{
    public class ConvertToViewModel
    {
       
        public UserDetailsViewModel convert(IEnumerable<dynamic> data)
        {
            UserDetailsViewModel userDetails = new UserDetailsViewModel();

            foreach (var item in data)
            {
                userDetails.FirstName = item["FirstName"].ToString();
                userDetails.Email = item["Email"].ToString();
                userDetails.Phone = Int32.Parse(item["Phone"].ToString());            
            }
            return userDetails;
        }

        public List<UserViewModel> convertToUserList(IEnumerable<dynamic> data)
        {
            List<UserViewModel> user = new List<UserViewModel> { };
            foreach (var item in data)
            {

                user.Add(new UserViewModel
                {
                    username = item["Username"].ToString(),
                    Password = item["Password"].ToString(),
                    Email = item["Email"].ToString()
                });

            }
            return user;
        }
    }
}
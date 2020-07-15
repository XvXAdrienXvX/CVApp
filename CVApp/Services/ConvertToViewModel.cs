using CVApp.Models;
using System;
using System.Collections.Generic;

namespace CVApp.Services
{
    public class ConvertToViewModel
    {
       
        public UserDetailsViewModel convert(IEnumerable<dynamic> data)
        {
            UserDetailsViewModel userDetails = new UserDetailsViewModel();
            userDetails.skills = new List<SkillsViewModel>();
            List<SkillsViewModel> skills = new List<SkillsViewModel>();

            foreach (var item in data)
            {              
                    userDetails.FirstName = item.GetType().GetProperty("FirstName").GetValue(item);
                    userDetails.Email = item.GetType().GetProperty("Email").GetValue(item);
                    userDetails.Phone = item.GetType().GetProperty("Phone").GetValue(item);
                    userDetails.Resume = item.GetType().GetProperty("Resume").GetValue(item);
                    userDetails.Admin = item.GetType().GetProperty("Admin").GetValue(item);

                foreach (dynamic obj in item.GetType().GetProperty("Skills").GetValue(item))
                {
                    skills.Add(new SkillsViewModel() { ShortName = obj.GetType().GetProperty("ShortName").GetValue(obj), SkillLevel = Convert.ToInt32(obj.GetType().GetProperty("SkillLevel").GetValue(obj)) });
                }
            }

            userDetails.skills.AddRange(skills);

            return userDetails;
        }

        public List<UserViewModel> convertToUserList(IEnumerable<dynamic> data)
        {
            List<UserViewModel> user = new List<UserViewModel> ();
            foreach (var item in data)
            {

                user.Add(new UserViewModel
                {
                    username = item["Username"].ToString(),
                    Email = item["Email"].ToString()
                });

            }
            return user;
        }

        public List<UserSkillsViewModel> convertToSkillList(IEnumerable<dynamic> data)
        {
            List<UserSkillsViewModel> skills = new List<UserSkillsViewModel> ();
            foreach (var item in data)
            {

                skills.Add(new UserSkillsViewModel
                {
                    UserSkillID = Convert.ToInt32(item["UserSkillId"]),
                    ShortName = item["ShortName"].ToString(),
                    SkillLevel = Convert.ToInt32(item["SkillLevel"])
                });

            }
            return skills;
        }
    }
}
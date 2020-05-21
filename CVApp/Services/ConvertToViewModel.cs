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
            userDetails.skills = new List<SkillsViewModel>();
            List<SkillsViewModel> skills = new List<SkillsViewModel>();

            foreach (var item in data)
            {
                userDetails.UserId = Convert.ToInt32(item["UserId"]);
                userDetails.Username = item["Username"].ToString();
                userDetails.FirstName = item["FirstName"].ToString();
                userDetails.Email = item["Email"].ToString();
                userDetails.Phone = Int32.Parse(item["Phone"].ToString());
                userDetails.Resume = item["Resume"].ToString();
                userDetails.Admin = (bool)item["Admin"];
                skills.Add( new SkillsViewModel() { ShortName = item["ShortName"].ToString(), SkillLevel = Convert.ToInt32(item["SkillLevel"])});
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
                    Password = item["Password"].ToString(),
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
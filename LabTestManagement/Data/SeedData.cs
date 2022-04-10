﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabTestManagement.Data
{
    public class SeedData
    {
        public static void Seed(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }

        private static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("NormalUser").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "NormalUser";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }


            if (!roleManager.RoleExistsAsync("Doctor").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Doctor";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }


            if (!roleManager.RoleExistsAsync("Administrator").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Administrator";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }
        }

        private static void SeedUsers(UserManager<IdentityUser> userManager)
        {
            if (userManager.FindByNameAsync("admin@localhost").Result == null)
            {
                IdentityUser user = new IdentityUser();
                user.UserName = "admin@localhost";
                user.Email = "admin@localhost";

                IdentityResult result = userManager.CreateAsync(user, "Admin123!").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Administrator").Wait();
                }
            }


            if (userManager.FindByNameAsync("editor@localhost").Result == null)
            {
                IdentityUser user = new IdentityUser();
                user.UserName = "editor@localhost";
                user.Email = "editor@localhost";

                IdentityResult result = userManager.CreateAsync(user, "Editor123!").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "NormalUser").Wait();
                }
            }

            if (userManager.FindByNameAsync("doctor@localhost").Result == null)
            {
                IdentityUser user = new IdentityUser();
                user.UserName = "doctor@localhost";
                user.Email = "doctor@localhost";

                IdentityResult result = userManager.CreateAsync(user, "Doctor123!").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Doctor").Wait();
                }
            }
        }
    }
}
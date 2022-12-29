using Operator_Rounds_Management_System.Models;
using Operator_Rounds_Management_System.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Operator_Rounds_Management_System.Enums;

namespace Operator_Rounds_Management_System.Services
{
    public class DataService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public DataService(ApplicationDbContext dbContext, RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager)
        {
            _dbContext = dbContext;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task ManageDataAsync()
        {
            // Task: Create the DB from the Migrations
            await _dbContext.Database.MigrateAsync();


            // Task 1: Seed a few roles into the system
            await SeedRolesAsync();

            // Task 2: Seed a few user in to the system
            await SeedUsersAsync();

        }

        private async Task SeedRolesAsync()
        {
            //If are already Roles in the system, do nothing.
            if (_dbContext.Roles.Any())
            {
                return;
            }

            //Otherwise we want to create a few roles.
            foreach (var role in Enum.GetNames(typeof(UserRoles)))
            {
                // I need to use the Role Manager to create roles
                await _roleManager.CreateAsync(new IdentityRole(role));

            }

        }

        private async Task SeedUsersAsync()
        {
            // if there are already users in the system do nothing
            if (_dbContext.Users.Any())
            {
                return;
            }

            // otherwise we want to create a few users.
            // Step 1: creates a new instance of BlogUser.
            var adminUser = new AppUser()
            {
                Email = "lyons.bart@protonmail.com",
                UserName = "lyons.bart@protonmail.com",
                FirstName = "Bart",
                LastName = "Lyons",
                PhoneNumber = "8598433629",
                EmailConfirmed = true,
                EmployeeId = 0001

            };

            // Step 2:  use the user manager to create a new user that is defined by adminUser
            await _userManager.CreateAsync(adminUser, "Abc&123!");

            // Step 3: add this new user to the admin role.

            await _userManager.AddToRoleAsync(adminUser, UserRoles.Administrator.ToString());

            // Step 1 repeat: Create the moderator user
            var leaderUser = new AppUser()
            {
                Email = "lyons.bart@outlook.com",
                UserName = "lyons.bart@outlook.com",
                FirstName = "Bart",
                LastName = "Lyons",
                PhoneNumber = "8508433629",
                EmailConfirmed = true,
                EmployeeId = 0002
            };

            // Step 2:  use the user manager to create a new user that is defined by modUser
            await _userManager.CreateAsync(leaderUser, "Abc&123!");


            // Step 3: add this new user to the mod role.

            await _userManager.AddToRoleAsync(leaderUser, UserRoles.Leader.ToString());

            // Step 1 repeat: Create the moderator user
            var operatorUser = new AppUser()
            {
                Email = "lyons.bart@ghatazhak.com",
                UserName = "lyons.bart@ghatazhak.com",
                FirstName = "Bart",
                LastName = "Lyons",
                PhoneNumber = "8508433629",
                EmailConfirmed = true,
                EmployeeId = 0003
            };

            // Step 2:  use the user manager to create a new user that is defined by modUser
            await _userManager.CreateAsync(operatorUser, "Abc&123!");


            // Step 3: add this new user to the mod role.

            await _userManager.AddToRoleAsync(operatorUser, UserRoles.Operator.ToString());




        }
    }
}

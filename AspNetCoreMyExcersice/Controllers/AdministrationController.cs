using AspNetCoreMyExersice.DTO.Models;
using AspNetCoreMyExersice.DTO.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreMyExcersice.Controllers
{
    public class AdministrationController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserManager<ApplicationUser> _userManager { get; }

        public AdministrationController(RoleManager<IdentityRole> roleManager,UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }
        public async Task<ActionResult> CreateRole(CreateRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole()
                {
                    Name = model.RoleName
                };
                IdentityResult result = await _roleManager.CreateAsync(identityRole);
                if(result.Succeeded)
                {
                    return RedirectToAction("ListRoles");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult ListRoles()
        {
            var roles = _roleManager.Roles;
            return View(roles);
        }
        [HttpGet]
        public async Task<IActionResult> EditRole(string id)
        {
            var role =await _roleManager.FindByIdAsync(id);
            if(role == null)
            {
                throw new Exception("Record Not Found");
            }


            var model = new EditRoleViewModel()
            {
                RoleId = id,
                RoleName = role.Name,
            };

            var users = _userManager.Users.ToList();
            foreach (var user in  users)
            {
                if(await _userManager.IsInRoleAsync(user,model.RoleName))
                {
                    model.Users.Add(user.UserName);
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditRole(EditRoleViewModel viewModel)
        {
            var role = await _roleManager.FindByIdAsync(viewModel.RoleId);
            if (role == null)
            {
                throw new Exception("Record Not Found");
            }


            role.Name = viewModel.RoleName;
            var result = await _roleManager.UpdateAsync(role);
            if(result.Succeeded)
            {
                return RedirectToAction("ListRoles");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
           
            return View(viewModel);
        }
    }
}

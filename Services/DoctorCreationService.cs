using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testing.Models;

namespace testing.Services
{
    public class DoctorCreationService : IDoctorCreationService
    {
        private readonly MedicalContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public DoctorCreationService(MedicalContext context,
            RoleManager<IdentityRole> roleManager, 
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }
        public async Task<IdentityResult> CreateDoctor([FromServices] IPasswordGenerator generator,[FromServices] IEmailSender sender,RegisterDoctorVM doctor)
        {
            var password = generator.GeneratePassword(16);
            var user = new IdentityUser { UserName = doctor.Email,
                                            Email = doctor.Email,
                                            PhoneNumber = doctor.Phone};
            var result = await _userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Doctor");
                int headDoctorId = _context.Set<Role>().Where(r => r.Name == "Главный врач").Select(r => r.Id).First();
                if(doctor.RoleId == headDoctorId)
                {
                await _userManager.AddToRoleAsync(user, "HeadDoctor");
                }
                var created_user = await _userManager.FindByEmailAsync(doctor.Email);
                Doctor doc = (Doctor)doctor;
                doc.UserId = created_user.Id;
                await _context.Doctors.AddAsync(doc);
                await _context.SaveChangesAsync();
                sender.SendMail(user.Email, doc.Firstname, password);
                return IdentityResult.Success;

            }
            var error = new IdentityError() {
                Description = "Error while creating IdentityRecord for the record!"};
            return IdentityResult.Failed(error);
        }
    }
}

using Microsoft.AspNetCore.Identity;
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
        public async Task<IdentityResult> CreateDoctor(RegisterDoctorVM doctor)
        {
            var user = new IdentityUser { UserName = doctor.Email,
                                            Email = doctor.Email,
                                            PhoneNumber = doctor.Phone};
            var result = await _userManager.CreateAsync(user, doctor.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Doctor");
                var created_user = await _userManager.FindByEmailAsync(doctor.Email);
                Doctor doc = (Doctor)doctor;
                doc.UserId = created_user.Id;
                await _context.Doctors.AddAsync(doc);
                await _context.SaveChangesAsync();
                return IdentityResult.Success;

            }
            var error = new IdentityError() {
                Description = "Error while creating IdentityRecord for the record!"};
            return IdentityResult.Failed(error);
        }
    }
}

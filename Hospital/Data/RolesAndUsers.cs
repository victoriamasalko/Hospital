using Microsoft.AspNetCore.Identity;
namespace Hospital.Data
{
    public static class RolesAndUsers
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            // ── 1. Create roles ──────────────────────────────────────────────────
            string[] roles = { "Doctor", "Nurse", "Psychologist", "KitchenStaff" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                    await roleManager.CreateAsync(new IdentityRole(role));
            }

            // ── 2. Helper to create a user and assign a role ─────────────────────
            async Task CreateUser(string email, string password, string role)
            {
                if (await userManager.FindByEmailAsync(email) == null)
                {
                    var user = new ApplicationUser
                    {
                        UserName = email,
                        Email = email,
                        EmailConfirmed = true
                    };

                    var result = await userManager.CreateAsync(user, password);

                    if (result.Succeeded)
                        await userManager.AddToRoleAsync(user, role);
                }
            }

            // ── 3. Seed doctors (2) ───────────────────────────────────────────────
            await CreateUser("doctor1@hospital.com", "Doctor_1!", "Doctor");
            await CreateUser("doctor2@hospital.com", "Doctor_2!", "Doctor");

            // ── 4. Seed nurses (6) ────────────────────────────────────────────────
            await CreateUser("nurse1@hospital.com", "Nurse_1!", "Nurse");
            await CreateUser("nurse2@hospital.com", "Nurse_2!", "Nurse");
            await CreateUser("nurse3@hospital.com", "Nurse_3!", "Nurse");
            await CreateUser("nurse4@hospital.com", "Nurse_4!", "Nurse");
            await CreateUser("nurse5@hospital.com", "Nurse_5!", "Nurse");
            await CreateUser("nurse6@hospital.com", "Nurse_6!", "Nurse");

            // ── 5. Seed psychologists (2) ─────────────────────────────────────────
            await CreateUser("psychologist1@hospital.com", "Psycho_1!", "Psychologist");
            await CreateUser("psychologist2@hospital.com", "Psycho_2!", "Psychologist");

            // ── 6. Seed kitchen staff (3) ─────────────────────────────────────────
            await CreateUser("kitchen1@hospital.com", "Kitchen_1!", "KitchenStaff");
            await CreateUser("kitchen2@hospital.com", "Kitchen_2!", "KitchenStaff");
            await CreateUser("kitchen3@hospital.com", "Kitchen_3!", "KitchenStaff");
        }
    }

}



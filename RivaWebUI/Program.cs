using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using Riva.DataAccessLayer.Concrete;
using Riva.EntityLayer.Entities;
using Riva.EntiyLayer.Entities;
using RivaEntityLayer.Entities;
using System;
using System.Threading.Tasks;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<RivaPideContext>();

// Kimlik doðrulama ve yetkilendirme yapýlandýrmasý
builder.Services.AddIdentity<AppUser, AppRole>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
})
.AddTokenProvider<DataProtectorTokenProvider<AppUser>>(TokenOptions.DefaultProvider).AddEntityFrameworkStores<RivaPideContext>()
.AddDefaultTokenProviders();

// Uygulama çerez yapýlandýrmasý
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Default/Index";
    options.ExpireTimeSpan = TimeSpan.FromDays(1);
    options.SlidingExpiration = true;
});

builder.Services.AddHttpClient();

// Yetkilendirme yapýlandýrmasý
builder.Services.AddControllersWithViews(options =>
{
    var policy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
    options.Filters.Add(new AuthorizeFilter(policy));
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Default/Index");
    app.UseHsts();
}
//404 Hatasýný Ana Sayfaya Yönlendiriyor
app.UseStatusCodePagesWithReExecute("/Default/Index");
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Default}/{action=Index}/{id?}");

// Uygulama kapsamýndaki servislerin oluþturulmasý
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<RivaPideContext>();
    var userManager = services.GetRequiredService<UserManager<AppUser>>();
    var roleManager = services.GetRequiredService<RoleManager<AppRole>>();
    var logger = services.GetRequiredService<ILogger<Program>>();

    try
    {
        await context.Database.MigrateAsync();
		await EnsureSlidersAsync(context); 
		await EnsureCategoryAsync(context);
		await EnsureDiscountyAsync(context);
		await EnsureTestimonialyAsync(context);

	}
    catch (Exception ex)
    {
        logger.LogError(ex, "Veritabaný migrasyonu veya diðer iþlemler sýrasýnda bir hata oluþtu.");
    }

    await EnsureRolesAsync(roleManager); 
    await EnsureUserAsync(userManager, logger); 
}

app.Run();

// Rollerin olup olmadýðýnýn kontrol edilmesi ve yoksa oluþturulmasý
async Task EnsureRolesAsync(RoleManager<AppRole> roleManager)
{
    if (!await roleManager.RoleExistsAsync("User"))
    {
        await roleManager.CreateAsync(new AppRole { Name = "User" });
    }

    if (!await roleManager.RoleExistsAsync("Admin"))
    {
        await roleManager.CreateAsync(new AppRole { Name = "Admin" });
    }
}

// Kullanýcýnýn olup olmadýðýnýn kontrol edilmesi ve yoksa oluþturulmasý
async Task EnsureUserAsync(UserManager<AppUser> userManager, ILogger<Program> logger)
{
    var user = await userManager.FindByNameAsync("Riva");

    if (user == null)
    {
        user = new AppUser
        {
            UserName = "Riva",
            Name = "Riva",
            Email = "RivaPideKebap@gmail.com",
            Surname = "Pide/Kep"
        };
        var password = "Riva123";

        user.SecurityStamp = Guid.NewGuid().ToString();
        var createUserResult = await userManager.CreateAsync(user, password);

        if (createUserResult.Succeeded)
        {
            user = await userManager.FindByNameAsync(user.UserName);

            var addToRoleResult = await userManager.AddToRoleAsync(user, "Admin");

            if (!addToRoleResult.Succeeded)
            {
                foreach (var error in addToRoleResult.Errors)
                {
                    logger.LogError($"Kullanýcýya rol eklenirken bir hata oluþtu: {error.Description}");
                }
            }
        }
        else
        {
            foreach (var error in createUserResult.Errors)
            {
                logger.LogError($"Kullanýcý oluþturulurken bir hata oluþtu: {error.Description}");
            }
        }
    }
}


async Task EnsureSlidersAsync(RivaPideContext context)
{
    
    if (!context.Sliders.Any())
    {
        var sliders = new List<Slider>
        {
            new Slider { Title1 = "Riva Pide & Kebap", Description1 = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. ",ImageUrl="/eatwell-master/images/bg_3.jpg" },
         
          
        };

        await context.Sliders.AddRangeAsync(sliders);
        await context.SaveChangesAsync();
    }
    else
    {

        Console.WriteLine("Slider verileri zaten mevcut.");
    }
}
 async Task EnsureCategoryAsync(RivaPideContext context)
{
    if (!context.Categories.Any())
    {
        var categories = new List<Category>
        {
            new Category { CategoryName = "Ýçecek", Status = true },
            new Category { CategoryName = "Tatlý", Status = true },
         
            new Category { CategoryName = "Pide", Status = true },
            new Category { CategoryName = "Kebap", Status = true },
            new Category { CategoryName = "Lahmacun", Status = true },
            new Category { CategoryName = "Diðer", Status = true }
        };

        context.Categories.AddRange(categories);
        await context.SaveChangesAsync();
    }
    else
    {
        Console.WriteLine("Kategori verileri zaten mevcut.");
    }
}
async Task EnsureDiscountyAsync(RivaPideContext context)
{
     if (!context.Discounts.Any())
    {
        var discounts = new List<Discount>
        {
            new Discount { Title = " Ürünlerde %10 Ýndirim ",Amount="%10 ",Description="Riva'da Bu Hafta Tüm Ürünlerde %10 Ýndirim ",ImageUrl="/images/c493ff02-a033-44a5-ae46-0f9266adb204.jpg" ,Status = true },
            new Discount { Title = " Tatlý+Lahmacun ",Amount="160 ",Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry. ",ImageUrl="/images/23e1a8d8-4745-4592-981d-68d2bf7a5ab8.jpg" ,Status = true },
            new Discount { Title = " Ýstediðiniz Pide+ Ýçecek ",Amount="120 ",Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum",ImageUrl="/images/8966f9a8-1bdc-4112-8277-a66d68b75164.jpg" ,Status = true },
            
        };

        context.Discounts.AddRange(discounts);
        await context.SaveChangesAsync();

    }
    else
    {
        Console.WriteLine("indirimler verileri zaten mevcut.");
    }
}
async Task EnsureTestimonialyAsync(RivaPideContext context)
{
    if (!context.Testimonials.Any())
    {
        var testimonials = new List<Testimonial>
        {
            new Testimonial { Name = "Semih Gül",Comment="Cok kaliteli ve temiz bir mekan. Calisanlar cok sicakkanli ve ilgili. Pidelerinden denedik ve cok begendik. Porsiyonlari buyuk ve lezzetli oldugu icin fiyatina degiyor, tavsiye ederim.", Status = false },
            new Testimonial { Name = "Lina",Comment="Evin yakýnýnda güzel bir yerin açýlýþý kutlu olsun! Hoþ bir atmosfer ve lezzetli yemekler. Size yeni yerinizde refah ve sadece iyileþme diliyorum. Herkes mutluydu. Kesinlikle tekrar geleceðiz!??", Status = false },
        

           
        };

        context.Testimonials.AddRange(testimonials);
        await context.SaveChangesAsync();
    }
    else
    {
        Console.WriteLine("Yorum verileri zaten mevcut.");
    }
}


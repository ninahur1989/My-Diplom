using DishBurger.Data.Static;
using DishBurger.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DishBurger.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                context.Database.EnsureCreated();

                //for docker
                //context.Database.Migrate();
                if (!context.Restaurants.Any())
                {
                    context.Restaurants.AddRange(new List<Restaurant>()
                    {
                        new Restaurant()
                        {
                            Name = "DishBurger Kyiv",
                            Logo = "https://popmenucloud.com/cdn-cgi/image/width=1920,height=1920,format=auto,fit=scale-down/beuvwscr/5881b925-f03b-4600-9536-06b9e0da23dd.jpg",
                            Description = "the best place in Kyiv",
                            Address = "Khreshatik 29a"
                        },
                        new Restaurant()
                        {
                            Name = "DishBurger Lviv",
                            Logo = "https://cdn.winsightmedia.com/platform/files/public/2020-08/background/tim-hortons_1596742394.jpg?VersionId=Oc2Rj5HgTTEM.mZOqj3kuXeEoa8knGyN",
                            Description = "the best place in Lviv",
                            Address = "Stepan Bandera Street 33"
                        },
                        new Restaurant()
                        {
                            Name = "DishBurger Kharkiv",
                            Logo = "https://media-cdn.tripadvisor.com/media/photo-s/04/34/f8/f0/gondolier-pizza-italian.jpg",
                            Description = "the best place in Kharkiv",
                            Address = "SSumskaya street 4в"
                        },
                        new Restaurant()
                        {
                            Name = "DishBurger Odessa",
                            Logo = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRvm0leuJY6JmFUsIxhkwcjW-zxTYXmeVlOVw&usqp=CAU",
                            Description = "the best place in Odessa",
                            Address = "Street Polskaya 12а"
                        },
                    });
                    context.SaveChanges();
                }

                if (!context.Ingredients.Any())
                {
                    context.Ingredients.AddRange(new List<Ingredient>()
                    {
                        new Ingredient()
                        {
                            FullName = "dough",
                            ProfilePictureURL = "https://i.obozrevatel.com/food/recipemain/2019/1/29/po2.jpg?size=636x424"
                        },
                        new Ingredient()
                        {
                            FullName = "papper",
                            ProfilePictureURL = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSbgP_LPZW_0885Qz3lpPYb_0LJtWwLrT90Sw&usqp=CAU"
                        },
                        new Ingredient()
                        {
                            FullName = "cheese",
                            ProfilePictureURL = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSRde4F9GzARgqzIafjYMfuPsKUuTfwtJasjQPSycQf8g&s"
                        },
                        new Ingredient()
                        {
                            FullName = "tomato",
                            ProfilePictureURL = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQvDOoVoP80A4e4_FFJDCFU6RKe3DK52w1L0A&usqp=CAU"
                        },
                        new Ingredient()
                        {
                            FullName = "mushrooms",
                            ProfilePictureURL = "https://cdn.shopify.com/s/files/1/0498/5903/5292/products/mushroomShiitake_460x.png?v=1656978127"
                        },
                        new Ingredient()
                        {
                            FullName = "olives",
                            ProfilePictureURL = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRyvJYe1WOxjG-jv8rDDsR4zaXoP1p1J8JaVQ&usqp=CAU"
                        },
                        new Ingredient()
                        {
                            FullName = "salami",
                            ProfilePictureURL = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQi6qi-g9PPPWNbBYmWGo5M46uTF7GugI5hig&usqp=CAU"
                        },new Ingredient()
                        {
                            FullName = "meat",
                            ProfilePictureURL = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTPpO-stFFMw63pFAbNvNbLAh61BzspVO85zg&usqp=CAU"
                        },
                        new Ingredient()
                        {
                            FullName = "mayonnaise",
                            ProfilePictureURL = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQF0KeRPWC7WP63_rSWKkODbdbvAB_xxCRZaQ&usqp=CAU"
                        },
                        new Ingredient()
                        {
                            FullName = "bun",
                            ProfilePictureURL = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSJUhhBDzc-peSN8ZYo1_0Ef-WB0mPMS5xzEQ&usqp=CAU"
                        },
                        new Ingredient()
                        {
                            FullName = "bacon",
                            ProfilePictureURL = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSlxtUlw0lnf2t7aMWchEFnfD5ruKS2n4p9cw&usqp=CAU"
                        },
                        new Ingredient()
                        {
                            FullName = "union",
                            ProfilePictureURL = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTOFcKT9ZR3ijWZpvQodAzeKCJODwOiU-tSrA&usqp=CAU"
                        },
                        new Ingredient()
                        {
                            FullName = "cucumber",
                            ProfilePictureURL = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT2_lBQVPrJ8liDajijAkyEflPLSX7dBXgH1Q&usqp=CAU"
                        },
                        new Ingredient()
                        {
                            FullName = "ketchup",
                            ProfilePictureURL = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS8k77kIqfnc0_rWq9K0Cts6zoFFtqcgXd6Uw&usqp=CAU"
                        },
                        new Ingredient()
                        {
                            FullName = "lettuce",
                            ProfilePictureURL = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRi1ZE3OlfpZ9KkdXVKY-LybQZ7jat71Mteig&usqp=CAU"
                        },new Ingredient()
                        {
                            FullName = "mozzarella",
                            ProfilePictureURL = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcReiCUYjXRaJWSz4_JafHkalZwHwkknGlK7Vw&usqp=CAU"
                        }
                    });
                    context.SaveChanges();
                }
                //manufacture
                if (!context.Manufacturers.Any())
                {
                    context.Manufacturers.AddRange(new List<Manufacturer>()
                    {
                        new Manufacturer()
                        {
                           Name = "Nutle"
                        },
                    });
                    context.SaveChanges();
                }

                if (!context.ItemEntitys.Any())
                {
                    context.ItemEntitys.AddRange(new List<ItemEntity>()
                    {
                        new ItemEntity()
                        {
                            Name = "Cheese Pizza",
                            Price = 233,
                            ImageURL =  "https://dodopizza.azureedge.net/static/Img/Products/Pizza/ru-RU/2ffc31bb-132c-4c99-b894-53f7107a1441.jpg",
                            product = Enums.Product.Dish,
                            ShortDescription = "the best price ",
                            Dish = new Dish()
                            {
                                Description = "Pizza for your health",
                                RestaurantId = 3,
                                DishCuisine = Cuisine.Chinese
                            }
                        },
                        new ItemEntity()
                        {
                            Name = "Pepperoni Fresh",
                            Price = 133,
                            ImageURL = "https://dodopizza.azureedge.net/static/Img/Products/f035c7f46c0844069722f2bb3ee9f113_584x584.jpeg",
                            product = Enums.Product.Dish,
                            ShortDescription = "the best price ",
                            Dish = new Dish()
                            {
                                Description = "Pizza for your health",
                                RestaurantId = 4,
                                DishCuisine = Cuisine.Spanish
                            }
                        },
                        new ItemEntity()
                        {
                            Name = "Barbecue Chicken",
                            Price = 129.52,
                            ImageURL = "https://dodopizza.azureedge.net/static/Img/Products/Pizza/ru-RU/6652fec1-04df-49d8-8744-232f1032c44b.jpg",
                            product = Enums.Product.Dish,
                            ShortDescription = "the best price ",
                            Dish = new Dish()
                            {
                                Description = "Pizza for your health",
                                RestaurantId = 1,
                                DishCuisine = Cuisine.Greek
                            }
                        },
                        new ItemEntity()
                        {
                            Name = "Sweet and sour Chicken",
                            Price = 169.50,
                            ImageURL = "https://dodopizza.azureedge.net/static/Img/Products/Pizza/ru-RU/af553bf5-3887-4501-b88e-8f0f55229429.jpg",
                            product = Enums.Product.Dish,
                            ShortDescription = "the best price ",
                            Dish = new Dish()
                            {
                                Description = "Pizza for your health",
                                RestaurantId = 3,
                                DishCuisine = Cuisine.Greek
                            }
                        },
                        new ItemEntity()
                        {
                            Name = "Burger Shaggyi",
                            Price = 69.50,
                            ImageURL = "https://contrabanda.kiev.ua/media/catalog/product/cache/1/thumbnail/600x/17f82f742ffe127f42dca9de82fb58b1/c/h/chik.jpg",
                            product = Enums.Product.Dish,
                            ShortDescription = "the best price ",
                            Dish = new Dish()
                            {
                                Description = "Burger for your health",
                                RestaurantId = 2,
                                DishCuisine = Cuisine.Italian
                            }
                        },
                        new ItemEntity()
                        {
                            Name = "Jazz Night",
                            Price = 247.50,
                            ImageURL = "https://contrabanda.kiev.ua/media/catalog/product/cache/1/small_image/600x/17f82f742ffe127f42dca9de82fb58b1/j/a/jazznight.jpg",
                            product = Enums.Product.Dish,
                            ShortDescription = "the best price ",
                            Dish = new Dish()
                            {
                                Description = "Burger for your health",
                                RestaurantId = 4,
                                DishCuisine = Cuisine.Spanish
                            }
                        },
                         new ItemEntity()
                        {
                            Name = "Burger Enzo Ferrari",
                            Price = 555.90,
                            ImageURL = "https://contrabanda.kiev.ua/media/catalog/product/cache/1/thumbnail/600x/17f82f742ffe127f42dca9de82fb58b1/e/n/enzo_2_1.jpg",
                            product = Enums.Product.Dish,
                            ShortDescription = "the best price ",
                            Dish = new Dish()
                            {
                                Description = "Burger for your health",
                                RestaurantId = 3,
                                DishCuisine = Cuisine.Greek
                            }
                        },
                         new ItemEntity()
                        {
                            Name = "Vegetables and Mushrooms",
                            Price = 88.88,
                            ImageURL = "https://dodopizza.azureedge.net/static/Img/Products/Pizza/ru-RU/30367198-f3bd-44ed-9314-6f717960da07.jpg",
                            product = Enums.Product.Dish,
                            ShortDescription = "the best price ",
                            Dish = new Dish()
                            {
                                Description = "Pizza for your health",
                                RestaurantId = 1,
                                DishCuisine = Cuisine.Spanish
                            }
                        },
                        new ItemEntity()
                        {
                            Name = "pizza2",
                            Price = 3133,
                            ImageURL = "https://dodopizza.azureedge.net/static/Img/Products/Pizza/ru-RU/2ffc31bb-132c-4c99-b894-53f7107a1441.jpg",
                            product = Enums.Product.Dish,
                            ShortDescription = "the best price ",
                            Dish = new Dish()
                            {
                                Description = "Pizza for your health",
                                RestaurantId = 1,
                                DishCuisine= Cuisine.Spanish
                            }
                        },
                        new ItemEntity()
                        {
                            Name = "revo",
                            Price = 20,
                            ImageURL = "https://hola.com.ua/image/cache/catalog/i/aj/ea/d35421ea54476f26675256a097ba8a18-800x800.png",
                            product = Enums.Product.Drink,
                            ShortDescription = "the best price ",
                            Drink = new Drink()
                            {
                                DrinkType = DrinkType.Alcohol,
                                ManufacturerId = 1,
                                Volume = 1
                            }
                        },
                        new ItemEntity()
                        {
                            Name = "coca-cola",
                            Price = 10,
                            ImageURL = "https://img.fozzyshop.com.ua/229215-thickbox_default/napitok-coca-cola-05l.jpg",
                            product = Enums.Product.Drink,
                            ShortDescription = "the best price ",
                            Drink = new Drink()
                            {
                                DrinkType = DrinkType.WithGas,
                                ManufacturerId = 1,
                                Volume = 0.5
                            }
                        },
                        new ItemEntity()
                        {
                            Name = "bear",
                            Price = 29,
                            ImageURL = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSfZqP05-m7sz8dx3vLMgQY-mRBuubL98oO9g&usqp=CAU",
                            product = Enums.Product.Drink,
                            ShortDescription = "the best price ",
                            Drink = new Drink()
                            {
                                DrinkType = DrinkType.Alcohol,
                                ManufacturerId = 1,
                                Volume = 1
                            }
                        },
                        new ItemEntity()
                        {
                            Name = "water",
                            Price = 15,
                            ImageURL = "https://aquamarket.ua/78127-product_category/morshinska-plyus-antioksi-selen-khrom-cink-15-l-voda-mineralna-negazovana-pet.jpg",
                            product = Enums.Product.Drink,
                            ShortDescription = "the best price ",
                            Drink = new Drink()
                            {
                                DrinkType = DrinkType.WithGas,
                                ManufacturerId = 1,
                                Volume = 1.5
                            }
                        },
                        new ItemEntity()
                        {
                            Name = "juice",
                            Price = 39,
                            ImageURL = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT1EEEfq_jolW9oNe-QDnZmMIOqv3E0gt88Rg&usqp=CAU",
                            product = Enums.Product.Drink,
                            ShortDescription = "the best price ",
                            Drink = new Drink()
                            {
                                DrinkType = DrinkType.WithoutGas,
                                ManufacturerId = 1,
                                Volume = 2
                            }
                        },
                        new ItemEntity()
                        {
                            Name = "Cudo",
                            Price = 8,
                            ImageURL = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ4vwWs71FsnLWrUBkpad6aVFF5LOAWcT_3sQ&usqp=CAU",
                            product = Enums.Product.Drink,
                            ShortDescription = "the best price ",
                            Drink = new Drink()
                            {
                                DrinkType = DrinkType.WithoutGas,
                                ManufacturerId = 1,
                                Volume = 0.2
                            }
                        }
                    });
                    context.SaveChanges();
                }

                if (!context.Ingredient_Dish.Any())
                {
                    context.Ingredient_Dish.AddRange(new List<Ingredient_Dish>()
                    {
                        //1
                        new Ingredient_Dish()
                        {
                            IngredientId = 1,
                            DishId = 1
                        },
                        new Ingredient_Dish()
                        {
                            IngredientId = 2,
                            DishId = 1
                        },
                        new Ingredient_Dish()
                        {
                            IngredientId = 13,
                            DishId = 1
                        },
                        new Ingredient_Dish()
                        {
                            IngredientId = 14,
                            DishId = 1
                        },
                         new Ingredient_Dish()
                        {
                            IngredientId = 10,
                            DishId = 1
                        },
                          new Ingredient_Dish()
                        {
                            IngredientId = 9,
                            DishId = 1
                        },
                        //2
                         new Ingredient_Dish()
                        {
                          IngredientId = 1,
                            DishId = 2
                        },
                         new Ingredient_Dish()
                        {
                           IngredientId = 4,
                            DishId = 2
                        },
                         //3
                        new Ingredient_Dish()
                        {
                            IngredientId = 5,
                            DishId = 3
                        },
                        new Ingredient_Dish()
                        {
                            IngredientId = 2,
                            DishId = 3
                        },
                        new Ingredient_Dish()
                        {
                            IngredientId = 1,
                            DishId = 3
                        },
                        //4
                        new Ingredient_Dish()
                        {
                            IngredientId = 1,
                            DishId = 4
                        },
                        new Ingredient_Dish()
                        {
                            IngredientId = 7,
                            DishId = 4
                        },
                        new Ingredient_Dish()
                        {
                            IngredientId = 4,
                            DishId = 4
                        },
                        //5
                        new Ingredient_Dish()
                        {
                            IngredientId = 2,
                            DishId = 5
                        },
                        new Ingredient_Dish()
                        {
                            IngredientId = 3,
                            DishId = 5
                        },
                        new Ingredient_Dish()
                        {
                            IngredientId = 4,
                            DishId = 5
                        },
                        new Ingredient_Dish()
                        {
                            IngredientId = 5,
                            DishId = 5
                        },
                        //6
                        new Ingredient_Dish()
                        {
                            IngredientId = 3,
                            DishId = 6
                        },
                        new Ingredient_Dish()
                        {
                            IngredientId = 4,
                            DishId = 6
                        },
                        new Ingredient_Dish()
                        {
                            IngredientId = 5,
                            DishId = 6
                        },
                    });
                    context.SaveChanges();
                }
            }
        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "admin@gmail.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "$%32gdsDSs2");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }

                string appUserEmail = "user@gmail.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "Application User",
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "$%32gdsDSs2");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}

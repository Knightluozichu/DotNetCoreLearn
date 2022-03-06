using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace SportsStore.Models
{
    public static class SeeData {
        public static void EnsurePopulated(IApplicationBuilder app){
            StoreDbContext context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<StoreDbContext>();

            if(context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if(!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product{
                        Name = "kayak",
                        Description = "船鞋",
                        Category = "水上运动",
                        Price = 275
                    },
                    new Product{
                        Name = "Lifejacket",
                        Description = "尊贵时尚运动鞋",
                        Category = "水上运动",
                        Price = 48.95m
                    },
                    new Product{
                        Name = "Soccer Ball",
                        Description = "足球运动鞋",
                        Category = "足球运动员",
                        Price = 19.50m
                    },
                    new Product{
                        Name = "Corner Flags",
                        Description = "专业休闲娱乐鞋",
                        Category = "足球运动员",
                        Price = 34.95m
                    },
                    new Product{
                        Name = "Stadium",
                        Description = "移动座位垫",
                        Category = "足球运动员",
                        Price = 79500
                    },
                    new Product{
                        Name = "Thinking Cap",
                        Description = "醒神提脑",
                        Category = "国际象棋",
                        Price = 16
                    },
                    new Product{
                        Name = "Unsteady Chair",
                        Description = "摇摇晃晃的椅子",
                        Category = "国际象棋",
                        Price = 29.95m
                    },
                    
                    new Product{
                        Name = "Human Chess Board",
                        Description = "棋盘",
                        Category = "国际象棋",
                        Price = 75
                    },
                    new Product{
                        Name = "Bling-Bling King",
                        Description = "皇帝棋子",
                        Category = "国际象棋",
                        Price = 1200
                    }
                );
                context.SaveChanges();   
            }
        }
    }
}
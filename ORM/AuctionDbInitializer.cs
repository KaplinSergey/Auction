using ORM.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Web.Helpers;


namespace ORM
{
    public class AuctionDbInitializer:DropCreateDatabaseIfModelChanges<AuctionDbContext>
    {
        protected override void Seed(AuctionDbContext context)
        {
            string contentType = "image/jpg";

            #region Books image

            string book_Amphibian_Man = Path.Combine(@"E:\Training\AuctionHelp\books\", "Belyaev_Amphibian Man.jpg");
            byte[] imageData_book_Amphibian_Man = File.ReadAllBytes(book_Amphibian_Man);

            string book_Bridge_To_reason = Path.Combine(@"E:\Training\AuctionHelp\books\", "Joe Haldeman_ Bridge to reason.jpg");
            byte[] imageData_book_Bridge_To_reason = File.ReadAllBytes(book_Bridge_To_reason);

            string book_Johns_wort_or_the_first_warpath = Path.Combine(@"E:\Training\AuctionHelp\books\", "Kuper_St. John's wort or the first warpath.jpg");
            byte[] imageData_book_Johns_wort_or_the_first_warpath = File.ReadAllBytes(book_Johns_wort_or_the_first_warpath);

            string book_Phoenix_operation = Path.Combine(@"E:\Training\AuctionHelp\books\", "Mikhail Prudnikov_Phoenix  operation.jpg");
            byte[] imageData_book_Phoenix_operation = File.ReadAllBytes(book_Phoenix_operation);

            string book_Treasure_Island = Path.Combine(@"E:\Training\AuctionHelp\books\", "Stephenson_Treasure Island.jpg");
            byte[] imageData_book_Treasure_Island = File.ReadAllBytes(book_Treasure_Island);

            string book_French_detective_novel = Path.Combine(@"E:\Training\AuctionHelp\books\", "The modern French detective novel.jpg");
            byte[] imageData_book_French_detective_novel = File.ReadAllBytes(book_French_detective_novel);

            string book_Myths_and_Legends = Path.Combine(@"E:\Training\AuctionHelp\books\", "Myths and Legends of Ancient Greece.jpg");
            byte[] imageData_book_Myths_and_Legends = File.ReadAllBytes(book_Myths_and_Legends);

            string book_Tales_about_Giants = Path.Combine(@"E:\Training\AuctionHelp\books\", "Tales about Giants.jpg");
            byte[] imageData_book_Tales_about_Giants = File.ReadAllBytes(book_Tales_about_Giants);

            string book_CPSU_Central_Committee = Path.Combine(@"E:\Training\AuctionHelp\books\", "CPSU Central Committee agitators 1985.jpg");
            byte[] imageData_book_CPSU_Central_Committee = File.ReadAllBytes(book_CPSU_Central_Committee);

            #endregion

            #region Clothes image

            string cloth_Girl_skirt = Path.Combine(@"E:\Training\AuctionHelp\clothes\", "Girl skirt.jpg");
            byte[] imageData_cloth_Girl_skirt = File.ReadAllBytes(cloth_Girl_skirt);

            string cloth_New_cap_beanies = Path.Combine(@"E:\Training\AuctionHelp\clothes\", "New cap beanies.jpg");
            byte[] imageData_cloth_New_cap_beanies = File.ReadAllBytes(cloth_New_cap_beanies);

            string cloth_New_fur_headphones = Path.Combine(@"E:\Training\AuctionHelp\clothes\", "New fur headphones.jpg");
            byte[] imageData_cloth_New_fur_headphones = File.ReadAllBytes(cloth_New_fur_headphones);

            string cloth_Mens_sweater = Path.Combine(@"E:\Training\AuctionHelp\clothes\", "Stylish brand men's sweater Slazenger.jpg");
            byte[] imageData_cloth_Mens_sweater = File.ReadAllBytes(cloth_Mens_sweater);

            string cloth_The_new_jacket = Path.Combine(@"E:\Training\AuctionHelp\clothes\", "The new jacket.jpg");
            byte[] imageData_cloth_The_new_jacket = File.ReadAllBytes(cloth_The_new_jacket);

            string cloth_Winter_jeans_Drizzte = Path.Combine(@"E:\Training\AuctionHelp\clothes\", "Winter jeans Drizzte.jpg");
            byte[] imageData_cloth_Winter_jeans_Drizzte = File.ReadAllBytes(cloth_Winter_jeans_Drizzte);

            string cloth_Winter_pants_Landsend = Path.Combine(@"E:\Training\AuctionHelp\clothes\", "Winter pants Landsend.jpg");
            byte[] imageData_cloth_Winter_pants_Landsend = File.ReadAllBytes(cloth_Winter_pants_Landsend);

            string cloth_Caps_for_Kids = Path.Combine(@"E:\Training\AuctionHelp\clothes\", "Caps for Kids.jpg");
            byte[] imageData_cloth_Caps_for_Kids = File.ReadAllBytes(cloth_Caps_for_Kids);

            string cloth_Demiseason_overalls_Lassie = Path.Combine(@"E:\Training\AuctionHelp\clothes\", "Demiseason overalls Lassie by Reima.jpg");
            byte[] imageData_cloth_Demiseason_overalls_Lassie = File.ReadAllBytes(cloth_Demiseason_overalls_Lassie);

            #endregion

            #region Coins image

            string coin_10_eurocents = Path.Combine(@"E:\Training\AuctionHelp\coins\", "10 eurocents, Germany 2002.jpg");
            byte[] imageData_coin_10_eurocents = File.ReadAllBytes(coin_10_eurocents);

            string coin_Bulgaria_5_leva = Path.Combine(@"E:\Training\AuctionHelp\coins\", "Bulgaria 5 leva 1992.jpg");
            byte[] imageData_coin_Bulgaria_5_leva = File.ReadAllBytes(coin_Bulgaria_5_leva);

            string coin_Faroe_Islands = Path.Combine(@"E:\Training\AuctionHelp\coins\", "Faroe Islands 10 Ore 1941.jpg");
            byte[] imageData_coin_Faroe_Islands = File.ReadAllBytes(coin_Faroe_Islands);

            string coin_Malta_5_cents = Path.Combine(@"E:\Training\AuctionHelp\coins\", "Malta 5 cents 1976.jpg");
            byte[] imageData_coin_Malta_5_cents = File.ReadAllBytes(coin_Malta_5_cents);

            string coin_Slovakia_2_euro = Path.Combine(@"E:\Training\AuctionHelp\coins\", "Slovakia 2 euro 2009.jpg");
            byte[] imageData_coin_Slovakia_2_euro = File.ReadAllBytes(coin_Slovakia_2_euro);

            string coin_Slovenia_1_tolar = Path.Combine(@"E:\Training\AuctionHelp\coins\", "Slovenia 1 tolar 2000.jpg");
            byte[] imageData_coin_Slovenia_1_tolar = File.ReadAllBytes(coin_Slovenia_1_tolar);

            string coin_BYZANTIUM_Romanos_III = Path.Combine(@"E:\Training\AuctionHelp\coins\", "BYZANTIUM Romanos III Argyros ANONYMOUS Follis.jpg");
            byte[] imageData_coin_BYZANTIUM_Romanos_III = File.ReadAllBytes(coin_BYZANTIUM_Romanos_III);

            string coin_Rzeczpospolita_18_pennie = Path.Combine(@"E:\Training\AuctionHelp\coins\", "Rzeczpospolita 18 pennies (ORT) in 1754 August III.jpg");
            byte[] imageData_coin_Rzeczpospolita_18_pennie = File.ReadAllBytes(coin_Rzeczpospolita_18_pennie);

            string coin_15_cents_1908_SPB = Path.Combine(@"E:\Training\AuctionHelp\coins\", "15 cents 1908 SPB.jpg");
            byte[] imageData_coin_15_cents_1908_SPB = File.ReadAllBytes(coin_15_cents_1908_SPB);

            #endregion

            #region collecting image

            string collecting_Excellent_DPO = Path.Combine(@"E:\Training\AuctionHelp\collecting\", "Excellent DPO BSSR.jpg");
            byte[] imageData_collecting_Excellent_DPO = File.ReadAllBytes(collecting_Excellent_DPO);

            string collecting_Gold_Medal_school_BSSR = Path.Combine(@"E:\Training\AuctionHelp\collecting\", "Gold Medal school BSSR.jpg");
            byte[] imageData_collecting_Gold_Medal_school_BSSR = File.ReadAllBytes(collecting_Gold_Medal_school_BSSR);

            string collecting_Krasnoyarsk_Civil_School = Path.Combine(@"E:\Training\AuctionHelp\collecting\", "Krasnoyarsk Civil Aviation School.jpg");
            byte[] imageData_collecting_Krasnoyarsk_Civil_School = File.ReadAllBytes(collecting_Krasnoyarsk_Civil_School);

            string collecting_Ministry_of_Internal_Affairs = Path.Combine(@"E:\Training\AuctionHelp\collecting\", "Ministry of Internal Affairs BHSS-BEP 80 years.jpg");
            byte[] imageData_collecting_Ministry_of_Internal_Affairs = File.ReadAllBytes(collecting_Ministry_of_Internal_Affairs);

            string collecting_Ready_for_Labour_and_Defence = Path.Combine(@"E:\Training\AuctionHelp\collecting\", "Ready for Labour and Defence of the USSR.jpg");
            byte[] imageData_collecting_Ready_for_Labour_and_Defence = File.ReadAllBytes(collecting_Ready_for_Labour_and_Defence);

            string collecting_Sign_of_Excellence = Path.Combine(@"E:\Training\AuctionHelp\collecting\", "Sign of Excellence in Emergency Ministry.jpg");
            byte[] imageData_collecting_Sign_of_Excellence = File.ReadAllBytes(collecting_Sign_of_Excellence);

            string collecting_Eleventh_definitive_issue = Path.Combine(@"E:\Training\AuctionHelp\collecting\", "Eleventh definitive issue of Belarus in 2008.jpg");
            byte[] imageData_collecting_Eleventh_definitive_issue = File.ReadAllBytes(collecting_Eleventh_definitive_issue);

            string collecting_Stamps_Costumes = Path.Combine(@"E:\Training\AuctionHelp\collecting\", "160-163 block and Stamps Costumes.jpg");
            byte[] imageData_collecting_Stamps_Costumes = File.ReadAllBytes(collecting_Stamps_Costumes);

            string collecting_Belarus_Mushrooms = Path.Combine(@"E:\Training\AuctionHelp\collecting\", "Belarus 291-295. Mushrooms. A series of 5 stamps.jpg");
            byte[] imageData_collecting_Belarus_Mushrooms = File.ReadAllBytes(collecting_Belarus_Mushrooms);

            #endregion

            #region computers image

            string computer_AMD_Phenom_II = Path.Combine(@"E:\Training\AuctionHelp\computers\", "AMD Phenom II X4 925.jpg");
            byte[] imageData_computer_AMD_Phenom_II = File.ReadAllBytes(computer_AMD_Phenom_II);

            string computer_Game_console_Microsoft_Xbox = Path.Combine(@"E:\Training\AuctionHelp\computers\", "Game console Microsoft Xbox 360 Slim 250GB.jpg");
            byte[] imageData_computer_Game_console_Microsoft_Xbox = File.ReadAllBytes(computer_Game_console_Microsoft_Xbox);

            string computer_Helmet_mobile_virtual = Path.Combine(@"E:\Training\AuctionHelp\computers\", "Helmet mobile virtual reality VR 3D BOX.jpg");
            byte[] imageData_computer_Helmet_mobile_virtual = File.ReadAllBytes(computer_Helmet_mobile_virtual);

            string computer_HP_4535s = Path.Combine(@"E:\Training\AuctionHelp\computers\", "HP 4535s.jpg");
            byte[] imageData_computer_HP_4535s = File.ReadAllBytes(computer_HP_4535s);

            string computer_HP_ProBook_450 = Path.Combine(@"E:\Training\AuctionHelp\computers\", "HP ProBook 450 G3.jpg");
            byte[] imageData_computer_HP_ProBook_450 = File.ReadAllBytes(computer_HP_ProBook_450);

            string computer_Monitor_Samsung_SyncMaster = Path.Combine(@"E:\Training\AuctionHelp\computers\", "Monitor Samsung SyncMaster 2233.jpg");
            byte[] imageData_computer_Monitor_Samsung_SyncMaster = File.ReadAllBytes(computer_Monitor_Samsung_SyncMaster);

            string computer_Lenovo_B50_30 = Path.Combine(@"E:\Training\AuctionHelp\computers\", "notebook Lenovo B50-30.jpg");
            byte[] imageData_computer_Lenovo_B50_30 = File.ReadAllBytes(computer_Lenovo_B50_30);

            string computer_MSI_Apache_GE60 = Path.Combine(@"E:\Training\AuctionHelp\computers\", "notebook MSI Apache GE60.jpg");
            byte[] imageData_computer_MSI_Apache_GE60 = File.ReadAllBytes(computer_MSI_Apache_GE60);

            string computer_LENOVO_Z50 = Path.Combine(@"E:\Training\AuctionHelp\computers\", "notebook LENOVO Z50-70.jpg");
            byte[] imageData_computer_LENOVO_Z50 = File.ReadAllBytes(computer_LENOVO_Z50);

            #endregion

            #region mobiles image

            string mobile_Apple_iPhone_4S = Path.Combine(@"E:\Training\AuctionHelp\mobiles\", "Apple iPhone 4S Smartphone (16Gb) White.jpg");
            byte[] imageData_mobile_Apple_iPhone_4S = File.ReadAllBytes(mobile_Apple_iPhone_4S);

            string mobile_Lenovo_A5000 = Path.Combine(@"E:\Training\AuctionHelp\mobiles\", "Lenovo A5000.jpg");
            byte[] imageData_mobile_Lenovo_A5000 = File.ReadAllBytes(mobile_Lenovo_A5000);

            string mobile_Phone_NOKIA_N93 = Path.Combine(@"E:\Training\AuctionHelp\mobiles\", "Phone NOKIA N93 (working).jpg");
            byte[] imageData_mobile_Phone_NOKIA_N93 = File.ReadAllBytes(mobile_Phone_NOKIA_N93);

            string mobile_Phone_NOKIA = Path.Combine(@"E:\Training\AuctionHelp\mobiles\", "Phone NOKIA Talkman (working).jpg");
            byte[] imageData_mobile_Phone_NOKIA = File.ReadAllBytes(mobile_Phone_NOKIA);

            string mobile_Phone_SAMSUNG = Path.Combine(@"E:\Training\AuctionHelp\mobiles\", "Phone SAMSUNG N900 new.jpg");
            byte[] imageData_mobile_Phone_SAMSUNG = File.ReadAllBytes(mobile_Phone_SAMSUNG);

            string mobile_Smartphone_ZTE = Path.Combine(@"E:\Training\AuctionHelp\mobiles\", "Smartphone ZTE Blade A465 Black.jpg");
            byte[] imageData_mobile_Smartphone_ZTE = File.ReadAllBytes(mobile_Smartphone_ZTE);

            string mobile_APPLE_iPhone_7 = Path.Combine(@"E:\Training\AuctionHelp\mobiles\", "NEW! APPLE iPhone 7.jpg");
            byte[] imageData_mobile_APPLE_iPhone_7 = File.ReadAllBytes(mobile_APPLE_iPhone_7);

            string mobile_Apple_iPhone_6 = Path.Combine(@"E:\Training\AuctionHelp\mobiles\", "Apple iPhone 6 64GB Gold.jpg");
            byte[] imageData_mobile_Apple_iPhone_6 = File.ReadAllBytes(mobile_Apple_iPhone_6);

            string mobile_ZTE_Blade_Q = Path.Combine(@"E:\Training\AuctionHelp\mobiles\", "ZTE Blade Q Lux 3G.jpg");
            byte[] imageData_mobile_ZTE_Blade_Q = File.ReadAllBytes(mobile_ZTE_Blade_Q);

            #endregion


            #region category image

            string category_books = Path.Combine(@"E:\Training\AuctionHelp\categories\", "books.jpg");
            byte[] imageData_category_books = File.ReadAllBytes(category_books);

            string category_clothing = Path.Combine(@"E:\Training\AuctionHelp\categories\", "clothing.jpg");
            byte[] imageData_category_clothing = File.ReadAllBytes(category_clothing);

            string category_mobile_phones = Path.Combine(@"E:\Training\AuctionHelp\categories\", "mobile phones.jpg");
            byte[] imageData_category_mobile_phones = File.ReadAllBytes(category_mobile_phones);

            string category_coins = Path.Combine(@"E:\Training\AuctionHelp\categories\", "coins.jpg");
            byte[] imageData_category_coins = File.ReadAllBytes(category_coins);

            string category_computers = Path.Combine(@"E:\Training\AuctionHelp\categories\", "computers.jpg");
            byte[] imageData_category_computers = File.ReadAllBytes(category_computers);

            string category_collecting = Path.Combine(@"E:\Training\AuctionHelp\categories\", "collecting.jpg");
            byte[] imageData_category_collecting = File.ReadAllBytes(category_collecting);

            #endregion


            Role adminRole = new Role { Id = 1, Name = "Admin" };
            Role userRole = new Role { Id = 2, Name = "User" };
            context.Roles.Add(adminRole);
            context.Roles.Add(userRole);


            User admin = new User
            {
                Id = 1,
                Name = "Admin",
                Email = "Admin@tut.by",
                Password = Crypto.HashPassword("12345678"),
                CreationDate = DateTime.Now,
                Role = adminRole
            };            
            User userSergey = new User { Id = 2, Name = "Sergey", Email = "s.k.85@tut.by", Password = Crypto.HashPassword("12345678"), CreationDate = DateTime.Now, Role = userRole,
                Purchases = new List<Purchase>
                {
                    new Purchase { Id = 1, LotId=1, Date=new DateTime(2016,12,31)},
                    new Purchase { Id = 2, LotId = 10, Date=new DateTime(2017,1,7)},
                    new Purchase { Id = 3, LotId = 38, Date=new DateTime(2017,1,21)},
                }
            };
            User userIvan = new User
            {
                Id = 3,
                Name = "Ivan",
                Email = "Ivan@tut.by",
                Password = Crypto.HashPassword("12345678"),
                CreationDate = DateTime.Now,
                Role = userRole,
                Purchases = new List<Purchase>
                {
                    new Purchase { Id = 5, LotId = 23, Date=new DateTime(2017,1,8)},
                    new Purchase { Id = 6, LotId = 31, Date=new DateTime(2017,1,16)},
                }
            };
            User userAlex = new User
            {
                Id = 4,
                Name = "Alex",
                Email = "Alex@tut.by",
                Password = Crypto.HashPassword("12345678"),
                CreationDate = DateTime.Now,
                Role = userRole,
                Purchases = new List<Purchase>
                {
                    new Purchase { Id = 6, LotId = 33, Date=new DateTime(2017,1,21)},
                    new Purchase { Id = 7, LotId = 51, Date=new DateTime(2017,1,20)},
                }        
            };

            context.Users.Add(admin);
            context.Users.Add(userSergey);
            context.Users.Add(userIvan);
            context.Users.Add(userAlex);

            Category coins = new Category
            {
                Id = 1,
                Name = "Coins",
                ImageData=imageData_category_coins,
                ImageType=contentType,
                Lots = new List<Lot>
                {
                    new Lot
                    {
                        Id=1, Name="10 eurocents", StartPrice=50M, LastPrice=60M, Description="10 eurocents", StartDate=new DateTime(2016,12,1), Duration=30, State=LotState.Sold, User=userIvan, ImageData=imageData_coin_10_eurocents, ImageType=contentType, Bids=new List<Bid>
                        {
                        new Bid { Id = 1, Price = 60M, Date = new DateTime(2017, 1, 5), User=userSergey}
                        }
                    },
                    new Lot
                    {
                        Id=2, Name="5 leva", StartPrice=40M, Description="Bulgaria 5 leva 1992", StartDate=new DateTime(2016,11,1), Duration=25, State=LotState.Unsold, User=userAlex, ImageData=imageData_coin_Bulgaria_5_leva, ImageType=contentType
                    },
                    new Lot
                    {
                        Id=3, Name="10 Ore", StartPrice=6M, Description="Faroe Islands 10 Ore 1941", StartDate=new DateTime(2017,1,1), Duration=30, State=LotState.ForSale, User=userIvan, ImageData=imageData_coin_Faroe_Islands, ImageType=contentType
                    },
                    new Lot
                    {
                        Id=4, Name="5 cents", StartPrice=50M, Description="Malta 5 cents 1976", StartDate=new DateTime(2017,1,1), Duration=30, State=LotState.ForSale, User=userSergey, ImageData=imageData_coin_Malta_5_cents, ImageType=contentType
                    },
                    new Lot
                    {
                        Id=5, Name="2 euro", StartPrice=70M, Description="Slovakia 2 euro 2009", StartDate=new DateTime(2017,1,1), Duration=30, State=LotState.ForSale, User=userAlex, ImageData=imageData_coin_Slovakia_2_euro, ImageType=contentType
                    },
                    new Lot
                    {
                        Id=6, Name="1 tolar", StartPrice=58M, Description="Slovenia  2000", StartDate=new DateTime(2017,1,1), Duration=30, State=LotState.ForSale, User=userAlex, ImageData=imageData_coin_Slovenia_1_tolar, ImageType=contentType
                    },
                    new Lot
                    {
                        Id=7, Name="BYZANTIUM Romanos III Argyros", StartPrice=58M, Description="BYZANTIUM Romanos III Argyros ANONYMOUS Follis", StartDate=new DateTime(2017,1,1), Duration=23, State=LotState.ForSale, User=userAlex, ImageData=imageData_coin_BYZANTIUM_Romanos_III, ImageType=contentType
                    },
                    new Lot
                    {
                        Id=8, Name="Rzeczpospolita 18 pennies", StartPrice=58M, Description="Rzeczpospolita 18 pennies (ORT) in 1754 August III", StartDate=new DateTime(2017,1,1), Duration=25, State=LotState.ForSale, User=userSergey, ImageData=imageData_coin_Rzeczpospolita_18_pennie, ImageType=contentType
                    },
                    new Lot
                    {
                        Id=9, Name="15 cents 1908 SPB", StartPrice=58M, Description="15 cents 1908 SPB", StartDate=new DateTime(2017,1,1), Duration=24, State=LotState.ForSale, User=userAlex, ImageData=imageData_coin_15_cents_1908_SPB, ImageType=contentType
                    }


                }

            };

            context.Categories.Add(coins);



            Category collecting = new Category
            {
                Id = 2,
                Name = "Clothing",
                ImageData = imageData_category_clothing,
                ImageType = contentType,
                Lots = new List<Lot>
                {
                    new Lot
                    {
                        Id=10, Name="Girl skirt", StartPrice=40M, LastPrice=60M, Description="Girl skirt", StartDate=new DateTime(2017,1,1), Duration=6, State=LotState.Sold, User=userIvan, ImageData=imageData_cloth_Girl_skirt, ImageType=contentType, Bids=new List<Bid>
                        {
                        new Bid { Id = 2, Price = 60M, Date = new DateTime(2017, 1, 4), User=userSergey}
                        },
                        Comments=new List<Comment>
                        {
                        new Comment{Id=1, Date=new DateTime(2017,1,3), Text="This second-hand skirt", User=userSergey},
                        new Comment{Id=2, Date=new DateTime(2017,1,4), Text="Yes, once", User=userIvan}
                        },
                    },
                    new Lot
                    {
                        Id=11, Name="New cap beanies", StartPrice=50M, Description="New cap beanies", StartDate=new DateTime(2016,1,1), Duration=30, State=LotState.Unsold, User=userIvan, ImageData=imageData_cloth_New_cap_beanies, ImageType=contentType
                    },
                    new Lot
                    {
                        Id=12, Name="New fur headphones", StartPrice=55M, Description="New fur headphones", StartDate=new DateTime(2017,1,1), Duration=30, State=LotState.ForSale, User=userIvan, ImageData=imageData_cloth_New_fur_headphones, ImageType=contentType
                    },
                    new Lot
                    {
                        Id=13, Name="Slazenger", StartPrice=40M, Description="Stylish brand men's sweater Slazenger", StartDate=new DateTime(2017,1,1), Duration=30, State=LotState.ForSale, User=userSergey, ImageData=imageData_cloth_Mens_sweater, ImageType=contentType
                    },
                    new Lot
                    {
                        Id=14, Name="The new jacket", StartPrice=50M, Description="The new jacket", StartDate=new DateTime(2017,1,1), Duration=30, State=LotState.ForSale, User=userSergey, ImageData=imageData_cloth_The_new_jacket, ImageType=contentType
                    },
                    new Lot
                    {
                        Id=15, Name="jeans Drizzte", StartPrice=50M, Description="Winter jeans Drizzte", StartDate=new DateTime(2017,1,1), Duration=30, State=LotState.ForSale, User=userSergey, ImageData=imageData_cloth_Winter_jeans_Drizzte, ImageType=contentType
                    },
                    new Lot
                    {
                        Id=16, Name="Winter pants Landsend", StartPrice=50M, Description="Winter pants Landsend", StartDate=new DateTime(2017,1,1), Duration=30, State=LotState.ForSale, User=userAlex, ImageData=imageData_cloth_Winter_pants_Landsend, ImageType=contentType
                    },
                    new Lot
                    {
                        Id=17, Name="Caps for Kids", StartPrice=50M, Description="Caps for Kids", StartDate=new DateTime(2017,1,1), Duration=30, State=LotState.ForSale, User=userAlex, ImageData=imageData_cloth_Caps_for_Kids, ImageType=contentType
                    },
                    new Lot
                    {
                        Id=18, Name="Demiseason overalls Lassie", StartPrice=50M, Description="Demiseason overalls Lassie by Reima", StartDate=new DateTime(2017,1,1), Duration=30, State=LotState.ForSale, User=userIvan, ImageData=imageData_cloth_Demiseason_overalls_Lassie, ImageType=contentType
                    }
                }
            };
            context.Categories.Add(collecting);


            Category books = new Category
            {
                Id = 3,
                Name = "Books",
                ImageData = imageData_category_books,
                ImageType = contentType,
                Lots = new List<Lot>
                {
                    new Lot
                    {
                        Id=19, Name="Amphibian Man", StartPrice=60M, Description="Belyaev Amphibian Man", StartDate=new DateTime(2017,1,1), Duration=30, State=LotState.ForSale, User=userIvan, ImageData=imageData_book_Amphibian_Man, ImageType=contentType
                    },
                    new Lot
                    {
                        Id=20, Name="Bridge to reason", StartPrice=70M, Description="Joe Haldeman - Bridge to reason", StartDate=new DateTime(2017,1,1), Duration=30, State=LotState.ForSale, User=userIvan, ImageData=imageData_book_Bridge_To_reason, ImageType=contentType
                    },
                    new Lot
                    {
                        Id=21, Name="St. John's wort or the first warpath", StartPrice=50M, Description="Kuper - St. John's wort or the first warpath", StartDate=new DateTime(2017,1,1), Duration=30, State=LotState.ForSale, User=userIvan, ImageData=imageData_book_Johns_wort_or_the_first_warpath, ImageType=contentType
                    },
                    new Lot
                    {
                        Id=22, Name="Phoenix operation", StartPrice=100M, Description="Mikhail Prudnikov - Phoenix operation", StartDate=new DateTime(2017,1,1), Duration=30, State=LotState.ForSale, User=userSergey, ImageData=imageData_book_Phoenix_operation, ImageType=contentType
                    },
                    new Lot
                    {
                        Id=23, Name="Treasure Island", StartPrice=75M, LastPrice=90M, Description="Stephenson - Treasure Island", StartDate=new DateTime(2017,1,1), Duration=7, State=LotState.Sold, User=userSergey, ImageData=imageData_book_Treasure_Island, ImageType=contentType, Bids=new List<Bid>
                        {
                        new Bid { Id = 3, Price = 90M, Date = new DateTime(2017, 1, 5), User=userIvan}
                        },
                        Comments=new List<Comment>
                        {
                        new Comment{Id=3, Date=new DateTime(2017,1,3), Text="What publisher released the book?", User=userIvan},
                        new Comment{Id=4, Date=new DateTime(2017,1,4), Text="Cassell and Company", User=userSergey}
                        },
                    },
                    new Lot
                    {
                        Id=24, Name="Detective novel", StartPrice=80M, Description="The modern French detective novel", StartDate=new DateTime(2017,1,1), Duration=10, State=LotState.Unsold, User=userSergey, ImageData=imageData_book_French_detective_novel, ImageType=contentType
                    },
                    new Lot
                    {
                        Id=25, Name="Myths and Legends", StartPrice=80M, Description="Myths and Legends of Ancient Greece", StartDate=new DateTime(2017,1,1), Duration=30, State=LotState.ForSale, User=userAlex, ImageData=imageData_book_Myths_and_Legends, ImageType=contentType
                    },
                    new Lot
                    {
                        Id=26, Name="Tales about Giants", StartPrice=80M, Description="Tales about Giants", StartDate=new DateTime(2017,1,1), Duration=30, State=LotState.ForSale, User=userSergey, ImageData=imageData_book_Tales_about_Giants, ImageType=contentType
                    },
                    new Lot
                    {
                        Id=27, Name="CPSU Central Committee agitators", StartPrice=80M, Description="CPSU Central Committee agitators 1985", StartDate=new DateTime(2017,1,1), Duration=30, State=LotState.ForSale, User=userAlex, ImageData=imageData_book_CPSU_Central_Committee, ImageType=contentType
                    }
                }
            };
            context.Categories.Add(books);



            Category computers = new Category
            {
                Id = 4,
                Name = "Computers",
                ImageData = imageData_category_computers,
                ImageType = contentType,
                Lots = new List<Lot>
                {
                    new Lot
                    {
                        Id=28, Name="Phenom II X4 925", StartPrice=60M, Description="AMD Phenom II X4 925", StartDate=new DateTime(2017,1,1), Duration=30, State=LotState.ForSale, User=userIvan, ImageData=imageData_computer_AMD_Phenom_II, ImageType=contentType
                    },
                    new Lot
                    {
                        Id=29, Name="Xbox 360 Slim 250GB", StartPrice=70M, Description="Game console Microsoft Xbox 360 Slim 250GB", StartDate=new DateTime(2017,1,1), Duration=30, State=LotState.ForSale, User=userIvan, ImageData=imageData_computer_Game_console_Microsoft_Xbox, ImageType=contentType
                    },
                    new Lot
                    {
                        Id=30, Name="VR 3D BOX", StartPrice=50M, Description="Helmet mobile virtual reality VR 3D BOX", StartDate=new DateTime(2017,1,1), Duration=30, State=LotState.ForSale, User=userIvan, ImageData=imageData_computer_Helmet_mobile_virtual, ImageType=contentType
                    },
                    new Lot
                    {
                        Id=31, Name="HP 4535s", StartPrice=100M, LastPrice=130M, Description="Notebook PC HP 4535s", StartDate=new DateTime(2017,1,1), Duration=15, State=LotState.Sold, User=userSergey, ImageData=imageData_computer_HP_4535s, ImageType=contentType, Bids=new List<Bid>
                        {
                        new Bid { Id = 4, Price = 130M, Date = new DateTime(2017, 1, 10), User=userIvan}
                        },
                        Comments=new List<Comment>
                        {
                        new Comment{Id=5, Date=new DateTime(2017,1,3), Text="How many years have used this laptop?", User=userIvan},
                        new Comment{Id=6, Date=new DateTime(2017,1,4), Text="2 yeras", User=userSergey},
                        new Comment{Id=7, Date=new DateTime(2017,1,4), Text="What is the amount of RAM installed on it?", User=userIvan},
                        new Comment{Id=8, Date=new DateTime(2017,1,4), Text="4 gigabytes", User=userSergey},
                        },
                    },
                    new Lot
                    {
                        Id=32, Name="HP 450 G3", StartPrice=75M, Description="HP ProBook 450 G3", StartDate=new DateTime(2017,1,1), Duration=30, State=LotState.ForSale, User=userSergey, ImageData=imageData_computer_HP_ProBook_450, ImageType=contentType
                    },
                    new Lot
                    {
                        Id=33, Name="Monitor SyncMaster 2233", StartPrice=80M, LastPrice=130M, Description="Monitor Samsung SyncMaster 2233", StartDate=new DateTime(2017,1,1), Duration=20, State=LotState.Sold, User=userSergey, ImageData=imageData_computer_Monitor_Samsung_SyncMaster, ImageType=contentType, Bids=new List<Bid>
                        {
                        new Bid { Id = 5, Price = 130M, Date = new DateTime(2017, 1, 15), User=userAlex}
                        },
                        Comments=new List<Comment>
                        {
                        new Comment{Id=9, Date=new DateTime(2017,1,15), Text="I love monitors from Samsung!", User=userAlex},
                        },
                    },
                    new Lot
                    {
                        Id=34, Name="Lenovo B50-30", StartPrice=80M, Description="Notebook Lenovo B50-30", StartDate=new DateTime(2017,1,1), Duration=30, State=LotState.ForSale, User=userAlex, ImageData=imageData_computer_Lenovo_B50_30, ImageType=contentType
                    },
                    new Lot
                    {
                        Id=35, Name="MSI Apache GE60", StartPrice=80M, Description="Notebook MSI Apache GE60", StartDate=new DateTime(2017,1,1), Duration=30, State=LotState.ForSale, User=userIvan, ImageData=imageData_computer_MSI_Apache_GE60, ImageType=contentType
                    },
                    new Lot
                    {
                        Id=36, Name="LENOVO Z50-70", StartPrice=80M, Description="Notebook LENOVO Z50-70", StartDate=new DateTime(2017,1,1), Duration=20, State=LotState.Unsold, User=userSergey, ImageData=imageData_computer_LENOVO_Z50, ImageType=contentType
                    }

                }
            };
            context.Categories.Add(computers);


            Category mobilePhones = new Category
            {
                Id = 5,
                Name = "Mobile phones",
                ImageData = imageData_category_mobile_phones,
                ImageType = contentType,
                Lots = new List<Lot>
                {
                    new Lot
                    {
                        Id=37, Name="Apple iPhone 4S", StartPrice=60M, Description="Apple iPhone 4S Smartphone (16Gb) White", StartDate=new DateTime(2017,1,1), Duration=30, State=LotState.ForSale, User=userIvan, ImageData=imageData_mobile_Apple_iPhone_4S, ImageType=contentType
                    },
                    new Lot
                    {
                        Id=38, Name="Lenovo A5000", StartPrice=70M, LastPrice=130M, Description="Lenovo A5000", StartDate=new DateTime(2017,1,1), Duration=20, State=LotState.Sold, User=userIvan, ImageData=imageData_mobile_Lenovo_A5000, ImageType=contentType, Bids=new List<Bid>
                        {
                        new Bid { Id = 6, Price = 130M, Date = new DateTime(2017, 1, 16), User=userSergey}
                        },
                    },
                    new Lot
                    {
                        Id=39, Name="NOKIA N93", StartPrice=50M, Description="Phone NOKIA N93 (working)", StartDate=new DateTime(2017,1,1), Duration=30, State=LotState.ForSale, User=userIvan, ImageData=imageData_mobile_Phone_NOKIA_N93, ImageType=contentType
                    },
                    new Lot
                    {
                        Id=40, Name="NOKIA Talkman", StartPrice=100M, Description="Phone NOKIA Talkman (working)", StartDate=new DateTime(2017,1,1), Duration=15, State=LotState.Unsold, User=userSergey, ImageData=imageData_mobile_Phone_NOKIA, ImageType=contentType
                    },
                    new Lot
                    {
                        Id=41, Name="SAMSUNG N900", StartPrice=75M, Description="Phone SAMSUNG N900 new", StartDate=new DateTime(2017,1,1), Duration=10, State=LotState.Unsold, User=userSergey, ImageData=imageData_mobile_Phone_SAMSUNG, ImageType=contentType
                    },
                    new Lot
                    {
                        Id=42, Name="ZTE Blade A465", StartPrice=80M, Description="Smartphone ZTE Blade A465 Black", StartDate=new DateTime(2017,1,1), Duration=30, State=LotState.ForSale, User=userAlex, ImageData=imageData_mobile_Smartphone_ZTE, ImageType=contentType
                    },
                    new Lot
                    {
                        Id=43, Name="APPLE iPhone 7", StartPrice=80M, Description="NEW! APPLE iPhone 7", StartDate=new DateTime(2017,1,1), Duration=30, State=LotState.ForSale, User=userSergey, ImageData=imageData_mobile_APPLE_iPhone_7, ImageType=contentType
                    },
                    new Lot
                    {
                        Id=44, Name="Apple iPhone 6", StartPrice=80M, Description="Apple iPhone 6 64GB Gold", StartDate=new DateTime(2017,1,1), Duration=30, State=LotState.ForSale, User=userAlex, ImageData=imageData_mobile_Apple_iPhone_6, ImageType=contentType
                    },
                    new Lot
                    {
                        Id=45, Name="ZTE Blade Q Lux", StartPrice=80M, Description="ZTE Blade Q Lux 3G", StartDate=new DateTime(2017,1,1), Duration=30, State=LotState.ForSale, User=userAlex, ImageData=imageData_mobile_ZTE_Blade_Q, ImageType=contentType
                    }
                }

            };
            context.Categories.Add(mobilePhones);


            Category clothing = new Category
            {
                Id = 6,
                Name = "Collecting",
                ImageData = imageData_category_collecting,
                ImageType = contentType,
                Lots = new List<Lot>
                {
                    new Lot
                    {
                        Id=46, Name="DPO BSSR", StartPrice=60M, LastPrice=80M, Description="Excellent DPO BSSR", StartDate=new DateTime(2017,1,1), Duration=30, State=LotState.ForSale, User=userIvan, ImageData=imageData_collecting_Excellent_DPO, ImageType=contentType, Comments=new List<Comment>
                        {
                        new Comment{Id=10, Date=new DateTime(2017,1,2), Text="what year this icon?", User=userSergey},
                        new Comment{Id=11, Date=new DateTime(2017,1,3), Text="1986", User=userIvan}
                        },
                        Bids=new List<Bid>
                        {
                        new Bid { Id = 7, Price = 80M, Date = new DateTime(2017, 1, 5), User=userSergey}
                        }
                    },
                    new Lot
                    {
                        Id=47, Name="Gold Medal school", StartPrice=70M, Description="Gold Medal school BSSR", StartDate=new DateTime(2017,1,1), Duration=30, State=LotState.ForSale, User=userIvan, ImageData=imageData_collecting_Gold_Medal_school_BSSR, ImageType=contentType
                    },
                    new Lot
                    {
                        Id=48, Name="Civil Aviation School", StartPrice=50M, Description="Krasnoyarsk Civil Aviation School", StartDate=new DateTime(2017,1,1), Duration=30, State=LotState.ForSale, User=userIvan, ImageData=imageData_collecting_Krasnoyarsk_Civil_School, ImageType=contentType
                    },
                    new Lot
                    {
                        Id=49, Name="BHSS-BEP 80 years", StartPrice=100M, Description="Ministry of Internal Affairs BHSS-BEP 80 years", StartDate=new DateTime(2017,1,1), Duration=30, State=LotState.ForSale, User=userSergey, ImageData=imageData_collecting_Ministry_of_Internal_Affairs, ImageType=contentType
                    },
                    new Lot
                    {
                        Id=50, Name="Ready for Labour and Defence", StartPrice=75M, Description="Ready for Labour and Defence of the USSR", StartDate=new DateTime(2017,1,1), Duration=30, State=LotState.ForSale, User=userSergey, ImageData=imageData_collecting_Ready_for_Labour_and_Defence, ImageType=contentType
                    },
                    new Lot
                    {
                        Id=51, Name="Excellence in Emergency Ministry", StartPrice=80M, LastPrice=100M, Description="Sign of Excellence in Emergency Ministry", StartDate=new DateTime(2017,1,1), Duration=19, State=LotState.Sold, User=userSergey, ImageData=imageData_collecting_Sign_of_Excellence, ImageType=contentType, Bids=new List<Bid>
                        {
                        new Bid { Id = 8, Price = 100M, Date = new DateTime(2017, 1, 15), User=userAlex}
                        },
                    },
                    new Lot
                    {
                        Id=52, Name="Eleventh definitive issue of Belarus", StartPrice=80M, Description="Eleventh definitive issue of Belarus in 2008", StartDate=new DateTime(2017,1,1), Duration=20, State=LotState.Unsold, User=userAlex, ImageData=imageData_collecting_Eleventh_definitive_issue, ImageType=contentType
                    },
                    new Lot
                    {
                        Id=53, Name="160-163 block and Stamps", StartPrice=80M, Description="160-163 block and Stamps Costumes", StartDate=new DateTime(2017,1,1), Duration=24, State=LotState.ForSale, User=userAlex, ImageData=imageData_collecting_Stamps_Costumes, ImageType=contentType
                    },
                    new Lot
                    {
                        Id=54, Name="Belarus 291-295. Mushrooms", StartPrice=80M, Description="Belarus 291-295. Mushrooms. A series of 5 stamps", StartDate=new DateTime(2017,1,1), Duration=30, State=LotState.ForSale, User=userAlex, ImageData=imageData_collecting_Belarus_Mushrooms, ImageType=contentType
                    }
                }
            };
            context.Categories.Add(clothing);

            context.SaveChanges();

            base.Seed(context);
        }
    }
}

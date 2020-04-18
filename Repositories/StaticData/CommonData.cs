using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Repositories.StaticData
{
    public class CommonData
    {
        public static DesignVM DisplayBanner = new DesignVM()
        {
            Quote = "Welcome",
            Title = "Chào mừng thực khách đến với nhà hàng",
            Content = ""
        };

        public static DesignVM DisplayWelcome = new DesignVM()
        {
            Title = "Chào mừng thực khách đến với nhà hàng",
            Content = "Để tránh tình trạng hết bàn/bàn view sông đẹp trong những dịp quan trọng, cuối tuần, lễ tết, Khiem-Baba đã tạo ra một hệ thống tự đặt bàn trực tuyến dành cho bạn. Chỉ cần điền số điện thoại là ngay lập tức bạn đã bàn không lo hết mà còn được cả vị trí view sông đẹp. Chưa hết đâu, bạn còn nhận được giảm 10% tổng bill khi đặt trực tuyến nữa. Còn chân chừ gì mà không gọi mấy đứa cạ cứng đến chiến và thưởng thức có một không hai?"
        };

        public static List<DesignVM> DisplayInfo = new List<DesignVM>()
        {
            new DesignVM()
            {
                Title = "096 395 2222",
                Content = "Hãy gọi cho chúng tôi"
            },
            new DesignVM()
            {
                Title = "38 Hòa Mã",
                Content = "phường Phạm Đình Hổ, quận Hai Bà Trưng, Hà Nội"
            },
            new DesignVM()
            {
                Title = "Mở cửa Thứ 2 - Chủ nhật",
                Content = "9:30am - 23:00pm"
            }
        };

        public static List<DesignVM> DisplayService = new List<DesignVM>()
        {
             new DesignVM()
             {
                  Title = "Dịch vụ của chúng tôi",
                  Content = "Đến với nhà hàng, bạn sẽ được trải nghiệm dịch vụ tuyệt vời của chúng tôi"
             },
             new DesignVM()
             {
                  Title = "Thực phẩm sạch",
                  Content = "Thực phẩm hoàn toàn từ tự nhiên, không chất bảo quản"
             },
             new DesignVM()
             {
                  Title = "Ship đồ ăn",
                  Content = "Chúng tôi đang thử nhiệm dịch vụ này"
             },
             new DesignVM()
             {
                  Title = "Hoạt động 24h / ngày",
                  Content = "Gọi cho chúng tôi ngay"
             }
        };

        public static DesignVM DisplayHotMenu = new DesignVM()
        {
            Title = "Hot Menu",
            Content = "Những món ăn được nhiều người ưa chuộng nhất"
        };

        public static DesignVM DisplayMenu = new DesignVM()
        {
            Title = "Menu",
            Content = "Món ăn cơ bản của nhà hàng"
        };

        public static List<string> DisplayImage = new List<string>()
        {
            "undefined-nha-hang-khiem-hoa-ma-0-3ce0d435637142648453980384.jpg",
            "undefined-nha-hang-khiem-hoa-ma-0-2b32c527637142650980120770.jpg",
            "undefined-nha-hang-khiem-hoa-ma-0-b94e2f24637121872216088815.jpg",
            "undefined-nha-hang-khiem-hoa-ma-0-c57da97a637121870548895441.jpg",
            "undefined-nha-hang-khiem-hoa-ma-0-14e41da2637121872145731913.jpg",
            "undefined-nha-hang-khiem-hoa-ma-0-a921ce4e637142650771390094.jpg",
            "undefined-nha-hang-khiem-hoa-ma-0-6bb678c6637121872089415191.jpg",
            "undefined-nha-hang-khiem-hoa-ma-0-645d7a23637121871140455025.jpg"
        };

        public static MenuVM Menu = new MenuVM()
        {
            Food = new FoodVM()
            {
                Description = "Bia Saigon Gold như chủ tịch Sabeco mô tả là một loại bia với chất lượng vượt trội hơn các loại bia quốc tế trên thị trường.",
                Name = "Stella",
                Image = "unnamed.png"
            },
            Food1 = new FoodVM()
            {
                Description = "Bia Saigon Gold như chủ tịch Sabeco mô tả là một loại bia với chất lượng vượt trội hơn các loại bia quốc tế trên thị trường.",
                Name = "Sai Gon",
                Image = "bia-sai-gon-lager-330ml-201909101523230056.jpg"
            },
            Food2 = new FoodVM()
            {
                Description = "Bia Saigon Gold như chủ tịch Sabeco mô tả là một loại bia với chất lượng vượt trội hơn các loại bia quốc tế trên thị trường.",
                Name = "Corona",
                Image = "bia-corona-355ml-201903251008037080.jfif"
            },
            Food3 = new FoodVM()
            {
                Description = "Món ăn này được bàn tay của đầu bếp nấu cỗ 29 chế biến vô cùng đơn giản nhưng ăn một lần là nhớ mãi đó nhé.",
                Name = "Món ăn 1",
                Image = "undefined-nha-hang-khiem-hoa-ma-0-e7ee9f60637121871738254689.jpg"
            },
            Food4 = new FoodVM()
            {
                Description = "Món ăn này được bàn tay của đầu bếp nấu cỗ 29 chế biến vô cùng đơn giản nhưng ăn một lần là nhớ mãi đó nhé.",
                Name = "Món ăn 2",
                Image = "undefined-nha-hang-khiem-hoa-ma-0-dbc8a02d637121870726113713.jpg"
            },
            Food5 = new FoodVM()
            {
                Description = "Món ăn này được bàn tay của đầu bếp nấu cỗ 29 chế biến vô cùng đơn giản nhưng ăn một lần là nhớ mãi đó nhé.",
                Name = "Món ăn 3",
                Image = "undefined-nha-hang-khiem-hoa-ma-0-a0143bcb637121871058241971.jpg"
            },
            Food6 = new FoodVM()
            {
                Description = "Món ăn này được bàn tay của đầu bếp nấu cỗ 29 chế biến vô cùng đơn giản nhưng ăn một lần là nhớ mãi đó nhé.",
                Name = "Món ăn 4",
                Image = "undefined-nha-hang-khiem-hoa-ma-0-27ea08cc637121871575232599.jpg"
            },
            Food7 = new FoodVM()
            {
                Description = "Món ăn này được bàn tay của đầu bếp nấu cỗ 29 chế biến vô cùng đơn giản nhưng ăn một lần là nhớ mãi đó nhé.",
                Name = "Món ăn 5",
                Image = "undefined-nha-hang-khiem-hoa-ma-0-5e59d19f637121871883804555.jpg"
            }
        };

        public static HotMenuVM HotMenu = new HotMenuVM()
        {
            Food = new FoodVM()
            {
                Description = "Món ăn này được bàn tay của đầu bếp nấu cỗ 29 chế biến vô cùng đơn giản nhưng ăn một lần là nhớ mãi đó nhé.",
                Name = "Món ăn 1",
                Image = "undefined-nha-hang-khiem-hoa-ma-0-e7ee9f60637121871738254689.jpg"
            },
            Food1 = new FoodVM()
            {
                Description = "Món ăn này được bàn tay của đầu bếp nấu cỗ 29 chế biến vô cùng đơn giản nhưng ăn một lần là nhớ mãi đó nhé.",
                Name = "Món ăn 2",
                Image = "undefined-nha-hang-khiem-hoa-ma-0-dbc8a02d637121870726113713.jpg"
            },
            Food2 = new FoodVM()
            {
                Description = "Món ăn này được bàn tay của đầu bếp nấu cỗ 29 chế biến vô cùng đơn giản nhưng ăn một lần là nhớ mãi đó nhé.",
                Name = "Món ăn 3",
                Image = "undefined-nha-hang-khiem-hoa-ma-0-a0143bcb637121871058241971.jpg"
            },
            Food3 = new FoodVM()
            {
                Description = "Món ăn này được bàn tay của đầu bếp nấu cỗ 29 chế biến vô cùng đơn giản nhưng ăn một lần là nhớ mãi đó nhé.",
                Name = "Món ăn 4",
                Image = "undefined-nha-hang-khiem-hoa-ma-0-27ea08cc637121871575232599.jpg"
            },
            Food4 = new FoodVM()
            {
                Description = "Món ăn này được bàn tay của đầu bếp nấu cỗ 29 chế biến vô cùng đơn giản nhưng ăn một lần là nhớ mãi đó nhé.",
                Name = "Món ăn 5",
                Image = "undefined-nha-hang-khiem-hoa-ma-0-5e59d19f637121871883804555.jpg"
            },
            Food5 = new FoodVM()
            {
                Description = "Món ăn này được bàn tay của đầu bếp nấu cỗ 29 chế biến vô cùng đơn giản nhưng ăn một lần là nhớ mãi đó nhé.",
                Name = "Món ăn 6",
                Image = "undefined-nha-hang-khiem-hoa-ma-0-1e347e2a637121871242636335.jpg"
            }
        };

        public static List<DesignVM> DisplaySynthesizeInfo = new List<DesignVM>()
        {
            new DesignVM()
            {
                Title = "50",
                Content = "Món ăn hấp dẫn"
            },
            new DesignVM()
            {
                Title = "4",
                Content = "Đầu bếp nổi tiếng"
            },
            new DesignVM()
            {
                Title = "5128",
                Content = "Khách hàng đã phục vụ"
            }
        };

        public static List<FoodCategoryVM> DisplayFoodCategory = new List<FoodCategoryVM>()
        {
            new FoodCategoryVM()
            {
                Name = "Món ăn",
                Foods = new Collection<FoodVM>()
                {
                   new FoodVM()
                   {
                       Image = "undefined-nha-hang-khiem-hoa-ma-0-e7ee9f60637121871738254689.jpg",
                       Name = "Món ăn 1",
                       Description = "Món ăn này được bàn tay của đầu bếp nấu cỗ 29 chế biến vô cùng đơn giản nhưng ăn một lần là nhớ mãi đó nhé."
                   },
                   new FoodVM()
                   {
                       Image = "undefined-nha-hang-khiem-hoa-ma-0-dbc8a02d637121870726113713.jpg",
                       Name = "Món ăn 2",
                       Description = "Món ăn này được bàn tay của đầu bếp nấu cỗ 29 chế biến vô cùng đơn giản nhưng ăn một lần là nhớ mãi đó nhé."
                   },
                   new FoodVM()
                   {
                       Image = "undefined-nha-hang-khiem-hoa-ma-0-a0143bcb637121871058241971.jpg",
                       Name = "Món ăn 3",
                       Description = "Món ăn này được bàn tay của đầu bếp nấu cỗ 29 chế biến vô cùng đơn giản nhưng ăn một lần là nhớ mãi đó nhé."
                   }
                }
            },
            new FoodCategoryVM()
            {
                Name = "Món khai vị",
                Foods = new Collection<FoodVM>()
                {
                   new FoodVM()
                   {
                       Image = "undefined-nha-hang-khiem-hoa-ma-0-e7ee9f60637121871738254689.jpg",
                       Name = "Món ăn 1",
                       Description = "Món ăn này được bàn tay của đầu bếp nấu cỗ 29 chế biến vô cùng đơn giản nhưng ăn một lần là nhớ mãi đó nhé."
                   },
                   new FoodVM()
                   {
                       Image = "undefined-nha-hang-khiem-hoa-ma-0-dbc8a02d637121870726113713.jpg",
                       Name = "Món ăn 2",
                       Description = "Món ăn này được bàn tay của đầu bếp nấu cỗ 29 chế biến vô cùng đơn giản nhưng ăn một lần là nhớ mãi đó nhé."
                   },
                   new FoodVM()
                   {
                       Image = "undefined-nha-hang-khiem-hoa-ma-0-a0143bcb637121871058241971.jpg",
                       Name = "Món ăn 3",
                       Description = "Món ăn này được bàn tay của đầu bếp nấu cỗ 29 chế biến vô cùng đơn giản nhưng ăn một lần là nhớ mãi đó nhé."
                   }
                }
            },
            new FoodCategoryVM()
            {
                Name = "Đồ uống",
                Foods = new Collection<FoodVM>()
                {
                   new FoodVM()
                   {
                       Image = "undefined-nha-hang-khiem-hoa-ma-0-e7ee9f60637121871738254689.jpg",
                       Name = "Món ăn 1",
                       Description = "Món ăn này được bàn tay của đầu bếp nấu cỗ 29 chế biến vô cùng đơn giản nhưng ăn một lần là nhớ mãi đó nhé."
                   },
                   new FoodVM()
                   {
                       Image = "undefined-nha-hang-khiem-hoa-ma-0-dbc8a02d637121870726113713.jpg",
                       Name = "Món ăn 2",
                       Description = "Món ăn này được bàn tay của đầu bếp nấu cỗ 29 chế biến vô cùng đơn giản nhưng ăn một lần là nhớ mãi đó nhé."
                   },
                   new FoodVM()
                   {
                       Image = "undefined-nha-hang-khiem-hoa-ma-0-a0143bcb637121871058241971.jpg",
                       Name = "Món ăn 3",
                       Description = "Món ăn này được bàn tay của đầu bếp nấu cỗ 29 chế biến vô cùng đơn giản nhưng ăn một lần là nhớ mãi đó nhé."
                   }
                }
            }
        };

        public static List<FoodCategoryVM> DisplayFoodCategoryMenu = new List<FoodCategoryVM>()
        {
            new FoodCategoryVM()
            {
                Name = "Món ăn",
                Id = 1
            },
            new FoodCategoryVM()
            {
                Name = "Món khai vị",
                Id = 2
            },
            new FoodCategoryVM()
            {
                Name = "Đồ uống",
                Id = 3
            }
        };

        public static List<FoodVM> DisplayFoodMenu = new List<FoodVM>()
        {
            new FoodVM()
            {
                FoodCategoryId = 2,
                Image = "undefined-nha-hang-khiem-hoa-ma-0-e7ee9f60637121871738254689.jpg",
                Name = "Món ăn 1",
                Description = "Món ăn này được bàn tay của đầu bếp nấu cỗ 29 chế biến vô cùng đơn giản nhưng ăn một lần là nhớ mãi đó nhé."
            },
            new FoodVM()
            {
                FoodCategoryId = 2,
                Image = "undefined-nha-hang-khiem-hoa-ma-0-e7ee9f60637121871738254689.jpg",
                Name = "Món ăn 1",
                Description = "Món ăn này được bàn tay của đầu bếp nấu cỗ 29 chế biến vô cùng đơn giản nhưng ăn một lần là nhớ mãi đó nhé."
            },
            new FoodVM()
            {
                FoodCategoryId = 2,
                Image = "undefined-nha-hang-khiem-hoa-ma-0-e7ee9f60637121871738254689.jpg",
                Name = "Món ăn 1",
                Description = "Món ăn này được bàn tay của đầu bếp nấu cỗ 29 chế biến vô cùng đơn giản nhưng ăn một lần là nhớ mãi đó nhé."
            },
            new FoodVM()
            {
                FoodCategoryId = 2,
                Image = "undefined-nha-hang-khiem-hoa-ma-0-e7ee9f60637121871738254689.jpg",
                Name = "Món ăn 1",
                Description = "Món ăn này được bàn tay của đầu bếp nấu cỗ 29 chế biến vô cùng đơn giản nhưng ăn một lần là nhớ mãi đó nhé."
            },
            new FoodVM()
            {
                FoodCategoryId = 2,
                Image = "undefined-nha-hang-khiem-hoa-ma-0-e7ee9f60637121871738254689.jpg",
                Name = "Món ăn 1",
                Description = "Món ăn này được bàn tay của đầu bếp nấu cỗ 29 chế biến vô cùng đơn giản nhưng ăn một lần là nhớ mãi đó nhé."
            },
            new FoodVM()
            {
                FoodCategoryId = 2,
                Image = "undefined-nha-hang-khiem-hoa-ma-0-e7ee9f60637121871738254689.jpg",
                Name = "Món ăn 1",
                Description = "Món ăn này được bàn tay của đầu bếp nấu cỗ 29 chế biến vô cùng đơn giản nhưng ăn một lần là nhớ mãi đó nhé."
            },
            new FoodVM()
            {
                FoodCategoryId = 2,
                Image = "undefined-nha-hang-khiem-hoa-ma-0-e7ee9f60637121871738254689.jpg",
                Name = "Món ăn 1",
                Description = "Món ăn này được bàn tay của đầu bếp nấu cỗ 29 chế biến vô cùng đơn giản nhưng ăn một lần là nhớ mãi đó nhé."
            },
            new FoodVM()
            {
                FoodCategoryId = 2,
                Image = "undefined-nha-hang-khiem-hoa-ma-0-e7ee9f60637121871738254689.jpg",
                Name = "Món ăn 1",
                Description = "Món ăn này được bàn tay của đầu bếp nấu cỗ 29 chế biến vô cùng đơn giản nhưng ăn một lần là nhớ mãi đó nhé."
            },
            new FoodVM()
            {
                FoodCategoryId = 3,
                Image = "undefined-nha-hang-khiem-hoa-ma-0-e7ee9f60637121871738254689.jpg",
                Name = "Món ăn 1",
                Description = "Món ăn này được bàn tay của đầu bếp nấu cỗ 29 chế biến vô cùng đơn giản nhưng ăn một lần là nhớ mãi đó nhé."
            },
            new FoodVM()
            {
                FoodCategoryId = 3,
                Image = "undefined-nha-hang-khiem-hoa-ma-0-e7ee9f60637121871738254689.jpg",
                Name = "Món ăn 1",
                Description = "Món ăn này được bàn tay của đầu bếp nấu cỗ 29 chế biến vô cùng đơn giản nhưng ăn một lần là nhớ mãi đó nhé."
            },
            new FoodVM()
            {
                FoodCategoryId = 3,
                Image = "undefined-nha-hang-khiem-hoa-ma-0-e7ee9f60637121871738254689.jpg",
                Name = "Món ăn 1",
                Description = "Món ăn này được bàn tay của đầu bếp nấu cỗ 29 chế biến vô cùng đơn giản nhưng ăn một lần là nhớ mãi đó nhé."
            },
            new FoodVM()
            {
                FoodCategoryId = 3,
                Image = "undefined-nha-hang-khiem-hoa-ma-0-e7ee9f60637121871738254689.jpg",
                Name = "Món ăn 1",
                Description = "Món ăn này được bàn tay của đầu bếp nấu cỗ 29 chế biến vô cùng đơn giản nhưng ăn một lần là nhớ mãi đó nhé."
            },
            new FoodVM()
            {
                FoodCategoryId = 3,
                Image = "undefined-nha-hang-khiem-hoa-ma-0-e7ee9f60637121871738254689.jpg",
                Name = "Món ăn 1",
                Description = "Món ăn này được bàn tay của đầu bếp nấu cỗ 29 chế biến vô cùng đơn giản nhưng ăn một lần là nhớ mãi đó nhé."
            },
            new FoodVM()
            {
                FoodCategoryId = 3,
                Image = "undefined-nha-hang-khiem-hoa-ma-0-e7ee9f60637121871738254689.jpg",
                Name = "Món ăn 1",
                Description = "Món ăn này được bàn tay của đầu bếp nấu cỗ 29 chế biến vô cùng đơn giản nhưng ăn một lần là nhớ mãi đó nhé."
            },
            new FoodVM()
            {
                FoodCategoryId = 3,
                Image = "undefined-nha-hang-khiem-hoa-ma-0-e7ee9f60637121871738254689.jpg",
                Name = "Món ăn 1",
                Description = "Món ăn này được bàn tay của đầu bếp nấu cỗ 29 chế biến vô cùng đơn giản nhưng ăn một lần là nhớ mãi đó nhé."
            },
            new FoodVM()
            {
                FoodCategoryId = 3,
                Image = "undefined-nha-hang-khiem-hoa-ma-0-e7ee9f60637121871738254689.jpg",
                Name = "Món ăn 1",
                Description = "Món ăn này được bàn tay của đầu bếp nấu cỗ 29 chế biến vô cùng đơn giản nhưng ăn một lần là nhớ mãi đó nhé."
            },
            new FoodVM()
            {
                FoodCategoryId = 1,
                Image = "undefined-nha-hang-khiem-hoa-ma-0-e7ee9f60637121871738254689.jpg",
                Name = "Món ăn 1",
                Description = "Món ăn này được bàn tay của đầu bếp nấu cỗ 29 chế biến vô cùng đơn giản nhưng ăn một lần là nhớ mãi đó nhé."
            },
            new FoodVM()
            {
                FoodCategoryId = 1,
                Image = "undefined-nha-hang-khiem-hoa-ma-0-e7ee9f60637121871738254689.jpg",
                Name = "Món ăn 1",
                Description = "Món ăn này được bàn tay của đầu bếp nấu cỗ 29 chế biến vô cùng đơn giản nhưng ăn một lần là nhớ mãi đó nhé."
            },
            new FoodVM()
            {
                FoodCategoryId = 1,
                Image = "undefined-nha-hang-khiem-hoa-ma-0-e7ee9f60637121871738254689.jpg",
                Name = "Món ăn 1",
                Description = "Món ăn này được bàn tay của đầu bếp nấu cỗ 29 chế biến vô cùng đơn giản nhưng ăn một lần là nhớ mãi đó nhé."
            },
            new FoodVM()
            {
                FoodCategoryId = 1,
                Image = "undefined-nha-hang-khiem-hoa-ma-0-e7ee9f60637121871738254689.jpg",
                Name = "Món ăn 1",
                Description = "Món ăn này được bàn tay của đầu bếp nấu cỗ 29 chế biến vô cùng đơn giản nhưng ăn một lần là nhớ mãi đó nhé."
            },
            new FoodVM()
            {
                FoodCategoryId = 1,
                Image = "undefined-nha-hang-khiem-hoa-ma-0-e7ee9f60637121871738254689.jpg",
                Name = "Món ăn 1",
                Description = "Món ăn này được bàn tay của đầu bếp nấu cỗ 29 chế biến vô cùng đơn giản nhưng ăn một lần là nhớ mãi đó nhé."
            },
            new FoodVM()
            {
                FoodCategoryId = 1,
                Image = "undefined-nha-hang-khiem-hoa-ma-0-e7ee9f60637121871738254689.jpg",
                Name = "Món ăn 1",
                Description = "Món ăn này được bàn tay của đầu bếp nấu cỗ 29 chế biến vô cùng đơn giản nhưng ăn một lần là nhớ mãi đó nhé."
            },
            new FoodVM()
            {
                FoodCategoryId = 1,
                Image = "undefined-nha-hang-khiem-hoa-ma-0-e7ee9f60637121871738254689.jpg",
                Name = "Món ăn 1",
                Description = "Món ăn này được bàn tay của đầu bếp nấu cỗ 29 chế biến vô cùng đơn giản nhưng ăn một lần là nhớ mãi đó nhé."
            },
            new FoodVM()
            {
                FoodCategoryId = 1,
                Image = "undefined-nha-hang-khiem-hoa-ma-0-e7ee9f60637121871738254689.jpg",
                Name = "Món ăn 1",
                Description = "Món ăn này được bàn tay của đầu bếp nấu cỗ 29 chế biến vô cùng đơn giản nhưng ăn một lần là nhớ mãi đó nhé."
            }
        };

        public static string DisplayImageFoodCategory = "about.jpg";
    }
}

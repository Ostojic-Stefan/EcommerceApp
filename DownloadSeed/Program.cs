using System.Text;
using System.Text.Json;

namespace DownloadSeed
{
    internal class Program
    {
        private readonly static Random random = new();
        private readonly static HttpClient httpClient = new();
        private readonly static List<string> cpuLinks = new()
        {
            "https://search.gigatron.rs/v1/catalog/get/racunari-i-komponente/komponente/procesori?strana=1",
            "https://search.gigatron.rs/v1/catalog/get/racunari-i-komponente/komponente/procesori?strana=2",
            "https://search.gigatron.rs/v1/catalog/get/racunari-i-komponente/komponente/procesori?strana=3"
        };

        private readonly static List<string> memoryLinks = new()
        {
            "https://search.gigatron.rs/v1/catalog/get/racunari-i-komponente/komponente/memorije?strana=1",
            "https://search.gigatron.rs/v1/catalog/get/racunari-i-komponente/komponente/memorije?strana=2",
        };

        private readonly static List<string> hardDriveLinks = new()
        {
            "https://search.gigatron.rs/v1/catalog/get/racunari-i-komponente/komponente/hard-diskovi?strana=1",
            "https://search.gigatron.rs/v1/catalog/get/racunari-i-komponente/komponente/hard-diskovi?strana=2",
        };

        internal record Product(
            string Name,
            string Brand,
            int CategoryId,
            decimal Price,
            int InStock,
            string ImageSource,
            string ImageUrlToSevrve,
            string Specifications,
            DateTime CreatedAt);

        internal enum Categories
        {
            GraphicsCard = 1,
            HardDrives,
            ComputerCase,
            Motherboards,
            Memory,
            PowerSupply,
            Processor,
            SSD
        }

        private readonly static Dictionary<string, Categories> categoriesMap = new()
        {
            { "Procesori", Categories.Processor },
            { "Memorije", Categories.Memory },
            { "Hard diskovi", Categories.HardDrives },
        };

        static async Task Main(string[] args)
        {
            await GetData(cpuLinks, "processors");
            await GetData(memoryLinks, "memory");
            await GetData(hardDriveLinks, "hard_drives");
        }

        private static async Task GetData(List<string> urls, string productType)
        {
            List<Task<List<Product>>> tasks = new(3);

            foreach (var link in urls)
            {
                var task = Task.Run(async () =>
                {
                    var result = await httpClient.GetAsync(link);
                    var data = await result.Content.ReadAsStringAsync();
                    Root root = JsonSerializer.Deserialize<Root>(data);
                    return root.hits.hits.Select(x =>
                    {
                        return new Product(
                            x._source.search_result_data.name,
                            x._source.search_result_data.brand,
                            (int)categoriesMap[x._source.search_result_data.subcategory],
                            decimal.Parse(x._source.search_result_data.price),
                            random.Next(1, 100),
                            x._source.search_result_data.image,
                            $"https://localhost:5001/Images/{x._source.search_result_data.image.Split('/').Last()}",
                            JsonSerializer.Serialize(x._source.search_result_data.specification_summary),
                            DateTime.Now
                        );
                    }).ToList();
                });

                tasks.Add(task);
            }

            var prods = (await Task.WhenAll(tasks)).SelectMany(x => x).ToList();
            var imgUrls = prods.Select(x => x.ImageSource).ToList();
            await DownloadImagesAsync(imgUrls);
            await ExportProductsAsJsonAsync(prods, productType);
        }

        private static async Task ExportProductsAsJsonAsync(List<Product> products, string fileName)
        {
            var json = JsonSerializer.Serialize(products);
            using (var fStream = new FileStream($"./Export/{fileName}.json", FileMode.Create, FileAccess.Write))
            {
                byte[] bytes = Encoding.UTF8.GetBytes(json);
                await fStream.WriteAsync(bytes, 0, bytes.Length);
            }
        }

        private static async Task DownloadImagesAsync(List<string> imagesToDownload)
        {
            if (!Directory.Exists("./Export/Image"))
            {
                Directory.CreateDirectory("./Export/Image");
            }

            var tasks = new List<Task>();

            foreach (var img in imagesToDownload)
            {
                var task = Task.Run(async () =>
                {
                    var response = await httpClient.GetAsync(img);
                    var imageContent = await response.Content.ReadAsStreamAsync();

                    var imgPath = Path.Combine("./Export/Image", img.Split('/').Last());

                    using (var fStream = new FileStream(imgPath, FileMode.Create, FileAccess.Write))
                    {
                        imageContent.CopyTo(fStream);
                    }
                });

                tasks.Add(task);
            }

            await Task.WhenAll(tasks);
        }
    }
}
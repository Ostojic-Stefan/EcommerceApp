using System.Text;
using System.Text.Json;

namespace DownloadSeed
{
    internal class Program
    {
        private readonly static Random random = new();
        private readonly static HttpClient httpClient = new();

        private readonly static Dictionary<string, string> urls = new()
        {
            { "https://search.gigatron.rs/v1/catalog/get/racunari-i-komponente/komponente/procesori?strana=1", "processors" },
            { "https://search.gigatron.rs/v1/catalog/get/racunari-i-komponente/komponente/procesori?strana=2", "processors" },
            { "https://search.gigatron.rs/v1/catalog/get/racunari-i-komponente/komponente/memorije?strana=1", "memory" },
            { "https://search.gigatron.rs/v1/catalog/get/racunari-i-komponente/komponente/memorije?strana=2", "memory"},
            { "https://search.gigatron.rs/v1/catalog/get/racunari-i-komponente/komponente/hard-diskovi?strana=1", "hard_drives" },
            { "https://search.gigatron.rs/v1/catalog/get/racunari-i-komponente/komponente/hard-diskovi?strana=2", "hard_drives" },
            { "https://search.gigatron.rs/v1/catalog/get/racunari-i-komponente/komponente/graficke-karte?strana=1", "graphics_cards" },
            { "https://search.gigatron.rs/v1/catalog/get/racunari-i-komponente/komponente/graficke-karte?strana=2", "graphics_cards" },
            { "https://search.gigatron.rs/v1/catalog/get/racunari-i-komponente/komponente/kucista?strana=1", "cases" },
            { "https://search.gigatron.rs/v1/catalog/get/racunari-i-komponente/komponente/kucista?strana=2", "cases" },
            { "https://search.gigatron.rs/v1/catalog/get/racunari-i-komponente/komponente/maticne-ploce?strana=1", "motherboards" },
            { "https://search.gigatron.rs/v1/catalog/get/racunari-i-komponente/komponente/maticne-ploce?strana=2", "motherboards" },
            { "https://search.gigatron.rs/v1/catalog/get/racunari-i-komponente/komponente/napajanja?strana=1", "power_supplies" },
            { "https://search.gigatron.rs/v1/catalog/get/racunari-i-komponente/komponente/napajanja?strana=2", "power_supplies" },
            { "https://search.gigatron.rs/v1/catalog/get/racunari-i-komponente/komponente/ssd?strana=1", "ssd" },
            { "https://search.gigatron.rs/v1/catalog/get/racunari-i-komponente/komponente/ssd?strana=2", "ssd" },
        };

        internal record ProductImage(
            string ImageName,
            string Url
        );

        internal record Product(
            string Name,
            string Description,
            string Brand,
            int CategoryId,
            decimal Price,
            int InStock,
            string ImageSource,
            ProductImage productImage,
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
            { "Grafičke karte", Categories.GraphicsCard },
            { "Kućišta", Categories.ComputerCase },
            { "Matične ploče", Categories.Motherboards },
            { "Napajanja", Categories.PowerSupply },
            { "SSD", Categories.SSD }
        };

        static async Task Main(string[] args)
        {
            await GetDataAsync(urls);
        }

        private static async Task GetDataAsync(Dictionary<string, string> urls)
        {
            List<Task<Root>> apiTasks = new(urls.Count);
            
            foreach (var link in urls)
            {
                Console.WriteLine($"Started Download For: {link}");
                apiTasks.Add(GetApiData(link.Key));
            }

            var data = await Task.WhenAll(apiTasks);
            Console.WriteLine($"Finished Downloading Api Data");

            IEnumerable<Product> prods = data.SelectMany(TransformApiDataIntoProductList);
            Console.WriteLine("Mapped into a product list");

            var imgUrls = prods.Select(x => x.ImageSource).ToList();

            await Task.WhenAll(DownloadImagesAsync(imgUrls), ExportProductsAsJsonAsync(prods));
        }

        private static async Task<Root> GetApiData(string link)
        {
            var result = await httpClient.GetAsync(link);
            var data = await result.Content.ReadAsStringAsync();
            Root root = JsonSerializer.Deserialize<Root>(data);
            return root;
        }

        private static List<Product> TransformApiDataIntoProductList(Root root)
        {
            return root.hits.hits.AsParallel().Select(x =>
            {
                return new Product(
                    x._source.search_result_data.name,
                    "Placeholder Text",
                    x._source.search_result_data.brand,
                    (int)categoriesMap[x._source.search_result_data.subcategory],
                    decimal.Parse(x._source.search_result_data.price),
                    random.Next(1, 100),
                    x._source.search_result_data.image,
                    new ProductImage(
                        x._source.search_result_data.image.Split('/').Last(),
                        $"https://localhost:5001/Images/{x._source.search_result_data.image.Split('/').Last()}"
                    ),
                    JsonSerializer.Serialize(x._source.search_result_data.specification_summary),
                    DateTime.Now
                );
            }).ToList();
        }

        private static async Task ExportProductsAsJsonAsync(IEnumerable<Product> products)
        {
            var json = JsonSerializer.Serialize(products);
            using var fStream = new FileStream($"./Export/products.json", FileMode.Create, FileAccess.Write);
            byte[] bytes = Encoding.UTF8.GetBytes(json);
            await fStream.WriteAsync(bytes);
            Console.WriteLine("Serialized Data");
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
                tasks.Add(DownloadImageAsync(img));
                Console.WriteLine($"Started Download For: {img}");
            }

            await Task.WhenAll(tasks);
            Console.WriteLine("Finished downloading Images");
        }

        private static async Task DownloadImageAsync(string img)
        {
            var response = await httpClient.GetAsync(img);
            var imageContent = await response.Content.ReadAsStreamAsync();

            var imgPath = Path.Combine("./Export/Image", img.Split('/').Last());

            using (var fStream = new FileStream(imgPath, FileMode.Create, FileAccess.Write))
            {
                await imageContent.CopyToAsync(fStream);
                Console.WriteLine($"Downloaded Image {imgPath}");
            }
        }
    }
}
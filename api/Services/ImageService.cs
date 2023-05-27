namespace api.Services
{
    public class ImageService
    {
        private readonly string _imageSavePath;

        public ImageService(IWebHostEnvironment environment)
        {
            _imageSavePath = Path.Combine(environment.WebRootPath, "Images");

            if (!Directory.Exists(_imageSavePath))
            {
                Directory.CreateDirectory(_imageSavePath);
            }
        }

        public async Task<string> SaveImageToFilesystem(string fileName, Stream stream)
        {
            var newFileName = Guid.NewGuid().ToString() + fileName;
            var filePath = Path.Combine(_imageSavePath, newFileName);
            using (FileStream fStream = new(filePath, FileMode.Create, FileAccess.Write))
            {
                await stream.CopyToAsync(fStream);
            }
            return filePath;
        }
    }
}

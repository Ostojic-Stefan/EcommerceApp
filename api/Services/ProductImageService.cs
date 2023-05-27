using api.EntityFrameworkHelpers;
using api.Models;
using System.IO;

namespace api.Services
{
    public class ProductImageService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ImageService _imageService;

        public ProductImageService(IUnitOfWork unitOfWork, ImageService imageService)
        {
            _unitOfWork = unitOfWork;
            _imageService = imageService;
        }

        public async Task<ProductImage> AddProductImageAsync(Product product, string fileName, Stream stream)
        {
            var filePath = await _imageService.SaveImageToFilesystem(fileName, stream);
            var productImageRepo = _unitOfWork.GetReadWriteRepository<ProductImage>();
            var productImage = new ProductImage
            {
                ProductId = product.Id,
                ImageName = fileName,
                Path = filePath,
                Url = Utils.ConvertAbsoluteImageFilePathToUrl(filePath)
            };
            productImageRepo.Add(productImage);
            await _unitOfWork.SaveChangesAsync();
            return productImage;
        }

    }
}

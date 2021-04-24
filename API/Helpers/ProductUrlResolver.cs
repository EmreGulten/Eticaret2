using API.Core.DbModels;
using API.Dtos;
using AutoMapper;

namespace API.Helpers
{
    public class ProductUrlResolver : IValueResolver<Product, ProductToReturnDto, string>
    {
        private readonly Microsoft.Extensions.Configuration.IConfiguration _configuration;
        public ProductUrlResolver(Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string Resolve(Product source, ProductToReturnDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl))
            {
                return _configuration["ApiUrl"] + source.PictureUrl;
            }
            return null;
        }
    }
}

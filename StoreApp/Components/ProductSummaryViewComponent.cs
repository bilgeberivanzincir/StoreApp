using Microsoft.AspNetCore.Mvc;
using Repositories;
using Services.Contracts;

namespace StoreApp.Components
{
    public class ProductSummaryViewComponent : ViewComponent
    {
        private readonly IServiceManager _serviceManager;

        public ProductSummaryViewComponent(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public string Invoke()
        {
            //service ile veritabanındaki tüm verilerinin sayısını değil geçerli ve service içinde filtrelediğimiz verilerin sayısını alırız. 
            return _serviceManager.ProductService.GetAllProducts(false).Count().ToString();
        }
        
    }
    
}
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductApp.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Application.Features.Queries.Product.GetAllProduct
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequest, IList<GetAllProductQueryResponse>>
    {
        private readonly IProductRepository _repository;

        public GetAllProductQueryHandler(IProductRepository repository)
        {
            _repository = repository;
        }
        public async Task<IList<GetAllProductQueryResponse>> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
        {
            var resultList =await  _repository.GetAll(x => x.IsDeleted == false, "Category").ToListAsync();

            List<GetAllProductQueryResponse> productList = new();

            foreach (var product in resultList)
            {
                productList.Add(new GetAllProductQueryResponse
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    Quantity = product.Quantity,
                    IsDeleted = product.IsDeleted,
                    CategoryId = product.CategoryId,
                    CategoryName = product.Category.Name
                });
            }

            return productList;


        }
    }
}

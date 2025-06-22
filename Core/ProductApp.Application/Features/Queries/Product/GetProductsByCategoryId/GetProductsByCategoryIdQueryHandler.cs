using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductApp.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Application.Features.Queries.Product.GetProductsByCategoryId
{
    public class GetProductsByCategoryIdQueryHandler : IRequestHandler<GetProductsByCategoryIdQueryRequest, IList<GetProductsByCategoryIdQueryResponse>>
    {
        private readonly IProductRepository _repository;

        public GetProductsByCategoryIdQueryHandler(IProductRepository repository)
        {
            _repository=repository;
        }
        public async Task<IList<GetProductsByCategoryIdQueryResponse>> Handle(GetProductsByCategoryIdQueryRequest request, CancellationToken cancellationToken)
        {
            var result=await _repository.GetAll(p => p.IsDeleted == false && p.CategoryId == request.CategoryId).ToListAsync();

            List<GetProductsByCategoryIdQueryResponse> productList = new();

            foreach (var product in result)
            {
                productList.Add(new GetProductsByCategoryIdQueryResponse
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    Quantity = product.Quantity,
                    CategoryId = product.CategoryId,


                });
            }

            return productList;
        }
    }
}

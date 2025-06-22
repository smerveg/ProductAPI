using MediatR;
using ProductApp.Application.Repositories;
using ProductApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Application.Features.Commands.Product.AddProduct
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommandRequest, AddProductCommandResponse>
    {
        private readonly IProductRepository _repository;

        public AddProductCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }
        public async Task<AddProductCommandResponse> Handle(AddProductCommandRequest request, CancellationToken cancellationToken)
        {
            await _repository.Add(new ProductApp.Domain.Entities.Product()
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                Quantity = request.Quantity,
                CategoryId = request.CategoryId,
                IsDeleted = false

            });

            var result=await _repository.SaveAsync();

            if (result == 1)
            {
                return new AddProductCommandResponse();
            }
            else {
                throw new Exception("Bad Request Error");
            
            }
            
        }
    }
}

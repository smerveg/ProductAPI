using MediatR;
using ProductApp.Application.Repositories;
using ProductApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ProductApp.Application.Features.Commands.Product.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
    {
        private readonly IProductRepository _repository;

        public UpdateProductCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }
        public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            ProductApp.Domain.Entities.Product product = await _repository.GetById(request.Id);
            if (product != null)
            {
                product.Name = request.Name;
                product.Description = request.Description;
                product.Price = request.Price;
                product.Quantity = request.Quantity;
                product.CategoryId = request.CategoryId;                                 

                _repository.Update(product);

                await _repository.SaveAsync();
                return new UpdateProductCommandResponse();
            }
            else {
                throw new Exception("Product not found");
            }
            
        }
    }
}

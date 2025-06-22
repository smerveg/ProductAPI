using MediatR;
using ProductApp.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Application.Features.Commands.Product.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest, DeleteProductCommandResponse>
    {
        private readonly IProductRepository _repository;

        public DeleteProductCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }
        public async Task<DeleteProductCommandResponse> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            var product=await _repository.GetById(request.Id);

            if (product != null)
            {
                await _repository.Delete(request.Id);
                await _repository.SaveAsync();
                return new DeleteProductCommandResponse();
            }
            else
            {
                throw new Exception("Product not found");
            }
                
           
        }
    }
}

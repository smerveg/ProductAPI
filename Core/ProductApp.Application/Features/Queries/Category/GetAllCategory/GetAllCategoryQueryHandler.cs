using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductApp.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Application.Features.Queries.Category.GetAllCategory
{
    public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQueryRequest, IList<GetAllCategoryQueryResponse>>
    {
        private readonly ICategoryRepository _repository;

        public GetAllCategoryQueryHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }
        public async Task<IList<GetAllCategoryQueryResponse>> Handle(GetAllCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            var resultList =await _repository.GetAll().ToListAsync();

            List<GetAllCategoryQueryResponse> categoryList= new();

            foreach (var category in resultList) {
                categoryList.Add(new GetAllCategoryQueryResponse {
                    Id = category.Id,
                    Name = category.Name,
                
                });
            }

            return categoryList;
        }
    }
}

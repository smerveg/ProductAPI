using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Application.Features.Queries.Product.GetProductsByCategoryId
{
    public class GetProductsByCategoryIdQueryRequest:IRequest<IList<GetProductsByCategoryIdQueryResponse>>
    {
        public int CategoryId { get; set; }
    }
}

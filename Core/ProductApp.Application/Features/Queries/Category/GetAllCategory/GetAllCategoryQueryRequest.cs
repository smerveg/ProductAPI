﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Application.Features.Queries.Category.GetAllCategory
{
    public class GetAllCategoryQueryRequest:IRequest<IList<GetAllCategoryQueryResponse>>
    {
    }
}

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Test.Data.Models;
using Test.Data.Responses;

namespace Test.Domain.Queries
{
    public class GetTownQuery : IRequest<ICollection<GetTownResponse>>
    {
        public string TownName { get; set; }

        public GetTownQuery(string townName)
        { 
            TownName = townName;
        }
    }

    public class GetTownQueryHandler : IRequestHandler<GetTownQuery, ICollection<GetTownResponse>>
    {
        private readonly ShivamTestContext _db;
        public GetTownQueryHandler(ShivamTestContext shivamTestContext)
        {
            _db = shivamTestContext;
        }

        public async Task<ICollection<GetTownResponse>> Handle(GetTownQuery request, CancellationToken cancellationToken)
        {
            ICollection<GetTownResponse> result = new List<GetTownResponse>();
            _db.Towns.Where(condition => condition.Name.StartsWith(request.TownName) || string.IsNullOrWhiteSpace(request.TownName)).ToList().ForEach(data =>
            {
                result.Add(new GetTownResponse()
                {
                    id = data.Idtown,
                    text = data.Name
                });
            });

            return await Task.FromResult(result);
        }
    }
}

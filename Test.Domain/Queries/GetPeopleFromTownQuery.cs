using MediatR;
using Microsoft.EntityFrameworkCore;
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
    public class GetPeopleFromTownQuery : IRequest<ICollection<GetPeopleFromTownQueryResponse>>
    {
        public string IdTown { get; set; }
        public GetPeopleFromTownQuery(string idTown)
        {
            IdTown = idTown;
        }
    }

    public class GetPeopleFromTownQueryHandler : IRequestHandler<GetPeopleFromTownQuery, ICollection<GetPeopleFromTownQueryResponse>>
    {
        private readonly ShivamTestContext _db;
        public GetPeopleFromTownQueryHandler(ShivamTestContext shivamTestContext)
        {
            _db = shivamTestContext;
        }

        public async Task<ICollection<GetPeopleFromTownQueryResponse>> Handle(GetPeopleFromTownQuery request, CancellationToken cancellationToken)
        {
            ICollection<GetPeopleFromTownQueryResponse> result = new List<GetPeopleFromTownQueryResponse>();
            _db.People
                .Include(people => people.IdtownBornNavigation)
                .Include(people => people.IdtownLivesNavigation)
                .Where(condition => condition.IdtownLivesNavigation.Idtown.Equals(request.IdTown) || condition.IdtownBornNavigation.Idtown.Equals(request.IdTown)).ToList()
                .ForEach(people =>
                {
                    result.Add(new GetPeopleFromTownQueryResponse()
                    {
                        Idtown = request.IdTown,
                        Born = people.IdtownBornNavigation?.Name,
                        Lives = people.IdtownLivesNavigation?.Name,
                        PeopleName = people.Name,
                        PeopleSurname = people.Surname
                    });
                });

            return await Task.FromResult(result);
        }
    }
}

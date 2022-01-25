using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Test.Data.Models;

namespace Test.Domain.Commands
{
    public class AddPeopleCommand : IRequest<int>
    {
        public string IdTownBorn { get; set; }
        public string IdTownLives { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public AddPeopleCommand(string idTownBorn,
            string idTownLives,
            string name,
            string surname)
        {
            IdTownBorn = idTownBorn;
            IdTownLives = idTownLives;
            Name = name;
            Surname = surname;
        }
    }

    public class AddPeopleCommandHandler : IRequestHandler<AddPeopleCommand, int>
    {
        private readonly ShivamTestContext _db;
        public AddPeopleCommandHandler(ShivamTestContext shivamTestContext)
        {
            _db = shivamTestContext;
        }

        public async Task<int> Handle(AddPeopleCommand request, CancellationToken cancellationToken)
        {
            var idTownBorn = _db.Towns.Where(condition => condition.Idtown.Equals(request.IdTownBorn)).FirstOrDefault();
            var idTownLives = _db.Towns.Where(condition => condition.Idtown.Equals(request.IdTownLives)).FirstOrDefault();
            var person = new Person()
            {
                IdtownBorn = request.IdTownBorn,
                IdtownLives = request.IdTownLives,
                IdtownBornNavigation = idTownBorn,
                IdtownLivesNavigation = idTownLives,
                Name = request.Name,
                Surname = request.Surname
            };
            _db.People.Add(person);
            _db.SaveChanges();

            return await Task.FromResult(person.Iduser);
        }
    }
}

using JsGrid.Data;
using MediatR;

namespace JsGrid.Services.Persons.Commands
{
    public abstract class AbstractPersonRequest : IRequest<Person>
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string Address { get; set; }

        public bool Married { get; set; }

        public int CountryId { get; set; }
    }
}

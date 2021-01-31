using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Data;
using WebApi.Data.Entity;

namespace WebApi.Contracts
{
    public interface IPersonManager : IRepository<Person>
    {
        Task<(IEnumerable<Person> Persons, Pagination Pagination)> GetPersonsAsync(UrlQueryParameters urlQueryParameters);

        //Add more class specific methods here when neccessary
    }
}

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UsingTask.Shared;

namespace UsingTask.Library
{
    public class PersonRepository
    {
        public async Task<List<Person>> Get(CancellationToken cancellationToken = new CancellationToken())
        {
            await Task.Delay(2000);

            cancellationToken.ThrowIfCancellationRequested();

            // Uncomment to test exception handling in calling code
            //throw new NotImplementedException("Get operation not implemented");

            return People.GetPeople();
        }

        public async Task<Person> Get(int id)
        {
            await Task.Delay(2000);

            return People.GetPeople().Find(p => p.Id == id);
        }
    }
}

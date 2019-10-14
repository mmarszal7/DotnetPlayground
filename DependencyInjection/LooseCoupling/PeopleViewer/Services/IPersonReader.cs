using System.Collections.Generic;

namespace Common
{
    public interface IPersonReader
    {
        IReadOnlyCollection<Person> GetPeople();
        Person GetPerson(int id);
    }
}

using System.Collections.Generic;
using RestWithASPNETUdemy.Model;
using System.Threading;

namespace RestWithASPNETUdemy.Services.Implementattions
{
    public class PersonServiceImpl : IPersonService
    {

        // Contador responsável por gerar um fake ID já que não estamos
        // acessando nenhum banco de dados
        private volatile int count;

        // Metodo responsável por criar uma nova pessoa
        // Se tivéssemos um banco de dados esse seria o
        // momento de persistir os dados
        public Person Create(Person person)
        {
            return person;
        }

        // Método responsável por retornar uma pessoa
        // como não acessamos nenhuma base de dados
        // estamos retornando um mock
        public Person FindById(long id)
        {
            return new Person {
                Id = IncrementAndGet(),
                FirstName = "Leandro",
                LastName = "Costa",
                Address = "Uberlandia - Minas Gerais - Brasil",
                Gender = "Male"
            };
        }

        // Método responsável por deletar
        // uma pessoa a partir de um ID
        public void Delete(long id)
        {
            //A nossa lógica de exclusão viria aqui
        }

        // Método responsável por retornar todas as pessoas
        // mais uma vez essas informações são mocks
        public List<Person> FindAll()
        {
            List<Person> persons = new List<Person>();
            for (int i = 0; i < 8; i++)
            {
                Person person = MockPerson(i);
                persons.Add(person);
            }
            return persons;
        }

        // Método responsável por atualizar uma pessoa
        // por ser mock retornamos a mesma informação passada
        public Person Update(Person person)
        {
            return person;
        }

        private Person MockPerson(int i)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = "Person Name " + i,
                LastName = "Person Lastname " + i,
                Address = "Some Address " + i,
                Gender = "Male"
            };
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }
    }
}

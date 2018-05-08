using System.Collections.Generic;
using RestWithASPNETUdemy.Model;
using System.Threading;
using RestWithASPNETUdemy.Model.Context;
using System;
using System.Linq;
using RestWithASPNETUdemy.Repository;

namespace RestWithASPNETUdemy.Business.Implementattions
{
    public class PersonBusinessImpl : IPersonBusiness
    {

        private IPersonRepository _personRepository;

        public PersonBusinessImpl(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public Person Create(Person person)
        {
            return _personRepository.Create(person);
        }

        public Person FindById(long id)
        {
            return _personRepository.FindById(id);
        }

        public List<Person> FindAll()
        {
            return _personRepository.FindAll();
        }

        public Person Update(Person person)
        {
            return _personRepository.Update(person);
        }

        public void Delete(long id)
        {
            _personRepository.Delete(id);
        }

    }
}

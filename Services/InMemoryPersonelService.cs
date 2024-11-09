using Microsoft.AspNetCore.Mvc;
using MvcMastery.Models;

namespace MvcMastery.Services
{
    public class InMemoryPersonelService
    {
        private readonly List<Personel> _personel;

        public InMemoryPersonelService()
        {
            _personel = new List<Personel>
            {
             new Personel { PersonelId = 1, Name = "John", Surname = "Doe", Email = "john.doe@example.com", Phone = "123-456-7890", Address = "123 Main St", DateOfBirth = new DateTime(1990, 1, 1), NationalId = "11111111111" },
            new Personel { PersonelId = 2, Name = "Jane", Surname = "Smith", Email = "jane.smith@example.com", Phone = "098-765-4321", Address = "456 Elm St", DateOfBirth = new DateTime(1992, 2, 2), NationalId = "22222222222" }
            };
        }

        public List<Personel> GetAll() => _personel;

        public Personel? GetById(int personelId) => _personel.Find(p => p.PersonelId == personelId);

        public void CreatePersonel(Personel personel)
        {
            personel.PersonelId = _personel.Count + 1;
            _personel.Add(personel);
        }

        public void UpdatePersonel(Personel personel)
        {
            var existingPersonel = GetById(personel.PersonelId);

            if (existingPersonel != null)
            {
                existingPersonel.Name = personel.Name;
                existingPersonel.Surname = personel.Surname;
                existingPersonel.Email = personel.Email;
                existingPersonel.Phone = personel.Phone;
                existingPersonel.Address = personel.Address;
                existingPersonel.DateOfBirth = personel.DateOfBirth;
                existingPersonel.NationalId = personel.NationalId;
            }
        }

        public void DeletePersonel(int personelId)
        {
            var personel = GetById(personelId);

            if (personel != null)
            {
                _personel.Remove(personel);
            }
        }
    }
}
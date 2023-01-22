using APBD_ZAO_CW4.Model;
using System.Collections.Generic;

namespace APBD_ZAO_CW4.DAL
{
    public interface IDbService
    {
        public bool CheckAnimalById(int idAnimal);
        List<Animal> GetAnimals(string orderBy);
        void CreateAnimal(Animal animal);
        void ChangeAnimal(int idAnimal, Animal animal);
        void DeleteAnimal(int idAnimal);
    }
}

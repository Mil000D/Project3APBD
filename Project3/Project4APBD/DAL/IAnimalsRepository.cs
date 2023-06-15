using Zadanie4.DTOs;
using Zadanie4.Enums;

namespace Zadanie4.DAL
{
    public interface IAnimalsRepository
    {
        public EnumToReturn SelectAnimals(List<AnimalDTO> animals, string orderBy);
        public EnumToReturn InsertAnimal(AnimalDTO animal);
        public EnumToReturn UpdateAnimal(AnimalDTO animal, int idAnimal);
        public EnumToReturn DeleteAnimal(int idAnimal);
    }
}

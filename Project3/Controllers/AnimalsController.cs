using Microsoft.AspNetCore.Mvc;
using Zadanie4.DAL;
using Zadanie4.DTOs;
using Zadanie4.Enums;

namespace Zadanie4.Controllers
{
    [Route("api/animals")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private readonly IAnimalsRepository animalsRepository;
        public AnimalsController(IAnimalsRepository animalsRepository)
        {
            this.animalsRepository = animalsRepository;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] string orderBy = "Name")
        {
            List<AnimalDTO> animals = new List<AnimalDTO>();
            EnumToReturn enumToReturn = animalsRepository.SelectAnimals(animals, orderBy);
            switch (enumToReturn)
            {
                case EnumToReturn.SQL_DATA_OPERATION_SUCCESSFUL:
                    return Ok(animals);
                case EnumToReturn.SQL_DATA_OPERATION_FAILURE:
                    return NotFound($"Invalid column specified: {orderBy}");
                case EnumToReturn.SQL_COULD_NOT_CONNECT:
                    return BadRequest("Could not connect to database");
                case EnumToReturn.SQL_ERROR:
                    return BadRequest("Error");
                default:
                    return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Post(AnimalCreateDTO animalCreateDTO)
        {
            var animal = new AnimalDTO
            {
                Name = animalCreateDTO.Name,
                Description = animalCreateDTO.Description,
                Category = animalCreateDTO.Category,
                Area = animalCreateDTO.Area
            };
            EnumToReturn enumToReturn = animalsRepository.InsertAnimal(animal);
            switch (enumToReturn)
            {
                case EnumToReturn.SQL_DATA_OPERATION_SUCCESSFUL:
                    return Ok("Insertion completed");
                case EnumToReturn.SQL_DATA_OPERATION_FAILURE:
                    return BadRequest("Couldn't insert data");
                case EnumToReturn.SQL_COULD_NOT_CONNECT:
                    return BadRequest("Could not connect to database");
                case EnumToReturn.SQL_ERROR:
                    return BadRequest("Error");
                default:
                    return BadRequest();
            }
        }
        [HttpPut("{idAnimal}")]
        public IActionResult Put(int idAnimal, AnimalCreateDTO animalCreateDTO)
        {
            var animal = new AnimalDTO
            {
                Name = animalCreateDTO.Name,
                Description = animalCreateDTO.Description,
                Category = animalCreateDTO.Category,
                Area = animalCreateDTO.Area
            };
            EnumToReturn enumToReturn = animalsRepository.UpdateAnimal(animal, idAnimal);
            switch (enumToReturn)
            {
                case EnumToReturn.SQL_DATA_OPERATION_SUCCESSFUL:
                    return Ok("Updating animal successful");
                case EnumToReturn.SQL_DATA_OPERATION_FAILURE:
                    return NotFound($"Invalid ID of Animal specified: {idAnimal}");
                case EnumToReturn.SQL_COULD_NOT_CONNECT:
                    return BadRequest("Could not connect to database");
                case EnumToReturn.SQL_ERROR:
                    return BadRequest("Error");
                default:
                    return BadRequest();
            }
        }
        [HttpDelete("{idAnimal}")]
        public IActionResult Delete(int idAnimal)
        {
            EnumToReturn enumToReturn = animalsRepository.DeleteAnimal(idAnimal);
            switch (enumToReturn)
            {
                case EnumToReturn.SQL_DATA_OPERATION_SUCCESSFUL:
                    return Ok($"Deleting animal with ID: {idAnimal} succesful");
                case EnumToReturn.SQL_DATA_OPERATION_FAILURE:
                    return NotFound($"Invalid ID of Animal specified: {idAnimal}");
                case EnumToReturn.SQL_COULD_NOT_CONNECT:
                    return BadRequest("Could not connect to database");
                case EnumToReturn.SQL_ERROR:
                    return BadRequest("Error");
                default:
                    return BadRequest();
            }
        }
    }
}

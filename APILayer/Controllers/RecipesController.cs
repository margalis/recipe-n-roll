using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess;
using DataAccess.Entities;
using AutoMapper;
using APILayer.Models;

namespace APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly IRecipesAndIngrRepository recipeAndIngrRepository;

        private readonly IMapper mapper;
        public RecipesController(IMapper mapper ,IRecipesAndIngrRepository recipeAndIngrRepository)
        {
            this.mapper = mapper;
            this.recipeAndIngrRepository=recipeAndIngrRepository;
        }
       

        [HttpGet("{ID}")]
        public RecipesDTO GetRecipe(int ID)
        {
           return mapper.Map<RecipesDTO>(recipeAndIngrRepository.GetRecipeInfo(ID));     
        }

        //??????????  vonnccc  T_T
        [HttpGet("")]
        public List<IDNameDTO> GetRecipeNamesSimilarTo(string name)
        {
            return mapper.Map<List<IDNameDTO>>(recipeAndIngrRepository.GetRecipeNamesSimilarTo(name));
        }
        [HttpGet]
        public List<IDNameDTO> GetRecipeNamesnIDviaIngredients([FromQuery]List<String> ingredientNames)
        {
            return mapper.Map<List<IDNameDTO>>
                (recipeAndIngrRepository.GetRecipeNamesnIDviaIngredients(ingredientNames));
        }
    }
}

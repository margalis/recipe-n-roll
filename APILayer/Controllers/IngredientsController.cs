using APILayer.Models;
using AutoMapper;
using DataAccess;
using DataAccess.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientsController : ControllerBase
    {
        private readonly IRecipesAndIngrRepository recipeAndIngrRepository;
        private readonly IMapper mapper;
        public IngredientsController(IMapper mapper,IRecipesAndIngrRepository recipeAndIngrRepository)
        {
            this.recipeAndIngrRepository = recipeAndIngrRepository;
        }
      
       [HttpGet]
       public IEnumerable<IngredientsDTO> GetIngredients()
       {
            return mapper.Map<IEnumerable<IngredientsDTO>>(recipeAndIngrRepository.GetIngredients());
       }               
    }

    

}

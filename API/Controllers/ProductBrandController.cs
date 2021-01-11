using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace API.Controllers
{
    public class ProductBrandController : BaseApiController
    {
        public static List<ProductBrand> productBrands = new List<ProductBrand>(){
            new ProductBrand(){ Id =1, Name = "Nokia"},
            new ProductBrand(){ Id=2, Name = "Samsung"}
        };

        [HttpGet]
        public ActionResult Get()
        {            
            return Ok(productBrands);
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var pBrand = productBrands.FirstOrDefault(x => x.Id == id);            
            return Ok(pBrand);
        }

        [HttpPost]
        public ActionResult Post([FromBody] ProductBrand brand)
        {
            if(brand == null)
            return BadRequest();
            
            productBrands.Add(brand);
            return Ok();
        }

        [HttpPut]
        public ActionResult Put(int id, [FromBody] ProductBrand brand)
        {
            productBrands.Add(brand);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var pBrand = productBrands.FirstOrDefault(x => x.Id == id);
            productBrands.Remove(pBrand);
            return Ok();
        }
    }
}
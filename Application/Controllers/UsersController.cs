using DomainLib.Entitys;
using DomainLib.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private IUserService _service;

        public UsersController(IUserService service)
        {
            _service = service;
        }

        //LISTAGEM

        [HttpGet]
        public async Task<ActionResult> GetAll([FromServices] IUserService service)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); //400 bad request - solicitação invalida
            }

            try
            {
                return Ok(await service.GetAll());
            }
            catch (ArgumentException e)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }

        }





        //LISTAGEM POR ID

        [HttpGet]
        [Route("{id}", Name = "GetWithId")]
        public async Task <ActionResult> Get(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); //400 bad request - solicitação invalida
            }

            try
            {
                return Ok(await _service.Get(id));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
           

        }


        //INSERT
        [HttpPost]
        public async Task<ActionResult> Post ([FromBody] UserEntity User)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); //400 bad request - solicitação invalida
            }

            try
            {
                var result = await _service.Post(User);
                if(result != null)
                {
                    return Created(new Uri(Url.Link("GetWithId", new { id = result.id })), result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (ArgumentException e)
            {

                return StatusCode((int) HttpStatusCode.InternalServerError, e.Message);
            }
        }



        //UPDATE

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UserEntity User)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); //400 bad request - solicitação invalida
            }

            try
            {
                var result = await _service.Put(User);
                if(result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (ArgumentException e)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }


        //DELETE
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); //400 bad request - solicitação invalida
            }

            try
            {
                return Ok(await _service.Delete(id));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }

        }



    }
}

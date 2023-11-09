using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SL.Controllers
{
    [Route("api/emisor")]
    [ApiController]
    public class EmisorController : ControllerBase
    {

        [Route("Add")]
        [HttpPost]

        public IActionResult Add(ML.Emisor emisor)
        {
            ML.Result result = BL.Emisor.Add(emisor);

            if (result.Correct)
            {
                return StatusCode(200, result);
            }
            else
            {
                return StatusCode(400, result);
            }
        }

        [Route("GetAll")]
        [HttpGet]
        public IActionResult GetAll()
        {
            ML.Result result = BL.Emisor.GetAll();

            if (result.Correct)
            {
                return StatusCode(200, result);
            }
            else
            {
                return StatusCode(400, result);
            }
        }

        [Route("GetById/{IdEmisor}")]
        [HttpGet]
        public IActionResult GetById(string IdEmisor)
        {
            ML.Result result = BL.Emisor.GetById(IdEmisor);

            if (result.Correct)
            {
                return StatusCode(200, result);
            }
            else
            {
                return StatusCode(400, result);
            }


        }


    }
}

using ModelValidatorDemo.API.Components;
using ModelValidatorDemo.API.Models;
using System.Threading.Tasks;
using System.Web.Http;

namespace ModelValidatorDemo.API.Controllers
{
    [RoutePrefix("api/v1")]
    public class OrderController : ApiController
    {
        [HttpPost]
        [Route("orders")]
        public async Task<IHttpActionResult> PostAsync([FromBody]Order order)
        {
            if (order == null)
                return BadRequest("Unusable resource");

            var modelValidator = new ModelValidator<Order>(order);

            if (!modelValidator.IsModelValid())
            {
                //DEBUG to see list of errors
                var errors = modelValidator.ModelErrors();

                return BadRequest("Unusable resource");
            }

            return Ok();
        }
    }
}
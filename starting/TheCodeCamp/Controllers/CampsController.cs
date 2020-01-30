using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using TheCodeCamp.Data;

namespace TheCodeCamp.Controllers
{
    public class CampsController : ApiController
    {
        private readonly ICampRepository _repository; // field that holds repository data
        public CampsController(ICampRepository repository) // constructor instantiates a field from ICampRepo
        {
            _repository = repository;
        }
        public async Task<IHttpActionResult> Get()
        {
            try
            {
                var result = await _repository.GetAllCampsAsync();

                return Ok(result);
            }
            catch (Exception ex)
            {
                //TODO add logging
                return InternalServerError(ex);
            }
        }
    }
}

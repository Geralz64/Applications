using Repository.TestData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/membership")]
    public class MembershipController : ApiController
    {

        [Route()]
        public async Task<IHttpActionResult> Get()
        {

            try
            {
                var result = await MembershipTestData.TestDataAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                InternalServerError(ex);
            }

            return null;

        }

        [Route("{memberID}")]
        public async Task<IHttpActionResult> Get(string memberID)
        {

            try
            {
                var result = await MembershipTestData.TestDataAsync(memberID);
                return Ok(result);
            }
            catch (Exception ex)
            {
                InternalServerError(ex);
            }

            return null;
        }


    }
}
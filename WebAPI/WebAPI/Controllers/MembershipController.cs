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

                var result = await Models.Membership.GetMembership();

                return Ok(result);
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);

            }

        }

        [Route("{memberID}")]
        public async Task<IHttpActionResult> Get(string memberID)
        {

            try
            {
                var result = await Models.Membership.GetMember(memberID);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);

            }
        }


        [Route("{memberID}")]
        public async Task<IHttpActionResult> Put(string memberID)
        {

            try
            {

                var result = await Models.Membership.UpdateMember(memberID);

                return Ok(result);

            }
            catch (Exception ex)
            {

                return InternalServerError(ex);

            }

        }


        [Route("{memberID}")]
        public async Task<IHttpActionResult> Post(string memberID)
        {
            try
            {

                var result = await Models.Membership.InsertMember(memberID);

                return Ok(result);

            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }



        [Route("{memberID}")]
        public async Task<IHttpActionResult> Delete(string memberID)
        {
            try
            {

                var result = await Models.Membership.DeleteMember(memberID);

                return Ok(result);

            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }



    }
}
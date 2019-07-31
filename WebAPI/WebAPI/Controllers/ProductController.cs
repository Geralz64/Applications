using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace WebAPI.Controllers
{

    [RoutePrefix("api/product")]
    public class ProductController : ApiController
    {

        [Route()]
        public async Task<IHttpActionResult> Get()
        {

            try
            {

                var result = await Models.Product.GetProducts();

                return Ok(result);

            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }


        }

        [Route("{productID}")]
        public async Task<IHttpActionResult> Get(string productID)
        {

            try
            {

                var results = await Models.Product.GetProduct(productID);

                return Ok(results);


            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }

        }


        //PUT
        [Route("{productID}")]
        public async Task<IHttpActionResult> Put(string productID)
        {
            try
            {
                var results = await Models.Product.UpdateProduct(productID);

                return Ok(results);

            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }



        }

        //POST
        [Route("{productID}")]
        public async Task<IHttpActionResult> Post()
        {

            try
            {

                var result = await Models.Product.InsertProduct();

                return Ok(result);


            }
            catch (Exception ex)
            {

                return InternalServerError(ex);

            }

        }

        //DELETE
        [Route("{productID}")]
        public async Task<IHttpActionResult> Delete(string productID)
        {

            try
            {

                var result = await Models.Product.DeleteProduct(productID);

                return Ok(result);


            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }


        }




    }
}
using MediatR;
using MerchantAPI.Application.Features.Merchant.Create;
using MerchantAPI.Application.Features.Merchant.Delete;
using MerchantAPI.Application.Features.Merchant.Get;
using MerchantAPI.Application.Features.Merchant.GetAll;
using MerchantAPI.Application.Features.Merchant.Update;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MerchantAPI.WebAPIServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MerchantsController(ISender sender) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetMerchants()
        {
            var results = await sender.Send(new GetAllMerchantQuery());
            bool isSuccess = results.isSuccess;
            if (isSuccess)
                return results.Data.Any() ? Ok(results) : NotFound(results);
            else
                return BadRequest();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMerchantById(int id)
        {
            var results = await sender.Send(new GetMerchantQuery(id));
            bool isSuccess = results.isSuccess;

            return isSuccess ? Ok(results) : NotFound(results);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMerchant([FromBody] CreateMerchant merchantDto)
        {
            var results = await sender.Send(new CreateMerchantCommand(merchantDto));
            bool isSuccess = results.isSuccess;
            return isSuccess ? CreatedAtAction(nameof(GetMerchantById), new {id=results.Data.Id} , results) : BadRequest(results);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMerchant(int id , UpdateMerchant updateMerchantDto)
        {
            var results = await sender.Send(new UpdateMerchantCommand(id , updateMerchantDto));
            bool isSuccess = results.isSuccess;
            return isSuccess ? NoContent() : BadRequest(results);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMerchant(int id)
        {
            var results = await sender.Send(new DeleteMerchantCommand(new DeleteMerchant(id)));
            bool isSuccess = results.isSuccess;
            return isSuccess ? NoContent() : NotFound(results);
        }
    }

}

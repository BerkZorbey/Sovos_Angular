using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Newtonsoft.Json;
using SovosCase.Models;
using SovosCase.Services.Abstract;
using System.Text.Json.Nodes;

namespace Sovos_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;

        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllInvoices()
        {
            var response = await _invoiceService.GetAllInvoice();
            if (response.Success == true)
            {
                return Ok(response.Model.ToJson());
            }
            else
            {
                return BadRequest(new { error = response.Exception });
            }
        } 


        [HttpPost]
        public async Task<IActionResult> InsertInvoice([FromBody] string invoice)
        {
            var response = await _invoiceService.InsertInvoice(invoice);
            if (response.Success == true)
            {
                return Ok(response.Model.ToJson());
            }
            else
            {
                return BadRequest(new { error = response.Exception });
            }

        }

    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using Newtonsoft.Json;
using Serilog;
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
                Log.Information("Get Invoices succesfully");
                return Ok(response.Model.ToJson());
            }
            else
            {
                if (response.Exception == null)
                {
                    Log.Error(response.Message);
                    return BadRequest(new { error = response.Message });
                }
                else
                {
                    Log.Error(response.Exception.Message);
                    return BadRequest(new { error = response.Exception.Message });
                }
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetInvoiceById(string id)
        {
            var response = await _invoiceService.GetInvoiceById(id);
            if (response.Success == true)
            {
                Log.Information("Get Invoice " + id + " succesfully");
                return Ok(response.Model.ToJson());
            }
            else
            {
                if (response.Exception == null)
                {
                    Log.Error(response.Message);
                    return BadRequest(new { error = response.Message });
                }
                else
                {
                    Log.Error(response.Exception.Message);
                    return BadRequest(new { error = response.Exception.Message });
                }
            }
        }

        [HttpPost]
        public async Task<IActionResult> InsertInvoice([FromBody] string invoice)
        {
            var response = await _invoiceService.InsertInvoice(invoice);
            if (response.Success == true)
            {
                Log.Information("Invoice added succesfully");
                return Ok(response.Model.ToJson());
            }
            else
            {
                if(response.Exception == null)
                {
                    Log.Error(response.Message);
                    return BadRequest(new { error = response.Message });
                }
                else
                {
                    Log.Error(response.Exception.Message);
                    return BadRequest(new { error = response.Exception.Message });
                }
            }

        }

    }
}

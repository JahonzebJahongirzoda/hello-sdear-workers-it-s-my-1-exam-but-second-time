using Microsoft.AspNetCore.Mvc;
using Infrastructure.Services;
using Domain.Entities;

namespace Webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class QuoteController : ControllerBase
{
    private readonly QuoteServices _service;

    public QuoteController()
    {
        _service = new QuoteServices();
    }


    [HttpGet("GetQuote")]
    public async Task<List<Quote>> Get()

    {
        return await _service.GetQuote();
    }


    [HttpGet("GetRand")]
    public async Task<List<Quote>> Getbyrand()

    {
        return await _service.Getbyrand();
    }









    [HttpPut("UpdateQuote")]
    public async Task<int> Put(Quote quote)

    {
        return await _service.UpdateQuote(quote);
    }










    [HttpDelete("DeleteQuote")]
    public async Task<int> Delete(int id)

    {
        return await _service.DeleteQuote(id);
    }





    [HttpGet("Getbyid")]
    public async Task<List<Quote>> Getbyid(int id)

    {
        return await _service.Getbyid(id);
    }









}

using Microsoft.AspNetCore.Mvc;
using RealEstateApp.Shared.Models;
using Shared.Services;

namespace Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ListingsController : ControllerBase
{
    private readonly IListingService _listingService; // reference to service

    public ListingsController(IListingService listingService) // constructs reference
    {
        _listingService = listingService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Listing>>> GetAll()
    {
        var listings = await _listingService.GetListingsAsync(); // get all listings from service
        return Ok(listings);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Listing>> GetById(int id)
    {
        var listing = await _listingService.GetListingsByIdAsync(id); // get the listing by id
        if (listing == null) return NotFound();
        return Ok(listing);
    }

    [HttpPost]
    public async Task<ActionResult<Listing>> Add([FromBody] ListingDTO listingDTO) // deserialize the incoming json request body into listingdto
    {
        if (listingDTO == null) return BadRequest();

        var listing = await _listingService.AddListingAsync(listingDTO); // add the listing asynchronuosly 
        return CreatedAtAction(nameof(GetById), new { id = listing.Id }, listing); // new listing is created, id 
    }
}
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebRest.EF.Data;
using WebRest.EF.Models;

namespace WebRestAPI.Controllers.UD;

[ApiController]
[Route("api/[controller]")]
public class AddressController : ControllerBase, iController<Address>
{
    private WebRestOracleContext _context;
    // Create a field to store the mapper object
    private readonly IMapper _mapper;

    public CustomerController(WebRestOracleContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    [Route("Get")]
    public async Task<IActionResult> Get()
    {

        List<Customer> lst = null;
        lst = await _context.Address.ToListAsync();
        return Ok(lst);
    }


    [HttpGet]
    [Route("Get/{ID}")]
    public async Task<IActionResult> Get(string ID)
    {
        var itm = await _context.Address.Where(x => x.AddressId == ID).FirstOrDefaultAsync();
        return Ok(itm);
    }


    [HttpDelete]
    [Route("Delete/{ID}")]
    public async Task<IActionResult> Delete(string ID)
    {
        var itm = await _context.Address.Where(x => x.AddressId == ID).FirstOrDefaultAsync();
        _context.Address.Remove(itm);
        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromBody] Address _Address)
    {
        var trans = _context.Database.BeginTransaction();

        try
        {
            var itm = await _context.Address.AsNoTracking()
            .Where(x => x.AddressId == _Address.AddressId)
            .FirstOrDefaultAsync();


            if (itm != null)
            {
                itm = _mapper.Map<Address>(_Address);

                 
                        itm.AddressFirstLine = _Address.AddressFirstLine;
                        itm.AddressSecondLine = _Address.AddressSecondLine;
                        itm.AddressThirdLine = _Address.AddressThirdLine;
                        itm.AddressCity = _Address.AddressCity;
                        itm.AddressState = _Address.AddressState;
                        itm.AddressZip = _Address.AddressZip;
                       
                _context.Address.Update(itm);
                await _context.SaveChangesAsync();
                trans.Commit();

            }
        }
        catch (Exception ex)
        {
            trans.Rollback();
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }

        return Ok();

    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Address _Address)
    {
        var trans = _context.Database.BeginTransaction();

        try
        {
            _Address.AddressId = Guid.NewGuid().ToString().ToUpper().Replace("-", "");
            _context.Address.Add(_Address);
            await _context.SaveChangesAsync();
            trans.Commit();
        }
        catch (Exception ex)
        {
            trans.Rollback();
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }

        return Ok();
    }

}
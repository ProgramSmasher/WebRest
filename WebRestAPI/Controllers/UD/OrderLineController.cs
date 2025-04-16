using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebRest.EF.Data;
using WebRest.EF.Models;

namespace WebRestAPI.Controllers.UD;

[ApiController]
[Route("api/[controller]")]
public class OrderLineController : ControllerBase, iController<OrderLine>
{
    private WebRestOracleContext _context;
    // Create a field to store the mapper object
    private readonly IMapper _mapper;

    public OrderStatusController(WebRestOracleContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    [Route("Get")]
    public async Task<IActionResult> Get()
    {

        List<OrderState> lst = null;
        lst = await _context.OrderLine.ToListAsync();
        return Ok(lst);
    }


    [HttpGet]
    [Route("Get/{ID}")]
    public async Task<IActionResult> Get(string ID)
    {
        var itm = await _context.OrderLine.Where(x => x.OrderLineId == ID).FirstOrDefaultAsync();
        return Ok(itm);
    }


    [HttpDelete]
    [Route("Delete/{ID}")]
    public async Task<IActionResult> Delete(string ID)
    {
        var itm = await _context.OrderLine.Where(x => x.OrderLineId == ID).FirstOrDefaultAsync();
        _context.OrderLine.Remove(itm);
        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromBody] OrderLine _OrderLine)
    {
        var trans = _context.Database.BeginTransaction();

        try
        {
            var itm = await _context.OrderLine.AsNoTracking()
            .Where(x => x.OrderLineId == _OrderLine.OrderLineId)
            .FirstOrDefaultAsync();


            if (itm != null)
            {
                itm = _mapper.Map<OrderLine>(_OrderLine);

                 
                        itm.OrderLineOrdersId = _OrderLine.OrderLineOrdersId;
                        itm.OrderLineProductId = _OrderLine.OrderLineProductId;
                        itm.OrderLineQty = _OrderLine.OrderLineQty;
                        itm.OrderLinePrice = _OrderLine.OrderLinePrice;
                        
                        
                       
                _context.OrderLine.Update(itm);
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
    public async Task<IActionResult> Post([FromBody] OrderLine _OrderLine)
    {
        var trans = _context.Database.BeginTransaction();

        try
        {
            _Order.OrderId = Guid.NewGuid().ToString().ToUpper().Replace("-", "");
            _context.Order.Add(_Order);
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
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shipment_service.Data;
using shipment_service.Models;

namespace shipment_service.Controllers {

    [ApiController]
    [Route("api/[controller]")]
    public class ShipmentsController : ControllerBase {
        private readonly AppDbContext _context;

        public ShipmentsController( AppDbContext context ) {
            _context = context;
        }

        // GET: api/shipments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Shipment>>> GetShipments() {
            return await _context.Shipments.ToListAsync();
        }

        // GET: api/shipments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Shipment>> GetShipment( int id ) {
            var shipment = await _context.Shipments.FindAsync(id);

            if (shipment == null)
                return NotFound();

            return shipment;
        }

        // POST: api/shipments
        [HttpPost]
        public async Task<ActionResult<Shipment>> CreateShipment( Shipment shipment ) {
            _context.Shipments.Add(shipment);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetShipment), new {
                id = shipment.Id
            }, shipment);
        }

        // PUT: api/shipments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateShipment( int id, Shipment updated ) {
            if (id != updated.Id)
                return BadRequest();

            var shipment = await _context.Shipments.FindAsync(id);
            if (shipment == null)
                return NotFound();

            shipment.Status = updated.Status;
            shipment.StartLocation = updated.StartLocation;
            shipment.EndLocation = updated.EndLocation;
            shipment.AssignedVehicleId = updated.AssignedVehicleId;
            shipment.ClientId = updated.ClientId;
            shipment.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/shipments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShipment( int id ) {
            var shipment = await _context.Shipments.FindAsync(id);
            if (shipment == null)
                return NotFound();

            _context.Shipments.Remove(shipment);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

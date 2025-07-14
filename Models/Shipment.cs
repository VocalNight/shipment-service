namespace shipment_service.Models {

    public enum ShipmentStatus {
        Pending,
        InTransit,
        Delayed,
        Delivered
    }

    public class Shipment {
        public int Id { get; set; }
        public string StartLocation { get; set; } = string.Empty;
        public string EndLocation { get; set; } = string.Empty;
        public ShipmentStatus Status { get; set; } = ShipmentStatus.Pending;
        public int? ClientId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }
}

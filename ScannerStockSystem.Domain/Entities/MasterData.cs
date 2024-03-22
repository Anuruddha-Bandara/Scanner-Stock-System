using ScannerStockSystem.Domain.Common;

namespace ScannerStockSystem.Domain.Entities
{
    public class MasterData: BaseAuditableEntity
    {       
        public string? SanjePoNo { get; set; }
        public string? ManufactureInvoiceNo { get; set; }
        public string? ManufactureSalesOrderNo { get; set; }
        public DateTime? ShipmentReceivedDate { get; set; }
        public decimal? UnitPrice { get; set; }
        public string? EndCustomerPoNo { get; set; }
        public DateTime? DispatchDate { get; set; }
        public string? DeliveryNoteNo { get; set; }
        public bool? Dispatched { get; set; }

        // Navigation property
        public Customer Customer { get; set;}
        //public int CustomerID { get; set; }   
        public Scanner Scanner { get; set;}
        //public int ScannerID { get; set;}
    }
}

using System.ComponentModel;
using System.Text;

namespace Gs1Parser
{
    //Company internal standard, change it to your liking
    public static class EGS1AI
    {
        // TODO: add more if used and replace the string in the definition
        [Description("00 - SSCC")]
        public static readonly string SSCC = "00";

        [Description("01 - GTIN")]
        public static readonly string GTIN = "01";

        [Description("10 - Batch or lot number")]
        public static readonly string Batch = "10";

        [Description("11 - Production date (YYMMDD)")]
        public static readonly string ProductionDate = "11";

        [Description("15 - MHD (Best Before Date) (YYMMDD)")]
        public static readonly string BestBeforeDate = "15";

        [Description("17 - Expiration date (YYMMDD)")]
        public static readonly string ExpirationDate = "17";

        [Description("21 - Serial Number")]
        public static readonly string SerialNumber = "21";

        [Description("241 - Customer Part Number (Article Number)")]
        public static readonly string CustomerPartNumber = "241";

        [Description("30 - Variable count of items")]
        public static readonly string Count = "30";

        [Description("310d - Net Weight (Kg)")]
        public static readonly string NetWeightKg = "310d";

        [Description("311d - Length (m)")]
        public static readonly string LengthM = "311d";

        [Description("37 - Count of trade items or trade item pieces contained in a logistic unit")]
        public static readonly string CountLogisticUnit = "37";

        [Description("400 - Order Number")]
        public static readonly string OrderNumber = "400";

        [Description("7007 - Harvest date (YYMMDD)")]
        public static readonly string HarvestDate = "7007";
    }
}

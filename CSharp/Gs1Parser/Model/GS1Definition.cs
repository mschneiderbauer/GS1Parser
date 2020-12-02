using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gs1Parser
{
    public class GS1Definition
    {
        public readonly char GROUP_SEPARATOR = (char)29; // FNC1 or <GS>
        public readonly char GROUP_SEPARATOR_ALTERNATIVE = (char)64; // @
        public readonly string PLACEHOLDER = "d";
        public readonly string DATE_FORMAT = "yyMMdd";
        public readonly string[] START_CODES = new string[] { "]C1", "]e0", "]d2", "]Q3", "]J1" };

        public SortedDictionary<string, AI> AIDict { get; }
        public int MinLengthOfAI { get; } = 2;
        public int MaxLengthOfAI { get; } = 4;

        public GS1Definition()
        {
            AIDict = new SortedDictionary<string, AI>();

            Add(EGS1AI.SSCC, "SSCC_SerialShippingContainerCode", DataType.NumericText, 18, false);
            Add(EGS1AI.GTIN, "GTIN", DataType.NumericText, 14, false);
            Add("02", "GTIN_OfContainedTradeItems", DataType.NumericText, 14, false);
            Add(EGS1AI.Batch, "Batch", DataType.Alphanumeric, 20, true);
            Add(EGS1AI.ProductionDate, "ProductionDate_YYMMDD", DataType.Date, 6, false);
            Add("12", "DueDate_YYMMDD", DataType.Date, 6, false);
            Add("13", "PackingDate_YYMMDD", DataType.Date, 6, false);
            Add(EGS1AI.BestBeforeDate, "MHD_BestBeforeDate_YYMMDD", DataType.Date, 6, false);
            Add("16", "SellByDate_YYMMDD", DataType.Date, 6, false);
            Add(EGS1AI.ExpirationDate, "ExpirationDate_YYMMDD", DataType.Date, 6, false);
            Add("20", "InternalProductVariant", DataType.Numeric, 2, false);
            Add(EGS1AI.SerialNumber, "SerialNumber", DataType.Alphanumeric, 20, true);
            Add("22", "ConsumerProductVariant", DataType.Alphanumeric, 29, false);
            Add("235", "TPX_GTIN)", DataType.Alphanumeric, 28, true);
            Add("240", "ProductIdentificationOfProducer", DataType.Alphanumeric, 30, true);
            Add(EGS1AI.CustomerPartNumber, "CustomerPartNumber", DataType.Alphanumeric, 30, true);
            Add("250", "SecondarySerialNumber", DataType.Alphanumeric, 30, true);
            Add("251", "ReferenceToSourceEntity", DataType.Alphanumeric, 30, true);
            Add(EGS1AI.Count, "VariableCountOfItems", DataType.Numeric, 8, true);
            Add(EGS1AI.NetWeightKg, "NetWeight_Kilograms", DataType.Numeric, 6, false);
            Add(EGS1AI.LengthM, "Length_Meter", DataType.Numeric, 6, false);
            Add("312d", "Width_Meter", DataType.Numeric, 6, false);
            Add("313d", "Heigth_Meter", DataType.Numeric, 6, false);
            Add("314d", "Surface_SquareMeter", DataType.Numeric, 6, false);
            Add("315d", "NetVolume_Liters", DataType.Numeric, 6, false);
            Add("316d", "NetVolume_CubicMeters", DataType.Numeric, 6, false);
            Add("320d", "NetWeight_Pounds", DataType.Numeric, 6, false);
            Add("321d", "Length_Inches", DataType.Numeric, 6, false);
            Add("322d", "Length_Feet", DataType.Numeric, 6, false);
            Add("323d", "Length_Yards", DataType.Numeric, 6, false);
            Add("324d", "Width_Inches", DataType.Numeric, 6, false);
            Add("325d", "Width_Feed", DataType.Numeric, 6, false);
            Add("326d", "Width_Yards", DataType.Numeric, 6, false);
            Add("327d", "Heigth_Inches", DataType.Numeric, 6, false);
            Add("328d", "Heigth_Feed", DataType.Numeric, 6, false);
            Add("329d", "Heigth_Yards", DataType.Numeric, 6, false);
            Add("330d", "GrossWeight_Kilogram", DataType.Numeric, 6, false);
            Add("331d", "Length_Meter", DataType.Numeric, 6, false);
            Add("332d", "Width_Meter", DataType.Numeric, 6, false);
            Add("333d", "Heigth_Meter", DataType.Numeric, 6, false);
            Add("334d", "Surface_SquareMeter", DataType.Numeric, 6, false);
            Add("335d", "GrossVolume_Liters", DataType.Numeric, 6, false);
            Add("336d", "GrossVolume_CubicMeters", DataType.Numeric, 6, false);
            Add("337d", "KilogramPerSquareMeter", DataType.Numeric, 6, false);
            Add("340d", "GrossWeight_Pounds", DataType.Numeric, 6, false);
            Add("341d", "Length_Inches", DataType.Numeric, 6, false);
            Add("342d", "Length_Feet", DataType.Numeric, 6, false);
            Add("343d", "Length_Yards", DataType.Numeric, 6, false);
            Add("344d", "Width_Inches", DataType.Numeric, 6, false);
            Add("345d", "Width_Feed", DataType.Numeric, 6, false);
            Add("346d", "Width_Yards", DataType.Numeric, 6, false);
            Add("347d", "Heigth_Inches", DataType.Numeric, 6, false);
            Add("348d", "Heigth_Feed", DataType.Numeric, 6, false);
            Add("349d", "Heigth_Yards", DataType.Numeric, 6, false);
            Add("350d", "Surface_SquareInches", DataType.Numeric, 6, false);
            Add("351d", "Surface_SquareFeet", DataType.Numeric, 6, false);
            Add("352d", "Surface_SquareYards", DataType.Numeric, 6, false);
            Add("353d", "Surface_SquareInches", DataType.Numeric, 6, false);
            Add("354d", "Surface_SquareFeed", DataType.Numeric, 6, false);
            Add("355d", "Surface_SquareYards", DataType.Numeric, 6, false);
            Add("356d", "NetWeight_TroyOunces", DataType.Numeric, 6, false);
            Add("357d", "NetVolume_Ounces", DataType.Numeric, 6, false);
            Add("360d", "NetVolume_Quarts", DataType.Numeric, 6, false);
            Add("361d", "NetVolume_Gallons", DataType.Numeric, 6, false);
            Add("362d", "GrossVolume_Quarts", DataType.Numeric, 6, false);
            Add("363d", "GrossVolume_Gallons", DataType.Numeric, 6, false);
            Add("364d", "NetVolume_CubicInches", DataType.Numeric, 6, false);
            Add("365d", "NetVolume_CubicFeet", DataType.Numeric, 6, false);
            Add("366d", "NetVolume_CubicYards", DataType.Numeric, 6, false);
            Add("367d", "GrossVolume_CubicInches", DataType.Numeric, 6, false);
            Add("368d", "GrossVolume_CubicFeet", DataType.Numeric, 6, false);
            Add("369d", "GrossVolume_CubicYards", DataType.Numeric, 6, false);
            Add(EGS1AI.CountLogisticUnit, "CountOfTradeItemsInLogisticUnit", DataType.Numeric, 8, true);
            //special fields
            Add("390d", "AmountDue_DefinedValutaBand", DataType.NumericText, 15, true);
            Add("391d", "AmountDue_WithISOValutaCode", DataType.NumericText, 18, true);
            Add("392d", "BePayingAmount_DefinedValutaBand", DataType.NumericText, 15, true);
            Add("393d", "BePayingAmount_WithISOValutaCode", DataType.NumericText, 18, true);
            //
            Add(EGS1AI.OrderNumber, "CustomerPurchaseOrderNumber", DataType.Alphanumeric, 30, true);
            Add("401", "GINC_GlobalIdentificationNumberFroConsignment", DataType.Alphanumeric, 30, true);
            Add("402", "GSIN_GlobalShipmentIdentificationNumber", DataType.NumericText, 17, true);
            Add("403", "RoutingCode", DataType.Alphanumeric, 30, true);
            Add("410", "EAN_UCC_GlobalLocationNumber(GLN)_GoodsRecipient", DataType.NumericText, 13, false);
            Add("411", "EAN_UCC_GlobalLocationNumber(GLN)_InvoiceRecipient", DataType.NumericText, 13, false);
            Add("412", "EAN_UCC_GlobalLocationNumber(GLN)_Distributor", DataType.NumericText, 13, false);
            Add("413", "EAN_UCC_GlobalLocationNumber(GLN)_FinalRecipient", DataType.NumericText, 13, false);
            Add("414", "EAN_UCC_GlobalLocationNumber(GLN)_PhysicalLocation", DataType.NumericText, 13, false);
            Add("415", "EAN_UCC_GlobalLocationNumber(GLN)_PayTo", DataType.NumericText, 13, false);
            Add("420", "ZipCodeOfRecipient_WithoutCountryCode", DataType.Alphanumeric, 20, true);
            Add("421", "ZipCodeOfRecipient_WithCountryCode", DataType.Alphanumeric, 12, true);
            Add("422", "CountryOfOrigin_ISO3166Format", DataType.Numeric, 3, true);
            Add("424", "CountryOfProcessing", DataType.Numeric, 3, true);
            Add("7001", "NatoStockNumber", DataType.NumericText, 13, false);
            Add(EGS1AI.HarvestDate, "HarvestDate_YYMMDD", DataType.Date, 6, false);
            Add("8001", "RolesProducts", DataType.NumericText, 14, false);
            Add("8002", "SerialNumberForMobilePhones", DataType.Alphanumeric, 20, true);
            Add("8003", "GRAI_GlobalReturnableAssetIdentifier", DataType.Alphanumeric, 34, true);
            Add("8004", "GIAI_GlobalIndividualAssetIdentifier", DataType.NumericText, 30, true);
            Add("8005", "SalesPricePerUnit", DataType.Numeric, 6, true);
            Add("8006", "IdentifikationOfAProductComponent", DataType.NumericText, 18, true);
            Add("8007", "IBAN", DataType.Alphanumeric, 30, true);
            Add("8008", "DataAndTimeOfManufacturing", DataType.NumericText, 12, true);
            Add("8010", "CPID_ComponentPartIdentifier", DataType.Alphanumeric, 30, true);
            Add("8011", "CPID_ComponentPartIdentifierSerialNumber", DataType.NumericText, 12, true);
            Add("8013", "GMN_GlobalModelNumber", DataType.Alphanumeric, 30, true);
            Add("8017", "GSRN_Provider", DataType.NumericText, 18, true);
            Add("8018", "GSRN_Recipient", DataType.NumericText, 18, true);
            Add("8019", "SRIN", DataType.NumericText, 10, true);
            Add("8020", "PaymentSlipReferenceNumber", DataType.Alphanumeric, 25, true);
            Add("90", "InformationForBilateralCoordinatedApplications", DataType.Alphanumeric, 30, true);

            Add("91", "Company specific", DataType.Alphanumeric, 30, true);
            Add("92", "Company specific", DataType.Alphanumeric, 30, true);
            Add("93", "Company specific", DataType.Alphanumeric, 30, true);
            Add("94", "Company specific", DataType.Alphanumeric, 30, true);
            Add("95", "Company specific", DataType.Alphanumeric, 30, true);
            Add("96", "Company specific", DataType.Alphanumeric, 30, true);
            Add("97", "Company specific", DataType.Alphanumeric, 30, true);
            Add("98", "Company specific", DataType.Alphanumeric, 30, true);
            Add("99", "Company specific", DataType.Alphanumeric, 30, true);

            MinLengthOfAI = AIDict.Values.Min(el => el.LengthOfAI);
            MaxLengthOfAI = AIDict.Values.Max(el => el.LengthOfAI);
        }

        /// <summary>
        /// Add an Application Identifier (AI)
        /// </summary>
        /// <param name="id">Number of the AI</param>
        /// <param name="description"></param>
        /// <param name="dataDescription">The type of the content</param>
        /// <param name="lengthOfData">The max lenght of the content</param>
        /// <param name="groupSeparatorPresent">Support a group seperator</param>
        public void Add(string id, string description, DataType dataDescription, int lengthOfData, bool groupSeparatorPresent)
        {
            AIDict[id] = new AI(id, description, dataDescription, lengthOfData, groupSeparatorPresent);
        }

        public bool TryGetAI(string ai, out AI Ai)
        {
            return AIDict.TryGetValue(ai, out Ai);
        }
    }
}

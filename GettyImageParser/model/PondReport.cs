using CsvHelper.Configuration.Attributes;

namespace GettyImageParser.model;

public class PondReport : IComparable
{
    [Name("id")]
    public int Id { get; set;}
    [Name("user_name")]
    public string  UserName { get; set; }
    [Name("report_id")]
    public int ReportId { get; set; }
    [Name("sale_date_time")]
    public string SaleDateTime { get; set; }
    [Name("transaction_id")]
    public string TransactionId { get; set; }
    [Name("content_id")]
    public string ContentId { get; set; }
    [Name("video_standard")]
    public int VideoStandart { get; set; }
    [Name("content_type")]
    public string ContentType { get; set; }
    [Name("currency_conversion_rate")]
    public decimal CurrencyConversionRate { get; set; }
    [Name("price_standard_local")]
    public decimal PriceStandartLocal { get; set; }
    [Name("price_edited_local")]
    public decimal PriceEditedLocal { get; set; }
    [Name("price_edit_reason_id")]
    public int PriceEditReasonId { get; set; }
    [Name("editReason")]
    public string EditReason { get; set; }
    [Name("delete_item")]
    public int DeleteItem { get; set; }
    [Name("delete_reason_id")]
    public int DeleteReasonId { get; set; }
    [Name("deleteReason")]
    public string DeleteReason { get; set; }
    [Name("reduced_commission")]
    public decimal ReducedComission { get; set; }
    [Name("commission_rate")]
    public decimal ComissionRate { get; set; }
    [Name("offset")]
    public int Offest { get; set; }
    [Name("media_size_id")]
    public int MediaSize { get; set; }
    [Name("minimum_price")]
    public int MinimumPrice { get; set; }
    [Name("updated_by")]
    public string UpdateBy { get; set; }
    [Name("updated_at")]
    public string UpdatedAt { get; set; }

    public int CompareTo(object? obj)
    {
        if(obj is PondReport pondReport) return String.Compare(UserName, pondReport.UserName, StringComparison.Ordinal);
        throw new ArgumentException("Некорректное значение параметра");
    }
}
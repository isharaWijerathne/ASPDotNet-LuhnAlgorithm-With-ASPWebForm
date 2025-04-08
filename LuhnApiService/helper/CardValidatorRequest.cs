namespace LuhnApiService.helper
{
    public class CardValidatorRequest
    {
        public string? CardNumber { get; set; }
        public string? ExpireDate { get; set; } //  Date/Year
        public int? CVV { get; set; }
    }
}

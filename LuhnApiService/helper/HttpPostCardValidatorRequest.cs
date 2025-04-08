namespace LuhnApiService.helper
{
    public class HttpPostCardValidatorRequest
    {
        public string? CardNumber { get; set; }
        public string? ExpireDate { get; set; } //  Date/Year
        public int? CVV { get; set; }
    }
}

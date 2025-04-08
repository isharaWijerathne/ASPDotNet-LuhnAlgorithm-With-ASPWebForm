namespace LuhnApiService.DTO
{
    public class CardValidatedStatus
    {
        public string? CardProvider { get; set; }

        public bool? IsCardValid { get; set; }

        public bool? IsCardLengthValid { get; set; }
    }
}

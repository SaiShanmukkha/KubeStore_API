namespace kubestore.DTO
{
    public class AuthMessageResponse
    {
        public string Message { get; set; }

        public bool IsSuccess { get; set; }

        public IEnumerable<string>? Errors { get; set; }

        public DateTime? Expiry { get; set; }

    }
}

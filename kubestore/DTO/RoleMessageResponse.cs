namespace kubestore.DTO
{
	public class RoleMessageResponse
	{
		public string Message { get; set; }

		public bool IsSuccess { get; set; }

		public IEnumerable<string>? Errors { get; set; }
	}
}

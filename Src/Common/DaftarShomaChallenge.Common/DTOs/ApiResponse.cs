using System.Net;

namespace DaftarShomaChallenge.Common.DTOs
{
	public record ApiResponse<T>
	{
		public bool Sucess { get; set; }
		public string ErrorMessage { get; set; }
		public T Data { get; set; }
	}

	public record ApiResponse
	{
		public bool Sucess { get; set; }
		public string ErrorMessage { get; set; }
		public string Message { get; set; }
		public HttpStatusCode StatusCode { get; set; }
	}
}

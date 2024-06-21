using System.Net;

namespace DaftarShomaChallenge.Common.DTOs
{
	public record ApiResponseWithListError
	{
		public bool Sucess { get; set; }
		public List<string> ErrorMessages { get; set; }
		public string Message { get; set; }
		public HttpStatusCode StatusCode { get; set; }
	}
}

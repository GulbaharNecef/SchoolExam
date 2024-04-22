namespace ExamProgramAPI.ResponseModels
{
	public class GenericResponseModel<T>
	{
		public T Data { get; set; }
		public int StatusCode { get; set; }
		//public string Message { get; set; }
	}
}

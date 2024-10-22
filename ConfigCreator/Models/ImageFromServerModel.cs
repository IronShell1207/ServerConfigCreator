namespace ConfigCreator.Models
{
	using Newtonsoft.Json;

	public class ImageFromServerModel
	{
		[JsonProperty("uri")]
		public string RelativePath { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("isPro")]
		public bool IsPaid { get; set; }

		[JsonProperty("file_name")]
		public string FileName { get; set; }
	}

}
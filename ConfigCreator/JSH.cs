namespace ConfigCreator
{
	using Newtonsoft.Json.Converters;
	using Newtonsoft.Json.Serialization;
	using Newtonsoft.Json;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;

	internal class JSH
	{

		/// <summary>
		/// Сериализует объект.
		/// </summary>
		public static string SerializeJson(object inputObject, bool isNullIgnore = false, ISerializationBinder bulder = null, bool prettify = false)
		{
			if (inputObject == null)
				return null;

			StringBuilder stringBuilder = new StringBuilder();
			using TextWriter textWriter = new StringWriter(stringBuilder);
			using JsonWriter jsonWriter = new JsonTextWriter(textWriter);

			var jsonSerializerSettings = new JsonSerializerSettings
			{
				Formatting = prettify ? Formatting.Indented : Formatting.None,
				TypeNameHandling = TypeNameHandling.Auto,
				NullValueHandling = NullValueHandling.Ignore,
				ReferenceLoopHandling = ReferenceLoopHandling.Ignore
			};
			if (bulder != null)
			{
				jsonSerializerSettings.SerializationBinder = bulder;
			}

			if (isNullIgnore)
			{
				jsonSerializerSettings.NullValueHandling = NullValueHandling.Ignore;
			}
			JsonConverter jsonConverter = new BinaryConverter();
			var jsonSerializer = JsonSerializer.Create(jsonSerializerSettings);
			jsonSerializer.Converters.Add(jsonConverter);
			jsonSerializer.Serialize(jsonWriter, inputObject);
			return stringBuilder.ToString();
		}
	}
}

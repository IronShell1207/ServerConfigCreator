

using ConfigCreator;
using ConfigCreator.Models;
using Windows.Storage;

Console.WriteLine("Enter path to folder: ");
string path = Console.ReadLine();

if (Directory.Exists(path))
{
	var folder = await StorageFolder.GetFolderFromPathAsync(path);
	if (folder != null)
	{
		var filesFromFolder = await folder.GetFilesAsync();
		List<ImageFromServerModel> images = new List<ImageFromServerModel>();
		foreach (var file in filesFromFolder)
		{
			var image = new ImageFromServerModel();
			image.Name = "Image";
			image.RelativePath = $"https://serv.droidhack.org/img/{file.Name}";
			image.IsPaid = false;
			image.FileName = file.Name;
			images.Add(image);
		}

		string js = JSH.SerializeJson(images);

	}
}

Console.ReadKey();
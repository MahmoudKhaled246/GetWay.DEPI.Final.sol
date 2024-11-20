namespace Auth.DEPI.Final.PL.Helpers
{
	public class DocumentSettings
	{
		public static string UploadFile(IFormFile file, string folderName)
		{

			//1 - Get Folder Path

			string folderPath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\files", folderName);

			//2 - make file Name Make It Unique

			string fileName = $"{Guid.NewGuid()}{file.FileName}";

			//3 - file Path  will be folderPath + fileName

			string filePath = Path.Combine(folderPath, fileName);

			//4 - Save File and Create it as Stream

			using var fileStream = new FileStream(filePath,FileMode.Create);

			file.CopyTo(fileStream);


			return fileName;
		}
		
		public static void DeleteFile(string fileName , string folderName)
		{
			// 1- get the File
			var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\files", folderName, fileName);

			// 2 - Delete if found 
			if (File.Exists(filePath))
			{
				File.Delete(filePath);
			}

		}
	}
}

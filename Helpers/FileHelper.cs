namespace DemoFramework_Core.Helpers
{
	public class FileHelpers
	{
		public static string GenerateFileName(string filename)
		{
			var name = Guid.NewGuid().ToString().Replace("-","");
			var lastindex = filename.LastIndexOf('.');
			var ext = filename.Substring(lastindex);
			return name + ext;
		}
	}
}

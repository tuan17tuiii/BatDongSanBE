namespace BatDongSan.Helpers
{
	public class RandomHelper
	{
		public static string GenerateScurityCode()
		{
			return Guid.NewGuid().ToString().Replace("-","");
		}
	}
}

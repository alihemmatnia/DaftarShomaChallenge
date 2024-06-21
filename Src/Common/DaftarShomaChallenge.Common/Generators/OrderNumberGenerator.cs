namespace DaftarShomaChallenge.Common.Generators
{
	public static class OrderNumberGenerator
	{
		private static Random _random = new();

		public static string Generate (int length = 6)
		{
			char[] digits = new char[length];
			digits[0] = (char) ('1' + _random.Next(0, 9));

			for (int i = 1; i < length; i++)
				digits[i] = (char) ('0' + _random.Next(0, 10));

			return new string(digits);
		}
	}
}

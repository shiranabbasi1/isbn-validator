using IsbnValidator.Interfaces;

namespace IsbnValidator.Implementations
{
	public class Isbn13Validator: IIsbnValidator
	{
		public bool Validate(string isbn)
		{
			bool result = false;

			isbn = isbn.Replace("-", "");
			int sum = 0;
			int limit = isbn.Length - 1;
			for (int i = 0, multiplier = 1; i < limit; i++)
			{
				if (int.TryParse($"{isbn[i]}", out int n))
				{
					sum += n * multiplier;
				}
				else
				{
					return result;
				}
				multiplier = (multiplier == 1) ? 3 : 1;
			}

			int checkDigit = GetCheckDigit(sum);
			result = ($"{checkDigit}".Equals($"{isbn[limit]}"));

			return result;
		}

		private int GetCheckDigit(int sum)
		{
			return (((sum % 10) == 0) ? 0 : (10 - (sum % 10)));
		}
	}
}

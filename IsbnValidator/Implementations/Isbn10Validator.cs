using IsbnValidator.Interfaces;

namespace IsbnValidator.Implementations
{
	public class Isbn10Validator : IIsbnValidator
	{
		public bool Validate(string isbn)
		{
			bool result = false;

			isbn = isbn.Replace("-", "");
			int sum = 0;
			int limit = isbn.Length - 1;
			for (int i = 0; i < limit; i++)
			{
				if(int.TryParse($"{isbn[i]}", out int n))
				{
					sum += (n * (isbn.Length - i));
				}
				else
				{
					return result;
				}
			}

			string checkDigit = GetCheckDigit(sum);
			result = checkDigit.Equals($"{isbn[limit]}".ToLower());

			return result;
		}

		private string GetCheckDigit(int sum)
		{
			if ((sum % 11) == 0)
				return "0";
			else
			{
				int checkDigit = ((sum / 11 + 1) * 11 - sum);
				return (checkDigit == 10) ? "x" : $"{checkDigit}";
			}
		}
	}
}

using IsbnValidator.Interfaces;
using IsbnValidator.Implementations;
using IsbnValidator.Common.Enums;

namespace IsbnValidator
{
	public class Program
	{
		public static void Main(string[] args)
		{
			string isbn = "0-471-19047-0";
			IIsbnValidator isbnValidator = IsbnValidatorResolver.Resolve(IsbnScheme.Ten);
			Console.WriteLine(isbnValidator.Validate(isbn));
		}
	}
}

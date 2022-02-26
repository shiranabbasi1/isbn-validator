using IsbnValidator.Common.Enums;
using IsbnValidator.Interfaces;

namespace IsbnValidator.Implementations
{
	public static class IsbnValidatorResolver
	{
		public static IIsbnValidator Resolve(IsbnScheme type = IsbnScheme.Ten)
		{
			IIsbnValidator result = null;
			if (type.Equals(IsbnScheme.Ten))
				result = new Isbn10Validator();
			else if (type.Equals(IsbnScheme.Thirteen))
				result = new Isbn13Validator();

			return result;
		}
	}
}
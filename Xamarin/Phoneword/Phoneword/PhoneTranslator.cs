using System.Text;
using System;

namespace Core
{
	public static class PhonewordTranslator
	{
		public static string ToNumber(string raw)
		{
			if (string.IsNullOrWhiteSpace(raw))
				return "";
			else
				raw = raw.ToUpperInvariant();

			var newNumber = new StringBuilder();
			foreach (var c in raw)
			{
				if (" -0123456789".Contains(c))
					newNumber.Append(c);
				else {
					var result = TranslateToNumber(c);
					if (result != null)
						newNumber.Append(result);
				}
				// otherwise we've skipped a non-numeric char
			}
			return newNumber.ToString();
		}
		static bool Contains (this string keyString, char c)
		{
			return keyString.IndexOf(c) >= 0;
		}
		static int? TranslateToNumber(char c)
		{
			if ("ABC".Contains(c))
				return 2;
			else if ("DEF".Contains(c))
				return 3;
			else if ("GHI".Contains(c))
				return 4;
			else if ("JKL".Contains(c))
				return 5;
			else if ("MNO".Contains(c))
				return 6;
			else if ("PQRS".Contains(c))
				return 7;
			else if ("TUV".Contains(c))
				return 8;
			else if ("WXYZ".Contains(c))
				return 9;
			return null;
		}

		public static string ToVanity(string raw)
		{
			if (string.IsNullOrWhiteSpace(raw))
				return "";
			else
				raw = raw.ToUpperInvariant();

			var newNumber = new StringBuilder();
			foreach (var c in raw)
			{
				if ("0123456789".Contains (c)) {
					var result = TranslateToVanity (c);
					if (result != null)
						newNumber.Append (result);
				}
			}
			return newNumber.ToString();
		}


		static string TranslateToVanity(char c)
		{

			if ("1".Contains(c))
				return " ";
			else if ("2".Contains(c))
				return "ABC";
			else if ("3".Contains(c))
				return "DEF";
			else if ("4".Contains(c))
				return "GHI";
			else if ("5".Contains(c))
				return "JKL";
			else if ("6".Contains(c))
				return "MNO";
			else if ("7".Contains(c))
				return "PQRS";
			else if ("8".Contains(c))
				return "TUV";
			else if ("9".Contains(c))
				return "WXYZ";
			return null;
		}
	}
}
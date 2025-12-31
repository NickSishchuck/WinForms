namespace WinFormsApp1
{
    public static class NumberToWordsUA
    {
        private static readonly string[] units = { "", "один", "два", "три", "чотири", "п'ять", "шість", "сім", "вісім", "дев'ять" };
        private static readonly string[] teens = { "десять", "одинадцять", "дванадцять", "тринадцять", "чотирнадцять", 
                                                   "п'ятнадцять", "шістнадцять", "сімнадцять", "вісімнадцять", "дев'ятнадцять" };
        private static readonly string[] tens = { "", "", "двадцять", "тридцять", "сорок", "п'ятдесят", 
                                                  "шістдесят", "сімдесят", "вісімдесят", "дев'яносто" };
        private static readonly string[] hundreds = { "", "сто", "двісті", "триста", "чотириста", "п'ятсот", 
                                                      "шістсот", "сімсот", "вісімсот", "дев'ятсот" };

        public static string Convert(decimal amount)
        {
            if (amount == 0)
                return "Нуль грн. 00 к.";

            int hryvnias = (int)amount;
            int kopiykas = (int)((amount - hryvnias) * 100);

            string result = "";

            if (hryvnias == 0)
            {
                result = "Нуль";
            }
            else
            {
                result = ConvertIntegerPart(hryvnias);
                // Перша літера велика
                if (!string.IsNullOrEmpty(result))
                {
                    result = char.ToUpper(result[0]) + result.Substring(1);
                }
            }

            result += " грн. " + kopiykas.ToString("D2") + " к.";

            return result;
        }

        private static string ConvertIntegerPart(int number)
        {
            if (number == 0)
                return "";

            string result = "";

            if (number >= 1000000)
            {
                int millions = number / 1000000;
                result += ConvertHundreds(millions) + GetMillionWord(millions);
                number %= 1000000;
            }

            if (number >= 1000)
            {
                int thousands = number / 1000;
                result += ConvertThousands(thousands);
                number %= 1000;
            }

            if (number > 0)
            {
                result += ConvertHundreds(number);
            }

            return result.Trim();
        }

        private static string ConvertHundreds(int number)
        {
            if (number == 0)
                return "";

            string result = "";

            int hundredsPart = number / 100;
            if (hundredsPart > 0)
            {
                result += hundreds[hundredsPart] + " ";
            }

            number %= 100;

            if (number >= 10 && number <= 19)
            {
                result += teens[number - 10] + " ";
                return result;
            }

            int tensPart = number / 10;
            if (tensPart > 0)
            {
                result += tens[tensPart] + " ";
            }

            int unitsPart = number % 10;
            if (unitsPart > 0)
            {
                result += units[unitsPart] + " ";
            }

            return result;
        }

        private static string ConvertThousands(int number)
        {
            if (number == 0)
                return "";

            string result = "";

            int hundredsPart = number / 100;
            if (hundredsPart > 0)
            {
                result += hundreds[hundredsPart] + " ";
            }

            number %= 100;

            if (number >= 10 && number <= 19)
            {
                result += teens[number - 10] + " ";
                result += GetThousandWord(number);
                return result;
            }

            int tensPart = number / 10;
            if (tensPart > 0)
            {
                result += tens[tensPart] + " ";
            }

            int unitsPart = number % 10;
            if (unitsPart > 0)
            {
                if (unitsPart == 1)
                    result += "одна ";
                else if (unitsPart == 2)
                    result += "дві ";
                else
                    result += units[unitsPart] + " ";
            }

            result += GetThousandWord(number);

            return result;
        }

        private static string GetThousandWord(int number)
        {
            int lastDigit = number % 10;
            int lastTwoDigits = number % 100;

            if (lastTwoDigits >= 11 && lastTwoDigits <= 19)
                return "тисяч ";

            if (lastDigit == 1)
                return "тисяча ";
            else if (lastDigit >= 2 && lastDigit <= 4)
                return "тисячі ";
            else
                return "тисяч ";
        }

        private static string GetMillionWord(int number)
        {
            int lastDigit = number % 10;
            int lastTwoDigits = number % 100;

            if (lastTwoDigits >= 11 && lastTwoDigits <= 19)
                return " мільйонів ";

            if (lastDigit == 1)
                return " мільйон ";
            else if (lastDigit >= 2 && lastDigit <= 4)
                return " мільйони ";
            else
                return " мільйонів ";
        }
    }
}

using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace Core.Common.Validations
{
    [ExcludeFromCodeCoverage]
    public static class Validate
    {
        public enum CardTypes
        {
            MasterCard = 0,
            Visa = 1,
            Amex = 2,
            DinersClub = 3,
            EnRoute = 4,
            Discover = 5,
            Jcb = 6,
            Unknown = 7,
            ChinaUnionPay = 8,
            InterPayment = 9,
            Maestro = 10,
            Dankort = 11,
            Laser = 12,
            UnionPay = 13
        }

        public static bool IsValidEmail(this string emailToValidate)
        {
            if (String.IsNullOrEmpty(emailToValidate))
                return false;

            Regex re = new Regex(RegexPatterns.EMAIL);

            return re.IsMatch(emailToValidate);
        }

        public static bool IsValidUSZipCode(this string value)
        {
            if (String.IsNullOrEmpty(value))
                return false;

            Regex fiveDigit = new Regex(RegexPatterns.ZIP_CODE_US);
            Regex fiveDigitPlusFour = new Regex(RegexPatterns.ZIP_CODE_US_WITH_FOUR);

            return fiveDigit.IsMatch(value) || fiveDigitPlusFour.IsMatch(value);
        }

        public static bool IsValidFiveDigitsUSZipCode(this string value)
        {
            if (String.IsNullOrEmpty(value))
                return false;

            Regex re = new Regex(RegexPatterns.ZIP_CODE_US);

            return re.IsMatch(value);
        }

        public static bool IsValidPhoneUS(this string value)
        {
            if (String.IsNullOrEmpty(value))
                return false;

            Regex re = new Regex(RegexPatterns.PHONE_US);

            return re.IsMatch(value);
        }

        public static bool IsValidUrl(this string value)
        {
            if (String.IsNullOrEmpty(value))
                return false;

            Regex re = new Regex(RegexPatterns.URL);

            return re.IsMatch(value);
        }

        public static bool IsValidSocialSecurity(this string value)
        {
            if (String.IsNullOrEmpty(value))
                return false;

            Regex re = new Regex(RegexPatterns.SOCIAL_SECURITY);

            return re.IsMatch(value);
        }

        public static bool IsValidNumeric(this string value)
        {
            if (String.IsNullOrEmpty(value))
                return false;

            Regex re = new Regex(RegexPatterns.NUMERIC);

            return re.IsMatch(value);
        }

        public static bool IsValidateCreditCard(string number)
        {
            return IsValidCcNumber(number) && (IsValidCardType(number) != CardTypes.Unknown);
        }

        /// <summary>
        ///     Extremely fast Luhn algorithm implementation, based on
        ///     pseudo code from Cliff L. Biffle (http://microcoder.livejournal.com/17175.html)
        ///     Copyleft Thomas @ Orb of Knowledge:
        ///     http://orb-of-knowledge.blogspot.com/2009/08/extremely-fast-luhn-function-for-c.html
        /// </summary>
        /// <param name="number"></param>
        /// <returns>bool</returns>
        /// <see cref="http://orb-of-knowledge.blogspot.com/2009/08/extremely-fast-luhn-function-for-c.html" />
        private static bool IsValidCcNumber(string number)
        {
            int[] deltas = new[] {0, 1, 2, 3, 4, -4, -3, -2, -1, 0};
            int checksum = 0;
            char[] chars = number.ToCharArray();
            for (int i = chars.Length - 1; i > -1; i--)
            {
                int j = (chars[i]) - 48;
                checksum += j;
                if (((i - chars.Length)%2) == 0)
                    checksum += deltas[j];
            }
            return ((checksum%10) == 0);
        }

        public static CardTypes IsValidCardType(string cardNumber)
        {
            // AMEX -- 34 or 37 -- 15 length
            if ((Regex.IsMatch(cardNumber, "^(34|37)")) && (15 == cardNumber.Length))
                //&& ((_cardTypes & CardType.Amex) != 0))
                return CardTypes.Amex;

            if ((Regex.IsMatch(cardNumber, @"^(62[0-9]{14,17})$")))
                return CardTypes.UnionPay;

            // 62 -- 16-19 length
            if ((Regex.IsMatch(cardNumber, "^(62)")) && (cardNumber.Length >= 16 && cardNumber.Length <= 19))
                //&& ((_cardTypes & CardType.Amex) != 0))
                return CardTypes.ChinaUnionPay;

            // Diners Club -- 300-305, 309, 36, 38-39, -- 14 length
            if ((Regex.IsMatch(cardNumber, "^(300|301|302|303|304|305|309|36|38|39)")) && (14 == cardNumber.Length))
                return CardTypes.DinersClub;

            // enRoute -- 2014,2149 -- 15 length
            if ((Regex.IsMatch(cardNumber, "^(2014|2149)")) && (15 == cardNumber.Length))
                return CardTypes.EnRoute;

            // Discover -- 6011 -- 16 length
            if ((Regex.IsMatch(cardNumber, "6(?:011|5[0-9]{2})[0-9]{12}")) && (16 == cardNumber.Length))
                return CardTypes.Discover;

            //636, 16-19 length
            if ((Regex.IsMatch(cardNumber, "^(636)")) && (cardNumber.Length >= 16 && cardNumber.Length <= 19))
                return CardTypes.InterPayment;

            //637-639 16 length
            if ((Regex.IsMatch(cardNumber, "^(637|638|639)")) && (cardNumber.Length == 14))
                return CardTypes.InterPayment;

            if ((Regex.IsMatch(cardNumber, "^(6304|6706|6709|6771)[0-9]{12,15}$")) && (cardNumber.Length >= 16 && cardNumber.Length <= 19))
                return CardTypes.Laser;

            // JCB -- 3528-3589 -- 16 length
            if ((Regex.IsMatch(cardNumber, @"(?:2131|1800|35\d{3})\d{11}")) && (16 == cardNumber.Length))
                return CardTypes.Jcb;

            // 5019 -- 16 length
            if ((Regex.IsMatch(cardNumber, "^(5019)")) && (16 == cardNumber.Length))
                return CardTypes.Dankort;

            // 500000-509999, 560000-699999, 12-19 length
            if ((Regex.IsMatch(cardNumber, @"^(?:5[0678]\d\d|6304|6390|67\d\d|68\d\d)\d{8,15}$")))
                return CardTypes.Maestro;

            // MasterCard -- 51 through 55 -- 16 length
            if ((Regex.IsMatch(cardNumber, "^(51|52|53|54|55)")) && (16 == cardNumber.Length))
                return CardTypes.MasterCard;

            // VISA -- 4 -- 13 and 16 length
            if ((Regex.IsMatch(cardNumber, "^(4)")) && (13 == cardNumber.Length || 16 == cardNumber.Length))
                return CardTypes.Visa;

            //if we reach here it failed all other validations
            return CardTypes.Unknown;
        }
    }
}
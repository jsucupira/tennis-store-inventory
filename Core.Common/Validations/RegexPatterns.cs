namespace Core.Common.Validations
{
    public static class RegexPatterns
    {
        public const string ALPHA = @"^[a-zA-Z]*$";
        public const string ALPHA_UPPER_CASE = @"^[A-Z]*$";
        public const string ALPHA_LOWER_CASE = @"^[a-z]*$";
        public const string ALPHA_NUMERIC = @"^[a-zA-Z0-9]*$";
        public const string ALPHA_NUMERIC_SPACE = @"^[a-zA-Z0-9 ]*$";
        public const string ALPHA_NUMERIC_SPACE_DASH = @"^[a-zA-Z0-9 \-]*$";
        public const string ALPHA_NUMERIC_SPACE_DASH_UNDERSCORE = @"^[a-zA-Z0-9 \-_]*$";
        public const string ALPHA_NUMERIC_SPACE_DASH_UNDERSCORE_PERIOD = @"^[a-zA-Z0-9\. \-_]*$";

        public const string NUMERIC = @"^\-?[0-9]*\.?[0-9]*$";
        public const string SOCIAL_SECURITY = @"\d{3}[-]?\d{2}[-]?\d{4}";
        public const string EMAIL = @"^([0-9a-zA-Z]+[-._+&])*[0-9a-zA-Z]+@([-0-9a-zA-Z]+[.])+[a-zA-Z]{2,6}$";

        public const string URL = @"^^(ht|f)tp(s?)\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&%\$#_=]*)?$";

        public const string ZIP_CODE_US = @"^\d{5}$";
        public const string ZIP_CODE_US_WITH_FOUR = @"\d{5}[-]\d{4}";
        public const string PHONE_US = @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$";
    }
}
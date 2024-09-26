﻿namespace ReserveiAPI.Objects.Utilities
{
    public static class ValidatorUtilitie
    {

        public static bool  CompareString(string str1, string str2)
        {
            return string.Equals(str1.RemoveDiacritics(), str2.RemoveDiacritics(), StringComparison.OrdinalIgnoreCase);
        }

        public static bool CheckValidPhone(string phone) 
        {
            int phoneLenght = OperatorUtilitie.ExtractNumbers(phone).Length;
            return phoneLenght > 9 && phoneLenght < 12;
        }

        public static int CheckValidEmail(string email)
        {
            int atCount = email.Count(c => c == '@');
            bool hasTextBeforeAt = email.IndexOf('@') > 0;
            bool hasTextAfterAt = email.LastIndexOf('@') < email.Length - 1;

            int atPosition = email.IndexOf('@');
            bool hasDoAfterAt = atPosition >= 0 && email.IndexOf('.', atPosition) > atPosition;
            bool endsWithDot = email.EndsWith('.');

            if (atCount != 1) return -1;

            else if (!hasTextBeforeAt) return -1;

            else if (!hasTextAfterAt) return -2;

            else if (!hasDoAfterAt) return -2;

            else if (endsWithDot) return -1;

            return 1;
        }

    }
}

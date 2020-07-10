using System;

namespace Nhom2.TMDT.Common.Verification
{
    public class Verification
    {
        public string Random()
        {
            string res = "";
            Random random = new Random();
            int lenght = random.Next(15, 20);
            while (lenght > 0)
            {
                int key = random.Next(48, 123);
                if (Char.IsLetterOrDigit((char)key))
                {
                    res += (char)key;
                    lenght--;
                }
            }
            return res;
        }
    }
}

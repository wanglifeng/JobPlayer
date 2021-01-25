using System;
using System.Collections.Generic;
using System.Globalization;
namespace CL.Manage.Data.String
{
    public static class  StringExtension
    {
        public static string[] StringSplit(this string i, string Char, int? index = null)
        {
            string[] array = new string[2];
            if (index.HasValue)
            {
                index = i.IndexOf(Char);
                char[] arrayChar = i.ToCharArray();
                string Head = null, Tail = null;
                for (int j = 0; j < arrayChar.Length; j++)
                {
                    if (j < index)
                    {
                        Head += arrayChar[j].ToString();
                    }
                    else if (j == index) continue;
                    else
                    {
                        Tail += arrayChar[j].ToString();
                    }

                }
                array[0] = Head;
                array[1] = Tail;
            }
            else
            {
                array = i.Split(new string[] { Char }, StringSplitOptions.RemoveEmptyEntries);
            }
            return array;
        }

        public static string StringCombination(this string[] i, string format, string direction)
        {
            string result = null;
            foreach (string v in i)
            {
                if (direction == "tail")
                    result += v + format;
                else if (direction == "head")
                    result += format + v;
                else
                    throw new Exception(string.Format("请确认符号的位置"));
            }
            return result;
        }

        public static string ReplaceString(this string i, string format1, string format2)
        {
            string[] array = i.StringSplit(format1);
            return array.StringCombination(format2, "head");
        }

        public static string Reverce(this string input)
        {
            char[] chars = input.ToCharArray();
            Array.Reverse(chars);
            return new string(chars);
        }

        public static string SplitHeadTail(this string input, char Head, char Tail)
        {
            int TailIndex;
            TailIndex = input.IndexOf(Tail);
            input = input.Remove(TailIndex);
            input = input.Reverce();
            TailIndex = input.IndexOf(Head);
            input = input.Remove(TailIndex);
            input = input.Reverce();
            return input;
        }

        public static int IndexFirstOrLast(this string input, char Char, string Direction)
        {
            if (Direction == "FirstIndex")
            {
                return input.IndexOf(Char);
            }
            else if (Direction == "LastIndex")
            {
                char[] charArray = input.ToCharArray();
                for (int i = charArray.Length; i > 0; i--)
                {
                    if (charArray[i - 1] == Char)
                    {
                        return i;
                    }
                }
                throw new Exception(string.Format("不存在字符{0}，获取不到对应index", Char));
            }
            else
            {
                throw new Exception(string.Format("请核对方向Direction的方向：FirstIndex or LastIndex"));
            }

        }

        public static string CreatePhoneNumber(this string i)
        {
            string[] telStarts = "134,135,136,137,138,139,150,151,152,157,158,159,130,131,132,155,156,133,153,180,181,182,183,185,186,176,187,187,188,189,177,178".Split(',');
            Random ran = new Random();
            int n = ran.Next(10, 1000);
            int index = ran.Next(0, telStarts.Length - 1);
            string first = telStarts[index];
            string second = (ran.Next(100, 888) + 10000).ToString().Substring(1);
            string thrid = (ran.Next(1, 9100) + 10000).ToString().Substring(1);
            return first + second + thrid;
        }

        public static string CreateID(this string Id)
        {
            System.Random rd = new System.Random();
            //随机地区号码
            Dictionary<int, string> areCollection = new Dictionary<int, string>(){
                {1,"320323"},{2,"320100"},{3,"320101"},{4,"320102"},{5,"320103"},{6,"320104"},{7,"320105"},{8,"320106"},{9,"320107"},{10,"320108"},
            };
            string area = areCollection[rd.Next(1, 10)];
            //随机出生日期
            DateTime birthday = DateTime.Now;
            birthday = birthday.AddYears(-rd.Next(18, 45));
            birthday = birthday.AddMonths(-rd.Next(0, 12));
            birthday = birthday.AddDays(-rd.Next(0, 31));
            //随机码
            string code = rd.Next(1000, 9999).ToString("####");
            //生成完整身份证号
            string codeNumber = area + birthday.ToString("yyyyMMdd") + code;
            double sum = 0;
            string checkCode = null;
            for (int i = 2; i <= 18; i++)
            {
                sum += int.Parse(codeNumber[18 - i].ToString(), NumberStyles.HexNumber) * (Math.Pow(2, i - 1) % 11);
            }
            string[] checkCodes = { "1", "0", "X", "9", "8", "7", "6", "5", "4", "3", "2" };
            checkCode = checkCodes[(int)sum % 11];
            codeNumber = codeNumber.Substring(0, 17) + checkCode;
            //
            return codeNumber;
        }

        public static string CreateCnName(this string i)
        {
            return CustomerName.GetCustomerName();
        }

        public static string CreateEmail(this string i)
        {
            string EmailHead=null;
            return EmailHead = EmailHead.CreatePhoneNumber() + "@qq.com";
        }
    }
}

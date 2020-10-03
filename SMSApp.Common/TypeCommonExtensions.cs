using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Security;
using System.Security.Cryptography;

namespace SMSApp.Common
{
    public static class TypeCommonExtensions
    {
        public static bool IsNumeric(this string str)
        {
            double retValue;
            return double.TryParse(str, out retValue);
        }

        public static bool IsNumeric(this object str)
        {
            double retValue;
            return double.TryParse(str.ToString(), out retValue);
        }

        public static string DefaultText(this string str, string text)
        {
            return str.Trim() == "" ? text : str;
        }

        public static char ToChar(this string str)
        {
            char retValue;
            char.TryParse(str, out retValue);
            return retValue;
        }

        public static char ToChar(this object str)
        {
            if (str == DBNull.Value)
            {
                return ' ';
            }
            else
            {
                char retValue;
                char.TryParse(str.ToString(), out retValue);
                return retValue;
            }
        }

        public static int ToInt(this string str)
        {
            int retValue;
            int.TryParse(str, out retValue);
            return retValue;
        }

        public static byte ToByte(this string str)
        {
            byte retValue;
            byte.TryParse(str, out retValue);
            return retValue;
        }

        public static int ToInt(this object str)
        {
            if (str == DBNull.Value || str == null)
            {
                return 0;
            }
            else
            {
                int retValue;
                int.TryParse(str.ToString(), out retValue);
                return retValue;
            }
        }

        public static Int16 ToInt16(this string str)
        {
            Int16 retValue;
            Int16.TryParse(str, out retValue);
            return retValue;
        }

        public static Int16 ToInt16(this object str)
        {
            if (str == DBNull.Value || str == null)
            {
                return 0;
            }
            else
            {
                Int16 retValue;
                Int16.TryParse(str.ToString(), out retValue);
                return retValue;
            }
        }

        public static byte ToByte(this object str)
        {
            if (str == DBNull.Value || str == null)
            {
                return 0;
            }
            else
            {
                byte retValue;
                byte.TryParse(str.ToString(), out retValue);
                return retValue;
            }
        }

        public static DateTime ToDateTime(this string str)
        {
            DateTime retValue;
            DateTime.TryParse(str, out retValue);
            return retValue;
        }

        public static DateTime ToDateTime(this object str)
        {
            if (str == DBNull.Value)
            {
                return DateTime.MinValue;
            }
            else
            {
                DateTime retValue;
                DateTime.TryParse(str.ToString(), out retValue);
                return retValue;
            }
        }

        public static double ToDouble(this object obj)
        {
            if (obj == DBNull.Value || obj == null)
            {
                return 0.0;
            }
            else
            {
                double retValue;
                double.TryParse(obj.ToString(), out retValue);
                return retValue;
            }
        }

        public static float ToSingle(this object obj)
        {
            if (obj == DBNull.Value || obj == null)
                return 0.0f;
            float retValue;
            float.TryParse(obj.ToString(), out retValue);
            return retValue;
        }

        public static decimal ToDecimal(this object str)
        {
            if (str == DBNull.Value)
            {
                return 0;
            }
            else
            {
                decimal retValue;
                decimal.TryParse(str.ToString(), out retValue);
                return retValue;
            }
        }

        public static long ToLong(this object str)
        {
            if (str == DBNull.Value || str == null)
            {
                return 0;
            }
            else
            {
                long retValue;
                long.TryParse(str.ToString(), out retValue);
                return retValue;
            }
        }

        public static DateTime IsDateTime(this string str)
        {
            DateTime retValue;
            DateTime.TryParse(str, out retValue);
            return retValue;
        }

        public static bool IsEmpty(this string str)
        {
            return str.Trim() == string.Empty;
        }

        public static bool IsNullOrEmpty(this string str)
        {
            return str.Trim() == string.Empty || str == null;
        }

        public static object ToObject(this int? val)
        {
            if (val == null)
                return DBNull.Value;
            else
                return val;
        }

        public static object ToObject(this int val)
        {
            if (val == 0)
                return DBNull.Value;
            else
                return val;
        }

        public static object ToObject(this Int16 val)
        {
            if (val == 0)
                return DBNull.Value;
            else
                return val;
        }

        public static object ToDbObject(this string val)
        {
            if (val == null)
                return DBNull.Value;
            else
                return val;
        }

        public static object ToDbObject(this object val)
        {
            if (val == null)
                return DBNull.Value;
            else
                return val;
        }

        public static string ToStr(this object val, bool returnEmptyIfDBNull = false)
        {
            if (val == DBNull.Value)
                return returnEmptyIfDBNull ? string.Empty : null;
            if (val == null)
                return string.Empty;
            else
                return val.ToString();
        }

        public static string ToAmount(this double val)
        {
            return "$" + String.Format("{0:#,##0.00}", val);
        }

        /// <summary>
        /// To convert empty string to null.
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static string EmptyToNull(this object val)
        {
            if (val == null)
                return null;
            else if (val.ToString() == string.Empty)
                return null;
            else
                return val.ToString();
        }

        /// <summary>
        /// To convert empty string to DBNull.
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static string EmptyToDBNull(this object val)
        {
            if (val == null)
                return "NULL";
            else if (val.ToString() == string.Empty)
                return "NULL";
            else
                return val.ToString();
        }

        /// <summary>
        /// To convert 0 to null.
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static string ZeroToNull(this object val)
        {
            if (val.ToString() == "0")
                return null;
            else
                return val.ToString();
        }

        public static bool ToBoolean(this object val)
        {
            if (val == DBNull.Value || val == null)
                return false;
            else if (val.ToString().ToLower() == "false" || val.ToString() == "0")
                return false;
            else
                return true;
        }

        public static char ToChar(this bool val)
        {
            if (val)

                //return '1';
                return 'Y';
            else

                //return '0';
                return 'N';
        }

        /// <summary>
        /// To split the given string with split value.
        /// Use of FlexSplit: If the given index exceeds the split array then it will return the empty value.
        /// </summary>
        /// <param name="val"></param>
        /// <param name="splitValue"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static string FlexSplit(object val, char splitValue, Int16 index)
        {
            if (val == null)
                return string.Empty;
            if (index <= val.ToString().Split(splitValue).Length - 1)
                return val.ToString().Split(splitValue)[index];
            else
                return string.Empty;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="val"></param>
        /// <param name="startIndex"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string FlexSubString(this object val, Int16 startIndex, Int16 length)
        {
            if (val == null)
                return string.Empty;
            if (val.ToString().Length >= startIndex + length)
                return val.ToString().Substring(startIndex, length);
            else
                return string.Empty;
        }

        public static System.Collections.IDictionary ToDictionary(this object obj)
        {
            System.Collections.Generic.Dictionary<string, object> objDescr = new System.Collections.Generic.Dictionary<string, object>();

            foreach (System.ComponentModel.PropertyDescriptor descriptor in System.ComponentModel.TypeDescriptor.GetProperties(obj))
            {
                objDescr.Add(descriptor.Name, descriptor.GetValue(obj));
            }
            return objDescr;
        }

        public static DateTime GetWeekStartDate(this DateTime obj)
        {
            return obj.AddDays(-(int)obj.DayOfWeek);
        }

        public static DateTime GetWeekEndDate(this DateTime obj)
        {
            return obj.GetWeekStartDate().AddDays(6);
        }

        public static string ToQualifiedFileName(this string fileName)
        {
            Regex regex = new Regex(@"[:""\/*?<>|]+");
            string qualifiedFileName = regex.Replace(fileName, "");
            return qualifiedFileName;
        }

        // Not completed - Need to place business id length and date format in configuration
        public static string ToBusinessID(this object obj)
        {
            return obj.ToStr().PadLeft(7, '0');
        }

        public static string ToClientID(this object obj)
        {
            return obj.ToStr().PadLeft(9, '0');
        }

        public static string ToFilingNumber(this object obj)
        {
            return obj.ToStr().PadLeft(10, '0');
        }

        /// <summary>
        /// For rendering date with a standard format
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToAppDate(this DateTime obj)
        {
            return string.Format("{0:MM/dd/yyyy}", obj);
        }

        public static string ToSqlstr(this string str)
        {
            if (str == null)
                return "NULL";
            else
                return str.Replace("'", "''");
        }

        public static T IfIsNullOrEmpty<T>(this object obj, T ifTrue)
        {
            return obj == null ? ifTrue : (obj.ToString() == "" ? ifTrue : (T)Convert.ChangeType(obj, typeof(T)));
        }

        public static string ToAgentID(this object obj)
        {
            return obj.ToStr().PadLeft(9, '0');
        }

        public static string GeneratePassword(int length)
        {
            RNGCryptoServiceProvider cryptRNG = new RNGCryptoServiceProvider();
            byte[] tokenBuffer = new byte[length];
            cryptRNG.GetBytes(tokenBuffer);
            return Convert.ToBase64String(tokenBuffer);
        }
    }
}

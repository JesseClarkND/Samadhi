using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.SQLite.Accessor
{
    public class DatabaseUtilities
    {
        public static int SafeMapToInt32(Dictionary<string, object> vals, string key)
        {
            try
            {
                if (vals.ContainsKey(key) == false)
                    throw new Exception("The key [" + key + "] is not found in the provided collection.");

                return Convert.ToInt32(vals[key]);
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to map " + key + " to an integer value. Value: " + vals[key] + " Exception: " + ex.Message);
            }
        }

        public static double SafeMapToDouble(Dictionary<string, object> vals, string key)
        {
            try
            {
                if (vals.ContainsKey(key) == false)
                    throw new Exception("The key [" + key + "] is not found in the provided collection.");

                return Convert.ToDouble(vals[key]);
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to map " + key + " to an integer value. Value: " + vals[key] + " Exception: " + ex.Message);
            }
        }

        public static String SafeMapToString(Dictionary<string, object> vals, string key)
        {
            try
            {
                String returnVal = Convert.ToString(vals[key]);
                if (returnVal == null)
                    returnVal = "";
                return returnVal;
            }
            catch
            {
                // If a string, support null values and missing keys by returning empty string.
            }
            return "";
        }

        public static Boolean SafeMapToBoolean(Dictionary<string, object> vals, string key)
        {
            try
            {
                Boolean returnVal = Convert.ToString(vals[key]) == "1";
                return returnVal;
            }
            catch
            {
                // If a string, support null values and missing keys by returning false.
            }
            return false;
        }

        public static DateTime? SafeMapToNullableDateTime(Dictionary<string, object> vals, string key)
        {
            try
            {
                if (vals.ContainsKey(key) == false)
                    return null;

                object obj = vals[key];

                if (obj == null)
                    return null;

                try
                {
                    return new DateTime?(Convert.ToDateTime(obj));
                }
                catch
                {
                    return null;
                }
            }
            catch
            {
                // If a string, support null values and missing keys by returning empty string.
            }
            return null;
        }

        public static byte[] SafeMapToBinary(Dictionary<string, object> vals, string key)
        {
            try
            {
                byte[] returnVal = (byte[])vals[key];
                if (returnVal == null)
                    returnVal = null;
                return returnVal;
            }
            catch
            {
                // If a string, support null values and missing keys by returning empty string.
            }
            return null;
        }

        public static byte[] SafeMapToBinary(object binaryObj)
        {
            try
            {
                byte[] returnVal = (byte[])binaryObj;
                if (returnVal == null)
                    returnVal = null;
                return returnVal;
            }
            catch
            {
                // If a string, support null values and missing keys by returning empty string.
            }
            return null;
        }

        public static int SafeMapToInt32(object intObj, string fieldName)
        {
            try
            {
                return Convert.ToInt32(intObj);
            }
            catch
            {
                throw new Exception("Unable to map to an integer value. field:" + fieldName);
            }
        }

        public static double SafeMapToDouble(object intObj)
        {
            try
            {
                return Convert.ToDouble(intObj);
            }
            catch
            {
                return 0.0;
                //throw new Exception("Unable to map to an double value.");
            }
        }

        public static string SafeMapToString(object strObj)
        {
            try
            {
                string returnVal = Convert.ToString(strObj);
                if (returnVal == null)
                    returnVal = "";
                return returnVal;
            }
            catch
            {
                // If a string, support null values and missing keys by returning empty string.
            }
            return "";
        }

        public static Boolean SafeMapToBoolean(object strObj)
        {
            try
            {
                Boolean returnVal = Convert.ToString(strObj) == "1";
                return returnVal;
            }
            catch
            {
                // If a string, support null values and missing keys by returning false.
            }
            return false;
        }

        public static DateTime? SafeMapToNullableDateTime(object date)
        {
            try
            {
                if (date == null)
                    return null;

                try
                {
                    return new DateTime?(Convert.ToDateTime(date));
                }
                catch
                {
                    return null;
                }
            }
            catch
            {
                // If a string, support null values and missing keys by returning empty string.
            }
            return null;
        }
    }
}

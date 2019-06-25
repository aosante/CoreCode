using System;
using System.Collections.Generic;

namespace DataAccess.Mapper
{
    public abstract class EntityMapper
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Testing for the commit. </summary>
        ///
        /// <remarks>   Celopez </remarks>
        ///
        /// <param name="dic">      The dic. </param>
        /// <param name="attName">  Name of the att. </param>
        ///
        /// <returns> </returns>
        ///-------------------------------------------------------------------------------------------------

        protected string GetStringValue(Dictionary<string, object> dic, string attName)
        {
            var val = dic[attName];
            if (dic.ContainsKey(attName) && val is string)
                return (string) val;
            return "";
        }

        protected decimal GetDecimalValue(Dictionary<string, object> dic, string attName)
        {
            var val = dic[attName];
            if (dic.ContainsKey(attName) && (val is decimal))
                return (decimal)dic[attName];
            return -1;
        }

        protected int GetIntValue(Dictionary<string, object> dic, string attName)
        {
            var val = dic[attName];
            if (dic.ContainsKey(attName) && (val is int || val is decimal))
                return (int) dic[attName];
            return -1;
        }

        protected bool GetBoolValue(Dictionary<string, object> dic, string attName)
        {
            var val = dic[attName];
            if (dic.ContainsKey(attName) && (val is bool)){
                return (bool) dic[attName];
            }
            return false;
        }

        protected double GetDoubleValue(Dictionary<string, object> dic, string attName)
        {
            var val = dic[attName];
            if (dic.ContainsKey(attName) && val is double)
                return (double) dic[attName];

            return -1;
        }

        protected DateTime GetDateValue(Dictionary<string, object> dic, string attName)
        {
            var val = dic[attName];
            if (dic.ContainsKey(attName) && val is DateTime)
                return (DateTime) dic[attName];

            return DateTime.Now;
        }
    }
}
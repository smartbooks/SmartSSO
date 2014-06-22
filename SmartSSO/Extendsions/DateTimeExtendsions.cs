// 
// Copyright (c) 2014,SmartBooks
// All rights reserved.
// 
// 文件名称：DateTimeExtendsions.cs
// 项目名称：WY.DC
// 摘      要：简要描述本文件的内容
// 
// 当前版本：1.0
// 作      者：ya wang
// 完成日期：2014年05月05日
// 

using System;

namespace SmartSSO.Extendsions
{
    public static class DateTimeExtendsions
    {
        public static int ToUnixTimeStamp(this DateTime dateTime)
        {
            var startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            return (int)(dateTime - startTime).TotalSeconds;
        }

        public static DateTime ToDateTime(this long unixTimeStamp)
        {
            var dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            var toNow = new TimeSpan(unixTimeStamp);
            return dtStart.Add(toNow);
        }

        public static DateTime ToDateTime(this string unixTimeStamp)
        {
            return ToDateTime(long.Parse(unixTimeStamp));
        }
    }
}
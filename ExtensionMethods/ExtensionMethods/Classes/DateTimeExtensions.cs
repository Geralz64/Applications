using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
namespace System
{
    static class DateTimeExtensions
    {
        public static string ToXmlDateTime(this DateTime dateTime)
        {

            return XmlConvert.ToString(dateTime, XmlDateTimeSerializationMode.Utc);

        }

        public static string ToXmlDateTime(this DateTime dateTime, XmlDateTimeSerializationMode mode)
        {

            return XmlConvert.ToString(dateTime, mode);

        }

    }
}

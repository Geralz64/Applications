using System;
using System.Collections.Generic;
using System.Text;
using Json;
namespace DelegatesAndEvents
{
    public static class ObjectExtensions
    {

        public static string ToJsonString(this object obj)
        {
            return JsonConvert.SerializeObject(obj);

        }

        public static string GetJsonTypeDescription(this object obj)
        {

            var description = obj.GetType().GetDescription();

            return description.ToJsonString();

        }


    }
}

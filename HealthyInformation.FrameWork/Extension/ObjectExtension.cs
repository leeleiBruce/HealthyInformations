using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthyInformation.Utility;

namespace HealthyInformation.FrameWork.Extension
{
    public static class ObjectExtension
    {
        public static async Task<T> DeepCopy<T>(this T source) where T : class
        {
            string jsonSource = await SerializeHelper.JsonSerialize<T>(source);
            return await SerializeHelper.JsonDeserialize<T>(jsonSource);
        }
    }
}

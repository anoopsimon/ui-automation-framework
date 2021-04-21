using Automation.Core.Web;
using JsonDiffPatchDotNet;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Automation.Core.Utils
{
    public class JsonUtil
    {
        public static T Deserialize<T>(string json) where T : new()
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
        
        public static string Serialize<T>(T jsonString) where T : class
        {
            return JsonConvert.SerializeObject(jsonString);
        }

        public static bool IsValidJson(string s)
        {
            try
            {
                JToken.Parse(s);
                return true;
            }

            catch (JsonReaderException ex)
            {
                return false;
            }
        }

        public static JToken Compare(string expectedJSON, string actualJSON)
        {

            if (!IsValidJson(expectedJSON)) throw new FrameworkException($"Expected JSON- Not valid Json string");
            if (!IsValidJson(actualJSON)) throw new FrameworkException($"Actual JSON - Not valid Json string");

            var jdp = new JsonDiffPatch();
            JToken diffResult = jdp.Diff(expectedJSON, actualJSON);
            return diffResult;
        }

    }
}

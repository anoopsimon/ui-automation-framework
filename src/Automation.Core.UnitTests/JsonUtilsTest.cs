using Automation.Core.Utils;
using Automation.Core.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using System;
using System.IO;
using System.Reflection;

namespace Automation.Core.UnitTests
{
    [TestClass]
    public class JsonUtilsTest
    {


        [TestMethod]
        public void ValidateJSONCompare()
        {
            var runDir = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

            var expectedJson = File.ReadAllText($"{runDir}/Data/compareActual.json");
            var actualJson = File.ReadAllText($"{runDir}/Data/compareExp.json");

            var result = JsonUtil.Compare(expectedJson, actualJson);


            
        }
    }
}

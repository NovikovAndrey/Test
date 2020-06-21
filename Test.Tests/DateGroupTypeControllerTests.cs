using System;
using System.Collections.Generic;
using Test_Project_Requirements.Controllers;
using Test_Project_Requirements.Models;
using Xunit;

namespace Test.Tests
{
    public class DateGroupTypeControllerTests
    {
        [Fact]
        public void DateGroupTypeController_Get_Enum()
        {
            List<String> expResult = new List<string>();
            foreach (string Name in Enum.GetNames(typeof(DateGroupType)))
            {
                expResult.Add(Name);
            }
            DateGroupTypeController controller = new DateGroupTypeController();
            var result = controller.Get();
            Assert.Equal(result, expResult);
        }
    }
}

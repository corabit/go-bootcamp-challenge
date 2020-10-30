using System;
using src.Controllers;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using src.Services;
using Moq;
using System.Collections.Generic;
using src.Model;
using System.Linq;

namespace test
{
    public class ColorTest
    {
        [Fact]
        public async void GetReturns_ListOfColors()
        {
            var mockColorService = new Mock<IColorService>();
            mockColorService.Setup(c => c.GetColors()).ReturnsAsync(ColorTestData.GetReturns_ListOfColors());
            var controller = new ColorController(mockColorService.Object);
            var actionResult = await controller.GetList();
            // Status Code 200
            Assert.IsType<OkObjectResult>(actionResult);
            var result = actionResult as OkObjectResult;
            // If is a list of colors
            Assert.IsType<List<Color>>(result.Value);

            var colors = result.Value as List<Color>;

            // Validate data Ids
            Assert.Collection<Color>(
                colors,
                item => Assert.Contains("v3rpf4v7v", item.Id),
                item => Assert.Contains("je502ioe4", item.Id),
                item => Assert.Contains("63a5l9qjv", item.Id),
                item => Assert.Contains("5sd3m248d", item.Id),
                item => Assert.Contains("neh72i6o7", item.Id)
            );
        }

        [Theory()]
        [InlineData("7e1e9c")]
        [InlineData("15b01a")]
        [InlineData("0343df")]
        [InlineData("ff81c0")]
        [InlineData("653700")]
        public async void GetReturns_Color(string hex)
        {
            var mockColorService = new Mock<IColorService>();
            var expectedColor = ColorTestData.GetReturns_ListOfColors().First(c => c.Hex.Substring(1) == hex);
            mockColorService.Setup(c => c.GetColor(hex)).ReturnsAsync(expectedColor);
            var controller = new ColorController(mockColorService.Object);
            var actionResult = await controller.Get(hex);
            // Status Code 200
            Assert.IsType<OkObjectResult>(actionResult);
            var result = actionResult as OkObjectResult;
            // If the result calue is a color
            Assert.IsType<Color>(result.Value);

            var resultColor = result.Value as Color;
            // Color result is the expected color
            Assert.Equal(resultColor, expectedColor);
        }

        [Theory()]
        [InlineData("8e1e9c")]
        [InlineData("85b01a")]
        [InlineData("8343df")]
        [InlineData("8f81c0")]
        [InlineData("853700")]
        public async void GetReturns_ColorNotFound(string hex)
        {
            var mockColorService = new Mock<IColorService>();
            
            mockColorService.Setup(c => c.GetColor(hex)).ReturnsAsync((Color)null);
            var controller = new ColorController(mockColorService.Object);
            var actionResult = await controller.Get(hex);
            // Status Code 404
            Assert.IsType<NotFoundResult>(actionResult);
        }
    }

    public static class ColorTestData {
        public static  IEnumerable<Color> GetReturns_ListOfColors() {
            return new List<Color>() {
              new Color { Id = "v3rpf4v7v", Name = "purple", Hex =  "#7e1e9c" },
              new Color { Id = "je502ioe4", Name = "green", Hex =  "#15b01a" },
              new Color { Id = "63a5l9qjv", Name = "blue", Hex =  "#0343df" },
              new Color { Id = "5sd3m248d", Name = "pink", Hex =  "#ff81c0" },
              new Color { Id = "neh72i6o7", Name = "brown", Hex =  "#653700" }
            };
        }
    }
}

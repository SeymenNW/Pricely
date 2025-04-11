using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Moq.Protected;
using Pricely.Core.Services.Merchants;
using Pricely.Core.Services.Merchants.Elgiganten;
using Pricely.Libraries.Shared.Models;
using Xunit;

namespace Pricely.Core.Tests.Services.Elgiganten
{
    public class ElgigantenServiceTests
    {
        private readonly ElgigantenService _elgigantenService;
        private readonly Mock<HttpMessageHandler> _mockHttpMessageHandler;
        private readonly HttpClient _mockHttpClient;

        public ElgigantenServiceTests()
        {
            _mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            _mockHttpClient = new HttpClient(_mockHttpMessageHandler.Object);
            _elgigantenService = new ElgigantenService(_mockHttpClient);
        }


        //This test is not finished.
        #region Searching Tests
        [Fact]
        public async Task GetProductsFromSearchAsync_ReturnTwoProducts()
        {
            // Arrange
          

            // Act
    

            // Assert
         
        }
        #endregion
    }
}

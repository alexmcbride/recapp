using iRacingSdkWrapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.IO;

namespace RecapApp.Tests
{
    [TestClass]
    public class RecapServiceTests
    {
        private Mock<ISdkWrapper> sdk;
        private RecapService recapService;

        [TestInitialize]
        public void Setup()
        {
            sdk = new Mock<ISdkWrapper>();
            recapService = new RecapService(sdk.Object);
        }

        [TestMethod]
        public void SessionInfoUpdateSetsTrackName()
        {
            var sessionInfo = File.ReadAllText("SessionInfo.yaml");

            sdk.Raise(s => s.SessionInfoUpdated += null, new SdkWrapper.SessionInfoUpdatedEventArgs(sessionInfo, 0));

            Assert.AreEqual("Suzuka International Racing Course", recapService.SessionInfo.WeekendInfo.TrackDisplayName);
        }
    }
}

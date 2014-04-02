using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Loco.Tests
{
    [TestClass]
    public class SynchronizedStoreContainerTests
    {
        private static Mock<ILocalStoreConfig> _localStoreConfigMock;
        private static Mock<ICloudStoreConfig> _cloudStoreConfigMock;

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            _localStoreConfigMock = new Mock<ILocalStoreConfig>();
            _cloudStoreConfigMock = new Mock<ICloudStoreConfig>();

            var localStoreMock = new Mock<ILocalStore<Item>>();
            var cloudStoreMock = new Mock<ICloudStore<Item>>();

            _localStoreConfigMock.Setup(x => x.GetLocalStore<Item>()).Returns(localStoreMock.Object);
            _cloudStoreConfigMock.Setup(x => x.GetCloudStore<Item>()).Returns(cloudStoreMock.Object);
        }

        [TestInitialize]
        public void TestInitialize()
        {
            SyncStoreContainer.Clear();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RegisterType_LocalStore_Null()
        {
            SyncStoreContainer.RegisterType<Item>(null, _cloudStoreConfigMock.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RegisterType_CloudStore_Null()
        {
            SyncStoreContainer.RegisterType<Item>(_localStoreConfigMock.Object, null);
        }

        [TestMethod]
        public void Get_Registered()
        {
            SyncStoreContainer.RegisterType<Item>(_localStoreConfigMock.Object, _cloudStoreConfigMock.Object);

            var synchronizedStore = SyncStoreContainer.GetSyncStore<Item>();

            Assert.IsNotNull(synchronizedStore);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Get_Not_Registered()
        {
            SyncStoreContainer.GetSyncStore<Item>();
        }

        [TestMethod]
        public void Get_Same_Instance()
        {
            SyncStoreContainer.RegisterType<Item>(_localStoreConfigMock.Object, _cloudStoreConfigMock.Object);

            var synchronizedStore1 = SyncStoreContainer.GetSyncStore<Item>();
            var synchronizedStore2 = SyncStoreContainer.GetSyncStore<Item>();

            Assert.AreEqual(synchronizedStore1, synchronizedStore2);
        }
    }
}
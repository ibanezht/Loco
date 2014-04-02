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
            SynchronizedStoreContainer.Clear();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RegisterType_LocalStore_Null()
        {
            SynchronizedStoreContainer.RegisterType<Item>(null, _cloudStoreConfigMock.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RegisterType_CloudStore_Null()
        {
            SynchronizedStoreContainer.RegisterType<Item>(_localStoreConfigMock.Object, null);
        }

        [TestMethod]
        public void Get_Registered()
        {
            SynchronizedStoreContainer.RegisterType<Item>(_localStoreConfigMock.Object, _cloudStoreConfigMock.Object);

            var synchronizedStore = SynchronizedStoreContainer.GetSynchronizedStore<Item>();

            Assert.IsNotNull(synchronizedStore);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Get_Not_Registered()
        {
            SynchronizedStoreContainer.GetSynchronizedStore<Item>();
        }

        [TestMethod]
        public void Get_Same_Instance()
        {
            SynchronizedStoreContainer.RegisterType<Item>(_localStoreConfigMock.Object, _cloudStoreConfigMock.Object);

            var synchronizedStore1 = SynchronizedStoreContainer.GetSynchronizedStore<Item>();
            var synchronizedStore2 = SynchronizedStoreContainer.GetSynchronizedStore<Item>();

            Assert.AreEqual(synchronizedStore1, synchronizedStore2);
        }
    }
}
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Loco.Tests
{
    [TestClass]
    public class SynchronizedStoreContainerTests
    {
        [TestInitialize]
        public void TestInitialize()
        {
            SynchronizedStoreContainer.Clear();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RegisterType_LocalStore_Null()
        {
            var cloudStoreConfigMock = new Mock<ICloudStoreConfig>();

            SynchronizedStoreContainer.RegisterType<FakeModel>(null, cloudStoreConfigMock.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RegisterType_CloudStore_Null()
        {
            var localStoreConfigMock = new Mock<ILocalStoreConfig>();

            SynchronizedStoreContainer.RegisterType<FakeModel>(localStoreConfigMock.Object, null);
        }

        [TestMethod]
        public void Get_Registered()
        {
            var localStoreConfigMock = new Mock<ILocalStoreConfig>();
            var cloudStoreConfigMock = new Mock<ICloudStoreConfig>();

            SynchronizedStoreContainer.RegisterType<FakeModel>(localStoreConfigMock.Object, cloudStoreConfigMock.Object);

            var synchronizedStore = SynchronizedStoreContainer.GetSynchronizedStore<FakeModel>();

            Assert.IsNotNull(synchronizedStore);
        }

        [TestMethod]
        public void Get_Not_Registered()
        {
            var synchronizedStore = SynchronizedStoreContainer.GetSynchronizedStore<FakeModel>();

            Assert.IsNull(synchronizedStore);
        }

        [TestMethod]
        public void Get_Twice_Equals()
        {
            var synchronizedStore1 = SynchronizedStoreContainer.GetSynchronizedStore<FakeModel>();
            var synchronizedStore2 = SynchronizedStoreContainer.GetSynchronizedStore<FakeModel>();

            Assert.AreEqual(synchronizedStore1, synchronizedStore2);
        }
    }
}
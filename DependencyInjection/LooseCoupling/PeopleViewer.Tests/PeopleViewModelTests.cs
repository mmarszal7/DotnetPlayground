using System.Collections.Generic;
using Common;
using NUnit.Framework;
using System.Linq;
using Moq;

namespace PeopleViewer.Tests
{
    public class PeopleViewModelTests
    {
        private Mock<IPersonReader> readerMock = new Mock<IPersonReader>();

        public PeopleViewModelTests()
        {
            var result = new List<Person>() { new Person(), new Person() };
            readerMock.Setup(t => t.GetPeople()).Returns(result);
        }

        [Test]
        public void RefreshPeople_OnExecute_PeopleIsPopulated()
        {
            // Arrange
            IPersonReader reader = new FakeReader();
            var vm = new PeopleViewModel(reader);

            // Act
            vm.RefreshPeople();

            // Assert
            Assert.IsNotNull(vm.People);
            Assert.AreEqual(2, vm.People.Count());
        }

        [Test]
        public void ClearPeople_OnExecute_PeopleIsEmpty()
        {
            // Arrange
            IPersonReader reader = readerMock.Object;

            var vm = new PeopleViewModel(reader);
            vm.RefreshPeople();
            Assert.AreEqual(2, vm.People.Count());

            // Act
            vm.ClearPeople();

            // Assert
            Assert.AreEqual(0, vm.People.Count());
        }
    }
}
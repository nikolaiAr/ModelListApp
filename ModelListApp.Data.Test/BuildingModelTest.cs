using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelListApp.Data.Test
{
    [TestFixture]
    public class BuildingModelTest
    {
        private BuildingModel _item;

        [SetUp]
        public void Init()
        {
            _item = new BuildingModel();
        }

        [Test]
        public void CreateParcel_IdIsRequired()
        {
            var value = _item.Id.ToString();

            Assert.That(value, Is.Not.Empty);
        }

        [Test]
        public void CreateParcel_IdIsUnique()
        {
            var itemList = new List<BuildingModel>();
            for (int i = 0; i < 5; i++)
                itemList.Add(new BuildingModel());
            var value = itemList.GroupBy(x => x.Id).Where(g => g.Count() > 1).ToList();

            Assert.That(value, Is.Empty);
        }

        [Test]
        public void CreateParcel_TypeIsRight()
        {
            var value = _item.Type;

            Assert.That(Constants.Enums.Types.Building, Is.EqualTo(value));
        }

        [Test]
        public void CreateParcel_DefaultFloorCountIsZero()
        {
            var value = _item.FloorCount;

            Assert.That(value, Is.Zero);
        }

        [Test]
        public void CreateParcel_DefaultAddressIsNull()
        {
            var value = _item.Address;

            Assert.That(value, Is.Null);
        }

        [Test]
        public void CreateParcel_DefaultListErrorsIsNotNull()
        {
            var value = Model.ListErrors;

            Assert.That(value, Is.Not.Empty);
        }

        [Test]
        public void CreateParcel_ZeroFloorCountErrorIsCreated()
        {
            var value = Model.ListErrors.Where(x => x.ModelId == _item.Id && x.FieldName == nameof(_item.FloorCount));

            Assert.That(value, Is.Not.Empty);
        }

        [Test]
        public void CreateParcel_NullAddressErrorIsCreated()
        {
            var value = Model.ListErrors.Where(x => x.ModelId == _item.Id && x.FieldName == nameof(_item.Address));

            Assert.That(value, Is.Not.Empty);
        }

        [Test]
        public void CreateParcel_ZeroFloorCountErrorHasRightModelId()
        {
            Error value = Model.ListErrors.Where(x => x.ModelId == _item.Id && x.FieldName == nameof(_item.FloorCount)).FirstOrDefault();

            Assert.That(_item.Id, Is.EqualTo(value.ModelId));
        }

        [Test]
        public void CreateParcel_NullAddressErrorHasRightModelId()
        {
            Error value = Model.ListErrors.Where(x => x.ModelId == _item.Id && x.FieldName == nameof(_item.Address)).FirstOrDefault();

            Assert.That(_item.Id, Is.EqualTo(value.ModelId));
        }

        [Test]
        public void CreateParcel_ZeroFloorCountErrorHasRightFieldName()
        {
            Error value = Model.ListErrors.Where(x => x.ModelId == _item.Id && x.FieldName == nameof(_item.FloorCount)).FirstOrDefault();

            Assert.That(nameof(_item.FloorCount), Is.EqualTo(value.FieldName));
        }

        [Test]
        public void CreateParcel_NullAddressErrorHasRightFieldName()
        {
            Error value = Model.ListErrors.Where(x => x.ModelId == _item.Id && x.FieldName == nameof(_item.Address)).FirstOrDefault();

            Assert.That(nameof(_item.Address), Is.EqualTo(value.FieldName));
        }

        [Test]
        public void CreateParcel_ZeroFloorCountErrorHasDescription()
        {
            Error value = Model.ListErrors.Where(x => x.ModelId == _item.Id && x.FieldName == nameof(_item.FloorCount)).FirstOrDefault();

            Assert.That(value.Description, Is.Not.Empty);
        }

        [Test]
        public void CreateParcel_NullAddressErrorHasDescription()
        {
            Error value = Model.ListErrors.Where(x => x.ModelId == _item.Id && x.FieldName == nameof(_item.Address)).FirstOrDefault();

            Assert.That(value.Description, Is.Not.Empty);
        }

        [Test]
        public void ValidateParcel_FloorCountErrorIsRemoved()
        {
            _item.FloorCount = 5;
            var value = Model.ListErrors.Where(x => x.ModelId == _item.Id && x.FieldName == nameof(_item.FloorCount));

            Assert.That(value, Is.Empty);
        }

        [Test]
        public void ValidateParcel_WrongFloorCountErrorIsCreated()
        {
            _item.FloorCount = -5;
            var value = Model.ListErrors.Where(x => x.ModelId == _item.Id && x.FieldName == nameof(_item.FloorCount));

            Assert.That(value, Is.Not.Empty);
        }

        [Test]
        public void ValidateParcel_AddressErrorIsRemoved()
        {
            _item.Address = "Address";
            var value = Model.ListErrors.Where(x => x.ModelId == _item.Id && x.FieldName == nameof(_item.Address));

            Assert.That(value, Is.Empty);
        }
    }
}

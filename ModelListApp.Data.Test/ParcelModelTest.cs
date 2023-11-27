using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelListApp.Data.Test
{
    [TestFixture]
    public class ParcelModelTest
    {
        private ParcelModel _item;

        [SetUp]
        public void Init()
        {
            _item = new ParcelModel();
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
            var itemList = new List<ParcelModel>();
            for (int i = 0; i < 5; i++)
                itemList.Add(new ParcelModel());
            var value = itemList.GroupBy(x => x.Id).Where(g => g.Count() > 1).ToList();

            Assert.That(value, Is.Empty);
        }

        [Test]
        public void CreateParcel_TypeIsRight()
        {
            var value = _item.Type;

            Assert.That(Constants.Enums.Types.Parcel, Is.EqualTo(value));
        }

        [Test]
        public void CreateParcel_DefaultNumberIsNull()
        {
            var value = _item.Number;

            Assert.That(value, Is.Null);
        }

        [Test]
        public void CreateParcel_DefaultLocationIsNull()
        {
            var value = _item.Location;

            Assert.That(value, Is.Null);
        }

        [Test]
        public void CreateParcel_DefaultListErrorsIsNotNull()
        {
            var value = Model.ListErrors;

            Assert.That(value, Is.Not.Empty);
        }

        [Test]
        public void CreateParcel_NullNumberErrorIsCreated()
        {
            var value = Model.ListErrors.Where(x => x.ModelId == _item.Id && x.FieldName == nameof(_item.Number));

            Assert.That(value, Is.Not.Empty);
        }

        [Test]
        public void CreateParcel_NullLocationErrorIsCreated()
        {
            var value = Model.ListErrors.Where(x => x.ModelId == _item.Id && x.FieldName == nameof(_item.Location));

            Assert.That(value, Is.Not.Empty);
        }

        [Test]
        public void CreateParcel_NullNumberErrorHasRightModelId()
        {
            Error value = Model.ListErrors.Where(x => x.ModelId == _item.Id && x.FieldName == nameof(_item.Number)).FirstOrDefault();

            Assert.That(_item.Id, Is.EqualTo(value.ModelId));
        }

        [Test]
        public void CreateParcel_NullLocationErrorHasRightModelId()
        {
            Error value = Model.ListErrors.Where(x => x.ModelId == _item.Id && x.FieldName == nameof(_item.Location)).FirstOrDefault();

            Assert.That(_item.Id, Is.EqualTo(value.ModelId));
        }

        [Test]
        public void CreateParcel_NullNumberErrorHasRightFieldName()
        {
            Error value = Model.ListErrors.Where(x => x.ModelId == _item.Id && x.FieldName == nameof(_item.Number)).FirstOrDefault();

            Assert.That(nameof(_item.Number), Is.EqualTo(value.FieldName));
        }

        [Test]
        public void CreateParcel_NullLocationErrorHasRightFieldName()
        {
            Error value = Model.ListErrors.Where(x => x.ModelId == _item.Id && x.FieldName == nameof(_item.Location)).FirstOrDefault();

            Assert.That(nameof(_item.Location), Is.EqualTo(value.FieldName));
        }

        [Test]
        public void CreateParcel_NullNumberErrorHasDescription()
        {
            Error value = Model.ListErrors.Where(x => x.ModelId == _item.Id && x.FieldName == nameof(_item.Number)).FirstOrDefault();

            Assert.That(value.Description, Is.Not.Empty);
        }

        [Test]
        public void CreateParcel_NullLocationErrorHasDescription()
        {
            Error value = Model.ListErrors.Where(x => x.ModelId == _item.Id && x.FieldName == nameof(_item.Location)).FirstOrDefault();

            Assert.That(value.Description, Is.Not.Empty);
        }

        [Test]
        public void ValidateParcel_NumberErrorIsRemoved()
        {
            _item.Number = "123";
            var value = Model.ListErrors.Where(x => x.ModelId == _item.Id && x.FieldName == nameof(_item.Number));

            Assert.That(value, Is.Empty);
        }

        [Test]
        public void ValidateParcel_LocationErrorIsRemoved()
        {
            _item.Location = "Location";
            var value = Model.ListErrors.Where(x => x.ModelId == _item.Id && x.FieldName == nameof(_item.Location));

            Assert.That(value, Is.Empty);
        }
    }
}

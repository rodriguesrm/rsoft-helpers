using RSoft.Helpers.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Xunit;

namespace RSoft.Helpers.Test.Extensions
{

    /// <summary>
    /// Reflection JSon extensions tests
    /// </summary>
    public class JsonExtensionTest
    {

        #region Tests

        [Fact]
        public void JsonDeserializeWhenJsonIsValisSuccess()
        {

            string name1 = "João";
            string name2 = "Maria";

            string json = "[";
            json += "{ \"id\": 1,\"name\": \"" + name1 + "\", \"createdOn\": \"1976-11-13T16:45Z\", \"isActive\": true},";
            json += "{ \"Id\": 2,\"Name\": \"" + name2 + "\", \"CreatedOn\": \"1983-05-19T13:30Z\", \"IsActive\": false}";
            json += "]";

            IEnumerable<ModelStub> result = json.JsonDeserialize<IEnumerable<ModelStub>>();
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
            Assert.Equal(name1, result.First().Name);
            Assert.Equal(name2, result.Last().Name);

        }

        [Fact]
        public void JsonDeserializeWhenJSonIsValicWithJsonOptionsCaseSensitiveOnPartialSuccess()
        {

            string name1 = "João";
            string name2 = "Maria";

            string json = "[";
            json += "{ \"id\": 1,\"name\": \"" + name1 + "\", \"createdOn\": \"1976-11-13T16:45Z\", \"isActive\": true},";
            json += "{ \"Id\": 2,\"Name\": \"" + name2 + "\", \"CreatedOn\": \"1983-05-19T13:30Z\", \"IsActive\": false}";
            json += "]";

            IEnumerable<ModelStub> result = json.JsonDeserialize<IEnumerable<ModelStub>>(new JsonSerializerOptions() { PropertyNameCaseInsensitive = false });
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
            Assert.Equal(0, result.First().Id);
            Assert.True(string.IsNullOrWhiteSpace(result.First().Name));
            Assert.Equal(name2, result.Last().Name);

        }

        [Fact]
        public void JsonDeserializeWhenJSonIsInValidThrowJsonException()
        {
            string json = "This is not a valid json";
            Assert.Throws<JsonException>(() => json.JsonDeserialize<ModelStub>());
        }

        [Fact]
        public void JsonDeserializeWhenJsonIsNullReturnNull()
        {

            string json = null;

            IEnumerable<ModelStub> result = json.JsonDeserialize<IEnumerable<ModelStub>>();
            Assert.Null(result);

        }

        [Fact]
        public void JSonSerializeSuccess()
        {
            ModelStub model = new ModelStub() { Id = 1, CreatedOn = DateTime.Now, Name = "João", IsActive = true };
            string json = model.JsonSerialize();
            Assert.NotNull(json);
            Assert.NotEmpty(json);
            ModelStub check = json.JsonDeserialize<ModelStub>();
            Assert.NotNull(check);
            Assert.Equal(model.Id, check.Id);
            Assert.Equal(model.CreatedOn, check.CreatedOn);
            Assert.Equal(model.Name, check.Name);
            Assert.Equal(model.IsActive, check.IsActive);
        }

        [Fact]
        public void JsonSerializeWhenObjectIsNullReturnNull()
        {
            ModelStub model = null;
            string json = model.JsonSerialize();
            Assert.Null(json);
        }

        #endregion

        #region Stubs

        private class ModelStub
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public DateTime CreatedOn { get; set; }
            public bool IsActive { get; set; }
        }

        #endregion

    }

}

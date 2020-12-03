using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void JsonSerialize()
        {
            var input = new laba1.Input
            {
                K = 35,
                Sums = new[] { 1m, 2m, 3.5m, 4.8m, 9.999m, 99m },
                Muls = new[] { 1, 2, 34, 42, 34, 41243 },
            };
            var serialize = new laba1.JsonSerializator();
            var serializedObject = serialize.Serialize(input);
            Assert.AreEqual(serializedObject,
                "{\"K\":35,\"Sums\":[1,2,3.5,4.8,9.999,99],\"Muls\":[1,2,34,42,34,41243]}");
        }
        [TestMethod]
        public void JsonDeSerialize()
        {
            var serialize = new laba1.JsonSerializator();
            var deserializedObject = serialize.Deserialize<laba1.Input>(
                "{\"K\":35,\"Sums\":[1,2,3.5,4.8,9.999,99],\"Muls\":[1,2,34,42,34,41243]}");
            var flag = true;
            var input = new laba1.Input
            {
                K = 35,
                Sums = new[] { 1m, 2m, 3.5m, 4.8m, 9.999m, 99m },
                Muls = new[] { 1, 2, 34, 42, 34, 41243 },
            };
            if (input.K != deserializedObject.K)
            {
                flag = false;
            }
            for (var i = 0; i < input.Sums.Length; i++)
            {
                if (input.Sums[i] != deserializedObject.Sums[i])
                {
                    flag = false;
                }
            }
            for (var i = 0; i < input.Muls.Length; i++)
            {
                if (input.Muls[i] != deserializedObject.Muls[i])
                {
                    flag = false;
                }
            }
            Assert.AreEqual(flag, true);
        }
        [TestMethod]
        public void AddZerosJson()
        {
            var json = "{\"SumResult\":30,\"MulResult\":4,\"SortedInputs\":[1,1.01,2.02,4]}";
            json = laba1.Program.AddZeros(json);
            Assert.AreEqual("{\"SumResult\":30.0,\"MulResult\":4,\"SortedInputs\":[1.0,1.01,2.02,4.0]}", json);
        }
        [TestMethod]
        public void XmlSerialize()
        {
            var input = new laba1.Input
            {
                K = 35,
                Sums = new[] { 1m, 2m, 3.5m, 4.8m, 9.999m, 99m },
                Muls = new[] { 1, 2, 34, 42, 34, 123, 41243 },
            };
            var serializer = new laba1.XmlSerializator();
            var xml = serializer.Serialize(input);
            Assert.AreEqual(xml, "<Input><K>35</K><Sums><decimal>1</decimal><decimal>2</decimal><decimal>3.5</decimal>" +
                "<decimal>4.8</decimal><decimal>9.999</decimal><decimal>99</decimal></Sums><Muls><int>1</int><int>2</int>" +
                "<int>34</int><int>42</int><int>34</int><int>123</int><int>41243</int></Muls></Input>");
        }
        [TestMethod]
        public void XmlDeserialize()
        {
            var xml = "<Input><K>35</K><Sums><decimal>1</decimal><decimal>2</decimal><decimal>3.5</decimal>" +
                "<decimal>4.8</decimal><decimal>9.999</decimal><decimal>99</decimal></Sums><Muls><int>1</int><int>2</int>" +
                "<int>34</int><int>42</int><int>34</int><int>123</int><int>41243</int></Muls></Input>";
            var serializer = new laba1.XmlSerializator();
            var deserializedObject = serializer.Deserialize<laba1.Input>(xml);
            var flag = true;
            var input = new laba1.Input
            {
                K = 35,
                Sums = new[] { 1m, 2m, 3.5m, 4.8m, 9.999m, 99m },
                Muls = new[] { 1, 2, 34, 42, 34, 123, 41243 },
            };
            if (input.K != deserializedObject.K)
            {
                flag = false;
            }
            for (var i = 0; i < input.Sums.Length; i++)
            {
                if (input.Sums[i] != deserializedObject.Sums[i])
                {
                    flag = false;
                }
            }
            for (var i = 0; i < input.Muls.Length; i++)
            {
                if (input.Muls[i] != deserializedObject.Muls[i])
                {
                    flag = false;
                }
            }
            Assert.AreEqual(flag, true);
        }
    }
}

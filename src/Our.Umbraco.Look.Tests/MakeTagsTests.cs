﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Our.Umbraco.Look.Models;
using System.Linq;

namespace Our.Umbraco.Look.Tests
{
    [TestClass]
    public class MakeTagsTests
    {
        [TestMethod]
        public void String_Params()
        {
            var tags = TagQuery.MakeTags("colour:red", "colour:green", "colour:blue");

            Assert.AreEqual(3, tags.Length);

            Assert.AreEqual("colour", tags[0].Group);
            Assert.AreEqual("red", tags[0].Name);

            Assert.AreEqual("colour", tags[1].Group);
            Assert.AreEqual("green", tags[1].Name);

            Assert.AreEqual("colour", tags[2].Group);
            Assert.AreEqual("blue", tags[2].Name);
        }

        [TestMethod]
        public void String_Array()
        {
            var tags = TagQuery.MakeTags(new string[] { "colour:red", "colour:green", "colour:blue" });

            Assert.AreEqual(3, tags.Length);

            Assert.AreEqual("colour", tags[0].Group);
            Assert.AreEqual("red", tags[0].Name);

            Assert.AreEqual("colour", tags[1].Group);
            Assert.AreEqual("green", tags[1].Name);

            Assert.AreEqual("colour", tags[2].Group);
            Assert.AreEqual("blue", tags[2].Name);
        }
    }
}
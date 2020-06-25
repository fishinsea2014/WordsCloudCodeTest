using Jason.Common.Helper;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnitTestProject
{
    public class SaltHashHelperTest
    {
        private readonly SaltHashHelper _saltHashHelper;
        public SaltHashHelperTest()
        {
            _saltHashHelper = new SaltHashHelper();
        }

        [Fact]
        public void CreateSaltedHashShould()
        {
            HashSalt res = _saltHashHelper.GenerateSaltedHash(64, "Jason");
            Assert.True(_saltHashHelper.VerifyStr("Jason",res));
        }

        [Fact]
        public void CreateSaltedHashShouldInvalid()
        {
            HashSalt res = _saltHashHelper.GenerateSaltedHash(64, "Jason");
            res.Hash += " ";
            Assert.False(_saltHashHelper.VerifyStr("Jason", res));
        }
    }
}

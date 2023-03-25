namespace c_sharp_unit_tests_github_actions;

using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using Jose;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestMethod1()
    {
        var serviceAccountId = "ajel4hfk79lh6j0ci6aq";
        var keyId = "ajeoqmhhondlfj6alhn8";
        var now = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

        var headers = new Dictionary<string, object>()
        {
            { "kid", keyId }
        };

        var payload = new Dictionary<string, object>()
        {
            { "aud", "https://iam.api.cloud.yandex.net/iam/v1/tokens" },
            { "iss", serviceAccountId },
            { "iat", now },
            { "exp", now + 3600 }
        };

        using (var rsa = RSA.Create())
        {
            rsa.ImportFromPem(File.ReadAllText("sa.key").ToCharArray());
            string encodedToken = Jose.JWT.Encode(payload, rsa, JwsAlgorithm.PS256, headers);

            Assert.IsNotNull(encodedToken);
        }
    }
}

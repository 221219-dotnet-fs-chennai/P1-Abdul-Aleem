using BusinessLogic;
using Microsoft.Extensions.FileSystemGlobbing.Internal;
using System.Text.RegularExpressions;
namespace Testing;

[TestFixture]
public class Tests
{

    [Test]
    public void Test1()
    {
        //TokenGenerator.TokenGeneratorToken tokenGeneratorToken = new TokenGenerator.TokenGeneratorToken();
        string authId = TokenGenerator.TokenGeneratorToken();
        Regex rgx = new Regex(@"\w\d\w\d\w\w\d\w\d\w\w\d\w\d\w\w");
        bool q = rgx.Equals(authId);
        Assert.AreEqual(q, false);
    }
}

//int r3 = Basic.mul(3, 3);
//Assert.AreEqual(r3, 9);
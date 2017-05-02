using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SfdcConnect;
using System.Threading.Tasks;
using System.Data;
using System.Threading;

namespace SfdcConnectTests
{
    [TestClass]
    public class UnitTest1
    {
        private string username = "";
        private string password = "";
        private string token = "";

        #region Login Tests

        [TestMethod]
        public void SfdcConnectionNoParameters()
        {
            SfdcConnection conn = new SfdcConnection();

            conn.Username = username;
            conn.Password = password;
            conn.Token = token;

            try
            {
                conn.Open();
            }
            catch
            {
                return;
            }
            Assert.Fail();
        }

        [TestMethod]
        public void SfdcConnectionUriParameter()
        {
            SfdcConnection conn = new SfdcConnection(string.Format("https://test.salesforce.com/services/Soap/u/{0}.0/", 36));

            conn.Username = username;
            conn.Password = password;
            conn.Token = token;

            conn.Open();

            conn.Close();
        }

        [TestMethod]
        public void SfdcConnectionTestAndVersionParameters()
        {
            SfdcConnection conn = new SfdcConnection(true, 36);

            conn.Username = username;
            conn.Password = password;
            conn.Token = token;

            conn.Open();

            conn.Close();
        }

        [TestMethod]
        public void SfdcConnectionNoParametersAsync()
        {
            SfdcConnection conn = new SfdcConnection();

            conn.Username = username;
            conn.Password = password;
            conn.Token = token;

            try
            {
                conn.OpenAsync();
            }
            catch
            {
                return;
            }
            Assert.Fail();
        }

        [TestMethod]
        public void SfdcConnectionUriParameterAsync()
        {
            SfdcConnection conn = new SfdcConnection(string.Format("https://test.salesforce.com/services/Soap/u/{0}.0", 36));

            conn.Username = username;
            conn.Password = password;
            conn.Token = token;

            conn.OpenAsync();

            int i = 0;
            while (conn.State == ConnectionState.Connecting && i < 60)
            {
                Thread.Sleep(1000);
                i++;
            }

            Assert.IsTrue(conn.State == ConnectionState.Open);

            conn.Close();

            Assert.IsTrue(conn.State == ConnectionState.Closed);
        }

        [TestMethod]
        public void SfdcConnectionTestAndVersionParametersAsync()
        {
            SfdcConnection conn = new SfdcConnection(true, 36);

            conn.Username = username;
            conn.Password = password;
            conn.Token = token;

            conn.OpenAsync();

            int i = 0;
            while (conn.State == ConnectionState.Connecting && i < 60)
            {
                Thread.Sleep(1000);
                i++;
            }

            Assert.IsTrue(conn.State == ConnectionState.Open);

            conn.Close();

            Assert.IsTrue(conn.State == ConnectionState.Closed);

        }

        [TestMethod]
        public async Task SfdcConnectionNoParametersAwaitAsync()
        {
            SfdcConnection conn = new SfdcConnection();

            conn.Username = username;
            conn.Password = password;
            conn.Token = token;

            try
            {
                await conn.OpenAsync(default(CancellationToken));
            }
            catch
            {
                return;
            }
            Assert.Fail();
        }

        [TestMethod]
        public async Task SfdcConnectionUriParameterAwaitAsync()
        {
            SfdcConnection conn = new SfdcConnection(string.Format("https://test.salesforce.com/services/Soap/u/{0}.0", 36));

            conn.Username = username;
            conn.Password = password;
            conn.Token = token;

            await conn.OpenAsync(default(CancellationToken));

            int i = 0;
            while (conn.State == ConnectionState.Connecting && i < 60)
            {
                Thread.Sleep(1000);
                i++;
            }

            Assert.IsTrue(conn.State == ConnectionState.Open);

            conn.Close();

            Assert.IsTrue(conn.State == ConnectionState.Closed);
        }

        [TestMethod]
        public async Task SfdcConnectionTestAndVersionParametersAwaitAsync()
        {
            SfdcConnection conn = new SfdcConnection(true, 36);

            conn.Username = username;
            conn.Password = password;
            conn.Token = token;

            await conn.OpenAsync(default(CancellationToken));

            int i = 0;
            while (conn.State == ConnectionState.Connecting && i < 60)
            {
                Thread.Sleep(1000);
                i++;
            }

            Assert.IsTrue(conn.State == ConnectionState.Open);

            conn.Close();

            Assert.IsTrue(conn.State == ConnectionState.Closed);
        }

        #endregion

        [TestMethod]
        public void SoapApiTest()
        {
            SfdcSoapApi conn = new SfdcSoapApi(true, 36);

            conn.Username = username;
            conn.Password = password;
            conn.Token = token;

            conn.Open();

            SfdcConnect.SoapObjects.DescribeSObjectResult result = conn.describeSObject("Contact");

            conn.Close();
        }

        [TestMethod]
        public void RestApiTest()
        {
            SfdcRestApi conn = new SfdcRestApi(true, 36);

            conn.Username = username;
            conn.Password = password;
            conn.Token = token;

            conn.Open();

            ApiLimits result = conn.GetLimits(true);

            conn.Close();
        }

        [TestMethod]
        public void MetadataApiTest()
        {
            SfdcMetadataApi conn = new SfdcMetadataApi(true, 36);

            conn.Username = username;
            conn.Password = password;
            conn.Token = token;

            conn.Open();

            SfdcConnect.MetadataObjects.DescribeMetadataResult dmd = conn.describeMetadata(double.Parse(conn.Version));

            conn.Close();
        }

        [TestMethod]
        public void ApexApiTest()
        {
            SfdcApexApi conn = new SfdcApexApi(true, 36);

            conn.Username = username;
            conn.Password = password;
            conn.Token = token;

            conn.Open();

            CompileClassResult[] ccr = conn.compileClasses(new string[] { "public class TestClass12321 { }" });

            conn.Close();
        }
    }
}

# SfdcConnect

This is a collection of wrapper classes for the Salesforce Apis.  Currently implemented are:

- SOAP API
- Metadata API
- Apex API
- Bulk API

Partially Implemented:

- REST API

Written in C#.  Some of the code for the Bulk API implementation come from another source, I don't remember where.

# Usage

The SfdcConnection object is not intended to be used by itself, it is the base class for the other API objects that handles login and logout.


## Login Examples

### Login in specifying if the environment is test or production and the api version
```C#
  SfdcConnection conn = new SfdcConnection(true, 36);

  conn.Username = username;
  conn.Password = password;
  conn.Token = token;

  conn.Open();

  conn.Close();
```

### Login in specifying if the Url the connection should use
```C#
  SfdcConnection conn = new SfdcConnection(string.Format("https://test.salesforce.com/services/Soap/u/{0}.0/", 36));

  conn.Username = username;
  conn.Password = password;
  conn.Token = token;

  conn.Open();

  conn.Close();
```

### Login in asynchronouosly
Both constructors are valid for async login
```C#
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
```

### Login in asynchronouosly with Custom Callback
The custom login completed function runs after the internal login completed function so you can ensure the connection state is open in your function
```C#
  SfdcConnection conn = new SfdcConnection(true, 36);

  conn.Username = username;
  conn.Password = password;
  conn.Token = token;

  conn.customLoginCompleted += YourCustomLoginCompletedFunction;

  conn.OpenAsync();
```


### Login in asynchronouosly using await
```C#
  SfdcConnection conn = new SfdcConnection(true, 36);

  conn.Username = username;
  conn.Password = password;
  conn.Token = token;
  
  CancellationToken cancelToken = new CancellationToken();

  await conn.OpenAsync(cancelToken);
```

## SOAP API Example
```C#
  SfdcSoapApi conn = new SfdcSoapApi(true, 36);

  conn.Username = username;
  conn.Password = password;
  conn.Token = token;

  conn.Open();

  SfdcConnect.SoapObjects.DescribeSObjectResult result = conn.describeSObject("Contact");

  conn.Close();
```

## REST API Example
```C#
  SfdcRestApi conn = new SfdcRestApi(true, 36);

  conn.Username = username;
  conn.Password = password;
  conn.Token = token;

  conn.Open();

  ApiLimits result = conn.GetLimits(true);

  conn.Close();
```

## Metadata API Example
```C#
  SfdcMetadataApi conn = new SfdcMetadataApi(true, 36);

  conn.Username = username;
  conn.Password = password;
  conn.Token = token;

  conn.Open();

  SfdcConnect.MetadataObjects.DescribeMetadataResult dmd = conn.describeMetadata(double.Parse(conn.Version));

  conn.Close();
```

## Apex API Example
```C#
  SfdcApexApi conn = new SfdcApexApi(true, 36);

  conn.Username = username;
  conn.Password = password;
  conn.Token = token;

  conn.Open();

  CompileClassResult[] ccr = conn.compileClasses(new string[] { "public class TestClass12321 { }" });

  conn.Close();
```

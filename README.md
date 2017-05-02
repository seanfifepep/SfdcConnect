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


## Soap API Examples

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
```C#
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
```

### Login in asynchronouosly
The custom login completed function runs after the internal login completed function so you can ensure the connection state is open in your function
```C#
  SfdcConnection conn = new SfdcConnection(string.Format("https://test.salesforce.com/services/Soap/u/{0}.0", 36));

  conn.Username = username;
  conn.Password = password;
  conn.Token = token;

  conn.customLoginCompleted += YourCustomLoginCompletedFunction;

  conn.OpenAsync();
```

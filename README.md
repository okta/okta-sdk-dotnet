# oktasdk-csharp

This SDK is in EA, so all existing features are supported by Okta in a production setting.

The SDK is distributed as a Portable Client Library with support for .NET 4, Windows 8, Windows Phone 8.1, and Silverlight 5.

Please visit [Okta's Management C# SDK](http://developer.okta.com/docs/sdk/core/csharp_api_sdk/html/6af60b57-62fa-477c-a899-e2f21286c53d.htm) for complete documentation.

## Installation 
### NuGet
- Right-click your project or solution in the Solution Explorer
- Click Manage NuGet Packages
- Search for Okta
- Install

### Build
- Ensure you have NuGet and Visual Studio 2012 Professional or higher
- Clone our GitHub repo
- Double-click `build.bat`
- You should now have `Okta.Core.dll` in `./bin/Release`

## Client Configuration
```csharp
var oktaClient = new OktaClient("your_api_key", "https://your_org.okta.com");

// Or pass in the URL directly
var oktaClient = new OktaClient("your_api_key", new Uri("https://your_org.oktapreview.com"));

var usersClient = oktaClient.GetUsersClient();

// You can also directly create clients
usersClient = new UsersClient("your_api_key", new Uri("https://your_org.oktapreview.com"));
```

### Additional Client Configuration
Using `OktaSettings`, you can create a proxy to connect to Okta.
```csharp
var handler = new HttpClientHandler()
{
    Proxy = new WebProxy(new Uri("https://your_proxy")),
    UseProxy = true
};

var oktaSettings = new OktaSettings()
{
    ApiToken = "your_api_key",
    Subdomain = "production subdomain",
    CustomHttpHandler = handler
};

var oktaClient = new OktaClient(oktaSettings);
```

### UsersClient and CRUD
This client is used to perform CRUD operations on [`User` objects](http://developer.okta.com/docs/api/resources/users.html).

```csharp
var usersClient = oktaClient.GetUsersClient();

var user = new User("newuser@example.com", "newuser@example.com", "FirstName", "LastName");

// Create and activate the user
user = usersClient.Add(user);

// Retrieve the user
user = usersClient.Get("newuser@example.com");

// Update the user's first name
user.Profile.FirstName = "newFirstName";
user = usersClient.Update(user);

// Deactivate the user
usersClient.Deactivate(user);
```

To retrieve a `User`, use the `Get` or `GetByUsername` methods:
```csharp
// All searches are case sensitive
User userByEmail = usersClient.Get("user@example.com");
User userById = usersClient.Get("00u0abcdefghIjklmo7");
User userByUsername = usersClient.GetByUsername("user@example.com");
```


### Get all Users
To request all users in an organization, use the `GetList` method:
```csharp
// Loop through pages, 100 users at a time
Uri nextPage = null;
PagedResults<User> users;

do
{
    users = usersClient.GetList(pageSize: 100, nextPage: nextPage);

    foreach (var user in users.Results)
    {
        // Perform user action
    }

    nextPage = users.NextPage;
}
while (!users.IsLastPage);
```

You can apply a filter with the `FilterBuilder` class:
```csharp
// Return all active users updated after 2014
var filter = new FilterBuilder()
                .Where(Filters.User.Status)
                .EqualTo(UserStatus.Active)
                .And()
                .Where(Filters.User.LastUpdated)
                .GreaterThanOrEqual(new DateTime(2014, 1, 1));

foreach (User user in usersClient.GetFilteredEnumerator(filter))
{
    // Perform user action
}
```

To query for users who match a certain query, use the `query` argument:
```csharp
// Return all users whose firstName, lastName, or email contains "test"
Uri nextPage = null;
PagedResults<User> users;

do
{
    users = usersClient.GetList(query: "test", nextPage: nextPage);

    foreach (User user in users.Results)
    {
        // Perform user action
    }

    nextPage = users.NextPage;
}
while (!users.IsLastPage);
```

### Get Custom Properties
Universal Directory enables the ability to add properties that are not mapped to an object.
```csharp
var user = usersClient.Get("user@your_org.com");

string custom = user.GetProperty("custom_attribute");

user.SetProperty("custom_attribute", "new_value");
```

### GroupsClient and CRUD
This client is used to perform CRUD operations on [`Group` objects](http://developer.okta.com/docs/api/resources/groups.html).

```csharp
var groupsClient = oktaClient.GetGroupsClient();

// Create and add group
Group admins = new Group(name: "admins", description: "Admins of org");
groupsClient.Add(admins);

// Retrieve the group by name
admins = groupsClient.GetByName("admins");

// Or retrieve by ID
admins = groupsClient.Get("00g0abcdefghIjklmo7");

// Update the description of the group
admins.Profile.Description = "Updated Admins of org";
groupsClient.Update(admins);

// Remove the group
groupsClient.Remove(admins);

// Or remove by ID
groupsClient.Remove(admins.Id); 
```
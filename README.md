# CommentManagement

## Getting Started

### 1.Install the following NuGet packages.
* JS.Abp.CommentManagement.Application
* JS.Abp.CommentManagement.Application.Contracts
* JS.Abp.CommentManagement.Domain
* JS.Abp.CommentManagement.Domain.Shared
* JS.Abp.CommentManagement.EntityFrameworkCore
* JS.Abp.CommentManagement.HttpApi
* JS.Abp.CommentManagement.HttpApi.Client

*(Optional)  JS.Abp.CommentManagement.Blazor
*(Optional)  JS.Abp.CommentManagement.Blazor.Server
*(Optional)  JS.Abp.CommentManagement.Blazor.WebAssembly

### 2.Add `DependsOn` attribute to configure the module
* [DependsOn(typeof(CommentManagementApplicationModule))]
* [DependsOn(typeof(CommentManagementApplicationContractsModule))]
* [DependsOn(typeof(CommentManagementDomainModule))]
* [DependsOn(typeof(CommentManagementDomainSharedModule))]
* [DependsOn(typeof(CommentManagementEntityFrameworkCoreModule))]
* [DependsOn(typeof(CommentManagementHttpApiModule))]
* [DependsOn(typeof(CommentManagementHttpApiClientModule))]


*(Optional)  [DependsOn(typeof(CommentManagementBlazorModule))]
*(Optional)  [DependsOn(typeof(CommentManagementBlazorServerModule))]
*(Optional)  [DependsOn(typeof(CommentManagementBlazorWebAssemblyModule))]

### 3. Add ` builder.ConfigureCommentManagement();` to the `OnModelCreating()` method in **YourProjectDbContext.cs**.

### 4. Add EF Core migrations and update your database.
Open a command-line terminal in the directory of the YourProject.EntityFrameworkCore project and type the following command:

````bash
> dotnet ef migrations add Added_CommentManagement
````
````bash
> dotnet ef database update
````

## How to Use
Add Comments Components
EntityId can use the current module or the current data id.

````csharp
<JS.Abp.CommentManagement.Blazor.Components.Comments EntityId="Guid.Empty"/>
````
Please note that the current user must have the "Comments" permission.

## Samples

See the [sample projects](https://github.com/zhaofenglee/CommentManagement/tree/master/host/JS.Abp.CommentManagement.Blazor.Server.Host)

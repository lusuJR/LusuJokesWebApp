# Lusu Jokes WebApp

<h2>Pakckages </h2>
<br/>
<ul>
  <li>dotnet add package Microsoft.EntityFrameworkCore</li>
  <li>dotnet add package Microsoft.EntityFrameworkCore.SqlServer</li>
  <li>dotnet add package Microsoft.EntityFrameworkCore.Tools</li>
  <li>dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore</li>
</ul>
<br />

<br/>
<h3>Migrations </h3>
<p>The Entity Framework Core (EF Core) CLI tools provide several commands to interact with the database and manage migrations. Below is a list of common dotnet ef commands related to migrations, databases, and other operations.</p>
<ul>
  <li>dotnet ef migrations add InitialCreate</li>
  <li>dotnet ef database update</li>
  <li>dotnet ef migrations list</li>
  <li>dotnet ef migrations remove</li>
  <li>dotnet ef migrations script</li>
  <li>dotnet ef migrations script --from InitialCreate --to AddNewColumn</li>
  <li>dotnet ef database update AddNewColumn</li>
  <li>dotnet ef database update AddNewColumn</li>
  <li>dotnet ef database ensure-created</li>
  <li>dotnet ef dbcontext scaffold "YourConnectionString" Microsoft.EntityFrameworkCore.SqlServer
</li>
</ul>
<P>The dotnet ef command-line tool provides a rich set of functionalities to manage Entity Framework Core migrations and interact with the database. The dotnet ef database update command, in particular, helps apply the latest changes to your database schema based on the migrations you've created. Other commands like dotnet ef migrations add or dotnet ef migrations list help manage the migration lifecycle</P>
<div>
  <h5>dotnet ef database update</h5>
  <p>Description: Applies pending migrations to the database (i.e., updates the schema)</p>
  <h5>dotnet ef migrations add <MigrationName></h5>
  <p>Description: Creates a new migration based on changes to the model.</p>
  <h5>dotnet ef migrations list</h5>
  <p>Description: Lists all migrations that have been applied or are pending.</p>
  <h5>dotnet ef migrations remove</h5>
  <p>Description: Removes the last migration if it has not been applied to the database.</p>
  <h5>dotnet ef migrations script</h5>
  <p>Description: Generates a SQL script from migrations.</p>
  <h5>dotnet ef database update <MigrationName></h5>
  <p>Description: Updates the database to a specific migration instead of applying all pending migrations.</p>
  <h5>dotnet ef database ensure-created</h5>
  <p>Description: Ensures that the database exists by creating it if it doesn’t already exist. This command does not apply migrations.</p>
  <h5>dotnet ef dbcontext scaffold</h5>
  <p>Description: Scaffolds a DbContext and entity classes based on an existing database.</p>
</div>

<br />
Note: Run the following command to create a new ASP.NET Core MVC project:
dotnet new mvc -n MyMvcApp

<h2 style="color:red">Error</h2>
<p>Could not execute because the specified command or file was not found.
Possible reasons for this include:
  * You misspelled a built-in dotnet command.
  * You intended to execute a .NET program, but dotnet-ef does not exist.
  * You intended to run a global tool, but a dotnet-prefixed executable with this name could not be found on the PATH.</p>

<h4>Steps to resolve the issue:</h4>
<p>Install the Entity Framework Core CLI tools: To use dotnet-ef, you need to install the EF Core CLI tools if they are not already installed. You can install them globally by running the following command:</p>

<ul>
  <li>dotnet tool install --global dotnet-ef</li>
  <li>dotnet ef --version</li>
</ul>

<p>To resolve this issue, install the EF Core CLI tools (dotnet-ef) globally or locally, ensure your project includes the necessary EF Core packages, and try running the dotnet-ef command again. Let me know if you encounter any further issues!</p>







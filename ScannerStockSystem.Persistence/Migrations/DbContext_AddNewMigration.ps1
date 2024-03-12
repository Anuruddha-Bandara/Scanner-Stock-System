# Param From User
param ($MigrationName,$connString)

# Set the path to your project folder
$projectPath = "..\Contexts"

# Set the path to your DbContext class
$dbContext = "ApplicationDbContext"
Write-Host $projectPath
# Read secrets.json content
#$secrets = Get-Content -Raw -Path .\secrets.json | ConvertFrom-Json

# Access the connection string
$connectionString = $connString #$secrets.ConnectionString
# Navigate to the project folder
Set-Location -Path $projectPath

# Execute the migration commands
dotnet ef migrations add $MigrationName --startup-project ../../ScannerStockSystem.WebAPI/ --project ..\ScannerStockSystem.Persistence.csproj -c $dbContext -o Data\Scripts
dotnet ef database update -c $dbContext --project ../../ScannerStockSystem.WebAPI/

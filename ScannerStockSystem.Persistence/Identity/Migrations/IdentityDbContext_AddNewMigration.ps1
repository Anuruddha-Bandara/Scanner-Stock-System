# PowerShell script to add migration and update database using specified DbContext class

param (
    [string]$name,            # Migration name
    [string]$connectionString # Connection string
)

# Specify the path to your project
$ProjectPath = "F:\Scanner-Stock-System\ScannerStockSystem.Persistence"

# Specify the relative path to your DbContext class
$DbContextClass = "ScannerStockSystem.Persistence.Identity.Data.AppIdentityContext"

# Change the working directory to the project path
Set-Location -Path $ProjectPath

# Get and display the current working directory
$currentDirectory = Get-Location
Write-Host "The current working directory is: $currentDirectory"

try {
    # Add migration
   # Write-Host "Adding migration: $name using DbContext: $DbContextClass"
   # dotnet ef migrations add  --project $ProjectPath  $name  --context $DbContextClass --output-dir Scripts

   $Env:ConnectionString="$connectionString"
    dotnet ef migrations add $name --startup-project $ProjectPath --context $DbContextClass --output-dir Scripts --verbose

    # Update database
    Write-Host "Updating database using DbContext: $DbContextClass"
     dotnet ef database update --context $DbContextClass --project $ProjectPath

    Write-Host "Migration and database update completed successfully."
} catch {
    # Handle any errors that may occur during execution
    Write-Host "An error occurred: $($_.Exception.Message)"
}


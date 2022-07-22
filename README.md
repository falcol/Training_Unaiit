# Training_Unaiit

# Database && Migration  
```bash
dotnet ef database update 
dotnet ef database drop
dotnet ef migration add name
dotnet ef migration remove 
```  

# Create Razor Pages
```bash
dotnet aspnet-codegenerator razorpage -m DB -dc DBContext -udl -outDir DirectoryPath --referenceScriptLibraries
```

# Create Identity
```bash
dotnet aspnet-codegenerator identity -dc Unaiit.Models.UnaiitDbContext -f
```

# Create Controllers
```bash
dotnet aspnet-codegenerator controller -name SchoolController -m Training_Unaiit.Models.School.SchoolTable -dc  Unaiit.Models.UnaiitDbContext -udl -outDir Areas/School/Controllers/
```

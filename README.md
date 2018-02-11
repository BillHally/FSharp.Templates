# FSharp.Templates

This repository contains various templates for use with the dotnet CLI "new"
command.

## FsXaml templates

Ther are 2 FsXaml templates (FsXamlSolution and FsXamlProject). They both:

1. Use the new "SDK-style" project format
1. Enable use of FsXaml to create WPF applications
1. Use Paket to handle dependencies

### Example usage

```powershell
# 1. Install the templates
dotnet new -i BillHally.FsXamlSolution.Template
dotnet new -i BillHally.FsXamlProject.Template

# 2. Create a new solution and project
dotnet new fsxamlsln -lang 'f#' -n AProject

# 3. Build the solution
cd AProject
.paket/paket install
msbuild /p:Configuration=Debug /t:Restore,Build /v:minimal

# 4. Run the application
dotnet run --no-build --project AProject/AProject.fsproj

# 5. Add a second project, build and run it
dotnet new fsxaml -lang 'f#' -n SecondProject
.paket/paket install
msbuild /p:Configuration=Debug /t:Restore,Build /v:minimal
dotnet run --no-build --project SecondProject/SecondProject.fsproj
```

### FsXamlSolution

This template creates a solution with the following layout:

```plain
.
├── build
│   ├── Rules
│   │   └── Wpf.ProjectItemsSchema.xml
│   └── Wpf.targets
├── paket.dependencies
├── SourceName
│   ├── App.xaml
│   ├── MainWindow.xaml
│   ├── paket.references
│   ├── Program.fs
│   └── SourceName.fsproj
└── SourceName.sln
```

The files and folders named `SourceName` will be replaced by whatever name you
specify when you use the template.

The build folder contains some files needed by msbuild and Visual studio in
order to support the `Resource` item-type, which is needed by FsXaml. These
files depend on the Nuget package `MSBuild.Sdk.Extras` - I'll look at getting the
relevant changes made directly in that package when I get a chance, at which
point the folder will no longer be needed.

### FsXamlProject

This template is essentially just a subset of FsXamlSolution - it creates only
the project, and adds it to an existing solution.

**IMPORTANT:** it won't work unless the solution has the "build" folder and
"paket.dependencies" which are created by the FsXamlSolution template, so if you
want to add to an existing solution, you'll need to create a dummy solution
using that template and manually copy the relevant bits across to your existing
solution.

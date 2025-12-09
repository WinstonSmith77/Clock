# .NET 9.0 Upgrade Plan

## Execution Steps

Execute steps below sequentially one by one in the order they are listed.

1. Validate that an .NET 9.0 SDK required for this upgrade is installed on the machine and if not, help to get it installed.
2. Ensure that the SDK version specified in global.json files is compatible with the .NET 9.0 upgrade.
3. Convert Clock.csproj to SDK-style project.
4. Upgrade Clock.csproj to .NET 9.0 (net9.0-windows).

## Settings

### Excluded projects

| Project name                                   | Description                 |
|:-----------------------------------------------|:---------------------------:|

### Project upgrade details

#### Clock.csproj modifications

Project properties changes:
  - Convert project file to SDK-style format
  - Target framework should be changed from `.NETFramework,Version=v4.8` to `net9.0-windows`

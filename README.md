[![Nuget](https://img.shields.io/nuget/v/dotnet-stryker.svg?color=blue&label=dotnet-stryker&style=flat-square)](https://www.nuget.org/packages/dotnet-stryker/)
[![Nuget](https://img.shields.io/nuget/dt/dotnet-stryker.svg?style=flat-square)](https://www.nuget.org/packages/dotnet-stryker/)
[![Azure DevOps build](https://img.shields.io/azure-devops/build/stryker-mutator/Stryker/4/master.svg?label=Azure%20Pipelines&style=flat-square)](https://dev.azure.com/stryker-mutator/Stryker/_build/latest?definitionId=4)
[![Azure DevOps tests](https://img.shields.io/azure-devops/tests/stryker-mutator/506a1f46-900e-434e-805f-ff8d36fc81af/4/master.svg?compact_message&style=flat-square)](https://dev.azure.com/stryker-mutator/Stryker/_build/latest?definitionId=4)
[![Slack](https://img.shields.io/badge/chat-on%20slack-blueviolet?style=flat-square)](https://join.slack.com/t/stryker-mutator/shared_invite/enQtOTUyMTYyNTg1NDQ0LTU4ODNmZDlmN2I3MmEyMTVhYjZlYmJkOThlNTY3NTM1M2QxYmM5YTM3ODQxYmJjY2YyYzllM2RkMmM1NjNjZjM)

⚠ You are currently looking at the V1.0 branch. We are working towards the next big release. All new features will be merged here. For currently released sources and for providing fixes see [master](https://github.com/stryker-mutator/stryker-net/tree/master)

# <img src="https://user-images.githubusercontent.com/10114577/59962899-d26b8d00-94eb-11e9-8e31-18b3d8d96fd3.png" width="40" height="40">tryker.NET
*Professor X: For someone who hates mutants... you certainly keep some strange company.*
*William Stryker: Oh, they serve their purpose... as long as they can be controlled.*

# Introduction
Stryker offers mutation testing for your .NET Core and .NET Framework projects. It allows you to test your tests by temporarily inserting bugs in your source code

For an introduction to mutation testing and Stryker's features, see [stryker-mutator.io](https://stryker-mutator.io/). Looking for mutation testing in [JavaScript & Typescript](https://stryker-mutator.github.io/stryker) or [Scala](https://stryker-mutator.github.io/stryker4s)?

# Compatibility
 - dotnet core 1.1 or newer
 - dotnet framework 4.5 or newer

# Getting started

```bash
dotnet tool install -g dotnet-stryker
cd /my/unit/test/project/folder
dotnet stryker
```

For more information read our [getting started](https://stryker-mutator.io/docs/stryker-net/Getting-started)

## Documentation
For the full documentation on how to use Stryker.NET, see our [configuration docs](https://stryker-mutator.io/docs/stryker-net/Configuration)

# Supported Mutators

For the full list of all available mutations, see the [mutator docs](https://stryker-mutator.io/docs/stryker-net/Mutators).

# Supported Reporters

For the full list of all available reporters, see the [reporter docs](https://stryker-mutator.io/docs/stryker-net/Reporters).

# Contributing
Want to help develop Stryker.NET? Check out our [contribution guide](/CONTRIBUTING.md).

Issues for the HTML report should be issued at https://github.com/stryker-mutator/mutation-testing-elements

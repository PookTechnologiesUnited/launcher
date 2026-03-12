<p align="center">
 <h2 align="center">ClassicCounter Launcher</h2>
 <p align="center">
   Launcher for ClassicCounter with Discord RPC, Auto-Updates and More!
   <br/>
   Written in C# using .NET 8.
 </p>
</p>

[![Downloads][downloads-shield]][downloads-url]
[![Stars][stars-shield]][stars-url]
[![Issues][issues-shield]][issues-url]
[![MIT License][license-shield]][license-url]

> [!IMPORTANT]
> .NET Desktop Runtime 8 is required to run the launcher. Download it from [**here**](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/runtime-desktop-8.0.25-windows-x64-installer).

## Arguments
- `--debug-mode` - Enables debug mode, prints additional info.
- `--disable-rpc` - Disables Discord RPC.
- `--gc` - Launches the Game with custom Game Coordinator.
- `--install-dependencies` - Launches setup process for required Game dependencies.
- `--patch-only` - Will only check for patches, won't open the game.
- `--skip-updates` - Skips checking for launcher updates.
- `--skip-validating` - Skips validating patches.
- `--validate-all` - Validates all game files.

> [!CAUTION]
> **Using `--skip-updates` or `--skip-validating` is NOT recommended!**  
> **An outdated launcher or patches might cause issues.**

## Packages Used
- [AsyncImageLoader](https://github.com/AvaloniaUtils/AsyncImageLoader.Avalonia) by [SKProCH](https://github.com/SKProCH)
- [Avalonia](https://github.com/AvaloniaUI/Avalonia) by [AvaloniaUI](https://github.com/AvaloniaUI)
- [CommunityToolkit](https://github.com/CommunityToolkit/dotnet) by [.NET Foundation](https://github.com/CommunityToolkit)
- [CSGSI](https://github.com/rakijah/CSGSI) by [rakijah](https://github.com/rakijah)
- [DiscordRichPresence](https://github.com/Lachee/discord-rpc-csharp) by [Lachee](https://github.com/Lachee)
- [Downloader](https://github.com/bezzad/Downloader) by [bezzad](https://github.com/bezzad)
- [Gameloop.Vdf](https://github.com/shravan2x/Gameloop.Vdf) by [shravan2x](https://github.com/shravan2x)
- [Refit](https://github.com/reactiveui/refit) by [ReactiveUI](https://github.com/reactiveui)
- [Spectre.Console](https://github.com/spectreconsole/spectre.console) by [Spectre Console](https://github.com/spectreconsole)

[downloads-shield]: https://img.shields.io/github/downloads/PookTechnologiesUnited/launcher/total.svg?style=for-the-badge
[downloads-url]: https://github.com/PookTechnologiesUnited/launcher/releases/latest
[stars-shield]: https://img.shields.io/github/stars/PookTechnologiesUnited/launcher.svg?style=for-the-badge
[stars-url]: https://github.com/PookTechnologiesUnited/launcher/stargazers
[issues-shield]: https://img.shields.io/github/issues/PookTechnologiesUnited/launcher.svg?style=for-the-badge
[issues-url]: https://github.com/PookTechnologiesUnited/launcher/issues
[license-shield]: https://img.shields.io/github/license/PookTechnologiesUnited/launcher.svg?style=for-the-badge
[license-url]: https://github.com/PookTechnologiesUnited/launcher/blob/main/LICENSE

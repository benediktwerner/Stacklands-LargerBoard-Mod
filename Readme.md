# Stacklands LargerBoard Mod

Increase the upper limit of the board size.

The board size in the game increases with the card limit (i.e. by building Sheds and Warehouses) and beyond that using Lighthouses but
there is an upper limit which is reached after 11 lighthouses.
This mod allows increasing the limit by an arbitrary amount (though the game breaks above ~15).

For backwards compbatibility (since this mod already existed before Lighthouses were a thing), this mod also
allows you to increase the maximum board size reachable using just sheds and warehouses.

By default, the max board size without lighthouses is unchanged and the max size with lighthouses is roughly doubled (the original value is 5.55, the new value is 10).

## Development

- Build using `dotnet build`
- For release builds, add `-c Release`
- If you're using VSCode, the `.vscode/tasks.json` file allows building via `Run Build`/`Ctrl+Shift+B`

## Links

- Github: https://github.com/benediktwerner/Stacklands-LargerBoard-Mod
- Steam Workshop: https://steamcommunity.com/sharedfiles/filedetails/?id=3012103049

## Changelog

- v1.2: Steam Workshop Support
- v1.1.5: Make it work with lighthouses
- v1.1.4: Fix island board not getting updated after going back to the main menu once
- v1.1.3: Update Thunderstore Readme
- v1.1.2: Update Thunderstore Readme to fix image link
- v1.1.1: Fix board rendering on the island
- v1.1.0: Initial release (for game version v1.1.x)

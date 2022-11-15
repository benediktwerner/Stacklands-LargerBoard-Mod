# Stacklands LargerBoard Mod

Increase the upper limit of the board size.

The board size in the game increases with the card limit (i.e. by building Sheds and Warehouses) but
there is an upper limit which is reached after just 21 Sheds or 6 Warehouses (or a combination thereof).
This mod allows increasing the limit by an arbitrary amount.

By default, the max board size is doubled (the original value is 2.5, the new value is 5).

To change it, you can adjust the configuration which will be generated at `BepInEx/config/de.benediktwerner.stacklands.LargerBoard.cfg`
after the first start.

## Manual Installation
This mod requires BepInEx to work. BepInEx is a modding framework which allows multiple mods to be loaded.

1. Download and install [BepInEx](https://stacklands.thunderstore.io/package/BepInEx/BepInExPack_Stacklands/)
2. Download this mod and extract it into `BepInEx/plugins/` (if the `plugins` directory doesn't exist, manually create it or launch the game once after installing BepInEx and it will be created automatically)
3. Launch the game

## Uninstallation

To uninstall the mod, simply remove `BepInEx/plugins/LargerBoard.dll` in the game's installation directory.

If you aren't using any other BepInEx mods, you can also completely remove BepInEx by deleting the `BepInEx` directory and the `changelog.txt`, `doorstop_config.ini`
and `winhttp.dll` files. Or you can simply remove and reinstall the game.

**Warning**: This will shove all the cards back into the original world bounds which may cause lag or ruin organization of the cards.

## Development
1. Install BepInEx
2. This mod uses publicized game DLLs to get private members without reflection
   - Use https://github.com/CabbageCrow/AssemblyPublicizer for example to publicize `Stacklands/Stacklands_Data/Managed/GameScripts.dll` (just drag the DLL onto the publicizer exe)
   - This outputs to `Stacklands_Data\Managed\publicized_assemblies\GameScripts_publicized.dll` (if you use another publicizer, place the result there)
3. Compile the project. This copies the resulting DLL into `<GAME_PATH>/BepInEx/plugins/`.
   - Your `GAME_PATH` should automatically be detected. If it isn't, you can manually set it in the `.csproj` file.
   - If you're using VSCode, the `.vscode/tasks.json` file should make it so that you can just do `Run Build`/`Ctrl+Shift+B` to build.

## Links
- Github: https://github.com/benediktwerner/Stacklands-LargerBoard-Mod
- Thunderstore: https://stacklands.thunderstore.io/package/benediktwerner/LargerBoard
- Nexusmods: https://www.nexusmods.com/stacklands/mods/8

## Changelog

- v1.1.3: Update Thunderstore Readme
- v1.1.2: Update Thunderstore Readme to fix image link
- v1.1.1: Fix board rendering on the island
- v1.1.0: Initial release (for game version v1.1.x)

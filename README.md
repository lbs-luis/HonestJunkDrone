# HonestJunkDrone (developer readme)

The store page is `thunderstore/HonestJunkDrone/README.md`.

## Layout

- `Directory.Build.props` and `Directory.Build.targets`: shared build settings, copied from DroneImprovements (without Risk of Options).
- `HonestJunkDrone/`: the mod project. `Plugin.cs` is the entry point, `Hooks/JunkDroneHooks.cs` the hooks.
- `thunderstore/HonestJunkDrone/`: the store files (`manifest.json`, `README.md`, `icon.png`).

## Build

```bash
dotnet build HonestJunkDrone.slnx -c Release
```

Output: `HonestJunkDrone/bin/Release/HonestJunkDrone.dll`. Copy it and the `.pdb` into `BepInEx/plugins/` to test.

## Dependencies

- BepInExPack
- HookGenPatcher, which generates `MMHOOK_RoR2.dll` on the player's machine (the project only references it at compile time)

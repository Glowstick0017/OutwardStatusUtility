# Outward All Status

A BepInEx mod for Outward that allows you to apply multiple status effects to your character with a single keypress.

## Features

- **Apply ALL Status Effects**: Press F9 to apply 100+ status effects from the game (enabled by default)
- **Comprehensive Effect Database**: Includes Boons, Buffs, Imbuements, Hexes, and more from the Outward Wiki
- **Flexible Configuration**: Choose to apply all effects or select specific categories
- **Safe by Default**: Harmful effects (Bleeding, Burning, Poison, etc.) are excluded unless explicitly enabled
- **Smart Name Matching**: Tries multiple naming variations to find status effects
- **Custom Status IDs**: Add your own status effect IDs
- **Default Durations**: Effects use their built-in durations from the game

## Installation

### Prerequisites
1. Install [BepInEx 5.x](https://github.com/BepInEx/BepInEx/releases) for Outward
2. Run the game once after installing BepInEx to generate configuration files

### Manual Installation
1. Download the latest release
2. Extract `OutwardAllStatus.dll` into `BepInEx/plugins/` folder in your Outward directory
3. Run the game

## Configuration

Press **F5** in-game (if you have [Outward Config Manager](https://thunderstore.io/c/outward/p/Mefino/Outward_Config_Manager/) installed) or manually edit the config file at:
`BepInEx/config/com.robbiepc.outwardallstatus.cfg`

### Configuration Options

**General**
- **Apply Status Key**: The key to press to apply effects (Default: F9)
- **Apply All Effects**: When enabled, applies ALL known status effects (Default: true)
  - Overrides individual category settings when enabled

**Effects** (Only apply when "Apply All Effects" is disabled)
- **Enable Blessing Effects**: Apply boons like Blessed, Cool, Warm, etc. (Default: true)
- **Enable Buff Effects**: Apply combat buffs and resistances (Default: true)
- **Enable Imbuements**: Apply weapon/shield imbuements (Default: true)
- **Enable Hex Effects**: Apply hex debuffs like Chill, Confusion, Curse (Default: false)
  - ⚠️ May reduce your damage and resistances!
- **Enable Debuff Effects**: Apply debuffs like Crippled, Dizzy, Slow Down (Default: false)
  - ⚠️ May reduce movement speed and resistances!
- **Include Negative Effects**: Include DoT effects like Bleeding, Burning, Poisoned (Default: false)
  - ⚠️⚠️ DANGEROUS! Will damage you over time!

**Note**: Effect durations are controlled by the game's built-in status effect definitions and cannot be easily modified through this mod.

**Advanced**
- **Custom Status IDs**: Comma-separated list of custom status effect IDs to apply
  - Example: `MyCustomStatus1,MyCustomStatus2,AnotherEffect`

## Status Effects Database

The mod includes **100+ status effects** from the Outward Wiki, organized into categories:

### ✅ Positive Effects (Safe - Applied by Default)

**Boons (7 effects)**
- Blessed, Cool, Warm, Discipline, Mist, Possessed, Rage

**Buffs (30+ effects)**
- Combat: Barrier, Craze, Elemental Immunity, Impact Up, Kill Streak, Speed Up, etc.
- Vital: Health Recovery, Mana Recovery, Stamina Recovery
- Resistances: Elemental Resistance, Impact Resistance Up, Status Buildup Resistance
- Special: Corruption Resistance, Force Bubble, Prime, Alert

**Imbuements (24+ effects)**
- Basic: Fire Imbue, Frost Imbue, Lightning Imbue, Poison Imbue, Wind Imbue
- Greater: Greater Fire/Frost/Lightning/Decay/Ethereal/Poison Imbues
- Special: Divine Light, Mystic Fire/Frost, Blood/Frost/Shatter Bullet Imbues
- Shield: Fire/Frost/Lightning/Decay/Ethereal Shield Imbues

**Weather Protection**
- Cold Weather Defense, Hot Weather Defense, Weather Defense, Wet

### ⚠️ Negative Effects (Disabled by Default - Enable Carefully!)

**Hexes (7 effects)**
- Chill, Confusion, Curse, Doomed, Haunted, Pain, Scorched
- Effect: Reduces damage and resistances by 25%

**Debuffs (12+ effects)**
- Movement: Crippled (-50% speed), Slow Down (-25% speed), Hampered
- Combat: Dizzy (-60% Impact Resist), Weaken (-40% damage), Sapped
- Special: Breathless, Despirited, Drawback, Panic

**DoT Effects - DANGEROUS! (10+ effects)**
- Bleeding, Extreme Bleeding, Burning, Poisoned, Extreme Poison
- Blaze, Holy Blaze, Plague
- **⚠️ These will damage you over time - NOT recommended!**

## Usage

1. Load into the game with your character
2. Press **F9** (or your configured key)
3. Status effects will be applied to your character
4. Check the console log (BepInEx console) to see which effects were applied

## Finding Status Effect IDs

To add custom status effects, you'll need to find their internal IDs:

1. Enable Debug Mode in Outward
2. Use tools like dnSpy or Unity Explorer to inspect game objects
3. Look in the game's ResourcesPrefabManager for status effect prefabs
4. Add the identifier names to the Custom Status IDs configuration

Common status effect patterns:
- Buffs often match their in-game names
- Some effects have specific prefixes or suffixes
- Check the Outward modding wiki for known effect IDs

## Building from Source

### Prerequisites
1. Install [.NET SDK](https://dotnet.microsoft.com/download) (for .NET Framework 4.7.2 support)
2. Clone this repository
3. Create a symbolic link or copy your Outward game's `Managed` folder to the project directory

### Build Commands
```bash
# Add BepInEx NuGet source
dotnet nuget add source https://nuget.bepinex.dev/v3/index.json -n BepInEx

# Build the project
dotnet build -c Release
```

Output will be located at: `bin/Release/net472/OutwardAllStatus.dll`

## Troubleshooting

**Status effects not applying?**
- Check the BepInEx console for error messages
- Verify you're in-game with a loaded character
- Make sure at least one effect type is enabled in the configuration

**Game crashes?**
- Disable debuff effects if enabled
- Check if custom status IDs are valid
- Verify BepInEx is installed correctly

**Key not responding?**
- Check if the key is already bound to another mod or game function
- Try changing the key in the configuration

## Credits

- Built with [BepInEx](https://github.com/BepInEx/BepInEx)
- Uses [HarmonyLib](https://github.com/pardeike/Harmony) for runtime patching
- Inspired by other Outward mods in the community

## License

MIT License - See LICENSE file for details

## Changelog

### Version 1.0.0
- Initial release
- Configurable status effect application
- Support for Blessings, Buffs, and Debuffs
- Custom status ID support
- Configurable effect duration

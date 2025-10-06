# Outward Status Utility

A BepInEx mod for Outward that allows you to apply multiple status effects to your character with a single keypress.

## Features

- 🎯 **16 Granular Categories** - Enable exactly the effects you want
- 📊 **260+ Status Effects** - Complete database organized by identifier names
- ⚡ **Instant Application** - Press F9 (configurable) to apply all enabled effects
- 🧹 **Instant Removal** - Press Numpad7 (configurable) to remove all status effects
- 🎮 **10 Positive Effect Categories** - Boons, buffs, recovery, runes, and more
- ⚠️ **6 Negative Effect Categories** - Hexes, debuffs, DOTs, diseases (disabled by default)
- 🔧 **Custom Effect Lists** - Add specific effect names for precise control or modded content
- 📝 **Fully Configurable** - All settings via BepInEx config file or [Outward Config Manager](https://thunderstore.io/c/outward/p/Mefino/Outward_Config_Manager/)
- ✅ **Name-Based Matching** - Effects are matched by their exact identifier names for reliability
- **Safe by Default** - Harmful effects disabled by default

## Installation

### Prerequisites

1. Install [BepInEx 5.x](https://github.com/BepInEx/BepInEx/releases) for Outward
2. Run the game once after installing BepInEx to generate configuration files

### Manual Installation

1. Download the latest release
2. Extract `OutwardStatusUtility.dll` into `BepInEx/plugins/` folder in your Outward directory
3. Run the game

## Configuration

Press F5 in-game (if you have [Outward Config Manager](https://thunderstore.io/c/outward/p/Mefino/Outward_Config_Manager/) installed) or manually edit the config file at:

`BepInEx/config/com.Glowstick.outwardstatusutility.cfg`

### Configuration Categories

#### General Settings

- **Apply Status Key**: The key to press to apply effects (Default: F9)
- **Remove Status Key**: The key to press to remove all effects (Default: Numpad7)

#### 🟢 Positive Effect Categories (Enabled by Default)

- **Enable Boons** - Major magical blessings (Rage, Discipline, Bless, Cool, Warm, Mist, Possessed)
- **Enable Recovery Effects** - Health/Stamina/Mana regeneration
- **Enable Combat Buffs** - Attack Up, Protection, Speed Up, Resistance
- **Enable Special Buffs** - Exalted, Energized, Prime, Elemental Buffs
- **Enable Food Buffs** - Positive food/drink effects
- **Enable Misc Effects** - Gift of Blood, Corruption Recovery, etc.

#### 🔵 Positive Effects (Disabled by Default)

- **Enable Imbuements** - Weapon/shield elemental imbues (may interfere with your imbues)
- **Enable Rune Effects** - Magical rune blessings (some are quest/story related)
- **Enable Rest Effects** - Tent and inn rest bonuses (can cause sleep/drowsy)
- **Enable Environmental Effects** - Temperature/weather resistances

#### 🔴 Negative Effect Categories (All Disabled by Default)

⚠️ **WARNING: These effects can harm, debuff, or kill your character!**

- **Enable Hexes** ⚠️ - Confusion, Pain, Chill, Haunted, Doom, Curse
- **Enable Debuffs** ⚠️ - Slow Down, Dizzy, Weaken, Sapped, Cripple
- **Enable DOTs** ⚠️ - Bleeding, Burning, Poisoned, Immolate, Plague
- **Enable Extreme Negatives** ⚠️⚠️ - DANGEROUS! Petrified, Corruption, Freezing
- **Enable Food Debuffs** ⚠️ - Starving, Hungry, Parched, Drunk
- **Enable Diseases** ⚠️ - Infection, Indigestion, Fever, Withdrawal

#### 🛠️ Custom Effects

- **Enable Custom Effects** - Toggle for custom effect list
- **Custom Status Names** - Comma-separated list of effect identifier names (e.g., `Rage,Discipline,Cool,Alert`)

## How It Works

The mod uses identifier name matching to apply status effects precisely:

1. You enable categories (e.g., Boons, Combat Buffs) or add custom effect names
2. When you press F9, the mod collects all effect names from enabled categories
3. It searches through all game status effects and matches by `IdentifierName`
4. Only effects with matching names are applied to your character
5. Press Numpad7 to instantly remove all active status effects

This approach ensures:

- ✅ **Accurate Category Filtering** - Only effects from enabled categories are applied
- ✅ **Modded Effect Support** - Works with custom effects by their identifier name
- ✅ **Reliable Matching** - Uses the game's internal naming system
- ✅ **Full Control** - See exactly which effects are applied via debug logs

## Status Effects Database

The mod includes 260+ status effects organized into 16 categories by their identifier names.

📊 **[View Complete Status Effect List](https://github.com/Glowstick0017/OutwardStatusUtility/blob/main/status_identifiers.txt)**

### ✅ Positive Effects (Enabled by Default)

- **Boons** - Rage, Discipline, Bless, Cool, Warm, Mist, Possessed (and amplified versions)
- **Recovery Effects** - Health/Stamina/Mana recovery (multiple tiers)
- **Combat Buffs** - Attack Up, Protection, Speed Up, Impact/Damage Resistance, Stability Up
- **Special Buffs** - Exalted, Energized, Prime, Elemental Buffs, KillStreak
- **Food Buffs** - Full, Refreshed, Gaberry Wine, PureWater, HealingWater
- **Misc Effects** - Gift of Blood, Corruption Recovery, Life Drain, various resistances

### 🔵 Positive Effects (Disabled by Default)

- **Imbuements** - Currently empty list (can be added via custom effects)
- **Rune Effects** - Wolf/Shim/Egoth/Dez/Fal Runes, Runic Lantern/Blade/Protection
- **Rest Effects** - Tent and inn rest bonuses (27 effects)
- **Environmental Effects** - Temperature and weather resistances (10 effects)

### ⚠️ Negative Effects (All Disabled by Default)

⚠️ **WARNING: These effects can harm, debuff, or kill your character!**

- **Hexes** - Confusion, Pain, Chill, Haunted, Doom, Curse (reduces damage and resistances)
- **Debuffs** - Slow Down, Dizzy, Weaken, Sapped, Cripple (movement and combat penalties)
- **DOTs** - Bleeding, Burning, Poisoned, Immolate, Plague (damage over time)
- **Extreme Negatives** - Petrified, Corruption, Freezing, Aetherbomb (VERY DANGEROUS!)
- **Food Debuffs** - Starving, Hungry, Parched, Drunk
- **Diseases** - Infection 1-3, Indigestion 1-2, Fever, Withdrawal, Leywilt, Hunch

## Usage

1. Load into the game with your character
2. Press **F9** (or your configured key) to apply status effects from enabled categories
3. Press **Numpad7** (or your configured key) to remove all status effects
4. All effects from enabled categories will be applied instantly
5. Check the console log (BepInEx console) or in-game notification to see results

### Usage Examples

**🧪 Testing Build Synergies**
- Enable: Boons, Combat Buffs, Special Buffs
- Test your build with all positive effects active

**🔥 Challenge Mode**
- Enable: Hexes, Debuffs, DOTs
- Create a hardcore challenge with multiple negative effects

**🎨 Specific Effect Combo**
- Disable all categories
- Enable Custom Effects: `Rage,Discipline,Cool,Alert,Exalted`
- Apply only the exact effects you want

**🧹 Quick Reset**
- Press Numpad7 to instantly clear all status effects
- Perfect for testing or removing unwanted effects

## Finding Status Effect Names

To add custom status effects, use their exact identifier names:

📊 **[View Complete Status Effect List](https://github.com/Glowstick0017/OutwardStatusUtility/blob/main/status_identifiers.txt)**

Example Custom Names:

```
Rage,Discipline,Bless,Alert,Exalted,Speed Up
```

**Important Notes:**

- Names are case-sensitive - must match exactly
- Use commas to separate multiple effect names
- No quotes needed around names
- Works with modded effects if you know their identifier names

## Building from Source

### Prerequisites

1. Install [.NET SDK](https://dotnet.microsoft.com/download) (for .NET Framework 4.7.2 support)
2. Clone this repository
3. Reference your Outward game's `Managed` folder DLLs in the project

### Build Commands

```powershell
# Restore packages
dotnet restore

# Build the project
dotnet build -c Release
```

Output will be located at: `bin/Release/net472/OutwardStatusUtility.dll`

## Project Structure

```
OutwardStatusUtility/
├── Plugin.cs                    # Main mod logic
├── OutwardStatusUtility.csproj  # Project file
├── status_identifiers.txt       # Complete list of status effect names
├── thunderstore/                # Thunderstore package files
│   ├── README.md
│   ├── manifest.json
│   └── icon.png
└── bin/Release/net472/          # Build output
```

## Troubleshooting

**Status effects not applying?**
- Check the BepInEx console for error messages
- Verify you're in-game with a loaded character
- Make sure at least one effect category is enabled in the configuration

**Game crashes?**
- Disable "Extreme Negatives" category if enabled
- Reduce number of simultaneous effects
- Check if custom status names are valid

**Key not responding?**
- Check if the key is already bound to another mod or game function
- Try changing the key in the configuration file

**Custom effect not working?**
- Verify the identifier name is correct and case-sensitive
- Check the [complete effect list](https://github.com/Glowstick0017/OutwardStatusUtility/blob/main/status_identifiers.txt)
- Enable "Custom Effects" toggle in config
- For modded effects, check the mod's documentation for exact names

## Credits

- Built with [BepInEx](https://github.com/BepInEx/BepInEx)
- Uses [HarmonyLib](https://github.com/pardeike/Harmony) for runtime patching
- Inspired by the Outward modding community

## License

MIT License - See LICENSE file for details

## Changelog

See [CHANGELOG.md](CHANGELOG.md) for detailed version history.

## Links

- **Source Code**: [GitHub Repository](https://github.com/Glowstick0017/OutwardStatusUtility)
- **Issues/Suggestions**: [GitHub Issues](https://github.com/Glowstick0017/OutwardStatusUtility/issues)
- **Effect List**: [status_identifiers.txt](https://github.com/Glowstick0017/OutwardStatusUtility/blob/main/status_identifiers.txt)

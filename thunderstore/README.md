# Outward Status Utility

Apply any combination of status effects to your character with the press of a button! This mod gives you complete control over 400+ status effects in Outward, organized into 16 intuitive categories.

Perfect for testing builds, creating challenges, or just having fun with game mechanics!

---

## ✨ Features

- **🎯 16 Granular Categories** - Enable exactly the effects you want
- **⚡ Instant Application** - Press F9 (configurable) to apply all enabled effects
- **🧹 Instant Removal** - Press NumPad 7 (configurable) to remove all status effects
- **🎮 10 Positive Effect Categories** - Boons, buffs, recovery, imbuements, and more
- **⚠️ 6 Negative Effect Categories** - Hexes, debuffs, DOTs, diseases (disabled by default)
- **🔧 Custom Effect Lists** - Add effects by name for modded content support
- **📝 Fully Configurable** - All settings via BepInEx config file or [Outward Config Manager](https://thunderstore.io/c/outward/p/Mefino/Outward_Config_Manager/)
- **✅ Name-Based Matching** - Effects matched by identifier names for precision and reliability

---

## 📦 Installation

### Automatic (Recommended)
1. Install with [r2modman](https://thunderstore.io/c/outward/p/ebkr/r2modman/) or Thunderstore Mod Manager
2. Launch the game
3. Configure via mod manager or in-game with [Outward Config Manager](https://thunderstore.io/c/outward/p/Mefino/Outward_Config_Manager/)

### Manual
1. Install [BepInExPack for Outward](https://thunderstore.io/c/outward/p/BepInEx/BepInExPack_Outward/)
2. Download this mod and extract the archive
3. Copy `OutwardStatusUtility.dll` to `BepInEx/plugins/` folder
4. Run the game

---

## 🎮 How to Use

1. **Launch the game** and load your character
2. **Press F9** to apply status effects from enabled categories
3. **Press NumPad 7** to remove all status effects
4. **Configure categories** via `BepInEx/config/com.Glowstick.outwardstatusutility.cfg` or use [Outward Config Manager](https://thunderstore.io/c/outward/p/Mefino/Outward_Config_Manager/) (F5 in-game)

---

## 🔧 How It Works

The mod uses **identifier name matching** for precise effect application:

1. ✅ You enable categories or add custom effect names
2. ✅ Mod collects all effect names from enabled categories
3. ✅ Searches game effects and matches by `IdentifierName`
4. ✅ Only matching effects are applied to your character
5. ✅ Press NumPad 7 to instantly clear all effects

**Benefits:**
- Accurate category filtering - only enabled categories apply
- Works with modded effects by their identifier name
- Reliable matching using game's internal naming system
- Full control with detailed debug logs

---

## ⚙️ Configuration Categories

### 🟢 Positive Effects (Enabled by Default)

| Category | Count | Description | Examples |
|----------|-------|-------------|----------|
| **Enable Boons** | 14 | Major magical blessings | Rage, Discipline, Bless, Cool, Warm, Mist, Possessed (+ Amplified) |
| **Enable Recovery Effects** | 17 | Health/Stamina/Mana regeneration | Health Recovery 2-5, Stamina Recovery 2-5, Mana Recovery, Passive Mana Regen |
| **Enable Combat Buffs** | 20 | Combat-focused enhancements | Attack Up, Impact Up, Protection 1-2, Barrier 1-2, Speed Up, Defense Bonus, Stability Up |
| **Enable Special Buffs** | 15 | Unique powerful buffs | Exalted, Energized, Alert, Prime, Elemental Buffs (Fire/Frost/Decay/Light/Ethereal/Chromatic) |
| **Enable Food Buffs** | 14 | Positive food/drink effects | Full, Refreshed, Gaberry Wine, Food Stability/Attack/Impact Up, Pure Water, Healing Water |
| **Enable Misc Effects** | 29 | Other beneficial effects | Gift of Blood, Corruption Recovery, Temple Buff, Force Bubble, Wind Imbue Stats |

### 🔵 Positive Effects (Disabled by Default)

| Category | Count | Description | Why Disabled? |
|----------|-------|-------------|---------------|
| **Enable Imbuements** | 24 | Weapon/shield elemental imbues | Fire/Frost/Lightning/Poison/Decay/Ethereal Imbues (Shield + Greater versions) - May interfere with your actual imbues |
| **Enable Rune Effects** | 13 | Magical rune blessings | Shim/Egoth/Dez/Fal Runes, Runic Lantern/Blade/Protection/Heal - Some are quest/story related |
| **Enable Rest Effects** | 27 | Tent and inn rest bonuses | Tent buffs (Camo/Fur/Luxurious/Mage/Plant/Scourge), Inn Sleep effects (Cierzo/Berg/Levant/Monsoon) - Can cause unwanted sleep/drowsy |
| **Enable Environmental Effects** | 10 | Temperature/weather resistances | Environment Cold/Heat Resistance, Cold1-2, Wet, Hallowed Marsh Poison, Sulphur Poison - May conflict with survival mechanics |

### 🔴 Negative Effects (All Disabled by Default)

⚠️ **WARNING:** These effects can harm, debuff, or kill your character!

| Category | Count | Description | Examples |
|----------|-------|-------------|----------|
| **Enable Hexes** ⚠️ | 6 | Magical curses (damage reduction) | Confusion, Pain, Chill, Haunted, Doom, Curse |
| **Enable Debuffs** ⚠️ | 13 | Combat penalties | Slow Down, Dizzy, Stun, Weaken, Sapped, Cripple, Panic, Breathless, Hampered |
| **Enable DOTs** ⚠️ | 10 | Damage over time | Burn, Burning, Poisoned/Poisoned+, Bleeding/Bleeding+, Immolate, Blaze, Plague |
| **Enable Extreme Negatives** ⚠️⚠️ | 14 | VERY DANGEROUS! | Petrification, Petrified, Tainted, Corrupt/Defiled (Positive/Negative), Freezing, Aetherbomb |
| **Enable Food Debuffs** ⚠️ | 10 | Hunger/thirst penalties | Starving, Hungry, Bloated, Parched, Thirsty, Drunk, Food Dizzy/Poisoned/Slow Down |
| **Enable Diseases** ⚠️ | 15 | Disease effects | Infection 1-3, Indigestion 1-2, Ambraine Withdrawal, Leywilt, Hunch, Hive Infestation, Meeka Fever |

### 🛠️ Custom Effects

| Setting | Description |
|---------|-------------|
| **Enable Custom Effects** | Toggle for custom effect list |
| **Custom Status Names** | Comma-separated list of effect identifier names |

**Example Custom List:**
```
Rage,Discipline,Cool,Fire Imbue,Greater Fire Imbue,Speed Up
```

📋 **[View Complete Status Effect List (400+ Effects)](https://docs.google.com/spreadsheets/d/1btxPTmgeRqjhqC5dwpPXWd49-_tX_OVLN1Uvwv525K4/edit?gid=1969601658#gid=1969601658)**

---

## 📋 Detailed Effect Tables

### ✅ Positive Boons (14 Effects)

| Effect Name | Description |
|-------------|-------------|
| Rage | +25% physical damage |
| Discipline | +25% impact damage |
| Warm | Cold weather resistance |
| Cool | Hot weather resistance |
| Mist | +10% movement speed |
| Bless | +10% all damage |
| Possessed | +15% ethereal damage |
| Rage Amplified | +40% physical damage |
| Discipline Amplified | +40% impact damage |
| Warm Amplified | Enhanced cold resistance |
| Cool Amplified | Enhanced hot resistance |
| Mist Amplified | +15% movement speed |
| Bless Amplified | +15% all damage |
| Possessed Amplified | +25% ethereal damage |

### ✅ Recovery Effects (17 Effects)

| Effect Name | Description |
|-------------|-------------|
| Health Recovery 2 | Restores health over time (Tier 2) |
| Stamina Recovery 2 | Restores stamina over time (Tier 2) |
| Mana Ratio Recovery 2 | Restores mana over time (Tier 2) |
| Health Recovery 3 | Restores health over time (Tier 3) |
| Stamina Recovery 3 | Restores stamina over time (Tier 3) |
| Mana Ratio Recovery 3 | Restores mana over time (Tier 3) |
| Health Recovery 4 | Restores health over time (Tier 4) |
| Stamina Recovery 4 | Restores stamina over time (Tier 4) |
| Mana Ratio Recovery 4 | Restores mana over time (Tier 4) |
| Health Recovery Small | Small health restoration |
| Stamina Recovery Small | Small stamina restoration |
| Mana Ratio Recovery Small | Small mana restoration |
| Health Recovery 5 | Restores health over time (Tier 5) |
| Stamina Recovery 5 | Restores stamina over time (Tier 5) |
| Mana Ratio Recovery 5 | Restores mana over time (Tier 5) |
| Passive Mana Regen | Continuous mana regeneration |
| ExtremeManaRegen1 | Extreme mana regeneration |

### ✅ Combat Buffs (20 Effects)

| Effect Name | Description |
|-------------|-------------|
| Stamina Cost Reduction | Reduces stamina costs |
| Mana Cost Reduction | Reduces mana costs |
| Speed Up | Increased movement speed |
| Elemental Resistance | Resistance to all elements |
| Elemental Immunity | Immunity to all elements |
| Environment Resistance | Environmental damage resistance |
| Stability Up | Increased stability (knockdown resistance) |
| Defense Bonus | Increased physical defense |
| Stealth Up | Improved stealth |
| Stability Up 2 | Enhanced stability bonus |
| Attack Up | Increased attack damage |
| Impact Up | Increased impact damage |
| Armor Penalties Reduction | Reduced armor movement penalties |
| Elemental Resistance 2 | Enhanced elemental resistance |
| Protection 1 | Physical damage reduction (Tier 1) |
| Protection 2 | Physical damage reduction (Tier 2) |
| Barrier 1 | Elemental damage reduction (Tier 1) |
| Barrier 2 | Elemental damage reduction (Tier 2) |
| StatusBuildUpResUp | Increased status buildup resistance |
| Shimmer | Special defensive buff |

### ✅ Special Buffs (15 Effects)

| Effect Name | Description |
|-------------|-------------|
| Exalted | Powerful all-around buff |
| Energized | Enhanced stamina regeneration |
| Alert | Increased awareness |
| Unerring Read | Enhanced accuracy |
| Prime | Peak physical condition |
| ElemFireBuff | Fire damage bonus |
| ElemFrostBuff | Frost damage bonus |
| ElemDecayBuff | Decay damage bonus |
| ElemLightBuff | Light damage bonus |
| ElemEtherealBuff | Ethereal damage bonus |
| ElemChromaticBuff | All elemental damage bonus |
| KillStreak | Stacking combat bonus |
| Craze | Berserker-like enhancement |
| GhostRhythm | Spirit-based buff |
| SkyRhythm | Heaven-based buff |

### 🔵 Imbuements (24 Effects)

| Effect Name | Type |
|-------------|------|
| Poison Imbue | Weapon imbue |
| Greater Poison Imbue | Enhanced weapon imbue |
| Fire Imbue | Weapon imbue |
| Greater Fire Imbue | Enhanced weapon imbue |
| Frost Imbue | Weapon imbue |
| Greater Frost Imbue | Enhanced weapon imbue |
| Lightning Imbue | Weapon imbue |
| Greater Lightning Imbue | Enhanced weapon imbue |
| Greater Ethereal Imbue | Enhanced weapon imbue |
| Wind Imbue | Weapon imbue |
| Greater Decay Imbue | Enhanced weapon imbue |
| Decay Shield Imbue | Shield imbue |
| Ethereal Shield Imbue | Shield imbue |
| Fire Shield Imbue | Shield imbue |
| Frost Shield Imbue | Shield imbue |
| Lightning Shield Imbue | Shield imbue |
| Mystic Fire Imbue | Special weapon imbue |
| Mystic Frost Imbue | Special weapon imbue |
| Divine Light Imbue | Special weapon imbue |
| Infuse Blood | Blood weapon infusion |
| Infuse Mana | Mana weapon infusion |
| Frost Bullet Imbue | Ranged imbue |
| Blood Bullet Imbue | Ranged imbue |
| Shatter Bullet Imbue | Ranged imbue |

### ⚠️ Hexes (6 Effects)

| Effect Name | Description |
|-------------|-------------|
| Confusion | Reduced damage output |
| Pain | -25% physical damage |
| Chill | -25% impact damage |
| Haunted | -25% ethereal damage |
| Doom | -10% all damage |
| Curse | -15% all resistances |

### ⚠️ Damage Over Time (10 Effects)

| Effect Name | Damage Type |
|-------------|-------------|
| Burn | Fire damage over time |
| Poisoned | Poison damage over time |
| Poisoned + | Enhanced poison damage |
| Bleeding | Physical damage over time |
| Bleeding + | Enhanced bleeding damage |
| Burning | Intense fire damage over time |
| Immolate | Extreme fire damage over time |
| Blaze | Divine fire damage over time |
| HolyBlaze | Holy fire damage over time |
| Plague | Disease damage over time |

---

## 🎯 Usage Examples

### 🧪 Testing Build Synergies
Enable **Boons**, **Combat Buffs**, and **Special Buffs** to test your build with all positive effects active.

```
Result: ~49 positive effects applied
Perfect for testing maximum potential damage and survivability
```

### 🔥 Challenge Mode
Enable **Hexes**, **Debuffs**, and **DOTs** to create a hardcore challenge.

```
Result: ~29 negative effects applied
Fight enemies while severely handicapped!
```

### 🎨 Specific Effect Combo
Disable all categories, enable **Custom Effects**, and add specific effects:
```
Rage,Discipline,Bless,Fire Imbue,Speed Up,Attack Up
```

### 🌟 Full Buffed Experience
Enable all 10 positive categories for the ultimate power fantasy!

```
Result: ~173 positive effects applied
Note: May cause visual clutter with many buff icons
```

### 🧹 Quick Reset
Press **NumPad 7** to instantly clear all status effects - perfect for testing or removing unwanted effects.

---

## ⚙️ Advanced Configuration

Edit `BepInEx/config/com.Glowstick.outwardstatusutility.cfg`:

```ini
[General]
# Keys to apply/remove status effects
Apply Status Key = F9
Remove Status Key = Keypad7

[1. Positive Effects]
Enable Boons = true
Enable Recovery Effects = true
Enable Combat Buffs = true
Enable Special Buffs = true
Enable Imbuements = false
Enable Rune Effects = false
Enable Food Buffs = true
Enable Rest Effects = false
Enable Environmental Effects = false
Enable Misc Effects = true

[2. Negative Effects]
# WARNING: All disabled by default for safety!
Enable Hexes = false
Enable Debuffs = false
Enable Damage Over Time = false
Enable Extreme Negatives = false
Enable Food Debuffs = false
Enable Diseases = false

[3. Custom Effects]
Enable Custom Effects = false
# Comma-separated list of effect identifier names
Custom Status Names = 
```

---

## 📋 Full Effect List

The mod includes **400+ status effects** organized into categories by their identifier names.

📊 **[View Complete Status Effect List](https://docs.google.com/spreadsheets/d/1btxPTmgeRqjhqC5dwpPXWd49-_tX_OVLN1Uvwv525K4/edit?gid=1969601658#gid=1969601658)**

**Effect Counts by Category:**
- ✅ Boons: 14 effects
- ✅ Recovery: 17 effects
- ✅ Combat Buffs: 20 effects
- ✅ Special Buffs: 15 effects
- 🔵 Imbuements: 24 effects
- 🔵 Rune Effects: 13 effects
- ✅ Food Buffs: 14 effects
- 🔵 Rest Effects: 27 effects
- 🔵 Environmental: 10 effects
- ✅ Misc Effects: 29 effects
- ⚠️ Hexes: 6 effects
- ⚠️ Debuffs: 13 effects
- ⚠️ DOTs: 10 effects
- ⚠️ Extreme Negatives: 14 effects
- ⚠️ Food Debuffs: 10 effects
- ⚠️ Diseases: 15 effects

**Total: 400+ Status Effects**

---

## 🔧 Compatibility

- **Compatible with:** Most mods, including custom status effects
- **Custom Status Support:** Use effect identifier names in "Custom Status Names" config
- **Mod Manager Friendly:** Works with r2modman and Thunderstore Mod Manager
- **Config Manager Support:** Full support for [Outward Config Manager](https://thunderstore.io/c/outward/p/Mefino/Outward_Config_Manager/) (F5 in-game)

---

## ⚠️ Important Notes

1. **Negative Effects Can Kill You** - Extreme negatives are disabled by default for a reason!
2. **Effect Stacking** - Applying too many effects may cause performance issues or visual clutter
3. **Imbuements** - May override your current weapon imbue
4. **Save Your Game** - Before experimenting with negative effects!
5. **Case-Sensitive Names** - Custom effect names must match exactly (e.g., "Rage" not "rage")
6. **Name-Based Matching** - The mod uses identifier names, not numeric IDs, for reliable matching

---

## 🐛 Troubleshooting

**Nothing happens when I press F9:**
- Check your config file - all categories might be disabled
- Enable at least one positive category or add custom effects
- Check logs at `BepInEx/LogOutput.log` for errors

**Only some effects applied:**
- This is normal - some effects may not be applicable in certain situations
- Check debug logs to see which effects succeeded/failed
- Some effects are mutually exclusive

**Too many effects applied:**
- Reduce the number of enabled categories
- Use Custom Effects list for precise control

**Game crashes:**
- Disable "Extreme Negatives" category
- Reduce number of simultaneous effects
- Check for mod conflicts

**Custom effect not working:**
- Verify the identifier name is correct and case-sensitive
- Check the [complete effect list](https://docs.google.com/spreadsheets/d/1btxPTmgeRqjhqC5dwpPXWd49-_tX_OVLN1Uvwv525K4/)
- Enable "Custom Effects" toggle in config
- For modded effects, check the mod's documentation for exact names

**Remove key not working:**
- Default is NumPad 7 - check if key is bound elsewhere
- Change key in config if needed
- Verify you have active status effects to remove

---

## 📝 Changelog

### v1.0.0 - Initial Release
- 16 configurable status effect categories (400+ effects total)
- Name-based identifier matching for precise effect application
- Custom effect name support for modded content
- Configurable hotkeys (F9 apply, NumPad 7 remove)
- Full BepInEx Config Manager support
- Detailed debug logging
- Safe defaults (negative effects disabled)

---

## 🔗 Links

- **Source Code:** [GitHub Repository](https://github.com/Glowstick0017/OutwardStatusUtility)
- **Issues/Suggestions:** [GitHub Issues](https://github.com/Glowstick0017/OutwardStatusUtility/issues)
- **Effect List:** [Google Sheets Database](https://docs.google.com/spreadsheets/d/1btxPTmgeRqjhqC5dwpPXWd49-_tX_OVLN1Uvwv525K4/)

---

## 📜 License

MIT License - Free to use, modify, and distribute

---

## 💬 Support

Found a bug? Have a suggestion? Open an issue on [GitHub](https://github.com/Glowstick0017/OutwardStatusUtility/issues)!

Enjoy experimenting with status effects! 🎮✨

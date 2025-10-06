# Changelog

All notable changes to Outward Status Utility will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [1.1.0] - 2025-10-05

### Added
- Complete status effect identifier list in `status_identifiers.txt` (260+ effects)
- Comprehensive README documentation for both developers and users
- Detailed effect tables with descriptions for all categories
- Usage examples for different gameplay scenarios

### Changed
- Updated documentation to accurately reflect 260+ effects (from 400+)
- Improved category descriptions with exact effect counts
- Replaced external spreadsheet link with GitHub status_identifiers.txt reference
- Enhanced troubleshooting section with more detailed solutions

### Fixed
- Corrected effect counts for all 16 categories based on actual implementation
- Fixed inconsistencies in category descriptions

## [1.0.0] - 2025-10-05

### Added
- Initial release
- 16 configurable status effect categories (260+ effects total)
  - 10 positive effect categories (Boons, Recovery, Combat Buffs, Special Buffs, Imbuements, Rune Effects, Food Buffs, Rest Effects, Environmental Effects, Misc Effects)
  - 6 negative effect categories (Hexes, Debuffs, DOTs, Extreme Negatives, Food Debuffs, Diseases)
- Name-based identifier matching for precise effect application
- Custom effect name support for modded content
- Configurable hotkeys (F9 apply, Numpad7 remove)
- Full BepInEx Config Manager support
- Detailed debug logging
- Safe defaults (negative effects disabled by default)
- In-game notifications for effect application/removal

### Features
- Apply multiple status effects instantly with a single keypress
- Remove all status effects with another keypress
- Granular control over which effect categories to enable
- Custom effect list support for precise control
- Compatible with modded status effects
- Comprehensive configuration options via BepInEx config file

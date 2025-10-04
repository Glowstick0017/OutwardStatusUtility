using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace OutwardStatusUtility
{
    [BepInPlugin(GUID, NAME, VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        public const string GUID = "com.Glowstick.outwardstatusutility";
        public const string NAME = "Outward Status Utility";
        public const string VERSION = "1.0.0";

        internal static ManualLogSource Log;
        
        // Configuration entries
        public static ConfigEntry<KeyCode> ApplyStatusKey;
        public static ConfigEntry<KeyCode> RemoveStatusKey;
        
        // Positive Effect Categories
        public static ConfigEntry<bool> EnableBoons;
        public static ConfigEntry<bool> EnableRecoveryEffects;
        public static ConfigEntry<bool> EnableCombatBuffs;
        public static ConfigEntry<bool> EnableSpecialBuffs;
        public static ConfigEntry<bool> EnableImbuements;
        public static ConfigEntry<bool> EnableRuneEffects;
        public static ConfigEntry<bool> EnableFoodBuffs;
        public static ConfigEntry<bool> EnableRestEffects;
        public static ConfigEntry<bool> EnableEnvironmentalEffects;
        public static ConfigEntry<bool> EnableMiscEffects;
        
        // Negative Effect Categories
        public static ConfigEntry<bool> EnableHexes;
        public static ConfigEntry<bool> EnableDebuffs;
        public static ConfigEntry<bool> EnableDoTs;
        public static ConfigEntry<bool> EnableExtremeNegatives;
        public static ConfigEntry<bool> EnableFoodDebuffs;
        public static ConfigEntry<bool> EnableDiseases;
        
        // Custom Effects
        public static ConfigEntry<bool> EnableCustomEffects;
        public static ConfigEntry<string> CustomStatusNames;
        
        // ALL STATUS EFFECTS - Complete list with EXACT internal identifier names
        // Organized by type for easy configuration
        
        // POSITIVE EFFECTS - Boons & Major Buffs
        private static readonly List<string> PositiveBoonNames = new List<string>
        {
            "Rage",
            "Discipline",
            "Warm",
            "Cool",
            "Mist",
            "Bless",
            "Possessed",
            "Rage Amplified",
            "Discipline Amplified",
            "Warm Amplified",
            "Cool Amplified",
            "Mist Amplified",
            "Bless Amplified",
            "Possessed Amplified",
        };
        
        // Recovery Effects
        private static readonly List<string> RecoveryEffectNames = new List<string>
        {
            "Health Recovery 2",
            "Stamina Recovery 2",
            "Mana Ratio Recovery 2",
            "Health Recovery 3",
            "Stamina Recovery 3",
            "Mana Ratio Recovery 3",
            "Health Recovery 4",
            "Stamina Recovery 4",
            "Mana Ratio Recovery 4",
            "Health Recovery Small",
            "Stamina Recovery Small",
            "Mana Ratio Recovery Small",
            "Health Recovery 5",
            "Stamina Recovery 5",
            "Mana Ratio Recovery 5",
            "Passive Mana Regen",
            "ExtremeManaRegen1",
        };
        
        // Combat Buffs
        private static readonly List<string> CombatBuffNames = new List<string>
        {
            "Stamina Cost Reduction",
            "Mana Cost Reduction",
            "Speed Up",
            "Elemental Resistance",
            "Elemental Immunity",
            "Environment Resistance",
            "Stability Up",
            "Defense Bonus",
            "Stealth Up",
            "Stability Up 2",
            "Attack Up",
            "Impact Up",
            "Armor Penalties Reduction",
            "Elemental Resistance 2",
            "Protection 1",
            "Protection 2",
            "Barrier 1",
            "Barrier 2",
            "StatusBuildUpResUp",
            "Shimmer",
        };
        
        // Special Buffs
        private static readonly List<string> SpecialBuffNames = new List<string>
        {
            "Exalted",
            "Energized",
            "Alert",
            "Unerring Read",
            "Prime",
            "ElemFireBuff",
            "ElemFrostBuff",
            "ElemDecayBuff",
            "ElemLightBuff",
            "ElemEtherealBuff",
            "ElemChromaticBuff",
            "KillStreak",
            "Craze",
            "GhostRhythm",
            "SkyRhythm",
        };
        
        // Imbue Effects
        private static readonly List<string> ImbueEffectNames = new List<string>
        {
            "Poison Imbue",
            "Greater Poison Imbue",
            "Fire Imbue",
            "Greater Fire Imbue",
            "Frost Imbue",
            "Greater Frost Imbue",
            "Lightning Imbue",
            "Greater Lightning Imbue",
            "Greater Ethereal Imbue",
            "Wind Imbue",
            "Greater Decay Imbue",
            "Decay Shield Imbue",
            "Ethereal Shield Imbue",
            "Fire Shield Imbue",
            "Frost Shield Imbue",
            "Lightning Shield Imbue",
            "Mystic Fire Imbue",
            "Mystic Frost Imbue",
            "Divine Light Imbue",
            "Infuse Blood",
            "Infuse Mana",
            "Frost Bullet Imbue",
            "Blood Bullet Imbue",
            "Shatter Bullet Imbue",
        };
        
        // Runes & Special Items
        private static readonly List<string> RuneEffectNames = new List<string>
        {
            "Wolf Fal Runes",
            "Wolf Runic Protection",
            "Shim Runes",
            "Egoth Runes",
            "Dez Runes",
            "Fal Runes",
            "Runic Lantern Amplified",
            "Runic Lantern",
            "Runic Blade",
            "Runic Protection Amplified",
            "Runic Protection",
            "Runic Heal Amplified",
            "Fireflies",
        };
        
        // NEGATIVE EFFECTS (Only apply if explicitly enabled)
        
        // Hexes
        private static readonly List<string> HexEffectNames = new List<string>
        {
            "Confusion",
            "Pain",
            "Chill",
            "Haunted",
            "Doom",
            "Curse",
        };
        
        // Debuffs
        private static readonly List<string> DebuffEffectNames = new List<string>
        {
            "Slow Down",
            "Dizzy",
            "Stun",
            "Elemental Vulnerability",
            "Cripple",
            "Weaken",
            "Sapped",
            "Panic",
            "Dispirited",
            "Breathless",
            "Hampered",
            "Drawback",
            "StatusBuildUpResDown",
        };
        
        // Damage Over Time Effects
        private static readonly List<string> DotEffectNames = new List<string>
        {
            "Burn",
            "Poisoned",
            "Poisoned +",
            "Bleeding",
            "Bleeding +",
            "Burning",
            "Immolate",
            "Blaze",
            "HolyBlaze",
            "Plague",
        };
        
        // Corruption & Extreme Conditions
        private static readonly List<string> ExtremeNegativeNames = new List<string>
        {
            "Petrification",
            "Petrified",
            "Aetherbomb",
            "AetherbombExplosion",
            "Tainted",
            "Corrupt Positive",
            "Corrupt Negative",
            "Defiled Positive",
            "Defiled Negative",
            "ColdExposure",
            "Freezing",
            "HeatExposure",
            "Temperature Burning",
            "AncientDwellerSlowing",
        };
        
        // Food & Drink Effects
        private static readonly List<string> FoodBuffNames = new List<string>
        {
            "Full",
            "Refreshed",
            "Gaberry Wine",
            "Food Stability Up",
            "Food Cool",
            "Food Mist",
            "Food Bless",
            "Food Possessed",
            "Food Discipline",
            "Food Attack Up",
            "Food Impact Up",
            "Food Water Stamina",
            "PureWater",
            "HealingWater",
        };
        
        // Food Negative Effects
        private static readonly List<string> FoodDebuffNames = new List<string>
        {
            "Starving",
            "Hungry",
            "Bloated",
            "Parched",
            "Thirsty",
            "Food Dizzy",
            "Food Poisoned",
            "Food Poisoned +",
            "Food Slow Down",
            "Drunk",
        };
        
        // Environmental Effects
        private static readonly List<string> EnvironmentNames = new List<string>
        {
            "Wet",
            "Environment Cold Resistance",
            "Environment Heat Resistance",
            "Food Environment Heat Resistance",
            "Food Environment Cold Resistance",
            "Cold1",
            "Cold2",
            "Hallowed Marsh Poison Lvl1",
            "Hallowed Marsh Poison Lvl2",
            "SulphurPoison",
        };
        
        // Rest & Sleep Effects
        private static readonly List<string> RestEffectNames = new List<string>
        {
            "Drowsy",
            "Tired",
            "Camo Tent buff",
            "Fur Tent buff",
            "Luxurious Tent buff",
            "Tent buff",
            "Cierzo Inns",
            "Monsoon Inns",
            "Berg Inns",
            "Levant Inns",
            "Mage Tent buff",
            "Plant Tent Buff",
            "Harmattant Inn A",
            "Harmattant Inn B",
            "Lockwell's Revelation Tired",
            "Lockwell's Revelation Very Tired",
            "Scourge Tent Buff",
            "Fire Totem Sleep",
            "Ice Totem Sleep",
            "Light Totem Sleep",
            "Decay Totem Sleep",
            "Ethereal Totem Sleep",
            "Calygrey Sleep",
            "Caldera Inn Sleep",
            "Caldera Hall Sleep",
            "Caldera Basic Sleep",
            "SaunaInn",
        };
        
        // Disease & Illness
        private static readonly List<string> DiseaseNames = new List<string>
        {
            "Infection1",
            "Infection2",
            "Infection3",
            "Indigestion1",
            "Indigestion2",
            "Ambraine Withdrawal",
            "AmbraineWithdrawalPreEffects",
            "Leywilt1",
            "Leywilt2",
            "Hunch1",
            "Hunch2",
            "HiveInfestation1",
            "hiveInfestation2",
            "MeekaFever1",
            "MeekaFever2",
        };
        
        // Special & Misc Effects
        private static readonly List<string> MiscEffectNames = new List<string>
        {
            "Bandage",
            "Gift of Blood",
            "Gift of Blood Ally",
            "Blood Leech Victim",
            "Blood Leech",
            "Titanic Golem 1",
            "Titanic Golem 2",
            "Titanic Golem 3",
            "Corruption Recovery 1",
            "Corruption Recovery 2",
            "Corruption Resistance 1",
            "Corruption Resistance 2",
            "EliteSupremeShellRage",
            "SupremeShellRage",
            "EliteSupremeShellDiscipline",
            "LionmanElderBoonLvl1",
            "LionmanElderBoonLvl2",
            "CrimsonMineLvl",
            "CrimsonSunLvl",
            "GargoyleBoonLvl",
            "ScarletEmissaryProt",
            "SlughellProt",
            "GrandmotherBoon",
            "TempleBuff",
            "TempleBuffPlus",
            "Bag Over Encumbered",
            "Pouch Over Encumbered",
            "Force Bubble",
            "Wind Imbue Stats",
        };

        void Awake()
        {
            Log = this.Logger;
            Log.LogInfo($"{NAME} {VERSION} is loading...");
            
            // Setup configuration
            ApplyStatusKey = Config.Bind("General", 
                "Apply Status Key", 
                KeyCode.F9, 
                "Key to press to apply status effects to your character");
            
            RemoveStatusKey = Config.Bind("General", 
                "Remove Status Key", 
                KeyCode.Keypad7, 
                "Key to press to remove all status effects from your character");
            
            // Positive Effect Categories
            EnableBoons = Config.Bind("1. Positive Effects", 
                "Enable Boons", 
                true, 
                "Apply boon effects (Rage, Discipline, Bless, Cool, Warm, Mist, Possessed)");
                
            EnableRecoveryEffects = Config.Bind("1. Positive Effects", 
                "Enable Recovery Effects", 
                true, 
                "Apply health/stamina/mana recovery effects");
                
            EnableCombatBuffs = Config.Bind("1. Positive Effects", 
                "Enable Combat Buffs", 
                true, 
                "Apply combat buffs (Attack Up, Protection, Speed Up, Resistance, etc.)");
            
            EnableSpecialBuffs = Config.Bind("1. Positive Effects",
                "Enable Special Buffs",
                true,
                "Apply special buffs (Exalted, Energized, Prime, Elemental Buffs, etc.)");
            
            EnableImbuements = Config.Bind("1. Positive Effects",
                "Enable Imbuements",
                false,
                "Apply weapon/shield imbue effects (Fire, Frost, Lightning, Poison, etc.)");
            
            EnableRuneEffects = Config.Bind("1. Positive Effects",
                "Enable Rune Effects",
                false,
                "Apply rune effects (Shim, Egoth, Dez, Fal, Runic Lantern, etc.)");
            
            EnableFoodBuffs = Config.Bind("1. Positive Effects",
                "Enable Food Buffs",
                true,
                "Apply positive food/drink effects (Full, Refreshed, Gaberry Wine, etc.)");
            
            EnableRestEffects = Config.Bind("1. Positive Effects",
                "Enable Rest Effects",
                false,
                "Apply tent and inn rest effects (may cause sleep/drowsy)");
            
            EnableEnvironmentalEffects = Config.Bind("1. Positive Effects",
                "Enable Environmental Effects",
                false,
                "Apply environmental resistance effects (Cold/Heat resistance, Wet, etc.)");
            
            EnableMiscEffects = Config.Bind("1. Positive Effects",
                "Enable Misc Effects",
                true,
                "Apply miscellaneous positive effects (Gift of Blood, Corruption Recovery, etc.)");
            
            // Negative Effect Categories
            EnableHexes = Config.Bind("2. Negative Effects", 
                "Enable Hexes", 
                false, 
                "⚠️ Apply hex effects (Confusion, Pain, Chill, Haunted, Doom, Curse)");
                
            EnableDebuffs = Config.Bind("2. Negative Effects", 
                "Enable Debuffs", 
                false, 
                "⚠️ Apply debuff effects (Slow Down, Dizzy, Weaken, Sapped, Cripple, etc.)");
            
            EnableDoTs = Config.Bind("2. Negative Effects",
                "Enable Damage Over Time",
                false,
                "⚠️ Apply DOT effects (Bleeding, Burning, Poisoned, Immolate, Plague)");
            
            EnableExtremeNegatives = Config.Bind("2. Negative Effects",
                "Enable Extreme Negatives",
                false,
                "⚠️⚠️ DANGEROUS! Apply extreme negative effects (Petrified, Corruption, Freezing, etc.)");
            
            EnableFoodDebuffs = Config.Bind("2. Negative Effects",
                "Enable Food Debuffs",
                false,
                "⚠️ Apply negative food effects (Starving, Hungry, Parched, Drunk, etc.)");
            
            EnableDiseases = Config.Bind("2. Negative Effects",
                "Enable Diseases",
                false,
                "⚠️ Apply disease effects (Infection, Indigestion, Fever, Withdrawal, etc.)");
            
            // Custom Effects
            EnableCustomEffects = Config.Bind("3. Custom Effects",
                "Enable Custom Effects",
                false,
                "Enable custom status effect list (uses Custom Status Names below)");
                
            CustomStatusNames = Config.Bind("3. Custom Effects", 
                "Custom Status Names", 
                "", 
                "Comma-separated list of status effect identifier names (e.g., 'Rage,Discipline,Cool,Fire Imbue'). See documentation for full list.");
            
            // Apply Harmony patches
            new Harmony(GUID).PatchAll();
            
            Log.LogInfo($"{NAME} {VERSION} loaded successfully!");
            Log.LogInfo($"Press {ApplyStatusKey.Value} to apply status effects");
            Log.LogInfo($"Press {RemoveStatusKey.Value} to remove all status effects");
            Log.LogInfo($"Total effects available: 400+");
        }

        void Update()
        {
            // Check if the configured key is pressed
            if (Input.GetKeyDown(ApplyStatusKey.Value))
            {
                ApplyStatusEffects();
            }
            
            if (Input.GetKeyDown(RemoveStatusKey.Value))
            {
                RemoveAllStatusEffects();
            }
        }

        private void ApplyStatusEffects()
        {
            try
            {
                // Get the local player character
                var characterManager = CharacterManager.Instance;
                if (characterManager == null)
                {
                    Log.LogWarning("CharacterManager not found!");
                    return;
                }

                var character = characterManager.GetFirstLocalCharacter();
                if (character == null)
                {
                    Log.LogWarning("Player character not found!");
                    return;
                }

                Log.LogInfo($"Applying status effects to {character.Name}...");
                
                // Collect all status effect names to apply based on enabled categories
                List<string> statusNamesToApply = new List<string>();
                
                // Positive Effects
                if (EnableBoons.Value)
                {
                    statusNamesToApply.AddRange(PositiveBoonNames);
                    Log.LogDebug("Added Boon effects");
                }
                
                if (EnableRecoveryEffects.Value)
                {
                    statusNamesToApply.AddRange(RecoveryEffectNames);
                    Log.LogDebug("Added Recovery effects");
                }
                
                if (EnableCombatBuffs.Value)
                {
                    statusNamesToApply.AddRange(CombatBuffNames);
                    Log.LogDebug("Added Combat Buff effects");
                }
                
                if (EnableSpecialBuffs.Value)
                {
                    statusNamesToApply.AddRange(SpecialBuffNames);
                    Log.LogDebug("Added Special Buff effects");
                }
                
                if (EnableImbuements.Value)
                {
                    statusNamesToApply.AddRange(ImbueEffectNames);
                    Log.LogDebug("Added Imbuement effects");
                }
                
                if (EnableRuneEffects.Value)
                {
                    statusNamesToApply.AddRange(RuneEffectNames);
                    Log.LogDebug("Added Rune effects");
                }
                
                if (EnableFoodBuffs.Value)
                {
                    statusNamesToApply.AddRange(FoodBuffNames);
                    Log.LogDebug("Added Food Buff effects");
                }
                
                if (EnableRestEffects.Value)
                {
                    statusNamesToApply.AddRange(RestEffectNames);
                    Log.LogDebug("Added Rest effects");
                }
                
                if (EnableEnvironmentalEffects.Value)
                {
                    statusNamesToApply.AddRange(EnvironmentNames);
                    Log.LogDebug("Added Environmental effects");
                }
                
                if (EnableMiscEffects.Value)
                {
                    statusNamesToApply.AddRange(MiscEffectNames);
                    Log.LogDebug("Added Misc effects");
                }
                
                // Negative Effects (warned with ⚠️)
                if (EnableHexes.Value)
                {
                    statusNamesToApply.AddRange(HexEffectNames);
                    Log.LogWarning("Added Hex effects (may be harmful!)");
                }
                
                if (EnableDebuffs.Value)
                {
                    statusNamesToApply.AddRange(DebuffEffectNames);
                    Log.LogWarning("Added Debuff effects (may be harmful!)");
                }
                
                if (EnableDoTs.Value)
                {
                    statusNamesToApply.AddRange(DotEffectNames);
                    Log.LogWarning("Added DOT effects (will cause damage!)");
                }
                
                if (EnableExtremeNegatives.Value)
                {
                    statusNamesToApply.AddRange(ExtremeNegativeNames);
                    Log.LogWarning("Added Extreme Negative effects (DANGEROUS!)");
                }
                
                if (EnableFoodDebuffs.Value)
                {
                    statusNamesToApply.AddRange(FoodDebuffNames);
                    Log.LogWarning("Added Food Debuff effects");
                }
                
                if (EnableDiseases.Value)
                {
                    statusNamesToApply.AddRange(DiseaseNames);
                    Log.LogWarning("Added Disease effects");
                }
                
                // Add custom status names if specified
                if (EnableCustomEffects.Value && !string.IsNullOrEmpty(CustomStatusNames.Value))
                {
                    var customNames = CustomStatusNames.Value.Split(',')
                        .Select(s => s.Trim())
                        .Where(s => !string.IsNullOrEmpty(s));
                    
                    statusNamesToApply.AddRange(customNames);
                    Log.LogInfo($"Custom effects enabled: {customNames.Count()} names added");
                }
                
                // Create a hashset of target names for efficient lookup
                var targetNames = new HashSet<string>(statusNamesToApply);
                
                if (statusNamesToApply.Count == 0)
                {
                    Log.LogWarning("No status effects enabled! Check your configuration.");
                    character.CharacterUI?.ShowInfoNotification("No status effects enabled!");
                    return;
                }
                
                Log.LogInfo($"Attempting to apply {statusNamesToApply.Count} status effects from enabled categories");

                // Now we can directly match by identifier name!
                var allEffects = Resources.FindObjectsOfTypeAll<StatusEffect>();
                
                int successCount = 0;
                int failCount = 0;
                
                foreach (var statusEffect in allEffects)
                {
                    if (statusEffect == null) continue;
                    
                    // Check if this effect's identifier name is in our target list
                    if (targetNames.Contains(statusEffect.IdentifierName))
                    {
                        try
                        {
                            var appliedEffect = character.StatusEffectMngr.AddStatusEffect(statusEffect, character);
                            
                            if (appliedEffect != null)
                            {
                                Log.LogDebug($"Applied: {statusEffect.IdentifierName}");
                                successCount++;
                            }
                            else
                            {
                                Log.LogDebug($"Failed to apply: {statusEffect.IdentifierName}");
                                failCount++;
                            }
                        }
                        catch (System.Exception ex)
                        {
                            Log.LogDebug($"Failed to apply {statusEffect.IdentifierName}: {ex.Message}");
                            failCount++;
                        }
                    }
                }
                
                Log.LogInfo($"Status effects applied: {successCount} successful, {failCount} failed");
                
                // Show in-game notification
                if (character.CharacterUI != null)
                {
                    character.CharacterUI.ShowInfoNotification($"Applied {successCount} status effects!");
                }
            }
            catch (System.Exception ex)
            {
                Log.LogError($"Error applying status effects: {ex.Message}");
                Log.LogError(ex.StackTrace);
            }
        }
        
        private void RemoveAllStatusEffects()
        {
            try
            {
                // Get the local player character
                var characterManager = CharacterManager.Instance;
                if (characterManager == null)
                {
                    Log.LogWarning("CharacterManager not found!");
                    return;
                }

                var character = characterManager.GetFirstLocalCharacter();
                if (character == null)
                {
                    Log.LogWarning("Player character not found!");
                    return;
                }

                Log.LogInfo($"Removing all status effects from {character.Name}...");
                
                // Get all current status effects on the character
                var statusEffectManager = character.StatusEffectMngr;
                if (statusEffectManager == null)
                {
                    Log.LogWarning("StatusEffectManager not found!");
                    return;
                }
                
                // Get all active status effects
                var activeEffects = statusEffectManager.Statuses;
                if (activeEffects == null || activeEffects.Count == 0)
                {
                    Log.LogInfo("No status effects to remove.");
                    character.CharacterUI?.ShowInfoNotification("No active status effects!");
                    return;
                }
                
                int removeCount = activeEffects.Count;
                Log.LogInfo($"Found {removeCount} active status effects to remove");
                
                // Create a list of effect identifiers to remove
                var effectNamesToRemove = new List<string>();
                foreach (var effect in activeEffects)
                {
                    if (effect != null)
                    {
                        effectNamesToRemove.Add(effect.IdentifierName);
                    }
                }
                
                int successCount = 0;
                foreach (var effectName in effectNamesToRemove)
                {
                    try
                    {
                        // Use CleanseStatusEffect to properly remove each effect
                        statusEffectManager.CleanseStatusEffect(effectName);
                        successCount++;
                        Log.LogDebug($"Removed: {effectName}");
                    }
                    catch (System.Exception ex)
                    {
                        Log.LogDebug($"Failed to remove {effectName}: {ex.Message}");
                    }
                }
                
                Log.LogInfo($"Successfully removed {successCount} status effects");
                
                // Show in-game notification
                if (character.CharacterUI != null)
                {
                    character.CharacterUI.ShowInfoNotification($"Removed {successCount} status effects!");
                }
            }
            catch (System.Exception ex)
            {
                Log.LogError($"Error removing status effects: {ex.Message}");
                Log.LogError(ex.StackTrace);
            }
        }
    }
}

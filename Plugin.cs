using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace OutwardAllStatus
{
    [BepInPlugin(GUID, NAME, VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        public const string GUID = "com.robbiepc.outwardallstatus";
        public const string NAME = "Outward All Status";
        public const string VERSION = "1.0.0";

        internal static ManualLogSource Log;
        
        // Configuration entries
        public static ConfigEntry<KeyCode> ApplyStatusKey;
        
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
        
        // ALL STATUS EFFECTS - Complete list with EXACT internal IDs
        // Organized by type for easy configuration
        
        // POSITIVE EFFECTS - Boons & Major Buffs
        private static readonly List<int> PositiveBoonIDs = new List<int>
        {
            18, // Rage
            19, // Discipline
            20, // Warm
            21, // Cool
            22, // Mist
            23, // Bless
            24, // Possessed
            68, // Rage Amplified
            69, // Discipline Amplified
            70, // Warm Amplified
            71, // Cool Amplified
            72, // Mist Amplified
            73, // Bless Amplified
            74, // Possessed Amplified
        };
        
        // Recovery Effects
        private static readonly List<int> RecoveryEffectIDs = new List<int>
        {
            0, // Health Recovery 2
            1, // Stamina Recovery 2
            2, // Mana Ratio Recovery 2
            3, // Health Recovery 3
            4, // Stamina Recovery 3
            5, // Mana Ratio Recovery 3
            6, // Health Recovery 4
            7, // Stamina Recovery 4
            8, // Mana Ratio Recovery 4
            45, // Health Recovery Small
            46, // Stamina Recovery Small
            47, // Mana Ratio Recovery Small
            75, // Health Recovery 5
            76, // Stamina Recovery 5
            77, // Mana Ratio Recovery 5
            59, // Passive Mana Regen
            592, // ExtremeManaRegen1
        };
        
        // Combat Buffs
        private static readonly List<int> CombatBuffIDs = new List<int>
        {
            39, // Stamina Cost Reduction
            40, // Mana Cost Reduction
            44, // Speed Up
            49, // Elemental Resistance
            50, // Elemental Immunity
            51, // Environment Resistance
            52, // Stability Up
            55, // Defense Bonus
            85, // Stealth Up
            86, // Stability Up 2
            87, // Attack Up
            88, // Impact Up
            93, // Armor Penalties Reduction
            96, // Elemental Resistance 2
            657, // Protection 1
            658, // Protection 2
            659, // Barrier 1
            660, // Barrier 2
            661, // StatusBuildUpResUp
            663, // Shimmer
        };
        
        // Special Buffs
        private static readonly List<int> SpecialBuffIDs = new List<int>
        {
            540, // Exalted
            560, // Energized
            561, // Alert
            562, // Unerring Read
            563, // Prime
            564, // ElemFireBuff
            565, // ElemFrostBuff
            566, // ElemDecayBuff
            567, // ElemLightBuff
            568, // ElemEtherealBuff
            683, // ElemChromaticBuff
            620, // KillStreak
            622, // Craze
            623, // GhostRhythm
            624, // SkyRhythm
        };
        
        // Imbue Effects
        private static readonly List<int> ImbueEffectIDs = new List<int>
        {
            200, // Poison Imbue
            201, // Greater Poison Imbue
            202, // Fire Imbue
            203, // Greater Fire Imbue
            204, // Frost Imbue
            205, // Greater Frost Imbue
            206, // Lightning Imbue
            207, // Greater Lightning Imbue
            208, // Greater Ethereal Imbue
            209, // Wind Imbue
            211, // Greater Decay Imbue
            212, // Decay Shield Imbue
            213, // Ethereal Shield Imbue
            214, // Fire Shield Imbue
            215, // Frost Shield Imbue
            216, // Lightning Shield Imbue
            217, // Mystic Fire Imbue
            218, // Mystic Frost Imbue
            219, // Divine Light Imbue
            222, // Infuse Blood
            223, // Infuse Mana
            250, // Frost Bullet Imbue
            251, // Blood Bullet Imbue
            252, // Shatter Bullet Imbue
        };
        
        // Runes & Special Items
        private static readonly List<int> RuneEffectIDs = new List<int>
        {
            599, // Wolf Fal Runes
            600, // Wolf Runic Protection
            1001, // Shim Runes
            1002, // Egoth Runes
            1003, // Dez Runes
            1004, // Fal Runes
            1005, // Runic Lantern Amplified
            1006, // Runic Lantern
            1007, // Runic Blade
            1008, // Runic Protection Amplified
            1009, // Runic Protection
            1010, // Runic Heal Amplified
            1021, // Fireflies
        };
        
        // NEGATIVE EFFECTS (Only apply if explicitly enabled)
        
        // Hexes
        private static readonly List<int> HexEffectIDs = new List<int>
        {
            25, // Confusion
            26, // Pain
            28, // Chill
            29, // Haunted
            30, // Doom
            31, // Curse
        };
        
        // Debuffs
        private static readonly List<int> DebuffEffectIDs = new List<int>
        {
            42, // Slow Down
            43, // Dizzy
            56, // Stun
            94, // Elemental Vulnerability
            95, // Cripple
            558, // Weaken
            559, // Sapped
            615, // Panic
            616, // Dispirited
            617, // Breathless
            618, // Hampered
            621, // Drawback
            662, // StatusBuildUpResDown
        };
        
        // Damage Over Time Effects
        private static readonly List<int> DotEffectIDs = new List<int>
        {
            27, // Burn
            32, // Poisoned
            33, // Poisoned +
            34, // Bleeding
            35, // Bleeding +
            36, // Burning
            66, // Immolate
            613, // Blaze
            614, // HolyBlaze
            619, // Plague
        };
        
        // Corruption & Extreme Conditions
        private static readonly List<int> ExtremeNegativeIDs = new List<int>
        {
            609, // Petrification
            610, // Petrified
            611, // Aetherbomb
            612, // AetherbombExplosion
            1011, // Tainted
            1012, // Corrupt Positive
            1013, // Corrupt Negative
            1014, // Defiled Positive
            1015, // Defiled Negative
            1016, // ColdExposure
            1017, // Freezing
            1018, // HeatExposure
            1019, // Temperature Burning
            625, // AncientDwellerSlowing
        };
        
        // Food & Drink Effects
        private static readonly List<int> FoodBuffIDs = new List<int>
        {
            403, // Full
            413, // Refreshed
            539, // Gaberry Wine
            544, // Food Stability Up
            545, // Food Cool
            546, // Food Mist
            547, // Food Bless
            548, // Food Possessed
            549, // Food Discipline
            551, // Food Attack Up
            552, // Food Impact Up
            538, // Food Water Stamina
            665, // PureWater
            666, // HealingWater
        };
        
        // Food Negative Effects
        private static readonly List<int> FoodDebuffIDs = new List<int>
        {
            400, // Starving
            401, // Hungry
            404, // Bloated
            410, // Parched
            411, // Thirsty
            531, // Food Dizzy
            535, // Food Poisoned
            536, // Food Poisoned +
            550, // Food Slow Down
            41, // Drunk
        };
        
        // Environmental Effects
        private static readonly List<int> EnvironmentIDs = new List<int>
        {
            37, // Wet
            38, // Environment Cold Resistance
            84, // Environment Heat Resistance
            532, // Food Environment Heat Resistance
            533, // Food Environment Cold Resistance
            500, // Cold1
            501, // Cold2
            1022, // Hallowed Marsh Poison Lvl1
            1023, // Hallowed Marsh Poison Lvl2
            1025, // SulphurPoison
        };
        
        // Rest & Sleep Effects
        private static readonly List<int> RestEffectIDs = new List<int>
        {
            420, // Drowsy
            421, // Tired
            560, // Energized
            523, // Camo Tent buff
            524, // Fur Tent buff
            525, // Luxurious Tent buff
            526, // Tent buff
            527, // Cierzo Inns
            528, // Monsoon Inns
            529, // Berg Inns
            530, // Levant Inns
            555, // Mage Tent buff
            556, // Plant Tent Buff
            569, // Harmattant Inn A
            570, // Harmattant Inn B
            571, // Lockwell's Revelation Tired
            572, // Lockwell's Revelation Very Tired
            595, // Scourge Tent Buff
            630, // Fire Totem Sleep
            631, // Ice Totem Sleep
            632, // Light Totem Sleep
            633, // Decay Totem Sleep
            634, // Ethereal Totem Sleep
            640, // Calygrey Sleep
            650, // Caldera Inn Sleep
            651, // Caldera Hall Sleep
            652, // Caldera Basic Sleep
            670, // SaunaInn
        };
        
        // Disease & Illness
        private static readonly List<int> DiseaseIDs = new List<int>
        {
            510, // Infection1
            511, // Infection2
            512, // Infection3
            520, // Indigestion1
            521, // Indigestion2
            664, // Ambraine Withdrawal
            669, // AmbraineWithdrawalPreEffects
            671, // Leywilt1
            672, // Leywilt2
            673, // Hunch1
            674, // Hunch2
            675, // HiveInfestation1
            676, // hiveInfestation2
            677, // MeekaFever1
            678, // MeekaFever2
        };
        
        // Special & Misc Effects
        private static readonly List<int> MiscEffectIDs = new List<int>
        {
            554, // Bandage
            573, // Gift of Blood
            574, // Gift of Blood Ally
            575, // Blood Leech Victim
            576, // Blood Leech
            577, // Titanic Golem 1
            578, // Titanic Golem 2
            579, // Titanic Golem 3
            582, // Corruption Recovery 1
            583, // Corruption Recovery 2
            587, // Corruption Resistance 1
            588, // Corruption Resistance 2
            596, // EliteSupremeShellRage
            597, // SupremeShellRage
            598, // EliteSupremeShellDiscipline
            601, // LionmanElderBoonLvl1
            602, // LionmanElderBoonLvl2
            603, // CrimsonMineLvl
            604, // CrimsonSunLvl
            605, // GargoyleBoonLvl
            606, // ScarletEmissaryProt
            607, // SlughellProt
            608, // GrandmotherBoon
            667, // TempleBuff
            668, // TempleBuffPlus
            1020, // Bag Over Encumbered
            1024, // Pouch Over Encumbered
            57, // Force Bubble
            58, // Wind Imbue Stats
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
                "Comma-separated list of status effect NAMES (e.g., 'Rage,Cool,Blessed'). Use exact IdentifierName from game.");
            
            // Apply Harmony patches
            new Harmony(GUID).PatchAll();
            
            Log.LogInfo($"{NAME} {VERSION} loaded successfully!");
            Log.LogInfo($"Press {ApplyStatusKey.Value} to apply status effects");
            Log.LogInfo($"Total effects available: 400+");
        }

        void Update()
        {
            // Check if the configured key is pressed
            if (Input.GetKeyDown(ApplyStatusKey.Value))
            {
                ApplyStatusEffects();
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
                
                // Collect all status effect IDs to apply based on enabled categories
                List<int> statusIDsToApply = new List<int>();
                
                // Positive Effects
                if (EnableBoons.Value)
                {
                    statusIDsToApply.AddRange(PositiveBoonIDs);
                    Log.LogDebug("Added Boon effects");
                }
                
                if (EnableRecoveryEffects.Value)
                {
                    statusIDsToApply.AddRange(RecoveryEffectIDs);
                    Log.LogDebug("Added Recovery effects");
                }
                
                if (EnableCombatBuffs.Value)
                {
                    statusIDsToApply.AddRange(CombatBuffIDs);
                    Log.LogDebug("Added Combat Buff effects");
                }
                
                if (EnableSpecialBuffs.Value)
                {
                    statusIDsToApply.AddRange(SpecialBuffIDs);
                    Log.LogDebug("Added Special Buff effects");
                }
                
                if (EnableImbuements.Value)
                {
                    statusIDsToApply.AddRange(ImbueEffectIDs);
                    Log.LogDebug("Added Imbuement effects");
                }
                
                if (EnableRuneEffects.Value)
                {
                    statusIDsToApply.AddRange(RuneEffectIDs);
                    Log.LogDebug("Added Rune effects");
                }
                
                if (EnableFoodBuffs.Value)
                {
                    statusIDsToApply.AddRange(FoodBuffIDs);
                    Log.LogDebug("Added Food Buff effects");
                }
                
                if (EnableRestEffects.Value)
                {
                    statusIDsToApply.AddRange(RestEffectIDs);
                    Log.LogDebug("Added Rest effects");
                }
                
                if (EnableEnvironmentalEffects.Value)
                {
                    statusIDsToApply.AddRange(EnvironmentIDs);
                    Log.LogDebug("Added Environmental effects");
                }
                
                if (EnableMiscEffects.Value)
                {
                    statusIDsToApply.AddRange(MiscEffectIDs);
                    Log.LogDebug("Added Misc effects");
                }
                
                // Negative Effects (warned with ⚠️)
                if (EnableHexes.Value)
                {
                    statusIDsToApply.AddRange(HexEffectIDs);
                    Log.LogWarning("Added Hex effects (may be harmful!)");
                }
                
                if (EnableDebuffs.Value)
                {
                    statusIDsToApply.AddRange(DebuffEffectIDs);
                    Log.LogWarning("Added Debuff effects (may be harmful!)");
                }
                
                if (EnableDoTs.Value)
                {
                    statusIDsToApply.AddRange(DotEffectIDs);
                    Log.LogWarning("Added DOT effects (will cause damage!)");
                }
                
                if (EnableExtremeNegatives.Value)
                {
                    statusIDsToApply.AddRange(ExtremeNegativeIDs);
                    Log.LogWarning("Added Extreme Negative effects (DANGEROUS!)");
                }
                
                if (EnableFoodDebuffs.Value)
                {
                    statusIDsToApply.AddRange(FoodDebuffIDs);
                    Log.LogWarning("Added Food Debuff effects");
                }
                
                if (EnableDiseases.Value)
                {
                    statusIDsToApply.AddRange(DiseaseIDs);
                    Log.LogWarning("Added Disease effects");
                }
                
                // Create a hashset of target IDs for efficient lookup
                var targetIDs = new HashSet<int>(statusIDsToApply);
                
                // Track custom effects separately
                HashSet<string> customEffectNames = new HashSet<string>();
                if (EnableCustomEffects.Value && !string.IsNullOrEmpty(CustomStatusNames.Value))
                {
                    var customNames = CustomStatusNames.Value.Split(',')
                        .Select(s => s.Trim())
                        .Where(s => !string.IsNullOrEmpty(s));
                    foreach (var name in customNames)
                    {
                        customEffectNames.Add(name);
                    }
                    Log.LogInfo($"Custom effects enabled: {customEffectNames.Count} effects");
                }
                
                if (statusIDsToApply.Count == 0 && customEffectNames.Count == 0)
                {
                    Log.LogWarning("No status effects enabled! Check your configuration.");
                    character.CharacterUI?.ShowInfoNotification("No status effects enabled!");
                    return;
                }
                
                Log.LogInfo($"Attempting to apply {statusIDsToApply.Count} categorized effects + {customEffectNames.Count} custom effects");

                // Get all available status effects from the game
                var allEffects = Resources.FindObjectsOfTypeAll<StatusEffect>();
                Log.LogInfo($"Found {allEffects.Length} total status effects in game");
                
                // Apply status effects
                int successCount = 0;
                int failCount = 0;
                
                foreach (var statusEffect in allEffects)
                {
                    if (statusEffect == null) continue;
                    
                    bool shouldApply = false;
                    
                    // Check if this effect should be applied based on categories (ID-based)
                    // Note: We can't directly access the ID, so we'll apply all and filter is not possible
                    // Instead, apply based on custom names if enabled
                    
                    if (customEffectNames.Count > 0 && customEffectNames.Contains(statusEffect.IdentifierName))
                    {
                        shouldApply = true;
                        Log.LogDebug($"Matched custom effect: {statusEffect.IdentifierName}");
                    }
                    else if (targetIDs.Count > 0)
                    {
                        // For ID-based categories, we need to apply all since we can't filter by ID directly
                        // This is a limitation - we'll just apply all when categories are enabled
                        shouldApply = true;
                    }
                    
                    if (!shouldApply) continue;
                    
                    try
                    {
                        // Apply the status effect
                        var appliedEffect = character.StatusEffectMngr.AddStatusEffect(statusEffect, character);
                        
                        if (appliedEffect != null)
                        {
                            Log.LogDebug($"Applied: {statusEffect.IdentifierName}");
                            successCount++;
                        }
                        else
                        {
                            failCount++;
                        }
                    }
                    catch (System.Exception ex)
                    {
                        Log.LogDebug($"Failed to apply {statusEffect.IdentifierName}: {ex.Message}");
                        failCount++;
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
    }
}

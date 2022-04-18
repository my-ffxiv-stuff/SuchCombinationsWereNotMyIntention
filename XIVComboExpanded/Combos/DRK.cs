using Dalamud.Game.ClientState.JobGauge.Types;

namespace XIVComboExpandedPlugin.Combos;

internal static class DRK
{
    public const byte JobID = 32;

    public const uint
        HardSlash = 3617,
        Unleash = 3621,
        SyphonStrike = 3623,
        Souleater = 3632,
        BloodWeapon = 3625,
        SaltedEarth = 3639,
        AbyssalDrain = 3641,
        CarveAndSpit = 3643,
        Quietus = 7391,
        Bloodspiller = 7392,
        FloodOfDarkness = 16466,
        EdgeOfDarkness = 16467,
        StalwartSoul = 16468,
        FloodOfShadow = 16469,
        EdgeOfShadow = 16470,
        LivingShadow = 16472,
        SaltAndDarkness = 25755,
        Shadowbringer = 25757;
        Plunge = ;

    public static class Buffs
    {
        public const ushort
            BloodWeapon = 742,
            Darkside = 751,
            Delirium = 1972;
    }

    public static class Debuffs
    {
        public const ushort
            Placeholder = 0;
    }

    public static class Levels
    {
        public const byte
            SyphonStrike = 2,
            Souleater = 26,
            FloodOfDarkness = 30,
            BloodWeapon = 35,
            EdgeOfDarkness = 40,
            StalwartSoul = 40,
            SaltedEarth = 52,
            AbyssalDrain = 56,
            CarveAndSpit = 60,
            Bloodspiller = 62,
            Quietus = 64,
            Delirium = 68,
            Shadow = 74,
            LivingShadow = 80,
            SaltAndDarkness = 86,
            Shadowbringer = 90;
    }
}

internal class OneOGCD : CustomCombo
{
    protected internal override CustomCombo Preset Preset { get; } = CustomComboPresent.DrkAny;
    
    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == DRK.Delirium)
        {
            var gauge = GetJobGauge<DRKGauge>();
            
            if (IsEnabled(CustomComboPresent.OneOGCD))
            {
                if (isOffCooldown(DRK.Delirium))
                {
                    return DRK.Delirium;
                }
                if (HasEffect(DRK.Buffs.Delirium) && isOffCooldown(DRK.LivingShadow))
                {
                    return DRK.LivingShadow;
                }
                if (isOffCooldown(DRK.SaltedEarth))
                {
                    return DRK.SaltedEarth;
                }
                if (HasEffect(DRK.Darkside) && GetRemainingCharges(DRK.Shadowbringer) == 2)
                {
                    return DRK.Shadowbringer;
                }
                if (GetRemainingCharges(DRK.Shadowbringer) == 1)
                {
                    return DRK.CarveAndSpit;
                }
                if (HasEffect(DRK.Darkside) && GetRemainingCharges(DRK.Shadowbringer) == 1)
                {
                    return DRK.Shadowbringer;
                }
                if (GetRemainingCharges(DRK.Shadowbringer) == 0)
                {
                    return DRK.SaltAndDarkness;
                }
                return DRK.Delirium;
            }
       }
       return actionID;
   }
}
            
/*
internal class DarkSouleater : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.DrkAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == DRK.Souleater)
        {
            var gauge = GetJobGauge<DRKGauge>();

            if (IsEnabled(CustomComboPreset.DarkDeliriumFeature))
            {
                if (level >= DRK.Levels.Bloodspiller && level >= DRK.Levels.Delirium && HasEffect(DRK.Buffs.Delirium))
                    return DRK.Bloodspiller;
            }

            if (IsEnabled(CustomComboPreset.DarkSouleaterCombo))
            {
                if (IsEnabled(CustomComboPreset.DarkSouleaterOvercapFeature))
                {
                    if (level >= DRK.Levels.Bloodspiller && gauge.Blood > 90 && HasEffect(DRK.Buffs.BloodWeapon))
                        return DRK.Bloodspiller;
                }

                if (comboTime > 0)
                {
                    if (lastComboMove == DRK.SyphonStrike && level >= DRK.Levels.Souleater)
                    {
                        if (IsEnabled(CustomComboPreset.DarkSouleaterOvercapFeature))
                        {
                            if (level >= DRK.Levels.Bloodspiller && (gauge.Blood > 80 || (gauge.Blood > 70 && HasEffect(DRK.Buffs.BloodWeapon))))
                                return DRK.Bloodspiller;
                        }

                        return DRK.Souleater;
                    }

                    if (lastComboMove == DRK.HardSlash && level >= DRK.Levels.SyphonStrike)
                        return DRK.SyphonStrike;
                }

                return DRK.HardSlash;
            }
        }

        return actionID;
    }
}

internal class DarkStalwartSoul : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.DrkAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == DRK.StalwartSoul)
        {
            var gauge = GetJobGauge<DRKGauge>();

            if (IsEnabled(CustomComboPreset.DarkDeliriumFeature))
            {
                if (level >= DRK.Levels.Quietus && level >= DRK.Levels.Delirium && HasEffect(DRK.Buffs.Delirium))
                    return DRK.Quietus;
            }

            if (IsEnabled(CustomComboPreset.DarkStalwartSoulCombo))
            {
                if (IsEnabled(CustomComboPreset.DarkStalwartSoulOvercapFeature))
                {
                    if (level >= DRK.Levels.Quietus && gauge.Blood > 90 && HasEffect(DRK.Buffs.BloodWeapon))
                        return DRK.Quietus;
                }

                if (comboTime > 0)
                {
                    if (lastComboMove == DRK.Unleash && level >= DRK.Levels.StalwartSoul)
                    {
                        if (IsEnabled(CustomComboPreset.DarkStalwartSoulOvercapFeature))
                        {
                            if (level >= DRK.Levels.Quietus && (gauge.Blood > 80 || (gauge.Blood > 70 && HasEffect(DRK.Buffs.BloodWeapon))))
                                return DRK.Quietus;
                        }

                        return DRK.StalwartSoul;
                    }
                }

                return DRK.Unleash;
            }
        }

        return actionID;
    }
}

internal class DarkCarveAndSpitAbyssalDrain : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.DrkAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == DRK.CarveAndSpit || actionID == DRK.AbyssalDrain)
        {
            if (IsEnabled(CustomComboPreset.DarkBloodWeaponFeature))
            {
                if (level < DRK.Levels.CarveAndSpit)
                    return DRK.BloodWeapon;

                if (level >= DRK.Levels.BloodWeapon && IsOffCooldown(DRK.BloodWeapon))
                    return DRK.BloodWeapon;
            }
        }

        return actionID;
    }
}

internal class DarkQuietusBloodspiller : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.DrkAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == DRK.Quietus || actionID == DRK.Bloodspiller)
        {
            var gauge = GetJobGauge<DRKGauge>();

            if (IsEnabled(CustomComboPreset.DarkLivingShadowFeature))
            {
                if (level >= DRK.Levels.LivingShadow && gauge.Blood >= 50 && IsOffCooldown(DRK.LivingShadow))
                    return DRK.LivingShadow;
            }
        }

        return actionID;
    }
}

internal class DarkLivingShadow : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.DrkAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == DRK.LivingShadow)
        {
            var gauge = GetJobGauge<DRKGauge>();

            if (IsEnabled(CustomComboPreset.DarkLivingShadowbringerFeature))
            {
                if (level >= DRK.Levels.Shadowbringer && gauge.ShadowTimeRemaining > 0 && HasCharges(DRK.Shadowbringer))
                    return DRK.Shadowbringer;
            }

            if (IsEnabled(CustomComboPreset.DarkLivingShadowbringerHpFeature))
            {
                if (level >= DRK.Levels.Shadowbringer && HasCharges(DRK.Shadowbringer) && IsOnCooldown(DRK.LivingShadow))
                    return DRK.Shadowbringer;
            }
        }

        return actionID;
    }
}
*/

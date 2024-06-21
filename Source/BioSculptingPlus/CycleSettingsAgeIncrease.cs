using RimWorld;
using SettingsHelper;
using Verse;

namespace BioSculptingPlus;

public class CycleSettingsAgeIncrease(string label, float potency = 1f, bool enabled = true, float duration = 1f)
    : CycleSettings(label, enabled, duration)
{
    protected float? CheckTimeIncrease;
    public float TimeIncrease = potency;

    public void ScribeValues(string label, float potency = 1f, bool enabled = true, float duration = 1f)
    {
        ScribeValues(label, enabled, duration);
        Scribe_Values.Look(ref TimeIncrease, label + "AgeIncrease", potency);
    }

    public new void DoCustomCycleSettings(ref Listing_Standard list)
    {
        list.AddLabelLine(Label.Translate());
        list.CheckboxLabeled("Settings_Enable".Translate(), ref Enabled);
        if (Enabled)
        {
            list.AddLabeledSlider("Settings_TimeRequired".Translate(), ref Duration, 0f, 60f, null, null, 0.1f, true,
                ((int)(Duration * GenDate.TicksPerDay)).ToStringTicksToPeriod(), 0.2f);
            list.AddLabeledSlider("Settings_TimeAgeIncreaseCycle".Translate(), ref TimeIncrease, 0f, 1200f, null, null,
                15f, true, ((int)(TimeIncrease * GenDate.TicksPerDay)).ToStringTicksToPeriod(), 0.2f);
        }

        Store();
    }

    public new void Store()
    {
        base.Store();
        CheckTimeIncrease ??= TimeIncrease;
    }

    public new bool NeedPatch()
    {
        return base.NeedPatch() || CheckTimeIncrease != TimeIncrease;
    }

    public new bool NeedReload()
    {
        return base.NeedReload();
    }
}
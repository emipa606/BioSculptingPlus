using RimWorld;
using SettingsHelper;
using Verse;

namespace BioSculptingPlus;

public class CycleSettings(string label, bool enabled = true, float duration = 1f)
{
    protected readonly string Label = label;
    protected float? CheckDuration;

    protected bool? CheckEnabled;

    public float Duration = duration;

    public bool Enabled = enabled;

    public void ScribeValues(string label, bool enabled = true, float duration = 1f)
    {
        Scribe_Values.Look(ref Enabled, label + "Enabled", enabled);
        Scribe_Values.Look(ref Duration, label + "Duration", duration);
    }

    public void DoCustomCycleSettings(ref Listing_Standard list)
    {
        list.AddLabelLine(Label.Translate());
        list.CheckboxLabeled("Settings_Enable".Translate(), ref Enabled);
        if (Enabled)
        {
            list.AddLabeledSlider("Settings_TimeRequired".Translate().RawText, ref Duration, 0f, 60f, null, null, 0.1f,
                true, ((int)(Duration * GenDate.TicksPerDay)).ToStringTicksToPeriod(), 0.2f);
        }

        Store();
    }

    protected void Store()
    {
        CheckEnabled ??= Enabled;
        CheckDuration ??= Duration;
    }

    protected bool NeedPatch()
    {
        return CheckDuration != Duration;
    }

    protected bool NeedReload()
    {
        return CheckEnabled != Enabled;
    }
}
using SettingsHelper;
using Verse;

namespace BioSculptingPlus
{
    public class CycleSettings
    {
        #region Actual

        public string Label;
        public bool Enabled;
        public float Duration;

        #endregion

        #region Storage

        protected bool? CheckEnabled;
        protected float? CheckDuration;

        #endregion

        public CycleSettings(string label, bool enabled = true, float duration = 1f)
        {
            Label = label;
            Enabled = enabled;
            Duration = duration;
        }

        public void ScribeValues(string label, bool enabled = true, float duration = 1f)
        {
            Scribe_Values.Look(ref Enabled, label + "Enabled", enabled);
            Scribe_Values.Look(ref Duration, label + "Duration", duration);
        }

        public void DoCustomCycleSettings(ref Listing_Standard list)
        {
            list.AddLabelLine(Label.Translate());
            list.CheckboxLabeled("Settings_Enable".Translate(), ref Enabled);
            list.AddLabeledSlider("Settings_TimeRequired".Translate(), ref Duration, 0f, 60f, null, null, 0.1f, true, Duration.ToString() + "Settings_Days".Translate(), 0.2f);
            Store();
        }

        public void Store()
        {
            CheckEnabled = CheckEnabled != null ? CheckEnabled : Enabled;
            CheckDuration = CheckDuration != null ? CheckDuration : Duration;
        }

        public bool NeedPatch()
        {
            return (
                CheckDuration != Duration
                );
        }

        public bool NeedReload()
        {
            return (CheckEnabled != Enabled);
        }

    }
}

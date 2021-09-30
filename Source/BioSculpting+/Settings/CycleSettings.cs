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
        public float Nutrition;

        #endregion

        #region Storage

        protected bool? CheckEnabled;
        protected float? CheckDuration;
        protected float? CheckNutrition;

        #endregion

        public CycleSettings(string label, bool enabled = true, float duration = 1f, float nutrition = 1f)
        {
            Label = label;
            Enabled = enabled;
            Duration = duration;
            Nutrition = nutrition;
        }

        public void ScribeValues(string label, bool enabled = true, float duration = 1f, float nutrition = 1f)
        {
            Scribe_Values.Look(ref Enabled, label + "Enabled", enabled);
            Scribe_Values.Look(ref Duration, label + "Duration", duration);
            Scribe_Values.Look(ref Nutrition, label + "Nutrition", nutrition);
        }

        public void DoCustomCycleSettings(ref Listing_Standard list)
        {
            list.AddLabelLine(Label.Translate());
            list.CheckboxLabeled("Settings_Enable".Translate(), ref Enabled);
            list.AddLabeledSlider("Settings_TimeRequired".Translate(), ref Duration, 0f, 60f, null, null, 0.1f, true, Duration.ToString() + "Settings_Days".Translate(), 0.2f);
            list.AddLabeledSlider("Settings_NutritionRequired".Translate(), ref Nutrition, 0f, 60f, null, null, 0.1f, true, Nutrition.ToString() + "Settings_Nutrition".Translate(), 0.2f);
            Store();
        }

        public void Store()
        {
            CheckEnabled = CheckEnabled != null ? CheckEnabled : Enabled;
            CheckDuration = CheckDuration != null ? CheckDuration : Duration;
            CheckNutrition = CheckNutrition != null ? CheckNutrition : Nutrition;
        }

        public bool NeedPatch()
        {
            return (
                CheckDuration != Duration ||
                CheckNutrition != Nutrition
                );
        }

        public bool NeedReload()
        {
            return (CheckEnabled != Enabled);
        }

    }
}

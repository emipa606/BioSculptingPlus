using RimWorld;
using Verse;
using UnityEngine;
using SettingsHelper;
using HarmonyLib;

namespace BioSculptingPlus
{
    public class Settings : ModSettings
    {
        #region Settings

        public CycleSettings BeautyCycleSettings = new CycleSettings("Settings_BeautyCycle", true, 1f, 1f);
        public CycleSettingsAgeIncrease AgeIncreaseCycleSettings = new CycleSettingsAgeIncrease("Settings_AgeIncreaseCycle", 1f, true, 1f, 1f);
        public CycleSettings VoiceCycleSettings = new CycleSettings("Settings_VoiceCycle", true, 1f, 1f);
        public CycleSettings ToughCycleSettings = new CycleSettings("Settings_ToughCycle", true, 1f, 1f);
        public CycleSettings ImmunityCycleSettings = new CycleSettings("Settings_ImmunityCycle", true, 1f, 1f);

        private Vector2 scrollPosition;

        #endregion

        public override void ExposeData()
        {
            BeautyCycleSettings.ScribeValues("BeautyCycle");
            AgeIncreaseCycleSettings.ScribeValues("AgeIncreaseCycle");
            VoiceCycleSettings.ScribeValues("VoiceCycle");
            ToughCycleSettings.ScribeValues("ToughCycle");
            ImmunityCycleSettings.ScribeValues("ImmunityCycle");

            base.ExposeData();
        }

        public void DoWindowContents(Rect canvas)
        {
            Rect outRect = canvas.TopPart(0.9f);
            Rect rect = new Rect(0f, 0f, outRect.width - 18f, 1500f);
            Widgets.BeginScrollView(outRect, ref scrollPosition, rect);
            Listing_Standard list = new Listing_Standard();
            list.Begin(rect);

            BeautyCycleSettings.DoCustomCycleSettings(ref list);
            list.AddHorizontalLine(ListingStandardHelper.Gap);
            AgeIncreaseCycleSettings.DoCustomCycleSettings(ref list);
            list.AddHorizontalLine(ListingStandardHelper.Gap);
            VoiceCycleSettings.DoCustomCycleSettings(ref list);
            list.AddHorizontalLine(ListingStandardHelper.Gap);
            ToughCycleSettings.DoCustomCycleSettings(ref list);
            list.AddHorizontalLine(ListingStandardHelper.Gap);
            ImmunityCycleSettings.DoCustomCycleSettings(ref list);

            list.End();
            Widgets.EndScrollView();

            Rect rect2 = canvas.BottomPart(0.075f).LeftPart(0.3f);
            rect2.height = canvas.height * 0.05f;
            if (Widgets.ButtonText(rect2, "Apply_Custom_Values".Translate()))
            {
                ApplySettings();
            }
            rect2.x += canvas.width * 0.7f;
            if (Widgets.ButtonText(rect2, "Reset Values"))
            {
                // Beauty Cycle
                BeautyCycleSettings.Duration = 1f;
                BeautyCycleSettings.Nutrition = 1f;

                // Age Increase Cycle
                AgeIncreaseCycleSettings.Duration = 1f;
                AgeIncreaseCycleSettings.Nutrition = 1f;
                AgeIncreaseCycleSettings.TimeIncrease = 1f;

                // Voice Fix Cycle
                VoiceCycleSettings.Duration = 1f;
                VoiceCycleSettings.Nutrition = 1f;

                // Tough Cycle
                ToughCycleSettings.Duration = 1f;
                ToughCycleSettings.Nutrition = 1f;

                // Immunity Cycle
                ImmunityCycleSettings.Duration = 1f;
                ImmunityCycleSettings.Nutrition = 1f;

                ApplySettings();
            }
        }

        public void ApplySettings()
        {
            // Beauty Cycle
            (DefDatabase<ThingDef>.GetNamed("BiosculpterPod").comps.Find((CompProperties x) => x.GetType() == typeof(CompProperties_BiosculpterPod_BeautyCycle) && x.compClass == typeof(CompBiosculpterPod_BeautyCycle)) as CompProperties_BiosculpterPod_BeautyCycle).durationDays = BeautyCycleSettings.Duration;
            (DefDatabase<ThingDef>.GetNamed("BiosculpterPod").comps.Find((CompProperties x) => x.GetType() == typeof(CompProperties_BiosculpterPod_BeautyCycle) && x.compClass == typeof(CompBiosculpterPod_BeautyCycle)) as CompProperties_BiosculpterPod_BeautyCycle).nutritionRequired = BeautyCycleSettings.Nutrition;

            // Age Increase Cycle
            (DefDatabase<ThingDef>.GetNamed("BiosculpterPod").comps.Find((CompProperties x) => x.GetType() == typeof(CompProperties_BiosculpterPod_AgeIncreaseCycle) && x.compClass == typeof(CompBiosculpterPod_AgeIncreaseCycle)) as CompProperties_BiosculpterPod_AgeIncreaseCycle).durationDays = AgeIncreaseCycleSettings.Duration;
            (DefDatabase<ThingDef>.GetNamed("BiosculpterPod").comps.Find((CompProperties x) => x.GetType() == typeof(CompProperties_BiosculpterPod_AgeIncreaseCycle) && x.compClass == typeof(CompBiosculpterPod_AgeIncreaseCycle)) as CompProperties_BiosculpterPod_AgeIncreaseCycle).nutritionRequired = AgeIncreaseCycleSettings.Nutrition;

            // Voice Fix Cycle
            (DefDatabase<ThingDef>.GetNamed("BiosculpterPod").comps.Find((CompProperties x) => x.GetType() == typeof(CompProperties_BiosculpterPod_VoiceCycle) && x.compClass == typeof(CompBiosculpterPod_VoiceCycle)) as CompProperties_BiosculpterPod_VoiceCycle).durationDays = VoiceCycleSettings.Duration;
            (DefDatabase<ThingDef>.GetNamed("BiosculpterPod").comps.Find((CompProperties x) => x.GetType() == typeof(CompProperties_BiosculpterPod_VoiceCycle) && x.compClass == typeof(CompBiosculpterPod_VoiceCycle)) as CompProperties_BiosculpterPod_VoiceCycle).nutritionRequired = VoiceCycleSettings.Nutrition;

            // Tough Cycle
            (DefDatabase<ThingDef>.GetNamed("BiosculpterPod").comps.Find((CompProperties x) => x.GetType() == typeof(CompProperties_BiosculpterPod_ToughCycle) && x.compClass == typeof(CompBiosculpterPod_ToughCycle)) as CompProperties_BiosculpterPod_ToughCycle).durationDays = ToughCycleSettings.Duration;
            (DefDatabase<ThingDef>.GetNamed("BiosculpterPod").comps.Find((CompProperties x) => x.GetType() == typeof(CompProperties_BiosculpterPod_ToughCycle) && x.compClass == typeof(CompBiosculpterPod_ToughCycle)) as CompProperties_BiosculpterPod_ToughCycle).nutritionRequired = ToughCycleSettings.Nutrition;

            // Immunity Cycle
            (DefDatabase<ThingDef>.GetNamed("BiosculpterPod").comps.Find((CompProperties x) => x.GetType() == typeof(CompProperties_BiosculpterPod_ImmunityCycle) && x.compClass == typeof(CompBiosculpterPod_ImmunityCycle)) as CompProperties_BiosculpterPod_ImmunityCycle).durationDays = ImmunityCycleSettings.Duration;
            (DefDatabase<ThingDef>.GetNamed("BiosculpterPod").comps.Find((CompProperties x) => x.GetType() == typeof(CompProperties_BiosculpterPod_ImmunityCycle) && x.compClass == typeof(CompBiosculpterPod_ImmunityCycle)) as CompProperties_BiosculpterPod_ImmunityCycle).nutritionRequired = ImmunityCycleSettings.Nutrition;
        }
    }
}

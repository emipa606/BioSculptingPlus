﻿using RimWorld;
using Verse;
using UnityEngine;
using SettingsHelper;
using HarmonyLib;

namespace BioSculptingPlus
{
    public class Settings : ModSettings
    {
        #region Settings

        public CycleSettings BeautyCycleSettings = new CycleSettings("Settings_BeautyCycle", true, RecommendedValues.BeautyCycle.Duration, RecommendedValues.BeautyCycle.Nutrition);
        public CycleSettingsAgeIncrease AgeIncreaseCycleSettings = new CycleSettingsAgeIncrease("Settings_AgeIncreaseCycle", RecommendedValues.AgeIncreaseCycle.Potency, true, RecommendedValues.AgeIncreaseCycle.Duration, RecommendedValues.AgeIncreaseCycle.Nutrition);
        public CycleSettings VoiceCycleSettings = new CycleSettings("Settings_VoiceCycle", true, RecommendedValues.VoiceCycle.Duration, RecommendedValues.VoiceCycle.Nutrition);
        public CycleSettings ToughCycleSettings = new CycleSettings("Settings_ToughCycle", true, RecommendedValues.ToughCycle.Duration, RecommendedValues.ToughCycle.Nutrition);
        public CycleSettings ImmunityCycleSettings = new CycleSettings("Settings_ImmunityCycle", true, RecommendedValues.ImmunityCycle.Duration, RecommendedValues.ImmunityCycle.Nutrition);

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
            if (Widgets.ButtonText(rect2, "Apply_Recommended_Values".Translate()))
            {
                // Beauty Cycle
                BeautyCycleSettings.Duration = RecommendedValues.BeautyCycle.Duration;
                BeautyCycleSettings.Nutrition = RecommendedValues.BeautyCycle.Nutrition;

                // Age Increase Cycle
                AgeIncreaseCycleSettings.Duration = RecommendedValues.AgeIncreaseCycle.Duration;
                AgeIncreaseCycleSettings.Nutrition = RecommendedValues.AgeIncreaseCycle.Nutrition;
                AgeIncreaseCycleSettings.TimeIncrease = RecommendedValues.AgeIncreaseCycle.Potency;

                // Voice Fix Cycle
                VoiceCycleSettings.Duration = RecommendedValues.VoiceCycle.Duration;
                VoiceCycleSettings.Nutrition = RecommendedValues.VoiceCycle.Nutrition;

                // Tough Cycle
                ToughCycleSettings.Duration = RecommendedValues.ToughCycle.Duration;
                ToughCycleSettings.Nutrition = RecommendedValues.ToughCycle.Nutrition;

                // Immunity Cycle
                ImmunityCycleSettings.Duration = RecommendedValues.ImmunityCycle.Duration;
                ImmunityCycleSettings.Nutrition = RecommendedValues.ImmunityCycle.Nutrition;

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
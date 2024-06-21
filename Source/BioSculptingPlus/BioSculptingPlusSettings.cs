using RimWorld;
using SettingsHelper;
using UnityEngine;
using Verse;

namespace BioSculptingPlus;

public class BioSculptingPlusSettings : ModSettings
{
    public static string CurrentVersion;

    public readonly CycleSettingsAgeIncrease AgeIncreaseCycleSettings =
        new CycleSettingsAgeIncrease("Settings_AgeIncreaseCycle", 60f, true, 2f);

    public readonly CycleSettings BeautyCycleSettings = new CycleSettings("Settings_BeautyCycle", true, 4f);

    public readonly CycleSettings ImmunityCycleSettings = new CycleSettings("Settings_ImmunityCycle", true, 8f);

    public readonly CycleSettings ToughCycleSettings = new CycleSettings("Settings_ToughCycle", true, 8f);

    public readonly CycleSettings VoiceCycleSettings = new CycleSettings("Settings_VoiceCycle", true, 8f);

    private Vector2 scrollPosition;

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
        var outRect = canvas.TopPart(0.9f);
        var rect = new Rect(0f, 0f, outRect.width - 18f, 670f);
        Widgets.BeginScrollView(outRect, ref scrollPosition, rect);
        var list = new Listing_Standard();
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
        var rect2 = canvas.BottomPart(0.075f).LeftPart(0.3f);
        rect2.height = canvas.height * 0.05f;
        if (Widgets.ButtonText(rect2, "Apply_Custom_Values".Translate()))
        {
            ApplySettings();
        }

        if (CurrentVersion != null)
        {
            GUI.contentColor = Color.gray;
            var rect3 = new Rect(rect2);
            rect3.y += canvas.height * 0.05f;
            Widgets.Label(rect3, "CurrentModVersion_Label".Translate(CurrentVersion));
            GUI.contentColor = Color.white;
        }

        rect2.x += canvas.width * 0.7f;
        if (!Widgets.ButtonText(rect2, "Apply_Recommended_Values".Translate()))
        {
            return;
        }

        BeautyCycleSettings.Duration = 4f;
        AgeIncreaseCycleSettings.Duration = 2f;
        AgeIncreaseCycleSettings.TimeIncrease = 60f;
        VoiceCycleSettings.Duration = 8f;
        ToughCycleSettings.Duration = 8f;
        ImmunityCycleSettings.Duration = 8f;
        ApplySettings();
    }

    private R GetBiosculpterCompPropertiesAs<T, R>() where T : CompBiosculpterPod_Cycle
        where R : CompProperties_BiosculpterPod_BaseCycle
    {
        return DefDatabase<ThingDef>.GetNamed("BiosculpterPod").comps
            .Find(x => x.GetType() == typeof(R) && x.compClass == typeof(T)) as R;
    }

    public void ApplySettings()
    {
        var biosculpterCompPropertiesAs =
            GetBiosculpterCompPropertiesAs<CompBiosculpterPod_BeautyCycle, CompProperties_BiosculpterPod_BeautyCycle>();
        if (biosculpterCompPropertiesAs != null)
        {
            biosculpterCompPropertiesAs.durationDays = BeautyCycleSettings.Duration;
        }

        var biosculpterCompPropertiesAs2 =
            GetBiosculpterCompPropertiesAs<CompBiosculpterPod_AgeIncreaseCycle,
                CompProperties_BiosculpterPod_AgeIncreaseCycle>();
        if (biosculpterCompPropertiesAs2 != null)
        {
            biosculpterCompPropertiesAs2.durationDays = AgeIncreaseCycleSettings.Duration;
        }

        var biosculpterCompPropertiesAs3 =
            GetBiosculpterCompPropertiesAs<CompBiosculpterPod_VoiceCycle, CompProperties_BiosculpterPod_VoiceCycle>();
        if (biosculpterCompPropertiesAs3 != null)
        {
            biosculpterCompPropertiesAs3.durationDays = VoiceCycleSettings.Duration;
        }

        var biosculpterCompPropertiesAs4 =
            GetBiosculpterCompPropertiesAs<CompBiosculpterPod_ToughCycle, CompProperties_BiosculpterPod_ToughCycle>();
        if (biosculpterCompPropertiesAs4 != null)
        {
            biosculpterCompPropertiesAs4.durationDays = ToughCycleSettings.Duration;
        }

        var biosculpterCompPropertiesAs5 =
            GetBiosculpterCompPropertiesAs<CompBiosculpterPod_ImmunityCycle,
                CompProperties_BiosculpterPod_ImmunityCycle>();
        if (biosculpterCompPropertiesAs5 != null)
        {
            biosculpterCompPropertiesAs5.durationDays = ImmunityCycleSettings.Duration;
        }
    }
}
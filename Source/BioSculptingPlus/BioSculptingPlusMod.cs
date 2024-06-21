using Mlie;
using UnityEngine;
using Verse;

namespace BioSculptingPlus;

public class BioSculptingPlusMod : Mod
{
    public static BioSculptingPlusSettings BioSculptingPlusSettings;

    public BioSculptingPlusMod(ModContentPack content)
        : base(content)
    {
        BioSculptingPlusSettings = GetSettings<BioSculptingPlusSettings>();
        BioSculptingPlusSettings.CurrentVersion = VersionFromManifest.GetVersionFromModMetaData(content.ModMetaData);
    }

    public override void DoSettingsWindowContents(Rect inRect)
    {
        BioSculptingPlusSettings.DoWindowContents(inRect);
        base.DoSettingsWindowContents(inRect);
    }

    public override string SettingsCategory()
    {
        return "Settings_ModName".Translate();
    }
}
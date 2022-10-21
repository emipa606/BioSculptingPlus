using Verse;
using UnityEngine;

namespace BioSculptingPlus
{
    public class BioSculptingPlusMod : Mod
    {
        public static Settings settings;

        public BioSculptingPlusMod(ModContentPack content) : base(content)
        {
            settings = GetSettings<Settings>();
        }

        public override void DoSettingsWindowContents(Rect inRect)
        {
            settings.DoWindowContents(inRect);
            base.DoSettingsWindowContents(inRect);
        }

        public override string SettingsCategory()
        {
            return "Settings_ModName".Translate();
        }
    }
}

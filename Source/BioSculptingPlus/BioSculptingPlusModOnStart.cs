using Verse;

namespace BioSculptingPlus;

[StaticConstructorOnStartup]
public static class BioSculptingPlusModOnStart
{
    static BioSculptingPlusModOnStart()
    {
        BioSculptingPlusMod.BioSculptingPlusSettings.ApplySettings();
    }
}
using RimWorld;
using Verse;

namespace BioSculptingPlus;

internal class CompBiosculpterPod_AgeIncreaseCycle : CompBiosculpterPod_Cycle
{
    public override void CycleCompleted(Pawn pawn)
    {
        var num = GenDate.TicksPerDay *
                  BioSculptingPlusMod.BioSculptingPlusSettings.AgeIncreaseCycleSettings.TimeIncrease;
        pawn.ageTracker.AgeBiologicalTicks += (int)num;
        Messages.Message("BiosculpterAgeIncreaseCycleComplete".Translate(pawn.Named("PAWN")), pawn,
            MessageTypeDefOf.PositiveEvent);
    }
}
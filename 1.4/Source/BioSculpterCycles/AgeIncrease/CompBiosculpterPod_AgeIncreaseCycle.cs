using RimWorld;
using System;
using Verse;

namespace BioSculptingPlus
{
    class CompBiosculpterPod_AgeIncreaseCycle : CompBiosculpterPod_Cycle
    {
        public override void CycleCompleted(Pawn pawn)
        {
            float increase = 60000f * BioSculptingPlusMod.settings.AgeIncreaseCycleSettings.TimeIncrease;

            pawn.ageTracker.AgeBiologicalTicks = pawn.ageTracker.AgeBiologicalTicks + (int)increase;

            Messages.Message("BiosculpterAgeIncreaseCycleComplete".Translate(pawn.Named("PAWN")), pawn, MessageTypeDefOf.PositiveEvent);
        }
    }
}

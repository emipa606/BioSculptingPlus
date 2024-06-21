using RimWorld;
using Verse;

namespace BioSculptingPlus;

internal class CompBiosculpterPod_ToughCycle : CompBiosculpterPod_Cycle
{
    private readonly TraitDef tough = TraitDef.Named("Tough");

    public override void CycleCompleted(Pawn pawn)
    {
        var failed = false;
        foreach (var allTrait in pawn.story.traits.allTraits)
        {
            if (allTrait.def == tough)
            {
                failed = true;
            }
        }

        if (failed)
        {
            Messages.Message("BiosculpterToughCycleComplete_Fail".Translate(pawn.Named("PAWN")), pawn,
                MessageTypeDefOf.NegativeEvent);
            return;
        }

        pawn.story.traits.GainTrait(new Trait(tough, forced: true));
        Messages.Message("BiosculpterToughCycleComplete_Success".Translate(pawn.Named("PAWN")), pawn,
            MessageTypeDefOf.PositiveEvent);
    }
}
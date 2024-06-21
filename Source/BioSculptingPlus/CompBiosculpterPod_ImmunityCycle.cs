using RimWorld;
using Verse;

namespace BioSculptingPlus;

internal class CompBiosculpterPod_ImmunityCycle : CompBiosculpterPod_Cycle
{
    public override void CycleCompleted(Pawn pawn)
    {
        Trait trait = null;
        var removeTrait = false;
        var failed = false;
        foreach (var allTrait in pawn.story.traits.allTraits)
        {
            if (allTrait.def == TraitDef.Named("Immunity"))
            {
                switch (allTrait.Degree)
                {
                    case -1:
                        trait = allTrait;
                        removeTrait = true;
                        break;
                    case 1:
                        failed = true;
                        break;
                }
            }
        }

        if (removeTrait)
        {
            pawn.story.traits.RemoveTrait(trait);
            Messages.Message("BiosculpterImmunityCycleComplete_Fix".Translate(pawn.Named("PAWN")), pawn,
                MessageTypeDefOf.PositiveEvent);
            return;
        }

        if (failed)
        {
            Messages.Message("BiosculpterImmunityCycleComplete_Fail".Translate(pawn.Named("PAWN")), pawn,
                MessageTypeDefOf.NegativeEvent);
            return;
        }

        pawn.story.traits.GainTrait(new Trait(TraitDef.Named("Immunity"), 1, true));
        Messages.Message("BiosculpterImmunityCycleComplete_Success".Translate(pawn.Named("PAWN")), pawn,
            MessageTypeDefOf.PositiveEvent);
    }
}
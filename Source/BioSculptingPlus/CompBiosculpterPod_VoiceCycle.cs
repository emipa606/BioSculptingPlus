using RimWorld;
using Verse;

namespace BioSculptingPlus;

internal class CompBiosculpterPod_VoiceCycle : CompBiosculpterPod_Cycle
{
    public override void CycleCompleted(Pawn pawn)
    {
        Trait trait = null;
        foreach (var allTrait in pawn.story.traits.allTraits)
        {
            if (allTrait.def == TraitDefOf.AnnoyingVoice)
            {
                trait = allTrait;
                continue;
            }

            if (allTrait.def == TraitDefOf.CreepyBreathing)
            {
                trait = allTrait;
            }
        }

        if (trait != null)
        {
            pawn.story.traits.RemoveTrait(trait);
            Messages.Message("BiosculpterVoiceFixCycleComplete_Fix".Translate(pawn.Named("PAWN")), pawn,
                MessageTypeDefOf.PositiveEvent);
            return;
        }

        Messages.Message("BiosculpterVoiceFixCycleComplete_Fail".Translate(pawn.Named("PAWN")), pawn,
            MessageTypeDefOf.NegativeEvent);
    }
}
using RimWorld;
using Verse;

namespace BioSculptingPlus
{
    class CompBiosculpterPod_VoiceCycle : CompBiosculpterPod_Cycle
    {
        public override void CycleCompleted(Pawn pawn)
        {
            Trait toRemove = null;
            foreach (Trait trait in pawn.story.traits.allTraits)
            {
                if (trait.def == TraitDefOf.AnnoyingVoice)
                {
                    toRemove = trait;
                }
                if (trait.def == TraitDefOf.CreepyBreathing)
                {
                    toRemove = trait;
                }
            }

            if (toRemove != null)
            {
                pawn.story.traits.RemoveTrait(toRemove);
                Messages.Message("BiosculpterVoiceFixCycleComplete_Fix".Translate(pawn.Named("PAWN")), pawn, MessageTypeDefOf.PositiveEvent);
            }
            else
            {
                 Messages.Message("BiosculpterVoiceFixCycleComplete_Fail".Translate(pawn.Named("PAWN")), pawn, MessageTypeDefOf.NegativeEvent);
            }

            return;
        }
    }
}

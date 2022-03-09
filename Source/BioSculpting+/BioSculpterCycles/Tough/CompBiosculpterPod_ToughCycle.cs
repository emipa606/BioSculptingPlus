using RimWorld;
using Verse;

namespace BioSculptingPlus
{
    class CompBiosculpterPod_ToughCycle : CompBiosculpterPod_Cycle
    {
        public override void CycleCompleted(Pawn pawn)
        {
            bool isTough = false;

            foreach (Trait trait in pawn.story.traits.allTraits)
            {
                if (trait.def == TraitDefOf.Tough)
                {
                    isTough = true;
                }
            }

            if (isTough)
            {
                Messages.Message("BiosculpterToughCycleComplete_Fail".Translate(pawn.Named("PAWN")), pawn, MessageTypeDefOf.NegativeEvent);
            }
            else
            {
                pawn.story.traits.GainTrait(new Trait(TraitDefOf.Tough, 0, forced: true));
                Messages.Message("BiosculpterToughCycleComplete_Success".Translate(pawn.Named("PAWN")), pawn, MessageTypeDefOf.PositiveEvent);
            }

            return;
        }
    }
}

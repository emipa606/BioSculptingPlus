using RimWorld;
using Verse;

namespace BioSculptingPlus
{
    class CompBiosculpterPod_ImmunityCycle : CompBiosculpterPod_Cycle
    {
        public override void CycleCompleted(Pawn pawn)
        {
            Trait toRemove = null;
            bool isSickly = false;
            bool isImmune = false;

            foreach (Trait trait in pawn.story.traits.allTraits)
            {
                switch (trait.Label)
                {
                    case "sickly":
                        toRemove = trait;
                        isSickly = true;
                        break;
                    case "super immune":
                        isImmune = true;
                        break;
                }
            }

            if (isSickly)
            {
                pawn.story.traits.RemoveTrait(toRemove);
                Messages.Message("BiosculpterImmunityCycleComplete_Fix".Translate(pawn.Named("PAWN")), pawn, MessageTypeDefOf.PositiveEvent);
            } else if (isImmune)
            {
                Messages.Message("BiosculpterImmunityCycleComplete_Fail".Translate(pawn.Named("PAWN")), pawn, MessageTypeDefOf.NegativeEvent);
            } else
            {
                pawn.story.traits.GainTrait(new Trait(TraitDef.Named("Immunity"), 1, forced: true));
                Messages.Message("BiosculpterImmunityCycleComplete_Success".Translate(pawn.Named("PAWN")), pawn, MessageTypeDefOf.PositiveEvent);
            }
            
            return;
        }
    }
}

using RimWorld;
using Verse;

namespace BioSculptingPlus
{
    class CompBiosculpterPod_BeautyCycle : CompBiosculpterPod_Cycle
    {
        public override void CycleCompleted(Pawn pawn)
        {
            Trait toRemove = null;
            int currentBeauty = 0;
            foreach (Trait trait in pawn.story.traits.allTraits)
            {
                switch (trait.Label)
                {
                    case "staggeringly ugly":
                        toRemove = trait;
                        currentBeauty -= 2;
                        break;
                    case "ugly":
                        toRemove = trait;
                        currentBeauty -= 1;
                        break;
                    case "pretty":
                        toRemove = trait;
                        currentBeauty += 1;
                        break;
                    case "beautiful":
                        currentBeauty += 2;
                        break;
                }
            }

            switch (currentBeauty)
            {
                case -2:
                    pawn.story.traits.RemoveTrait(toRemove);
                    pawn.story.traits.GainTrait(new Trait(TraitDef.Named("Beauty"), -1, forced: true));
                    Messages.Message("BiosculpterBeautyCycleComplete_Ugly".Translate(pawn.Named("PAWN")), pawn, MessageTypeDefOf.PositiveEvent);
                    break;
                case -1:
                    pawn.story.traits.RemoveTrait(toRemove);
                    Messages.Message("BiosculpterBeautyCycleComplete_Normal".Translate(pawn.Named("PAWN")), pawn, MessageTypeDefOf.PositiveEvent);
                    break;
                case 0:
                    pawn.story.traits.GainTrait(new Trait(TraitDef.Named("Beauty"), 1, forced: true));
                    Messages.Message("BiosculpterBeautyCycleComplet_Pretty".Translate(pawn.Named("PAWN")), pawn, MessageTypeDefOf.PositiveEvent);
                    break;
                case 1:
                    pawn.story.traits.RemoveTrait(toRemove);
                    pawn.story.traits.GainTrait(new Trait(TraitDef.Named("Beauty"), 2, forced: true));
                    Messages.Message("BiosculpterBeautyCycleComplete_Beautiful".Translate(pawn.Named("PAWN")), pawn, MessageTypeDefOf.PositiveEvent);
                    break;
                default:
                    Messages.Message("BiosculpterBeautyCycleFailed".Translate(pawn.Named("PAWN")), pawn, MessageTypeDefOf.NegativeEvent);
                    break;
            }
            return;
        }
    }
}

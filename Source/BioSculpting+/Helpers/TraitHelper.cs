using RimWorld;
using Verse;

namespace BioSculptingPlus.TraitHelper
{
    public static class TraitHelper
    {
        public static void tryRemoveTrait(this Pawn p, Trait t)
        {
            try
            {
                p.story.traits.RemoveTrait(t);
            } catch
            {
                Messages.Message("TraitHelper: An error occured during tryRemoveTrait.", MessageTypeDefOf.NegativeEvent);
            }
        }

        public static void tryAddTrait(this Pawn p, string name, int val, bool forced = false)
        {
            try
            {
                p.story.traits.GainTrait(new Trait(TraitDef.Named(name), val, forced));
            }
            catch
            {
                Messages.Message("TraitHelper: An error occured during tryAddTrait.", MessageTypeDefOf.NegativeEvent);
            }
        }
    }
}

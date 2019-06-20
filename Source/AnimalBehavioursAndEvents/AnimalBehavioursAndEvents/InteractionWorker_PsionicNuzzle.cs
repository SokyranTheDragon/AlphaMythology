﻿using System;
using System.Collections.Generic;
using Verse;
using RimWorld;

namespace AlphaBehavioursAndEvents
{
    public class InteractionWorker_PsionicNuzzle : InteractionWorker
    {
        public override void Interacted(Pawn initiator, Pawn recipient, List<RulePackDef> extraSentencePacks, out string letterText, out string letterLabel, out LetterDef letterDef)
        {
            this.AddNuzzledThought(initiator, recipient);
            this.TryGiveName(initiator, recipient);
            letterText = null;
            letterLabel = null;
            letterDef = null;
        }

        private void AddNuzzledThought(Pawn initiator, Pawn recipient)
        {
            Thought_Memory newThought = (Thought_Memory)ThoughtMaker.MakeThought(ThoughtDef.Named("AA_BeenPsionicallyNuzzled"));
            recipient.needs.mood.thoughts.memories.TryGainMemory(newThought, null);
        }

        private void TryGiveName(Pawn initiator, Pawn recipient)
        {
            if ((initiator.Name == null || initiator.Name.Numerical) && Rand.Value < initiator.RaceProps.nameOnNuzzleChance)
            {
                PawnUtility.GiveNameBecauseOfNuzzle(recipient, initiator);
            }
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BridgePattern.Mutators;

namespace BridgePattern.Monsters
{
    public abstract class BaseMonster
    {
        protected readonly Mutator[] _mutators;
        public string Name { get; }
        public int HitPoints { get; }

        public int Level { get; }

        protected BaseMonster( string name, int hitPoints, int level, Mutator[] mutators)
        {
            Name = name;
            HitPoints = hitPoints;
            Level = level;

            _mutators = mutators;
        }

        public abstract string GetDescription();
    }

    public class RegularMonster : BaseMonster
    {

        public RegularMonster(string name, int hitPoints, int level, Mutator[] mutators) : base(name, hitPoints, level, mutators)
        {
        }

        public override string GetDescription()
        {
            string description;
            if (_mutators.Length > 1)
            {
                description = _mutators.SkipLast(1).Aggregate(String.Empty, (x, mut) => x + mut.GetDescription());
            } else
            {
                description = _mutators.Aggregate(String.Empty, (x, mut) => x + mut.GetDescription());
            }
            return "A plain old " + Name + " that " + description;
        }
    }

    public class UniqueMonster : BaseMonster
    {
        public UniqueMonster(string name, int hitPoints, int level, Mutator[] mutators) : base(name, hitPoints, level, mutators)
        {
        }

        public override string GetDescription()
        {
            string description;
            if (_mutators.Length > 1)
            {
                description = _mutators.SkipLast(1).Aggregate(String.Empty, (x, mut) => x + mut.GetDescription());
                description += " and " + _mutators.Last().GetDescription();
            }
            else
            {
                description = _mutators.Aggregate(String.Empty, (x, mut) => x + mut.GetDescription());
            }

            return "A super strong " + Name + " that " + description;
        }
    }
}

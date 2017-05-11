using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Skills
{
    class ActionPoints
    {
        private float MaxActionPoints;
        private float CurrentActionPoints;

        private float RegenAmount;


        public ActionPoints(float maxActionPoints)
        {
            MaxActionPoints = maxActionPoints;
            CurrentActionPoints = MaxActionPoints;
            RegenAmount = 1;
        }

        public bool IsFive(int value)
        {
            return value % 5 == 0;
        }

        private void RegenActionPoints()
        {
            CurrentActionPoints = CurrentActionPoints + RegenAmount;
            if (CurrentActionPoints >= MaxActionPoints)
            {
                CurrentActionPoints = MaxActionPoints;
            }
        }

        public void UsePoints(int cost)
        {
            if (CurrentActionPoints >= cost)
            {
                CurrentActionPoints = CurrentActionPoints - cost;
            }
        }

        public void IncreaseAP(int level)
        {
            if (IsFive(level))
            {
                MaxActionPoints = MaxActionPoints + 1;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Skills
{
    public class ActionPoints : MonoBehaviour
    {
        private float MaxActionPoints;
        private float CurrentActionPoints;

        private float RegenAmount;


        public ActionPoints()
        {
            MaxActionPoints = 3;
            CurrentActionPoints = MaxActionPoints;
            RegenAmount = 1;
        }

        public bool IsFive(int value)
        {
            return value % 5 == 0;
        }

        public void RegenActionPoints()
        {
            CurrentActionPoints = CurrentActionPoints + RegenAmount;
            if (CurrentActionPoints >= MaxActionPoints)
            {
                CurrentActionPoints = MaxActionPoints;
            }
        }

        public bool UsePoints(int cost)
        {
            if (CurrentActionPoints >= cost)
            {
                CurrentActionPoints = CurrentActionPoints - cost;
                return true;
            }
            return false;
        }

        public void IncreaseAP(int level)
        {
            if (IsFive(level))
            {
                MaxActionPoints = MaxActionPoints + 1;
            }
        }

        public override string ToString()
        {
            return "AP: " + CurrentActionPoints + "/" + MaxActionPoints;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Skills
{
    public class AllSkills
    {
        //properties
        private List<Skill> AllMeleeSkills = new List<Skill>();

        //constructor
        public AllSkills()
        {
            Skill Drain_Skill = new Skill(1, "Drain", 10, 1, 0, 0.2f, "Drain HP from enemies");
            Skill Huge_Swing = new Skill(2, "Huge swing", 10, 2, 0, 0.4f, "A bigger swing");
            AllMeleeSkills.Add(Drain_Skill);
            AllMeleeSkills.Add(Huge_Swing);
        }

        //methods
        public Skill SearchSkill(int id)
        {
            foreach (Skill s in AllMeleeSkills)
            {
                if (s.ID == id)
                {
                    return s;
                }
            }
            return null;
        }
    }
}

using Microsoft.CodeAnalysis;

namespace WebApplication2.Model
{
    public class Hero
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Sexs sex { get; set; }//男女

        public Times timeType { get; set; }//朝代

        public Groups country { get; set; }

        public Costs cost { get; set; }

        public Stars star { get; set; }

        public Arms arm { get; set; }

        public int Attackdistance { get; set; }

        public float InitialStrategy { get; set; }

        public float Initialattack { get; set; }

        public float Initialsiege { get; set; }

        public float InitialDefense { get; set; }

        public float Initialspeed { get; set; }

        public Skill Basictactics { get; set; }

        public Skill Detachabletactics { get; set; }
    }   
}

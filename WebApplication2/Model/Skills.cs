using Microsoft.CodeAnalysis;

namespace WebApplication2.Model
{
   
   

    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public SkillTypes type { get; set; }
        public SkillQualitys quality { get; set; }
        public SkillTargets target { get; set; }
    }

}

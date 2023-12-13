using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Model;

namespace WebApplication2.Data
{
    public class WebApplication2Context : DbContext
    {
        public WebApplication2Context (DbContextOptions<WebApplication2Context> options)
            : base(options)
        {
        }
        public DbSet<WebApplication2.Model.Arms>? Arms { get; set; }
        public DbSet<WebApplication2.Model.Costs>? Costs { get; set; }
        public DbSet<WebApplication2.Model.Groups>? Groups { get; set; }
        public DbSet<WebApplication2.Model.Stars>? Stars { get; set; }
        public DbSet<WebApplication2.Model.Times>? Times { get; set; }
        public DbSet<WebApplication2.Model.SkillQualitys>? SkillQualitys { get; set; }
        public DbSet<WebApplication2.Model.SkillTargets>? SkillTargets { get; set; }
        public DbSet<WebApplication2.Model.SkillTypes>? SkillTypes { get; set; }
        public DbSet<WebApplication2.Model.Skills>? Skills { get; set; }
        public DbSet<WebApplication2.Model.Heros>? Heros { get; set; }


    }
}

﻿using System;
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
        public DbSet<WebApplication2.Model.HeroModel>? HeroModel { get; set; }
        public DbSet<WebApplication2.Model.SkillModel>? SkillModel { get; set; }
        public DbSet<WebApplication2.Model.ProductModel>? ProductModel { get; set; }
        



    }
}

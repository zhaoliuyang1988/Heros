using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Model;

namespace WebApplication2.Pages.Product
{
    public class DetailsModel : PageModel
    {
        private readonly WebApplication2.Data.WebApplication2Context _context;

        public DetailsModel(WebApplication2.Data.WebApplication2Context context)
        {
            _context = context;
        }

        public ProductModel ProductModel { get; set; } = default!;

        public IList<HeroModel> HeroModels { get; set; } = default!;

        public IList<HeroModel> HeroModels_Orange { get; set; } = default!;

        public IList<HeroModel> HeroModels_Others { get; set; } = default!;

        public IList<SkillModel> SkillModels { get; set; } = default!;

        public IList<SkillModel> SkillModels_Orange { get; set; } = default!;

        public IList<SkillModel> SkillModels_Others { get; set; } = default!;

        public IList<HeroModel> HeroResults { get; set; } = default!;

        public IList<SkillModel> SkillResults { get; set; } = default!;

        public IList<SignResult> SignResults { get; set; } = default!;

        public StringBuilder Comments { get; set; }

        public int Numbers { get; set; }

        private int rate = 10;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ProductModel == null)
            {
                return NotFound();
            }

            var productmodel = await _context.ProductModel.FirstOrDefaultAsync(m => m.Id == id);
            if (productmodel == null)
            {
                return NotFound();
            }
            else
            {
                ProductModel = productmodel;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.ProductModel == null)
            {
                return Page();
            }

            var productmodel = await _context.ProductModel.FindAsync(id);
            if (productmodel == null)
            {
                return NotFound();
            }
            else
            {
                ProductModel = productmodel;
            }

            int val = 0;
            int.TryParse(ProductModel.Name.Replace("Hero_", "").Replace("Skill_", ""), out val);
            Numbers = val;

            if (_context.HeroModel != null)
            {
                HeroModels = await _context.HeroModel.ToListAsync();
                HeroModels_Orange = await _context.HeroModel.Where(c => c.starId == starEnum.橙).ToListAsync();
                HeroModels_Others = await _context.HeroModel.Where(c => c.starId != starEnum.橙).ToListAsync();

            }
            if (_context.SkillModel != null)
            {
                SkillModels = await _context.SkillModel.ToListAsync();
                SkillModels_Orange = await _context.SkillModel.Where(c => c.quality == qualityEnum.S).ToListAsync();
                SkillModels_Others = await _context.SkillModel.Where(c => c.quality != qualityEnum.S).ToListAsync();
            }

            int merchantval = Numbers / 10;
            int remainderval = Numbers % 10;

            double count = GenerateProduct.Get(rate);

            if (ProductModel.Name.Contains("Hero"))
            {
                HeroResults = new List<HeroModel>();
                for (int j = 0; j < merchantval; j++)
                {
                    HeroModel heroModel = new HeroModel();
                    for (int i = 0; i < rate; i++)
                    {
                        if (count == 0)
                        {
                            heroModel = RandomPick<HeroModel>.Get(HeroModels_Orange);
                            count = GenerateProduct.Get(rate);
                        }
                        else
                        {
                            heroModel = RandomPick<HeroModel>.Get(HeroModels_Others);
                            count = count - 1;
                        }
                        HeroResults.Add(heroModel!);
                    }
                }
                for (int j = 0; j < remainderval; j++)
                {
                    HeroModel heroModel = RandomPick<HeroModel>.Get(HeroModels);
                    HeroResults.Add(heroModel);
                }

                SignResults = HeroResults.GroupBy(x => x.Id).Select(g =>
                    new SignResult()
                    {
                        Id = g.Key,
                        Name = HeroModels.Where(x => x.Id == g.Key).FirstOrDefault()!.Name,
                        starEnumId = HeroModels.Where(x => x.Id == g.Key).FirstOrDefault()!.starId,
                        qualityId = null,
                        armId = HeroModels.Where(x => x.Id == g.Key).FirstOrDefault()!.armId,
                        picPath = HeroModels.Where(x => x.Id == g.Key).FirstOrDefault()!.picPath,
                        Total = g.Count()
                    }
                    ).OrderBy(x => x.starEnumId!.ToEnumInt())
                    .ThenByDescending(x => x.Total).ToList();

                Comments = new StringBuilder();
                Comments.Append(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + " 总共抽了" + Numbers + "次，共抽到了");
                foreach (var item in SignResults.GroupBy(x => x.starEnumId))
                {
                    Comments.Append(item.Sum(x => x.Total) + "张" + item.Key.ToString() + "色英雄卡片,");
                }
                Comments.Remove(Comments.Length - 1, 1);
                Comments.Append(".");

            }
            else
            {
                SkillResults = new List<SkillModel>();
                for (int j = 0; j < merchantval; j++)
                {
                    SkillModel skillModel = new SkillModel();
                    for (int i = 0; i < rate; i++)
                    {
                        if (count == 0)
                        {
                            skillModel = RandomPick<SkillModel>.Get(SkillModels_Orange);
                            count = GenerateProduct.Get(rate);
                        }
                        else
                        {
                            skillModel = RandomPick<SkillModel>.Get(SkillModels_Others);

                            int check = skillModel.quality.ToEnumInt();
                            count = count - 1;
                        }
                        SkillResults.Add(skillModel!);
                    }
                }
                for (int j = 0; j < remainderval; j++)
                {
                    SkillModel skillModel = RandomPick<SkillModel>.Get(SkillModels);
                    SkillResults.Add(skillModel);
                }

                SignResults = SkillResults.GroupBy(x => x.Id).Select(g =>
                    new SignResult()
                    {
                        Id = g.Key,
                        Name = SkillModels.Where(x => x.Id == g.Key).FirstOrDefault()!.Name,
                        starEnumId = null,
                        qualityId = SkillModels.Where(x => x.Id == g.Key).FirstOrDefault()!.quality,
                        armId = SkillModels.Where(x => x.Id == g.Key).FirstOrDefault()!.armId,
                        picPath = SkillModels.Where(x => x.Id == g.Key).FirstOrDefault()!.picPath,
                        Total = g.Count()
                    }
                    ).OrderBy(x => x.qualityId!.ToEnumInt())
                    .ThenByDescending(x => x.Total)
                    .ToList();

                Comments = new StringBuilder();
                Comments.Append(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + " 总共抽了" + Numbers + "次，共抽到了");
                foreach (var item in SignResults.GroupBy(x => x.qualityId))
                {
                    Comments.Append(item.Sum(x => x.Total) + "张" + item.Key.ToString() + "战法卡片,");
                }
                Comments.Remove(Comments.Length - 1, 1);
                Comments.Append(".");
            }

            return Page();
        }
    }
}

/// <summary>
/// 保底算法
/// </summary>
public class GenerateProduct
{
    public static double Get(int rate)
    {
        while (true)
        {
            Random rnd = new Random();
            double n = rnd.NextDouble();

            double p = Math.Floor(Math.Log(1 - n) * (-1 * rate));
            if (p < rate)
            {
                return p;
            }
            return rate - 1;
        }
    }
}


public class RandomPick<T>
{
    public static T Get(IList<T> list)
    {
        T result = default(T);
        if (list is not null && list.Count() > 0)
        {
            Random rnd = new Random();
            int index = rnd.Next(list.Count());
            result = list[index];
        }
        return result;
    }
}

public static class EnumExtensions
{
    public static int ToEnumInt(this Enum e)
    {
        try
        {
            return e.GetHashCode();
        }
        catch (Exception)
        {
            return 0;
        }
    }
}

public class SignResult{
    [Description("编号")]
    public int Id { get; set; }

    [Description("名字")]
    public string Name { get; set; }

    [Description("星级")]
    public starEnum? starEnumId { get; set; }

    [Description("品质")]
    public qualityEnum? qualityId { get; set; }

    [Description("兵种类型")]
    public armEnum armId { get; set; }

    [Description("图片路径")]
    public string picPath { get; set; }

    [Description("总数")]
    public int Total { get; set; }
}

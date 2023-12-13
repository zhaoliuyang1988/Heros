using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebApplication2.Data;
using WebApplication2.Model;

namespace WebApplication2.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly WebApplication2.Data.WebApplication2Context _context;

        public IndexModel(WebApplication2.Data.WebApplication2Context context)
        {
            _context = context;
            multiple = "10";
        }


        public int rate = 10;

        [BindProperty]
        public string multiple { get; set; }

        public List<List<string>> Result { get; set; }

        public List<SignResult> Note
        {
            get;
            set;
        }

        public string Sum
        {
            get;
            set;
        }


        public string[] ResultType = new[] { "橙",  "紫" , "蓝", "白" };


        //public IList<Product> Product { get; set; } = default!;

        public async Task OnGetAsync()
        {
            //if (_context.Product != null)
            //{
            //    Product = await _context.Product.ToListAsync();
            //}
            Result = new List<List<string>>();
            Note = new List<SignResult>();
            int val1 = 0;
            int val2 = 0;
            int val3 = 0;
            int val4 = 0;
            double count = GenerateNumber.Get(rate);

            int multval = 10;
            if (multiple is not null)
            {
                int.TryParse(multiple, out multval);
            }

            for (int j = 0; j < multval; j++)
            {
                List<string> list = new List<string>();


                for (int i = 0; i < rate; i++)
                {
                    if (count == 0)
                    {
                        //橙卡
                        list.Add(ResultType[0]);
                        count = GenerateNumber.Get(rate);
                    }
                    else
                    {
                        count = count - 1;

                        //随机白蓝粉
                        Random rnd = new Random();
                        int r = rnd.Next(1, 4);

                        list.Add(ResultType[r]);
                    }
                }

                Result.Add(list);

                string val = DateTime.Now.ToShortDateString() + DateTime.Now.ToShortTimeString() + " 总共抽了" + rate + "次，共抽到了"
                    + Result[j].Count(r => r == "橙") + "张橙卡，"
                    + Result[j].Count(r => r == "紫") + "张紫卡，"
                    + Result[j].Count(r => r == "蓝") + "张蓝卡，"
                    + Result[j].Count(r => r == "白") + "张白卡。";
                val += " 每次抽的结果如下:";

                string singalval = "";

                foreach (var str in Result[j])
                {
                    singalval += str + ",";
                }
                singalval.Remove(singalval.Length - 1);

                val += singalval;

                Note.Add(new SignResult() { RowIndex = j + 1, Name = "10连抽", Result = val });

                val1 += Result[j].Count(r => r == "橙");
                val2 += Result[j].Count(r => r == "紫");
                val3 += Result[j].Count(r => r == "蓝");
                val4 += Result[j].Count(r => r == "白");

            }

            var sumval = DateTime.Now.ToShortDateString() + DateTime.Now.ToShortTimeString() + " 总共抽了" + rate * multval + "次，共抽到了"
                    + val1 + "张橙卡，"
                    + val2 + "张紫卡，"
                    + val3 + "张蓝卡，"
                    + val4 + "张白卡。";

            Note.Add(new SignResult() { Name = "Sum", Result = sumval });


        }

        public async Task<IActionResult> OnPostAsync()
        {
            Result = new List<List<string>>();
            Note = new List<SignResult>();
            int val1 = 0;
            int val2 = 0;
            int val3 = 0;
            int val4 = 0;
            double count = GenerateNumber.Get(rate);

            int multval = 10;
            if (multiple is not null)
            {
                int.TryParse(multiple, out multval);
            }

            for (int j = 0; j < multval; j++)
            {
                List<string> list = new List<string>();


                for (int i = 0; i < rate; i++)
                {
                    if (count == 0)
                    {
                        //橙卡
                        list.Add(ResultType[0]);
                        count = GenerateNumber.Get(rate);
                    }
                    else
                    {
                        count = count - 1;

                        //随机白蓝粉
                        Random rnd = new Random();
                        int r = rnd.Next(1, 4);

                        list.Add(ResultType[r]);
                    }
                }

                Result.Add(list);

                string val = DateTime.Now.ToShortDateString() + DateTime.Now.ToShortTimeString() + " 总共抽了" + rate + "次，共抽到了"
                    + Result[j].Count(r => r == "橙") + "张橙卡，"
                    + Result[j].Count(r => r == "紫") + "张紫卡，"
                    + Result[j].Count(r => r == "蓝") + "张蓝卡，"
                    + Result[j].Count(r => r == "白") + "张白卡。";
                val += " 每次抽的结果如下:";

                string singalval = "";

                foreach (var str in Result[j])
                {
                    singalval += str + ",";
                }
                singalval.Remove(singalval.Length - 1);

                val += singalval;

                Note.Add(new SignResult() { RowIndex = j + 1, Name = "10连抽", Result = val });

                val1 += Result[j].Count(r => r == "橙");
                val2 += Result[j].Count(r => r == "紫");
                val3 += Result[j].Count(r => r == "蓝");
                val4 += Result[j].Count(r => r == "白");

            }

            var sumval = DateTime.Now.ToShortDateString() + DateTime.Now.ToShortTimeString() + " 总共抽了" + rate * multval + "次，共抽到了"
                    + val1 + "张橙卡，"
                    + val2 + "张紫卡，"
                    + val3 + "张蓝卡，"
                    + val4 + "张白卡。";

            Note.Add(new SignResult() { Name = "Sum", Result = sumval });


            return Page();
        }
    }
}

public class GenerateNumber
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

public class SignResult { 

    public int? RowIndex { get; set; }

    public string Name { get; set; }

    public string Result { get; set; }



}


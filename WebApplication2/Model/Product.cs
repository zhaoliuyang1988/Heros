namespace WebApplication2.Model
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Male { get; set; }//男女

        public string ProductType { get; set; }//朝代

        public int wuli { get; set; }//武力

        public int zhili { get; set; }//智力

        public int Description { get; set; }//故事

        public string Pic { get; set; }//图片

        public List<string> skills { get; set; }//技能

        public List<string> zhuangbeis { get; set; }//装备

        public int level { get; set; }//1-5 5橙4紫3蓝2绿1白
    }
}

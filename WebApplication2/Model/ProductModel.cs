using System.ComponentModel;

namespace WebApplication2.Model
{
    public class ProductModel
    {
        [Description("编号")]
        public int Id { get; set; }

        [Description("名字")]
        public string Name { get; set; }

        [Description("描述")]
        public string Description { get; set; }

        [Description("图片路径")]
        public string picPath { get; set; }

        [Description("价格")]
        public int Price { get; set; }
    }
}

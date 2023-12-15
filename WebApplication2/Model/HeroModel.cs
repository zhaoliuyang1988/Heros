using Microsoft.CodeAnalysis;
using System.ComponentModel;

namespace WebApplication2.Model
{
    public class HeroModel
    {
        [Description("编号")]
        public int Id { get; set; }

        [Description("名字")]
        public string Name { get; set; }

        [Description("历史描述")]
        public string Description { get; set; }

        [Description("性别")]
        public sexEnum sexId { get; set; }//男女

        [Description("时代")]
        public timeEnum timeTypeId { get; set; }//时代

        [Description("朝代")]
        public groupEnum groupId { get; set; }//朝代

        [Description("星级")]
        public starEnum starId { get; set; }

        [Description("兵种")]
        public armEnum armId { get; set; }

        [Description("代价")]
        public float costId { get; set; }

        [Description("攻击距离")]
        public int Attackdistance { get; set; }

        [Description("初始谋略")]
        public float InitialStrategy { get; set; }

        [Description("初始攻击")]
        public float Initialattack { get; set; }

        [Description("初始攻城")]
        public float Initialsiege { get; set; }

        [Description("初始防御")]
        public float InitialDefense { get; set; }

        [Description("初始速度")]
        public float Initialspeed { get; set; }

        [Description("基础战法")]
        public int BasictacticsId { get; set; }

        [Description("可拆战法")]
        public int DetachabletacticsId { get; set; }

        [Description("图片路径")]
        public string picPath { get; set; }
    }


    public enum sexEnum
    {
        男 = 1,
        女 = 2
    }
    public enum groupEnum
    {
        汉 = 1,
        魏 = 2,
        蜀 = 3,
        吴 = 4,
        群 = 5,
        晋 = 6

    }


    public enum timeEnum
    {
        三国 = 1,
        唐 = 2,
        宋 = 3,
        元 = 4,
        明 = 5,
        清 = 6

    }

    public enum starEnum
    {

        白 = 1,
        绿 = 2,
        蓝 = 3,
        粉 = 4,
        橙 = 5

    }


    public enum armEnum
    {

        弓 = 1,
        步 = 2,
        骑 = 3,
        弓骑=4,
        步骑=5,
        弓步=6,
        全=7
    }


}

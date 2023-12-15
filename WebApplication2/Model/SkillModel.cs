using Microsoft.CodeAnalysis;
using System.ComponentModel;

namespace WebApplication2.Model
{
    /// <summary>
    /// 战法
    /// </summary>
    public class SkillModel
    {
        [Description("编号")]
        public int Id { get; set; }
        [Description("名字")]
        public string Name { get; set; }
        [Description("战法详情")]
        public string Description { get; set; }

        [Description("兵种类型")]
        public armEnum armId { get; set; }

        [Description("类型")]
        public typeEnum type { get; set; }

        [Description("品质")]
        public qualityEnum quality { get; set; }

        [Description("目标")]
        public targetEnum target { get; set; }
    }


    public enum typeEnum
    {
        指挥战法 = 1,
        主动战法 = 2,
        被动战法 = 3,
        追击战法 = 4
    }

    public enum qualityEnum
    {
        S = 1,
        A = 2,
        B = 3,
        C = 4,
        D = 5
    }

    public enum targetEnum
    {
        我方单体 = 1,
        我方团体 = 2,
        敌军单体 = 3,
        敌军团体 = 4,
        共计目标 = 5,
        自己 = 6
    }

}

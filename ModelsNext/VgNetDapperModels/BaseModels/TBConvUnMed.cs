using Dapper.Contrib.Extensions;

namespace VgNetDapperModels.BaseModels
{
    [Table("TBConvUnMed")]
    public class TBConvUnMed
    {
        public string UnMed1 { get; set; }

        public string UnMed2 { get; set; }

        public double? Conv1 { get; set; }

        public double? Conv2 { get; set; }

    }
}
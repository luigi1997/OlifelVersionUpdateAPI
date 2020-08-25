using Dapper.Contrib.Extensions;

namespace VgNetDapperModels.BaseModels
{
    [Table("RegEx")]
    public class RegEx
    {
        [ExplicitKey]
        public string Name { get; set; }
        public string Pattern { get; set; }
    }
}
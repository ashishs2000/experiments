namespace SqlDb.Baseline.Models
{
    public class DbTableRelationship
    {
        public string PrimaryKey { get; set; }
        public string PrimaryTable { get; set; }
        public string ForeignKey { get; set; }
        public string ForeignTable { get; set; }

        public override string ToString()
        {
            return $"{PrimaryTable} -> {ForeignTable}";
        }
    }
}
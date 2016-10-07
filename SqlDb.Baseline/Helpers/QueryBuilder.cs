using System.Collections.Generic;
using System.Text;
using SqlDb.Baseline.Models;
using SqlDb.Baseline.QueryCommand;

namespace SqlDb.Baseline.Helpers
{
    public class QueryBuilder
    {
        private readonly DbTable _table;
        private readonly IQueryCommand _command;
        private readonly Dictionary<int, List<InnerJoin>> _innerJoinsMap = new Dictionary<int, List<InnerJoin>>();

        private int key = 1;
        public bool HasMappedEmployer { get; private set; }
        public QueryBuilder(DbTable table, IQueryCommand command)
        {
            _table = table;
            _command = command;
        }

        public void Add(string employerTableAlias, InnerJoin[] innerJoins)
        {
            HasMappedEmployer = true;

            if (!_innerJoinsMap.ContainsKey(key))
                _innerJoinsMap.Add(key, new List<InnerJoin>());

            var employerJoin = JoinWithEmployer(employerTableAlias);

            _innerJoinsMap[key].AddRange(innerJoins);
            _innerJoinsMap[key].Add(employerJoin);
            key = key + 1;
        }

        private InnerJoin JoinWithEmployer(string leftAlias)
        {
            var employerJoin = new InnerJoin();
            employerJoin.LeftCondition("EmployerId", leftAlias);
            employerJoin.RightCondition("@EmployerIds", "EmployerId", "eids");

            return employerJoin;
        }

        public override string ToString()
        {
            var query = new StringBuilder();
            query.Append(_command.CreateQuery(_table, "test", "a1"));

            var firstTime = false;
            foreach (var innerJoinMap in _innerJoinsMap)
            {
                if (firstTime)
                {
                    query.AppendLine("UNION ALL");
                    query.AppendLine(_command.CreateQuery(_table, "test", "a1", true));
                }

                foreach (var innerJoin in innerJoinMap.Value)
                {
                    query.AppendLine(innerJoin.ToString());
                    firstTime = true;
                }
            }

            return query.ToString();
        }
    }
}
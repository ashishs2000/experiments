using System.Collections.Generic;
using System.Text;
using SqlDb.Baseline.ConfigSections;
using SqlDb.Baseline.Models;
using SqlDb.Baseline.QueryCommand;

namespace SqlDb.Baseline.Helpers
{
    public class QueryBuilder
    {
        private readonly IDatabaseConfig _config;
        private readonly DbTable _table;
        private readonly IQueryCommand _command;
        private readonly Dictionary<int, List<InnerJoin>> _innerJoinsMap = new Dictionary<int, List<InnerJoin>>();

        private int _key = 1;
        public bool HasMappedEmployer { get; private set; }
        public QueryBuilder(IDatabaseConfig config,DbTable table, IQueryCommand command)
        {
            _config = config;
            _table = table;
            _command = command;
        }

        public void Add(string employerTableAlias, InnerJoin[] innerJoins)
        {
            HasMappedEmployer = true;

            if (!_innerJoinsMap.ContainsKey(_key))
                _innerJoinsMap.Add(_key, new List<InnerJoin>());

            var employerJoin = JoinWithEmployer(employerTableAlias);

            _innerJoinsMap[_key].AddRange(innerJoins);
            _innerJoinsMap[_key].Add(employerJoin);
            _key = _key + 1;
        }

        private InnerJoin JoinWithEmployer(string leftAlias)
        {
            var employerJoin = new InnerJoin(_config);
            employerJoin.LeftCondition("EmployerId", leftAlias);
            employerJoin.RightCondition("@EmployerIds", "EmployerId", "eids");

            return employerJoin;
        }

        public override string ToString()
        {
            var query = new StringBuilder();
            query.Append(_command.CreateInitialStatement(_config,_table, "a1"));

            var unionOn = false;
            foreach (var innerJoinMap in _innerJoinsMap)
            {
                if (unionOn)
                {
                    query.AppendLine("UNION ALL");
                    query.AppendLine($"SELECT {_table.Csv("a1")}");
                    query.AppendLine($"FROM {_table.FullName} {"a1"}");
                    unionOn = false;
                }

                foreach (var innerJoin in innerJoinMap.Value)
                {
                    query.AppendLine(innerJoin.ToString());
                    unionOn = true;
                }
            }

            return query.ToString();
        }
    }
}
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;

namespace Algorithms.ReadProvider
{
    public interface ISpecification<T>
    {
        Expression<Func<T,bool>> Criteria { get; } 
    }

    public interface IEvaluation<in TView,TDbEntity> : ISpecification<TDbEntity>
    {
        bool Evaluate(TView entity);
    }

    public class CanDeleteEvaluationSpecification : IEvaluation<EvaluationView,DbEvaluation>
    {
        public Expression<Func<DbEvaluation, bool>> Criteria { get; }= p => !p.IsCompleted && !p.IsArchived;

        public bool Evaluate(EvaluationView view)
        {
            return Criteria.Compile()(new DbEvaluation
            {
                IsCompleted = view.IsCompleted,
                IsArchived = view.IsArchived
            });
        }
    }

    public class EvaluationQuery
    {
        private readonly DbContext _db;
        private IQueryable<DbEvaluation> _inner;
        public EvaluationQuery(DbContext db)
        {
            _db = db;
            _inner = _db.Set<DbEvaluation>();
        }

        public EvaluationQuery Where(ISpecification<DbEvaluation> spec)
        {
            var query = new EvaluationQuery(_db);
            query._inner = _inner.Where(spec.Criteria);
            return query;
        }
    }

    public class EvaluationView
    {
        public string Name { get; set; }
        public bool IsArchived { get; set; }
        public bool IsCompleted { get; set; }
    }

    public class DbEvaluation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsArchived { get; set; }
        public bool IsCompleted { get; set; }
    }
}
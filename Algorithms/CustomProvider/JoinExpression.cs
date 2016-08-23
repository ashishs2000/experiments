using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Algorithms.CustomProvider
{
    public enum OrderByDirection
    {
        None = 0,
        Ascending,
        Descending
    }
    public static class OrderExtensions
    {
        public static IOrderedEnumerable<TSource> OrderByWithDirection<TSource, TKey>(this IEnumerable<TSource> value, Func<TSource, TKey> keySelector, IComparer<TKey> comparer, OrderByDirection direction)
        {
            //	Ideally, if order is not needed, the method would not be called, but sometimes it's easier to code a "no sort" option.
            //	Testing shows the "OrderByDirection.None" is negligible on large IEnumerables
            if (direction == OrderByDirection.None)
                return value.OrderBy(o => false);
            return direction == OrderByDirection.Descending ? value.OrderByDescending(keySelector, comparer) : value.OrderBy(keySelector, comparer);
        }

        public static IOrderedEnumerable<TSource> OrderByWithDirection<TSource, TKey>(this IEnumerable<TSource> value, Func<TSource, TKey> keySelector, OrderByDirection direction)
        {
            return value.OrderByWithDirection(keySelector, default(IComparer<TKey>), direction);
        }

        public static IOrderedEnumerable<TSource> ThenByWithDirection<TSource, TKey>(this IOrderedEnumerable<TSource> value, Func<TSource, TKey> keySelector, IComparer<TKey> comparer, OrderByDirection direction)
        {
            //	Ideally, if order is not needed, the method would not be called, but sometimes it's easier to code a "no sort" option.
            //	Testing shows the "OrderByDirection.None" is negligible on large IOrderedEnumerables
            if (direction == OrderByDirection.None)
                return value;
            return direction == OrderByDirection.Descending ? value.ThenByDescending(keySelector, comparer) : value.ThenBy(keySelector, comparer);
        }

        public static IOrderedEnumerable<TSource> ThenByWithDirection<TSource, TKey>(this IOrderedEnumerable<TSource> value, Func<TSource, TKey> keySelector, OrderByDirection direction)
        {
            return value.ThenByWithDirection(keySelector, default(IComparer<TKey>), direction);
        }
    }
    
    public static class JoinExtensions
    {
        public static IEnumerable<TResult> CrossJoin<TOuter, TInner, TResult>(this IEnumerable<TOuter> outer,
            IEnumerable<TInner> inner, Func<TOuter, TInner, TResult> resultSelector)
        {
            return outer.SelectMany(o => inner.Select(i => resultSelector(o, i)));
        }

        public static IEnumerable<TResult> LeftJoin<TOuter, TInner, TKey, TResult>(this IEnumerable<TOuter> outer,
            IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector,
            Func<TOuter, TInner, TResult> resultSelector, IEqualityComparer<TKey> comparer)
        {
            return outer.GroupJoin(
                inner,
                outerKeySelector,
                innerKeySelector,
                (o, ei) => ei
                    .Select(i => resultSelector(o, i))
                    .DefaultIfEmpty(resultSelector(o, default(TInner))), comparer)
                    .SelectMany(oi => oi);
        }

        public static IEnumerable<TResult> LeftJoin<TOuter, TInner, TKey, TResult>(this IEnumerable<TOuter> outer,
            IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector,
            Func<TOuter, TInner, TResult> resultSelector)
        {
            return outer.LeftJoin(inner, outerKeySelector, innerKeySelector, resultSelector, default(IEqualityComparer<TKey>));
        }
        
        public static IEnumerable<TResult> RightJoin<TOuter, TInner, TKey, TResult>(this IEnumerable<TOuter> outer,
            IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector,
            Func<TOuter, TInner, TResult> resultSelector, IEqualityComparer<TKey> comparer)
        {
            return inner.LeftJoin(outer, innerKeySelector, outerKeySelector, (o, i) => resultSelector(i, o), comparer);
        }
        
        public static IEnumerable<TResult> RightJoin<TOuter, TInner, TKey, TResult>(this IEnumerable<TOuter> outer,
            IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector,
            Func<TOuter, TInner, TResult> resultSelector)
        {
            return outer.RightJoin(inner, outerKeySelector, innerKeySelector, resultSelector, default(IEqualityComparer<TKey>));
        }
        
        public static IEnumerable<TResult> FullJoin<TOuter, TInner, TKey, TResult>(this IEnumerable<TOuter> outer,
            IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector,
            Func<TOuter, TInner, TResult> resultSelector, IEqualityComparer<TKey> comparer)
        {
            var leftInner = outer.LeftJoin(inner, outerKeySelector, innerKeySelector, (o, i) => new { o, i }, comparer);
            var defOuter = default(TOuter);
            var right = outer.RightJoin(inner, outerKeySelector, innerKeySelector, (o, i) => new { o, i }, comparer)
                .Where(oi => oi.o == null || oi.o.Equals(defOuter));
            return leftInner.Concat(right).Select(oi => resultSelector(oi.o, oi.i));
        }
        
        public static IEnumerable<TResult> FullJoin<TOuter, TInner, TKey, TResult>(this IEnumerable<TOuter> outer,
            IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector,
            Func<TOuter, TInner, TResult> resultSelector)
        {
            return outer.FullJoin(inner, outerKeySelector, innerKeySelector, resultSelector, default(IEqualityComparer<TKey>));
        }
    }
}
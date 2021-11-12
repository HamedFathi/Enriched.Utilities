using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Enriched.Utilities
{
    public static class QueryableReflectionUtility
    {
        public static readonly MethodInfo Aggregate1 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                        where x.Name == nameof(Queryable.Aggregate)
                                                        let args = x.GetGenericArguments()
                                                        where args.Length == 1
                                                        let pars = x.GetParameters()
                                                        where pars.Length == 2 &&
                                                            pars[0].ParameterType == typeof(IQueryable<>).MakeGenericType(args[0]) &&
                                                            pars[1].ParameterType == typeof(Expression<>).MakeGenericType(typeof(Func<,,>).MakeGenericType(args[0], args[0], args[0]))
                                                        select x).Single();

        public static readonly MethodInfo Aggregate2 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                        where x.Name == nameof(Queryable.Aggregate)
                                                        let args = x.GetGenericArguments()
                                                        where args.Length == 2
                                                        let pars = x.GetParameters()
                                                        where pars.Length == 3 &&
                                                            pars[0].ParameterType == typeof(IQueryable<>).MakeGenericType(args[0]) &&
                                                            pars[1].ParameterType == args[1] &&
                                                            pars[2].ParameterType == typeof(Expression<>).MakeGenericType(typeof(Func<,,>).MakeGenericType(args[1], args[0], args[1]))
                                                        select x).Single();

        public static readonly MethodInfo Aggregate3 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                        where x.Name == nameof(Queryable.Aggregate)
                                                        let args = x.GetGenericArguments()
                                                        where args.Length == 3
                                                        let pars = x.GetParameters()
                                                        where pars.Length == 4 &&
                                                            pars[0].ParameterType == typeof(IQueryable<>).MakeGenericType(args[0]) &&
                                                            pars[1].ParameterType == args[1] &&
                                                            pars[2].ParameterType == typeof(Expression<>).MakeGenericType(typeof(Func<,,>).MakeGenericType(args[1], args[0], args[1])) &&
                                                            pars[3].ParameterType == typeof(Expression<>).MakeGenericType(typeof(Func<,>).MakeGenericType(args[1], args[2]))
                                                        select x).Single();

        public static readonly MethodInfo All = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                 where x.Name == nameof(Queryable.All)
                                                 let args = x.GetGenericArguments()
                                                 where args.Length == 1
                                                 let pars = x.GetParameters()
                                                 where pars.Length == 2 &&
                                                     pars[0].ParameterType == typeof(IQueryable<>).MakeGenericType(args[0]) &&
                                                     pars[1].ParameterType == typeof(Expression<>).MakeGenericType(typeof(Func<,>).MakeGenericType(args[0], typeof(bool)))
                                                 select x).Single();

        public static readonly MethodInfo Any1 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                  where x.Name == nameof(Queryable.Any)
                                                  let args = x.GetGenericArguments()
                                                  where args.Length == 1
                                                  let pars = x.GetParameters()
                                                  where pars.Length == 1 &&
                                                      pars[0].ParameterType == typeof(IQueryable<>).MakeGenericType(args[0])
                                                  select x).Single();

        public static readonly MethodInfo Any2 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                  where x.Name == nameof(Queryable.Any)
                                                  let args = x.GetGenericArguments()
                                                  where args.Length == 1
                                                  let pars = x.GetParameters()
                                                  where pars.Length == 2 &&
                                                      pars[0].ParameterType == typeof(IQueryable<>).MakeGenericType(args[0]) &&
                                                      pars[1].ParameterType == typeof(Expression<>).MakeGenericType(typeof(Func<,>).MakeGenericType(args[0], typeof(bool)))
                                                  select x).Single();

        public static readonly MethodInfo AsQueryable1 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                          where x.Name == nameof(Queryable.AsQueryable)
                                                          let args = x.GetGenericArguments()
                                                          where args.Length == 1
                                                          let pars = x.GetParameters()
                                                          where pars.Length == 1 &&
                                                              pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0])
                                                          select x).Single();

        public static readonly MethodInfo AsQueryable2 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                          where x.Name == nameof(Queryable.AsQueryable) &&
                                                              x.GetGenericArguments().Length == 0
                                                          let pars = x.GetParameters()
                                                          where pars.Length == 1 &&
                                                              pars[0].ParameterType == typeof(System.Collections.IEnumerable)
                                                          select x).Single();

        public static readonly MethodInfo Average1 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                      where x.Name == nameof(Queryable.Average) &&
                                                          x.GetGenericArguments().Length == 0
                                                      let pars = x.GetParameters()
                                                      where pars.Length == 1 &&
                                                          pars[0].ParameterType == typeof(IQueryable<int>)
                                                      select x).Single();

        public static readonly MethodInfo Average2 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                      where x.Name == nameof(Queryable.Average) &&
                                                          x.GetGenericArguments().Length == 0
                                                      let pars = x.GetParameters()
                                                      where pars.Length == 1 &&
                                                          pars[0].ParameterType == typeof(IQueryable<int?>)
                                                      select x).Single();

        public static readonly MethodInfo Average3 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                      where x.Name == nameof(Queryable.Average) &&
                                                          x.GetGenericArguments().Length == 0
                                                      let pars = x.GetParameters()
                                                      where pars.Length == 1 &&
                                                          pars[0].ParameterType == typeof(IQueryable<long>)
                                                      select x).Single();

        public static readonly MethodInfo Average4 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                      where x.Name == nameof(Queryable.Average) &&
                                                          x.GetGenericArguments().Length == 0
                                                      let pars = x.GetParameters()
                                                      where pars.Length == 1 &&
                                                          pars[0].ParameterType == typeof(IQueryable<long?>)
                                                      select x).Single();

        public static readonly MethodInfo Average5 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                      where x.Name == nameof(Queryable.Average) &&
                                                          x.GetGenericArguments().Length == 0
                                                      let pars = x.GetParameters()
                                                      where pars.Length == 1 &&
                                                          pars[0].ParameterType == typeof(IQueryable<float>)
                                                      select x).Single();

        public static readonly MethodInfo Average6 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                      where x.Name == nameof(Queryable.Average) &&
                                                          x.GetGenericArguments().Length == 0
                                                      let pars = x.GetParameters()
                                                      where pars.Length == 1 &&
                                                          pars[0].ParameterType == typeof(IQueryable<float?>)
                                                      select x).Single();

        public static readonly MethodInfo Average7 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                      where x.Name == nameof(Queryable.Average) &&
                                                          x.GetGenericArguments().Length == 0
                                                      let pars = x.GetParameters()
                                                      where pars.Length == 1 &&
                                                          pars[0].ParameterType == typeof(IQueryable<double>)
                                                      select x).Single();

        public static readonly MethodInfo Average8 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                      where x.Name == nameof(Queryable.Average) &&
                                                          x.GetGenericArguments().Length == 0
                                                      let pars = x.GetParameters()
                                                      where pars.Length == 1 &&
                                                          pars[0].ParameterType == typeof(IQueryable<double?>)
                                                      select x).Single();

        public static readonly MethodInfo Average9 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                      where x.Name == nameof(Queryable.Average) &&
                                                          x.GetGenericArguments().Length == 0
                                                      let pars = x.GetParameters()
                                                      where pars.Length == 1 &&
                                                          pars[0].ParameterType == typeof(IQueryable<decimal>)
                                                      select x).Single();

        public static readonly MethodInfo Average10 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                       where x.Name == nameof(Queryable.Average) &&
                                                           x.GetGenericArguments().Length == 0
                                                       let pars = x.GetParameters()
                                                       where pars.Length == 1 &&
                                                           pars[0].ParameterType == typeof(IQueryable<decimal?>)
                                                       select x).Single();

        public static readonly MethodInfo Average11 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                       where x.Name == nameof(Queryable.Average)
                                                       let args = x.GetGenericArguments()
                                                       where args.Length == 1
                                                       let pars = x.GetParameters()
                                                       where pars.Length == 2 &&
                                                           pars[0].ParameterType == typeof(IQueryable<>).MakeGenericType(args[0]) &&
                                                           pars[1].ParameterType == typeof(Expression<>).MakeGenericType(typeof(Func<,>).MakeGenericType(args[0], typeof(int)))
                                                       select x).Single();

        public static readonly MethodInfo Average12 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                       where x.Name == nameof(Queryable.Average)
                                                       let args = x.GetGenericArguments()
                                                       where args.Length == 1
                                                       let pars = x.GetParameters()
                                                       where pars.Length == 2 &&
                                                           pars[0].ParameterType == typeof(IQueryable<>).MakeGenericType(args[0]) &&
                                                           pars[1].ParameterType == typeof(Expression<>).MakeGenericType(typeof(Func<,>).MakeGenericType(args[0], typeof(int?)))
                                                       select x).Single();

        public static readonly MethodInfo Average13 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                       where x.Name == nameof(Queryable.Average)
                                                       let args = x.GetGenericArguments()
                                                       where args.Length == 1
                                                       let pars = x.GetParameters()
                                                       where pars.Length == 2 &&
                                                           pars[0].ParameterType == typeof(IQueryable<>).MakeGenericType(args[0]) &&
                                                           pars[1].ParameterType == typeof(Expression<>).MakeGenericType(typeof(Func<,>).MakeGenericType(args[0], typeof(float)))
                                                       select x).Single();

        public static readonly MethodInfo Average14 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                       where x.Name == nameof(Queryable.Average)
                                                       let args = x.GetGenericArguments()
                                                       where args.Length == 1
                                                       let pars = x.GetParameters()
                                                       where pars.Length == 2 &&
                                                           pars[0].ParameterType == typeof(IQueryable<>).MakeGenericType(args[0]) &&
                                                           pars[1].ParameterType == typeof(Expression<>).MakeGenericType(typeof(Func<,>).MakeGenericType(args[0], typeof(float?)))
                                                       select x).Single();

        public static readonly MethodInfo Average15 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                       where x.Name == nameof(Queryable.Average)
                                                       let args = x.GetGenericArguments()
                                                       where args.Length == 1
                                                       let pars = x.GetParameters()
                                                       where pars.Length == 2 &&
                                                           pars[0].ParameterType == typeof(IQueryable<>).MakeGenericType(args[0]) &&
                                                           pars[1].ParameterType == typeof(Expression<>).MakeGenericType(typeof(Func<,>).MakeGenericType(args[0], typeof(long)))
                                                       select x).Single();

        public static readonly MethodInfo Average16 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                       where x.Name == nameof(Queryable.Average)
                                                       let args = x.GetGenericArguments()
                                                       where args.Length == 1
                                                       let pars = x.GetParameters()
                                                       where pars.Length == 2 &&
                                                           pars[0].ParameterType == typeof(IQueryable<>).MakeGenericType(args[0]) &&
                                                           pars[1].ParameterType == typeof(Expression<>).MakeGenericType(typeof(Func<,>).MakeGenericType(args[0], typeof(long?)))
                                                       select x).Single();

        public static readonly MethodInfo Average17 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                       where x.Name == nameof(Queryable.Average)
                                                       let args = x.GetGenericArguments()
                                                       where args.Length == 1
                                                       let pars = x.GetParameters()
                                                       where pars.Length == 2 &&
                                                           pars[0].ParameterType == typeof(IQueryable<>).MakeGenericType(args[0]) &&
                                                           pars[1].ParameterType == typeof(Expression<>).MakeGenericType(typeof(Func<,>).MakeGenericType(args[0], typeof(double)))
                                                       select x).Single();

        public static readonly MethodInfo Average18 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                       where x.Name == nameof(Queryable.Average)
                                                       let args = x.GetGenericArguments()
                                                       where args.Length == 1
                                                       let pars = x.GetParameters()
                                                       where pars.Length == 2 &&
                                                           pars[0].ParameterType == typeof(IQueryable<>).MakeGenericType(args[0]) &&
                                                           pars[1].ParameterType == typeof(Expression<>).MakeGenericType(typeof(Func<,>).MakeGenericType(args[0], typeof(double?)))
                                                       select x).Single();

        public static readonly MethodInfo Average19 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                       where x.Name == nameof(Queryable.Average)
                                                       let args = x.GetGenericArguments()
                                                       where args.Length == 1
                                                       let pars = x.GetParameters()
                                                       where pars.Length == 2 &&
                                                           pars[0].ParameterType == typeof(IQueryable<>).MakeGenericType(args[0]) &&
                                                           pars[1].ParameterType == typeof(Expression<>).MakeGenericType(typeof(Func<,>).MakeGenericType(args[0], typeof(decimal)))
                                                       select x).Single();

        public static readonly MethodInfo Average20 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                       where x.Name == nameof(Queryable.Average)
                                                       let args = x.GetGenericArguments()
                                                       where args.Length == 1
                                                       let pars = x.GetParameters()
                                                       where pars.Length == 2 &&
                                                           pars[0].ParameterType == typeof(IQueryable<>).MakeGenericType(args[0]) &&
                                                           pars[1].ParameterType == typeof(Expression<>).MakeGenericType(typeof(Func<,>).MakeGenericType(args[0], typeof(decimal?)))
                                                       select x).Single();

        public static readonly MethodInfo Cast = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                  where x.Name == nameof(Queryable.Cast) &&
                                                      x.GetGenericArguments().Length == 1
                                                  let pars = x.GetParameters()
                                                  where pars.Length == 1 &&
                                                      pars[0].ParameterType == typeof(IQueryable)
                                                  select x).Single();

        public static readonly MethodInfo Concat = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                    where x.Name == nameof(Queryable.Concat)
                                                    let args = x.GetGenericArguments()
                                                    where args.Length == 1
                                                    let pars = x.GetParameters()
                                                    where pars.Length == 2 &&
                                                        pars[0].ParameterType == typeof(IQueryable<>).MakeGenericType(args[0]) &&
                                                        pars[1].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0])
                                                    select x).Single();

        public static readonly MethodInfo Contains1 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                       where x.Name == nameof(Queryable.Contains)
                                                       let args = x.GetGenericArguments()
                                                       where args.Length == 1
                                                       let pars = x.GetParameters()
                                                       where pars.Length == 2 &&
                                                           pars[0].ParameterType == typeof(IQueryable<>).MakeGenericType(args[0]) &&
                                                           pars[1].ParameterType == args[0]
                                                       select x).Single();

        public static readonly MethodInfo Contains2 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                       where x.Name == nameof(Queryable.Contains)
                                                       let args = x.GetGenericArguments()
                                                       where args.Length == 1
                                                       let pars = x.GetParameters()
                                                       where pars.Length == 3 &&
                                                           pars[0].ParameterType == typeof(IQueryable<>).MakeGenericType(args[0]) &&
                                                           pars[1].ParameterType == args[0] &&
                                                           pars[2].ParameterType == typeof(IEqualityComparer<>).MakeGenericType(args[0])
                                                       select x).Single();

        public static readonly MethodInfo Count1 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                    where x.Name == nameof(Queryable.Count)
                                                    let args = x.GetGenericArguments()
                                                    where args.Length == 1
                                                    let pars = x.GetParameters()
                                                    where pars.Length == 1 &&
                                                        pars[0].ParameterType == typeof(IQueryable<>).MakeGenericType(args[0])
                                                    select x).Single();

        public static readonly MethodInfo Count2 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                    where x.Name == nameof(Queryable.Count)
                                                    let args = x.GetGenericArguments()
                                                    where args.Length == 1
                                                    let pars = x.GetParameters()
                                                    where pars.Length == 2 &&
                                                        pars[0].ParameterType == typeof(IQueryable<>).MakeGenericType(args[0]) &&
                                                        pars[1].ParameterType == typeof(Expression<>).MakeGenericType(typeof(Func<,>).MakeGenericType(args[0], typeof(bool)))
                                                    select x).Single();

        public static readonly MethodInfo DefaultIfEmpty1 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                             where x.Name == nameof(Queryable.DefaultIfEmpty)
                                                             let args = x.GetGenericArguments()
                                                             where args.Length == 1
                                                             let pars = x.GetParameters()
                                                             where pars.Length == 1 &&
                                                                 pars[0].ParameterType == typeof(IQueryable<>).MakeGenericType(args[0])
                                                             select x).Single();

        public static readonly MethodInfo DefaultIfEmpty2 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                             where x.Name == nameof(Queryable.DefaultIfEmpty)
                                                             let args = x.GetGenericArguments()
                                                             where args.Length == 1
                                                             let pars = x.GetParameters()
                                                             where pars.Length == 2 &&
                                                                 pars[0].ParameterType == typeof(IQueryable<>).MakeGenericType(args[0]) &&
                                                                 pars[1].ParameterType == args[0]
                                                             select x).Single();

        public static readonly MethodInfo Distinct1 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                       where x.Name == nameof(Queryable.Distinct)
                                                       let args = x.GetGenericArguments()
                                                       where args.Length == 1
                                                       let pars = x.GetParameters()
                                                       where pars.Length == 1 &&
                                                           pars[0].ParameterType == typeof(IQueryable<>).MakeGenericType(args[0])
                                                       select x).Single();

        public static readonly MethodInfo Distinct2 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                       where x.Name == nameof(Queryable.Distinct)
                                                       let args = x.GetGenericArguments()
                                                       where args.Length == 1
                                                       let pars = x.GetParameters()
                                                       where pars.Length == 2 &&
                                                           pars[0].ParameterType == typeof(IQueryable<>).MakeGenericType(args[0]) &&
                                                           pars[1].ParameterType == typeof(IEqualityComparer<>).MakeGenericType(args[0])
                                                       select x).Single();

        public static readonly MethodInfo ElementAt = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                       where x.Name == nameof(Queryable.ElementAt)
                                                       let args = x.GetGenericArguments()
                                                       where args.Length == 1
                                                       let pars = x.GetParameters()
                                                       where pars.Length == 2 &&
                                                           pars[0].ParameterType == typeof(IQueryable<>).MakeGenericType(args[0]) &&
                                                           pars[1].ParameterType == typeof(int)
                                                       select x).Single();

        public static readonly MethodInfo ElementAtOrDefault = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                                where x.Name == nameof(Queryable.ElementAtOrDefault)
                                                                let args = x.GetGenericArguments()
                                                                where args.Length == 1
                                                                let pars = x.GetParameters()
                                                                where pars.Length == 2 &&
                                                                    pars[0].ParameterType == typeof(IQueryable<>).MakeGenericType(args[0]) &&
                                                                    pars[1].ParameterType == typeof(int)
                                                                select x).Single();

        public static readonly MethodInfo Except1 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                     where x.Name == nameof(Queryable.Except)
                                                     let args = x.GetGenericArguments()
                                                     where args.Length == 1
                                                     let pars = x.GetParameters()
                                                     where pars.Length == 2 &&
                                                         pars[0].ParameterType == typeof(IQueryable<>).MakeGenericType(args[0]) &&
                                                         pars[1].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0])
                                                     select x).Single();

        public static readonly MethodInfo Except2 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                     where x.Name == nameof(Queryable.Except)
                                                     let args = x.GetGenericArguments()
                                                     where args.Length == 1
                                                     let pars = x.GetParameters()
                                                     where pars.Length == 3 &&
                                                         pars[0].ParameterType == typeof(IQueryable<>).MakeGenericType(args[0]) &&
                                                         pars[1].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                         pars[2].ParameterType == typeof(IEqualityComparer<>).MakeGenericType(args[0])
                                                     select x).Single();

        public static readonly MethodInfo First1 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                    where x.Name == nameof(Queryable.First)
                                                    let args = x.GetGenericArguments()
                                                    where args.Length == 1
                                                    let pars = x.GetParameters()
                                                    where pars.Length == 1 &&
                                                        pars[0].ParameterType == typeof(IQueryable<>).MakeGenericType(args[0])
                                                    select x).Single();

        public static readonly MethodInfo First2 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                    where x.Name == nameof(Queryable.First)
                                                    let args = x.GetGenericArguments()
                                                    where args.Length == 1
                                                    let pars = x.GetParameters()
                                                    where pars.Length == 2 &&
                                                        pars[0].ParameterType == typeof(IQueryable<>).MakeGenericType(args[0]) &&
                                                        pars[1].ParameterType == typeof(Expression<>).MakeGenericType(typeof(Func<,>).MakeGenericType(args[0], typeof(bool)))
                                                    select x).Single();

        public static readonly MethodInfo FirstOrDefault1 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                             where x.Name == nameof(Queryable.FirstOrDefault)
                                                             let args = x.GetGenericArguments()
                                                             where args.Length == 1
                                                             let pars = x.GetParameters()
                                                             where pars.Length == 1 &&
                                                                 pars[0].ParameterType == typeof(IQueryable<>).MakeGenericType(args[0])
                                                             select x).Single();

        public static readonly MethodInfo FirstOrDefault2 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                             where x.Name == nameof(Queryable.FirstOrDefault)
                                                             let args = x.GetGenericArguments()
                                                             where args.Length == 1
                                                             let pars = x.GetParameters()
                                                             where pars.Length == 2 &&
                                                                 pars[0].ParameterType == typeof(IQueryable<>).MakeGenericType(args[0]) &&
                                                                 pars[1].ParameterType == typeof(Expression<>).MakeGenericType(typeof(Func<,>).MakeGenericType(args[0], typeof(bool)))
                                                             select x).Single();

        public static readonly MethodInfo GroupBy1 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                      where x.Name == nameof(Queryable.GroupBy)
                                                      let args = x.GetGenericArguments()
                                                      where args.Length == 2
                                                      let pars = x.GetParameters()
                                                      where pars.Length == 2 &&
                                                          pars[0].ParameterType == typeof(IQueryable<>).MakeGenericType(args[0]) &&
                                                          pars[1].ParameterType == typeof(Expression<>).MakeGenericType(typeof(Func<,>).MakeGenericType(args[0], args[1]))
                                                      select x).Single();

        public static readonly MethodInfo GroupBy2 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                      where x.Name == nameof(Queryable.GroupBy)
                                                      let args = x.GetGenericArguments()
                                                      where args.Length == 3
                                                      let pars = x.GetParameters()
                                                      where pars.Length == 3 &&
                                                          pars[0].ParameterType == typeof(IQueryable<>).MakeGenericType(args[0]) &&
                                                          pars[1].ParameterType == typeof(Expression<>).MakeGenericType(typeof(Func<,>).MakeGenericType(args[0], args[1])) &&
                                                          pars[2].ParameterType == typeof(Expression<>).MakeGenericType(typeof(Func<,>).MakeGenericType(args[0], args[2]))
                                                      select x).Single();

        public static readonly MethodInfo GroupBy3 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                      where x.Name == nameof(Queryable.GroupBy)
                                                      let args = x.GetGenericArguments()
                                                      where args.Length == 2
                                                      let pars = x.GetParameters()
                                                      where pars.Length == 3 &&
                                                          pars[0].ParameterType == typeof(IQueryable<>).MakeGenericType(args[0]) &&
                                                          pars[1].ParameterType == typeof(Expression<>).MakeGenericType(typeof(Func<,>).MakeGenericType(args[0], args[1])) &&
                                                          pars[2].ParameterType == typeof(IEqualityComparer<>).MakeGenericType(args[1])
                                                      select x).Single();

        public static readonly MethodInfo GroupBy4 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                      where x.Name == nameof(Queryable.GroupBy)
                                                      let args = x.GetGenericArguments()
                                                      where args.Length == 3
                                                      let pars = x.GetParameters()
                                                      where pars.Length == 3 &&
                                                          pars[0].ParameterType == typeof(IQueryable<>).MakeGenericType(args[0]) &&
                                                          pars[1].ParameterType == typeof(Expression<>).MakeGenericType(typeof(Func<,>).MakeGenericType(args[0], args[1])) &&
                                                          pars[2].ParameterType == typeof(Expression<>).MakeGenericType(typeof(Func<,,>).MakeGenericType(args[1], typeof(IEnumerable<>).MakeGenericType(args[0]), args[2]))
                                                      select x).Single();

        public static readonly MethodInfo GroupBy5 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                      where x.Name == nameof(Queryable.GroupBy)
                                                      let args = x.GetGenericArguments()
                                                      where args.Length == 3
                                                      let pars = x.GetParameters()
                                                      where pars.Length == 4 &&
                                                          pars[0].ParameterType == typeof(IQueryable<>).MakeGenericType(args[0]) &&
                                                          pars[1].ParameterType == typeof(Expression<>).MakeGenericType(typeof(Func<,>).MakeGenericType(args[0], args[1])) &&
                                                          pars[2].ParameterType == typeof(Expression<>).MakeGenericType(typeof(Func<,>).MakeGenericType(args[0], args[2])) &&
                                                          pars[3].ParameterType == typeof(IEqualityComparer<>).MakeGenericType(args[1])
                                                      select x).Single();

        public static readonly MethodInfo GroupBy6 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                      where x.Name == nameof(Queryable.GroupBy)
                                                      let args = x.GetGenericArguments()
                                                      where args.Length == 4
                                                      let pars = x.GetParameters()
                                                      where pars.Length == 4 &&
                                                          pars[0].ParameterType == typeof(IQueryable<>).MakeGenericType(args[0]) &&
                                                          pars[1].ParameterType == typeof(Expression<>).MakeGenericType(typeof(Func<,>).MakeGenericType(args[0], args[1])) &&
                                                          pars[2].ParameterType == typeof(Expression<>).MakeGenericType(typeof(Func<,>).MakeGenericType(args[0], args[2])) &&
                                                          pars[3].ParameterType == typeof(Expression<>).MakeGenericType(typeof(Func<,,>).MakeGenericType(args[1], typeof(IEnumerable<>).MakeGenericType(args[2]), args[3]))
                                                      select x).Single();

        public static readonly MethodInfo GroupBy7 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                      where x.Name == nameof(Queryable.GroupBy)
                                                      let args = x.GetGenericArguments()
                                                      where args.Length == 3
                                                      let pars = x.GetParameters()
                                                      where pars.Length == 4 &&
                                                          pars[0].ParameterType == typeof(IQueryable<>).MakeGenericType(args[0]) &&
                                                          pars[1].ParameterType == typeof(Expression<>).MakeGenericType(typeof(Func<,>).MakeGenericType(args[0], args[1])) &&
                                                          pars[2].ParameterType == typeof(Expression<>).MakeGenericType(typeof(Func<,,>).MakeGenericType(args[1], typeof(IEnumerable<>).MakeGenericType(args[0]), args[2])) &&
                                                          pars[3].ParameterType == typeof(IEqualityComparer<>).MakeGenericType(args[1])
                                                      select x).Single();

        public static readonly MethodInfo GroupBy8 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                      where x.Name == nameof(Queryable.GroupBy)
                                                      let args = x.GetGenericArguments()
                                                      where args.Length == 4
                                                      let pars = x.GetParameters()
                                                      where pars.Length == 5 &&
                                                          pars[0].ParameterType == typeof(IQueryable<>).MakeGenericType(args[0]) &&
                                                          pars[1].ParameterType == typeof(Expression<>).MakeGenericType(typeof(Func<,>).MakeGenericType(args[0], args[1])) &&
                                                          pars[2].ParameterType == typeof(Expression<>).MakeGenericType(typeof(Func<,>).MakeGenericType(args[0], args[2])) &&
                                                          pars[3].ParameterType == typeof(Expression<>).MakeGenericType(typeof(Func<,,>).MakeGenericType(args[1], typeof(IEnumerable<>).MakeGenericType(args[2]), args[3])) &&
                                                          pars[4].ParameterType == typeof(IEqualityComparer<>).MakeGenericType(args[1])
                                                      select x).Single();

        public static readonly MethodInfo GroupJoin1 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                        where x.Name == nameof(Queryable.GroupJoin)
                                                        let args = x.GetGenericArguments()
                                                        where args.Length == 4
                                                        let pars = x.GetParameters()
                                                        where pars.Length == 5 &&
                                                            pars[0].ParameterType == typeof(IQueryable<>).MakeGenericType(args[0]) &&
                                                            pars[1].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[1]) &&
                                                            pars[2].ParameterType == typeof(Expression<>).MakeGenericType(typeof(Func<,>).MakeGenericType(args[0], args[2])) &&
                                                            pars[3].ParameterType == typeof(Expression<>).MakeGenericType(typeof(Func<,>).MakeGenericType(args[1], args[2])) &&
                                                            pars[4].ParameterType == typeof(Expression<>).MakeGenericType(typeof(Func<,,>).MakeGenericType(args[0], typeof(IEnumerable<>).MakeGenericType(args[1]), args[3]))
                                                        select x).Single();

        public static readonly MethodInfo GroupJoin2 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                        where x.Name == nameof(Queryable.GroupJoin)
                                                        let args = x.GetGenericArguments()
                                                        where args.Length == 4
                                                        let pars = x.GetParameters()
                                                        where pars.Length == 6 &&
                                                            pars[0].ParameterType == typeof(IQueryable<>).MakeGenericType(args[0]) &&
                                                            pars[1].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[1]) &&
                                                            pars[2].ParameterType == typeof(Expression<>).MakeGenericType(typeof(Func<,>).MakeGenericType(args[0], args[2])) &&
                                                            pars[3].ParameterType == typeof(Expression<>).MakeGenericType(typeof(Func<,>).MakeGenericType(args[1], args[2])) &&
                                                            pars[4].ParameterType == typeof(Expression<>).MakeGenericType(typeof(Func<,,>).MakeGenericType(args[0], typeof(IEnumerable<>).MakeGenericType(args[1]), args[3])) &&
                                                            pars[5].ParameterType == typeof(IEqualityComparer<>).MakeGenericType(args[2])
                                                        select x).Single();

        public static readonly MethodInfo Intersect1 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                        where x.Name == nameof(Queryable.Intersect)
                                                        let args = x.GetGenericArguments()
                                                        where args.Length == 1
                                                        let pars = x.GetParameters()
                                                        where pars.Length == 2 &&
                                                            pars[0].ParameterType == typeof(IQueryable<>).MakeGenericType(args[0]) &&
                                                            pars[1].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0])
                                                        select x).Single();

        public static readonly MethodInfo Intersect2 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                        where x.Name == nameof(Queryable.Intersect)
                                                        let args = x.GetGenericArguments()
                                                        where args.Length == 1
                                                        let pars = x.GetParameters()
                                                        where pars.Length == 3 &&
                                                            pars[0].ParameterType == typeof(IQueryable<>).MakeGenericType(args[0]) &&
                                                            pars[1].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                            pars[2].ParameterType == typeof(IEqualityComparer<>).MakeGenericType(args[0])
                                                        select x).Single();

        public static readonly MethodInfo Join1 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                   where x.Name == nameof(Queryable.Join)
                                                   let args = x.GetGenericArguments()
                                                   where args.Length == 4
                                                   let pars = x.GetParameters()
                                                   where pars.Length == 5 &&
                                                       pars[0].ParameterType == typeof(IQueryable<>).MakeGenericType(args[0]) &&
                                                       pars[1].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[1]) &&
                                                       pars[2].ParameterType == typeof(Expression<>).MakeGenericType(typeof(Func<,>).MakeGenericType(args[0], args[2])) &&
                                                       pars[3].ParameterType == typeof(Expression<>).MakeGenericType(typeof(Func<,>).MakeGenericType(args[1], args[2])) &&
                                                       pars[4].ParameterType == typeof(Expression<>).MakeGenericType(typeof(Func<,,>).MakeGenericType(args[0], args[1], args[3]))
                                                   select x).Single();

        public static readonly MethodInfo Join2 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                   where x.Name == nameof(Queryable.Join)
                                                   let args = x.GetGenericArguments()
                                                   where args.Length == 4
                                                   let pars = x.GetParameters()
                                                   where pars.Length == 6 &&
                                                       pars[0].ParameterType == typeof(IQueryable<>).MakeGenericType(args[0]) &&
                                                       pars[1].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[1]) &&
                                                       pars[2].ParameterType == typeof(Expression<>).MakeGenericType(typeof(Func<,>).MakeGenericType(args[0], args[2])) &&
                                                       pars[3].ParameterType == typeof(Expression<>).MakeGenericType(typeof(Func<,>).MakeGenericType(args[1], args[2])) &&
                                                       pars[4].ParameterType == typeof(Expression<>).MakeGenericType(typeof(Func<,,>).MakeGenericType(args[0], args[1], args[3])) &&
                                                       pars[5].ParameterType == typeof(IEqualityComparer<>).MakeGenericType(args[2])
                                                   select x).Single();

        public static readonly MethodInfo Last1 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                   where x.Name == nameof(Queryable.Last)
                                                   let args = x.GetGenericArguments()
                                                   where args.Length == 1
                                                   let pars = x.GetParameters()
                                                   where pars.Length == 1 &&
                                                       pars[0].ParameterType == typeof(IQueryable<>).MakeGenericType(args[0])
                                                   select x).Single();

        public static readonly MethodInfo Last2 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                   where x.Name == nameof(Queryable.Last)
                                                   let args = x.GetGenericArguments()
                                                   where args.Length == 1
                                                   let pars = x.GetParameters()
                                                   where pars.Length == 2 &&
                                                       pars[0].ParameterType == typeof(IQueryable<>).MakeGenericType(args[0]) &&
                                                       pars[1].ParameterType == typeof(Expression<>).MakeGenericType(typeof(Func<,>).MakeGenericType(args[0], typeof(bool)))
                                                   select x).Single();

        public static readonly MethodInfo LastOrDefault1 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                            where x.Name == nameof(Queryable.LastOrDefault)
                                                            let args = x.GetGenericArguments()
                                                            where args.Length == 1
                                                            let pars = x.GetParameters()
                                                            where pars.Length == 1 &&
                                                                pars[0].ParameterType == typeof(IQueryable<>).MakeGenericType(args[0])
                                                            select x).Single();

        public static readonly MethodInfo LastOrDefault2 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                            where x.Name == nameof(Queryable.LastOrDefault)
                                                            let args = x.GetGenericArguments()
                                                            where args.Length == 1
                                                            let pars = x.GetParameters()
                                                            where pars.Length == 2 &&
                                                                pars[0].ParameterType == typeof(IQueryable<>).MakeGenericType(args[0]) &&
                                                                pars[1].ParameterType == typeof(Expression<>).MakeGenericType(typeof(Func<,>).MakeGenericType(args[0], typeof(bool)))
                                                            select x).Single();

        public static readonly MethodInfo LongCount1 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                        where x.Name == nameof(Queryable.LongCount)
                                                        let args = x.GetGenericArguments()
                                                        where args.Length == 1
                                                        let pars = x.GetParameters()
                                                        where pars.Length == 1 &&
                                                            pars[0].ParameterType == typeof(IQueryable<>).MakeGenericType(args[0])
                                                        select x).Single();

        public static readonly MethodInfo LongCount2 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                        where x.Name == nameof(Queryable.LongCount)
                                                        let args = x.GetGenericArguments()
                                                        where args.Length == 1
                                                        let pars = x.GetParameters()
                                                        where pars.Length == 2 &&
                                                            pars[0].ParameterType == typeof(IQueryable<>).MakeGenericType(args[0]) &&
                                                            pars[1].ParameterType == typeof(Expression<>).MakeGenericType(typeof(Func<,>).MakeGenericType(args[0], typeof(bool)))
                                                        select x).Single();

        public static readonly MethodInfo Max1 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                  where x.Name == nameof(Queryable.Max)
                                                  let args = x.GetGenericArguments()
                                                  where args.Length == 1
                                                  let pars = x.GetParameters()
                                                  where pars.Length == 1 &&
                                                      pars[0].ParameterType == typeof(IQueryable<>).MakeGenericType(args[0])
                                                  select x).Single();

        public static readonly MethodInfo Max2 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                  where x.Name == nameof(Queryable.Max)
                                                  let args = x.GetGenericArguments()
                                                  where args.Length == 2
                                                  let pars = x.GetParameters()
                                                  where pars.Length == 2 &&
                                                      pars[0].ParameterType == typeof(IQueryable<>).MakeGenericType(args[0]) &&
                                                      pars[1].ParameterType == typeof(Expression<>).MakeGenericType(typeof(Func<,>).MakeGenericType(args[0], args[1]))
                                                  select x).Single();

        public static readonly MethodInfo Min1 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                  where x.Name == nameof(Queryable.Min)
                                                  let args = x.GetGenericArguments()
                                                  where args.Length == 1
                                                  let pars = x.GetParameters()
                                                  where pars.Length == 1 &&
                                                      pars[0].ParameterType == typeof(IQueryable<>).MakeGenericType(args[0])
                                                  select x).Single();

        public static readonly MethodInfo Min2 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                  where x.Name == nameof(Queryable.Min)
                                                  let args = x.GetGenericArguments()
                                                  where args.Length == 2
                                                  let pars = x.GetParameters()
                                                  where pars.Length == 2 &&
                                                      pars[0].ParameterType == typeof(IQueryable<>).MakeGenericType(args[0]) &&
                                                      pars[1].ParameterType == typeof(Expression<>).MakeGenericType(typeof(Func<,>).MakeGenericType(args[0], args[1]))
                                                  select x).Single();

        public static readonly MethodInfo OfType = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                    where x.Name == nameof(Queryable.OfType) &&
                                                        x.GetGenericArguments().Length == 1
                                                    let pars = x.GetParameters()
                                                    where pars.Length == 1 &&
                                                        pars[0].ParameterType == typeof(IQueryable)
                                                    select x).Single();

        public static readonly MethodInfo OrderBy1 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                      where x.Name == nameof(Queryable.OrderBy)
                                                      let args = x.GetGenericArguments()
                                                      where args.Length == 2
                                                      let pars = x.GetParameters()
                                                      where pars.Length == 2 &&
                                                          pars[0].ParameterType == typeof(IQueryable<>).MakeGenericType(args[0]) &&
                                                          pars[1].ParameterType == typeof(Expression<>).MakeGenericType(typeof(Func<,>).MakeGenericType(args[0], args[1]))
                                                      select x).Single();

        public static readonly MethodInfo OrderBy2 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                      where x.Name == nameof(Queryable.OrderBy)
                                                      let args = x.GetGenericArguments()
                                                      where args.Length == 2
                                                      let pars = x.GetParameters()
                                                      where pars.Length == 3 &&
                                                          pars[0].ParameterType == typeof(IQueryable<>).MakeGenericType(args[0]) &&
                                                          pars[1].ParameterType == typeof(Expression<>).MakeGenericType(typeof(Func<,>).MakeGenericType(args[0], args[1])) &&
                                                          pars[2].ParameterType == typeof(IComparer<>).MakeGenericType(args[1])
                                                      select x).Single();

        public static readonly MethodInfo OrderByDescending1 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                                where x.Name == nameof(Queryable.OrderByDescending)
                                                                let args = x.GetGenericArguments()
                                                                where args.Length == 2
                                                                let pars = x.GetParameters()
                                                                where pars.Length == 2 &&
                                                                    pars[0].ParameterType == typeof(IQueryable<>).MakeGenericType(args[0]) &&
                                                                    pars[1].ParameterType == typeof(Expression<>).MakeGenericType(typeof(Func<,>).MakeGenericType(args[0], args[1]))
                                                                select x).Single();

        public static readonly MethodInfo OrderByDescending2 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                                where x.Name == nameof(Queryable.OrderByDescending)
                                                                let args = x.GetGenericArguments()
                                                                where args.Length == 2
                                                                let pars = x.GetParameters()
                                                                where pars.Length == 3 &&
                                                                    pars[0].ParameterType == typeof(IQueryable<>).MakeGenericType(args[0]) &&
                                                                    pars[1].ParameterType == typeof(Expression<>).MakeGenericType(typeof(Func<,>).MakeGenericType(args[0], args[1])) &&
                                                                    pars[2].ParameterType == typeof(IComparer<>).MakeGenericType(args[1])
                                                                select x).Single();

        public static readonly MethodInfo Reverse = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                     where x.Name == nameof(Queryable.Reverse)
                                                     let args = x.GetGenericArguments()
                                                     where args.Length == 1
                                                     let pars = x.GetParameters()
                                                     where pars.Length == 1 &&
                                                         pars[0].ParameterType == typeof(IQueryable<>).MakeGenericType(args[0])
                                                     select x).Single();

        public static readonly MethodInfo Select1 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                     where x.Name == nameof(Queryable.Select)
                                                     let args = x.GetGenericArguments()
                                                     where args.Length == 2
                                                     let pars = x.GetParameters()
                                                     where pars.Length == 2 &&
                                                         pars[0].ParameterType == typeof(IQueryable<>).MakeGenericType(args[0]) &&
                                                         pars[1].ParameterType == typeof(Expression<>).MakeGenericType(typeof(Func<,>).MakeGenericType(args[0], args[1]))
                                                     select x).Single();

        public static readonly MethodInfo Select2 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                     where x.Name == nameof(Queryable.Select)
                                                     let args = x.GetGenericArguments()
                                                     where args.Length == 2
                                                     let pars = x.GetParameters()
                                                     where pars.Length == 2 &&
                                                         pars[0].ParameterType == typeof(IQueryable<>).MakeGenericType(args[0]) &&
                                                         pars[1].ParameterType == typeof(Expression<>).MakeGenericType(typeof(Func<,,>).MakeGenericType(args[0], typeof(int), args[1]))
                                                     select x).Single();

        public static readonly MethodInfo SelectMany1 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                         where x.Name == nameof(Queryable.SelectMany)
                                                         let args = x.GetGenericArguments()
                                                         where args.Length == 2
                                                         let pars = x.GetParameters()
                                                         where pars.Length == 2 &&
                                                             pars[0].ParameterType == typeof(IQueryable<>).MakeGenericType(args[0]) &&
                                                             pars[1].ParameterType == typeof(Expression<>).MakeGenericType(typeof(Func<,>).MakeGenericType(args[0], typeof(IEnumerable<>).MakeGenericType(args[1])))
                                                         select x).Single();

        public static readonly MethodInfo SelectMany2 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                         where x.Name == nameof(Queryable.SelectMany)
                                                         let args = x.GetGenericArguments()
                                                         where args.Length == 2
                                                         let pars = x.GetParameters()
                                                         where pars.Length == 2 &&
                                                             pars[0].ParameterType == typeof(IQueryable<>).MakeGenericType(args[0]) &&
                                                             pars[1].ParameterType == typeof(Expression<>).MakeGenericType(typeof(Func<,,>).MakeGenericType(args[0], typeof(int), typeof(IEnumerable<>).MakeGenericType(args[1])))
                                                         select x).Single();

        public static readonly MethodInfo SelectMany3 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                         where x.Name == nameof(Queryable.SelectMany)
                                                         let args = x.GetGenericArguments()
                                                         where args.Length == 3
                                                         let pars = x.GetParameters()
                                                         where pars.Length == 3 &&
                                                             pars[0].ParameterType == typeof(IQueryable<>).MakeGenericType(args[0]) &&
                                                             pars[1].ParameterType == typeof(Expression<>).MakeGenericType(typeof(Func<,,>).MakeGenericType(args[0], typeof(int), typeof(IEnumerable<>).MakeGenericType(args[1]))) &&
                                                             pars[2].ParameterType == typeof(Expression<>).MakeGenericType(typeof(Func<,,>).MakeGenericType(args[0], args[1], args[2]))
                                                         select x).Single();

        public static readonly MethodInfo SelectMany4 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                         where x.Name == nameof(Queryable.SelectMany)
                                                         let args = x.GetGenericArguments()
                                                         where args.Length == 3
                                                         let pars = x.GetParameters()
                                                         where pars.Length == 3 &&
                                                             pars[0].ParameterType == typeof(IQueryable<>).MakeGenericType(args[0]) &&
                                                             pars[1].ParameterType == typeof(Expression<>).MakeGenericType(typeof(Func<,>).MakeGenericType(args[0], typeof(IEnumerable<>).MakeGenericType(args[1]))) &&
                                                             pars[2].ParameterType == typeof(Expression<>).MakeGenericType(typeof(Func<,,>).MakeGenericType(args[0], args[1], args[2]))
                                                         select x).Single();

        public static readonly MethodInfo SequenceEqual1 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                            where x.Name == nameof(Queryable.SequenceEqual)
                                                            let args = x.GetGenericArguments()
                                                            where args.Length == 1
                                                            let pars = x.GetParameters()
                                                            where pars.Length == 2 &&
                                                                pars[0].ParameterType == typeof(IQueryable<>).MakeGenericType(args[0]) &&
                                                                pars[1].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0])
                                                            select x).Single();

        public static readonly MethodInfo SequenceEqual2 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                            where x.Name == nameof(Queryable.SequenceEqual)
                                                            let args = x.GetGenericArguments()
                                                            where args.Length == 1
                                                            let pars = x.GetParameters()
                                                            where pars.Length == 3 &&
                                                                pars[0].ParameterType == typeof(IQueryable<>).MakeGenericType(args[0]) &&
                                                                pars[1].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                                pars[2].ParameterType == typeof(IEqualityComparer<>).MakeGenericType(args[0])
                                                            select x).Single();

        public static readonly MethodInfo Single1 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                     where x.Name == nameof(Queryable.Single)
                                                     let args = x.GetGenericArguments()
                                                     where args.Length == 1
                                                     let pars = x.GetParameters()
                                                     where pars.Length == 1 &&
                                                         pars[0].ParameterType == typeof(IQueryable<>).MakeGenericType(args[0])
                                                     select x).Single();

        public static readonly MethodInfo Single2 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                     where x.Name == nameof(Queryable.Single)
                                                     let args = x.GetGenericArguments()
                                                     where args.Length == 1
                                                     let pars = x.GetParameters()
                                                     where pars.Length == 2 &&
                                                         pars[0].ParameterType == typeof(IQueryable<>).MakeGenericType(args[0]) &&
                                                         pars[1].ParameterType == typeof(Expression<>).MakeGenericType(typeof(Func<,>).MakeGenericType(args[0], typeof(bool)))
                                                     select x).Single();

        public static readonly MethodInfo SingleOrDefault1 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                              where x.Name == nameof(Queryable.SingleOrDefault)
                                                              let args = x.GetGenericArguments()
                                                              where args.Length == 1
                                                              let pars = x.GetParameters()
                                                              where pars.Length == 1 &&
                                                                  pars[0].ParameterType == typeof(IQueryable<>).MakeGenericType(args[0])
                                                              select x).Single();

        public static readonly MethodInfo SingleOrDefault2 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                              where x.Name == nameof(Queryable.SingleOrDefault)
                                                              let args = x.GetGenericArguments()
                                                              where args.Length == 1
                                                              let pars = x.GetParameters()
                                                              where pars.Length == 2 &&
                                                                  pars[0].ParameterType == typeof(IQueryable<>).MakeGenericType(args[0]) &&
                                                                  pars[1].ParameterType == typeof(Expression<>).MakeGenericType(typeof(Func<,>).MakeGenericType(args[0], typeof(bool)))
                                                              select x).Single();

        public static readonly MethodInfo Skip = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                  where x.Name == nameof(Queryable.Skip)
                                                  let args = x.GetGenericArguments()
                                                  where args.Length == 1
                                                  let pars = x.GetParameters()
                                                  where pars.Length == 2 &&
                                                      pars[0].ParameterType == typeof(IQueryable<>).MakeGenericType(args[0]) &&
                                                      pars[1].ParameterType == typeof(int)
                                                  select x).Single();

        public static readonly MethodInfo SkipWhile1 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                        where x.Name == nameof(Queryable.SkipWhile)
                                                        let args = x.GetGenericArguments()
                                                        where args.Length == 1
                                                        let pars = x.GetParameters()
                                                        where pars.Length == 2 &&
                                                            pars[0].ParameterType == typeof(IQueryable<>).MakeGenericType(args[0]) &&
                                                            pars[1].ParameterType == typeof(Expression<>).MakeGenericType(typeof(Func<,>).MakeGenericType(args[0], typeof(bool)))
                                                        select x).Single();

        public static readonly MethodInfo SkipWhile2 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                        where x.Name == nameof(Queryable.SkipWhile)
                                                        let args = x.GetGenericArguments()
                                                        where args.Length == 1
                                                        let pars = x.GetParameters()
                                                        where pars.Length == 2 &&
                                                            pars[0].ParameterType == typeof(IQueryable<>).MakeGenericType(args[0]) &&
                                                            pars[1].ParameterType == typeof(Expression<>).MakeGenericType(typeof(Func<,,>).MakeGenericType(args[0], typeof(int), typeof(bool)))
                                                        select x).Single();

        public static readonly MethodInfo Sum1 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                  where x.Name == nameof(Queryable.Sum) &&
                                                      x.GetGenericArguments().Length == 0
                                                  let pars = x.GetParameters()
                                                  where pars.Length == 1 &&
                                                      pars[0].ParameterType == typeof(IQueryable<int>)
                                                  select x).Single();

        public static readonly MethodInfo Sum2 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                  where x.Name == nameof(Queryable.Sum) &&
                                                      x.GetGenericArguments().Length == 0
                                                  let pars = x.GetParameters()
                                                  where pars.Length == 1 &&
                                                      pars[0].ParameterType == typeof(IQueryable<int?>)
                                                  select x).Single();

        public static readonly MethodInfo Sum3 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                  where x.Name == nameof(Queryable.Sum) &&
                                                      x.GetGenericArguments().Length == 0
                                                  let pars = x.GetParameters()
                                                  where pars.Length == 1 &&
                                                      pars[0].ParameterType == typeof(IQueryable<long>)
                                                  select x).Single();

        public static readonly MethodInfo Sum4 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                  where x.Name == nameof(Queryable.Sum) &&
                                                      x.GetGenericArguments().Length == 0
                                                  let pars = x.GetParameters()
                                                  where pars.Length == 1 &&
                                                      pars[0].ParameterType == typeof(IQueryable<long?>)
                                                  select x).Single();

        public static readonly MethodInfo Sum5 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                  where x.Name == nameof(Queryable.Sum) &&
                                                      x.GetGenericArguments().Length == 0
                                                  let pars = x.GetParameters()
                                                  where pars.Length == 1 &&
                                                      pars[0].ParameterType == typeof(IQueryable<float>)
                                                  select x).Single();

        public static readonly MethodInfo Sum6 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                  where x.Name == nameof(Queryable.Sum) &&
                                                      x.GetGenericArguments().Length == 0
                                                  let pars = x.GetParameters()
                                                  where pars.Length == 1 &&
                                                      pars[0].ParameterType == typeof(IQueryable<float?>)
                                                  select x).Single();

        public static readonly MethodInfo Sum7 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                  where x.Name == nameof(Queryable.Sum) &&
                                                      x.GetGenericArguments().Length == 0
                                                  let pars = x.GetParameters()
                                                  where pars.Length == 1 &&
                                                      pars[0].ParameterType == typeof(IQueryable<double>)
                                                  select x).Single();

        public static readonly MethodInfo Sum8 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                  where x.Name == nameof(Queryable.Sum) &&
                                                      x.GetGenericArguments().Length == 0
                                                  let pars = x.GetParameters()
                                                  where pars.Length == 1 &&
                                                      pars[0].ParameterType == typeof(IQueryable<double?>)
                                                  select x).Single();

        public static readonly MethodInfo Sum9 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                  where x.Name == nameof(Queryable.Sum) &&
                                                      x.GetGenericArguments().Length == 0
                                                  let pars = x.GetParameters()
                                                  where pars.Length == 1 &&
                                                      pars[0].ParameterType == typeof(IQueryable<decimal>)
                                                  select x).Single();

        public static readonly MethodInfo Sum10 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                   where x.Name == nameof(Queryable.Sum) &&
                                                       x.GetGenericArguments().Length == 0
                                                   let pars = x.GetParameters()
                                                   where pars.Length == 1 &&
                                                       pars[0].ParameterType == typeof(IQueryable<decimal?>)
                                                   select x).Single();

        public static readonly MethodInfo Sum11 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                   where x.Name == nameof(Queryable.Sum)
                                                   let args = x.GetGenericArguments()
                                                   where args.Length == 1
                                                   let pars = x.GetParameters()
                                                   where pars.Length == 2 &&
                                                       pars[0].ParameterType == typeof(IQueryable<>).MakeGenericType(args[0]) &&
                                                       pars[1].ParameterType == typeof(Expression<>).MakeGenericType(typeof(Func<,>).MakeGenericType(args[0], typeof(decimal?)))
                                                   select x).Single();

        public static readonly MethodInfo Sum12 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                   where x.Name == nameof(Queryable.Sum)
                                                   let args = x.GetGenericArguments()
                                                   where args.Length == 1
                                                   let pars = x.GetParameters()
                                                   where pars.Length == 2 &&
                                                       pars[0].ParameterType == typeof(IQueryable<>).MakeGenericType(args[0]) &&
                                                       pars[1].ParameterType == typeof(Expression<>).MakeGenericType(typeof(Func<,>).MakeGenericType(args[0], typeof(int)))
                                                   select x).Single();

        public static readonly MethodInfo Sum13 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                   where x.Name == nameof(Queryable.Sum)
                                                   let args = x.GetGenericArguments()
                                                   where args.Length == 1
                                                   let pars = x.GetParameters()
                                                   where pars.Length == 2 &&
                                                       pars[0].ParameterType == typeof(IQueryable<>).MakeGenericType(args[0]) &&
                                                       pars[1].ParameterType == typeof(Expression<>).MakeGenericType(typeof(Func<,>).MakeGenericType(args[0], typeof(int?)))
                                                   select x).Single();

        public static readonly MethodInfo Sum14 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                   where x.Name == nameof(Queryable.Sum)
                                                   let args = x.GetGenericArguments()
                                                   where args.Length == 1
                                                   let pars = x.GetParameters()
                                                   where pars.Length == 2 &&
                                                       pars[0].ParameterType == typeof(IQueryable<>).MakeGenericType(args[0]) &&
                                                       pars[1].ParameterType == typeof(Expression<>).MakeGenericType(typeof(Func<,>).MakeGenericType(args[0], typeof(long)))
                                                   select x).Single();

        public static readonly MethodInfo Sum15 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                   where x.Name == nameof(Queryable.Sum)
                                                   let args = x.GetGenericArguments()
                                                   where args.Length == 1
                                                   let pars = x.GetParameters()
                                                   where pars.Length == 2 &&
                                                       pars[0].ParameterType == typeof(IQueryable<>).MakeGenericType(args[0]) &&
                                                       pars[1].ParameterType == typeof(Expression<>).MakeGenericType(typeof(Func<,>).MakeGenericType(args[0], typeof(long?)))
                                                   select x).Single();

        public static readonly MethodInfo Sum16 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                   where x.Name == nameof(Queryable.Sum)
                                                   let args = x.GetGenericArguments()
                                                   where args.Length == 1
                                                   let pars = x.GetParameters()
                                                   where pars.Length == 2 &&
                                                       pars[0].ParameterType == typeof(IQueryable<>).MakeGenericType(args[0]) &&
                                                       pars[1].ParameterType == typeof(Expression<>).MakeGenericType(typeof(Func<,>).MakeGenericType(args[0], typeof(float)))
                                                   select x).Single();

        public static readonly MethodInfo Sum17 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                   where x.Name == nameof(Queryable.Sum)
                                                   let args = x.GetGenericArguments()
                                                   where args.Length == 1
                                                   let pars = x.GetParameters()
                                                   where pars.Length == 2 &&
                                                       pars[0].ParameterType == typeof(IQueryable<>).MakeGenericType(args[0]) &&
                                                       pars[1].ParameterType == typeof(Expression<>).MakeGenericType(typeof(Func<,>).MakeGenericType(args[0], typeof(float?)))
                                                   select x).Single();

        public static readonly MethodInfo Sum18 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                   where x.Name == nameof(Queryable.Sum)
                                                   let args = x.GetGenericArguments()
                                                   where args.Length == 1
                                                   let pars = x.GetParameters()
                                                   where pars.Length == 2 &&
                                                       pars[0].ParameterType == typeof(IQueryable<>).MakeGenericType(args[0]) &&
                                                       pars[1].ParameterType == typeof(Expression<>).MakeGenericType(typeof(Func<,>).MakeGenericType(args[0], typeof(double)))
                                                   select x).Single();

        public static readonly MethodInfo Sum19 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                   where x.Name == nameof(Queryable.Sum)
                                                   let args = x.GetGenericArguments()
                                                   where args.Length == 1
                                                   let pars = x.GetParameters()
                                                   where pars.Length == 2 &&
                                                       pars[0].ParameterType == typeof(IQueryable<>).MakeGenericType(args[0]) &&
                                                       pars[1].ParameterType == typeof(Expression<>).MakeGenericType(typeof(Func<,>).MakeGenericType(args[0], typeof(double?)))
                                                   select x).Single();

        public static readonly MethodInfo Sum20 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                   where x.Name == nameof(Queryable.Sum)
                                                   let args = x.GetGenericArguments()
                                                   where args.Length == 1
                                                   let pars = x.GetParameters()
                                                   where pars.Length == 2 &&
                                                       pars[0].ParameterType == typeof(IQueryable<>).MakeGenericType(args[0]) &&
                                                       pars[1].ParameterType == typeof(Expression<>).MakeGenericType(typeof(Func<,>).MakeGenericType(args[0], typeof(decimal)))
                                                   select x).Single();

        public static readonly MethodInfo Take = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                  where x.Name == nameof(Queryable.Take)
                                                  let args = x.GetGenericArguments()
                                                  where args.Length == 1
                                                  let pars = x.GetParameters()
                                                  where pars.Length == 2 &&
                                                      pars[0].ParameterType == typeof(IQueryable<>).MakeGenericType(args[0]) &&
                                                      pars[1].ParameterType == typeof(int)
                                                  select x).Single();

        public static readonly MethodInfo TakeWhile1 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                        where x.Name == nameof(Queryable.TakeWhile)
                                                        let args = x.GetGenericArguments()
                                                        where args.Length == 1
                                                        let pars = x.GetParameters()
                                                        where pars.Length == 2 &&
                                                            pars[0].ParameterType == typeof(IQueryable<>).MakeGenericType(args[0]) &&
                                                            pars[1].ParameterType == typeof(Expression<>).MakeGenericType(typeof(Func<,>).MakeGenericType(args[0], typeof(bool)))
                                                        select x).Single();

        public static readonly MethodInfo TakeWhile2 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                        where x.Name == nameof(Queryable.TakeWhile)
                                                        let args = x.GetGenericArguments()
                                                        where args.Length == 1
                                                        let pars = x.GetParameters()
                                                        where pars.Length == 2 &&
                                                            pars[0].ParameterType == typeof(IQueryable<>).MakeGenericType(args[0]) &&
                                                            pars[1].ParameterType == typeof(Expression<>).MakeGenericType(typeof(Func<,,>).MakeGenericType(args[0], typeof(int), typeof(bool)))
                                                        select x).Single();

        public static readonly MethodInfo ThenBy1 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                     where x.Name == nameof(Queryable.ThenBy)
                                                     let args = x.GetGenericArguments()
                                                     where args.Length == 2
                                                     let pars = x.GetParameters()
                                                     where pars.Length == 2 &&
                                                         pars[0].ParameterType == typeof(IOrderedQueryable<>).MakeGenericType(args[0]) &&
                                                         pars[1].ParameterType == typeof(Expression<>).MakeGenericType(typeof(Func<,>).MakeGenericType(args[0], args[1]))
                                                     select x).Single();

        public static readonly MethodInfo ThenBy2 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                     where x.Name == nameof(Queryable.ThenBy)
                                                     let args = x.GetGenericArguments()
                                                     where args.Length == 2
                                                     let pars = x.GetParameters()
                                                     where pars.Length == 3 &&
                                                         pars[0].ParameterType == typeof(IOrderedQueryable<>).MakeGenericType(args[0]) &&
                                                         pars[1].ParameterType == typeof(Expression<>).MakeGenericType(typeof(Func<,>).MakeGenericType(args[0], args[1])) &&
                                                         pars[2].ParameterType == typeof(IComparer<>).MakeGenericType(args[1])
                                                     select x).Single();

        public static readonly MethodInfo ThenByDescending1 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                               where x.Name == nameof(Queryable.ThenByDescending)
                                                               let args = x.GetGenericArguments()
                                                               where args.Length == 2
                                                               let pars = x.GetParameters()
                                                               where pars.Length == 2 &&
                                                                   pars[0].ParameterType == typeof(IOrderedQueryable<>).MakeGenericType(args[0]) &&
                                                                   pars[1].ParameterType == typeof(Expression<>).MakeGenericType(typeof(Func<,>).MakeGenericType(args[0], args[1]))
                                                               select x).Single();

        public static readonly MethodInfo ThenByDescending2 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                               where x.Name == nameof(Queryable.ThenByDescending)
                                                               let args = x.GetGenericArguments()
                                                               where args.Length == 2
                                                               let pars = x.GetParameters()
                                                               where pars.Length == 3 &&
                                                                   pars[0].ParameterType == typeof(IOrderedQueryable<>).MakeGenericType(args[0]) &&
                                                                   pars[1].ParameterType == typeof(Expression<>).MakeGenericType(typeof(Func<,>).MakeGenericType(args[0], args[1])) &&
                                                                   pars[2].ParameterType == typeof(IComparer<>).MakeGenericType(args[1])
                                                               select x).Single();

        public static readonly MethodInfo Union1 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                    where x.Name == nameof(Queryable.Union)
                                                    let args = x.GetGenericArguments()
                                                    where args.Length == 1
                                                    let pars = x.GetParameters()
                                                    where pars.Length == 2 &&
                                                        pars[0].ParameterType == typeof(IQueryable<>).MakeGenericType(args[0]) &&
                                                        pars[1].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0])
                                                    select x).Single();

        public static readonly MethodInfo Union2 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                    where x.Name == nameof(Queryable.Union)
                                                    let args = x.GetGenericArguments()
                                                    where args.Length == 1
                                                    let pars = x.GetParameters()
                                                    where pars.Length == 3 &&
                                                        pars[0].ParameterType == typeof(IQueryable<>).MakeGenericType(args[0]) &&
                                                        pars[1].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                        pars[2].ParameterType == typeof(IEqualityComparer<>).MakeGenericType(args[0])
                                                    select x).Single();

        public static readonly MethodInfo Where1 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                    where x.Name == nameof(Queryable.Where)
                                                    let args = x.GetGenericArguments()
                                                    where args.Length == 1
                                                    let pars = x.GetParameters()
                                                    where pars.Length == 2 &&
                                                        pars[0].ParameterType == typeof(IQueryable<>).MakeGenericType(args[0]) &&
                                                        pars[1].ParameterType == typeof(Expression<>).MakeGenericType(typeof(Func<,>).MakeGenericType(args[0], typeof(bool)))
                                                    select x).Single();

        public static readonly MethodInfo Where2 = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                    where x.Name == nameof(Queryable.Where)
                                                    let args = x.GetGenericArguments()
                                                    where args.Length == 1
                                                    let pars = x.GetParameters()
                                                    where pars.Length == 2 &&
                                                        pars[0].ParameterType == typeof(IQueryable<>).MakeGenericType(args[0]) &&
                                                        pars[1].ParameterType == typeof(Expression<>).MakeGenericType(typeof(Func<,,>).MakeGenericType(args[0], typeof(int), typeof(bool)))
                                                    select x).Single();

        public static readonly MethodInfo Zip = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                 where x.Name == nameof(Queryable.Zip)
                                                 let args = x.GetGenericArguments()
                                                 where args.Length == 3
                                                 let pars = x.GetParameters()
                                                 where pars.Length == 3 &&
                                                     pars[0].ParameterType == typeof(IQueryable<>).MakeGenericType(args[0]) &&
                                                     pars[1].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[1]) &&
                                                     pars[2].ParameterType == typeof(Expression<>).MakeGenericType(typeof(Func<,,>).MakeGenericType(args[0], args[1], args[2]))
                                                 select x).Single();
    }
}
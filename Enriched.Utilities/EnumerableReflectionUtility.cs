using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Enriched.Utilities
{
    public static class EnumerableReflectionUtility
    {
        public static readonly MethodInfo Aggregate1 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                        where x.Name == nameof(Enumerable.Aggregate)
                                                        let args = x.GetGenericArguments()
                                                        where args.Length == 1
                                                        let pars = x.GetParameters()
                                                        where pars.Length == 2 &&
                                                            pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                            pars[1].ParameterType == typeof(Func<,,>).MakeGenericType(args[0], args[0], args[0])
                                                        select x).Single();

        public static readonly MethodInfo Aggregate2 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                        where x.Name == nameof(Enumerable.Aggregate)
                                                        let args = x.GetGenericArguments()
                                                        where args.Length == 2
                                                        let pars = x.GetParameters()
                                                        where pars.Length == 3 &&
                                                            pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                            pars[1].ParameterType == args[1] &&
                                                            pars[2].ParameterType == typeof(Func<,,>).MakeGenericType(args[1], args[0], args[1])
                                                        select x).Single();

        public static readonly MethodInfo Aggregate3 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                        where x.Name == nameof(Enumerable.Aggregate)
                                                        let args = x.GetGenericArguments()
                                                        where args.Length == 3
                                                        let pars = x.GetParameters()
                                                        where pars.Length == 4 &&
                                                            pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                            pars[1].ParameterType == args[1] &&
                                                            pars[2].ParameterType == typeof(Func<,,>).MakeGenericType(args[1], args[0], args[1]) &&
                                                            pars[3].ParameterType == typeof(Func<,>).MakeGenericType(args[1], args[2])
                                                        select x).Single();

        public static readonly MethodInfo All = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                 where x.Name == nameof(Enumerable.All)
                                                 let args = x.GetGenericArguments()
                                                 where args.Length == 1
                                                 let pars = x.GetParameters()
                                                 where pars.Length == 2 &&
                                                     pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                     pars[1].ParameterType == typeof(Func<,>).MakeGenericType(args[0], typeof(bool))
                                                 select x).Single();

        public static readonly MethodInfo Any1 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                  where x.Name == nameof(Enumerable.Any)
                                                  let args = x.GetGenericArguments()
                                                  where args.Length == 1
                                                  let pars = x.GetParameters()
                                                  where pars.Length == 1 &&
                                                      pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0])
                                                  select x).Single();

        public static readonly MethodInfo Any2 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                  where x.Name == nameof(Enumerable.Any)
                                                  let args = x.GetGenericArguments()
                                                  where args.Length == 1
                                                  let pars = x.GetParameters()
                                                  where pars.Length == 2 &&
                                                      pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                      pars[1].ParameterType == typeof(Func<,>).MakeGenericType(args[0], typeof(bool))
                                                  select x).Single();

        public static readonly MethodInfo Append = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                    where x.Name == nameof(Enumerable.Append)
                                                    let args = x.GetGenericArguments()
                                                    where args.Length == 1
                                                    let pars = x.GetParameters()
                                                    where pars.Length == 2 &&
                                                        pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                        pars[1].ParameterType == args[0]
                                                    select x).Single();

        public static readonly MethodInfo AsEnumerable = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                          where x.Name == nameof(Enumerable.AsEnumerable)
                                                          let args = x.GetGenericArguments()
                                                          where args.Length == 1
                                                          let pars = x.GetParameters()
                                                          where pars.Length == 1 &&
                                                              pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0])
                                                          select x).Single();

        public static readonly MethodInfo Average1 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                      where x.Name == nameof(Enumerable.Average) &&
                                                          x.GetGenericArguments().Length == 0
                                                      let pars = x.GetParameters()
                                                      where pars.Length == 1 &&
                                                          pars[0].ParameterType == typeof(IEnumerable<int>)
                                                      select x).Single();

        public static readonly MethodInfo Average2 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                      where x.Name == nameof(Enumerable.Average) &&
                                                          x.GetGenericArguments().Length == 0
                                                      let pars = x.GetParameters()
                                                      where pars.Length == 1 &&
                                                          pars[0].ParameterType == typeof(IEnumerable<int?>)
                                                      select x).Single();

        public static readonly MethodInfo Average3 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                      where x.Name == nameof(Enumerable.Average) &&
                                                          x.GetGenericArguments().Length == 0
                                                      let pars = x.GetParameters()
                                                      where pars.Length == 1 &&
                                                          pars[0].ParameterType == typeof(IEnumerable<long>)
                                                      select x).Single();

        public static readonly MethodInfo Average4 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                      where x.Name == nameof(Enumerable.Average) &&
                                                          x.GetGenericArguments().Length == 0
                                                      let pars = x.GetParameters()
                                                      where pars.Length == 1 &&
                                                          pars[0].ParameterType == typeof(IEnumerable<long?>)
                                                      select x).Single();

        public static readonly MethodInfo Average5 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                      where x.Name == nameof(Enumerable.Average) &&
                                                          x.GetGenericArguments().Length == 0
                                                      let pars = x.GetParameters()
                                                      where pars.Length == 1 &&
                                                          pars[0].ParameterType == typeof(IEnumerable<float>)
                                                      select x).Single();

        public static readonly MethodInfo Average6 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                      where x.Name == nameof(Enumerable.Average) &&
                                                          x.GetGenericArguments().Length == 0
                                                      let pars = x.GetParameters()
                                                      where pars.Length == 1 &&
                                                          pars[0].ParameterType == typeof(IEnumerable<float?>)
                                                      select x).Single();

        public static readonly MethodInfo Average7 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                      where x.Name == nameof(Enumerable.Average) &&
                                                          x.GetGenericArguments().Length == 0
                                                      let pars = x.GetParameters()
                                                      where pars.Length == 1 &&
                                                          pars[0].ParameterType == typeof(IEnumerable<double>)
                                                      select x).Single();

        public static readonly MethodInfo Average8 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                      where x.Name == nameof(Enumerable.Average) &&
                                                          x.GetGenericArguments().Length == 0
                                                      let pars = x.GetParameters()
                                                      where pars.Length == 1 &&
                                                          pars[0].ParameterType == typeof(IEnumerable<double?>)
                                                      select x).Single();

        public static readonly MethodInfo Average9 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                      where x.Name == nameof(Enumerable.Average) &&
                                                          x.GetGenericArguments().Length == 0
                                                      let pars = x.GetParameters()
                                                      where pars.Length == 1 &&
                                                          pars[0].ParameterType == typeof(IEnumerable<decimal>)
                                                      select x).Single();

        public static readonly MethodInfo Average10 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                       where x.Name == nameof(Enumerable.Average) &&
                                                           x.GetGenericArguments().Length == 0
                                                       let pars = x.GetParameters()
                                                       where pars.Length == 1 &&
                                                           pars[0].ParameterType == typeof(IEnumerable<decimal?>)
                                                       select x).Single();

        public static readonly MethodInfo Average11 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                       where x.Name == nameof(Enumerable.Average)
                                                       let args = x.GetGenericArguments()
                                                       where args.Length == 1
                                                       let pars = x.GetParameters()
                                                       where pars.Length == 2 &&
                                                           pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                           pars[1].ParameterType == typeof(Func<,>).MakeGenericType(args[0], typeof(int))
                                                       select x).Single();

        public static readonly MethodInfo Average12 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                       where x.Name == nameof(Enumerable.Average)
                                                       let args = x.GetGenericArguments()
                                                       where args.Length == 1
                                                       let pars = x.GetParameters()
                                                       where pars.Length == 2 &&
                                                           pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                           pars[1].ParameterType == typeof(Func<,>).MakeGenericType(args[0], typeof(int?))
                                                       select x).Single();

        public static readonly MethodInfo Average13 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                       where x.Name == nameof(Enumerable.Average)
                                                       let args = x.GetGenericArguments()
                                                       where args.Length == 1
                                                       let pars = x.GetParameters()
                                                       where pars.Length == 2 &&
                                                           pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                           pars[1].ParameterType == typeof(Func<,>).MakeGenericType(args[0], typeof(long))
                                                       select x).Single();

        public static readonly MethodInfo Average14 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                       where x.Name == nameof(Enumerable.Average)
                                                       let args = x.GetGenericArguments()
                                                       where args.Length == 1
                                                       let pars = x.GetParameters()
                                                       where pars.Length == 2 &&
                                                           pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                           pars[1].ParameterType == typeof(Func<,>).MakeGenericType(args[0], typeof(long?))
                                                       select x).Single();

        public static readonly MethodInfo Average15 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                       where x.Name == nameof(Enumerable.Average)
                                                       let args = x.GetGenericArguments()
                                                       where args.Length == 1
                                                       let pars = x.GetParameters()
                                                       where pars.Length == 2 &&
                                                           pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                           pars[1].ParameterType == typeof(Func<,>).MakeGenericType(args[0], typeof(float))
                                                       select x).Single();

        public static readonly MethodInfo Average16 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                       where x.Name == nameof(Enumerable.Average)
                                                       let args = x.GetGenericArguments()
                                                       where args.Length == 1
                                                       let pars = x.GetParameters()
                                                       where pars.Length == 2 &&
                                                           pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                           pars[1].ParameterType == typeof(Func<,>).MakeGenericType(args[0], typeof(float?))
                                                       select x).Single();

        public static readonly MethodInfo Average17 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                       where x.Name == nameof(Enumerable.Average)
                                                       let args = x.GetGenericArguments()
                                                       where args.Length == 1
                                                       let pars = x.GetParameters()
                                                       where pars.Length == 2 &&
                                                           pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                           pars[1].ParameterType == typeof(Func<,>).MakeGenericType(args[0], typeof(double))
                                                       select x).Single();

        public static readonly MethodInfo Average18 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                       where x.Name == nameof(Enumerable.Average)
                                                       let args = x.GetGenericArguments()
                                                       where args.Length == 1
                                                       let pars = x.GetParameters()
                                                       where pars.Length == 2 &&
                                                           pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                           pars[1].ParameterType == typeof(Func<,>).MakeGenericType(args[0], typeof(double?))
                                                       select x).Single();

        public static readonly MethodInfo Average19 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                       where x.Name == nameof(Enumerable.Average)
                                                       let args = x.GetGenericArguments()
                                                       where args.Length == 1
                                                       let pars = x.GetParameters()
                                                       where pars.Length == 2 &&
                                                           pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                           pars[1].ParameterType == typeof(Func<,>).MakeGenericType(args[0], typeof(decimal))
                                                       select x).Single();

        public static readonly MethodInfo Average20 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                       where x.Name == nameof(Enumerable.Average)
                                                       let args = x.GetGenericArguments()
                                                       where args.Length == 1
                                                       let pars = x.GetParameters()
                                                       where pars.Length == 2 &&
                                                           pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                           pars[1].ParameterType == typeof(Func<,>).MakeGenericType(args[0], typeof(decimal?))
                                                       select x).Single();

        public static readonly MethodInfo Cast = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                  where x.Name == nameof(Enumerable.Cast) &&
                                                      x.GetGenericArguments().Length == 1
                                                  let pars = x.GetParameters()
                                                  where pars.Length == 1 &&
                                                      pars[0].ParameterType == typeof(System.Collections.IEnumerable)
                                                  select x).Single();

        public static readonly MethodInfo Concat = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                    where x.Name == nameof(Enumerable.Concat)
                                                    let args = x.GetGenericArguments()
                                                    where args.Length == 1
                                                    let pars = x.GetParameters()
                                                    where pars.Length == 2 &&
                                                        pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                        pars[1].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0])
                                                    select x).Single();

        public static readonly MethodInfo Contains1 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                       where x.Name == nameof(Enumerable.Contains)
                                                       let args = x.GetGenericArguments()
                                                       where args.Length == 1
                                                       let pars = x.GetParameters()
                                                       where pars.Length == 2 &&
                                                           pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                           pars[1].ParameterType == args[0]
                                                       select x).Single();

        public static readonly MethodInfo Contains2 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                       where x.Name == nameof(Enumerable.Contains)
                                                       let args = x.GetGenericArguments()
                                                       where args.Length == 1
                                                       let pars = x.GetParameters()
                                                       where pars.Length == 3 &&
                                                           pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                           pars[1].ParameterType == args[0] &&
                                                           pars[2].ParameterType == typeof(IEqualityComparer<>).MakeGenericType(args[0])
                                                       select x).Single();

        public static readonly MethodInfo Count1 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                    where x.Name == nameof(Enumerable.Count)
                                                    let args = x.GetGenericArguments()
                                                    where args.Length == 1
                                                    let pars = x.GetParameters()
                                                    where pars.Length == 1 &&
                                                        pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0])
                                                    select x).Single();

        public static readonly MethodInfo Count2 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                    where x.Name == nameof(Enumerable.Count)
                                                    let args = x.GetGenericArguments()
                                                    where args.Length == 1
                                                    let pars = x.GetParameters()
                                                    where pars.Length == 2 &&
                                                        pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                        pars[1].ParameterType == typeof(Func<,>).MakeGenericType(args[0], typeof(bool))
                                                    select x).Single();

        public static readonly MethodInfo DefaultIfEmpty1 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                             where x.Name == nameof(Enumerable.DefaultIfEmpty)
                                                             let args = x.GetGenericArguments()
                                                             where args.Length == 1
                                                             let pars = x.GetParameters()
                                                             where pars.Length == 1 &&
                                                                 pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0])
                                                             select x).Single();

        public static readonly MethodInfo DefaultIfEmpty2 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                             where x.Name == nameof(Enumerable.DefaultIfEmpty)
                                                             let args = x.GetGenericArguments()
                                                             where args.Length == 1
                                                             let pars = x.GetParameters()
                                                             where pars.Length == 2 &&
                                                                 pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                                 pars[1].ParameterType == args[0]
                                                             select x).Single();

        public static readonly MethodInfo Distinct1 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                       where x.Name == nameof(Enumerable.Distinct)
                                                       let args = x.GetGenericArguments()
                                                       where args.Length == 1
                                                       let pars = x.GetParameters()
                                                       where pars.Length == 1 &&
                                                           pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0])
                                                       select x).Single();

        public static readonly MethodInfo Distinct2 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                       where x.Name == nameof(Enumerable.Distinct)
                                                       let args = x.GetGenericArguments()
                                                       where args.Length == 1
                                                       let pars = x.GetParameters()
                                                       where pars.Length == 2 &&
                                                           pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                           pars[1].ParameterType == typeof(IEqualityComparer<>).MakeGenericType(args[0])
                                                       select x).Single();

        public static readonly MethodInfo ElementAt = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                       where x.Name == nameof(Enumerable.ElementAt)
                                                       let args = x.GetGenericArguments()
                                                       where args.Length == 1
                                                       let pars = x.GetParameters()
                                                       where pars.Length == 2 &&
                                                           pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                           pars[1].ParameterType == typeof(int)
                                                       select x).Single();

        public static readonly MethodInfo ElementAtOrDefault = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                                where x.Name == nameof(Enumerable.ElementAtOrDefault)
                                                                let args = x.GetGenericArguments()
                                                                where args.Length == 1
                                                                let pars = x.GetParameters()
                                                                where pars.Length == 2 &&
                                                                    pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                                    pars[1].ParameterType == typeof(int)
                                                                select x).Single();

        public static readonly MethodInfo Empty = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                   where x.Name == nameof(Enumerable.Empty) &&
                                                       x.GetGenericArguments().Length == 1 &&
                                                       x.GetParameters().Length == 0
                                                   select x).Single();

        public static readonly MethodInfo Except1 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                     where x.Name == nameof(Enumerable.Except)
                                                     let args = x.GetGenericArguments()
                                                     where args.Length == 1
                                                     let pars = x.GetParameters()
                                                     where pars.Length == 2 &&
                                                         pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                         pars[1].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0])
                                                     select x).Single();

        public static readonly MethodInfo Except2 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                     where x.Name == nameof(Enumerable.Except)
                                                     let args = x.GetGenericArguments()
                                                     where args.Length == 1
                                                     let pars = x.GetParameters()
                                                     where pars.Length == 3 &&
                                                         pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                         pars[1].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                         pars[2].ParameterType == typeof(IEqualityComparer<>).MakeGenericType(args[0])
                                                     select x).Single();

        public static readonly MethodInfo First1 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                    where x.Name == nameof(Enumerable.First)
                                                    let args = x.GetGenericArguments()
                                                    where args.Length == 1
                                                    let pars = x.GetParameters()
                                                    where pars.Length == 1 &&
                                                        pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0])
                                                    select x).Single();

        public static readonly MethodInfo First2 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                    where x.Name == nameof(Enumerable.First)
                                                    let args = x.GetGenericArguments()
                                                    where args.Length == 1
                                                    let pars = x.GetParameters()
                                                    where pars.Length == 2 &&
                                                        pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                        pars[1].ParameterType == typeof(Func<,>).MakeGenericType(args[0], typeof(bool))
                                                    select x).Single();

        public static readonly MethodInfo FirstOrDefault1 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                             where x.Name == nameof(Enumerable.FirstOrDefault)
                                                             let args = x.GetGenericArguments()
                                                             where args.Length == 1
                                                             let pars = x.GetParameters()
                                                             where pars.Length == 1 &&
                                                                 pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0])
                                                             select x).Single();

        public static readonly MethodInfo FirstOrDefault2 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                             where x.Name == nameof(Enumerable.FirstOrDefault)
                                                             let args = x.GetGenericArguments()
                                                             where args.Length == 1
                                                             let pars = x.GetParameters()
                                                             where pars.Length == 2 &&
                                                                 pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                                 pars[1].ParameterType == typeof(Func<,>).MakeGenericType(args[0], typeof(bool))
                                                             select x).Single();

        public static readonly MethodInfo GroupBy1 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                      where x.Name == nameof(Enumerable.GroupBy)
                                                      let args = x.GetGenericArguments()
                                                      where args.Length == 2
                                                      let pars = x.GetParameters()
                                                      where pars.Length == 2 &&
                                                          pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                          pars[1].ParameterType == typeof(Func<,>).MakeGenericType(args[0], args[1])
                                                      select x).Single();

        public static readonly MethodInfo GroupBy2 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                      where x.Name == nameof(Enumerable.GroupBy)
                                                      let args = x.GetGenericArguments()
                                                      where args.Length == 2
                                                      let pars = x.GetParameters()
                                                      where pars.Length == 3 &&
                                                          pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                          pars[1].ParameterType == typeof(Func<,>).MakeGenericType(args[0], args[1]) &&
                                                          pars[2].ParameterType == typeof(IEqualityComparer<>).MakeGenericType(args[1])
                                                      select x).Single();

        public static readonly MethodInfo GroupBy3 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                      where x.Name == nameof(Enumerable.GroupBy)
                                                      let args = x.GetGenericArguments()
                                                      where args.Length == 3
                                                      let pars = x.GetParameters()
                                                      where pars.Length == 3 &&
                                                          pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                          pars[1].ParameterType == typeof(Func<,>).MakeGenericType(args[0], args[1]) &&
                                                          pars[2].ParameterType == typeof(Func<,>).MakeGenericType(args[0], args[2])
                                                      select x).Single();

        public static readonly MethodInfo GroupBy4 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                      where x.Name == nameof(Enumerable.GroupBy)
                                                      let args = x.GetGenericArguments()
                                                      where args.Length == 3
                                                      let pars = x.GetParameters()
                                                      where pars.Length == 3 &&
                                                          pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                          pars[1].ParameterType == typeof(Func<,>).MakeGenericType(args[0], args[1]) &&
                                                          pars[2].ParameterType == typeof(Func<,,>).MakeGenericType(args[1], typeof(IEnumerable<>).MakeGenericType(args[0]), args[2])
                                                      select x).Single();

        public static readonly MethodInfo GroupBy5 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                      where x.Name == nameof(Enumerable.GroupBy)
                                                      let args = x.GetGenericArguments()
                                                      where args.Length == 3
                                                      let pars = x.GetParameters()
                                                      where pars.Length == 4 &&
                                                          pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                          pars[1].ParameterType == typeof(Func<,>).MakeGenericType(args[0], args[1]) &&
                                                          pars[2].ParameterType == typeof(Func<,>).MakeGenericType(args[0], args[2]) &&
                                                          pars[3].ParameterType == typeof(IEqualityComparer<>).MakeGenericType(args[1])
                                                      select x).Single();

        public static readonly MethodInfo GroupBy6 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                      where x.Name == nameof(Enumerable.GroupBy)
                                                      let args = x.GetGenericArguments()
                                                      where args.Length == 4
                                                      let pars = x.GetParameters()
                                                      where pars.Length == 4 &&
                                                          pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                          pars[1].ParameterType == typeof(Func<,>).MakeGenericType(args[0], args[1]) &&
                                                          pars[2].ParameterType == typeof(Func<,>).MakeGenericType(args[0], args[2]) &&
                                                          pars[3].ParameterType == typeof(Func<,,>).MakeGenericType(args[1], typeof(IEnumerable<>).MakeGenericType(args[2]), args[3])
                                                      select x).Single();

        public static readonly MethodInfo GroupBy7 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                      where x.Name == nameof(Enumerable.GroupBy)
                                                      let args = x.GetGenericArguments()
                                                      where args.Length == 3
                                                      let pars = x.GetParameters()
                                                      where pars.Length == 4 &&
                                                          pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                          pars[1].ParameterType == typeof(Func<,>).MakeGenericType(args[0], args[1]) &&
                                                          pars[2].ParameterType == typeof(Func<,,>).MakeGenericType(args[1], typeof(IEnumerable<>).MakeGenericType(args[0]), args[2]) &&
                                                          pars[3].ParameterType == typeof(IEqualityComparer<>).MakeGenericType(args[1])
                                                      select x).Single();

        public static readonly MethodInfo GroupBy8 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                      where x.Name == nameof(Enumerable.GroupBy)
                                                      let args = x.GetGenericArguments()
                                                      where args.Length == 4
                                                      let pars = x.GetParameters()
                                                      where pars.Length == 5 &&
                                                          pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                          pars[1].ParameterType == typeof(Func<,>).MakeGenericType(args[0], args[1]) &&
                                                          pars[2].ParameterType == typeof(Func<,>).MakeGenericType(args[0], args[2]) &&
                                                          pars[3].ParameterType == typeof(Func<,,>).MakeGenericType(args[1], typeof(IEnumerable<>).MakeGenericType(args[2]), args[3]) &&
                                                          pars[4].ParameterType == typeof(IEqualityComparer<>).MakeGenericType(args[1])
                                                      select x).Single();

        public static readonly MethodInfo GroupJoin1 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                        where x.Name == nameof(Enumerable.GroupJoin)
                                                        let args = x.GetGenericArguments()
                                                        where args.Length == 4
                                                        let pars = x.GetParameters()
                                                        where pars.Length == 5 &&
                                                            pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                            pars[1].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[1]) &&
                                                            pars[2].ParameterType == typeof(Func<,>).MakeGenericType(args[0], args[2]) &&
                                                            pars[3].ParameterType == typeof(Func<,>).MakeGenericType(args[1], args[2]) &&
                                                            pars[4].ParameterType == typeof(Func<,,>).MakeGenericType(args[0], typeof(IEnumerable<>).MakeGenericType(args[1]), args[3])
                                                        select x).Single();

        public static readonly MethodInfo GroupJoin2 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                        where x.Name == nameof(Enumerable.GroupJoin)
                                                        let args = x.GetGenericArguments()
                                                        where args.Length == 4
                                                        let pars = x.GetParameters()
                                                        where pars.Length == 6 &&
                                                            pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                            pars[1].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[1]) &&
                                                            pars[2].ParameterType == typeof(Func<,>).MakeGenericType(args[0], args[2]) &&
                                                            pars[3].ParameterType == typeof(Func<,>).MakeGenericType(args[1], args[2]) &&
                                                            pars[4].ParameterType == typeof(Func<,,>).MakeGenericType(args[0], typeof(IEnumerable<>).MakeGenericType(args[1]), args[3]) &&
                                                            pars[5].ParameterType == typeof(IEqualityComparer<>).MakeGenericType(args[2])
                                                        select x).Single();

        public static readonly MethodInfo Intersect1 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                        where x.Name == nameof(Enumerable.Intersect)
                                                        let args = x.GetGenericArguments()
                                                        where args.Length == 1
                                                        let pars = x.GetParameters()
                                                        where pars.Length == 2 &&
                                                            pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                            pars[1].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0])
                                                        select x).Single();

        public static readonly MethodInfo Intersect2 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                        where x.Name == nameof(Enumerable.Intersect)
                                                        let args = x.GetGenericArguments()
                                                        where args.Length == 1
                                                        let pars = x.GetParameters()
                                                        where pars.Length == 3 &&
                                                            pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                            pars[1].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                            pars[2].ParameterType == typeof(IEqualityComparer<>).MakeGenericType(args[0])
                                                        select x).Single();

        public static readonly MethodInfo Join1 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                   where x.Name == nameof(Enumerable.Join)
                                                   let args = x.GetGenericArguments()
                                                   where args.Length == 4
                                                   let pars = x.GetParameters()
                                                   where pars.Length == 5 &&
                                                       pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                       pars[1].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[1]) &&
                                                       pars[2].ParameterType == typeof(Func<,>).MakeGenericType(args[0], args[2]) &&
                                                       pars[3].ParameterType == typeof(Func<,>).MakeGenericType(args[1], args[2]) &&
                                                       pars[4].ParameterType == typeof(Func<,,>).MakeGenericType(args[0], args[1], args[3])
                                                   select x).Single();

        public static readonly MethodInfo Join2 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                   where x.Name == nameof(Enumerable.Join)
                                                   let args = x.GetGenericArguments()
                                                   where args.Length == 4
                                                   let pars = x.GetParameters()
                                                   where pars.Length == 6 &&
                                                       pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                       pars[1].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[1]) &&
                                                       pars[2].ParameterType == typeof(Func<,>).MakeGenericType(args[0], args[2]) &&
                                                       pars[3].ParameterType == typeof(Func<,>).MakeGenericType(args[1], args[2]) &&
                                                       pars[4].ParameterType == typeof(Func<,,>).MakeGenericType(args[0], args[1], args[3]) &&
                                                       pars[5].ParameterType == typeof(IEqualityComparer<>).MakeGenericType(args[2])
                                                   select x).Single();

        public static readonly MethodInfo Last1 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                   where x.Name == nameof(Enumerable.Last)
                                                   let args = x.GetGenericArguments()
                                                   where args.Length == 1
                                                   let pars = x.GetParameters()
                                                   where pars.Length == 1 &&
                                                       pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0])
                                                   select x).Single();

        public static readonly MethodInfo Last2 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                   where x.Name == nameof(Enumerable.Last)
                                                   let args = x.GetGenericArguments()
                                                   where args.Length == 1
                                                   let pars = x.GetParameters()
                                                   where pars.Length == 2 &&
                                                       pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                       pars[1].ParameterType == typeof(Func<,>).MakeGenericType(args[0], typeof(bool))
                                                   select x).Single();

        public static readonly MethodInfo LastOrDefault1 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                            where x.Name == nameof(Enumerable.LastOrDefault)
                                                            let args = x.GetGenericArguments()
                                                            where args.Length == 1
                                                            let pars = x.GetParameters()
                                                            where pars.Length == 1 &&
                                                                pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0])
                                                            select x).Single();

        public static readonly MethodInfo LastOrDefault2 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                            where x.Name == nameof(Enumerable.LastOrDefault)
                                                            let args = x.GetGenericArguments()
                                                            where args.Length == 1
                                                            let pars = x.GetParameters()
                                                            where pars.Length == 2 &&
                                                                pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                                pars[1].ParameterType == typeof(Func<,>).MakeGenericType(args[0], typeof(bool))
                                                            select x).Single();

        public static readonly MethodInfo LongCount1 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                        where x.Name == nameof(Enumerable.LongCount)
                                                        let args = x.GetGenericArguments()
                                                        where args.Length == 1
                                                        let pars = x.GetParameters()
                                                        where pars.Length == 1 &&
                                                            pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0])
                                                        select x).Single();

        public static readonly MethodInfo LongCount2 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                        where x.Name == nameof(Enumerable.LongCount)
                                                        let args = x.GetGenericArguments()
                                                        where args.Length == 1
                                                        let pars = x.GetParameters()
                                                        where pars.Length == 2 &&
                                                            pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                            pars[1].ParameterType == typeof(Func<,>).MakeGenericType(args[0], typeof(bool))
                                                        select x).Single();

        public static readonly MethodInfo Max1 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                  where x.Name == nameof(Enumerable.Max) &&
                                                      x.GetGenericArguments().Length == 0
                                                  let pars = x.GetParameters()
                                                  where pars.Length == 1 &&
                                                      pars[0].ParameterType == typeof(IEnumerable<int>)
                                                  select x).Single();

        public static readonly MethodInfo Max2 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                  where x.Name == nameof(Enumerable.Max) &&
                                                      x.GetGenericArguments().Length == 0
                                                  let pars = x.GetParameters()
                                                  where pars.Length == 1 &&
                                                      pars[0].ParameterType == typeof(IEnumerable<int?>)
                                                  select x).Single();

        public static readonly MethodInfo Max3 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                  where x.Name == nameof(Enumerable.Max) &&
                                                      x.GetGenericArguments().Length == 0
                                                  let pars = x.GetParameters()
                                                  where pars.Length == 1 &&
                                                      pars[0].ParameterType == typeof(IEnumerable<long>)
                                                  select x).Single();

        public static readonly MethodInfo Max4 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                  where x.Name == nameof(Enumerable.Max) &&
                                                      x.GetGenericArguments().Length == 0
                                                  let pars = x.GetParameters()
                                                  where pars.Length == 1 &&
                                                      pars[0].ParameterType == typeof(IEnumerable<long?>)
                                                  select x).Single();

        public static readonly MethodInfo Max5 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                  where x.Name == nameof(Enumerable.Max) &&
                                                      x.GetGenericArguments().Length == 0
                                                  let pars = x.GetParameters()
                                                  where pars.Length == 1 &&
                                                      pars[0].ParameterType == typeof(IEnumerable<double>)
                                                  select x).Single();

        public static readonly MethodInfo Max6 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                  where x.Name == nameof(Enumerable.Max) &&
                                                      x.GetGenericArguments().Length == 0
                                                  let pars = x.GetParameters()
                                                  where pars.Length == 1 &&
                                                      pars[0].ParameterType == typeof(IEnumerable<double?>)
                                                  select x).Single();

        public static readonly MethodInfo Max7 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                  where x.Name == nameof(Enumerable.Max) &&
                                                      x.GetGenericArguments().Length == 0
                                                  let pars = x.GetParameters()
                                                  where pars.Length == 1 &&
                                                      pars[0].ParameterType == typeof(IEnumerable<float>)
                                                  select x).Single();

        public static readonly MethodInfo Max8 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                  where x.Name == nameof(Enumerable.Max) &&
                                                      x.GetGenericArguments().Length == 0
                                                  let pars = x.GetParameters()
                                                  where pars.Length == 1 &&
                                                      pars[0].ParameterType == typeof(IEnumerable<float?>)
                                                  select x).Single();

        public static readonly MethodInfo Max9 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                  where x.Name == nameof(Enumerable.Max) &&
                                                      x.GetGenericArguments().Length == 0
                                                  let pars = x.GetParameters()
                                                  where pars.Length == 1 &&
                                                      pars[0].ParameterType == typeof(IEnumerable<decimal>)
                                                  select x).Single();

        public static readonly MethodInfo Max10 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                   where x.Name == nameof(Enumerable.Max) &&
                                                       x.GetGenericArguments().Length == 0
                                                   let pars = x.GetParameters()
                                                   where pars.Length == 1 &&
                                                       pars[0].ParameterType == typeof(IEnumerable<decimal?>)
                                                   select x).Single();

        public static readonly MethodInfo Max11 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                   where x.Name == nameof(Enumerable.Max)
                                                   let args = x.GetGenericArguments()
                                                   where args.Length == 1
                                                   let pars = x.GetParameters()
                                                   where pars.Length == 1 &&
                                                       pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0])
                                                   select x).Single();

        public static readonly MethodInfo Max12 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                   where x.Name == nameof(Enumerable.Max)
                                                   let args = x.GetGenericArguments()
                                                   where args.Length == 1
                                                   let pars = x.GetParameters()
                                                   where pars.Length == 2 &&
                                                       pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                       pars[1].ParameterType == typeof(Func<,>).MakeGenericType(args[0], typeof(int))
                                                   select x).Single();

        public static readonly MethodInfo Max13 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                   where x.Name == nameof(Enumerable.Max)
                                                   let args = x.GetGenericArguments()
                                                   where args.Length == 1
                                                   let pars = x.GetParameters()
                                                   where pars.Length == 2 &&
                                                       pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                       pars[1].ParameterType == typeof(Func<,>).MakeGenericType(args[0], typeof(int?))
                                                   select x).Single();

        public static readonly MethodInfo Max14 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                   where x.Name == nameof(Enumerable.Max)
                                                   let args = x.GetGenericArguments()
                                                   where args.Length == 1
                                                   let pars = x.GetParameters()
                                                   where pars.Length == 2 &&
                                                       pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                       pars[1].ParameterType == typeof(Func<,>).MakeGenericType(args[0], typeof(long))
                                                   select x).Single();

        public static readonly MethodInfo Max15 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                   where x.Name == nameof(Enumerable.Max)
                                                   let args = x.GetGenericArguments()
                                                   where args.Length == 1
                                                   let pars = x.GetParameters()
                                                   where pars.Length == 2 &&
                                                       pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                       pars[1].ParameterType == typeof(Func<,>).MakeGenericType(args[0], typeof(long?))
                                                   select x).Single();

        public static readonly MethodInfo Max16 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                   where x.Name == nameof(Enumerable.Max)
                                                   let args = x.GetGenericArguments()
                                                   where args.Length == 1
                                                   let pars = x.GetParameters()
                                                   where pars.Length == 2 &&
                                                       pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                       pars[1].ParameterType == typeof(Func<,>).MakeGenericType(args[0], typeof(float))
                                                   select x).Single();

        public static readonly MethodInfo Max17 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                   where x.Name == nameof(Enumerable.Max)
                                                   let args = x.GetGenericArguments()
                                                   where args.Length == 1
                                                   let pars = x.GetParameters()
                                                   where pars.Length == 2 &&
                                                       pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                       pars[1].ParameterType == typeof(Func<,>).MakeGenericType(args[0], typeof(float?))
                                                   select x).Single();

        public static readonly MethodInfo Max18 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                   where x.Name == nameof(Enumerable.Max)
                                                   let args = x.GetGenericArguments()
                                                   where args.Length == 1
                                                   let pars = x.GetParameters()
                                                   where pars.Length == 2 &&
                                                       pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                       pars[1].ParameterType == typeof(Func<,>).MakeGenericType(args[0], typeof(double))
                                                   select x).Single();

        public static readonly MethodInfo Max19 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                   where x.Name == nameof(Enumerable.Max)
                                                   let args = x.GetGenericArguments()
                                                   where args.Length == 1
                                                   let pars = x.GetParameters()
                                                   where pars.Length == 2 &&
                                                       pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                       pars[1].ParameterType == typeof(Func<,>).MakeGenericType(args[0], typeof(double?))
                                                   select x).Single();

        public static readonly MethodInfo Max20 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                   where x.Name == nameof(Enumerable.Max)
                                                   let args = x.GetGenericArguments()
                                                   where args.Length == 1
                                                   let pars = x.GetParameters()
                                                   where pars.Length == 2 &&
                                                       pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                       pars[1].ParameterType == typeof(Func<,>).MakeGenericType(args[0], typeof(decimal))
                                                   select x).Single();

        public static readonly MethodInfo Max21 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                   where x.Name == nameof(Enumerable.Max)
                                                   let args = x.GetGenericArguments()
                                                   where args.Length == 1
                                                   let pars = x.GetParameters()
                                                   where pars.Length == 2 &&
                                                       pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                       pars[1].ParameterType == typeof(Func<,>).MakeGenericType(args[0], typeof(decimal?))
                                                   select x).Single();

        public static readonly MethodInfo Max22 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                   where x.Name == nameof(Enumerable.Max)
                                                   let args = x.GetGenericArguments()
                                                   where args.Length == 2
                                                   let pars = x.GetParameters()
                                                   where pars.Length == 2 &&
                                                       pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                       pars[1].ParameterType == typeof(Func<,>).MakeGenericType(args[0], args[1])
                                                   select x).Single();

        public static readonly MethodInfo Min1 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                  where x.Name == nameof(Enumerable.Min) &&
                                                      x.GetGenericArguments().Length == 0
                                                  let pars = x.GetParameters()
                                                  where pars.Length == 1 &&
                                                      pars[0].ParameterType == typeof(IEnumerable<int>)
                                                  select x).Single();

        public static readonly MethodInfo Min2 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                  where x.Name == nameof(Enumerable.Min) &&
                                                      x.GetGenericArguments().Length == 0
                                                  let pars = x.GetParameters()
                                                  where pars.Length == 1 &&
                                                      pars[0].ParameterType == typeof(IEnumerable<int?>)
                                                  select x).Single();

        public static readonly MethodInfo Min3 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                  where x.Name == nameof(Enumerable.Min) &&
                                                      x.GetGenericArguments().Length == 0
                                                  let pars = x.GetParameters()
                                                  where pars.Length == 1 &&
                                                      pars[0].ParameterType == typeof(IEnumerable<long>)
                                                  select x).Single();

        public static readonly MethodInfo Min4 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                  where x.Name == nameof(Enumerable.Min) &&
                                                      x.GetGenericArguments().Length == 0
                                                  let pars = x.GetParameters()
                                                  where pars.Length == 1 &&
                                                      pars[0].ParameterType == typeof(IEnumerable<long?>)
                                                  select x).Single();

        public static readonly MethodInfo Min5 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                  where x.Name == nameof(Enumerable.Min) &&
                                                      x.GetGenericArguments().Length == 0
                                                  let pars = x.GetParameters()
                                                  where pars.Length == 1 &&
                                                      pars[0].ParameterType == typeof(IEnumerable<float>)
                                                  select x).Single();

        public static readonly MethodInfo Min6 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                  where x.Name == nameof(Enumerable.Min) &&
                                                      x.GetGenericArguments().Length == 0
                                                  let pars = x.GetParameters()
                                                  where pars.Length == 1 &&
                                                      pars[0].ParameterType == typeof(IEnumerable<float?>)
                                                  select x).Single();

        public static readonly MethodInfo Min7 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                  where x.Name == nameof(Enumerable.Min) &&
                                                      x.GetGenericArguments().Length == 0
                                                  let pars = x.GetParameters()
                                                  where pars.Length == 1 &&
                                                      pars[0].ParameterType == typeof(IEnumerable<double>)
                                                  select x).Single();

        public static readonly MethodInfo Min8 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                  where x.Name == nameof(Enumerable.Min) &&
                                                      x.GetGenericArguments().Length == 0
                                                  let pars = x.GetParameters()
                                                  where pars.Length == 1 &&
                                                      pars[0].ParameterType == typeof(IEnumerable<double?>)
                                                  select x).Single();

        public static readonly MethodInfo Min9 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                  where x.Name == nameof(Enumerable.Min) &&
                                                      x.GetGenericArguments().Length == 0
                                                  let pars = x.GetParameters()
                                                  where pars.Length == 1 &&
                                                      pars[0].ParameterType == typeof(IEnumerable<decimal>)
                                                  select x).Single();

        public static readonly MethodInfo Min10 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                   where x.Name == nameof(Enumerable.Min) &&
                                                       x.GetGenericArguments().Length == 0
                                                   let pars = x.GetParameters()
                                                   where pars.Length == 1 &&
                                                       pars[0].ParameterType == typeof(IEnumerable<decimal?>)
                                                   select x).Single();

        public static readonly MethodInfo Min11 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                   where x.Name == nameof(Enumerable.Min)
                                                   let args = x.GetGenericArguments()
                                                   where args.Length == 1
                                                   let pars = x.GetParameters()
                                                   where pars.Length == 1 &&
                                                       pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0])
                                                   select x).Single();

        public static readonly MethodInfo Min12 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                   where x.Name == nameof(Enumerable.Min)
                                                   let args = x.GetGenericArguments()
                                                   where args.Length == 2
                                                   let pars = x.GetParameters()
                                                   where pars.Length == 2 &&
                                                       pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                       pars[1].ParameterType == typeof(Func<,>).MakeGenericType(args[0], args[1])
                                                   select x).Single();

        public static readonly MethodInfo Min13 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                   where x.Name == nameof(Enumerable.Min)
                                                   let args = x.GetGenericArguments()
                                                   where args.Length == 1
                                                   let pars = x.GetParameters()
                                                   where pars.Length == 2 &&
                                                       pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                       pars[1].ParameterType == typeof(Func<,>).MakeGenericType(args[0], typeof(int))
                                                   select x).Single();

        public static readonly MethodInfo Min14 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                   where x.Name == nameof(Enumerable.Min)
                                                   let args = x.GetGenericArguments()
                                                   where args.Length == 1
                                                   let pars = x.GetParameters()
                                                   where pars.Length == 2 &&
                                                       pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                       pars[1].ParameterType == typeof(Func<,>).MakeGenericType(args[0], typeof(int?))
                                                   select x).Single();

        public static readonly MethodInfo Min15 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                   where x.Name == nameof(Enumerable.Min)
                                                   let args = x.GetGenericArguments()
                                                   where args.Length == 1
                                                   let pars = x.GetParameters()
                                                   where pars.Length == 2 &&
                                                       pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                       pars[1].ParameterType == typeof(Func<,>).MakeGenericType(args[0], typeof(long))
                                                   select x).Single();

        public static readonly MethodInfo Min16 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                   where x.Name == nameof(Enumerable.Min)
                                                   let args = x.GetGenericArguments()
                                                   where args.Length == 1
                                                   let pars = x.GetParameters()
                                                   where pars.Length == 2 &&
                                                       pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                       pars[1].ParameterType == typeof(Func<,>).MakeGenericType(args[0], typeof(long?))
                                                   select x).Single();

        public static readonly MethodInfo Min17 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                   where x.Name == nameof(Enumerable.Min)
                                                   let args = x.GetGenericArguments()
                                                   where args.Length == 1
                                                   let pars = x.GetParameters()
                                                   where pars.Length == 2 &&
                                                       pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                       pars[1].ParameterType == typeof(Func<,>).MakeGenericType(args[0], typeof(float))
                                                   select x).Single();

        public static readonly MethodInfo Min18 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                   where x.Name == nameof(Enumerable.Min)
                                                   let args = x.GetGenericArguments()
                                                   where args.Length == 1
                                                   let pars = x.GetParameters()
                                                   where pars.Length == 2 &&
                                                       pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                       pars[1].ParameterType == typeof(Func<,>).MakeGenericType(args[0], typeof(float?))
                                                   select x).Single();

        public static readonly MethodInfo Min19 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                   where x.Name == nameof(Enumerable.Min)
                                                   let args = x.GetGenericArguments()
                                                   where args.Length == 1
                                                   let pars = x.GetParameters()
                                                   where pars.Length == 2 &&
                                                       pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                       pars[1].ParameterType == typeof(Func<,>).MakeGenericType(args[0], typeof(double))
                                                   select x).Single();

        public static readonly MethodInfo Min20 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                   where x.Name == nameof(Enumerable.Min)
                                                   let args = x.GetGenericArguments()
                                                   where args.Length == 1
                                                   let pars = x.GetParameters()
                                                   where pars.Length == 2 &&
                                                       pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                       pars[1].ParameterType == typeof(Func<,>).MakeGenericType(args[0], typeof(double?))
                                                   select x).Single();

        public static readonly MethodInfo Min21 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                   where x.Name == nameof(Enumerable.Min)
                                                   let args = x.GetGenericArguments()
                                                   where args.Length == 1
                                                   let pars = x.GetParameters()
                                                   where pars.Length == 2 &&
                                                       pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                       pars[1].ParameterType == typeof(Func<,>).MakeGenericType(args[0], typeof(decimal))
                                                   select x).Single();

        public static readonly MethodInfo Min22 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                   where x.Name == nameof(Enumerable.Min)
                                                   let args = x.GetGenericArguments()
                                                   where args.Length == 1
                                                   let pars = x.GetParameters()
                                                   where pars.Length == 2 &&
                                                       pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                       pars[1].ParameterType == typeof(Func<,>).MakeGenericType(args[0], typeof(decimal?))
                                                   select x).Single();

        public static readonly MethodInfo OfType = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                    where x.Name == nameof(Enumerable.OfType) &&
                                                        x.GetGenericArguments().Length == 1
                                                    let pars = x.GetParameters()
                                                    where pars.Length == 1 &&
                                                        pars[0].ParameterType == typeof(System.Collections.IEnumerable)
                                                    select x).Single();

        public static readonly MethodInfo OrderBy1 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                      where x.Name == nameof(Enumerable.OrderBy)
                                                      let args = x.GetGenericArguments()
                                                      where args.Length == 2
                                                      let pars = x.GetParameters()
                                                      where pars.Length == 2 &&
                                                          pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                          pars[1].ParameterType == typeof(Func<,>).MakeGenericType(args[0], args[1])
                                                      select x).Single();

        public static readonly MethodInfo OrderBy2 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                      where x.Name == nameof(Enumerable.OrderBy)
                                                      let args = x.GetGenericArguments()
                                                      where args.Length == 2
                                                      let pars = x.GetParameters()
                                                      where pars.Length == 3 &&
                                                          pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                          pars[1].ParameterType == typeof(Func<,>).MakeGenericType(args[0], args[1]) &&
                                                          pars[2].ParameterType == typeof(IComparer<>).MakeGenericType(args[1])
                                                      select x).Single();

        public static readonly MethodInfo OrderByDescending1 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                                where x.Name == nameof(Enumerable.OrderByDescending)
                                                                let args = x.GetGenericArguments()
                                                                where args.Length == 2
                                                                let pars = x.GetParameters()
                                                                where pars.Length == 2 &&
                                                                    pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                                    pars[1].ParameterType == typeof(Func<,>).MakeGenericType(args[0], args[1])
                                                                select x).Single();

        public static readonly MethodInfo OrderByDescending2 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                                where x.Name == nameof(Enumerable.OrderByDescending)
                                                                let args = x.GetGenericArguments()
                                                                where args.Length == 2
                                                                let pars = x.GetParameters()
                                                                where pars.Length == 3 &&
                                                                    pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                                    pars[1].ParameterType == typeof(Func<,>).MakeGenericType(args[0], args[1]) &&
                                                                    pars[2].ParameterType == typeof(IComparer<>).MakeGenericType(args[1])
                                                                select x).Single();

        public static readonly MethodInfo Prepend = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                     where x.Name == nameof(Enumerable.Prepend)
                                                     let args = x.GetGenericArguments()
                                                     where args.Length == 1
                                                     let pars = x.GetParameters()
                                                     where pars.Length == 2 &&
                                                         pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                         pars[1].ParameterType == args[0]
                                                     select x).Single();

        public static readonly MethodInfo Range = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                   where x.Name == nameof(Enumerable.Range) &&
                                                       x.GetGenericArguments().Length == 0
                                                   let pars = x.GetParameters()
                                                   where pars.Length == 2 &&
                                                       pars[0].ParameterType == typeof(int) &&
                                                       pars[1].ParameterType == typeof(int)
                                                   select x).Single();

        public static readonly MethodInfo Repeat = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                    where x.Name == nameof(Enumerable.Repeat)
                                                    let args = x.GetGenericArguments()
                                                    where args.Length == 1
                                                    let pars = x.GetParameters()
                                                    where pars.Length == 2 &&
                                                        pars[0].ParameterType == args[0] &&
                                                        pars[1].ParameterType == typeof(int)
                                                    select x).Single();

        public static readonly MethodInfo Reverse = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                     where x.Name == nameof(Enumerable.Reverse)
                                                     let args = x.GetGenericArguments()
                                                     where args.Length == 1
                                                     let pars = x.GetParameters()
                                                     where pars.Length == 1 &&
                                                         pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0])
                                                     select x).Single();

        public static readonly MethodInfo Select1 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                     where x.Name == nameof(Enumerable.Select)
                                                     let args = x.GetGenericArguments()
                                                     where args.Length == 2
                                                     let pars = x.GetParameters()
                                                     where pars.Length == 2 &&
                                                         pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                         pars[1].ParameterType == typeof(Func<,>).MakeGenericType(args[0], args[1])
                                                     select x).Single();

        public static readonly MethodInfo Select2 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                     where x.Name == nameof(Enumerable.Select)
                                                     let args = x.GetGenericArguments()
                                                     where args.Length == 2
                                                     let pars = x.GetParameters()
                                                     where pars.Length == 2 &&
                                                         pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                         pars[1].ParameterType == typeof(Func<,,>).MakeGenericType(args[0], typeof(int), args[1])
                                                     select x).Single();

        public static readonly MethodInfo SelectMany1 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                         where x.Name == nameof(Enumerable.SelectMany)
                                                         let args = x.GetGenericArguments()
                                                         where args.Length == 2
                                                         let pars = x.GetParameters()
                                                         where pars.Length == 2 &&
                                                             pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                             pars[1].ParameterType == typeof(Func<,>).MakeGenericType(args[0], typeof(IEnumerable<>).MakeGenericType(args[1]))
                                                         select x).Single();

        public static readonly MethodInfo SelectMany2 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                         where x.Name == nameof(Enumerable.SelectMany)
                                                         let args = x.GetGenericArguments()
                                                         where args.Length == 2
                                                         let pars = x.GetParameters()
                                                         where pars.Length == 2 &&
                                                             pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                             pars[1].ParameterType == typeof(Func<,,>).MakeGenericType(args[0], typeof(int), typeof(IEnumerable<>).MakeGenericType(args[1]))
                                                         select x).Single();

        public static readonly MethodInfo SelectMany3 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                         where x.Name == nameof(Enumerable.SelectMany)
                                                         let args = x.GetGenericArguments()
                                                         where args.Length == 3
                                                         let pars = x.GetParameters()
                                                         where pars.Length == 3 &&
                                                             pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                             pars[1].ParameterType == typeof(Func<,,>).MakeGenericType(args[0], typeof(int), typeof(IEnumerable<>).MakeGenericType(args[1])) &&
                                                             pars[2].ParameterType == typeof(Func<,,>).MakeGenericType(args[0], args[1], args[2])
                                                         select x).Single();

        public static readonly MethodInfo SelectMany4 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                         where x.Name == nameof(Enumerable.SelectMany)
                                                         let args = x.GetGenericArguments()
                                                         where args.Length == 3
                                                         let pars = x.GetParameters()
                                                         where pars.Length == 3 &&
                                                             pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                             pars[1].ParameterType == typeof(Func<,>).MakeGenericType(args[0], typeof(IEnumerable<>).MakeGenericType(args[1])) &&
                                                             pars[2].ParameterType == typeof(Func<,,>).MakeGenericType(args[0], args[1], args[2])
                                                         select x).Single();

        public static readonly MethodInfo SequenceEqual1 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                            where x.Name == nameof(Enumerable.SequenceEqual)
                                                            let args = x.GetGenericArguments()
                                                            where args.Length == 1
                                                            let pars = x.GetParameters()
                                                            where pars.Length == 2 &&
                                                                pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                                pars[1].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0])
                                                            select x).Single();

        public static readonly MethodInfo SequenceEqual2 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                            where x.Name == nameof(Enumerable.SequenceEqual)
                                                            let args = x.GetGenericArguments()
                                                            where args.Length == 1
                                                            let pars = x.GetParameters()
                                                            where pars.Length == 3 &&
                                                                pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                                pars[1].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                                pars[2].ParameterType == typeof(IEqualityComparer<>).MakeGenericType(args[0])
                                                            select x).Single();

        public static readonly MethodInfo Single1 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                     where x.Name == nameof(Enumerable.Single)
                                                     let args = x.GetGenericArguments()
                                                     where args.Length == 1
                                                     let pars = x.GetParameters()
                                                     where pars.Length == 1 &&
                                                         pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0])
                                                     select x).Single();

        public static readonly MethodInfo Single2 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                     where x.Name == nameof(Enumerable.Single)
                                                     let args = x.GetGenericArguments()
                                                     where args.Length == 1
                                                     let pars = x.GetParameters()
                                                     where pars.Length == 2 &&
                                                         pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                         pars[1].ParameterType == typeof(Func<,>).MakeGenericType(args[0], typeof(bool))
                                                     select x).Single();

        public static readonly MethodInfo SingleOrDefault1 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                              where x.Name == nameof(Enumerable.SingleOrDefault)
                                                              let args = x.GetGenericArguments()
                                                              where args.Length == 1
                                                              let pars = x.GetParameters()
                                                              where pars.Length == 1 &&
                                                                  pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0])
                                                              select x).Single();

        public static readonly MethodInfo SingleOrDefault2 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                              where x.Name == nameof(Enumerable.SingleOrDefault)
                                                              let args = x.GetGenericArguments()
                                                              where args.Length == 1
                                                              let pars = x.GetParameters()
                                                              where pars.Length == 2 &&
                                                                  pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                                  pars[1].ParameterType == typeof(Func<,>).MakeGenericType(args[0], typeof(bool))
                                                              select x).Single();

        public static readonly MethodInfo Skip = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                  where x.Name == nameof(Enumerable.Skip)
                                                  let args = x.GetGenericArguments()
                                                  where args.Length == 1
                                                  let pars = x.GetParameters()
                                                  where pars.Length == 2 &&
                                                      pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                      pars[1].ParameterType == typeof(int)
                                                  select x).Single();

        public static readonly MethodInfo SkipWhile1 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                        where x.Name == nameof(Enumerable.SkipWhile)
                                                        let args = x.GetGenericArguments()
                                                        where args.Length == 1
                                                        let pars = x.GetParameters()
                                                        where pars.Length == 2 &&
                                                            pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                            pars[1].ParameterType == typeof(Func<,>).MakeGenericType(args[0], typeof(bool))
                                                        select x).Single();

        public static readonly MethodInfo SkipWhile2 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                        where x.Name == nameof(Enumerable.SkipWhile)
                                                        let args = x.GetGenericArguments()
                                                        where args.Length == 1
                                                        let pars = x.GetParameters()
                                                        where pars.Length == 2 &&
                                                            pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                            pars[1].ParameterType == typeof(Func<,,>).MakeGenericType(args[0], typeof(int), typeof(bool))
                                                        select x).Single();

        public static readonly MethodInfo Sum1 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                  where x.Name == nameof(Enumerable.Sum) &&
                                                      x.GetGenericArguments().Length == 0
                                                  let pars = x.GetParameters()
                                                  where pars.Length == 1 &&
                                                      pars[0].ParameterType == typeof(IEnumerable<int>)
                                                  select x).Single();

        public static readonly MethodInfo Sum2 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                  where x.Name == nameof(Enumerable.Sum) &&
                                                      x.GetGenericArguments().Length == 0
                                                  let pars = x.GetParameters()
                                                  where pars.Length == 1 &&
                                                      pars[0].ParameterType == typeof(IEnumerable<int?>)
                                                  select x).Single();

        public static readonly MethodInfo Sum3 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                  where x.Name == nameof(Enumerable.Sum) &&
                                                      x.GetGenericArguments().Length == 0
                                                  let pars = x.GetParameters()
                                                  where pars.Length == 1 &&
                                                      pars[0].ParameterType == typeof(IEnumerable<long>)
                                                  select x).Single();

        public static readonly MethodInfo Sum4 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                  where x.Name == nameof(Enumerable.Sum) &&
                                                      x.GetGenericArguments().Length == 0
                                                  let pars = x.GetParameters()
                                                  where pars.Length == 1 &&
                                                      pars[0].ParameterType == typeof(IEnumerable<long?>)
                                                  select x).Single();

        public static readonly MethodInfo Sum5 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                  where x.Name == nameof(Enumerable.Sum) &&
                                                      x.GetGenericArguments().Length == 0
                                                  let pars = x.GetParameters()
                                                  where pars.Length == 1 &&
                                                      pars[0].ParameterType == typeof(IEnumerable<float>)
                                                  select x).Single();

        public static readonly MethodInfo Sum6 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                  where x.Name == nameof(Enumerable.Sum) &&
                                                      x.GetGenericArguments().Length == 0
                                                  let pars = x.GetParameters()
                                                  where pars.Length == 1 &&
                                                      pars[0].ParameterType == typeof(IEnumerable<float?>)
                                                  select x).Single();

        public static readonly MethodInfo Sum7 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                  where x.Name == nameof(Enumerable.Sum) &&
                                                      x.GetGenericArguments().Length == 0
                                                  let pars = x.GetParameters()
                                                  where pars.Length == 1 &&
                                                      pars[0].ParameterType == typeof(IEnumerable<double>)
                                                  select x).Single();

        public static readonly MethodInfo Sum8 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                  where x.Name == nameof(Enumerable.Sum) &&
                                                      x.GetGenericArguments().Length == 0
                                                  let pars = x.GetParameters()
                                                  where pars.Length == 1 &&
                                                      pars[0].ParameterType == typeof(IEnumerable<double?>)
                                                  select x).Single();

        public static readonly MethodInfo Sum9 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                  where x.Name == nameof(Enumerable.Sum) &&
                                                      x.GetGenericArguments().Length == 0
                                                  let pars = x.GetParameters()
                                                  where pars.Length == 1 &&
                                                      pars[0].ParameterType == typeof(IEnumerable<decimal>)
                                                  select x).Single();

        public static readonly MethodInfo Sum10 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                   where x.Name == nameof(Enumerable.Sum) &&
                                                       x.GetGenericArguments().Length == 0
                                                   let pars = x.GetParameters()
                                                   where pars.Length == 1 &&
                                                       pars[0].ParameterType == typeof(IEnumerable<decimal?>)
                                                   select x).Single();

        public static readonly MethodInfo Sum11 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                   where x.Name == nameof(Enumerable.Sum)
                                                   let args = x.GetGenericArguments()
                                                   where args.Length == 1
                                                   let pars = x.GetParameters()
                                                   where pars.Length == 2 &&
                                                       pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                       pars[1].ParameterType == typeof(Func<,>).MakeGenericType(args[0], typeof(int))
                                                   select x).Single();

        public static readonly MethodInfo Sum12 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                   where x.Name == nameof(Enumerable.Sum)
                                                   let args = x.GetGenericArguments()
                                                   where args.Length == 1
                                                   let pars = x.GetParameters()
                                                   where pars.Length == 2 &&
                                                       pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                       pars[1].ParameterType == typeof(Func<,>).MakeGenericType(args[0], typeof(int?))
                                                   select x).Single();

        public static readonly MethodInfo Sum13 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                   where x.Name == nameof(Enumerable.Sum)
                                                   let args = x.GetGenericArguments()
                                                   where args.Length == 1
                                                   let pars = x.GetParameters()
                                                   where pars.Length == 2 &&
                                                       pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                       pars[1].ParameterType == typeof(Func<,>).MakeGenericType(args[0], typeof(long))
                                                   select x).Single();

        public static readonly MethodInfo Sum14 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                   where x.Name == nameof(Enumerable.Sum)
                                                   let args = x.GetGenericArguments()
                                                   where args.Length == 1
                                                   let pars = x.GetParameters()
                                                   where pars.Length == 2 &&
                                                       pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                       pars[1].ParameterType == typeof(Func<,>).MakeGenericType(args[0], typeof(long?))
                                                   select x).Single();

        public static readonly MethodInfo Sum15 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                   where x.Name == nameof(Enumerable.Sum)
                                                   let args = x.GetGenericArguments()
                                                   where args.Length == 1
                                                   let pars = x.GetParameters()
                                                   where pars.Length == 2 &&
                                                       pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                       pars[1].ParameterType == typeof(Func<,>).MakeGenericType(args[0], typeof(float))
                                                   select x).Single();

        public static readonly MethodInfo Sum16 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                   where x.Name == nameof(Enumerable.Sum)
                                                   let args = x.GetGenericArguments()
                                                   where args.Length == 1
                                                   let pars = x.GetParameters()
                                                   where pars.Length == 2 &&
                                                       pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                       pars[1].ParameterType == typeof(Func<,>).MakeGenericType(args[0], typeof(float?))
                                                   select x).Single();

        public static readonly MethodInfo Sum17 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                   where x.Name == nameof(Enumerable.Sum)
                                                   let args = x.GetGenericArguments()
                                                   where args.Length == 1
                                                   let pars = x.GetParameters()
                                                   where pars.Length == 2 &&
                                                       pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                       pars[1].ParameterType == typeof(Func<,>).MakeGenericType(args[0], typeof(double))
                                                   select x).Single();

        public static readonly MethodInfo Sum18 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                   where x.Name == nameof(Enumerable.Sum)
                                                   let args = x.GetGenericArguments()
                                                   where args.Length == 1
                                                   let pars = x.GetParameters()
                                                   where pars.Length == 2 &&
                                                       pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                       pars[1].ParameterType == typeof(Func<,>).MakeGenericType(args[0], typeof(double?))
                                                   select x).Single();

        public static readonly MethodInfo Sum19 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                   where x.Name == nameof(Enumerable.Sum)
                                                   let args = x.GetGenericArguments()
                                                   where args.Length == 1
                                                   let pars = x.GetParameters()
                                                   where pars.Length == 2 &&
                                                       pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                       pars[1].ParameterType == typeof(Func<,>).MakeGenericType(args[0], typeof(decimal))
                                                   select x).Single();

        public static readonly MethodInfo Sum20 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                   where x.Name == nameof(Enumerable.Sum)
                                                   let args = x.GetGenericArguments()
                                                   where args.Length == 1
                                                   let pars = x.GetParameters()
                                                   where pars.Length == 2 &&
                                                       pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                       pars[1].ParameterType == typeof(Func<,>).MakeGenericType(args[0], typeof(decimal?))
                                                   select x).Single();

        public static readonly MethodInfo Take = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                  where x.Name == nameof(Enumerable.Take)
                                                  let args = x.GetGenericArguments()
                                                  where args.Length == 1
                                                  let pars = x.GetParameters()
                                                  where pars.Length == 2 &&
                                                      pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                      pars[1].ParameterType == typeof(int)
                                                  select x).Single();

        public static readonly MethodInfo TakeWhile1 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                        where x.Name == nameof(Enumerable.TakeWhile)
                                                        let args = x.GetGenericArguments()
                                                        where args.Length == 1
                                                        let pars = x.GetParameters()
                                                        where pars.Length == 2 &&
                                                            pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                            pars[1].ParameterType == typeof(Func<,>).MakeGenericType(args[0], typeof(bool))
                                                        select x).Single();

        public static readonly MethodInfo TakeWhile2 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                        where x.Name == nameof(Enumerable.TakeWhile)
                                                        let args = x.GetGenericArguments()
                                                        where args.Length == 1
                                                        let pars = x.GetParameters()
                                                        where pars.Length == 2 &&
                                                            pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                            pars[1].ParameterType == typeof(Func<,,>).MakeGenericType(args[0], typeof(int), typeof(bool))
                                                        select x).Single();

        public static readonly MethodInfo ThenBy1 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                     where x.Name == nameof(Enumerable.ThenBy)
                                                     let args = x.GetGenericArguments()
                                                     where args.Length == 2
                                                     let pars = x.GetParameters()
                                                     where pars.Length == 2 &&
                                                         pars[0].ParameterType == typeof(IOrderedEnumerable<>).MakeGenericType(args[0]) &&
                                                         pars[1].ParameterType == typeof(Func<,>).MakeGenericType(args[0], args[1])
                                                     select x).Single();

        public static readonly MethodInfo ThenBy2 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                     where x.Name == nameof(Enumerable.ThenBy)
                                                     let args = x.GetGenericArguments()
                                                     where args.Length == 2
                                                     let pars = x.GetParameters()
                                                     where pars.Length == 3 &&
                                                         pars[0].ParameterType == typeof(IOrderedEnumerable<>).MakeGenericType(args[0]) &&
                                                         pars[1].ParameterType == typeof(Func<,>).MakeGenericType(args[0], args[1]) &&
                                                         pars[2].ParameterType == typeof(IComparer<>).MakeGenericType(args[1])
                                                     select x).Single();

        public static readonly MethodInfo ThenByDescending1 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                               where x.Name == nameof(Enumerable.ThenByDescending)
                                                               let args = x.GetGenericArguments()
                                                               where args.Length == 2
                                                               let pars = x.GetParameters()
                                                               where pars.Length == 2 &&
                                                                   pars[0].ParameterType == typeof(IOrderedEnumerable<>).MakeGenericType(args[0]) &&
                                                                   pars[1].ParameterType == typeof(Func<,>).MakeGenericType(args[0], args[1])
                                                               select x).Single();

        public static readonly MethodInfo ThenByDescending2 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                               where x.Name == nameof(Enumerable.ThenByDescending)
                                                               let args = x.GetGenericArguments()
                                                               where args.Length == 2
                                                               let pars = x.GetParameters()
                                                               where pars.Length == 3 &&
                                                                   pars[0].ParameterType == typeof(IOrderedEnumerable<>).MakeGenericType(args[0]) &&
                                                                   pars[1].ParameterType == typeof(Func<,>).MakeGenericType(args[0], args[1]) &&
                                                                   pars[2].ParameterType == typeof(IComparer<>).MakeGenericType(args[1])
                                                               select x).Single();

        public static readonly MethodInfo ToArray = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                     where x.Name == nameof(Enumerable.ToArray)
                                                     let args = x.GetGenericArguments()
                                                     where args.Length == 1
                                                     let pars = x.GetParameters()
                                                     where pars.Length == 1 &&
                                                         pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0])
                                                     select x).Single();

        public static readonly MethodInfo ToDictionary1 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                           where x.Name == nameof(Enumerable.ToDictionary)
                                                           let args = x.GetGenericArguments()
                                                           where args.Length == 2
                                                           let pars = x.GetParameters()
                                                           where pars.Length == 2 &&
                                                               pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                               pars[1].ParameterType == typeof(Func<,>).MakeGenericType(args[0], args[1])
                                                           select x).Single();

        public static readonly MethodInfo ToDictionary2 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                           where x.Name == nameof(Enumerable.ToDictionary)
                                                           let args = x.GetGenericArguments()
                                                           where args.Length == 2
                                                           let pars = x.GetParameters()
                                                           where pars.Length == 3 &&
                                                               pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                               pars[1].ParameterType == typeof(Func<,>).MakeGenericType(args[0], args[1]) &&
                                                               pars[2].ParameterType == typeof(IEqualityComparer<>).MakeGenericType(args[1])
                                                           select x).Single();

        public static readonly MethodInfo ToDictionary3 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                           where x.Name == nameof(Enumerable.ToDictionary)
                                                           let args = x.GetGenericArguments()
                                                           where args.Length == 3
                                                           let pars = x.GetParameters()
                                                           where pars.Length == 3 &&
                                                               pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                               pars[1].ParameterType == typeof(Func<,>).MakeGenericType(args[0], args[1]) &&
                                                               pars[2].ParameterType == typeof(Func<,>).MakeGenericType(args[0], args[2])
                                                           select x).Single();

        public static readonly MethodInfo ToDictionary4 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                           where x.Name == nameof(Enumerable.ToDictionary)
                                                           let args = x.GetGenericArguments()
                                                           where args.Length == 3
                                                           let pars = x.GetParameters()
                                                           where pars.Length == 4 &&
                                                               pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                               pars[1].ParameterType == typeof(Func<,>).MakeGenericType(args[0], args[1]) &&
                                                               pars[2].ParameterType == typeof(Func<,>).MakeGenericType(args[0], args[2]) &&
                                                               pars[3].ParameterType == typeof(IEqualityComparer<>).MakeGenericType(args[1])
                                                           select x).Single();
#if NETSTANDARD2_1
        public static readonly MethodInfo ToHashSet1 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                        where x.Name == nameof(Enumerable.ToHashSet)
                                                        let args = x.GetGenericArguments()
                                                        where args.Length == 1
                                                        let pars = x.GetParameters()
                                                        where pars.Length == 1 &&
                                                            pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0])
                                                        select x).Single();

        public static readonly MethodInfo ToHashSet2 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                        where x.Name == nameof(Enumerable.ToHashSet)
                                                        let args = x.GetGenericArguments()
                                                        where args.Length == 1
                                                        let pars = x.GetParameters()
                                                        where pars.Length == 2 &&
                                                            pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                            pars[1].ParameterType == typeof(IEqualityComparer<>).MakeGenericType(args[0])
                                                        select x).Single();
#endif
        public static readonly MethodInfo ToList = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                    where x.Name == nameof(Enumerable.ToList)
                                                    let args = x.GetGenericArguments()
                                                    where args.Length == 1
                                                    let pars = x.GetParameters()
                                                    where pars.Length == 1 &&
                                                        pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0])
                                                    select x).Single();

        public static readonly MethodInfo ToLookup1 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                       where x.Name == nameof(Enumerable.ToLookup)
                                                       let args = x.GetGenericArguments()
                                                       where args.Length == 2
                                                       let pars = x.GetParameters()
                                                       where pars.Length == 2 &&
                                                           pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                           pars[1].ParameterType == typeof(Func<,>).MakeGenericType(args[0], args[1])
                                                       select x).Single();

        public static readonly MethodInfo ToLookup2 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                       where x.Name == nameof(Enumerable.ToLookup)
                                                       let args = x.GetGenericArguments()
                                                       where args.Length == 2
                                                       let pars = x.GetParameters()
                                                       where pars.Length == 3 &&
                                                           pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                           pars[1].ParameterType == typeof(Func<,>).MakeGenericType(args[0], args[1]) &&
                                                           pars[2].ParameterType == typeof(IEqualityComparer<>).MakeGenericType(args[1])
                                                       select x).Single();

        public static readonly MethodInfo ToLookup3 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                       where x.Name == nameof(Enumerable.ToLookup)
                                                       let args = x.GetGenericArguments()
                                                       where args.Length == 3
                                                       let pars = x.GetParameters()
                                                       where pars.Length == 3 &&
                                                           pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                           pars[1].ParameterType == typeof(Func<,>).MakeGenericType(args[0], args[1]) &&
                                                           pars[2].ParameterType == typeof(Func<,>).MakeGenericType(args[0], args[2])
                                                       select x).Single();

        public static readonly MethodInfo ToLookup4 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                       where x.Name == nameof(Enumerable.ToLookup)
                                                       let args = x.GetGenericArguments()
                                                       where args.Length == 3
                                                       let pars = x.GetParameters()
                                                       where pars.Length == 4 &&
                                                           pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                           pars[1].ParameterType == typeof(Func<,>).MakeGenericType(args[0], args[1]) &&
                                                           pars[2].ParameterType == typeof(Func<,>).MakeGenericType(args[0], args[2]) &&
                                                           pars[3].ParameterType == typeof(IEqualityComparer<>).MakeGenericType(args[1])
                                                       select x).Single();

        public static readonly MethodInfo Union1 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                    where x.Name == nameof(Enumerable.Union)
                                                    let args = x.GetGenericArguments()
                                                    where args.Length == 1
                                                    let pars = x.GetParameters()
                                                    where pars.Length == 2 &&
                                                        pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                        pars[1].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0])
                                                    select x).Single();

        public static readonly MethodInfo Union2 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                    where x.Name == nameof(Enumerable.Union)
                                                    let args = x.GetGenericArguments()
                                                    where args.Length == 1
                                                    let pars = x.GetParameters()
                                                    where pars.Length == 3 &&
                                                        pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                        pars[1].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                        pars[2].ParameterType == typeof(IEqualityComparer<>).MakeGenericType(args[0])
                                                    select x).Single();

        public static readonly MethodInfo Where1 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                    where x.Name == nameof(Enumerable.Where)
                                                    let args = x.GetGenericArguments()
                                                    where args.Length == 1
                                                    let pars = x.GetParameters()
                                                    where pars.Length == 2 &&
                                                        pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                        pars[1].ParameterType == typeof(Func<,>).MakeGenericType(args[0], typeof(bool))
                                                    select x).Single();

        public static readonly MethodInfo Where2 = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                    where x.Name == nameof(Enumerable.Where)
                                                    let args = x.GetGenericArguments()
                                                    where args.Length == 1
                                                    let pars = x.GetParameters()
                                                    where pars.Length == 2 &&
                                                        pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                        pars[1].ParameterType == typeof(Func<,,>).MakeGenericType(args[0], typeof(int), typeof(bool))
                                                    select x).Single();

        public static readonly MethodInfo Zip = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                 where x.Name == nameof(Enumerable.Zip)
                                                 let args = x.GetGenericArguments()
                                                 where args.Length == 3
                                                 let pars = x.GetParameters()
                                                 where pars.Length == 3 &&
                                                     pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                     pars[1].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[1]) &&
                                                     pars[2].ParameterType == typeof(Func<,,>).MakeGenericType(args[0], args[1], args[2])
                                                 select x).Single();
    }
}
using System;
using System.Runtime.CompilerServices;

namespace WargamingApi.Types
{
    public static class Extensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        public static string EnumToString(this Language target)
        {
            return target switch
            {
                Language.En => nameof(Language.En),
                Language.Ru => nameof(Language.Ru),
                Language.Pl => nameof(Language.Pl),
                Language.De => nameof(Language.De),
                Language.Fr => nameof(Language.Fr),
                Language.Es => nameof(Language.Es),
                Language.Tr => nameof(Language.Tr),
                Language.Cs => nameof(Language.Cs),
                Language.Th => nameof(Language.Th),
                Language.Vi => nameof(Language.Vi),
                Language.Ko => nameof(Language.Ko),
                _ => throw new ArgumentOutOfRangeException(nameof(target), target, null)
            };
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        public static string EnumToString(this Regions target)
        {
            return target switch
            {
                Regions.Ru => nameof(Regions.Ru),
                Regions.Eu => nameof(Regions.Eu),
                Regions.Na => nameof(Regions.Na),
                Regions.Asia => nameof(Regions.Asia),
                _ => throw new ArgumentOutOfRangeException(nameof(target), target, null)
            };
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        public static string EnumToString(this Type target)
        {
            return target switch
            {
                Type.StartsWith => nameof(Type.StartsWith),
                Type.Exact => nameof(Type.Exact),
                _ => throw new ArgumentOutOfRangeException(nameof(target), target, null)
            };
        }
    }
}
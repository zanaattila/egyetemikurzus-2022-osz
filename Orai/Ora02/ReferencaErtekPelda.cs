using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ora02
{
    internal sealed class ReferencaErtekPelda : IEquatable<ReferencaErtekPelda>
    {
        public int X { get; init; }
        public int Y { get; init; }

        public override bool Equals(object? obj)
        {
            /*var casted = obj as ReferencaErtekPelda;
            if (casted == null) return false;
            return X == casted.X && Y == casted.Y;
            */

            if (obj is ReferencaErtekPelda pelda)
            {
                return X == pelda.X && Y == pelda.Y;
            }
            return false;
        }

        public bool Equals(ReferencaErtekPelda? other)
        {
            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            //FNV - Műkdöik, de van jobb
            const int basePrime = 11;
            int result = basePrime;
            result = result * 5 ^ X.GetHashCode();
            result = result * 5 ^ Y.GetHashCode();
            return result;

            //Pl ez:
            //return HashCode.Combine(X, Y);
        }
    }

    internal sealed record class PeldaRecord
    {
        public int X { get; init; }
        public int Y { get; init; }
    }
}

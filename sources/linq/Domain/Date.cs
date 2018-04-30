using System;

namespace Linq.Domain
{
    internal struct Date : IEquatable<Date>
    {
        public int Year { get; }

        public int Month { get; }

        public Date(int year, int month)
        {
            Year = year;
            Month = month;
        }

        public override string ToString()
        {
            return $"{Month}-{Year}";
        }


        public bool Equals(Date other)
        {
            return Year == other.Year && Month == other.Month;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is Date && Equals((Date)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Year * 397) ^ Month;
            }
        }

        public static bool operator ==(Date a, Date b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(Date a, Date b)
        {
            return !(a == b);
        }
    }
}
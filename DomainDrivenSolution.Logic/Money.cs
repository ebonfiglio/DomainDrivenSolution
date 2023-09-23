namespace DomainDrivenSolution.Logic
{
    public class Money : ValueObject<Money>
    {
        public static readonly Money None = new(0, 0, 0, 0, 0, 0);
        public static readonly Money Cent = new(1, 0, 0, 0, 0, 0);
        public static readonly Money TenCent = new(0, 1, 0, 0, 0, 0);
        public static readonly Money Quarter = new(0, 0, 1, 0, 0, 0);
        public static readonly Money Dollar = new(0, 0, 0, 1, 0, 0);
        public static readonly Money FiveDollar = new(0, 0, 0, 0, 1, 0);
        public static readonly Money TwentyDollar = new(0, 0, 0, 0, 0, 1);

        public int OneCentCount { get; }
        public int TenCentCount { get; }
        public int QuarterCount { get; }
        public int OneDollarCount { get; }
        public int FiveDollarCount { get; }
        public int TwentyDollarCount { get; }

        public decimal Amount =>
                 OneCentCount * 0.01m +
                 TenCentCount * 0.10m +
                 QuarterCount * 0.25m +
                 OneDollarCount +
                 FiveDollarCount * 5 +
                 TwentyDollarCount * 20;



        public Money(int oneCentCount, int tenCentCount, int quarterCount, int oneDollarCount, int fiveDollarCount, int twentyDollarCount)
        {
            if (oneCentCount < 0) throw new InvalidOperationException();
            if (tenCentCount < 0) throw new InvalidOperationException();
            if (quarterCount < 0) throw new InvalidOperationException();
            if (oneDollarCount < 0) throw new InvalidOperationException();
            if (fiveDollarCount < 0) throw new InvalidOperationException();
            if (twentyDollarCount < 0) throw new InvalidOperationException();

            OneCentCount = oneCentCount;
            TenCentCount = tenCentCount;
            QuarterCount = quarterCount;
            OneDollarCount = oneDollarCount;
            FiveDollarCount = fiveDollarCount;
            TwentyDollarCount = twentyDollarCount;
        }

        public static Money operator +(Money a, Money b)
        {
            Money sum = new(
                a.OneCentCount + b.OneCentCount,
                a.TenCentCount + b.TenCentCount,
                a.QuarterCount + b.QuarterCount,
                a.OneDollarCount + b.OneDollarCount,
                a.FiveDollarCount + b.FiveDollarCount,
                a.TwentyDollarCount + b.TwentyDollarCount);

            return sum;
        }

        public static Money operator -(Money a, Money b)
        {
            Money sum = new(
                a.OneCentCount - b.OneCentCount,
                a.TenCentCount - b.TenCentCount,
                a.QuarterCount - b.QuarterCount,
                a.OneDollarCount - b.OneDollarCount,
                a.FiveDollarCount - b.FiveDollarCount,
                a.TwentyDollarCount - b.TwentyDollarCount);

            return sum;
        }


        protected override bool EqualsCore(Money other)
        {
            return OneCentCount == other.OneCentCount &&
                TenCentCount == other.TenCentCount &&
                QuarterCount == other.QuarterCount &&
                OneDollarCount == other.OneDollarCount &&
                FiveDollarCount == other.FiveDollarCount &&
                TwentyDollarCount == other.TwentyDollarCount;
        }

        protected override int GetHashCodeCore()
        {
            unchecked
            {
                int hashCode = OneCentCount;
                hashCode = (hashCode * 397) ^ TenCentCount;
                hashCode = (hashCode * 397) ^ QuarterCount;
                hashCode = (hashCode * 397) ^ OneDollarCount;
                hashCode = (hashCode * 397) ^ FiveDollarCount;
                hashCode = (hashCode * 397) ^ TwentyDollarCount;
                return hashCode;
            }
        }

        public override string ToString()
        {
            if(Amount < 1)
            {
                return $"¢{(Amount * 100).ToString("0")}";
            }

            return $"${Amount.ToString("0.00")}";
        }
    }
}

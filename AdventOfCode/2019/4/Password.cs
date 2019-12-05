namespace AdventOfCode._2019._4
{
    public abstract class Password
    {
        protected readonly int[] Digits;

        protected Password(int[] digits)
        {
            var clone = (int[]) digits.Clone();

            for (var i = 0; i < clone.Length - 1; i++)
            {
                if (clone[i] > clone[i + 1])
                {
                    for (var j = i + 1; j < clone.Length; j++)
                    {
                        clone[j] = clone[i];
                    }

                    break;
                }
            }

            Digits = clone;
        }

        public int Value => int.Parse(string.Join(string.Empty, Digits));

        public void Increment()
        {
            for (var i = Digits.Length - 1; i >= 0; i--)
            {
                if (Digits[i] == 9)
                {
                    continue;
                }

                Digits[i]++;

                for (var j = i + 1; j < Digits.Length; j++)
                {
                    Digits[j] = Digits[i];
                }

                break;
            }
        }

        public abstract bool IsValid();
    }
}
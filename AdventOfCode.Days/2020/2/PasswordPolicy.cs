namespace AdventOfCode.Days._2020._2
{
    public class PasswordPolicy
    {
        public PasswordPolicy(int min, int max, char policyCharacter, string password)
        {
            Min = min;
            Max = max;
            PolicyCharacter = policyCharacter;
            Password = password;
        }

        public int Min { get; }
        public int Max { get; }
        public char PolicyCharacter { get; }
        public string Password { get; }
    }
}
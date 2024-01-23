using System.Collections.Generic;
using System.IO;

namespace Scripts
{
    public class Leaderboard
	{
		public const string leaderboardPath = "leaders.top";

		private static readonly ReverseComparer iNeedIt;

		public static int Score { get; set; }
		
		private List<int> leaders;

		public int Count => leaders.Count;

		public int this[int index]
		{
			get
			{
				return leaders[index];
			}
		}

		public void Load()
		{
			leaders = new();
			if (File.Exists(leaderboardPath))
			{
				using StreamReader reader = new(leaderboardPath);
				while (!reader.EndOfStream)
				{
					leaders.Add(int.Parse(reader.ReadLine()));
				}
			}
		}

		public void Save()
		{
			leaders.Insert(MyPosition(), Score);

			using StreamWriter writer = new(File.Create(leaderboardPath));
			foreach (int value in leaders)
			{
				writer.WriteLine(value);
			}
		}

		public int MyPosition()
		{
			for (int i = leaders.Count - 1; i >= 0; i--)
			{
				if (Score < leaders[i])
				{
					return i + 1;
				}
			}
			return 0;
        }

        private class ReverseComparer : IComparer<int>
        {
            public int Compare(int x, int y)
            {
				return y.CompareTo(x);
            }
        }
    }
}
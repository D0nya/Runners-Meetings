using System;
using System.Collections.Generic;
using System.Linq;

namespace RunnersMeetings
{
  public class Program
  {
    static void Main()
    {
      Kata k = new Kata();
      Console.WriteLine(k.RunnersMeetings(new int[] { 1, 4, 2 }, new int[] { 27, 18, 24 }));
    }
  }

  public class Kata
  {
    public int RunnersMeetings(int[] StartPosition, int[] speed)
    {
      int result = 1;
      int distDiff, speedDiff, cnt, meetingPoint;
      for (int i = 0; i < StartPosition.Length; i++)
      {
        for (int j = i + 1; j < StartPosition.Length; j++)
        {
          distDiff = Math.Abs(StartPosition[j] - StartPosition[i]);
          speedDiff = Math.Abs(speed[i] - speed[j]);
          if (speedDiff <= 0 && distDiff != 0)
            continue;

          meetingPoint = StartPosition[i] * speedDiff + speed[i] * distDiff;
          cnt = 0;

          for (int k = 0; k < StartPosition.Length; k++)
          {
            if (StartPosition[k] * speedDiff + speed[k] * distDiff == meetingPoint)
              cnt++;
          }
          if (cnt == 0)
            continue;
          if (cnt > result)
            result = cnt;
        }
      }
      if (result < 2)
        result = -1;
      return result;
    }
  }
}
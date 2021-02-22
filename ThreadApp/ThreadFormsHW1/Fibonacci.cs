namespace ThreadFormsHW1
{
    public class Fibonacci : NumberType
    {
        protected override void _generate(object obj)
        {
            if (obj is int[] arr && arr.Length == 2 && arr[0] < arr[1] && _stopped is false)
            {
                int max = arr[1];
                int min = arr[0];

                int i2 = 1, j2 = 1;

                if (min > 1)
                {
                    for (int i = 1, j = 1; i <= min; i += j)
                    {
                        i2 = i;
                        j2 = j = i - j;
                    }

                    if (i2 != min) i2 += j2;
                }

                for (int i = i2, j = j2; i <= max;)
                {
                    _syncContext.Send(e => _trigger(new Response(i)), null);
                    j = i - j;

                    if (i + j > 0) i += j;
                    else break;
                }
            }
            Stop();
        }
    }
}

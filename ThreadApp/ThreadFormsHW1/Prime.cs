namespace ThreadFormsHW1
{
    public class Prime : NumberType
    {
        protected override void _generate(object obj)
        {
            if (obj is int[] arr && arr.Length == 2 && arr[0] < arr[1] && _stopped is false)
            {
                int max = arr[1];

                int min = arr[0] <= 2 ? 2 : arr[0];
                if (min == 2) _syncContext.Send(e => _trigger(new Response(min++)), null);
                
                if (min % 2 == 0) min++;

                for (int i = min; i <= max && _stopped is false; i+=2)
                {
                    bool isPrime = true;

                    for (int j = 3; j < i / 2 && _stopped is false; j+=2)
                    {
                        if (i % j == 0)
                        {
                            isPrime = false;
                            break;
                        }
                    }

                    if (isPrime) _syncContext.Send(e => _trigger(new Response(i)), null);

                    //if (i > 10000) Stop();
                }
            }
            Stop();
        }
    }
}

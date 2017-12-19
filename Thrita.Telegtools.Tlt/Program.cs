using System;
using System.Threading.Tasks;

namespace Thrita.Telegtools.Tlt
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //var callTask = Task.Run(() => CallTL());
                var callTask = Task.Run(() =>  new ChannelTools().GatherChannelHistory("K1 in USA"));
                callTask.Wait();

                Console.WriteLine("THE END!");
#if DEBUG
                Console.WriteLine("Press a key.");
                Console.ReadKey();
#endif
            }
            catch (Exception ex)  //Exceptions here or in the function will be caught here
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
        }
    }
}

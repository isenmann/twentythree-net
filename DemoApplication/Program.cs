using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwentyThreeNet;

namespace DemoApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            TwentyThree twentyThree = new TwentyThree("DEMOKEY","DEMOSHARED");

            // Getting the frob and calculate the URL
            string frob = twentyThree.AuthGetFrob();
            string url = twentyThree.AuthCalcUrl(frob, AuthLevel.Delete);

            // Pointing the user to the URL with its standard browser
            Process p = Process.Start(url);
            p.WaitForExit();

            // Get the authentication token to access 23, remember this for all other methods
            Auth auth = twentyThree.AuthGetToken(frob);
            string token = auth.Token;
        }
    }
}

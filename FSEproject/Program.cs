using System;
using System.Net.Http;
using System.Numerics;
using Newtonsoft.Json;
using System.Threading.Tasks;


namespace FSEproject
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            await Assignment2.GetResponses();
        }
    }
}
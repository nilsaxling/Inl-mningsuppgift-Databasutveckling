using Inlämningsuppgift_Databasutveckling.Data;

namespace Inlämningsuppgift_Databasutveckling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataAccess dataAccess = new DataAccess();

            dataAccess.Seed();
        }
    }
}
using System.Collections;
using MathNet.Numerics;
using MathNet.Numerics.Distributions;

class Simulation 
{
    public static void Main(string[] args)
    {
        
        Random rnd = new Random();
        CustomerQueue customerQueue = new CustomerQueue();
        Staff staff = new Staff ();

        int MaxSimTime = 8 * 60; // Later tambah 8 * 60 minutes
        int StartTime = 0;
        int timeCustomerArrival = rnd.Next() % 10;
        int ServiceTime = 0;
        bool ServerFree = true;

        int CustomerQueue = 0;

        // Start simulation
        while (StartTime <= MaxSimTime)
        {
            Console.WriteLine("\nTime: " + StartTime);

            if (timeCustomerArrival <= 0)
            {
                Console.WriteLine("Customer arrived!");
                Customer customer = new Customer(rnd.Next());
                customerQueue.Push(customer);
                timeCustomerArrival = (int) Exponential.Sample(0.1);
                CustomerQueue++;
            }

            if (ServerFree == true && customerQueue.NumCustomers() > 0)
            {
                Customer customer = customerQueue.Pop();
                staff.ReceivePayment(customer.getID());
                ServiceTime = (int) Normal.Sample(10, 5);
                ServerFree = false;

            }

            if (ServerFree == false)
            {
                ServiceTime--;
                Console.WriteLine("\nService Time : " + ServiceTime);
                if (ServiceTime == 0) 
                {
                    ServerFree = true;
                }
            }

            Console.WriteLine("Customer Time Arrival: " + timeCustomerArrival);
            Console.WriteLine("Queue Size: " + customerQueue.NumCustomers());
            timeCustomerArrival--;
            StartTime++;
        }
        Console.WriteLine("\nNumber of customers today : " + CustomerQueue);
        Console.WriteLine("Average queue length : " +  ((float) CustomerQueue /  MaxSimTime));
        Console.WriteLine("Total profit received : " + staff.GetTotalProfit());
        
    }

}

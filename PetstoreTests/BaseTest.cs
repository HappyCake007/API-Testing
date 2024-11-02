using RestSharp;
using NUnit.Framework;

namespace PetstoreTests;

public class Inventory                                                              
{
    public int Sold { get; set; }
    public int Pending { get; set; }
    public int Available { get; set; }
}

public class BaseTest
{
    protected RestClient client;

    [SetUp]
    public void Initialise()
    {
        client = new RestClient("http://localhost:8080/api");
    }
    public Inventory GetInventory()                                                 
    {
        var request = new RestRequest("/store/inventory");
        return client.GetAsync<Inventory>((request)).GetAwaiter().GetResult();      
    }
}
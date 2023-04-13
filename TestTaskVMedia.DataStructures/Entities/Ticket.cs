namespace TestTaskVMedia.DataStructures;

using Entities;

public class Ticket
{
    public int Id { get; set; }
    public int PassengerId { get; set; }
    public Passenger Passenger { get; set; }
    public int TrainId { get; set; }
    public Train Train { get; set; }
    public DateTime DepartureTime { get; set; }
    public DateTime ArrivalTime { get; set; }
    public decimal Price { get; set; }
}
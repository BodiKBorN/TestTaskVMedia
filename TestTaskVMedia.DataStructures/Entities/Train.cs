namespace TestTaskVMedia.DataStructures.Entities;

public class Train
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Origin { get; set; }
    public string Destination { get; set; }
    public ICollection<Ticket> Tickets { get; set; }
}
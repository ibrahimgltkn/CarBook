namespace CarBook.Domain.Entities;

public class Location
{
    public int LocationID { get; set; }
    public string Name { get; set; }
    public List<RentACar> RentACars { get; set; }
}

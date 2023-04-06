namespace CityInfo_1.Models
{
    public class CityDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

        public int NumberofPointsofInterest
        {
            get
            {
                return PointsOfInterest.Count;
            }
        }
        public ICollection<PointofInterestDto> PointsOfInterest { get; set; }
        = new List<PointofInterestDto>();
    }
}

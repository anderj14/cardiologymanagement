namespace Core.Entities
{
    public class SurgeryFollowUp: BaseEntity
    {
        public DateTime FollowUpDate { get; set; }
        public string FollowUpNotes { get; set; }
        public string Complications { get; set; }
        public string FollowUpComplete { get; set; }

        // Relación con la entidad Surgery
        public int CardiologySurgeryId { get; set; }
        public CardiologySurgery CardiologySurgery { get; set; }
    }
}
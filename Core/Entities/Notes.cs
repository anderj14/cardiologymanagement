namespace Core.Entities
{
    public class Notes : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public int NoteStatusId { get; set; }
        public NoteStatus NoteStatus { get; set; }
    }
}
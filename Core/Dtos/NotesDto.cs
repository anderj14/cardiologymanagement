namespace Core.Dtos
{
    public class NotesDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public string NoteStatus { get; set; }
    }
}
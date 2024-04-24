namespace Misericordia.Models{
    public class Attention{
        public int Id { get; set; }
        public int AttentionPreference { get; set; }
        public string NumAttention { get; set; }
        public int EndingAttention { get; set; }
        public int UserId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime DateAttention { get; set; }
    }
}
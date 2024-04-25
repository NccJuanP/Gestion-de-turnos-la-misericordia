namespace misericordia.Models
{
    public class Attention
    {
        public int Id { get; set; }
        public int AttentionPreference { get; set; }
        public string NumAttention { get; set; }
        public int UserId { get; set; }
        public int EmployeeId { get; set; }
        public int EndingAttention { get; set; }
        public DateTime DateAttentionExit { get; set; }
        public DateTime DateAttentionEnter { get; set; }
    }
}
namespace Tasks.Domain.Task
{
    public class Task
    {
        public Guid Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public Boolean Done { get; set; }
        public virtual User.User AssignedTo { get; set; }
        public virtual Board.Board Board { get; set; }

    }
}

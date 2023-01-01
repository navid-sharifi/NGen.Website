namespace NGen
{
    public partial class User : BaseEntity
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Roles { get; set; }
		public string Family { get; set; }
		public string Description { get; set; }
	}
    
    public partial class File : BaseEntity
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public long CreateDateTime { get; set; }
        public User Creator { get; set; }
        public Guid CreatorId { get; set; }

    }
    public partial class Folder : BaseEntity
    {
        public string Name { get; set; }
        public string Type { get; set; }
		public long CreateDateTime { get; set; }
		public User Creator { get; set; }
		public Guid CreatorId { get; set; }
		public Folder? Father { get; set; }
		public Guid? FatherId { get; set; }
	}
}

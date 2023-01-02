using Microsoft.AspNetCore.Http;

namespace NGen
{
    public partial class File : BaseEntity
    {
        public IFormFile Source { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public long CreateDateTime { get; set; }
        public User Creator { get; set; }
        public Guid CreatorId { get; set; }
		public Folder? Folder { get; set; }
		public Guid? FolderId { get; set; }

	}
}

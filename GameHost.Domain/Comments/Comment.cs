using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHost.Domain.Comments
{
    public class Comment
    {
        public Guid CommentId { get; set; }
        public Guid EventId { get; set; }
        public Guid UserId { get; set; }
        public string TextContent { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModified { get; set; }
    }
}

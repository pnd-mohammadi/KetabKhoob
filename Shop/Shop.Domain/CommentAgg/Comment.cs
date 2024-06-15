using Common.Domain;
using Common.Domain.Exceptions;
using Shop.Domain.CommentAgg.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.CommentAgg
{
    public class Comment : AggregateRoot
    {
        public Comment(long userId, long productId, string text)
        {
            Guard(text);
            UserId = userId;
            ProductId = productId;
            Text = text;
            Status = CommentStatus.Pending;
        }

        public long UserId { get; private set; }
        public long ProductId { get; private set; }
        public string Text { get; private set; }
        public CommentStatus Status { get; private set; }
        public DateTime UpdateTime { get; private set; }

        public void Edit( string text)
        {
            Guard(text);
            Text = text;
            UpdateTime= DateTime.Now;
        }
        public void ChangeStatus(CommentStatus status)
        {
            Status = status;
            UpdateTime= DateTime.Now;

        }
        public void Guard(string text)
        {
            NullOrEmptyDomainDataException.CheckString(text,nameof(text));
        }

    }
}

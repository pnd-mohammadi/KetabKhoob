﻿using Shop.Domain.CommentAgg;
using Shop.Infrastructure._Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Persistent.Ef.CommentAgg
{
    public class CommentRepository : BaseRepository<Comment>, ICommentRepository
    {
        public CommentRepository(ShopContext context) : base(context)
        {
        }

        public async Task DeleteAndSave(Comment comment)
        {
            Context.Remove(comment);
            await Context.SaveChangesAsync();
        }
    }
}

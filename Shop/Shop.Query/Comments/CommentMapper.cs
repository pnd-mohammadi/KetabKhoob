using Shop.Domain.CommentAgg;
using Shop.Query.Comments.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.Comments;

internal static class CommentMapper
{
    public static CommentDto? Map(this Comment? comment)
    {
        if (comment == null)
            return null;
        return new CommentDto()
        {
            Id= comment.Id,
            Text=comment.Text,
            Status=comment.Status,
            ProductId=comment.ProductId,
            USerId=comment.UserId,
            CreationDate=comment.CreationDate
        };
    }
    public static CommentDto? MapFilterComment(this Comment comment)
    {
        if (comment == null)
            return null;
        return new CommentDto()
        {
            Id = comment.Id,
            Text = comment.Text,
            Status = comment.Status,
            ProductId = comment.ProductId,
            USerId = comment.UserId,
            CreationDate = comment.CreationDate
        };
    }
}

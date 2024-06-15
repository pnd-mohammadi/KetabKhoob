﻿using Common.Application;
using MediatR;
using Shop.Application.Comments.ChangeStatus;
using Shop.Application.Comments.Create;
using Shop.Application.Comments.Delete;
using Shop.Application.Comments.Edit;
using Shop.Query.Comments.DTOs;
using Shop.Query.Comments.GetByFilter;
using Shop.Query.Comments.GetById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Shop.Presentation.Facade.Comments
{
    internal class CommentFacade : ICommentFacade
    {
        private readonly IMediator _mediator;

        public CommentFacade(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<OperationResult> ChangeStatus(ChangeCommentStatusCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> CreateComment(CreateCommentCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> DeleteComment(DeleteCommentCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> EditComment(EditCommentCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<CommentDto?> GetCommentById(long id)
        {
            return await _mediator.Send(new GetCommentByIdQuery(id));
        }

        public async Task<CommentFilterResult> GetCommentsByFilter(CommentFilterParams filterParams)
        {
            return await _mediator.Send(new GetCommentByFilterQuery(filterParams));
        }
    }
}

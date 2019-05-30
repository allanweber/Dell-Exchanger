﻿using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exchanger.Domain.CommandHandlers.Commands.Assignment;
using Exchanger.Domain.Dtos;
using Exchanger.Domain.Entities;
using Exchanger.Domain.Repositories;
using Exchanger.Framework.Constants;
using Exchanger.Framework.Controllers;

namespace Exchanger.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/[Controller]")]
    [EnableCors(AppConstants.ALLOWALLHEADERS)]
    public class AssignmentController :
        BaseCrudController<
            IAssignmentRepository,
            Assignment,
            AssignmentInsertCommand,
            AssignmentUpdateCommand,
            AssignmentDeleteCommand,
            AssignmentDto>
    {
        public AssignmentController(IMapper mapper, IMediator mediator, IAssignmentRepository assignmentRepository)
            : base(mapper, mediator, assignmentRepository)
        {
            AssignmentRepository = assignmentRepository;
        }

        public IAssignmentRepository AssignmentRepository { get; }

        [HttpGet]
        [Route("project/{projectId:int}")]
        public async Task<IActionResult> GetByProject(int projectId)
        {
            var tasks = await this.AssignmentRepository.GetAllByProject(projectId);

            var dto = this.Mapper.Map<IEnumerable<AssignmentDto>>(tasks);

            return Ok(dto);
        }

        [HttpGet]
        [Route("{assignmentId:int}/done")]
        public async Task<IActionResult> Done(int assignmentId)
        {
            var doneDate = await this.AssignmentRepository.DoneAssignment(assignmentId);

            return Ok(doneDate);
        }
    }
}
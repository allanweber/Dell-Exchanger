﻿using AutoMapper;
using System;
using Exchanger.Domain.CommandHandlers.Commands.Assignment;
using Exchanger.Domain.CommandHandlers.Commands.Project;
using Exchanger.Domain.Entities;

namespace Exchanger.Infrastructure.Mappers
{
    public class DtoToEntities: Profile
    {
        public DtoToEntities()
        {
            this.CreateMap<ProjectInsertCommand, Project>();
            this.CreateMap<ProjectUpdateCommand, Project>();

            this.CreateMap<AssignmentInsertCommand, Assignment>()
                .ForMember(entity => entity.DueDate, source => source.MapFrom(from => DateTime.Parse(from.DueDate)));
            this.CreateMap<AssignmentUpdateCommand, Assignment>();
        }
    }
}

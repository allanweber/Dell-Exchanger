using System;
using System.Linq.Expressions;
using Exchanger.Domain.Entities;
using Exchanger.Framework.Specifications;

namespace Exchanger.Domain.Specifications
{
    public class AssignmentsLateByProjectId : BaseSpecification<Assignment>
    {
        public AssignmentsLateByProjectId(int projectId)
        {
            ProjectId = projectId;
        }

        public override string Description => string.Empty;

        public int ProjectId { get; }

        protected override Expression<Func<Assignment, bool>> GetFinalExpression()
            => assignment => assignment.ProjectId == this.ProjectId 
            && assignment.DueDate.Day < DateTime.Now.Day;
    }
}

﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using Exchanger.Api;
using Exchanger.Domain.CommandHandlers.Commands.Project;
using Exchanger.Domain.Dtos;
using Exchanger.Framework.CommandHandlers;
using Exchanger.Framework.Test;

namespace Exchanger.Test
{
    public class ProjectTest : IClassFixture<WebHostFixture<Startup>>
    {
        public ProjectTest(WebHostFixture<Startup> webHostFixture)
        {
            WebHostFixture = webHostFixture;
        }

        public WebHostFixture<Startup> WebHostFixture { get; }

        private string path = "api/v1/Project";

        [Fact]
        public async Task test_insert_update_delete_projects()
        {
            var insert = new ProjectInsertCommand
            {
                Name = "Projeto 1"
            };

            await this.insertProject(insert, HttpStatusCode.OK);
            var content = await this.insertProject(insert, HttpStatusCode.BadRequest);
            var command = await content.ReadAsObjectAsync<FailureResult>();
            Assert.False(command.IsSuccess, "Sucesso deveria ser falso");
            Assert.True(command.IsFailure, "Falha deveria ser true");

            insert = new ProjectInsertCommand
            {
                Name = "Projeto 2"
            };
            await this.insertProject(insert, HttpStatusCode.OK);

            ProjectUpdateCommand update = new ProjectUpdateCommand
            {
                Id = 1,
                Name = "Projeto Um"
            };
            await this.updateProject(update, HttpStatusCode.OK);

            update = new ProjectUpdateCommand
            {
                Id = 2,
                Name = "Projeto Um"
            };
            content = await this.updateProject(update, HttpStatusCode.BadRequest);
            command = await content.ReadAsObjectAsync<FailureResult>();
            Assert.False(command.IsSuccess, "Sucesso deveria ser falso");
            Assert.True(command.IsFailure, "Falha deveria ser true");

            var getall = await this.getAllProjects();
            Assert.True(getall.Count == 2, $"Get all deveria ter 2 registros mas tinha {getall.Count}");

            ProjectDeleteCommand delete = new ProjectDeleteCommand
            {
                Id = 2
            };
            var res = await this.WebHostFixture.TestClient.DeleteAsync($"{this.path}/2");
            Assert.True(res.StatusCode == HttpStatusCode.OK, await res.Content.ReadAsStringAsync());

            getall = await this.getAllProjects();
            Assert.True(getall.Count == 1, $"Get all deveria ter 1 registro mas tinha {getall.Count}");
        }

        private async Task<HttpContent> insertProject(ProjectInsertCommand postObj, HttpStatusCode statusExpected)
        {
            var httpResponse = await this.WebHostFixture.TestClient.PostAsObjectAsync(this.path, postObj);
            Assert.True(httpResponse.StatusCode == statusExpected, await httpResponse.Content.ReadAsStringAsync());
            return httpResponse.Content;
        }

        private async Task<HttpContent> updateProject(ProjectUpdateCommand updateObj, HttpStatusCode statusExpected)
        {

            var httpResponse = await this.WebHostFixture.TestClient.PutAsObjectAsync(this.path, updateObj);
            Assert.True(httpResponse.StatusCode == statusExpected, await httpResponse.Content.ReadAsStringAsync());
            return httpResponse.Content;
        }

        private async Task<IList<ProjectDto>> getAllProjects()
        {
            var httpResponse = await this.WebHostFixture.TestClient.GetAsync(this.path);
            Assert.True(httpResponse.StatusCode == HttpStatusCode.OK, await httpResponse.Content.ReadAsStringAsync());
            return await httpResponse.Content.ReadAsObjectAsync<IList<ProjectDto>>();
        }
    }
}

using System;
using NUnit.Framework;
using Kanbanize.KanbanizeRestClient;
using System.Net.Http;
using System.Net;

namespace Kanbanize.Tests
{
    public class Tests : Setup
    {
        [Test]
        public void ApiKeyIsReturned()
        {
            Assert.IsTrue(_apiKey != null);
        }

        [Test]
        public void VerifyTaskhasBeenCreated()
        {
            _client = new Rest();
            _task = _client.CreateTaskWithBoardId();
            _response = _client.PostNewTask(_apiKey, _task);
            Assert.That(_task.assignee == "Mitaka");
            Assert.IsTrue(_response.StatusCode == HttpStatusCode.OK);
        }

        [Test]
        public void VerifyTaskHasBeenCreatedWithCorrectParameters()
        {
            _client = new Rest();
            _task = _client.CreateTaskWithBoardId();
            _response = _client.PostNewTask(_apiKey, _task);
            Assert.That(_task.title == "Test task" && _task.description == "To do list");
            Assert.That(_task.assignee == "Mitaka" && _task.priority == "High");
            Assert.That(_task.column == "Requested" && _task.boardid == "1");
            Assert.IsTrue(_response.StatusCode == HttpStatusCode.OK);
        }

        [Test]
        public void VerifyTaskHasBeenCreatedInCorrectColumn()
        {
            _client = new Rest();
            _task = _client.CreateTaskWithBoardId();
            _response = _client.PostNewTask(_apiKey, _task);
            NUnit.Framework.Assert.That(_task.column == "Requested");
            Assert.IsTrue(_response.StatusCode == HttpStatusCode.OK);
        }

        [Test]
        public void VerifyTaskHasBeenMoved()
        {
            _client = new Rest();
            _task = _client.CreateTaskWithBoardIdAndTaskId();
            _task.column = "Requested";
            _response = _client.PostNewTask(_apiKey, _task);
            var currentId = _response.Content.Split(':', StringSplitOptions.None).Last().Trim('}');
            _task.taskid = currentId;
            _response = _client.MoveTask(_apiKey, _task);
            Assert.That(_task.column == "Requested");
            Assert.IsTrue(_response.StatusCode == HttpStatusCode.OK);
        }

        [Test]
        public void VerifyTaskBasBeenDeleted()
        {
            _client = new Rest();
            _task = _client.CreateTaskWithBoardIdAndTaskId();
            _response = _client.PostNewTask(_apiKey, _task);
            var currentId = _response.Content.Split(':', StringSplitOptions.None).Last().Trim('}');
            _task.taskid = currentId;
            _response = _client.DeleteTask(_apiKey, _task);
            Assert.IsTrue(_response.StatusCode == HttpStatusCode.OK);
        }
    }
}

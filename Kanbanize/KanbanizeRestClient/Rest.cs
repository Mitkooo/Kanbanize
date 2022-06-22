using RestSharp;
using Kanbanize.Helpers;
using Kanbanize.DTOs.KanbanizeTask;
using Kanbanize.Builders.UserBuilder;
using Kanbanize.Builders.TaskBuilder;
using Kanbanize.DTOs.User;

namespace Kanbanize.KanbanizeRestClient
{
    public class Rest
    {
        public string GetApiKey()
        {
            RestClient client = new RestClient(Helper.BaseUrl + Helper.Login);
            RestRequest request = new RestRequest();
            request.Method = Method.Post;
            var currentUser = CreateUser();
            request.AddBody(currentUser);
            RestResponse response = client.Execute(request);
            var apiKey = response.Content.Split(new string[] { "\":\"" }, StringSplitOptions.None).Last().Split("\"").First();
            return apiKey;
        }

        public RestResponse PostNewTask(string apiKey, object currentTask)
        {
            var client = new RestClient(Helper.BaseUrl + Helper.CreateTask);
            var request = new RestRequest();
            request.Method = Method.Post;
            request.AddHeader("apiKey", apiKey);
            request.AddJsonBody(currentTask);
            var response = client.Execute(request);
            return response;
        }

        public RestResponse DeleteTask(string apiKey, object currentTask)
        {
            var client = new RestClient(Helper.BaseUrl + Helper.DeleteTask);
            var request = new RestRequest();
            request.Method = Method.Post;
            request.AddHeader("apiKey", apiKey);
            request.AddJsonBody(currentTask);
            var response = client.Execute(request);
            return response;
        }

        public RestResponse MoveTask(string apiKey, object currentTask)
        {
            var client = new RestClient(Helper.BaseUrl + Helper.MoveTask);
            var request = new RestRequest();
            request.Method = Method.Post;
            request.AddHeader("apiKey", apiKey);
            request.AddJsonBody(currentTask);
            var response = client.Execute(request);
            return response;
        }

        public KanbanizeTask CreateTaskWithBoardIdAndTaskId()
        {
            var builder = new TaskBuilder();
            var user = builder.DefaultTaskWithColumn().Build();
            return user;
        }

        //public KanbanizeTask CreateDefaultTask()
        //{
        //    var builder = new TaskBuilder();
        //    var task = builder.DefaultTask().Build();
        //    return task;
        //}
        public KanbanizeTask CreateTaskWithBoardId()
        {
            var builder = new TaskBuilder();
            var task = builder.DefaultTaskWithBoardId().Build();
            return task;
        }

        public User CreateUser()
        {
            var builder = new UserBuilder();
            var user = builder.DefaultUser().Build();
            return user;
        }
    }
}

using System;

namespace Kanbanize.Helpers
{
    public class Helper
    {
        public static string BaseUrl = "https://testcorporation.kanbanize.com/index.php/api/kanbanize/";
        public static string Login = "login/format/json";
        public static string CreateTask = "/create_new_task/format/json";
        public static string MoveTask = "move_task/format/json";
        public static string DeleteTask = "delete_task/format/json";
    }
}

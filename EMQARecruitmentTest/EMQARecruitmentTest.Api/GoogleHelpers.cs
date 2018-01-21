using System;
using System.Collections.Generic;
using System.IO;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Tasks.v1;
using Google.Apis.Tasks.v1.Data;

namespace EMQARecruitmentTest.Api
{
    public class GoogleHelpers
    {
        /// <summary>
        /// Connect to the Google API using the Service-to-Service method
        /// </summary>
        /// <returns>The authentication credentials</returns>
        private ICredential ConnectToGoogleApi()
        {
            using (var stream = new FileStream(Path.Combine(TestFolders.InputFolder, "client_secrets.json"), FileMode.Open, FileAccess.Read))
            {
                //return ServiceAccountCredential.FromServiceAccountData(stream);
                return GoogleCredential.FromStream(stream).CreateScoped(TasksService.Scope.Tasks);
            }
        }

        /// <summary>
        /// Connected to the specific task api
        /// </summary>
        /// <returns>A task service for running actions against</returns>
        public TasksService ConnectToTaskService()
        {
            // Create the service.
            return new TasksService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = ConnectToGoogleApi(),
                ApplicationName = "EuroMoneyQATest"
            });
        }

        /// <summary>
        /// Creates a standard task list, using the current date and time as a unique identifier
        /// </summary>
        /// <returns>The created task list</returns>
        public TaskList CreateTaskList()
        {
            var standardName = $"StandardTaskList{DateTime.UtcNow.ToString("yyyyMMddhhmmssffff")}";
            var taskService = ConnectToTaskService();
            var taskList = new TaskList();
            taskList.Title = standardName;

            // Act
            // Create the task list
            // add the date and time to the name, so the task can be repeated
            return taskService.Tasklists.Insert(taskList).Execute();
        }

        /// <summary>
        /// Gets the requested task list
        /// </summary>
        /// <param name="taskListId">The Id of the task list to retrieve</param>
        /// <returns>The task list</returns>
        public TaskList GetTaskList(string taskListId)
        {
            return ConnectToTaskService().Tasklists.Get(taskListId).Execute();
        }

        /// <summary>
        /// Creates a set of tasks against a task list, using an index as a unique identifier.
        /// </summary>
        /// <param name="taskList">The task list to create the tasks against</param>
        /// <param name="number">the number of tasks to create.</param>
        /// <returns></returns>
        public IEnumerable<Task> CreateStandardTasks(TaskList taskList, int number)
        {
            for (int i = 0; i < 3; i++)
            {
                var task = new Task
                {
                    Title = $"{taskList.Title}-TestTask{i}"
                };
                yield return ConnectToTaskService().Tasks.Insert(task, taskList.Id).Execute();
            }
        }

        /// <summary>
        /// Get the tasks associated with a task list
        /// </summary>
        /// <param name="taskList">The task list to get the tasks for</param>
        /// <returns>A list of the tasks</returns>
        public IList<Task> GetTasks(TaskList taskList)
        {
            return ConnectToTaskService().Tasks.List(taskList.Id).Execute().Items;
        }
    }
}

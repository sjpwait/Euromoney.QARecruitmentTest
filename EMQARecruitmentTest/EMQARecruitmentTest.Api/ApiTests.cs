using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Google.Apis.Tasks.v1.Data;
using NUnit.Framework;

namespace EMQARecruitmentTest.Api
{
    [TestFixture]
    public class ApiTests
    {
        GoogleHelpers google = new GoogleHelpers();

        [Test]
        public void CreateNewTaskList()
        {
            // Assemble
            var expectedTaskListName = $"TestTaskList{DateTime.UtcNow.ToString("yyyyMMddhhmmssffff")}";

            // Create a task service
            var taskService = google.ConnectToTaskService();
            var taskList = new TaskList();
            taskList.Title = expectedTaskListName;

            // Act
            // Create the task list
            // add the date and time to the name, so the task can be repeated
            var created = taskService.Tasklists.Insert(taskList).Execute();


            // Assert
            // Ensure that the task is created using ID of the created task
            var actualTaskLists = taskService.Tasklists.Get(created.Id).Execute();
            // TODO: Add your API test code here
            actualTaskLists.Title.Should().Be(expectedTaskListName);
            actualTaskLists.Id.Should().Be(created.Id);
        }

        [Test]
        public void CreateTasksInTaskList()
        {
            // Assemble
            var taskList = google.CreateTaskList();

            var tasks = new List<Task>();
            for (int i = 0; i < 3; i++)
            {
                tasks.Add(new Task
                {
                    Title = $"{taskList.Title}-TestTask{i}"
                });
            }

            // Act
            var taskService = google.ConnectToTaskService();
            foreach (var task in tasks)
            {
                taskService.Tasks.Insert(task, taskList.Id).Execute();
            }

            // Assert
            var actualTaskList = google.GetTaskList(taskList.Id);

            var actualTasks = taskService.Tasks.List(taskList.Id).Execute();
            // Check the count of items
            actualTasks.Items.Count.Should().Be(tasks.Count);

            // Check the title of the tasks created
            actualTasks.Items.Select(t => t.Title).ShouldBeEquivalentTo(tasks.Select(y => y.Title));
        }

        [Test]
        public void MarkTaskAsComplete()
        {
            // Assemble
            var taskList = google.CreateTaskList();
            var tasks = google.CreateStandardTasks(taskList, 3);

            // Act
            // Get the 2nd task (index 1)
            var taskToComplete = tasks.ToList()[1];
            taskToComplete.Status = "completed";

            var taskService = google.ConnectToTaskService();
            taskService.Tasks.Update(taskToComplete, taskList.Id, taskToComplete.Id).Execute();

            // Assert

            var updatedTasks = google.GetTasks(taskList);
            // Complete List
            var completedTasks = updatedTasks.Where(t => t.Completed != null);
            completedTasks.Count().Should().Be(1);
            completedTasks.Single().Id.Should().Be(taskToComplete.Id);

            // Incomplete List
            var incompleteTasks = updatedTasks.Where(t => t.Completed == null);
            incompleteTasks.Count().Should().Be(2);
            incompleteTasks.All(a => a.Id != taskToComplete.Id).Should().BeTrue();
        }

        [Test]
        public void MarkTaskAsDeleted()
        {
            // Assemble
            var taskList = google.CreateTaskList();
            var tasks = google.CreateStandardTasks(taskList, 3);

            // Act
            // Get the 2nd task (index 1)
            var taskToDelete = tasks.ToList()[1];

            var taskService = google.ConnectToTaskService();
            taskService.Tasks.Delete(taskList.Id, taskToDelete.Id).Execute();

            // Assert

            var updatedTasks = google.GetTasks(taskList);
            // Deleted Tasks List
            var deletedTasks = updatedTasks.Where(t => t.Deleted != null);
            deletedTasks.Count().Should().Be(0);

            // not Delete Tasks List
            updatedTasks.Count().Should().Be(2);
            updatedTasks.All(a => a.Id != taskToDelete.Id).Should().BeTrue();
        }
    }
}

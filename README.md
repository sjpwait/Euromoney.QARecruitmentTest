## Intro

This test is made up of two parts, a UI test and an APi test. 

---

## UI Test

Using C# write automated functional tests for the following user stories using Selenium WebDriver and Specflow with the use of page object where possible
- The site to test is http://www.euromoneyplc.com/
- Selenium Webdriver and NUnit must be used via Nuget packages.
- Other useful Nuget libraries may also be used.
- We have created blank project with all Nuget packages inside, so fill free to fork it. 
- Any browser can be used for the purpose of this task.


---

### Story 1

As a **user**  
I want to **click the ‘who we are’ --> ‘management team’ menu item**  
So that **we can see that the correct page is displayed**  


#### Acceptance criteria

- Management team page is displayed correctly
- Verify that all team members have Name, Job Title, Picture and description.


---

### Story 2

As a **user**  
I want to **go to the ‘Our Portfolio’ --> ‘Pricing, data and market intelligence’ menu item**  
So that **I can open the IJ Global website and see the latest news section**  


#### Acceptance criteria

- The ‘Specialist finance and economic data’ link is displayed correctly on the menu item
- The ‘VISIT IJ GLOBAL’ link navigates to https://ijglobal.com/
- The page title is ‘IJGlobal | Infrastructure Journal and Project Finance Magazine’
- The league table section is displayed on the home page


---

## API Test

Using Google Tasks API https://developers.google.com/google-apps/tasks/ write tests for the following scenarios using C#, NUnit.  


1. Create a new task list and check the new task list is returned by GET tasklists.  
2. Create three tasks in the new task list and check the new tasks are returned by GET tasklist.  
3. Mark one task as completed and check if the task is returned by GET tasklist.  
4. Delete another task and check if the task is not returned by GET tasklist. 
5. Mark the last task as hidden and check if the task is not returned by GET tasklist.  
6. Call tasks.clear and check if no tasks are returned by GET tasklist.  
7. Call GET tasklists with showhidden = true and showdeleted = true and check that all tasks a returned.  
8. Delete the tasklist and check if it is not returned by GET tasklists.  

# Task List

This simple console application gives the user the ability to create a task list ex. ("mow the lawn", "take out the trash"). The User can create a new task list or load a previously saved list. Items on the list can be "checked off", skipped, deleted, or added
to the bottom of the list again as a reminder. The program will always display the next "unchecked" item, but will self clean and delete checked off items that have no previous "unchecked" tasks before it. Users can then save their modified list to a save file.

## Getting Started

The following will show you how to run this simple program

### Prerequisites

You will need the latest version of Visual Studio 2019.


## Running the program

1. Open the program.cs.
2. Press F5 to run the program.
3. Users will be prompted to either create a New list or Load and existing list.

New
1. Enter a task, then press enter.
2. Repeat this step and enter as many separate tasks as you would like.
3. Type "done" when complete

Load
1. Select a load file: 1, 2, 3 and press Enter

TaskList Commands
1. Your task list will be displayed.
2. Use 'Z' and 'X' to navigate through your list.
3. Use 'B' and 'N' to navigate pages if your list exceeds 20 tasks.
4. Press 'C' to mark a task as complete. The task should change color.
5. Press 'R' to mark a task as complete, but re-add the task to the end of the list.
6. Press 'A' to add a new task.
7. Press 'D' to delete the currently selected task (Completed tasks will auto delete when there are no existing uncompleted tasks before it).

Save and Quit
1. Press 'Esc" to save or quit
2. Select a save file: 1, 2, 3 and press Enter (This will overwrite any file in the existing slot).
3. Type 'Q' and press 'Enter' to quit (this step can be taken before saving to skip the save step).

## Planned Future Improvements

1. Clean up formatting.
2. Allow users to change Page length.
3. Allow users to upload txt files from different paths
4.. Convert to a web application.

## Built With

Visual Studio 2019


## Authors

* **Jonathan Slack** - *Initial work* - [JMSlack](https://github.com/JMSlack)


## Acknowledgments

* An individual project during the Microsoft Software and Systems Academy

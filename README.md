The to do list app covers the followings :

1. The tasks must be longer than 10 characters (empty task is not allowed as well) Otherwise an error message is displayed.
   <img width="855" alt="image" src="https://github.com/Nimble-nerd/ToDoListApp/assets/155387191/5358d4e5-dc4d-4561-bc5e-d4ac8ac7d91e">

2. A deadline can be defined (on edit mode).
3. All tasks that are overdue will be marked in red.
4. The tasks are displayed in a table.
5. They can be deleted and marked as done (and reverted as undone as well)
6. The tasks are persisted in a data storage of your choice. (I have used in-memory provider of entity framework for the sake of simplicity)

To run the app, follow the following steps:

1. Run the web api (a .net 8 api)
2. Run the react app (npm run dev)
3. Download the file 'An example video of ToDoListApp' which demonstrates the usage of the app.


N.B: I have deliberately skipped implementing any cross-cutting concerns i.e. logging, security etc.



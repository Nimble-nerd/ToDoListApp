To run the app, follow the following steps:

1. Run the web api (a .net 8 api)
2. Run the react app (npm run dev)
3. Download the file 'An example video of ToDoListApp' which demonstrates the usage of the app.

   
The to do list app covers the followings :

1. The tasks must be longer than 10 characters (empty task is not allowed as well) Otherwise an error message is displayed.
   <img width="300" alt="image" src="https://github.com/Nimble-nerd/ToDoListApp/assets/155387191/b9d620b9-1897-43d2-8fa9-54f604bb81d0">
   <img width="300" alt="image" src="https://github.com/Nimble-nerd/ToDoListApp/assets/155387191/ab5a21fb-633b-4d81-b2bf-fe9c2ddc339c">
3. A deadline can be defined (on edit mode).   
   <img width="300" alt="image" src="https://github.com/Nimble-nerd/ToDoListApp/assets/155387191/b0f6e0dc-f5d5-44ee-a9e7-413e0294cbd3">
4. All tasks that are overdue will be marked in red.   
   <img width="300" alt="image" src="https://github.com/Nimble-nerd/ToDoListApp/assets/155387191/74fa1a96-11c6-4efe-aa3c-9d52aa39e60b">   
5. They can be deleted and marked as done (and reverted as undone as well)
   <img width="300" alt="image" src="https://github.com/Nimble-nerd/ToDoListApp/assets/155387191/35c432cf-0b82-466e-863e-684eadd5c94f">
6. The tasks are displayed in a table.   
   <img width="300" alt="image" src="https://github.com/Nimble-nerd/ToDoListApp/assets/155387191/8487fbb4-721b-469e-8b71-5a6e7a51fe50">
7. The tasks are persisted in a data storage of your choice. (I have used in-memory provider of entity framework for the sake of simplicity)


N.B: I have deliberately skipped implementing any cross-cutting concerns i.e. logging, security etc.



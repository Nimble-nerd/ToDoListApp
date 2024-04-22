import React, { createContext, useCallback, useEffect, useState } from 'react'
import { nanoid } from 'nanoid'
import axios from 'axios';
import toast from 'react-hot-toast';

interface TodoContextProps {
  todos: Todo[]
  addTodo: (text: string) => void
  deleteTodo: (id: string) => void
  editTodo: (id: string, text: string, deadline: Date | null) => void
  updateTodoStatus: (id: string, status: boolean) => void,
  getAllTodos: () => Promise<void>
  setTodos: React.Dispatch<React.SetStateAction<Todo[]>>
}

export interface Todo {
  id: string
  text: string
  deadline: Date | null | undefined
  status: boolean | undefined
}

export const TodoContext = createContext<TodoContextProps | undefined>(
  undefined,
)
export const TodoProvider = (props: { children: React.ReactNode }) => {
  const [todos, setTodos] = useState<Todo[]>([]);
  const urlBaseTodo = 'https://localhost:7184/api/v1'

  const getAllTodos = useCallback(async () => {
    await axios.get(`${urlBaseTodo}/todos`)
      .then(response => {
        setTodos(response.data);
      })
      .catch(error => {
        console.log(error);
      });
  }, [])

  useEffect(() => {
    getAllTodos();
  }, [getAllTodos]);
 
  const addTodo = async (text: string) => {

    const defaultDeadline = new Date();
    defaultDeadline.setDate(defaultDeadline.getDate() + 7); // default dealine is set to 7 days for the seek of simplicity

    const newTodo: Todo = {
      id: nanoid(),
      text,
      deadline: defaultDeadline,
      status: false,
    }
    await axios.post(`${urlBaseTodo}/todo`, newTodo)
      .then((response) => {
        if (response?.status === 201) {
          toast.success('Todo added successfully!')
        }
      });
    await getAllTodos();
  }

  const deleteTodo = async (id: string) => {
    await axios.delete(`${urlBaseTodo}/todo/${id}`)
      .then((response) => {
        if (response?.status === 204) {
          toast.success('Todo deleted successfully!')
        }
      });
    await getAllTodos();
  }

  const editTodo = async (id: string, text: string, deadline: Date | null) => {
    const status = todos.find(t => t.id == id)?.status;
    const updatedTodo: Todo = {
      id,
      text,
      deadline,
      status,
    }
    await axios.put(`${urlBaseTodo}/todo`, updatedTodo)
      .then((response) => {
        if (response?.status === 200) {
          toast.success('Todo item updated successfully!')
        }
      });

    await getAllTodos();
  }

  const updateTodoStatus = async (id: string, status: boolean) => {
    debugger;
    const updatedTodo = {
      id,
      status,
    }
    await axios.put(`${urlBaseTodo}/todo/status`, updatedTodo)
      .then((response) => {
        debugger;
        if (response?.status === 200) {
          toast.success('Todo status updated successfully!')
        }
      });

    await getAllTodos();
  }

  const value: TodoContextProps = {
    todos,
    addTodo,
    deleteTodo,
    editTodo,
    updateTodoStatus,
    getAllTodos,
    setTodos
  }

  return (
    <TodoContext.Provider value={value}>{props.children}</TodoContext.Provider>
  )
}
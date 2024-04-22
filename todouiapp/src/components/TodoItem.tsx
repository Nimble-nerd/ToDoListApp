
import { useEffect, useRef, useState } from 'react'
import { Todo } from '../context/TodoContext'
import { useTodo } from '../context/useTodo'
import { Input } from './Input'
import { BsCheck2Square } from 'react-icons/bs'
import { TbRefresh } from 'react-icons/tb'
import { FaRegEdit } from 'react-icons/fa'
import { RiDeleteBin7Line } from 'react-icons/ri'
import { toast } from 'react-hot-toast'
import cn from 'classnames'
import { motion } from 'framer-motion'
import DatePicker from "react-datepicker";
import "react-datepicker/dist/react-datepicker.css";

export const TodoItem = (props: { todo: Todo }) => {
  const { todo } = props

  const [editingTodoText, setEditingTodoText] = useState<string>('')
  const [editingTodoId, setEditingTodoId] = useState<string | null>(null)
  const [startDate, setStartDate] = useState<Date | null>(new Date());

  console.log(startDate)

  const { deleteTodo, editTodo, updateTodoStatus } = useTodo()

  const editInputRef = useRef<HTMLInputElement>(null)

  useEffect(() => {
    if (editingTodoId !== null && editInputRef.current) {
      editInputRef.current.focus()
    }
  }, [editingTodoId])

  const handleEdit = (todoId: string, todoText: string) => {
    setEditingTodoId(todoId)
    setEditingTodoText(todoText)

    if (editInputRef.current) {
      editInputRef.current.focus()
    }
  }

  const handleCancel = () => {
    setEditingTodoId(null)
    setEditingTodoText('')
  }
  const handleUpdate = (todoId: string) => {
    if (editingTodoText.trim() !== '') {

      if (editingTodoText.trim().length > 10) {
        toast.error('Item can not be more than 10 characters')
        return
      }

      editTodo(todoId, editingTodoText, startDate)
      setEditingTodoId(null)
      setEditingTodoText('')
    } else {
      toast.error('Todo field cannot be empty!')
    }
  }

  const handleDelete = (todoId: string) => {
    deleteTodo(todoId)
  }

  const handleStatusUpdate = (todoId: string, status: boolean) => {
    debugger;
    updateTodoStatus(todoId, status)
  }

  const divStyle = {
    marginTop: '10px'
  };
  const divMarginLeft = {
    marginLeft: '5px'
  };


  return (
    <motion.li
      layout
      key={todo.id}
      className={cn(
        'p-5 rounded-xl bg-zinc-900',
        todo.status === true && 'bg-opacity-50 text-zinc-500',
      )}
    >
      {editingTodoId === todo.id ? (

        <motion.div layout className="flex gap-2">
          <div>
            <div style={divStyle}>
              <label>Task name</label>
              <Input
                ref={editInputRef}
                type="text"
                value={editingTodoText}
                onChange={e => setEditingTodoText(e.target.value)}
              /></div>
            <div style={divStyle}>
              <label>Deadline</label> <br></br>
              <DatePicker
                className={cn(
                  'w-full px-5 py-2 bg-transparent border-2 outline-none border-zinc-600 rounded-xl placeholder:text-zinc-500 focus:border-white',
                )}
                selected={startDate} onChange={(date) => setStartDate(date)} />
            </div>
            <div style={divStyle}>
              <button
                className="px-5 py-2 text-sm font-normal text-orange-300 bg-orange-900 border-2 border-orange-900 active:scale-95 rounded-xl color:white"
                onClick={() => handleUpdate(todo.id)}
              >
                Update
              </button>
              <button style={divMarginLeft}
                className="px-5 py-2 text-sm font-normal text-orange-300 bg-orange-900 border-2 border-orange-900 active:scale-95 rounded-xl color:white padding-left:5px"
                onClick={() => handleCancel()}
              > Cancel
              </button>
            </div>
          </div>
        </motion.div>
      ) : (
        <div className="flex flex-col gap-5">
          <motion.span
            layout
            style={{
              textDecoration:
                todo.status === true ? 'line-through' : 'none',
            }}
          >
            <div style={{
              color: todo.deadline && new Date(todo.deadline) < new Date()
                ? 'red' : ''
            }}>{todo.text}</div>
          </motion.span>
          <div className="flex justify-between gap-5 text-white">
            <button onClick={() => {
              handleStatusUpdate(todo.id, !todo.status);
            }}>
              {todo.status === false ? (
                <span className="flex items-center gap-1">
                  <BsCheck2Square />
                  Mark Completed
                </span>
              ) : (
                <span className="flex items-center gap-1">
                  <TbRefresh />
                  Mark Undone
                </span>
              )}
            </button>
            <div className="flex items-center gap-2">
              <button
                onClick={() => handleEdit(todo.id, todo?.text)}
                className="flex items-center gap-1 "
              >
                <FaRegEdit />
                Edit
              </button>
              <button
                onClick={() => handleDelete(todo.id)}
                className="flex items-center gap-1 text-red-500"
              >
                <RiDeleteBin7Line />
                Delete
              </button>
            </div>
          </div>
        </div>
      )
      }
    </motion.li >
  )
}
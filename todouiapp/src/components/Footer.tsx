import { ToggleButton, ToggleButtonGroup } from "@mui/material";
import { useTodo } from "../context";
import { useState } from "react";
import axios from "axios";

export const Footer = () => {
  const { todos, setTodos, getAllTodos } = useTodo()
  const [alignment, setAlignment] = useState('all');
  const handleChange = (
    event: React.MouseEvent<HTMLElement>,
    newAlignment: string,
  ) => {
    setAlignment(newAlignment);
  };

  const urlBaseTodo = 'https://localhost:7184/api/v1'

  const getTodosByStatus = async (status: boolean) => {
    await axios.get(`${urlBaseTodo}/todos/${status}`)
      .then(response => {
        setTodos(response.data);
      })
      .catch(error => {
        console.log(error);
      });
  }

  const buttonStyle = {
    color: 'white'
  };
  return (

    <div className="flex justify-between gap-5 text-white">
      <div className="flex items-left gap-1">
        {todos?.length > 0 && <div className="flex items-center gap-1">{todos?.length} item(s)</div>}
      </div>

      <div className="flex items-right gap-1  text-white">
        <ToggleButtonGroup
          color="primary"
          value={alignment}
          exclusive
          onChange={handleChange}
          aria-label="Platform"
        >
          <ToggleButton value="all" style={buttonStyle} onClick={() => getAllTodos()}>All</ToggleButton>
          <ToggleButton value="active" style={buttonStyle} onClick={() => getTodosByStatus(false)} >Active</ToggleButton>
          <ToggleButton value="completed" style={buttonStyle} onClick={() => getTodosByStatus(true)}>Completed</ToggleButton>
        </ToggleButtonGroup>
      </div>
    </div >
  )
}

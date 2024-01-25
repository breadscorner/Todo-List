import { useState, useEffect } from "react";
import "./App.css";

type Todo = {
  id: number;
  title: string;
  completed: boolean;
  created_at: string;
};

export default function App() {
  const [todos, setTodos] = useState<Todo[]>([]);

  console.log(todos, 12);

  useEffect(() => {
    async function fetchTodos() {
      const response = await fetch("/api/todos");
      const data = await response.json();
      setTodos(data);
      console.log(data, 1);
    }
    fetchTodos();
    console.log("Hello");
  }, []);

  return (
    <>
      <h1>Hello</h1>
      {todos.map((todo) => (
        <div key={todo.id}>
          <h2>{todo.title}</h2>
          <p>{todo.completed ? "Completed" : "Not Completed"}</p>
        </div>
      ))}
    </>
  );
}

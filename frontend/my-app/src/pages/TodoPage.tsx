import { useEffect, useState } from "react";
import { getTodos, createTodo, deleteTodo } from "../services/todoService";

export default function TodoPage() {
  const [todos, setTodos] = useState<any[]>([]);
  const [title, setTitle] = useState("");

  useEffect(() => {
    loadTodos();
  }, []);

  async function loadTodos() {
    const data = await getTodos();
    setTodos(data);
  }

  async function handleAdd() {
    await createTodo(title, "Açıklama deneme", new Date().toISOString());
    setTitle("");
    loadTodos();
  }

  async function handleDelete(id: number) {
    await deleteTodo(id);
    loadTodos();
  }

  return (
    <div>
      <h2>Todo List</h2>
      <input value={title} onChange={(e) => setTitle(e.target.value)} placeholder="Yeni Todo" />
      <button onClick={handleAdd}>Ekle</button>
      <ul>
        {todos.map((t) => (
          <li key={t.id}>
            {t.title} <button onClick={() => handleDelete(t.id)}>Sil</button>
          </li>
        ))}
      </ul>
    </div>
  );
}

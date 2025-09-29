import api from "./api";

export async function getTodos() {
  const res = await api.get("/todo");
  return res.data;
}

export async function createTodo(title: string, description: string, dueDate: string) {
  const res = await api.post("/todo", { title, description, dueDate });
  return res.data;
}

export async function updateTodo(id: number, title: string, description: string, dueDate: string, isCompleted: boolean) {
  const res = await api.put(`/todo/${id}`, { title, description, dueDate, isCompleted });
  return res.data;
}

export async function deleteTodo(id: number) {
  return api.delete(`/todo/${id}`);
}

import api from "./api";

export async function getTodos() {
  const res = await api.get("/todo");
  return res.data;
}

export async function createTodo(title: string, description: string, dueDate: string) {
  const res = await api.post("/todo", { title, description, dueDate });
  return res.data;
}

export async function deleteTodo(id: number) {
  await api.delete(`/todo/${id}`);
}

export async function updateTodo(id: number, title: string, description: string, dueDate: string, isCompleted: boolean) {
  try {
    // 🔥 VERİLERİ TEMİZLE VE FORMATLA
    const payload = {
      title: title || '', // null/undefined ise boş string
      description: description || '', // undefined ise boş string
      dueDate: dueDate ? new Date(dueDate).toISOString() : new Date().toISOString(), // Format düzeltme
      isCompleted: isCompleted
    };

    console.log("📡 Backend'e gönderilen TEMİZ veri:", payload);

    const res = await api.put(`/todo/${id}`, payload);
    console.log("📡 Backend'den gelen response:", res.data);
    
    return res.data;
    
  } catch (error) {
    console.error("📡 API Hatası:", error);
    throw error;
  }
}
import axios from "axios";

const api = axios.create({
  baseURL: "http://localhost:5079/api", 
});

// Token varsa header’a ekle
api.interceptors.request.use((config) => {
  const token = localStorage.getItem("token");
  if (token) {
    config.headers.Authorization = `Bearer ${token}`;
  }
  return config;
});

export default api;

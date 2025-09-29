import api from "./api";

export async function login(UserName: string, Password: string) {
  const res = await api.post("/account/login", { UserName, Password });
  if (res.data.token) {
    localStorage.setItem("token", res.data.token);
  }
  return res.data;
}

export async function register(UserName: string, Email: string, Password: string) {
  const res = await api.post("/account/register", { UserName, Email, Password });
  return res.data;
}

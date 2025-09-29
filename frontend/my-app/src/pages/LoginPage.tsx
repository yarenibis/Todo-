import { useState } from "react";
import { login } from "../services/authService";

export default function LoginPage() {
  const [userName, setUserName] = useState("");
  const [password, setPassword] = useState("");

  const handleLogin = async () => {
    try {
      const user = await login(userName, password);
      alert("Giriş başarılı! Token alındı.");
    } catch (err) {
      alert("Login failed!");
    }
  };

  return (
    <div>
      <h2>Login</h2>
      <input placeholder="Username" value={userName} onChange={(e) => setUserName(e.target.value)} />
      <input placeholder="Password" type="password" value={password} onChange={(e) => setPassword(e.target.value)} />
      <button onClick={handleLogin}>Login</button>
    </div>
  );
}

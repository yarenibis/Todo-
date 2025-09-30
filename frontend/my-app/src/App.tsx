import { BrowserRouter as Router, Routes, Route, Link } from "react-router-dom";
import LoginPage from "./pages/LoginPage";
import RegisterPage from "./pages/RegisterPage";
import TodoPage from "./pages/TodoPage";
import { AppBar, Toolbar, Button, Box } from "@mui/material";

export default function App() {
  return (
    <Router>
      {/* Üst Menü */}
      <AppBar position="static">
        <Toolbar>
          <Box sx={{ flexGrow: 1 }}>
            <Button color="inherit" component={Link} to="/login">
              Login
            </Button>
            <Button color="inherit" component={Link} to="/register">
              Register
            </Button>
            <Button color="inherit" component={Link} to="/todos">
              Todos
            </Button>
          </Box>
        </Toolbar>
      </AppBar>

      {/* Sayfa Geçişleri */}
      <Routes>
        <Route path="/login" element={<LoginPage />} />
        <Route path="/register" element={<RegisterPage />} />
        <Route path="/todos" element={<TodoPage />} />
        <Route path="*" element={<LoginPage />} /> {/* Default */}
      </Routes>
    </Router>
  );
}

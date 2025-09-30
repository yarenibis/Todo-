import { useEffect, useState } from "react";
import {
  Container,
  TextField,
  Button,
  Typography,
  Box,
  List,
  ListItem,
  ListItemText,
  Checkbox,
  IconButton,
  Paper,
} from "@mui/material";
import { Delete, Edit } from "@mui/icons-material";
import { getTodos, createTodo, deleteTodo, updateTodo } from "../services/todoService";

export default function TodoPage() {
  const [todos, setTodos] = useState<any[]>([]);
  const [title, setTitle] = useState("");
  const [description, setDescription] = useState("");
  const [dueDate, setDueDate] = useState("");

  useEffect(() => {
    loadTodos();
  }, []);

  async function loadTodos() {
    const data = await getTodos();
    setTodos(data);
  }

  async function handleAdd() {
    if (!title || !dueDate) return;
    await createTodo(title, description, dueDate);
    setTitle("");
    setDescription("");
    setDueDate("");
    loadTodos();
  }

  async function handleDelete(id: number) {
    await deleteTodo(id);
    loadTodos();
  }

  async function handleToggleComplete(todo: any) {
    await updateTodo(
        todo.id, 
        todo.title, 
        todo.description, 
        todo.dueDate, 
        !todo.isCompleted // Yeni durum
      );
    loadTodos();
  }

  return (
    <Container maxWidth="sm">
      <Paper elevation={3} sx={{ p: 4, mt: 4 }}>
        <Typography variant="h5" gutterBottom>
          ✅ Todo List
        </Typography>

        {/* Inputlar */}
        <Box display="flex" flexDirection="column" gap={2}>
          <TextField
            label="Başlık"
            value={title}
            onChange={(e) => setTitle(e.target.value)}
            size="small"
          />
          <TextField
            label="Açıklama"
            value={description}
            onChange={(e) => setDescription(e.target.value)}
            size="small"
          />
          <TextField
            label="Bitiş Tarihi"
            type="date"
            InputLabelProps={{ shrink: true }}
            value={dueDate}
            onChange={(e) => setDueDate(e.target.value)}
            size="small"
          />
          <Button variant="contained" onClick={handleAdd}>
            Ekle
          </Button>
        </Box>
      </Paper>

      {/* Todo Listesi */}
      <List sx={{ mt: 3 }}>
        {todos.map((t) => (
          <ListItem
            key={t.id}
            secondaryAction={
              <>
                <IconButton onClick={() => handleDelete(t.id)}>
                  <Delete />
                </IconButton>
              </>
            }
          >
            <Checkbox
              checked={t.isCompleted}
              onChange={() => handleToggleComplete(t)}
            />
            <ListItemText
              primary={t.title}
              secondary={`Bitiş: ${new Date(t.dueDate).toLocaleDateString()}`}
              sx={{
                textDecoration: t.isCompleted ? "line-through" : "none",
              }}
            />
          </ListItem>
        ))}
      </List>
    </Container>
  );
}

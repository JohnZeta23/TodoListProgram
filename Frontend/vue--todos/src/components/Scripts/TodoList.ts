import { ElMessage } from "element-plus";
import { Options, Vue } from "vue-class-component";
import TodoForm from "../TodoForm.vue";
import axios from "axios";
import VueAxios from "vue-axios";
import { Delete, Edit, Search, Share, Upload } from '@element-plus/icons-vue'

interface Todo {
  id: number;
  title: string;
  completed: boolean;
}

@Options({
  components: {
    TodoForm,
  },
})
export default class TodoList extends Vue {
  todos = [];

  async mounted() {
    await this.loadTodos();
  }
  async loadTodos() {
    const response = await this.axios.get("https://localhost:7002/api/todos");
    this.todos = response.data;
  }
  async createTodo(todo: any) {
    console.log("Todo", todo);
    await this.axios.post("https://localhost:7002/api/todos", {
      title: todo.title,
      completed: todo.completed,
    });
    ElMessage({
      message: "¡Tarea por hacer agregada!",
      type: "success",
    });
    await this.loadTodos();
  }

  async updateTodo(todo: Todo) {
    console.log("Todo", todo);
    await this.axios.put(`https://localhost:7002/api/todos/${todo.id}`, {
      id: todo.id,
      title: todo.title,
      completed: todo.completed,
    });
    ElMessage({
      message: "¡Tarea por hacer editada con exito!",
      type: "success",
    });
    await this.loadTodos();
  }

  async handleDelete(todo: Todo) {
    await this.axios.delete(`https://localhost:7002/api/todos/${todo.id}`);
    ElMessage({
      message: "¡Tarea por hacer eliminada con exito!",
      type: "success",
    });
    await this.loadTodos();
  }

  cancelDelete() {
    console.log("Eliminación de tarea cancelada");
  }
}
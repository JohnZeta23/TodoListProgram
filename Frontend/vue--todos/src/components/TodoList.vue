<template>
  <el-row>
    <el-col :span="12" :offset="7" style="width: 100%">
      <h1>Lista de tareas</h1>
      <todo-Form @send-message="createTodo"></todo-Form>
      <el-table :data="todos">
        <el-table-column prop="title" label="Titulo" width="350" />
        <el-table-column fixed="right" label="Operaciones" width="200">
          <template #default="scope">
              <el-space wrap>
                <el-switch
                  v-model="scope.row.completed"
                  @click="updateTodo(scope.row)"/>
                  <el-popconfirm confirm-button-text="Yes"
                  cancel-button-text="No"
                  icon="el-icon-info"
                  icon-color="red"
                  title="¿Estas seguro que quieres eliminar esta tarea?"
                  @confirm="handleDelete(scope.row)"
                  @cancel="cancelDelete">
                  <template #reference>
                    <el-button size="mini" type="danger">Eliminar</el-button>
                  </template>
                </el-popconfirm>
              </el-space>
          </template>
        </el-table-column>
      </el-table>
    </el-col>
  </el-row>
</template>

<script lang="ts">
import { ElMessage } from "element-plus";
import { Options, Vue } from "vue-class-component";
import TodoForm from "./TodoForm.vue";
import axios from "axios";
import VueAxios from "vue-axios";

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
</script>
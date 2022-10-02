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
                    <el-button size="mini" type="danger">Eliminar
                      <el-icon class="el-icon--right"><Delete /></el-icon>
                    </el-button>
                  </template>
                </el-popconfirm>
              </el-space>
          </template>
        </el-table-column>
      </el-table>
    </el-col>
  </el-row>
</template>

<script lang="ts" src="../components/Scripts/TodoList">

</script>
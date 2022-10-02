<template>
    <el-form @submit.prevent :inline="true" :model="formInput" class="todo-form-input">
        <el-form-item label="Tarea" prop="tittle">
            <el-input v-model="formInput.title" placeholder="Enter todo"></el-input>
        </el-form-item>
        <el-form-item>
            <el-button type="primary" @click="onSubmit()">Add</el-button>
        </el-form-item>
    </el-form>
</template>

<script lang="ts" src="../components/Scripts/TodoForm">

</script>
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

<script lang="ts">
import { ElMessage } from 'element-plus';
import { Options, Vue } from 'vue-class-component';

@Options({})
export default class TodoForm extends Vue{
    formInput = {title: "" , completed: false};

    onSubmit(){
        if(this.formInput.title.length > 3){
        this.$emit('send-message', this.formInput)
        }else{
            ElMessage({
                message : "Advertencia: Esta tarea es muy corta. Dito' vago ",
                type : "warning"
            })
        }
        this.formInput.title = "";
    }
}
</script>



<template>
  <el-container>
    <el-main>
    <TodoList></TodoList>
  </el-main>
</el-container>
</template>

<script lang="ts">
import { Options, Vue } from 'vue-class-component';
import TodoList from './components/TodoList.vue';

@Options({
  components: {
    TodoList,
  },
})
export default class App extends Vue {}
</script>

<style>
  body{
    margin: 0%;
}

.el-container
{
background-color: aliceblue;
color: var(--el-text-color-primary);
text-align: -webkit-center;
}
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
}
</style>

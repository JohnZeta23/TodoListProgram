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
                message : "Advertencia: Esta tarea es muy corta.",
                type : "warning"
            })
        }
        this.formInput.title = "";
    }
}

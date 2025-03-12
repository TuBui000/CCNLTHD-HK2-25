<!-- <script setup>
import axios from 'axios';
import { onMounted, reactive, ref } from 'vue';
import ComfirmDel from './ComfirmDel.vue';
import { useRouter } from 'vue-router';



const todolist = ref([]);
const deleteItemId = ref(0);


let newTodo = reactive({
    title: "",
    date: "",
});


let deleteModalInstance

onMounted(() => {
    deleteModalInstance = new window.bootstrap.Modal(document.getElementById('deleteform'))
    axios.get('https://localhost:7002/api/TodoList')
    .then((response) => {
        todolist.value = response.data;
    });
});

const addTodo = () =>{
    axios.post('https://localhost:7002/api/TodoList', newTodo)
    .then(() =>{
        window.location.reload();
    });
};


const OpenModalDel = (id) => {
    deleteItemId.value = id;
    deleteModalInstance.show();
};

const ConfirmDel = () => {
    axios.delete(`https://localhost:7002/api/TodoList/${deleteItemId.value}`)
    .then(() => {
        todolist.value = todolist.value.filter((u) => u.id !== deleteItemId.value);
    });
    deleteModalInstance.hide();
};

</script> -->
<script setup>

import axios from 'axios';
import { onMounted, ref } from 'vue';
import ComfirmDel from './ComfirmDel.vue';
import { useRouter } from 'vue-router';

const router = useRouter();
const todolist = ref([]);
const deleteItemId = ref(null);


const newTodo = ref({
    title: "",
    date: new Date().toISOString() // 🗓 Lấy ngày hiện tại
});

const cities = (["HN", "HCM"])

let deleteModalInstance;



// Hàm lấy danh sách todo
const getTodos = async () => {
    try {
        const response = await axios.get('https://localhost:7002/api/TodoList');
        todolist.value = response.data;
    } catch (error) {
        console.error("Lỗi khi lấy danh sách todo:", error);
    }
};

// Hàm thêm todo
const addTodo = async () => {
    if (!newTodo.value.title.trim()) return; // Không cho phép thêm todo rỗng

    try {
        const response = await axios.post('https://localhost:7002/api/TodoList', newTodo.value);
        todolist.value.push(response.data);
        newTodo.value.title = ""; // Reset input sau khi thêm
    } catch (error) {
        console.error("Lỗi khi thêm todo:", error);
    }
};

// Hàm mở modal xóa
const OpenModalDel = (id) => {
    deleteItemId.value = id;
    deleteModalInstance.show();
};


// Hàm xác nhận xóa todo
const ConfirmDel = async () => {
    try {
        await axios.delete(`https://localhost:7002/api/TodoList/${deleteItemId.value}`);
        todolist.value = todolist.value.filter(todo => todo.id !== deleteItemId.value);
        deleteModalInstance.hide();
    } catch (error) {
        console.error("Lỗi khi xóa todo:", error);
    }
};

// Khi component được mount, lấy danh sách todo
onMounted(() => {
    deleteModalInstance = new window.bootstrap.Modal(document.getElementById('deleteform'));
    getTodos();
});

</script>

<template>
    <div class="bg-todo d-flex align-items-center justify-content-center vh-100">
        <div class="container text-center w-50">
            <div class="d-flex justify-content-start">
                <RouterLink class="btn btn-secondary" to="/">Home</RouterLink>
            </div>
            <div class="justify-content-center">
                <h2 class="text-dark">TODO LIST</h2>
            </div>
            <form @submit.prevent="addTodo">
                <div class="input-todo mt-3">
                    <div class="input-gr mb-3 w-50">
                        <input type="text" placeholder="Add new todo" aria-label="Add new todo"
                            aria-describedby="button-addtodo" v-model="newTodo.title">
                        <select v-model="newTodo.city" id="comboBox">
                            <option v-for="city in cities" :key="city" :value="city">
                                {{ city }}
                            </option>
                        </select>
                        <button type="submit" id="button-addtodo">
                            <i class="fa-solid fa-plus"></i>
                        </button>
                    </div>
                </div>
            </form>
            <div class="card-todo mt-4 p-5">
                <div class="d-flex justify-content-start mb-2">
                    <h4 class="fst-italic">Todo's</h4>
                </div>
                <div class="scrollbar">
                    <div class="row p-3 align-items-center mt-1" v-for="item in todolist" :key="item.id">
                        <div class="col-1 p-0 ">
                            <i class="fa-regular fa-circle"></i>
                        </div>
                        <div class="col-6 p-0 d-flex justify-content-start fw-medium fs-5">
                            {{ item.title }}
                        </div>
                        <div class="col-1 p-0 d-flex justify-content-start fw-medium fs-5">
                            {{ item.city }}
                        </div>
                        <div class="col-2 p-0 fw-lighter">
                            <!-- chỉ lấy ngày -->
                            {{ item.date.split('T')[0] }}
                        </div>
                        <div class="col-1 p-0 pen ">
                            <RouterLink :to="`/edit/${item.id}`">
                                <i class="fa-regular fa-pen-to-square btn"></i>
                            </RouterLink>
                        </div>
                        <div class="col-1 p-0 trash">
                            <i class="fa-regular fa-trash-can btn" @click="($event) => OpenModalDel(item.id)"></i>
                        </div>
                    </div>
                </div>
            </div>

        </div>
        <ComfirmDel @confirm-delete-click="ConfirmDel"></ComfirmDel>
    </div>
</template>

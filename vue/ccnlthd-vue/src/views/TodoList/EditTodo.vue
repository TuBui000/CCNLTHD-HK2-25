<!-- EditTodo.vue -->
<script setup>
import axios from 'axios';
import { reactive, onMounted } from 'vue';
import { useRoute, useRouter } from 'vue-router';

const route = useRoute();
const router = useRouter();
const cities = ["HN", "HCM"];

let todoToUpdate = reactive({
    id: 0,
    title: '',
    city: '',
    date: ''
});


onMounted(() => {
    axios
        .get(`https://localhost:7002/api/TodoList/${route.params.id}`)
        .then((response) => {
            todoToUpdate.id = response.data.id;
            todoToUpdate.title = response.data.title;
            todoToUpdate.city = response.data.city;
            todoToUpdate.date = response.data.date;
        });
});

// Hàm cập nhật todo
const updateTodo = () => {
    axios.put("https://localhost:7002/api/TodoList", todoToUpdate)
        .then(() => {
            router.push("/todolist")
        });
};

</script>

<template>
    <div class="container mt-4">
        <form @submit.prevent="updateTodo">
            <legend>Update Todo</legend>
            <div class="mb-3">
                <label for="txtTodo" class="form-label">To do</label>
                <input type="text" class="form-control" id="txtTodo" v-model="todoToUpdate.title">
            </div>
            <div class="mb-3">
                <label for="txtcity" class="form-label">Location</label>
                <select v-model="todoToUpdate.city" id="comboBox">
                    <option v-for="city in cities">
                        {{ city }}
                    </option>
                </select>
            </div>
            <button type="submit" class="btn btn-primary">Update</button>
        </form>
    </div>
</template>
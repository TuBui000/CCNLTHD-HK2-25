<script setup>
import HomeView from './HomeView.vue';


const home = {HomeView, path:"/"}

</script>

<template>
    <div class="bg-todo d-flex align-items-center justify-content-center vh-100">
        <div class="container text-center w-50">
            <div class="d-flex justify-content-start">
               <RouterLink class="btn btn-primary" :to="home.path"></RouterLink>
            </div>
            <div class="justify-content-center">
                <h2 class="text-dark">TODO LIST</h2>
            </div>
            <div class="input-todo mt-3">
                <div class="input-gr mb-3 w-50">
                    <input type="text" placeholder="Add new todo" aria-label="Add new todo"
                        aria-describedby="button-addtodo">
                    <button type="button" id="button-addtodo">
                        <i class="fa-solid fa-plus" ></i>
                    </button>
                </div>
            </div>
            <div class="card-todo mt-4 p-4">
                <div class="d-flex justify-content-start">
                    <h4 class="fst-italic">Todo's</h4>
                </div>
                <div class="">
                </div> 
            </div>
        </div>
    </div>
</template>
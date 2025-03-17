import { createRouter, createWebHistory } from "vue-router";
import HomeView from "@/views/HomeView.vue";
import TodoList from "@/views/TodoList/TodoList.vue";
import EditTodo from "@/views/TodoList/EditTodo.vue";
import Weather from "@/views/Weather/Weather.vue";
import Calculator from "@/views/Calculator/Calculator.vue";


const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: HomeView,
    },
    {
      path: '/todolist',
      name: 'todolist',
      component: TodoList,
    },
    {
      path: '/edit/:id',
      name: 'edittodo',
      component: EditTodo,
    },
    {
      path: "/weather",
      name: "weather",
      component: Weather,
    },
    {
      path: "/calculator",
      name: "calculator",
      component: Calculator,
    },
  ],
})

export default router

import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import TodoList from '@/views/TodoList.vue'
import EditTodo from '@/views/EditTodo.vue'

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
  ],
})

export default router
